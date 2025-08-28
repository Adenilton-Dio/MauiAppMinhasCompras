namespace MauiAppMinhasCompras;

public partial class MainPage : ContentPage
{
    private List<Produto> Produtos;

    public MainPage()
    {
        InitializeComponent();

        Produtos = new List<Produto>
        {
            new Produto { Id = 1, Descricao = "Arroz", Preco = 22.50m, Quantidade = 2 },
            new Produto { Id = 2, Descricao = "Feijão", Preco = 8.90m, Quantidade = 5 },
            new Produto { Id = 3, Descricao = "Macarrão", Preco = 4.20m, Quantidade = 3 },
        };

        ProdutosView.ItemsSource = Produtos;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = e.NewTextValue?.ToLower() ?? "";

        var produtosFiltrados = Produtos
            .Where(p => p.Descricao.ToLower().Contains(filtro))
            .ToList();

        ProdutosView.ItemsSource = produtosFiltrados;
    }
}

public class Produto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public decimal Total => Preco * Quantidade;
}
