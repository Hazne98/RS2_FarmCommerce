using AutoMapper;
using FarmCommerce.Model.Requests;
using FarmCommerce.Model.SearchRequests;
using FarmCommerce.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public class KorisniciService : BaseService<Model.Korisnik, Database.Korisnik, KorisnikSearchObject>, IKorisniciService
    {
        private readonly Rs2farmCommerceContext _context;
        public IMapper _mapper { get; set; }
        public KorisniciService(Rs2farmCommerceContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Model.Korisnik>> Get()
        {
            var entityList = await _context.Korisniks.ToListAsync();

            //var list = new List<Model.Korisnik>();            Automapper zamjeni ove linije koda
            //foreach (var item in entityList)
            //{
            //    list.Add(new Model.Korisnik()
            //    {
            //        Email = item.Email,
            //        Ime = item.Ime,
            //        Prezime = item.Prezime,
            //        PostanskiBroj = item.PostanskiBroj,
            //        Telefon = item.Telefon,
            //        Drzava = item.Drzava,
            //        Grad = item.Grad,
            //        Adresa = item.Adresa
            //    });
            //}
            //return list;
            return _mapper.Map<List<Model.Korisnik>>(entityList);
        }

        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            var entity = new Korisnik();
            _mapper.Map(request, entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            _context.Korisniks.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }

        //public override async Task BeforeInsert(Korisnik entity, KorisnikInsertRequest insert)
        //{
        //    entity.LozinkaSalt = GenerateSalt();
        //    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, insert.Lozinka);
        //}

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            var entity = _context.Korisniks.Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }
    }
}