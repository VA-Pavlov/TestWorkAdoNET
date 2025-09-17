using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWorkAdoNET
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            connection();
        }
        private void connection()
        {
            var connectionLine = $"Data Source={DataSource_TextBox.Text};" +
                                    $"Initial Catalog={InitialCatalog_TextBox.Text};" +
                                    $"Integrated Security=True;";
            if (Auntif_CheckBox.IsChecked==true)
                connectionLine += $"";
            SqlConnection connection = new SqlConnection(connectionLine);
            try
            {
                connection.Open();
                UsersWindow usersWindow = new UsersWindow(connection);
                usersWindow.Show();
                this.Close();
            }
            catch (Exception ex) 
            {
                connection.Close();
                MessageBox.Show(ex.Message,"Ошибка подключения",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void ConnectDB_Click(object sender, RoutedEventArgs e)
        {
            connection();
        }
    }
}
