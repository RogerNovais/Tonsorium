using System;
using System.Collections.Generic;
using System.Text;

namespace Tonsorium.Models
{
    public class OpcaoServico
    {
        public string Icone { get; set; } = "";
        public Servico Servico { get; set; } = new();
        public bool Selecionado { get; set; }
        public string CorBorda => Selecionado ? "#f5a623" : "#333333";
        public string CorFundo => Selecionado ? "#261c08" : "#111111";
        public string Marcador => Selecionado ? "✓ Selecionado" : "";
    }

    public class OpcaoProfissional
    {
        public Profissional Profissional { get; set; } = new();
        public bool Selecionado { get; set; }
        public string CorBorda => Selecionado ? "#f5a623" : "#333333";
        public string CorFundo => Selecionado ? "#261c08" : "#111111";
        public string Marcador => Selecionado ? "✓" : "";
    }

    public class OpcaoHorario
    {
        public string Hora { get; set; } = "";
        public bool Selecionado { get; set; }
        public bool EValido { get; set; } = true;
        public string Motivo { get; set; } = "";

        public string CorBorda => !EValido ? "#1a1a1a" : Selecionado ? "White" : "#333333";
        public string CorFundo => !EValido ? "#0a0a0a" : Selecionado ? "White" : "#111111";
        public string CorTexto => !EValido ? "#444444" : Selecionado ? "Black" : "#cccccc";
    }

    public class DiaCalendario
    {
        public string Numero { get; set; } = "";
        public DateTime Data { get; set; }
        public bool EValido { get; set; } = true;
        public bool Selecionado { get; set; }
        public string Parametro => Data.ToString("yyyy-MM-dd");

        public string CorBorda =>
            string.IsNullOrEmpty(Numero) ? "Transparent" :
            !EValido ? "#1a1a1a" :
            Selecionado ? "White" : "#333333";

        public string CorFundo =>
            string.IsNullOrEmpty(Numero) ? "Transparent" :
            !EValido ? "#0a0a0a" :
            Selecionado ? "White" : "Transparent";

        public string CorTexto =>
            !EValido ? "#555555" :
            Selecionado ? "Black" : "White";
    }

    public class Agendamento
    {
        public Servico Servico { get; set; } = new();
        public Profissional Profissional { get; set; } = new();
        public DateTime Inicio { get; set; }
        public int DuracaoMinutos { get; set; }
        public DateTime Fim => Inicio.AddMinutes(DuracaoMinutos);
        public string Total { get; set; } = "";
    }
}
