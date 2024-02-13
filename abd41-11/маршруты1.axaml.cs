using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace abd41_11;

public partial class маршруты1 : Window
{
    public маршруты1()
    {
        InitializeComponent();
        string fullTable =
            "SELECT id, название, расстояние FROM Маршруты;";
        ShowTable(fullTable);
        string sql = "SELECT id, название, расстояние FROM Маршруты;";

        ShowTable(sql);
        //FillМаршрутыList();
    }
    private string _connString = "server=localhost;database=abd21;port=3306;User Id=root;password=09January2004";
    private List<Маршруты> _Маршрутыs;
    private MySqlConnection _connection;

    public void ShowTable(string searchSql)
    {
        string sql = "SELECT id, название, расстояние FROM Маршруты;";

        _Маршрутыs = new List<Маршруты>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentМаршруты = new Маршруты()
            {
                id = reader.GetInt32("id"),
                название = reader.GetString("название"),
                расстояние = reader.GetFloat("расстояние")
            };
            _Маршрутыs.Add(currentМаршруты);
        }

        _connection.Close();
        МаршрутыGrid.ItemsSource = _Маршрутыs;
    }

    private void NextButton_Click(object? sender, RoutedEventArgs e)
    {
        графики_работы_водителей графики_работы_водителей = new графики_работы_водителей();
        графики_работы_водителей.Show();
    }
}