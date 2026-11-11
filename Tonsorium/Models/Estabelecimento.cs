using System;
using System.Collections.Generic;
using System.Text;

namespace Tonsorium.Models
{
    public class Estabelecimento
    {
        public string Nome { get; set; } = "";
        public double Avaliacao { get; set; }
        public string Descricao { get; set; } = "";
        public string Tag { get; set; } = "";
        public string Estrelas => new('★', (int)Math.Round(Avaliacao));
    }

    public class SecaoCarrossel
    {
        public string Titulo { get; set; } = "";
        public string Subtitulo { get; set; } = "";
        public System.Collections.Generic.IList<Estabelecimento> Itens { get; set; }
            = new System.Collections.Generic.List<Estabelecimento>();
    }
}
