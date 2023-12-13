using System.Data;
using System.Windows;
using Microsoft.Data.SqlClient;
using System.Linq;

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
            string connectionString = "Data Source=LAPTOP-2\\SQLLAPTOP;Initial Catalog=fuck;Persist Security Info=True;User ID=dimavoronkov2222;Password=G_8289/00/5654_G;Encrypt=True;Trust Server Certificate=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("Connection successful!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            var averageGrades = dt.AsEnumerable().Select(row => row.Field<double>("Average_Grade_Per_Year"));
            var minGrades = dt.AsEnumerable().Select(row => row.Field<string>("Subject_With_Minimum_Average_Grade"));
            var maxGrades = dt.AsEnumerable().Select(row => row.Field<string>("Subject_With_Maximum_Average_Grade"));
            var groups = dt.AsEnumerable().Select(row => row.Field<string>("Group_Name"));
            var mathGrades = dt.AsEnumerable().Select(row => row.Field<double>("Math_Grade"));
            MinAvgScore.Text = $"Minimum Average Grade: {averageGrades.Min()}";
            MaxAvgScore.Text = $"Maximum Average Grade: {averageGrades.Max()}";
            MinMathScoreCount.Text = $"Number of students with minimum math grade: {mathGrades.Count(g => g == mathGrades.Min())}";
            MaxMathScoreCount.Text = $"Number of students with maximum math grade: {mathGrades.Count(g => g == mathGrades.Max())}";
            StudentGroupCount.Text = $"Number of students in each group: {string.Join(", ", groups.GroupBy(g => g).Select(g => $"{g.Key}: {g.Count()}"))}";
            GroupAvgRating.Text = $"Group's average rating: {averageGrades.Average()}";
        }
    }
}