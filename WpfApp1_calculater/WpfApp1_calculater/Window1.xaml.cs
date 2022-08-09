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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApp1_calculater
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            string connString = "server=127.0.0.1;port=3306;user id=root;password=;database=calculator;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string sql = "SELECT * FROM test WHERE 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            string txt = "";
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                txt = "id:" + data["id"].ToString() + " dec:" + data["dec_"].ToString() + " bin:" + data["bin_"].ToString() +
                " infix:" + data["infix"].ToString() + " postfix:" + data["postfix"].ToString() + " prefix:" + data["prefix"].ToString();
                datasbox.Text += txt;
                datasbox.Text += "\n";
            }
            conn.Close();
        }

        private void datasbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            string delid = delbox.Text;
            string connString = "server=127.0.0.1;port=3306;user id=root;password=;database=calculator;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string sql = $"DELETE FROM test WHERE id='{delid}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            delbox.Text = "";
            connString = "server=127.0.0.1;port=3306;user id=root;password=;database=calculator;charset=utf8;";
            MySqlConnection conn2 = new MySqlConnection(connString);
            conn2.Open();
            sql = "SELECT * FROM test WHERE 1";
            MySqlCommand cmd2 = new MySqlCommand(sql, conn2);
            string txt = "";
            datasbox.Text = "";
            MySqlDataReader data = cmd2.ExecuteReader();
            while (data.Read())
            {
                txt = "id:" + data["id"].ToString() + " dec:" + data["dec_"].ToString() + " bin:" + data["bin_"].ToString() +
                " infix:" + data["infix"].ToString() + " postfix:" + data["postfix"].ToString() + " prefix:" + data["prefix"].ToString();
                datasbox.Text += txt;
                datasbox.Text += "\n";
            }
            conn2.Close();
        }
    }
}
