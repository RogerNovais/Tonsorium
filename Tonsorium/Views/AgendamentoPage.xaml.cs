using System.Globalization;
using System.Windows.Input;
using Tonsorium.Data;
using Tonsorium.Models;

namespace Tonsorium.Views;

public partial class AgendamentoPage : ContentPage
{
    private static readonly string[] Meses =
        { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho",
          "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

    private int etapaAtual = 1;
    private DateTime mesExibido;
    private Servico? servicoSelecionado;
    private Profissional? profissionalSelecionado;
    private DateTime? dataSelecionada;
    private string? horarioSelecionado;

    public AgendamentoPage()
    {
        // Comandos ANTES do InitializeComponent
        SelecionarServicoCommand = new Command<string>(SelecionarServico);
        SelecionarProfissionalCommand = new Command<string>(SelecionarProfissional);
        SelecionarDiaCommand = new Command<string>(SelecionarDia);
        SelecionarHorarioCommand = new Command<string>(SelecionarHorario);
        MesAnteriorCommand = new Command(() => { mesExibido = mesExibido.AddMonths(-1); ConstruirCalendario(); });
        MesSeguinteCommand = new Command(() => { mesExibido = mesExibido.AddMonths(1); ConstruirCalendario(); });
        AvancarCommand = new Command(Avancar);
        VoltarEtapaCommand = new Command(VoltarEtapa);
        ConfirmarCommand = new Command(Confirmar);

        InitializeComponent();
        BindingContext = this;

        mesExibido = DateTime.Today;
        ReconstruirOpcoes();
        ConstruirCalendario();
        ReconstruirHorarios();
        AtualizarVisibilidade();
    }

    public ICommand SelecionarServicoCommand { get; }
    public ICommand SelecionarProfissionalCommand { get; }
    public ICommand SelecionarDiaCommand { get; }
    public ICommand SelecionarHorarioCommand { get; }
    public ICommand MesAnteriorCommand { get; }
    public ICommand MesSeguinteCommand { get; }
    public ICommand AvancarCommand { get; }
    public ICommand VoltarEtapaCommand { get; }
    public ICommand ConfirmarCommand { get; }

    private List<OpcaoServico> opcoesServico = new();
    public List<OpcaoServico> OpcoesServico
    {
        get => opcoesServico;
        set { opcoesServico = value; OnPropertyChanged(nameof(OpcoesServico)); }
    }

    private List<OpcaoProfissional> opcoesProfissionais = new();
    public List<OpcaoProfissional> OpcoesProfissionais
    {
        get => opcoesProfissionais;
        set { opcoesProfissionais = value; OnPropertyChanged(nameof(OpcoesProfissionais)); }
    }

    private List<DiaCalendario> diasVisiveis = new();
    public List<DiaCalendario> DiasVisiveis
    {
        get => diasVisiveis;
        set { diasVisiveis = value; OnPropertyChanged(nameof(DiasVisiveis)); }
    }

    private List<OpcaoHorario> horariosVisiveis = new();
    public List<OpcaoHorario> HorariosVisiveis
    {
        get => horariosVisiveis;
        set { horariosVisiveis = value; OnPropertyChanged(nameof(HorariosVisiveis)); }
    }

    public string LegendaHorarios =>
        dataSelecionada is null
            ? "Selecione uma data para ver os horários."
            : "Apagados: já passaram, estão ocupados ou ultrapassam o fechamento (21:00).";

    private void ReconstruirOpcoes()
    {
        var icones = AgendamentoData.IconesServicos;

        OpcoesServico = AgendamentoData.Servicos.Select((s, i) => new OpcaoServico
        {
            Icone = i < icones.Length ? icones[i] : "✂",
            Servico = s,
            Selecionado = s.Nome == servicoSelecionado?.Nome
        }).ToList();

        OpcoesProfissionais = AgendamentoData.Profissionais.Select(p => new OpcaoProfissional
        {
            Profissional = p,
            Selecionado = p.Nome == profissionalSelecionado?.Nome
        }).ToList();
    }

    // Horários: recalculados sempre que data, profissional ou serviço mudam
    private void ReconstruirHorarios()
    {
        var itens = AgendamentoData.Horarios
            .Select(h => (Hora: h, Motivo: MotivoDoHorario(h)))
            .ToList();

        // Se o horário escolhido virou indisponível, a seleção é desfeita
        if (horarioSelecionado is not null &&
            itens.Any(i => i.Hora == horarioSelecionado && i.Motivo is not null))
        {
            horarioSelecionado = null;
        }

        HorariosVisiveis = itens.Select(i => new OpcaoHorario
        {
            Hora = i.Hora,
            EValido = i.Motivo is null,
            Motivo = i.Motivo ?? "",
            Selecionado = i.Hora == horarioSelecionado
        }).ToList();

        OnPropertyChanged(nameof(LegendaHorarios));
        AtualizarResumo();
    }

    private string? MotivoDoHorario(string hora)
    {
        if (dataSelecionada is null || profissionalSelecionado is null || servicoSelecionado is null)
            return null;

        var inicio = dataSelecionada.Value.Date.Add(TimeSpan.Parse(hora));
        return AgendamentoRepositorio.MotivoIndisponivel(
            profissionalSelecionado,
            AgendamentoRepositorio.MinutosDe(servicoSelecionado.Duracao),
            inicio);
    }

    // Calendário: bloqueia dias passados e meses anteriores ao atual

    public string MesAnoTitulo => $"{Meses[mesExibido.Month - 1]} {mesExibido.Year}";

   

    // Seleções

    private void SelecionarServico(string nome)
    {
        servicoSelecionado = AgendamentoData.Servicos.First(s => s.Nome == nome);
        ReconstruirOpcoes();
        ReconstruirHorarios(); // a duração do serviço muda os horários livres
    }

    private void SelecionarProfissional(string nome)
    {
        profissionalSelecionado = AgendamentoData.Profissionais.First(p => p.Nome == nome);
        ReconstruirOpcoes();
        ReconstruirHorarios(); // agenda é por profissional
    }


    public string DataTexto => dataSelecionada?.ToString("dd/MM/yyyy") ?? "-";

    private async void SelecionarHorario(string hora)
    {
        var opcao = HorariosVisiveis.FirstOrDefault(o => o.Hora == hora);
        if (opcao is null)
            return;

        if (!opcao.EValido)
        {
            await DisplayAlert("Horário indisponível", opcao.Motivo, "OK");
            return;
        }

        horarioSelecionado = hora;
        ReconstruirHorarios();
    }

    // Um dia só fica disponível se ainda houver algum horário possível nele
    private bool DiaTemHorario(DateTime data)
    {
        if (data.Date < DateTime.Today)
            return false;

        if (data.Date > DateTime.Today)
            return true;

        // Hoje: precisa existir um horário futuro que caiba antes do fechamento
        var agora = DateTime.Now;
        return AgendamentoData.Horarios.Any(h =>
        {
            var inicio = data.Date.Add(TimeSpan.Parse(h));
            return inicio > agora &&
                   inicio.TimeOfDay.Add(TimeSpan.FromMinutes(30)) <= AgendamentoRepositorio.Fechamento;
        });
    }

    private void ConstruirCalendario()
    {
        var inicioMesAtual = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        if (mesExibido < inicioMesAtual)
            mesExibido = inicioMesAtual;

        var primeiroDia = new DateTime(mesExibido.Year, mesExibido.Month, 1);
        var deslocamento = (int)primeiroDia.DayOfWeek;
        var totalDias = DateTime.DaysInMonth(mesExibido.Year, mesExibido.Month);

        var lista = new List<DiaCalendario>();
        for (int i = 0; i < deslocamento; i++)
            lista.Add(new DiaCalendario { Numero = "", EValido = false });

        for (int d = 1; d <= totalDias; d++)
        {
            var data = new DateTime(mesExibido.Year, mesExibido.Month, d);
            lista.Add(new DiaCalendario
            {
                Numero = d.ToString(),
                Data = data,
                EValido = DiaTemHorario(data),
                Selecionado = dataSelecionada == data
            });
        }

        DiasVisiveis = lista;
        OnPropertyChanged(nameof(MesAnoTitulo));
    }

    private void SelecionarDia(string parametro)
    {
        var data = DateTime.ParseExact(parametro, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        // Trava: dia sem horário possível não pode ser selecionado
        if (!DiaTemHorario(data))
            return;

        dataSelecionada = data;
        ConstruirCalendario();
        ReconstruirHorarios();
        OnPropertyChanged(nameof(DataTexto));
    }

    // Stepper de etapas

    public bool Etapa1Visivel => etapaAtual == 1;
    public bool Etapa2Visivel => etapaAtual == 2;
    public bool Etapa3Visivel => etapaAtual == 3;
    public bool Etapa4Visivel => etapaAtual == 4;
    public bool Etapa5Visivel => etapaAtual == 5;

    public string Circulo1Cor => etapaAtual >= 1 ? "#f5a623" : "#555555";
    public string Circulo2Cor => etapaAtual >= 2 ? "#f5a623" : "#555555";
    public string Circulo3Cor => etapaAtual >= 3 ? "#f5a623" : "#555555";
    public string Circulo4Cor => etapaAtual >= 4 ? "#f5a623" : "#555555";
    public string Circulo5Cor => etapaAtual >= 5 ? "#f5a623" : "#555555";

    public string ContadorEtapas => $"{etapaAtual} de 5";

    private async void Avancar()
    {
        var pendencia =
            etapaAtual == 1 && servicoSelecionado is null ? "Selecione um serviço." :
            etapaAtual == 2 && profissionalSelecionado is null ? "Selecione um profissional." :
            etapaAtual == 3 && dataSelecionada is null ? "Selecione uma data." :
            etapaAtual == 4 && horarioSelecionado is null ? "Selecione um horário disponível." :
            null;

        if (pendencia is not null)
        {
            await DisplayAlert("Atenção", pendencia, "OK");
            return;
        }

        if (etapaAtual < 5)
        {
            etapaAtual++;
            AtualizarVisibilidade();
        }
    }

    private void VoltarEtapa()
    {
        if (etapaAtual > 1)
        {
            etapaAtual--;
            AtualizarVisibilidade();
        }
    }

    private void AtualizarVisibilidade()
    {
        OnPropertyChanged(nameof(Etapa1Visivel));
        OnPropertyChanged(nameof(Etapa2Visivel));
        OnPropertyChanged(nameof(Etapa3Visivel));
        OnPropertyChanged(nameof(Etapa4Visivel));
        OnPropertyChanged(nameof(Etapa5Visivel));
        OnPropertyChanged(nameof(Circulo1Cor));
        OnPropertyChanged(nameof(Circulo2Cor));
        OnPropertyChanged(nameof(Circulo3Cor));
        OnPropertyChanged(nameof(Circulo4Cor));
        OnPropertyChanged(nameof(Circulo5Cor));
        OnPropertyChanged(nameof(ContadorEtapas));
        AtualizarResumo();
    }

    private void AtualizarResumo()
    {
        OnPropertyChanged(nameof(ResumoServico));
        OnPropertyChanged(nameof(ResumoProfissional));
        OnPropertyChanged(nameof(ResumoData));
        OnPropertyChanged(nameof(ResumoHorario));
        OnPropertyChanged(nameof(ResumoTotal));
    }

    public string ResumoServico => servicoSelecionado?.Nome ?? "-";
    public string ResumoProfissional => profissionalSelecionado?.Nome ?? "-";
    public string ResumoData => dataSelecionada?.ToString("dd/MM/yyyy") ?? "-";
    public string ResumoHorario => horarioSelecionado ?? "-";
    public string ResumoTotal => servicoSelecionado is null ? "R$ 0,00" : $"{servicoSelecionado.Preco},00";

    private async void Confirmar()
    {
        if (servicoSelecionado is null || profissionalSelecionado is null ||
            dataSelecionada is null || horarioSelecionado is null)
        {
            await DisplayAlert("Atenção", "Complete todas as etapas antes de confirmar.", "OK");
            return;
        }

        var inicio = dataSelecionada.Value.Date.Add(TimeSpan.Parse(horarioSelecionado));

        var agendamento = new Agendamento
        {
            Servico = servicoSelecionado,
            Profissional = profissionalSelecionado,
            Inicio = inicio,
            DuracaoMinutos = AgendamentoRepositorio.MinutosDe(servicoSelecionado.Duracao),
            Total = servicoSelecionado.Preco
        };

        if (!AgendamentoRepositorio.Criar(agendamento, out var erro))
        {
            await DisplayAlert("Horário indisponível",
                erro ?? "Esse horário não está mais disponível.", "OK");

            horarioSelecionado = null;
            etapaAtual = 4;
            ReconstruirHorarios();
            AtualizarVisibilidade();
            return;
        }

        await DisplayAlert("Agendamento confirmado",
            $"{agendamento.Servico.Nome} com {agendamento.Profissional.Nome}\n" +
            $"{inicio:dd/MM/yyyy} às {inicio:HH:mm}\n" +
            $"Total: {agendamento.Total}",
            "OK");

        await Navigation.PopAsync();
    }

    private void OnVoltarPerfilClicked(object sender, EventArgs e)
        => Navigation.PopAsync();
}