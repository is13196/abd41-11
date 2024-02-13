using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace abd41_11;

public partial class водители1 : Window
{
    public водители1()
    {
        InitializeComponent();
        string fullTable =
            "SELECT id, имя, возраст, id_транспорта FROM Водители;";
        ShowTable(fullTable);
        string sql = "SELECT id, имя, возраст, id_транспорта FROM Водители;";

        ShowTable(sql);
        FillВодителиList();
    }
    private string _connString = "server=localhost;database=abd21;port=3306;User Id=root;password=09January2004";
    private List<Водители> _водителиs;
    private MySqlConnection _connection;

    public void ShowTable(string searchSql)
    {
        string sql = "SELECT id, имя, возраст, id_транспорта FROM Водители;";

        _водителиs = new List<Водители>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentВодители = new Водители()
            {
                id = reader.GetInt32("id"),
                имя = reader.GetString("имя"),
                возраст = reader.GetInt32("возраст"),
                id_транспорта = reader.GetInt32("id_транспорта")
                
            };
            _водителиs.Add(currentВодители);
        }

        _connection.Close();
        ВодителиGrid.ItemsSource = _водителиs;
    }
    public void FillВодителиList()
    {
        _водителиs = new List<Водители>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command =
            new MySqlCommand("SELECT id, имя, возраст, id_транспорта FROM Водители;",
                _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentВодители = new Водители()
            {
                id = reader.GetInt32("id"),
                имя = reader.GetString("имя"),
                возраст = reader.GetInt32("возраст"),
                id_транспорта = reader.GetInt32("id_транспорта")
                
            };
            _водителиs.Add(currentВодители); 
        }

        _connection.Close();
        var ВодителиComboBox = this.Find<ComboBox>("CmbВодители");
        ВодителиComboBox.ItemsSource = _водителиs;
    }


  

    private void AddButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            //This is my connection string i have assigned the database file address path
            string MyConnection2 ="server=localhost;database=abd21;port=3306;User Id=root;password=09January2004"; 
            //This is my insert query in which i am taking input from the user through windows forms
            string Query = "insert into Водители(id,имя,возраст,id_транспорта) values('" + this.txtid.Text +
                           "','" + this.txtимя.Text + "','" + this.txtвозраст.Text + "','" + this.txtid_транспорта.Text +"');";
            //This is  MySqlConnection here i have created the object and pass my connection string.
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            //This is command class which will handle the query and connection object.
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
            MessageBox.Show("Save Data");
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }  
    }

    private void EditButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            //This is my connection string i have assigned the database file address path
            string MyConnection2 ="server=localhost;database=abd21;port=3306;User Id=root;password=09January2004"; 
            //This is my update query in which i am taking input from the user through windows forms and update the record.
            string Query ="update Водители set id='" + this.txtEditid.Text + "',имя='" + this.txtEditимя.Text + "',возраст='" + this.txtEditвозраст.Text + "',id_транспорта='" + this.txtEditid_транспорта.Text +  "' where id='" + this.txtEditid.Text + "';";
            
             
            //This is  MySqlConnection here i have created the object and pass my connection string.
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data Updated");
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();//Connection closed here
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DeleteButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            string MyConnection2 ="server=localhost;database=abd21;port=3306;User Id=root;password=09January2004"; 
            string Query = "delete from Водители where id='" + this.txtDeleteid.Text + "';";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data Deleted");
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }  
    }

    private void SaveData_OnClick(object? sender, RoutedEventArgs e)
    {
        RegistrationForm1 registrationForm1 = new RegistrationForm1();
        registrationForm1.Show();
    }

    private void Cmbводители1_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var ВодителиComboBox = (ComboBox)sender;
        var currentВодители = ВодителиComboBox.SelectedItem as Водители;
        var filteredВодители = _водителиs
            .Where(x => x.возраст == currentВодители.возраст)
            .ToList();
        ВодителиGrid.ItemsSource = filteredВодители;
    }

    private void TxtSearch_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var searchВодители = _водителиs;
        //поиск - where, contains
        searchВодители = searchВодители
            .Where(p => p.имя.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
        //сортировка - orderby по столбцу имя
        ВодителиGrid.ItemsSource = searchВодители.OrderBy(p => p.имя);
    }
}

internal class Exception : System.Exception
{
}