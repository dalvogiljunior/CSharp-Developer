using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaMaxima.Dominio.Entidades
{
    public class Cliente:Entidade
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Codigo))
                AdicionarMensagemDeValidacao("Código do cliente não pode ser vazio.");

            if (string.IsNullOrEmpty(Nome))
                AdicionarMensagemDeValidacao("Nome do cliente não pode vazio.");
        }
    }
}
