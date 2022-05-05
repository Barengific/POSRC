﻿using System;
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

            List<Product> products = new List<Product>();

            products.Add(
                new Product(
                            "Glass",
                            "$50.00",
                            "2",
                            "$100.00",
                            "Assets/glass.png"
                    )
                );

            ListView1.ItemsSource = products;

        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;

            Product selectedBook = listView.SelectedItem as Product;

            MessageDialog dialog = new MessageDialog(
                "Selected : \n"
                + selectedBook.ItemName + "\n"
                + selectedBook.ItemPrice + "\n"
                + selectedBook.ItemQty + "\n"
                + selectedBook.ItemTotal);

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
