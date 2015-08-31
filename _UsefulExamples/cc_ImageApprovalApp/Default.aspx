<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Title="Yao's Form" 
    Inherits="_Default" MasterPageFile="~/masterpages/generic-noleftmenu.master" %>
<asp:Content ContentPlaceHolderID="mainBlock" runat="server">
    <h2>Yao's Form</h2>
    <asp:ValidationSummary runat="server" DisplayMode="BulletList" 
        HeaderText="There were errors processing your submission:" />
    <fieldset>
        <legend>Basic Information</legend>
        <p>
            <asp:Label runat="server" AssociatedControlID="firstName" Text="First Name:" />
            <br />
            <asp:TextBox ID="firstName" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="firstName" runat="server"
                errormessage="First name is required" Display="None" />
        </p>
        <p>
            <asp:Label runat="server" AssociatedControlID="lastName" Text="Last Name:" />
            <br />
            <asp:TextBox ID="lastName" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="lastName" runat="server"
                errormessage="Last name is required" Display="None" />
        </p>
    </fieldset>
    <fieldset>
        <legend>Image</legend>
        <p>
           <%-- <asp:Label AssociatedControlID="resumeFile" runat="server" Text="Resume File:" />
            <br />
            <asp:FileUpload ID="resumeFile" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="resumeFile" runat="server"
                errormessage="File is required" Display="None" />--%>

            <asp:Label AssociatedControlID="imgFile" runat="server" Text="Upload your image:" />
            <br />
            <asp:FileUpload ID="imgFile" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="imgFile" runat="server"
                errormessage="Image is required" Display="None" />
        </p>
    </fieldset>
    <p><asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" /></p>
</asp:Content>