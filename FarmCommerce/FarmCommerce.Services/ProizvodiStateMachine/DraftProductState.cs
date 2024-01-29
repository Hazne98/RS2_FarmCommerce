using AutoMapper;
using Azure.Core;
using EasyNetQ;
using FarmCommerce.Model;
using FarmCommerce.Model.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FarmCommerce.Services.ProizvodiStateMachine
{
    public class DraftProductState : BaseState
    {
        protected ILogger<DraftProductState> _logger;
        public DraftProductState(ILogger<DraftProductState> logger, IServiceProvider serviceProvider, Database.Rs2farmCommerceContext context, IMapper mapper) : base(serviceProvider, context, mapper)
        {
            _logger = logger;
        }

        public override async Task<Proizvodi> Update(int id, ProizvodUpdateRequest request)
        {
            var set = _context.Set<Database.Proizvod>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            if (entity.Cena < 0)
            {
                throw new Exception("Cijena ne moze biti u minusu");
            }

            if (entity.Cena < 1)
            {
                throw new UserException("Cijena ispod minimuma");
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Proizvodi>(entity);
        }

        public override async Task<Proizvodi> Activate(int id)
        {
            _logger.LogInformation($"Aktivacija proizvoda: {id}");
            _logger.LogWarning($"W: Aktivacija proizvoda: {id}");
            _logger.LogError($"E: Aktivacija proizvoda: {id}");

            var set = _context.Set<Database.Proizvod>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "active";

            await _context.SaveChangesAsync();

            //var factory = new ConnectionFactory { HostName = "localhost" };
            //using var connection = factory.CreateConnection();
            //using var channel = connection.CreateModel();

            //channel.QueueDeclare(queue: "product_added",
            //                     durable: false,
            //                     exclusive: false,
            //                     autoDelete: false,
            //                     arguments: null);

            //string message; //$"{entity.ProizvodId}, {entity.ImeProizvoda}";
            //var body = Encoding.UTF8.GetBytes(message);

            //channel.BasicPublish(exchange: string.Empty,
            //                     routingKey: "product_added",
            //                     basicProperties: null,
            //                     body: body);

            var mappedEntity = _mapper.Map<Model.Proizvodi>(entity);

            //using var bus = RabbitHutch.CreateBus("host=localhost");

            //bus.PubSub.Publish(mappedEntity);

            return mappedEntity;
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Update");
            list.Add("Activate");

            return list;
        }
    }
}
