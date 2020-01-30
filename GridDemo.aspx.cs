using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using Telerik.Web.UI;



namespace Telerik_Demo
{
    public partial class GridDemo : System.Web.UI.Page
    {

       SqlConnection connection;
        /*SqlDataAdapter adapter;
       DataSet dataset;
       DataView dataview;*/

        public GridDemo()
        {
            connection = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TelericDemoConnectionString"]));
            

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //LoadDemoGrid();
        }



        protected void GridDemoRadGrid_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.KeepInEditMode = true;
                e.ExceptionHandled = true;
                DisplayMessage(true, "Employee " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"] + " cannot be updated. Reason: " + e.Exception.Message);
            }
            else
            {
                DisplayMessage(false, "Employee " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"] + " updated");
            }
        }

        protected void GridDemoRadGrid_ItemInserted(object source, GridInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                e.KeepInInsertMode = true;
                DisplayMessage(true, "Employee cannot be inserted. Reason: " + e.Exception.Message);
            }
            else
            {
                DisplayMessage(false, "Employee inserted");
            }
        }

        protected void GridDemoRadGrid_ItemDeleted(object source, GridDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                DisplayMessage(true, "Employee " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"] + " cannot be deleted. Reason: " + e.Exception.Message);
            }
            else
            {
                DisplayMessage(false, "Employee " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"] + " deleted");
            }
        }

        private void DisplayMessage(bool isError, string text)
        {
            Label label = (isError) ? this.Label1 : this.Label2;
            label.Text = text;
        }

        

        protected void GridDemoRadGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                GridEditCommandColumn editColumn = (GridEditCommandColumn)GridDemoRadGrid.MasterTableView.GetColumn("EditCommandColumn");
                editColumn.Visible = false;
            }
            else if (e.CommandName == RadGrid.RebindGridCommandName && e.Item.OwnerTableView.IsItemInserted)
            {
                e.Canceled = true;
            }
            else
            {
                GridEditCommandColumn editColumn = (GridEditCommandColumn)GridDemoRadGrid.MasterTableView.GetColumn("EditCommandColumn");
                if (!editColumn.Visible)
                    editColumn.Visible = true;
            }
        }
        protected void GridDemoRadGrid_PreRender(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridDemoRadGrid.EditIndexes.Add(0);
                GridDemoRadGrid.Rebind();
            }
        }
    





    /*protected void LoadDemoGrid()
        {
            dataset = new DataSet();
            adapter = new SqlDataAdapter("Sp_EmployeeData_Select", connection);
            connection.Open();
            adapter.Fill(dataset, "Employee");
            dataview = new DataView(dataset.Tables["Employee"]);
            GridDemoRadGrid.DataSource = dataview;
            connection.Close();
           
            int temp = dataview.Count;
            if (temp == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('no Data Available')", true);
                GridDemoRadGrid.Visible = false;

            }
            else
            {
                GridDemoRadGrid.Visible = true;
                GridDemoRadGrid.DataBind();
            }
        }*/

      
    }
}
