<%@ Page Title="Edit Help Topic Tags" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopicTags.Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit Help Topic Tags</h2>
    <asp:Label runat="server" ID="lblTopic" Font-Bold="true"></asp:Label><br />
    <div class="input-group">
        <%--<input id="txtTags" type="text" class="  search-query form-control" placeholder="Enter tag" style="height: 30px" />--%>
        <asp:TextBox runat="server" ID="txtTags" CssClass="search-query form-control" Height="30px" placeholder="Enter Tags"></asp:TextBox>
        <span class="input-group-btn">
            <%--<button id="btnAddTag" class="btn btn-primary" type="button" onclick="btnAddTag_Click" style="height: 30px">
                <span class="fa fa-plus"></span>
            </button>--%>
            <asp:LinkButton ID="btnAddTag" runat="server" CssClass="btn btn-primary" Height="30px" OnClick="btnAddTag_Click">
                    <i class="fa fa-plus"></i>
            </asp:LinkButton>
        </span>
    </div><br />
    <asp:Label ID="lblWarning" runat="server"></asp:Label>
    <table id="catList" class="table table-striped table-bordered table-hover">
        <thead>
            <tr>
                <th>Text</th>
                <th></th>
            </tr>
        </thead>

        <tbody>
            <asp:Repeater ID="rptTags" runat="server">
                <ItemTemplate>
                    <tr>
                        <td hidden="hidden">
                            <asp:Label runat="server" ID="lblID" Text='<%# Eval("Help_Topic_Tag_ID") %>' Visible="false" />
                        </td>
                        <td><%# Eval("Help_Topic_Tag_Text") %></td>
                        <td>
                            <asp:LinkButton ID="btnRowDelete" runat="server" CssClass="btn btn-default btn-xs" OnClick="btnRowDelete_Click">
                                <i class="fa fa-trash-o"></i> Delete
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" CssClass="btn btn-default" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
