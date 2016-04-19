<%@ Page Title="Help Category List" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="BootStrapTest.Admin.HelpCategory.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblHead" runat="server" CssClass="h3">Help Category List</asp:Label><br /><br />
    <asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" OnClick="btnAdd_Click" Text="Add New Category" />
    <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" OnClick="btnDelete_Click" Text="Delete Selected" />
    <br />
    <br />
    <table id="catList" class="table table-striped table-bordered table-hover" style="cursor: pointer;" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th></th>
                <th>ID</th>
                <th>Name</th>
                <th>Order</th>
                <th>Parent</th>
                <th>Logged Out Available</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ckDelete" runat="server"></asp:CheckBox>
                        </td>
                        <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                            onmouseover="$(this).css('cursor', 'pointer')">
                            <%# Eval("Help_Category_ID") %></td>
                        <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                            onmouseover="$(this).css('cursor', 'pointer')">
                            <%# Eval("Help_Category_Name") %></td>
                        <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                            onmouseover="$(this).css('cursor', 'pointer')">
                            <%# Eval("Help_Category_Order") %></td>
                        <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                            onmouseover="$(this).css('cursor', 'pointer')">
                            <asp:Label ID="lblCatParent" runat="server" /></td>
                        <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                            onmouseover="$(this).css('cursor', 'pointer')">
                            <%# Eval("Help_Category_Logged_Out_Available") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Label ID="lblWarning" runat="server"></asp:Label>
        </tbody>
    </table>
</asp:Content>
