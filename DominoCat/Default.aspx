<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DominoCat.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="setOfSquamas" runat="server" Rows="10" Columns="40" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="Find" runat="server" OnClick="Find_Click" Text="Go"/>
        <asp:TextBox ID="result" runat="server" Rows="10" Columns="40" TextMode="MultiLine"></asp:TextBox>
    </div>
    </form>
</body>
</html>
