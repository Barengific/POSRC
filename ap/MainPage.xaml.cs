using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Data.Sqlite;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnLogin(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine("___: ");
            using (var connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = @"SELECT id, upass, job_title FROM staff";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetString(0);
                        Debug.WriteLine($"Hello, {id}!");
                        var upass = reader.GetString(1);
                        Debug.WriteLine($"Hello, {upass}!");
                        var jobtitle = reader.GetString(2);
                        Debug.WriteLine($"Hello, {jobtitle}!");

                        if (txtUName.Text == id && txtUPass.Password.ToString() == upass)
                        {
                            //Login success
                            if (jobtitle == "cashier")
                            {
                                //MainWinStaff w = new MainWinStaff();
                                //w.Show();
                            }
                            else if (jobtitle == "manager")
                            {
                                //MainWinStaff w = new MainWinStaff();
                                //w.Show();
                            }

                        }
                        else
                        {
                            //Login failed
                            Debug.WriteLine("wwww");
                        }
                    }
                }
            }

        }
    }
}
