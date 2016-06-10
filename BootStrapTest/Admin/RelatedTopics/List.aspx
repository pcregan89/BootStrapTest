<%@ Page Title="List of Related Topics - Meat Connected" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BootStrapTest.Admin.RelatedTopics.List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>List of Related Topics</h2>
    <p style="display: inline">Filter By Category:</p>
    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-default dropdown-toggle" Style="width: 40%"></asp:DropDownList>
    <asp:Button ID="btnRefresh" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnRefresh_Click" />
    <br /><br />
    <table class="table table-hover table-responsive table-bordered">
        <asp:Repeater ID="rptHelpTopic" runat="server" OnItemDataBound="rptHelpTopic_ItemDataBound">

            <HeaderTemplate>
                <thead>
                    <tr>
                        <th>Category</th>
                        <th>Title</th>
                        <th>Related Topics</th>
                        <th>Change</th>
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblCatParent" Text='<%# Eval("Help_Category_ID") %>' /></td>
                    <td><%# Eval("Help_Topic_Header") %></td>
                    <td>
                        <asp:Label runat="server" ID="lblRelatedTopics"></asp:Label></td>
                    <td>
                        <button id="editButton" onclick="javascript:window.location.href='../../Admin/RelatedTopics/Form.aspx?id=<%# Eval("Help_Topic_ID")  %>'; return false;">Edit</button></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

    </table>
</asp:Content>
