using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

    public ListaProduto()
    {
        InitializeComponent();

        lst_produtos.ItemsSource=lista; // Tudo será incluso na lista de produtos a partir  desse comando
    }

    protected async override void OnAppearing()
    {
        try
        {


            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }


    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Produto> tmp = await App.Db.Search(q);

            tmp.ForEach(i => lista.Add(i));

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }

    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {

        try
        {
            double soma = lista.Sum(i => i.Total);

            string msg = $"O total é {soma:C}";

            DisplayAlert("Total dos Produtos", msg, "OK!");

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }

    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // sempre que for clicado no menuitem, será mostrado qual o selecionado->
            MenuItem selecionado = sender as MenuItem;

            //resgate de item com BindingContext: 
            Produto p = selecionado.BindingContext as Produto;

            //Qual será o produto que será removido: 

            bool confirm = await DisplayAlert("Tem Certeza?", $"Remover Produto {p.Descricao}?", "Sim", "Não"); // confirmar exclusão, com o nome do produto associado (p)

                //Se a pessoa Confirmar: RETORNA-> True (segue 'if')

                //Se a pessoa Cancelar: RETORNA-> False 

                if (confirm)
            {
                await App.Db.Delete(p.Id); // Removerá do banco de dados 
                lista.Remove(p); // Remove do Observable Collection / listview - 'p' - item da lista selecionado
            }

        }
        catch (Exception ex)
        {
           await DisplayAlert("Ops", ex.Message, "OK");
        }

    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            //Qual o item selecionado?:
            Produto p = e.SelectedItem as  Produto;

            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,
            });

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}