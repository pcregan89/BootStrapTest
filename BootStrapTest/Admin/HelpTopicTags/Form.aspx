<%@ Page Title="Edit Help Topic Tags" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopicTags.Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit Help Topic Tags</h2>
    <asp:Label runat="server" ID="lblTopic" Font-Bold="true"></asp:Label><br />
    <div class="input-group">
        <asp:TextBox runat="server" ID="txtTags" CssClass="form-control" Height="30px" placeholder="Enter Tags"></asp:TextBox>
        <span class="input-group-btn">
            <asp:LinkButton ID="btnAddTag" runat="server" CssClass="btn btn-primary" Height="30px" OnClick="btnAddTag_Click">
                    <i class="fa fa-plus"></i>
            </asp:LinkButton>
        </span>
        <span style="margin-left: 20px;"></span>
    </div>
    <br />
    <asp:Label ID="lblWarning" runat="server" Visible="false"></asp:Label><br />
    <asp:Repeater ID="rptTags" runat="server">
        <HeaderTemplate>
            <table id="catList" class="table table-striped table-bordered table-hover">
                <thead>
                    <tr>
                        <th>Text</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
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
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" CssClass="btn btn-default" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
