using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Telerik_Demo
{
    public partial class GridDemoRadDropDownList : System.Web.UI.Page
    {
       SqlConnection connection;
        SqlCommand cmd;
        public GridDemoRadDropDownList()
            {
            connection = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TelericDemoConnectionString"]));
            {
                cmd = new SqlCommand("Select ID,Name,ADDRESS,PHONE FROM EMPLOYEE", connection);
                connection.Open();
                GridDemoRadDropDownList1.DataSource = cmd.ExecuteReader();

                GridDemoRadDropDownList1.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

    }
}