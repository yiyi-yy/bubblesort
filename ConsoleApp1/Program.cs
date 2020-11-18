using System;
using System.Data;
using System.Text;
using ConsoleApp1.Implement;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using Renci.SshNet;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
          //  maopao();
            Console.WriteLine("Hello World!");

            ISort sort = new ImplSort() ;
            int[] arr = new int[] { 2, 1,3,5,4,7,0,2, 4, 8, 4, 29, 2, 1 };
            string bubbleSort =sort.arrToString( sort.bubbleSort(arr));
            Console.WriteLine($"冒泡排序后：{bubbleSort}");


            string selectedSort = sort.arrToString(sort.selectedSort(arr));
            Console.WriteLine($"选择排序后：{bubbleSort}");
        }

        public void mysql()
        {

            string SSHHost = "120.27.71.106";        // SSH地址
            int SSHPort = 22;              // SSH端口
            string SSHUser = "root";           // SSH用户名
            string SSHPassword = "11,Alipay";           // SSH密码

            string sqlIPA = "127.0.0.1";// 映射地址  实际上也可以写其它的   Linux上的MySql的my.cnf bind-address 可以设成0.0.0.0 或者不设置
            string sqlHost = "localhost"; // mysql安装的机器IP 也可以是内网IP 比如：192.168.1.20
            uint sqlport = 3306;        // 数据库端口及映射端口
            string sqlConn = "Database=javatest;Data Source=" + sqlIPA + ";Port=" + sqlport + ";User Id=root;Password=root;CharSet=utf8;SslMode=None;";

            PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(SSHHost, SSHPort, SSHUser, SSHPassword);


            using (var client = new SshClient(connectionInfo))
            {
                try
                {
                    client.Connect();
                    if (!client.IsConnected)
                    {
                        Console.WriteLine("没有连接成功！");
                        return;
                    }

                    var portFwdL = new ForwardedPortLocal(sqlIPA, sqlport, sqlHost, sqlport); //映射到本地端口
                    client.AddForwardedPort(portFwdL);
                    portFwdL.Start();
                    if (!client.IsConnected)
                    {
                        Console.WriteLine("没有连接成功！");
                        return;
                    }
                    // MySqlSslMode.None
                    MySqlConnection conn = new MySqlConnection(sqlConn);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();

                    string sql = "select * from people";
                    myDataAdapter.SelectCommand = new MySqlCommand(sql, conn);

                    try
                    {
                        conn.Open();
                        DataSet ds = new DataSet();
                        myDataAdapter.Fill(ds);
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            //         Console.WriteLine(Convert.ToString( item["id"]));
                            Console.WriteLine(Convert.ToString(item["name"]));
                            Console.WriteLine(Convert.ToString(item["age"]));
                            Console.WriteLine("-----------------------");
                        }
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }

                    client.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                finally { }
            }
        }
        public static void maopao()
        {
            string a = "bdhxabdfjeofmvlode";
            char[] arr = a.ToCharArray();
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    char temp ;
                    if (arr[i]>arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    max++;
                }
            }
            string aa=new String(arr);
            Console.WriteLine( aa);
            Console.WriteLine(max.ToString());

            max = 0;
            char[] arr2 = a.ToCharArray();
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2.Length-i; j++)
                {
                    char temp;
                    if (arr2[i] > arr2[j])
                    {
                        temp = arr2[i];
                        arr2[i] = arr2[j];
                        arr2[j] = temp;
                    }
                    max++;
                }
            }

            string bb = new String(arr2);
            Console.WriteLine(bb);
            Console.WriteLine(max);

            max = 0;
            char[] arr3 = a.ToCharArray();
            for (int i = 0; i < arr3.Length-1; i++)
            {
                for (int j = 0; j < arr3.Length - i-1; j++)
                {
                    char temp;
                    if (arr3[j] > arr3[j+1])
                    {
                        temp = arr3[j];
                        arr3[j] = arr3[j+1];
                        arr3[j+1] = temp;
                    }
                    max++;
                }
            }

            int[] arr4 = new int[] { 2,4,6,2,6,2,4,8,4,29,2,1};
            for (int i = 0; i < arr4.Length - 1; i++)
            {
                for (int j = 0; j < arr4.Length - i - 1; j++)
                {   // 这里说明为什么需要-1
                    if (arr4[j] > arr4[j + 1])
                    {
                        int temp1 = arr4[j];
                        arr4[j] = arr4[j + 1];
                        arr4[j + 1] = temp1;
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in arr4)
            {
                sb.Append(item);
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine(max);

            string cc = new String(arr3);
            Console.WriteLine(cc);
            Console.WriteLine(max);
        }
        public static void erfenchaozhao()
        { 
        }
    }
}
