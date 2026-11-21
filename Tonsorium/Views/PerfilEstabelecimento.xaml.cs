using Tonsorium.Data;

namespace Tonsorium.Views;

public partial class PerfilEstabelecimento : ContentPage
{
    public PerfilEstabelecimento()
    {
        InitializeComponent();
        BindingContext = PerfilData.StudioBlack;
    }

    private void OnVoltarClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void OnAgendarClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgendamentoPage());
    }
}