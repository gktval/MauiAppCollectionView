namespace MauiAppCollectionView;

public partial class MainPage : ContentPage
{
	public List<string> DataSource { get; set; }
	public MainPage()
	{
		InitializeComponent();

        DataSource = new List<string>
        {
            "ABC",
            "DEF",
            "GHI",
            "JKL"
        };

        BindingContext = this;

        gridView.Reload();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        gridView.Reload();
    }
}

