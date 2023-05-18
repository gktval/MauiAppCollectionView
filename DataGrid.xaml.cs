using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MauiAppCollectionView;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class DataGrid : INotifyPropertyChanged
{
    public event EventHandler OnReload;


    public DataGrid()
    {
        InitializeComponent();

        BindingContext = this;
    }

    internal void Reload()
    {
        if (_internalItems is not null)
        {
            InternalItems = new List<object>(_internalItems);
        }
        OnReload?.Invoke(this, EventArgs.Empty);
    }


    private IList<object> _internalItems;

    internal IList<object> InternalItems
    {
        get => _internalItems;
        set
        {
            _internalItems = value;

            _collectionView.ItemsSource = _internalItems;
        }
    }

    /// <summary>
    /// ItemsSource of the DataGrid
    /// </summary>
    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty =
           BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(DataGrid), null,
               propertyChanged: (b, o, n) =>
               {
                   var self = (DataGrid)b;
                   //ObservableCollection Tracking
                   if (o is INotifyCollectionChanged collectionChanged)
                   {
                       collectionChanged.CollectionChanged -= self.HandleItemsSourceCollectionChanged;
                   }

                   if (n == null)
                   {
                       self.InternalItems = null;
                   }
                   else
                   {
                       if (n is INotifyCollectionChanged changed)
                       {
                           changed.CollectionChanged += self.HandleItemsSourceCollectionChanged;
                       }

                       self.InternalItems = new List<object>(((IEnumerable)n).Cast<object>());
                   }

               });


    private void HandleItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (sender is IEnumerable items)
        {
            InternalItems = new List<object>(items.Cast<object>());
        }
    }

    private void _collectionView_Loaded(object sender, EventArgs e)
    {

    }
}