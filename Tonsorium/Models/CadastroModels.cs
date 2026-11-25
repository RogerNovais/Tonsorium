using System;
using System.Collections.Generic;
using System.Text;

namespace Tonsorium.Models
{
    public class OpcaoChip
    {
        public string Texto { get; set; } = "";
        public bool Selecionado { get; set; }
        public string CorFundo => Selecionado ? "White" : "#111111";
        public string CorTexto => Selecionado ? "Black" : "#cccccc";
        public string CorBorda => Selecionado ? "White" : "#333333";
    }
}
