using System.Globalization;
using System.Windows.Input;
using Tonsorium.Data;
using Tonsorium.Models;

namespace Tonsorium.Views;

public static class AgendamentoData
{
    // STATIC READONLY: instância única. Era o bug da seleção: "=> new()" criava
    // listas novas a cada acesso, então "s == servicoSelecionado" nunca era verdadeiro.
    public static readonly string[] IconesServicos = { "✂", "◈", "✦", "◆" };

    public static readonly List<Servico> Servicos = new()
    {
        new Servico { Numero = "01", Nome = "Corte Masculino", Preco = "R$ 55", Duracao = "45 min",
            Descricao = "Corte personalizado de acordo com seu estilo." },
        new Servico { Numero = "02", Nome = "Degradê", Preco = "R$ 45", Duracao = "40 min",
            Descricao = "Fade moderno com acabamento preciso." },
        new Servico { Numero = "03", Nome = "Barba", Preco = "R$ 35", Duracao = "30 min",
            Descricao = "Modelagem e acabamento completo." },
        new Servico { Numero = "04", Nome = "Corte + Barba", Preco = "R$ 80", Duracao = "1h 15min",
            Descricao = "A experiência completa para renovar seu visual." },
    };

    public static readonly List<Profissional> Profissionais = new()
    {
        new Profissional { Iniciais = "MS", Nome = "Matheus Silva", Cargo = "Especialista em degradê", Tags = "★ 4.9" },
        new Profissional { Iniciais = "RC", Nome = "Rafael Costa", Cargo = "Especialista em barba", Tags = "★ 4.8" },
        new Profissional { Iniciais = "GL", Nome = "Gabriel Lima", Cargo = "Especialista em cachos", Tags = "★ 5.0" },
    };

    public static readonly string[] Horarios =
    {
        "09:00", "09:45", "10:30", "11:15", "13:00", "13:45", "14:30",
        "15:15", "16:00", "16:45", "17:30", "18:15", "19:00", "19:45", "20:30",
    };
}