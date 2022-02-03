using System.Windows;
using System.Data.SqlClient;

namespace dabe_project
{

    public partial class family : Window
    {
        private SqlConnection connection;
        private Window parent;
        public family(SqlConnection connection, Window parent)
        {
            InitializeComponent();
            this.parent = parent;
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
            new info_devices(connection, this);
            this.Visibility = Visibility.Hidden;
        }
    }
}
