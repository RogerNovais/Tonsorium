using System;
using System.Collections.Generic;
using System.Text;

namespace Tonsorium.Models
{
    public class AgendamentoHoje
    {
        public string Data { get; set; } = "";
        public string Hora { get; set; } = "";
        public string Duracao { get; set; } = "";
        public string Iniciais { get; set; } = "";
        public string Cliente { get; set; } = "";
        public string Servico { get; set; } = "";
        public string Status { get; set; } = "";

        public string HoraDuracao => $"{Hora} · {Duracao}";
        public string CorStatus => Status == "Confirmado" ? "#4cd964" : "#f5a623";
    }

    public class AvaliacaoCliente
    {
        public string Iniciais { get; set; } = "";
        public string Cliente { get; set; } = "";
        public string Data { get; set; } = "";
        public string Estrelas { get; set; } = "";
        public string Nota { get; set; } = "";
        public string Texto { get; set; } = "";

        public string RotuloAtendimento => $"Atendimento {Nota}";
    }
}
