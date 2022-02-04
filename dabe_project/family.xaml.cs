using System.Windows;
using System.Data.SqlClient;

namespace dabe_project
{

    public partial class family : Window
    {
        private SqlConnection connection;
        private Window parent;
        private string login;
        public family(SqlConnection connection, string login, Window parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.login = login;
            this.connection = connection;
            this.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            new info_devices(connection, login, this);
            this.Visibility = Visibility.Hidden;
        }
    }
}
