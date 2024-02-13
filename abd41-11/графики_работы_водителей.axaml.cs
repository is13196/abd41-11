using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;

namespace abd41_11;

public partial class графики_работы_водителей : Window
{
    public графики_работы_водителей()
    {
        InitializeComponent();
        string fullTable =
            "SELECT id, id_водителя, id_маршрута, время_начала, время_окончания FROM Графики_работы_водителей;";
        ShowTable(fullTable);
        string sql = "SELECT id, id_водителя, id_маршрута, время_начала, время_окончания FROM Графики_работы_водителей;";

        ShowTable(sql);
    }
    private string _connString = "server=localhost;database=abd21;port=3306;User Id=root;password=09January2004";
    private List<Графики_работы_водителей> _графикиРаботыВодителейs;
    private MySqlConnection _connection;

    public void ShowTable(string searchSql)
    {
        string sql = "SELECT id, id_водителя, id_маршрута, время_начала, время_окончания FROM Графики_работы_водителей;";

        _графикиРаботыВодителейs = new List<Графики_работы_водителей>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentГрафики_работы_водителей = new Графики_работы_водителей()
            {
                id = reader.GetInt32("id"),
                id_водителя = reader.GetInt32("id_водителя"),
                id_маршрута = reader.GetInt32("id_маршрута"),
                время_начала = reader.GetInt32("время_начала"),
                время_окончания = reader.GetInt32("время_окончания")
            };
            _графикиРаботыВодителейs.Add(currentГрафики_работы_водителей);
        }

        _connection.Close();
        Графики_работы_водителейGrid.ItemsSource = _графикиРаботыВодителейs;
    }

    private void NextButton_Click(object? sender, RoutedEventArgs e)
    {
        водители1 водители1 = new водители1();
        водители1.Show();
        
    }
}