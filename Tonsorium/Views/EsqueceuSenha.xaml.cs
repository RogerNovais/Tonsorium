using System.Text.RegularExpressions;

namespace Tonsorium.Views;

public partial class EsqueceuSenha : ContentPage
{
    public EsqueceuSenha()
    {
        InitializeComponent();
    }

    private void OnEmailTextChanged(object sender, TextChangedEventArgs e)
    {
        AvisoEmail.IsVisible = !string.IsNullOrEmpty(e.NewTextValue)
                               && !IsEmailValido(e.NewTextValue);
    }

    private bool IsEmailValido(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        string email = CampoEmail.Text?.Trim();

        if (string.IsNullOrEmpty(email) || !IsEmailValido(email))
        {
            AvisoEmail.IsVisible = true;
            return;
        }

        // TODO: integrar com o backend de recuperação de senha
        MensagemSucesso.IsVisible = true;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new BoasVindas());
    }
}