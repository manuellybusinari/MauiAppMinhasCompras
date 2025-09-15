namespace MauiAppMinhasCompras.Views;

public partial class RelatorioPage : ContentPage
{
    public RelatorioPage()
    {
        InitializeComponent();
    }

    // Evento chamado quando o botão "Filtrar" é clicado
    private async void Filtrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Captura as datas selecionadas pelo usuário
            DateTime dataInicial = dpInicio.Date;
            DateTime dataFinal = dpFim.Date;

            // Busca todos os produtos do banco
            var todosProdutos = await App.Db.GetAll();

            // Filtra os produtos dentro do intervalo de datas
            var produtosFiltrados = todosProdutos
                .Where(p => p.DataCadastro >= dataInicial && p.DataCadastro <= dataFinal)
                .OrderBy(p => p.DataCadastro)
                .ToList();

            // Exibe os produtos filtrados na ListView
            lvRelatorio.ItemsSource = produtosFiltrados;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}

