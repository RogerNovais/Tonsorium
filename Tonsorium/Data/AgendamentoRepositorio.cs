using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tonsorium.Models;
using Tonsorium.Views;

namespace Tonsorium.Data
{
    public static class AgendamentoRepositorio
    {
        public static readonly TimeSpan Fechamento = new(21, 0, 0);

        // Agendamento de exemplo para demonstrar o conflito: Matheus amanhã às 10:30
        private static readonly List<Agendamento> agendamentos = new()
    {
        new Agendamento
        {
            Servico = AgendamentoData.Servicos[0],
            Profissional = AgendamentoData.Profissionais[0],
            Inicio = DateTime.Today.AddDays(1).AddHours(10).AddMinutes(30),
            DuracaoMinutos = 45,
            Total = AgendamentoData.Servicos[0].Preco
        }
    };

        public static IReadOnlyList<Agendamento> Todos => agendamentos;

        // "45 min" -> 45 | "1h 15min" -> 75
        public static int MinutosDe(string duracao)
        {
            var horas = Regex.Match(duracao ?? "", @"(\d+)\s*h");
            var minutos = Regex.Match(duracao ?? "", @"(\d+)\s*min");

            int h = horas.Success ? int.Parse(horas.Groups[1].Value) : 0;
            int m = minutos.Success ? int.Parse(minutos.Groups[1].Value) : 0;

            int total = h * 60 + m;
            return total > 0 ? total : 30;
        }

        // Retorna null quando o horário está livre; caso contrário, o motivo
        public static string? MotivoIndisponivel(Profissional profissional, int duracaoMinutos, DateTime inicio)
        {
            var fim = inicio.AddMinutes(duracaoMinutos);

            if (inicio <= DateTime.Now)
                return "Este horário já passou.";

            if (fim.TimeOfDay > Fechamento)
                return "O atendimento ultrapassaria o horário de fechamento (21:00).";

            bool ocupado = agendamentos.Any(a =>
                a.Profissional.Nome == profissional.Nome &&
                a.Inicio < fim &&
                inicio < a.Fim);

            return ocupado ? "Este profissional já está ocupado nesse horário." : null;
        }

        // Revalida no momento da confirmação (outro usuário pode ter reservado antes)
        public static bool Criar(Agendamento novo, out string? erro)
        {
            erro = MotivoIndisponivel(novo.Profissional, novo.DuracaoMinutos, novo.Inicio);
            if (erro is not null)
                return false;

            agendamentos.Add(novo);
            return true;
        }
    }
}
