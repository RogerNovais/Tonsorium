using System.Windows.Input;
using Tonsorium.Data;
using Tonsorium.Models;

namespace Tonsorium.Views;

public partial class PaginaUsuario : ContentPage
{
    private static readonly Dictionary<string, string[]> MapaFiltros = new()
    {
        ["Cabelos Cacheados"] = new[] { "Cacheados" },
        ["Cabelos Crespos"] = new[] { "Crespos" },
        ["Barba"] = new[] { "Masculino" },
        ["Manicure"] = new[] { "Manicure" },
    };

    private readonly List<SecaoCarrossel> todasSecoes;
    private string filtroAtual;

    public PaginaUsuario()
    {
        // Comandos ANTES do InitializeComponent
        FiltrarCommand = new Command<string>(AplicarFiltro);
        AbrirPerfilCommand = new Command<string>(AbrirPerfil);
        AbrirUtensiliosCommand = new Command(async () => await Navigation.PushAsync(new UtensiliosPage()));

        InitializeComponent();
        BindingContext = this;

        todasSecoes = HomeData.Secoes.ToList();
        SecoesVisiveis = todasSecoes;
    }

    public ICommand FiltrarCommand { get; }
    public ICommand AbrirPerfilCommand { get; }
    public ICommand AbrirUtensiliosCommand { get; }

    private List<SecaoCarrossel> secoesVisiveis;
    public List<SecaoCarrossel> SecoesVisiveis
    {
        get => secoesVisiveis;
        set
        {
            secoesVisiveis = value;
            OnPropertyChanged(nameof(SecoesVisiveis));
        }
    }

    private void AbrirPerfil(string nomeEstabelecimento)
    {
        // Por enquanto todos os cards abrem o Studio Black (único mock no PerfilData).
        Navigation.PushAsync(new PerfilEstabelecimento());
    }

    private void AplicarFiltro(string chipTitulo)
    {
        if (string.IsNullOrWhiteSpace(chipTitulo))
            return;

        // Segundo toque no mesmo chip remove o filtro
        if (filtroAtual == chipTitulo)
        {
            filtroAtual = null;
            SecoesVisiveis = todasSecoes;
            return;
        }

        filtroAtual = chipTitulo;

        var tags = MapaFiltros.TryGetValue(chipTitulo, out var t)
            ? t
            : new[] { chipTitulo };

        var filtrados = todasSecoes
            .SelectMany(s => s.Itens)
            .Where(e => tags.Contains(e.Tag, StringComparer.OrdinalIgnoreCase))
            .DistinctBy(e => e.Nome)
            .ToList();

        SecoesVisiveis = new List<SecaoCarrossel>
        {
            new()
            {
                Titulo = $"Resultados: {chipTitulo}",
                Subtitulo = filtrados.Count > 0
                    ? $"{filtrados.Count} estabelecimento(s) encontrado(s)"
                    : "Nenhum estabelecimento com essa característica ainda",
                Itens = filtrados
            }
        };
    }

    private void OnBuscarClicked(object sender, EventArgs e)
    {
        // TODO: navegar para tela de resultados com BuscaEntry.Text
    }
}