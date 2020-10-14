using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProvaMaxima.Dominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao;
        private List<string> mensagemValidacao => _mensagensValidacao ?? (_mensagensValidacao = new List<string>());
        [BsonId]
        public Guid Id { get; set; }
        public abstract void Validate();
        protected bool EhValido => !mensagemValidacao.Any();
        protected void LimparMensagensDeValidacao()
        {
            mensagemValidacao.Clear();
        }
        protected void AdicionarMensagemDeValidacao(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }
    }
}
