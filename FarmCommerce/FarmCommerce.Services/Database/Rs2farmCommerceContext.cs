using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FarmCommerce.Services.Database;

public partial class Rs2farmCommerceContext : DbContext
{
    public Rs2farmCommerceContext()
    {
    }

    public Rs2farmCommerceContext(DbContextOptions<Rs2farmCommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dostava> Dostavas { get; set; }

    public virtual DbSet<Favoriti> Favoritis { get; set; }

    public virtual DbSet<Firma> Firmas { get; set; }

    public virtual DbSet<Kategorija> Kategorijas { get; set; }

    public virtual DbSet<KorisniciUloge> KorisniciUloges { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<Kosarica> Kosaricas { get; set; }

    public virtual DbSet<LokacijaFirme> LokacijaFirmes { get; set; }

    public virtual DbSet<NarudzbaProizvodum> NarudzbaProizvoda { get; set; }

    public virtual DbSet<Oprema> Opremas { get; set; }

    public virtual DbSet<Placanje> Placanjes { get; set; }

    public virtual DbSet<Proizvod> Proizvods { get; set; }

    public virtual DbSet<Recenzija> Recenzijas { get; set; }

    public virtual DbSet<RezervacijaOpreme> RezervacijaOpremes { get; set; }

    public virtual DbSet<StavkaKosarice> StavkaKosarices { get; set; }

    public virtual DbSet<Uloge> Uloges { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RS2FarmCommerce");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dostava>(entity =>
        {
            entity.HasKey(e => e.DostavaId).HasName("PK__Dostava__7E3805C6628AA1BD");

            entity.ToTable("Dostava");

            entity.Property(e => e.DostavaId)
                .ValueGeneratedNever()
                .HasColumnName("DostavaID");
            entity.Property(e => e.LokacijaFirmeId).HasColumnName("LokacijaFirmeID");
            entity.Property(e => e.NarudzbaProizvodaId).HasColumnName("NarudzbaProizvodaID");
            entity.Property(e => e.StatusDostave).HasMaxLength(50);
            entity.Property(e => e.VrijemeDostave).HasColumnType("datetime");

            entity.HasOne(d => d.LokacijaFirme).WithMany(p => p.Dostavas)
                .HasForeignKey(d => d.LokacijaFirmeId)
                .HasConstraintName("FK__Dostava__Lokacij__4AB81AF0");

            entity.HasOne(d => d.NarudzbaProizvoda).WithMany(p => p.Dostavas)
                .HasForeignKey(d => d.NarudzbaProizvodaId)
                .HasConstraintName("FK__Dostava__Narudzb__49C3F6B7");
        });

        modelBuilder.Entity<Favoriti>(entity =>
        {
            entity.HasKey(e => e.FavoritiId).HasName("PK__Favoriti__CF4C8B733BE34349");

            entity.ToTable("Favoriti");

            entity.Property(e => e.FavoritiId)
                .ValueGeneratedNever()
                .HasColumnName("FavoritiID");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
            entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");
            entity.Property(e => e.VrijemeDodavanja).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Favoritis)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__Favoriti__Korisn__5CD6CB2B");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.Favoritis)
                .HasForeignKey(d => d.ProizvodId)
                .HasConstraintName("FK__Favoriti__Proizv__5DCAEF64");
        });

        modelBuilder.Entity<Firma>(entity =>
        {
            entity.HasKey(e => e.FirmaId).HasName("PK__Firma__CD9C5ECFAE0C288E");

            entity.ToTable("Firma");

            entity.Property(e => e.FirmaId)
                .ValueGeneratedNever()
                .HasColumnName("FirmaID");
            entity.Property(e => e.Adresa).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Naziv).HasMaxLength(100);
            entity.Property(e => e.SlikaUrl)
                .HasMaxLength(255)
                .HasColumnName("SlikaURL");
            entity.Property(e => e.Telefon).HasMaxLength(20);
        });

        modelBuilder.Entity<Kategorija>(entity =>
        {
            entity.HasKey(e => e.KategorijaId).HasName("PK__Kategori__6C3B8FCE853F4452");

            entity.ToTable("Kategorija");

            entity.HasIndex(e => e.Naziv, "UQ__Kategori__603E8146ACC6E4EB").IsUnique();

            entity.Property(e => e.KategorijaId)
                .ValueGeneratedNever()
                .HasColumnName("KategorijaID");
            entity.Property(e => e.Naziv).HasMaxLength(50);
        });

        modelBuilder.Entity<KorisniciUloge>(entity =>
        {
            entity.HasKey(e => e.KorisnikUlogaId).HasName("PK__Korisnic__1608720E3356A738");

            entity.ToTable("KorisniciUloge");

            entity.Property(e => e.KorisnikUlogaId)
                .ValueGeneratedNever()
                .HasColumnName("KorisnikUlogaID");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
            entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisniciUloges)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__Korisnici__Koris__2A4B4B5E");

            entity.HasOne(d => d.Uloga).WithMany(p => p.KorisniciUloges)
                .HasForeignKey(d => d.UlogaId)
                .HasConstraintName("FK__Korisnici__Uloga__2B3F6F97");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.KorisnikId).HasName("PK__Korisnik__80B06D61F2F81526");

            entity.ToTable("Korisnik");

            entity.HasIndex(e => e.Email, "UQ__Korisnik__A9D1053447C972BD").IsUnique();

            entity.Property(e => e.KorisnikId)
                .ValueGeneratedNever()
                .HasColumnName("KorisnikID");
            entity.Property(e => e.Adresa).HasMaxLength(255);
            entity.Property(e => e.Drzava).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Grad).HasMaxLength(50);
            entity.Property(e => e.Ime).HasMaxLength(50);
            entity.Property(e => e.Lozinka).HasMaxLength(255);
            entity.Property(e => e.PostanskiBroj).HasMaxLength(20);
            entity.Property(e => e.Prezime).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(20);
        });

        modelBuilder.Entity<Kosarica>(entity =>
        {
            entity.HasKey(e => e.KosaricaId).HasName("PK__Kosarica__0DC8A9B18CC81059");

            entity.ToTable("Kosarica");

            entity.Property(e => e.KosaricaId)
                .ValueGeneratedNever()
                .HasColumnName("KosaricaID");
            entity.Property(e => e.DatumDodavanja).HasColumnType("datetime");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Kosaricas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__Kosarica__Korisn__4D94879B");
        });

        modelBuilder.Entity<LokacijaFirme>(entity =>
        {
            entity.HasKey(e => e.LokacijaFirmeId).HasName("PK__Lokacija__E6AA13BF2C7D7019");

            entity.ToTable("LokacijaFirme");

            entity.Property(e => e.LokacijaFirmeId)
                .ValueGeneratedNever()
                .HasColumnName("LokacijaFirmeID");
            entity.Property(e => e.Adresa).HasMaxLength(255);
            entity.Property(e => e.Drzava).HasMaxLength(50);
            entity.Property(e => e.FirmaId).HasColumnName("FirmaID");
            entity.Property(e => e.Grad).HasMaxLength(50);
            entity.Property(e => e.PostanskiBroj).HasMaxLength(20);

            entity.HasOne(d => d.Firma).WithMany(p => p.LokacijaFirmes)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__LokacijaF__Firma__3A81B327");
        });

        modelBuilder.Entity<NarudzbaProizvodum>(entity =>
        {
            entity.HasKey(e => e.NarudzbaProizvodaId).HasName("PK__Narudzba__F2AB4462629E067D");

            entity.Property(e => e.NarudzbaProizvodaId)
                .ValueGeneratedNever()
                .HasColumnName("NarudzbaProizvodaID");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
            entity.Property(e => e.LokacijaFirmeId).HasColumnName("LokacijaFirmeID");
            entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");
            entity.Property(e => e.StatusNarudzbe).HasMaxLength(50);
            entity.Property(e => e.UkupnaCena).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.NarudzbaProizvoda)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__NarudzbaP__Koris__44FF419A");

            entity.HasOne(d => d.LokacijaFirme).WithMany(p => p.NarudzbaProizvoda)
                .HasForeignKey(d => d.LokacijaFirmeId)
                .HasConstraintName("FK__NarudzbaP__Lokac__46E78A0C");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.NarudzbaProizvoda)
                .HasForeignKey(d => d.ProizvodId)
                .HasConstraintName("FK__NarudzbaP__Proiz__45F365D3");
        });

        modelBuilder.Entity<Oprema>(entity =>
        {
            entity.HasKey(e => e.OpremaId).HasName("PK__Oprema__5C2EDCF1D8BF9897");

            entity.ToTable("Oprema");

            entity.Property(e => e.OpremaId)
                .ValueGeneratedNever()
                .HasColumnName("OpremaID");
            entity.Property(e => e.Cena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FirmaId).HasColumnName("FirmaID");
            entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");
            entity.Property(e => e.LokacijaFirmeId).HasColumnName("LokacijaFirmeID");
            entity.Property(e => e.Naziv).HasMaxLength(100);
            entity.Property(e => e.SlikaUrl)
                .HasMaxLength(255)
                .HasColumnName("SlikaURL");

            entity.HasOne(d => d.Firma).WithMany(p => p.Opremas)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__Oprema__FirmaID__693CA210");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Opremas)
                .HasForeignKey(d => d.KategorijaId)
                .HasConstraintName("FK__Oprema__Kategori__3D5E1FD2");

            entity.HasOne(d => d.LokacijaFirme).WithMany(p => p.Opremas)
                .HasForeignKey(d => d.LokacijaFirmeId)
                .HasConstraintName("FK__Oprema__Lokacija__6B24EA82");
        });

        modelBuilder.Entity<Placanje>(entity =>
        {
            entity.HasKey(e => e.PlacanjeId).HasName("PK__Placanje__DDE16D8CB3CF19FD");

            entity.ToTable("Placanje");

            entity.Property(e => e.PlacanjeId)
                .ValueGeneratedNever()
                .HasColumnName("PlacanjeID");
            entity.Property(e => e.NarudzbaProizvodaId).HasColumnName("NarudzbaProizvodaID");
            entity.Property(e => e.RezervacijaOpremeId).HasColumnName("RezervacijaOpremeID");
            entity.Property(e => e.StatusPlacanja).HasMaxLength(50);
            entity.Property(e => e.TipPlacanja).HasMaxLength(50);
            entity.Property(e => e.UkupanIznos).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.NarudzbaProizvoda).WithMany(p => p.Placanjes)
                .HasForeignKey(d => d.NarudzbaProizvodaId)
                .HasConstraintName("FK__Placanje__Narudz__5441852A");

            entity.HasOne(d => d.RezervacijaOpreme).WithMany(p => p.Placanjes)
                .HasForeignKey(d => d.RezervacijaOpremeId)
                .HasConstraintName("FK__Placanje__Rezerv__5535A963");
        });

        modelBuilder.Entity<Proizvod>(entity =>
        {
            entity.HasKey(e => e.ProizvodId).HasName("PK__Proizvod__21A8BE18CE62E789");

            entity.ToTable("Proizvod");

            entity.Property(e => e.ProizvodId)
                .ValueGeneratedNever()
                .HasColumnName("ProizvodID");
            entity.Property(e => e.Cena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FirmaId).HasColumnName("FirmaID");
            entity.Property(e => e.Naziv).HasMaxLength(100);
            entity.Property(e => e.SlikaUrl)
                .HasMaxLength(255)
                .HasColumnName("SlikaURL");

            entity.HasOne(d => d.Firma).WithMany(p => p.Proizvods)
                .HasForeignKey(d => d.FirmaId)
                .HasConstraintName("FK__Proizvod__FirmaI__34C8D9D1");
        });

        modelBuilder.Entity<Recenzija>(entity =>
        {
            entity.HasKey(e => e.RecenzijaId).HasName("PK__Recenzij__D36C6090A4DA95B7");

            entity.ToTable("Recenzija");

            entity.Property(e => e.RecenzijaId)
                .ValueGeneratedNever()
                .HasColumnName("RecenzijaID");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
            entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");
            entity.Property(e => e.VrijemeRecenzije).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Recenzijas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__Recenzija__Koris__5812160E");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.Recenzijas)
                .HasForeignKey(d => d.ProizvodId)
                .HasConstraintName("FK__Recenzija__Proiz__59FA5E80");

            entity.HasOne(d => d.ProizvodNavigation).WithMany(p => p.Recenzijas)
                .HasForeignKey(d => d.ProizvodId)
                .HasConstraintName("FK__Recenzija__Proiz__59063A47");
        });

        modelBuilder.Entity<RezervacijaOpreme>(entity =>
        {
            entity.HasKey(e => e.RezervacijaOpremeId).HasName("PK__Rezervac__22F5B49C5331D451");

            entity.ToTable("RezervacijaOpreme");

            entity.Property(e => e.RezervacijaOpremeId)
                .ValueGeneratedNever()
                .HasColumnName("RezervacijaOpremeID");
            entity.Property(e => e.DatumRezervacije).HasColumnType("datetime");
            entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
            entity.Property(e => e.LokacijaFirmeId).HasColumnName("LokacijaFirmeID");
            entity.Property(e => e.OpremaId).HasColumnName("OpremaID");
            entity.Property(e => e.StatusRezervacije).HasMaxLength(50);
            entity.Property(e => e.VremePocetka).HasColumnType("datetime");
            entity.Property(e => e.VremeZavrsetka).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.RezervacijaOpremes)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__Rezervaci__Koris__403A8C7D");

            entity.HasOne(d => d.LokacijaFirme).WithMany(p => p.RezervacijaOpremes)
                .HasForeignKey(d => d.LokacijaFirmeId)
                .HasConstraintName("FK__Rezervaci__Lokac__4222D4EF");

            entity.HasOne(d => d.Oprema).WithMany(p => p.RezervacijaOpremes)
                .HasForeignKey(d => d.OpremaId)
                .HasConstraintName("FK__Rezervaci__Oprem__412EB0B6");
        });

        modelBuilder.Entity<StavkaKosarice>(entity =>
        {
            entity.HasKey(e => e.StavkaKosariceId).HasName("PK__StavkaKo__06033BA8394879E4");

            entity.ToTable("StavkaKosarice");

            entity.Property(e => e.StavkaKosariceId)
                .ValueGeneratedNever()
                .HasColumnName("StavkaKosariceID");
            entity.Property(e => e.KosaricaId).HasColumnName("KosaricaID");
            entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

            entity.HasOne(d => d.Kosarica).WithMany(p => p.StavkaKosarices)
                .HasForeignKey(d => d.KosaricaId)
                .HasConstraintName("FK__StavkaKos__Kosar__5070F446");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.StavkaKosarices)
                .HasForeignKey(d => d.ProizvodId)
                .HasConstraintName("FK__StavkaKos__Proiz__5165187F");
        });

        modelBuilder.Entity<Uloge>(entity =>
        {
            entity.HasKey(e => e.UlogaId).HasName("PK__Uloge__DCAB23EB2D277ED6");

            entity.ToTable("Uloge");

            entity.HasIndex(e => e.Naziv, "UQ__Uloge__603E814696D2B7DB").IsUnique();

            entity.Property(e => e.UlogaId)
                .ValueGeneratedNever()
                .HasColumnName("UlogaID");
            entity.Property(e => e.Naziv).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
