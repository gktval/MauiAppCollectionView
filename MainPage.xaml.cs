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
        grid1.ItemsSource = DataSource;

        BindingContext = this;

        OnPropertyChanged(nameof(DataSource));
    }
}

