using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class RelatorioPage : ContentPage
{
    public RelatorioPage()
    {
        InitializeComponent();
    }

    private async void OnFiltrarClicked(object sender, EventArgs e)
    {
        var todosProdutos = await App.Db.GetAll();

        var filtrados = todosProdutos
            .Where(p => p.DataCadastro >= dpInicio.Date && p.DataCadastro <= dpFim.Date)
            .ToList();

        lvRelatorio.ItemsSource = filtrados;
    }
}
