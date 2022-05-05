using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashboardStaff : Page
    {

        public DashboardStaff()
        {
            this.InitializeComponent();

            //List<Products> products = new List<Products>();
            //products.Add(new Products { Image = "Assets/sponge.jpg", Title = "Sponge", Subtitle = "sponges", Description = "a soft, light, porous absorbent substance" });
            //products.Add(new Products { Image = "Assets/glass.jpg", Title = "Glass", Subtitle = "list of glass", Description = "a non-crystalline, often transparent amorphous solid" });

            //LvItems.ItemsSource = products;

            List<Product> products = new List<Product>();

            // Add some items to collection
            products.Add(
                new Product(
                            "Glass",
                            "$50.00",
                            "2",
                            "$100.00",
                            "Assets/glass.png"
                    )
                );

            // Specify the list view item source
            ListView1.ItemsSource = products;

        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the instance of ListView
            ListView listView = sender as ListView;

            // Get the ListView selected item as a Book
            Product selectedBook = listView.SelectedItem as Product;

            // Initialize a new message dialog
            MessageDialog dialog = new MessageDialog(
                "Selected : \n"
                + selectedBook.ItemName + "\n"
                + selectedBook.ItemPrice + "\n"
                + selectedBook.ItemQty + "\n"
                + selectedBook.ItemTotal);

            // Finally, display the selected item details on dialog
            dialog.ShowAsync();
        }
    }

    public class Product
    {
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string ItemQty { get; set; }
        public string ItemTotal { get; set; }
        public string ItemImage { get; set; }

        public Product(string Name, string Price, string Qty, string Total, string Image)
        {
            this.ItemName = Name;
            this.ItemPrice = Price;
            this.ItemQty = Qty;
            this.ItemTotal = Total;
            this.ItemImage = Image;
        }
    }

}
