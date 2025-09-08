using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        // Preencher o Model com os dados atualizados

        {
            try
            {

                Produto p = new Produto 
                {
                    Descricao= txt_descricao.Text,
                    Quantidade= Convert.ToDouble(txt_qtd.Text),
                    Preco= Convert.ToDouble(txt_preco.Text)
                };  


                await App.Db.Insert(p);
                await DisplayAlert("Sucesso", "Registro inserido", "OK!!");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK!");
            }
        }
    }
}