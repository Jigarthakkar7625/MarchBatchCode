using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstAspNetWebFormApp
{
    public partial class About : Page
    {
        //ADO.NET >> Activex data object
        // EF >> 

        //string connectioStrings = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // Dataset or Datatable >> Disconnected architecture

            // Select >> Conn oprn close nai thay.
            //SqlCommand sqlCommand = new SqlCommand("Select * from [dbo].[AuditLog]", SqlConnection); //Kuvo
            //SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            //DataSet dataSet = new DataSet();
            //adapter.Fill(dataSet, "MyTable");

            //foreach (DataRow row in dataSet.Tables["MyTable"].Rows)
            //{

            //}

            //Select >> Conn oprn close nai thay.
            SqlCommand sqlCommand = new SqlCommand("SP_GetData", SqlConnection); //Kuvo
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "MyTable");

            DataTable datatable = new DataTable();
            adapter.Fill(datatable);

            GridView1.DataSource = datatable;
            GridView1.DataBind();




            foreach (DataRow row in dataSet.Tables["MyTable"].Rows)
            {

            }



            //SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[AuditLog] VALUES(@value)", SqlConnection);

            //sqlCommand.Parameters.AddWithValue("@value", txtName.Text);

            //SqlConnection.Open();
            //sqlCommand.ExecuteNonQuery();
            //SqlConnection.Close();


            //var a = txtName.Text;
        }
    }
}