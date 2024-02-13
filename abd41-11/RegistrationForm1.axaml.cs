using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace abd41_11;

public partial class RegistrationForm1 : Window
{
    public RegistrationForm1()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        string login = TextBox.Text;
        string password = TextBox1.Text;

        // Проверка логина и пароля для врача
        if (login == "admin" && password == "admin")
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}