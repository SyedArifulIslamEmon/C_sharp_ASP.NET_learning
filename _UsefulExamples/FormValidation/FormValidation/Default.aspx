<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormValidation._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Number" 
                AssociatedControlID="TextBox1" />
            <asp:TextBox ID="TextBox1" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Field is required!!!!!" ControlToValidate="TextBox1" Display="None" />
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ErrorMessage="Number must be between 1 and 100!!!!!!!!" MinimumValue="1" 
                MaximumValue="100" ControlToValidate="TextBox1" Display="None" />
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Number" 
                AssociatedControlID="TextBox2" />
            <asp:TextBox ID="TextBox2" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Field is required!!!!!" ControlToValidate="TextBox2" Display="None" />
            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                ErrorMessage="Number must be between 1 and 100!!!!!!!!" MinimumValue="1" 
                MaximumValue="100" ControlToValidate="TextBox2" Display="None" />
        </div>
        <asp:Button ID="Button1" runat="server" Text="Submit" CausesValidation="false" OnClick="Button1_Click" />
    </form>
</body>
</html>
