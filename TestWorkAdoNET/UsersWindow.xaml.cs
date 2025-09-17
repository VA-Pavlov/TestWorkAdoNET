using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWorkAdoNET
{
    /// <summary>
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        SqlConnection connection;
        public UsersWindow(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            getUsers();
        }

        private void getUsers()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM  dbo.GetPersons()", connection);

            try
            {

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                // Привязываем DataTable к DataGrid
                dataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
