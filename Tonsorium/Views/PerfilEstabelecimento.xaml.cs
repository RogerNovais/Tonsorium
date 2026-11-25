using System.Windows.Input;
using Tonsorium.Data;

namespace Tonsorium.Views;

public partial class PerfilEstabelecimento : ContentPage
{
    public PerfilEstabelecimento(string nome)
    {
        // Comandos ANTES do InitializeComponent
        VoltarCommand = new Command(async () => await Navigation.PopAsync());
        AgendarCommand = new Command(async () => await Navigation.PushAsync(new AgendamentoPage(Perfil.Nome)));

        // Busca o perfil do próprio estabelecimento
        Perfil = EstabelecimentosData.Obter(nome);

        InitializeComponent();
        BindingContext = this;
    }

    // Tipo totalmente qualificado: dentro de Tonsorium.Views, o nome simples aponta para esta página
    public Tonsorium.Models.PerfilEstabelecimento Perfil { get; }

    public ICommand VoltarCommand { get; }
    public ICommand AgendarCommand { get; }

    public string LocalizacaoCompleta => $"{Perfil.LocalizacaoEndereco} · {Perfil.LocalizacaoCidade}";
    public string FuncionamentoCompleto => $"{Perfil.FuncionamentoDias} · {Perfil.FuncionamentoHoras}";
    public string EspecialidadesTexto => string.Join(" · ", Perfil.Especialidades);
}