namespace MauiAppCollectionView;

internal sealed class DataGridRow : Grid
{
    #region properties

    public CollectionView DataGrid
    {
        get => (CollectionView)GetValue(DataGridProperty);
        set => SetValue(DataGridProperty, value);
    }

    public int Index { get; set; }

    #endregion properties

    #region Bindable Properties

    public static readonly BindableProperty DataGridProperty =
        BindableProperty.Create(nameof(DataGrid), typeof(CollectionView), typeof(DataGridRow), null, BindingMode.OneTime);

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


