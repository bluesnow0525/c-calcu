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
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApp1_calculater
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        
        string nums = "";
        string pre = "";
        string post = "";
        string dec = "";
        string bin = "";
        public MainWindow()
        {
            InitializeComponent();
            
        }

        bool isOp(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/')
                return true;
            return false;
        }
        char compare(char opt, char si)
        {
            
            if ((opt == '+' || opt == '-') && (si == '*' || si == '/'))
                return '<';
            else if (opt == '#')
                return '<';
            return '>';
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //if click 1
            nums += "1";
            num_show.Text= nums;
        }

        private void num_show_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            nums += "2";
            num_show.Text = nums;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            nums += "3";
            num_show.Text = nums;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            nums += "4";
            num_show.Text = nums;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            nums += "5";
            num_show.Text = nums;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            nums += "6";
            num_show.Text = nums;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            nums += "7";
            num_show.Text = nums;
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            nums += "8";
            num_show.Text = nums;
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            nums += "9";
            num_show.Text = nums;
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            nums += "0";
            num_show.Text = nums;
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            nums += "+";
            num_show.Text = nums;
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            nums += "-";
            num_show.Text = nums;
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            nums += "*";
            num_show.Text = nums;
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            nums += "/";
            num_show.Text = nums;
        }

        private void buttonclear_Click(object sender, RoutedEventArgs e)
        {
            num_show.Text = "";
            post_show.Text = "";
            pre_show.Text = "";
            dec_show.Text = "";
            bin_show.Text = "";
            nums = "";
            bin = "";
            pre = "";
            post = "";
            dec = "";        
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            //dec and bin
            List<char> tmp = new List<char>();
            List<int> arr = new List<int>();
            foreach (char c in nums)
            {
                if(c=='*' || c == '/' || c=='+' || c=='-')
                {
                    tmp.Add(c);
                }
                else
                {
                    arr.Add(c-'0');
                }
            }           
            for(int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i] == '*')
                {
                    int a=(arr[i])*(arr[i + 1]);
                    arr[i] = a;
                    arr[i + 1] = 0;
                    tmp[i] = '+';
                    
                }
                if (tmp[i] == '/')
                {
                    int a = (arr[i]) / (arr[i + 1]);
                    arr[i] = a;
                    arr[i + 1] = 0;
                    tmp[i] = '+';
                }
            }
            int dec_num = arr[0];
            for (int i = 0; i <tmp.Count; i++)
            {                           
                if(tmp[i] == '+')
                {
                    dec_num += (arr[i+1] );
                }
                if(tmp[i] == '-')
                {
                    dec_num -= (arr[i + 1] );
                }                
            }
            int m = dec_num;
            string rebin = "";
            bin = "";
            while (true)
            {
                int r=m%2;
                m=m/2;
                rebin+=r.ToString();
                if (m == 0)
                {
                    break;
                }
            }
            for(int i = rebin.Length-1; i >= 0; i--)
            {
                bin += rebin[i];
            }
            dec = dec_num.ToString();
            dec_show.Text = dec;
            bin_show.Text = bin;
            //post
            Stack<char> ops = new Stack<char>();
            Stack<char> lists = new Stack<char>();
            ops.Push('#');
            lists.Push('#');
            //text_binary.Text = string.Parse(nums.Length.ToString());
            for (int i = 0; i < nums.Length; i++)
            {
                if (!isOp(nums[i]))
                    lists.Push(nums[i]);
                else
                {
                    char c = compare(ops.Peek(), nums[i]);
                    if (c == '<')
                        ops.Push(nums[i]);
                    else
                    {
                        lists.Push(ops.Peek());
                        ops.Pop();
                        ops.Push(nums[i]);
                    }

                }
            }
            //Object a = '#';
            while (ops.Peek() != '#')
            {
                
                lists.Push(ops.Peek());
                ops.Pop();
            }
            List<char> s1 = new List<char>();
            while (lists.Peek() != '#')
            {
                
                s1.Add(lists.Peek());
                lists.Pop();
                
            }
            for (int i = 0; i < s1.Count / 2; i++)
            {
                
                char temp = s1[i];
                s1[i] = s1[s1.Count - 1 - i];
                s1[s1.Count - 1 - i] = temp;
            }
            string postorderr = "";
            for (int i = 0; i < s1.Count; i++)
            {
                postorderr += s1[i];
            }
            post_show.Text = postorderr;
            post = postorderr;
            //pre
            ops.Clear();
            lists.Clear();
            ops.Push('#');
            lists.Push('#');
            //text_binary.Text = string.Parse(nums.Length.ToString());
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (!isOp(nums[i]))
                    lists.Push(nums[i]);
                else
                {
                    char c = compare(ops.Peek(), nums[i]);
                    if (c == '<')
                        ops.Push(nums[i]);
                    else
                    {
                        lists.Push(ops.Peek());
                        ops.Pop();
                        ops.Push(nums[i]);
                    }
                }
            }
            //Object a = '#';
            while (ops.Peek() != '#')
            {
                
                lists.Push(ops.Peek());
                ops.Pop();
            }
            s1.Clear();
            //List<char> s1 = new List<char>();
            while (lists.Peek() != '#')
            {
                
                s1.Add(lists.Peek());
                lists.Pop();
                
            }
            for (int i = 0; i < s1.Count / 2; i++)
            {
                
                char temp = s1[i];
                s1[i] = s1[s1.Count - 1 - i];
                s1[s1.Count - 1 - i] = temp;
            }
            string preorderr = "";
            for (int i = s1.Count - 1; i >= 0; i--)
            {
                preorderr += s1[i];
                
            }
            pre_show.Text = preorderr;
            pre = preorderr;
        }

        private void buttom_insert_Click(object sender, RoutedEventArgs e)
        {
            string connString = "server=127.0.0.1;port=3306;user id=root;password=;database=calculator;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string sql = "SELECT * FROM test WHERE 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader data = cmd.ExecuteReader();
            int bol = 0;
            while (data.Read())
            {
               
                if (data["dec_"].ToString() == dec && data["infix"].ToString() == nums)
                {
                    Window2 w2 = new Window2();
                    w2.Show();
                    bol = 1;
                }           
            }
            conn.Close();
            if (bol == 0)
            {
                connString = "server=127.0.0.1;port=3306;user id=root;password=;database=calculator;charset=utf8;";
                MySqlConnection conn2 = new MySqlConnection(connString);
                conn2.Open();
                sql = $"INSERT INTO `test` (`id`, `dec_`, `bin_`, `infix`, `postfix`, `prefix`) VALUES (NULL, '{dec}', '{bin}', '{nums}', '{post}', '{pre}');";
                MySqlCommand cmd2 = new MySqlCommand(sql, conn2);
                cmd2.ExecuteNonQuery();
                conn2.Close();
            }
            
        }

        private void button_query_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.Show();
        }
    }
}
