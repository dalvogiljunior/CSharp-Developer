using ProvaMaxima.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaMaxima.Repositorio.Contexto
{
    public class MongoDbConfiguracao
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
