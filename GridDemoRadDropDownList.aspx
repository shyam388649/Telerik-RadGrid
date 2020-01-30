<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridDemoRadDropDownList.aspx.cs" Inherits="Telerik_Demo.GridDemoRadDropDownList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadDropDownList ID="GridDemoRadDropDownList1" DataTextField="Name" DataValueField="ID" runat="server"></telerik:RadDropDownList>
    </div>
    </form>
</body>
</html>
