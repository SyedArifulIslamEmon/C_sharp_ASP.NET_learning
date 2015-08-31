<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imgDisplay.aspx.cs" Title="Approved Images"
    Inherits="imgDisplay"  MasterPageFile="~/masterpages/generic-noleftmenu.master" %>

<asp:Content ContentPlaceHolderID="mainBlock" runat="server">
    <h2>Approved Images</h2>

<%--
    <asp:GridView runat="server" ID="lvImages" AutoGenerateColumns="false">
        <Columns>
            <asp:ImageField DataImageUrlField="url" ControlStyle-Height="100" 
                ControlStyle-Width="150" HeaderText="Image" />
            <asp:BoundField DataField="name" HeaderText="File Name" />
        </Columns>
    </asp:GridView>
--%>

    <asp:ListView runat="server" ID="lvImages" >
        <ItemTemplate>
            <li>
                <%# Eval("firstName") %> <%# Eval("lastName") %>
               
                <br />
                <asp:Image runat="server" ImageUrl='<%# Eval("url") %>' Height="100" Width="150" />
            </li>
        </ItemTemplate>
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </ul>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <p>No Images are approved.</p>
        </EmptyDataTemplate>
    </asp:ListView>

</asp:Content>