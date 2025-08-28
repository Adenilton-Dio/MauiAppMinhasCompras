using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views1;


public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new();
	public ObservableCollection<Produto> Lista;
#pragma warning disable CS8618 // O campo n�o anul�vel precisa conter um valor n�o nulo ao sair do construtor. Considere adicionar o modificador "obrigat�rio" ou declarar como anul�vel.
    public ListaProduto()
#pragma warning restore CS8618 // O campo n�o anul�vel precisa conter um valor n�o nulo ao sair do construtor. Considere adicionar o modificador "obrigat�rio" ou declarar como anul�vel.
    {
		InitializeComponent();

		lst_produtos.ItemsSource = lista;	
    }
	protected  async override void OnAppearing()
	{
	List<Produto> tmp = await App.Db.GetAll();

    tmp.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views1.NovoProduto());
			
		} catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		string q = e.NewTextValue;

		lista.Clear();

        List<Produto> tmp = await App.Db.Search(q);

        tmp.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		double soma = (double)lista.Sum(i => i.Total);

		string msg = $"O total � {soma:C2}";

		DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private void MenuItem_Clicked_1(object sender, EventArgs e)
    {

    }
}