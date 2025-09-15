using MauiAppMinhasCompras.Models;
using System.Globalization;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_descricao.Text) ||
                string.IsNullOrWhiteSpace(txt_qtd.Text) ||
                string.IsNullOrWhiteSpace(txt_preco.Text))
            {
                await DisplayAlert("Atenção", "Por favor, preencha todos os campos.", "OK!");
                return;
            }

            Produto p = new Produto
            {
                Descricao = txt_descricao.Text.Trim(),
                Quantidade = Convert.ToDouble(txt_qtd.Text, CultureInfo.InvariantCulture),
                Preco = Convert.ToDouble(txt_preco.Text, CultureInfo.InvariantCulture),
                DataCadastro = dp_dataCadastro.Date
            };

            await App.Db.Insert(p);
            await DisplayAlert("Sucesso", "Registro inserido com sucesso!", "OK!");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível salvar o produto: {ex.Message}", "OK!");
        }
    }
}