using System.Windows.Input;
using Tonsorium.Data;
using Tonsorium.Models;

namespace Tonsorium.Views;

public partial class PaginaCadastro : ContentPage
{
    private static readonly string[] Generos = { "Masculino", "Feminino", "Outro" };
    private static readonly string[] TiposCabelo = { "Liso", "Ondulado", "Cacheado", "Crespo" };

    private string? generoSelecionado;
    private string? cabeloSelecionado;
    private string? publicoSelecionado;
    private bool ehEmpresa;

    public PaginaCadastro()
    {
        // Comandos ANTES do InitializeComponent
        VoltarCommand = new Command(async () => await Navigation.PopAsync());
        AlternarTipoCommand = new Command<string>(tipo =>
        {
            ehEmpresa = tipo == "Empresa";
            AtualizarTipo();
        });
        SelecionarGeneroCommand = new Command<string>(g =>
        {
            generoSelecionado = g;
            GenerosVisiveis = Montar(Generos, g);
        });
        SelecionarCabeloCommand = new Command<string>(c =>
        {
            cabeloSelecionado = c;
            CabelosVisiveis = Montar(TiposCabelo, c);
        });
        SelecionarPublicoCommand = new Command<string>(p =>
        {
            publicoSelecionado = p;
            PublicosVisiveis = Montar(TiposCabelo, p);
        });
        CriarContaCommand = new Command(async () => await CriarConta());

        // Listas prontas ANTES do BindingContext: era isso que deixava os chips vazios
        GenerosVisiveis = Montar(Generos, null);
        CabelosVisiveis = Montar(TiposCabelo, null);
        PublicosVisiveis = Montar(TiposCabelo, null);

        InitializeComponent();
        BindingContext = this;
    }

    public ICommand VoltarCommand { get; }
    public ICommand AlternarTipoCommand { get; }
    public ICommand SelecionarGeneroCommand { get; }
    public ICommand SelecionarCabeloCommand { get; }
    public ICommand SelecionarPublicoCommand { get; }
    public ICommand CriarContaCommand { get; }

    // Chips: notificam a tela quando a lista muda
    private List<OpcaoChip> generosVisiveis = new();
    public List<OpcaoChip> GenerosVisiveis
    {
        get => generosVisiveis;
        private set { generosVisiveis = value; OnPropertyChanged(nameof(GenerosVisiveis)); }
    }

    private List<OpcaoChip> cabelosVisiveis = new();
    public List<OpcaoChip> CabelosVisiveis
    {
        get => cabelosVisiveis;
        private set { cabelosVisiveis = value; OnPropertyChanged(nameof(CabelosVisiveis)); }
    }

    private List<OpcaoChip> publicosVisiveis = new();
    public List<OpcaoChip> PublicosVisiveis
    {
        get => publicosVisiveis;
        private set { publicosVisiveis = value; OnPropertyChanged(nameof(PublicosVisiveis)); }
    }

    private static List<OpcaoChip> Montar(string[] opcoes, string? selecionado)
        => opcoes.Select(o => new OpcaoChip { Texto = o, Selecionado = o == selecionado }).ToList();

    // Alternância Cliente / Empresa
    public bool EhCliente => !ehEmpresa;
    public bool EhEmpresa => ehEmpresa;
    public string CorTabCliente => ehEmpresa ? "#111111" : "White";
    public string CorTabEmpresa => ehEmpresa ? "White" : "#111111";
    public string CorTextoTabCliente => ehEmpresa ? "#aaaaaa" : "Black";
    public string CorTextoTabEmpresa => ehEmpresa ? "Black" : "#aaaaaa";

    private void AtualizarTipo()
    {
        OnPropertyChanged(nameof(EhCliente));
        OnPropertyChanged(nameof(EhEmpresa));
        OnPropertyChanged(nameof(CorTabCliente));
        OnPropertyChanged(nameof(CorTabEmpresa));
        OnPropertyChanged(nameof(CorTextoTabCliente));
        OnPropertyChanged(nameof(CorTextoTabEmpresa));
    }

    // Campos do cliente
    public string Nome { get; set; } = "";
    public string Sobrenome { get; set; } = "";
    public string DataNascimento { get; set; } = "";
    public string Telefone { get; set; } = "";
    public string Email { get; set; } = "";
    public string Cpf { get; set; } = "";
    public string Senha { get; set; } = "";

    // Campos da empresa
    public string Cnpj { get; set; } = "";
    public string NomeEmpresa { get; set; } = "";
    public string EmailEmpresa { get; set; } = "";
    public string TelefoneEmpresa { get; set; } = "";
    public string Localizacao { get; set; } = "";
    public string SenhaEmpresa { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string ContadorDescricao => $"{Descricao.Length}/300";

    private void OnDescricaoTextChanged(object? sender, TextChangedEventArgs e)
    {
        Descricao = e.NewTextValue ?? "";
        OnPropertyChanged(nameof(ContadorDescricao));
    }

    // Validação em tempo real

    private void OnEmailTextChanged(object? sender, TextChangedEventArgs e)
        => MostrarAviso(AvisoEmail, e.NewTextValue, Validacoes.EmailValido);

    private void OnEmailEmpresaTextChanged(object? sender, TextChangedEventArgs e)
        => MostrarAviso(AvisoEmailEmpresa, e.NewTextValue, Validacoes.EmailValido);

    private void OnSenhaTextChanged(object? sender, TextChangedEventArgs e)
        => MostrarAviso(AvisoSenha, e.NewTextValue, Validacoes.SenhaValida);

    private void OnSenhaEmpresaTextChanged(object? sender, TextChangedEventArgs e)
        => MostrarAviso(AvisoSenhaEmpresa, e.NewTextValue, Validacoes.SenhaValida);

    private void OnCpfTextChanged(object? sender, TextChangedEventArgs e)
    {
        var mascara = Validacoes.MascaraCpf(e.NewTextValue);
        if (CampoCpf.Text != mascara)
            CampoCpf.Text = mascara;

        // Só acusa erro quando o CPF já está completo
        AvisoCpf.IsVisible = mascara.Length == 14 && !Validacoes.CpfValido(mascara);
    }

    private void OnDataTextChanged(object? sender, TextChangedEventArgs e)
    {
        var mascara = Validacoes.MascaraData(e.NewTextValue);
        if (CampoData.Text != mascara)
            CampoData.Text = mascara;

        // Só acusa erro quando a data já está completa
        AvisoData.IsVisible = mascara.Length == 10 && !Validacoes.DataValida(mascara, out _);
    }

    private static void MostrarAviso(Label aviso, string? texto, Func<string?, bool> valido)
        => aviso.IsVisible = !string.IsNullOrEmpty(texto) && !valido(texto);

    // Validação ao criar a conta

    private async Task CriarConta()
    {
        var erro = ehEmpresa ? ValidarEmpresa() : ValidarCliente();
        if (erro is not null)
        {
            await DisplayAlert("Atenção", erro, "OK");
            return;
        }

        await DisplayAlert("Cadastro validado",
            ehEmpresa
                ? "Dados da empresa validados. A gravação será feita na próxima etapa."
                : "Dados do cliente validados. A gravação será feita na próxima etapa.",
            "OK");
    }

    private string? ValidarCliente()
    {
        if (string.IsNullOrWhiteSpace(Nome)) return "Informe seu nome.";
        if (string.IsNullOrWhiteSpace(Sobrenome)) return "Informe seu sobrenome.";
        if (generoSelecionado is null) return "Selecione o gênero.";
        if (cabeloSelecionado is null) return "Selecione o tipo de cabelo.";
        if (!Validacoes.DataValida(DataNascimento, out _)) return "Informe uma data de nascimento válida (dd/mm/aaaa).";
        if (!Validacoes.CpfValido(Cpf)) return "Informe um CPF válido.";
        if (!Validacoes.EmailValido(Email)) return "Informe um e-mail válido.";
        if (!Validacoes.SenhaValida(Senha)) return "A senha precisa ter 6+ caracteres, com maiúscula, minúscula, número e caractere especial.";
        return null;
    }

    private string? ValidarEmpresa()
    {
        if (Cnpj.Count(char.IsDigit) != 14) return "Informe um CNPJ com 14 dígitos.";
        if (string.IsNullOrWhiteSpace(NomeEmpresa)) return "Informe o nome da empresa.";
        if (!Validacoes.EmailValido(EmailEmpresa)) return "Informe um e-mail válido.";
        if (publicoSelecionado is null) return "Selecione o público-alvo.";
        if (!Validacoes.SenhaValida(SenhaEmpresa)) return "A senha precisa ter 6+ caracteres, com maiúscula, minúscula, número e caractere especial.";
        return null;
    }
}