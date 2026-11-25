using System;
using System.Collections.Generic;
using System.Text;
using Tonsorium.Models;

namespace Tonsorium.Data
{
    public static class EmpresaData
    {
        public static readonly List<AgendamentoHoje> AgendamentosHoje = new()
    {
        new AgendamentoHoje
        {
            Data = "19 de Setembro · Sábado",
            Hora = "9H00",
            Duracao = "50min",
            Iniciais = "GS",
            Cliente = "Gustavo de Souza Prpa",
            Servico = "Corte e barba",
            Status = "Confirmado"
        }
    };

        public static readonly AvaliacaoCliente UltimaAvaliacao = new()
        {
            Iniciais = "GS",
            Cliente = "Gustavo de Souza Prpa",
            Data = "19/09/2026 12:00",
            Estrelas = "★★★★★",
            Nota = "5.0",
            Texto = "profissionais bem atenciosos, gostei muito do corte e do atendimento."
        };
    }
}
