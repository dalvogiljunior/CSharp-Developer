using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace ProvaMaxima.Dominio.Entidades
{
    public class Produto:Entidade
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }
        public decimal PrecoUnitario { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarMensagemDeValidacao("O nome do produto não pode ser vazio.");

            if (PrecoUnitario > 0)
                AdicionarMensagemDeValidacao("O valor do produto deve ser maior que 0.");

            if (string.IsNullOrEmpty(ImagemUrl))
                AdicionarMensagemDeValidacao("O url da imagem deve ser informado.");
        }
    }
}
