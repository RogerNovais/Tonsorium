using System.Windows.Input;
using Tonsorium.Data;
using Tonsorium.Models;

namespace Tonsorium.Views;

public partial class UtensiliosPage : ContentPage
{
    public UtensiliosPage()
    {
        // Comandos ANTES do InitializeComponent
        AlternarCommand = new Command<string>(Alternar);
        VoltarCommand = new Command(async () => await Navigation.PopAsync());

        InitializeComponent();

        // Lista criada uma única vez. Os cards mudam sozinhos via INotifyPropertyChanged.
        Itens = UtensiliosData.Criar();
        BindingContext = this;
    }

    public ICommand AlternarCommand { get; }
    public ICommand VoltarCommand { get; }

    public IReadOnlyList<DicaUtensilio> Dicas => UtensiliosData.Dicas;

    public List<Utensilio> Itens { get; private set; } = new();

    // Inverte somente o cartão tocado; a lista não é recriada
    private void Alternar(string numero)
    {
        var item = Itens.FirstOrDefault(u => u.Numero == numero);
        if (item is not null)
            item.Expandido = !item.Expandido;
    }
}