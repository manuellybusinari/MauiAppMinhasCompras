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
                // id: BindingContext -> tela de editar 
                Produto produto_anexado = BindingContext as Produto;
                Produto p = new Produto
                {
                    Id= produto_anexado.Id,
                    Descricao= txt_descricao.Text,
                    Quantidade= Convert.ToDouble(txt_qtd.Text),
                    Preco= Convert.ToDouble(txt_preco.Text)
                };

                await App.Db.Update(p); //corrigindo...
                await DisplayAlert("Sucesso", "Registro Atualizado", "OK!!");
                await Navigation.PopAsync();    //Voltar à tela de origem


            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK!");
            }
        }
    }
}