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
        AbrirCabelosCommand = new Command(async () => await Navigation.PushAsync(new CabelosPage()));

        InitializeComponent();
        BindingContext = this;

        todasSecoes = HomeData.Secoes.ToList();
        SecoesVisiveis = todasSecoes;
    }

    public ICommand FiltrarCommand { get; }
    public ICommand AbrirPerfilCommand { get; }
    public ICommand AbrirUtensiliosCommand { get; }
    public ICommand AbrirCabelosCommand { get; }

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

    private async void AbrirPerfil(string nomeEstabelecimento)
    {
        if (!EstabelecimentosData.Existe(nomeEstabelecimento))
        {
            await DisplayAlert("Perfil indisponível",
                $"Não encontramos o perfil de \"{nomeEstabelecimento}\".", "OK");
            return;
        }

        await Navigation.PushAsync(new PerfilEstabelecimento(nomeEstabelecimento));
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
        BuscaEntry.Unfocus();
        var termo = BuscaEntry.Text?.Trim() ?? "";

        // Campo vazio: volta para a home completa
        if (string.IsNullOrWhiteSpace(termo))
        {
            filtroAtual = null;
            SecoesVisiveis = todasSecoes;
            return;
        }

        filtroAtual = null;

        // Busca pelo nome e, também, pela tag (ex.: "Manicure", "Cacheados")
        var encontrados = todasSecoes
            .SelectMany(s => s.Itens)
            .Where(x => x.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase)
                     || (x.Tag ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase))
            .DistinctBy(x => x.Nome)
            .ToList();

        SecoesVisiveis = new List<SecaoCarrossel>
        {
            new()
            {
                Titulo = $"Resultados: {termo}",
                Subtitulo = encontrados.Count > 0
                    ? $"{encontrados.Count} estabelecimento(s) encontrado(s)"
                    : $"Não encontramos nenhum estabelecimento para \"{termo}\".",
                Itens = encontrados
            }
        };
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new BoasVindas());
    }
}