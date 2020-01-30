<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridDemo.aspx.cs" Inherits="Telerik_Demo.GridDemo" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True"></telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="True" />
        
        <telerik:RadODataDataSource runat="server" ID="RadODataDataSource1"/>
          <p id="divMsgs" runat="server">
        <asp:Label ID="Label1" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#FF8080">
        </asp:Label>
        <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#00C000">
        </asp:Label>
    </p>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="GridDemoRadGrid">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GridDemoRadGrid" />
                        <telerik:AjaxUpdatedControl ControlID="SqlDataSource1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
       <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <telerik:RadFormDecorator RenderMode="Lightweight" runat="server" DecorationZoneID="GridDemo" EnableRoundedCorners="false" DecoratedControls="All" />
      
       <div id ="GridDemo">
           
           <telerik:RadGrid RenderMode="Lightweight" ID="GridDemoRadGrid" runat="server" DataSourceID="SqlDataSource1"
            AllowPaging="True" AllowAutomaticUpdates="True" AllowAutomaticInserts="True"
            AllowAutomaticDeletes="true" AllowSorting="true" 
             OnPreRender="GridDemoRadGrid_PreRender" OnItemCommand="GridDemoRadGrid_ItemCommand" AllowFilteringByColumn="True" OnItemDeleted="GridDemoRadGrid_ItemDeleted"
            OnItemInserted="GridDemoRadGrid_ItemInserted" OnItemUpdated="GridDemoRadGrid_ItemUpdated" > 
           

            <PagerStyle Mode="NextPrevAndNumeric" />
            <MasterTableView DataSourceID="SqlDataSource1" AutoGenerateColumns="False"
                DataKeyNames="ID" CommandItemDisplay="Top">
                <Columns>
                        <telerik:GridEditCommandColumn UniqueName="EditCommandColumn">
                        </telerik:GridEditCommandColumn>
                        
                        <telerik:GridBoundColumn DataField="Name" HeaderText="Name" SortExpression="Name"
                            UniqueName="Name">
                            <ColumnValidationSettings EnableRequiredFieldValidation="true">
                            <RequiredFieldValidator ForeColor="Red" Text="*This field is required" Display="Dynamic">
                            </RequiredFieldValidator>
                        </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Email" HeaderText="Email" SortExpression="Email"
                            UniqueName="Email">
                            <ColumnValidationSettings EnableRequiredFieldValidation="true">
                            <RequiredFieldValidator ForeColor="Red" Text="*This field is required" Display="Dynamic">
                            </RequiredFieldValidator>
                        </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Contact" HeaderText="Contact" SortExpression="Contact"
                            UniqueName="Contact">
                            <ColumnValidationSettings EnableRequiredFieldValidation="true">
                            <RequiredFieldValidator ForeColor="Red" Text="*This field is required" Display="Dynamic">
                            </RequiredFieldValidator>
                        </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Address" HeaderText="Address" SortExpression="Address"
                            UniqueName="Address">
                            <ColumnValidationSettings EnableRequiredFieldValidation="true">
                            <RequiredFieldValidator ForeColor="Red" Text="*This field is required" Display="Dynamic">
                            </RequiredFieldValidator>
                        </ColumnValidationSettings>
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" HeaderText="Delete" />
                </Columns>    
            </MasterTableView>
               
        </telerik:RadGrid>
           </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TelericDemoConnectionString %>"

   ProviderName="System.Data.SqlClient"
   SelectCommand="Sp_EmployeeData_Select"
   DeleteCommand="DELETE FROM [EmployeeData] WHERE [ID] = @ID"
   InsertCommand="Sp_EmployeeData_Insert @Name,@Email,@Contact,@Address"
   UpdateCommand="UPDATE [EmployeeData] SET [Name] = @Name, [Email] = @Email, [Contact] = @Contact, [Address]= @Address WHERE [ID] = @ID">
   <DeleteParameters>
       <asp:Parameter Name="ID" Type="Int32" />
   </DeleteParameters>
   <InsertParameters>
       <asp:Parameter Name="ID" Type="Int32" />
       <asp:Parameter Name="Name" Type="String" />
       <asp:Parameter Name="Contact" Type="String" />
       <asp:Parameter Name="Email" Type="String" />
       <asp:Parameter Name="Address" Type="String" />
   </InsertParameters>
   <UpdateParameters>
       <asp:Parameter Name="ID" Type="Int32" />
       <asp:Parameter Name="Name" Type="String" />
       <asp:Parameter Name="Contact" Type="String" />
       <asp:Parameter Name="Email" Type="String" />
       <asp:Parameter Name="Address" Type="String" />
    </UpdateParameters>
 </asp:SqlDataSource>
          
    </form>
</body>
</html>
          
            
       
      
 
