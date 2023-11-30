using System.Windows;
using Microsoft.Data.SqlClient;
namespace Module_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=DESKTOP-SE9ORTN;Initial Catalog=Module_1;Integrated Security=True;Trust Server Certificate=True";
        private void connect(string name)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            if (name == "Connect")
            {
                Connection.Open();
                MessageBox.Show("Connection successful!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (name == "Disconnect")
            {
                Connection.Close();
                MessageBox.Show("Disconnection successful!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("It seems something went wrong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Connect.Content.ToString();
            connect(name);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = Disconnect.Content.ToString();
            connect(name);
        }
    }
}