<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customPaging.aspx.cs" Inherits="Telerik_Demo.customPaging" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True"></telerik:RadScriptManager>

        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="GridDemoRadGrid">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GridDemoRadGrid" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

        <div>
            <telerik:RadGrid RenderMode="Lightweight" ID="GridDemoRadGrid" runat="server"
                AllowPaging="false" 
                ShowStatusBar="true" 
                AlternatingItemStyle-ForeColor="skyblue" 
                PageSize="10" 
                OnNeedDataSource="GridDemoRadGrid_NeedDataSource" 
                OnPageIndexChanged="GridDemoRadGrid_PageIndexChanged">
                <PagerStyle Mode="NextPrevAndNumeric" />
                <ClientSettings AllowDragToGroup="False">
                </ClientSettings>
                <MasterTableView AutoGenerateColumns="False" AllowCustomPaging="true"
                    DataKeyNames="ID" CommandItemDisplay="Top" InsertItemDisplay="Top"
                    InsertItemPageIndexAction="ShowItemOnFirstPage" AllowPaging="true">
                    <Columns>
                        <telerik:GridEditCommandColumn UniqueName="EditCommandColumn">
                        </telerik:GridEditCommandColumn>
                        <telerik:GridBoundColumn UniqueName="ID" HeaderText="ID" DataField="ID" InsertVisiblityMode="AlwaysHidden" Visible="true" ReadOnly="false">
                            <HeaderStyle Width="70px"></HeaderStyle>
                        </telerik:GridBoundColumn>
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

            <%--<asp:SqlDataSource ID="GridDemoRadGridSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TelericDemoConnectionString %>"
                SelectCommand="Sp_EmployeeData_Select"></asp:SqlDataSource>--%>
        </div>
    </form>
</body>
</html>
