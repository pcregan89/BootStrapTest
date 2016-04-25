<%@ Page Title="Help Category List" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="BootStrapTest.Admin.HelpCategory.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblHead" runat="server" CssClass="h3">Help Category List</asp:Label><br /><br />
    <button type="button" runat="server" class="btn btn-primary" onserverclick="btnAdd_Click">
            <i class="fa fa-plus"></i> Add New Category</button>
    <button type="button" runat="server" class="btn btn-danger" onserverclick="btnDelete_Click">
            <i class="fa fa-trash-o"></i> Delete Selected</button>
    <asp:Label ID="lblWarning" runat="server"></asp:Label>
    <br /><br />
    <table id="catList" class="table table-striped table-bordered table-hover">
        <thead>
            <tr>
                <th></th>
                <th>ID</th>
                <th>Name</th>
                <th>Order</th>
                <th>Parent</th>
                <th>Logged Out Available</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ckDelete" runat="server"></asp:CheckBox>
                        </td>
                        <td> <asp:Label ID="lblID" runat="server" Text='<%# Eval("Help_Category_ID") %>'></asp:Label></td>
                        <td> <%# Eval("Help_Category_Name") %></td>
                        <td> <%# Eval("Help_Category_Order") %></td>
                        <td> <asp:Label ID="lblCatParent" runat="server" /></td>
                        <td> <%# Eval("Help_Category_Logged_Out_Available") %></td>
                        <td>
                            <button type="button" class="btn btn-default btn-xs" onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'">
                                <i class="fa fa-external-link"></i> View</button>
                            <asp:LinkButton ID="btnRowDelete" runat="server" CssClass="btn btn-default btn-xs" OnClick="btnRowDelete_Click">
                                <i class="fa fa-trash-o"></i> Delete
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
