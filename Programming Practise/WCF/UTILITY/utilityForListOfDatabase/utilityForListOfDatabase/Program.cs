using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace ConsoleApplication1
{
    class Program
    {
        //        Try the following

        //For MySQL:

        //SELECT TABLE_NAME 
        //FROM INFORMATION_SCHEMA.TABLES
        //WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA='dbName'

        //For MS SQL:

        //SELECT TABLE_NAME 
        //FROM INFORMATION_SCHEMA.TABLES
        //WHERE TABLE_TYPE = 'BASE TABLE' 
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Your Server Ip => ");
            string Ip = Console.ReadLine();
            Console.WriteLine("Please enter Your UserName of SqlServer");
            string username = Console.ReadLine();
            Console.WriteLine("Enter The password Of SqlServer");
            string password = Console.ReadLine();
            SqlConnection con = new SqlConnection(
            new SqlConnectionStringBuilder()
            {
                DataSource = Ip,
                InitialCatalog = "",
                UserID = username,
                Password = password,
                PersistSecurityInfo=true,
                IntegratedSecurity = false,
                MultipleActiveResultSets = true
            }.ConnectionString
            );
            SqlConnection.ClearAllPools();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT name FROM master.dbo.sysdatabases  WHERE name LIKE '%Authentication%'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            //SqlDataAdapter ds = new SqlDataAdapter(cmd);
            //DataTable table = new DataTable();
            //ds.Fill(table);
            // <add name="ConnSecurity" connectionString="Data Source=172.16.10.120;Initial Catalog=Synchronization.Authentication;Integrated Security=false;Persist Security Info=True;User ID=sa;Password=server@2010;MultipleActiveResultSets=True" providerName="System.Data.SqlClient"/>
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    Console.WriteLine("Table Name : " + dr[0]);
                }
            }
            if (!dr.IsClosed)
            {
                dr.Close();
            }
            if (con != null)
            {
                con.Close();
            }
            Console.ReadLine();
        }
    }
}