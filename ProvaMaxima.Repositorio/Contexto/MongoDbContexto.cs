using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProvaMaxima.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MongoDB.Bson.Serialization.Conventions;

namespace ProvaMaxima.Repositorio.Contexto
{
    public sealed class MongoDbContexto
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _clientMongo;
        private readonly MongoDbConfiguracao _mongoDbConfiguracao;

        public MongoDbContexto(IOptions<MongoDbConfiguracao> mongoDbConfiguracao)
        {
            _mongoDbConfiguracao = mongoDbConfiguracao.Value;
            _clientMongo = new MongoClient(mongoDbConfiguracao.Value.ConnectionString);

            if (_clientMongo != null)
            {
                _database = _clientMongo.GetDatabase(mongoDbConfiguracao.Value.DatabaseName);

                SeedMongo();
            }
        }
        public IMongoCollection<T> ObtenhaColecao<T>() where T : class
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        private void SeedMongo()
        {
            if (_clientMongo.ListDatabaseNames().ToList().Any(nome => nome == _mongoDbConfiguracao.DatabaseName))
            {
                return;
            }

            ObtenhaColecao<Usuario>().InsertOne(new Usuario()
            {
                Login = "talentosmaxima",
                Senha = "talentosmaxima"
            });

            ObtenhaColecao<Produto>().InsertMany(new List<Produto>() 
            {
                new Produto()
                {
                    Codigo= "8689",
                    Nome="Fardo 6UN Coca-Cola 600ml",
                    PrecoUnitario=(decimal)17.34,
                    ImagemUrl="foto-coca-cola.png"
                },
                new Produto()
                {
                    Codigo= "8254",
                    Nome="Fardo 6UN Fanta 600ml",
                    PrecoUnitario=(decimal)16.64,
                    ImagemUrl="foto-fanta.png"
                },
            });

            ObtenhaColecao<Cliente>().InsertMany(new List<Cliente>() 
            {
                new Cliente()
                {
                    Codigo= "1",
                    Nome="Cliente 1"
                },
                new Cliente()
                {
                    Codigo= "2",
                    Nome="Cliente 2"
                },
                new Cliente()
                {
                    Codigo= "3",
                    Nome="Cliente 3"
                },
            });
        }
    }
}
