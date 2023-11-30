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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-SE9ORTN;Initial Catalog=Module_1;Integrated Security=True;Trust Server Certificate=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("Connection successful!", "Information",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}