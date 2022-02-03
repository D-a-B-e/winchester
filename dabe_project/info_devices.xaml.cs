using System;
using System.IO;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;

namespace dabe_project
{
    
    public partial class info_devices : Window
    {
        private SqlConnection connection;
        private Window parent;
        public info_devices(SqlConnection connection, Window parent)
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

        private void querySqlFun(string querySql)
        {
            string sqlExpression = querySql;


            try
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    descript_device.Text = reader.GetString(1);
                    byte[] img_byte = reader[2] as byte[];

                    if (img_byte != null)
                    {

                        MemoryStream mem_stream = new MemoryStream(img_byte);
                        try
                        {
                            lab_img.Source = BitmapFrame.Create(mem_stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        }
                        catch (NotSupportedException)
                        {
                            lab_img.Source = null;
                        }
                    }
                    reader.Close();

                }

                else
                {

                    reader.Close();


                }
            }

            catch (SqlException e)
            {
                MessageBox.Show("Ошибка" + e.ToString());
                this.Close();
            }

        }

        private void disketa_Click(object sender, RoutedEventArgs e)
        {
            string querySql = "SELECT name_device, description_device, img FROM dbo.info_devices WHERE(name_device = 'Дискета')";
            querySqlFun(querySql);
        }

        private void dvd_disk_Click(object sender, RoutedEventArgs e)
        {
            string querySql = "SELECT name_device, description_device, img FROM dbo.info_devices WHERE(name_device = 'DVD-диск')";
            querySqlFun(querySql);
        }

        private void usb_flash_Click(object sender, RoutedEventArgs e)
        {
            string querySql = "SELECT name_device, description_device, img FROM dbo.info_devices WHERE(name_device = 'USB-flash')";
            querySqlFun(querySql);
        }

        private void hdd_Click(object sender, RoutedEventArgs e)
        {
            string querySql = "SELECT name_device, description_device, img FROM dbo.info_devices WHERE(name_device = 'Жесткий диск')";
            querySqlFun(querySql);
        }

        private void begin_test_Click(object sender, RoutedEventArgs e)
        {
            new Test(connection, this);
            this.Visibility = Visibility.Hidden;
        }
    }
}
