using System.Data;
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
        // Connection to the database
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-2\\SQLLAPTOP;Initial Catalog=fuck;Persist Security Info=True;User ID=dimavoronkov2222;Password=G_8289/00/5654_G;Encrypt=True;Trust Server Certificate=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("Connection successful!", "Information",MessageBoxButton.OK,MessageBoxImage.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private void LoadData()
        {
            string connectionString = "Data Source=LAPTOP-2\\SQLLAPTOP;Initial Catalog=fuck;Persist Security Info=True;User ID=dimavoronkov2222;Password=G_8289/00/5654_G;Encrypt=True;Trust Server Certificate=True";
            string sql = "SELECT * FROM dbo.Student_Grades2";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable("Student_Grades2");
            dataadapter.Fill(dt);
            StudentGradesDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}