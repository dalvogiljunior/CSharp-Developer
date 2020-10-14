using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaMaxima.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public override void Validate()
        {
        }
    }
}
