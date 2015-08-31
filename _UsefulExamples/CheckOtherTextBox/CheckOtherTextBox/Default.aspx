<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckOtherTextBox._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%-- Validation Summary to show error messages on top of page. USED REGULARLY. --%>
        <asp:ValidationSummary DisplayMode="BulletList" runat="server" /> 

        <%-- take name input and validate as required field --%>
        <%-- default display of error message is none --%>
        <div>
            <asp:Label runat="server" Text="Name: " AssociatedControlID="txtName" />
            <asp:TextBox runat="server" ID="txtName" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" 
                ErrorMessage="Your name is required!!!!!!!!!!!!" Display="None" />
        </div>

        <%-- When checkbox "Other" is checked, textbox shows up. --%>
        <%-- Validator on textbox is disabled on default, textbox is invisible on default --%>
        <div>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Other" 
                OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />  
           <%-- "AutoPostBack" allows the textbox to appear when checkbox"Other" is clicked, 
               instead of only appear after submit button is clicked. --%>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" 
                ControlToValidate="TextBox1" ErrorMessage="This field is required!!!" 
                Display="None" Enabled="false" />
        </div>

        <%-- custom validator on calender, must choose a date --%>
        <div>
            <asp:Calendar ID="calDate" runat="server" />
            <asp:CustomValidator runat="server" OnServerValidate="Unnamed_ServerValidate" 
                ErrorMessage="Must choose a date!!!!!!!!!!!!!!" Display="None" />
        </div>

        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    </form>
</body>
</html>
