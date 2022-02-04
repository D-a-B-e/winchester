using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;

namespace dabe_project
{
    
    public partial class MainWindow : Window
    {
        private SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = @"HOME-PC\SQLEXPRESS",
                    InitialCatalog = "dabe_project",
                    IntegratedSecurity = true
                };
                connection = new SqlConnection(builder.ConnectionString);
                
            }
            catch (SqlException er)
            {
                MessageBox.Show("Ошибка подключения" + er.ToString());
            }

            connection.Open();

        }

        private void start_prog_Click(object sender, RoutedEventArgs e)
        {
            new Signup(connection, this);
            this.Visibility = Visibility.Hidden;
        }
    }
}
