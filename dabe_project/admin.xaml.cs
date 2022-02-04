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
using System.Windows.Shapes;

namespace dabe_project
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public class Result
        {
            public int id_result { get; set; }
            public string login { get; set; }
            public string result { get; set; }
        }
        SqlConnection connection;
        Window parent;
        public Admin(SqlConnection connection, Window parent)
        {
            InitializeComponent();
            this.Show();
            this.connection = connection;
            this.parent = parent;
            List<Result> result_list = new List<Result>();

            string sqlExpression = "SELECT * FROM results";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                //  
                while (reader.Read())
                {

                    Result rec = new Result();

                    rec.id_result = reader.GetInt32(0);
                    rec.login = reader.GetString(1);
                    rec.result = reader.GetString(2);


                    result_list.Add(rec);


                }
                reader.Close();

                table.ItemsSource = result_list;
                table.Columns[0].Header = "Номер результата";
                table.Columns[1].Header = "Пользователь";
                table.Columns[2].Header = "Результат";


            }
            else
            {

                reader.Close();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
