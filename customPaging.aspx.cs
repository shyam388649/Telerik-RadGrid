using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Telerik_Demo
{
    public partial class customPaging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if( !Page.IsPostBack)
            //BindGridDemo();
        }
        protected void GridDemoRadGrid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindGridDemo();
        }

        private void BindGridDemo()
        {
            int startIndex = GridDemoRadGrid.CurrentPageIndex;
            int numberOfrows = GridDemoRadGrid.PageSize;

            DataSet ds = SqlHelper.ExecuteSPReturnDS(new object[] { "USP_EmployeeData_Select", "@Start_Index", startIndex, "@Number_Of_Rows", numberOfrows });

            if (GridDemoRadGrid.VirtualItemCount == 0)
                GridDemoRadGrid.VirtualItemCount = Convert.ToInt32(ds.Tables[0].Rows[0]["Records_Count"]);

            GridDemoRadGrid.DataSource = ds.Tables[1];
        }

        protected void GridDemoRadGrid_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            GridDemoRadGrid.DataBind();
        }
    }
}