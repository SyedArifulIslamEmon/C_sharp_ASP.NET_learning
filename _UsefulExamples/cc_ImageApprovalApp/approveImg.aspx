<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approveImg.aspx.cs"
    Inherits="approveImg" MasterPageFile="~/masterpages/generic-noleftmenu.master" %>
    
<asp:Content ContentPlaceHolderID="mainBlock" runat="server">
    <asp:Label runat="server" Text="" ID="msgLabel" />
    <br />
    <asp:HyperLink ID="imgPage" runat="server" Text="" NavigateUrl="~/imgDisplay.aspx" />
</asp:Content>
