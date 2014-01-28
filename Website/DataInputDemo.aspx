<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataInputDemo.aspx.cs" Inherits="Website.DataInputDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtCol" runat="server" Text="2"></asp:TextBox>
            <br />
            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtData" Width="800px" Height="500px"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
            <asp:Literal ID="li" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
