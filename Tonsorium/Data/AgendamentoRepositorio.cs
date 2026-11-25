using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Tonsorium.Models;

namespace Tonsorium.Data;

public static class AgendamentoRepositorio
{
    // Agendamento de exemplo do Studio Black: Matheus, amanhã às 10:30
    private static readonly List<Agendamento> agendamentos = new()
    {
        new Agendamento
        {
            Servico = EstabelecimentosData.Obter("Studio Black").Servicos[0],
            Profissional = EstabelecimentosData.Obter("Studio Black").Equipe[0],
            Inicio = DateTime.Today.AddDays(1).AddHours(10).AddMinutes(30),
            DuracaoMinutos = 45,
            Total = EstabelecimentosData.Obter("Studio Black").Servicos[0].Preco
        }
    };

    public static IReadOnlyList<Agendamento> Todos => agendamentos;

    // "09:00 às 21:00" -> 21:00
    public static TimeSpan FechamentoDe(string funcionamentoHoras)
    {
        var partes = (funcionamentoHoras ?? "").Split("às");
        return TimeSpan.TryParse(partes[^1].Trim(), out var hora)
            ? hora
            : new TimeSpan(21, 0, 0);
    }

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
    public static string? MotivoIndisponivel(
        Profissional profissional, int duracaoMinutos, DateTime inicio, TimeSpan fechamento)
    {
        var fim = inicio.AddMinutes(duracaoMinutos);

        if (inicio <= DateTime.Now)
            return "Este horário já passou.";

        if (fim.TimeOfDay > fechamento)
            return $"O atendimento ultrapassaria o horário de fechamento ({fechamento:hh\\:mm}).";

        bool ocupado = agendamentos.Any(a =>
            a.Profissional.Nome == profissional.Nome &&
            a.Inicio < fim &&
            inicio < a.Fim);

        return ocupado ? "Este profissional já está ocupado nesse horário." : null;
    }

    // Revalida no momento da confirmação
    public static bool Criar(Agendamento novo, TimeSpan fechamento, out string? erro)
    {
        erro = MotivoIndisponivel(novo.Profissional, novo.DuracaoMinutos, novo.Inicio, fechamento);
        if (erro is not null)
            return false;

        agendamentos.Add(novo);
        return true;
    }
}