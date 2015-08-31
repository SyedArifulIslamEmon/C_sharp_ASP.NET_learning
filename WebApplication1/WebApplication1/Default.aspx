<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged1" style="height: 22px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#660033" OnClick="Button1_Click" Text="Click me" ToolTip="Yao's Tool Tip" />
    </div>
    </form>
</body>
</html>
