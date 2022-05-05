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
using Windows.Storage;
using System.Collections.Generic;
using System.Reflection;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string addProductTbl = "CREATE TABLE items(	id INT NOT NULL PRIMARY KEY,	sku int,	name VARCHAR(20) NOT NULL,	description VARCHAR(50),	qty int NOT NULL,	price float NOT NULL,	category VARCHAR(20) NOT NULL);";

        string addStaffTbl = "CREATE TABLE staff(  id INTEGER PRIMARY KEY AUTOINCREMENT,  upass CHAR(64) NOT NULL,  first_name CHAR(20) NOT NULL,  last_name CHAR(20),  email CHAR(50),  phone int NOT NULL,  hired_date DateTime NOT NULL,  location CHAR(20),  job_title CHAR(20));";

        string addOrdersTbl = "CREATE TABLE orders(	id INT NOT NULL PRIMARY KEY,	datetime timestamp NOT NULL,	total_price float NOT NULL,	qty int NOT NULL,	staff_id int NOT NULL);";

        string addSalesTbl = "CREATE TABLE sales(	orders_id INT NOT NULL FOREIGN KEY,	product_id INT NOT NULL FOREIGN KEY,	qty int NOT NULL,	sub_total int NOT NULL,);";

        string addBobUser = "INSERT INTO staff(upass, first_name, last_name, email, phone, hired_date, location, job_title) VALUES ('bobpass1234','bob', 'jim', 'bobJ12@gmail.com', 075326920, date('now','start of month'), 'nyc', 'managers');";


        public MainPage()
        {
            this.InitializeComponent();
            AddData();
        }

        private void BtnLogin(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(DashboardStaff));

            Debug.WriteLine("___: ");
            //using (var connection = new SqliteConnection("Data Source=hello.db"))
            //{
            //    connection.Open();

            //    var command = connection.CreateCommand();

            //    command.CommandText = @"SELECT id, upass, job_title FROM staff";

            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var id = reader.GetString(0);
            //            Debug.WriteLine($"Hello, {id}!");
            //            var upass = reader.GetString(1);
            //            Debug.WriteLine($"Hello, {upass}!");
            //            var jobtitle = reader.GetString(2);
            //            Debug.WriteLine($"Hello, {jobtitle}!");

            //            if (txtUName.Text == id && txtUPass.Password.ToString() == upass)
            //            {
            //                //Login success
            //                if (jobtitle == "cashier")
            //                {
            //                    //MainWinStaff w = new MainWinStaff();
            //                    //w.Show();
            //                }
            //                else if (jobtitle == "manager")
            //                {
            //                    //MainWinStaff w = new MainWinStaff();
            //                    //w.Show();
            //                }

            //            }
            //            else
            //            {
            //                //Login failed
            //                Debug.WriteLine("wwww");
            //            }
            //        }
            //    }
            //}

        }

        public async static void InitializeDatabase()
        {
            _ = await ApplicationData.Current.LocalFolder.CreateFileAsync("sqliteSample.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");

            using (SqliteConnection db =
               new SqliteConnection($"Data Source={dbpath}"))
            {
                db.Open();

                String tableCommand = @"CREATE TABLE  IF NOT EXISTS staff(  id INTEGER PRIMARY KEY AUTOINCREMENT,  upass CHAR(64) NOT NULL,  first_name CHAR(20) NOT NULL,  last_name CHAR(20),  email CHAR(50),  phone int NOT NULL,  hired_date DateTime NOT NULL,  location CHAR(20),  job_title CHAR(20));";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData()
        {
            string addBobUser = "INSERT INTO staff(upass, first_name, last_name, email, phone, hired_date, location, job_title) VALUES ('bobpass1234','bob', 'jim', 'bobJ12@gmail.com', 075326920, date('now','start of month'), 'nyc', 'managers');";
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = @addBobUser;

                insertCommand.ExecuteReader();

                db.Close();
            }

        }
    }
}
