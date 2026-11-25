using Microsoft.Maui.Graphics;
using Tonsorium.Controls;
using Tonsorium.Data;
using Tonsorium.Models;

namespace Tonsorium.Views;

public partial class PaginaEmpresa : ContentPage
{
    public PaginaEmpresa()
    {
        // Definido antes do InitializeComponent
        GraficoClientes = new GraficoLinhaDrawable(DesempenhoData.Meses, DesempenhoData.ClientesPorMes);

        InitializeComponent();
        BindingContext = this;
    }

    public IDrawable GraficoClientes { get; }

    public string Saudacao => "Olá, Gustavo.";
    public string DataAtual => "19 SET 2026";
    public string NomeEstabelecimento => "Black House";
    public string AreaEstabelecimento => "Barbearia & Estética";

    public string TotalAgendamentos => "128";
    public string TotalClientes => "84";
    public string NotaMedia => "4.9 ★";

    public List<AgendamentoHoje> AgendamentosHoje => EmpresaData.AgendamentosHoje;
    public AvaliacaoCliente UltimaAvaliacao => EmpresaData.UltimaAvaliacao;

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new BoasVindas());
    }
}