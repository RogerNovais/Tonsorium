using System.Windows.Input;
using Tonsorium.Data;
using Tonsorium.Models;

namespace Tonsorium.Views;

public partial class CabelosPage : ContentPage
{
    public CabelosPage()
    {
        // Comandos ANTES do InitializeComponent
        AlternarTipoCommand = new Command<string>(AlternarTipo);
        AlternarCurvaturaCommand = new Command<string>(AlternarCurvatura);
        VoltarCommand = new Command(async () => await Navigation.PopAsync());

        InitializeComponent();

        // Listas criadas uma única vez; cada item notifica a própria mudança
        Tipos = CabelosData.Tipos();
        Curvaturas = CabelosData.Curvaturas();
        BindingContext = this;
    }

    public ICommand AlternarTipoCommand { get; }
    public ICommand AlternarCurvaturaCommand { get; }
    public ICommand VoltarCommand { get; }

    public List<TipoCabelo> Tipos { get; private set; } = new();
    public List<CurvaturaCabelo> Curvaturas { get; private set; } = new();

    private void AlternarTipo(string numero)
    {
        var item = Tipos.FirstOrDefault(t => t.Numero == numero);
        if (item is not null)
            item.Expandido = !item.Expandido;
    }

    private void AlternarCurvatura(string numero)
    {
        var item = Curvaturas.FirstOrDefault(c => c.Numero == numero);
        if (item is not null)
            item.Expandido = !item.Expandido;
    }
}