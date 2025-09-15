using MauiAppMinhasCompras.Models;
using System.Threading.Tasks;

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
			// Preecher a Model -> produto
			Produto p = new Produto // declaração da variável 'p' do tipo produto
			{
				Descricao= txt_descricao.Text,
				Quantidade= Convert.ToDouble(txt_qtd.Text),
				Preco= Convert.ToDouble(txt_preco.Text),
                DataCadastro= dp_dataCadastro.Date	// Captura a data
            };  // MODEL preenchida

			// 'space' no teclado lista todas as propriedades para fazer o preenchimento do objeto 

			await App.Db.Insert(p);
			//Avisar o usuário que deu tudo certo com DisplayAlert
			await DisplayAlert("Sucesso", "Registro inserido", "OK!!");
			await Navigation.PopAsync();

		}catch(Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK!"); 
		}
	

    }
}