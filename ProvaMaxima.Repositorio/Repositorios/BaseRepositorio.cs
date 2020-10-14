using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using ProvaMaxima.Dominio.Contratos;
using ProvaMaxima.Dominio.Entidades;
using ProvaMaxima.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProvaMaxima.Repositorio.Repositorios
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : Entidade
    {
        protected readonly IMongoCollection<T> ColecaoDoObjeto;

        public BaseRepositorio(MongoDbContexto mongoDbContexto)
        {
            ColecaoDoObjeto = mongoDbContexto.ObtenhaColecao<T>();
        }

        public void Adicionar(T obj)
        {
            ColecaoDoObjeto.InsertOne(obj);
        }

        public void Atualizar(T obj)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var bson = new BsonDocument() {
                { "$set", BsonDocument.Parse(JsonConvert.SerializeObject(obj, serializerSettings)) }
            };

            ColecaoDoObjeto.UpdateOne(FiltroPorId(obj.Id), bson);
        }

        public T ObtenhaPorId(Guid id)
        {
            return ColecaoDoObjeto.Find(FiltroPorId(id)).FirstOrDefault();
        }

        public IEnumerable<T> ObtenhaTodos()
        {
            return ColecaoDoObjeto.Find(_ => true).ToList();
        }

        public void Remover(T obj)
        {
            ColecaoDoObjeto.DeleteOne(FiltroPorId(obj.Id));
        }

        private FilterDefinition<T> FiltroPorId(Guid id)
        {
            return Builders<T>.Filter.Eq("Id", id);
        }
    }
}
