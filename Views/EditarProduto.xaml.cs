using MauiAppMinhasCompras.Models;
using System.Globalization;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
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

            Produto produto_anexado = BindingContext as Produto;

            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text.Trim(),
                Quantidade = Convert.ToDouble(txt_qtd.Text, CultureInfo.InvariantCulture),
                Preco = Convert.ToDouble(txt_preco.Text, CultureInfo.InvariantCulture),
                DataCadastro = dp_dataCadastro.Date
            };

            await App.Db.Update(p);
            await DisplayAlert("Sucesso", "Registro atualizado com sucesso!", "OK!");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível atualizar o produto: {ex.Message}", "OK!");
        }
    }
}