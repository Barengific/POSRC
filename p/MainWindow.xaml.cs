using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Diagnostics;

namespace p
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string addProductTbl = "CREATE TABLE items(	id INT NOT NULL PRIMARY KEY,	sku int,	name VARCHAR(20) NOT NULL,	description VARCHAR(50),	qty int NOT NULL,	price float NOT NULL,	category VARCHAR(20) NOT NULL);";

        string addStaffTbl = "CREATE TABLE staff(  id INTEGER PRIMARY KEY AUTOINCREMENT,  upass CHAR(64) NOT NULL,  first_name CHAR(20) NOT NULL,  last_name CHAR(20),  email CHAR(50),  phone int NOT NULL,  hired_date DateTime NOT NULL,  location CHAR(20),  job_title CHAR(20));";

        string addOrdersTbl = "CREATE TABLE orders(	id INT NOT NULL PRIMARY KEY,	datetime timestamp NOT NULL,	total_price float NOT NULL,	qty int NOT NULL,	staff_id int NOT NULL);";

        string addSalesTbl = "CREATE TABLE sales(	orders_id INT NOT NULL FOREIGN KEY,	product_id INT NOT NULL FOREIGN KEY,	qty int NOT NULL,	sub_total int NOT NULL,);";

        string addBobUser = "INSERT INTO staff(upass, first_name, last_name, email, phone, hired_date, location, job_title) VALUES ('bobpass1234','bob', 'jim', 'bobJ12@gmail.com', 075326920, date('now','start of month'), 'nyc', 'managers');";

        public MainWindow()
        {
            InitializeComponent();

            using (var connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();

                //command.CommandText = @addProductTbl;
                //command.CommandText = @addStaffTbl;
                //command.ExecuteNonQuery();
                //command.CommandText = @addOrdersTbl;
                //command.CommandText = @addSalesTbl;
                //command.CommandText = @addBobUser;
                //command.ExecuteNonQuery();
                //command.Parameters.AddWithValue("$id", 0);

                //command.CommandText = @"SELECT * FROM staff";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //var id = reader.GetString(0);
                        //Debug.WriteLine($"Hello, {id}!");
                        //var upass = reader.GetString(1);
                        //Debug.WriteLine($"Hello, {upass}!");
                        //var fname = reader.GetString(2);
                        //Debug.WriteLine($"Hello, {fname}!");
                        //var lname = reader.GetString(3);
                        //Debug.WriteLine($"Hello, {lname}!");
                        //var email = reader.GetString(4);
                        //Debug.WriteLine($"Hello, {email}!");
                        //var phone = reader.GetString(5);
                        //Debug.WriteLine($"Hello, {phone}!");
                        //var hired = reader.GetString(6);
                        //Debug.WriteLine($"Hello, {hired}!");
                        //var location = reader.GetString(7);
                        //Debug.WriteLine($"Hello, {location}!");
                        //var jobtitle = reader.GetString(8);
                        //Debug.WriteLine($"Hello, {jobtitle}!");
                    }
                    //Debug.WriteLine($"Hello11111!");
                }
                //Debug.WriteLine($"Hello222222!");
            }

        }

        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            /// Fix time format for AI Box.
            Debug.WriteLine("___: " );
            using (var connection = new SqliteConnection("Data Source=hello.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = @"SELECT id, upass FROM staff";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetString(0);
                        Debug.WriteLine($"Hello, {id}!");
                        var upass = reader.GetString(1);
                        Debug.WriteLine($"Hello, {upass}!");

                        if(txtUName.Text == id && txtUPass.Text == upass)
                        {
                            //Login success
                            Debug.WriteLine("qqqqqqq");
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
