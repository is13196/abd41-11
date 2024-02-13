using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace abd41_11;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        string fullTable =
            "SELECT id, название, тип, вместимость FROM Транспортные_средства;";
        ShowTable(fullTable);
        string sql = "SELECT id, название, тип, вместимость FROM Транспортные_средства;";

        ShowTable(sql);
        FillТранспортные_средстваList();
    }


    private string _connString = "server=localhost;database=abd21;port=3306;User Id=root;password=09January2004";
    private List<Транспортные_средства> _Транспортные_средстваs;
    private MySqlConnection _connection;

    public void ShowTable(string searchSql)
    {
        string sql = "SELECT id, название, тип, вместимость FROM Транспортные_средства;";

        _Транспортные_средстваs = new List<Транспортные_средства>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentТранспортные_средства = new Транспортные_средства()
            {
                id = reader.GetInt32("id"),
                название = reader.GetString("название"),
                тип = reader.GetString("тип"),
                вместимость = reader.GetInt32("вместимость")
              
            };
            _Транспортные_средстваs.Add(currentТранспортные_средства);
        }

        _connection.Close();
        Транспортные_средстваGrid.ItemsSource = _Транспортные_средстваs;
    }

    public void FillТранспортные_средстваList()
    {
        _Транспортные_средстваs = new List<Транспортные_средства>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command =
            new MySqlCommand("SELECT id, название, тип, вместимость FROM Транспортные_средства;",
                _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentТранспортные_средства = new Транспортные_средства()
            {
                id = reader.GetInt32("id"),
                название = reader.GetString("название"),
                тип = reader.GetString("тип"),
                вместимость = reader.GetInt32("вместимость"),

            };
            _Транспортные_средстваs.Add(currentТранспортные_средства);
        }

        _connection.Close();
        var Транспортные_средстваComboBox = this.Find<ComboBox>("CmbТранспортные_средства");
        Транспортные_средстваComboBox.ItemsSource = _Транспортные_средстваs;
    }



    private void TxtSearch_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var searchТранспортные_средства = _Транспортные_средстваs;
        //поиск - where, contains
        searchТранспортные_средства = searchТранспортные_средства
            .Where(p => p.название.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
        //сортировка - orderby по столбцу название
        Транспортные_средстваGrid.ItemsSource = searchТранспортные_средства.OrderBy(p => p.название);
    }



    private void AddButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            //This is my connection string i have assigned the database file address path
            string MyConnection2 ="server=localhost;database=abd21;port=3306;User Id=root;password=09January2004"; 
            //This is my insert query in which i am taking input from the user through windows forms
            string Query = "insert into Транспортные_средства(id,название,тип,вместимость) values('" + this.txtid.Text +
                           "','" + this.txtназвание.Text + "','" + this.txtтип.Text + "','" + this.txtвместимость.Text +"');";
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
            string Query ="update Транспортные_средства set id='" + this.txtEditid.Text + "',название='" + this.txtEditназвание.Text + "',тип='" + this.txtEditтип.Text + "',вместимость='" + this.txtEditвместимость.Text +  "' where id='" + this.txtEditid.Text + "';";
            
             
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
            string Query = "delete from Транспортные_средства where id='" + this.txtDeleteid.Text + "';";
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
        маршруты1 маршруты1 = new маршруты1();
        маршруты1.Show();
        
    }

    private void CmbТранспортные_средства_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var Транспортные_средстваComboBox = (ComboBox)sender;
        var currentТранспортные_средства = Транспортные_средстваComboBox.SelectedItem as Транспортные_средства;
        var filteredТранспортные_средства = _Транспортные_средстваs
            .Where(x => x.тип == currentТранспортные_средства.тип)
            .ToList();
        Транспортные_средстваGrid.ItemsSource = filteredТранспортные_средства;
        
    }
}

internal class MessageBox
{
    public static void Show(string saveData)
    {
        throw new NotImplementedException();
    }
}


















