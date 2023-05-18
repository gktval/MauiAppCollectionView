namespace MauiAppCollectionView;

internal sealed class DataGridRow : Grid
{
    #region properties

    public CollectionView DataGrid
    {
        get => (CollectionView)GetValue(DataGridProperty);
        set => SetValue(DataGridProperty, value);
    }

    public object ItemSource
    {
        get => (object)GetValue(ItemSourceProperty);
        set => SetValue(ItemSourceProperty, value);
    }

    public int Index { get; set; }

    #endregion properties

    #region Bindable Properties
    public static readonly BindableProperty ItemSourceProperty =
        BindableProperty.Create(nameof(ItemSource), typeof(object),
            typeof(DataGridRow),
            null,
            BindingMode.OneTime, propertyChanged: ItemSourceSet);

    private static void ItemSourceSet(BindableObject bindable, object oldValue, object newValue)
    {
        var content = (DataGridRow)bindable;
        if(newValue!=null)
        {
            content.CreateView();
        }
    }

    public static readonly BindableProperty DataGridProperty =
        BindableProperty.Create(nameof(DataGrid), typeof(CollectionView), 
            typeof(DataGridRow), 
            null,
            BindingMode.OneTime, propertyChanged: OnGridChanged);

    private static void OnGridChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var content = (DataGridRow)bindable;
        //if (content != null)
        //{
        //    var grid = (DataGrid)newValue;
        //    grid.OnReload += content.Reload;
        //}
    }

    //private void Reload(object sender, EventArgs e)
    //{
    //    CreateView();
    //}

    #endregion Bindable Properties

    #region Methods

    private int _index = 0;

    private void CreateView()
    {
        Children.Clear();

        BackgroundColor = Colors.White;

        Index = _index;

        var cell = new Label
        {
            TextColor = Colors.Black,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill,
            Text = Index.ToString(),
        };

        SetColumn((BindableObject)cell, 0);
        Children.Add(cell);
        _index++;
    }


    /// <inheritdoc/>
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        CreateView();
    }

    protected override void OnParentChanged()
    {
        base.OnParentChanged();
    }    

    #endregion Methods
}


