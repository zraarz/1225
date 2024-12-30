using System.Windows;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _1224_Practice;

public partial class new_user : Window
{
    public new_user()
    {
        InitializeComponent();
    }
    
    public static int EditData(string sql)
    {
        SqlConnection sq = new SqlConnection();
        sq.ConnectionString = "Server = localhost; DataBase = chatdemo; Trusted_Connection=true;";
        sq.Open();
        SqlCommand cmd = new SqlCommand(sql, sq);
        int count = 0;
        try
        {
            count = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }

        sq.Close();
        return count;
    }

    public static int EditMessageBox(string sql2)
    {
        SqlConnection sq2 = new SqlConnection();
        sq2.ConnectionString = "Server = localhost; DataBase = message; Trusted_Connection=true;";
        sq2.Open();
        SqlCommand cmd = new SqlCommand(sql2, sq2);
        int count2 = 0;
        try
        {
            count2 = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }

        sq2.Close();
        return count2;
    }
    public static DataTable SelectData(string sql)
    {
        SqlConnection sq = new SqlConnection();
        sq.ConnectionString = "Server = localhost; DataBase = chatdemo; Trusted_Connection=true;";
        sq.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sq;
        cmd.CommandText = sql;
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = cmd;
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        sq.Close();
        DataTable table = ds.Tables[0];
        return table;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        string newusername = Txtnewuser.Text;
        string newpassword = Txtnewpassword.Text;
        string newnickname = Txtnewnickname.Text;
        string sql = $"insert into UserTable values ('{newusername}','{newpassword}','{newnickname}');";
        int count = EditData(sql);
        try
        {
            EditData(sql);
            
        }
        catch (Exception exception)
        {
            MessageBox.Show("账户已经存在");
        }
        
        if (count <= 0)
        {
            MessageBox.Show("账户已经存在");
        }
        else
        {
            MessageBox.Show("账户创建成功");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }

    private void ButtonBase_Back(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Hide();
    }
}