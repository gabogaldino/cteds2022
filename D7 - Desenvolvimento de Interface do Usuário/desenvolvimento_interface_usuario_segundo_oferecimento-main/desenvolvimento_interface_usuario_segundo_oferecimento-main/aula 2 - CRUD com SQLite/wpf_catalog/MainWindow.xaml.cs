using System.Linq;
using System.Windows;
using wpf_catalog.Data;

namespace wpf_catalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;
        Product newProduct = new();

        public MainWindow(Context context)
        {
            this.context = context;
            InitializeComponent();
            GetProducts();
            NewProductGrid.DataContext = newProduct;
        }

        private void GetProducts()
        {
            ProductDataGrid.ItemsSource = context.Products.ToList();
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            context.Products.Add(newProduct);
            context.SaveChanges();

            GetProducts();

            newProduct = new Product();
            NewProductGrid.DataContext = newProduct;
        }
    }
}
