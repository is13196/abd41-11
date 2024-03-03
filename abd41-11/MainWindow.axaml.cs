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
        string fullTable = "SELECT id, ФИО, Дата_рождения, Адрес, Телефон FROM студенты;";
            
        ShowTable(fullTable);
        string sql = "SELECT id, ФИО, Дата_рождения, Адрес, Телефон FROM студенты;";

        ShowTable(sql);
        FillстудентыList();
    }


    private string _connString = "server=localhost;database=pp1;port=3306;User Id=root;password=09January2004";
    private List<студенты> _студентыs;
    private MySqlConnection _connection;

    public void ShowTable(string searchSql)
    {
        string sql = "SELECT id, ФИО, Дата_рождения, Адрес, Телефон FROM студенты;";

        _студентыs = new List<студенты>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentстуденты = new студенты()
            {
                id = reader.GetInt32("id"),
                ФИО = reader.GetString("ФИО"),
                Дата_рождения = reader.GetString("Дата_рождения"),
                Адрес = reader.GetString("Адрес"),
                Телефон = reader.GetString("Телефон")
              
            };
            _студентыs.Add(currentстуденты);
        }

        _connection.Close();
        студентыGrid.ItemsSource = _студентыs;
    }

    public void FillстудентыList()
    {
        _студентыs = new List<студенты>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command =
            new MySqlCommand("SELECT id, ФИО, Дата_рождения, Адрес, Телефон FROM студенты;",
                _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentстуденты = new студенты()
            {
                id = reader.GetInt32("id"),
                ФИО = reader.GetString("ФИО"),
                Дата_рождения = reader.GetString("Дата_рождения"),
                Адрес = reader.GetString("Адрес"),
                Телефон = reader.GetString("Телефон") 

            };
            _студентыs.Add(currentстуденты);
        }

        _connection.Close();
        var студентыComboBox = this.Find<ComboBox>("Cmbстуденты");
        студентыComboBox.ItemsSource = _студентыs;
    }



    private void TxtSearch_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var searchстуденты = _студентыs;
        //поиск - where, contains
        searchстуденты = searchстуденты
            .Where(p => p.ФИО.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
        //сортировка - orderby по столбцу ФИО
        студентыGrid.ItemsSource = searchстуденты.OrderBy(p => p.ФИО);
    }



    private void AddButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            //This is my connection string i have assigned the database file address path
            string MyConnection2 ="server=localhost;database=pp1;port=3306;User Id=root;password=09January2004"; 
            //This is my insert query in which i am taking input from the user through windows forms
            string Query = "insert into  студенты( id, ФИО, Дата_рождения, Адрес, Телефон) values('" + this.txtid.Text +
                           "','" + this.txtФИО.Text + "','" + this.txtДата_рождения.Text + "','" + this.txtАдрес.Text + this.txtТелефон.Text + "');";
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
            string MyConnection2 ="server=localhost;database=pp1;port=3306;User Id=root;password=09January2004"; 
            //This is my update query in which i am taking input from the user through windows forms and update the record.
            string Query ="update студенты set id='" + this.txtEditid.Text + "',ФИО='" + this.txtEditФИО.Text + "',Дата_рождения='" + this.txtEditДата_рождения.Text + "',Адрес='" + this.txtEditАдрес.Text +  "',Телефон='" + this.txtEditТелефон.Text +  "' where id='" + this.txtEditid.Text + "';";
            
             
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
            string MyConnection2 ="server=localhost;database=pp1;port=3306;User Id=root;password=09January2004"; 
            string Query = "delete from  студенты where id='" + this.txtDeleteid.Text + "';";
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

 

    private void Cmbстуденты_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var студентыComboBox = (ComboBox)sender;
        var currentстуденты = студентыComboBox.SelectedItem as студенты;
        var filteredстуденты = _студентыs
            .Where(x => x.Дата_рождения == currentстуденты.Дата_рождения)
            .ToList();
        студентыGrid.ItemsSource = filteredстуденты;
    }
}

internal class MessageBox
{
    public static void Show(string saveData)
    {
        
    }
}


















