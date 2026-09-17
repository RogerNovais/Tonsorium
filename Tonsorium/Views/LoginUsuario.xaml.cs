using System.Text.RegularExpressions;

namespace Tonsorium.Views;

public partial class LoginUsuario : ContentPage
{
    public LoginUsuario()
    {
        InitializeComponent();
    }

    // Valida o e-mail em tempo real
    private void OnEmailTextChanged(object sender, TextChangedEventArgs e)
    {
        string email = e.NewTextValue?.Trim() ?? "";
        string regexEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        if (string.IsNullOrEmpty(email))
        {
            AvisoEmail.IsVisible = false;
        }
        else
        {
            AvisoEmail.IsVisible = !Regex.IsMatch(email, regexEmail);
        }
    }

    // Valida a senha em tempo real
    private void OnSenhaTextChanged(object sender, TextChangedEventArgs e)
    {
        string senha = e.NewTextValue ?? "";
        string regexSenha = @"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$";

        if (string.IsNullOrEmpty(senha))
        {
            AvisoSenha.IsVisible = false;
        }
        else
        {
            AvisoSenha.IsVisible = !Regex.IsMatch(senha, regexSenha);
        }
    }

    // Dispara ao clicar no botão Entrar
    private async void OnBotaoAcaoClicked(object sender, EventArgs e)
    {
        // Verifica se há avisos visíveis ou se os campos estão totalmente vazios
        if (AvisoEmail.IsVisible || AvisoSenha.IsVisible ||
            string.IsNullOrEmpty(CampoEmail.Text) || string.IsNullOrEmpty(CampoSenha.Text))
        {
            await DisplayAlert("Erro", "Por favor, preencha os campos corretamente antes de continuar.", "OK");
            return;
        }


        await Navigation.PushAsync(new PaginaUsuario());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new BoasVindas());
    }
}