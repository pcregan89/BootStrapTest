<%@ Page Title="Help Topic Tags" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopicTags.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Help Topic Tags List</h2>
    <table id="catList" class="table table-striped table-bordered table-hover">
        <thead>
            <tr>
                <th>ID</th>
                <th>Title</th>
                <th>Tags</th>
                <th></th>
            </tr>
        </thead>

        <tbody>
            <asp:Repeater ID="rptHelpTopic" runat="server" OnItemDataBound="rptHelpTopic_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Help_Topic_ID") %></td>
                        <td><%# Eval("Help_Topic_Header") %></td>
                        <td>
                            <asp:Label runat="server" ID="lblTags"></asp:Label></td>
                        <td>
                            <button type="button" class="btn btn-default btn-xs" onclick="location.href='../../Admin/HelpTopicTags/Form.aspx?id=<%# Eval("Help_Topic_ID")  %>'">
                                <i class="fa fa-pencil-square-o"></i> Edit</button>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
