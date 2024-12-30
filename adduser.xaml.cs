using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Windows.Controls;
using System.Windows.Input;

namespace _1224_Practice;

public partial class adduser : Window
{
    public adduser()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        string reciever = txtuser.Text;
        string adder = MainWindow.GlobalData._SharedData;
        string firstmessage = "chat start";
        string sql2 = $"insert into Message values ('{adder}','{firstmessage}','{reciever}');";
        string sql3 = $"select * from UserTable where UserName='{adder}' or UserName = '{reciever}';";
        DataTable table = SelectData(sql3);
        
        EditMessageBox(sql2);
        MessageBox.Show("添加成功");
        Index index = new Index();
        index.Show();
        this.Hide();
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
    public static DataTable SelectData(string sql3)
    {
        SqlConnection sq = new SqlConnection();
        sq.ConnectionString = "Server = localhost; DataBase = chatdemo; Trusted_Connection=true;";
        sq.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sq;
        cmd.CommandText = sql3;
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = cmd;
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        sq.Close();
        DataTable table = ds.Tables[0];
        return table;
    }
    
    private void Txtuser_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtuser.Text) && txtuser.Text.Length > 0)
        {
            txtuser.Visibility = Visibility.Collapsed;
        }
        else
        {
            txtuser.Visibility = Visibility.Visible;
        }
    }

    private void Txtusername_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        txtusername.Focus();
    }

    private void ButtonBase_Backchat(object sender, RoutedEventArgs e)
    {
        Index index = new Index();
        index.Show();
        Hide();
    }
}