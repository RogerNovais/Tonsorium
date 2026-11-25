namespace Tonsorium.Views;

public partial class BoasVindas : ContentPage
{
	public BoasVindas()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginEmpresa());
    }

    private void Button_Clicked2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginUsuario());
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new PaginaCadastro());
    }
}