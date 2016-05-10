<%@ Page Title="Related Topics - Meat Connected" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="BootStrapTest.Admin.RelatedTopics.Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scr" runat="server"> </asp:ScriptManager>

    <div class="col-xs-8">

    <h2 style="padding-top:-10px"><asp:Label ID ="heading" runat="server"></asp:Label></h2>

        <% if (!invalidTopic) { %> 
    <fieldset class="form-group">
    <h2>Update Related Topics</h2>

    <h3><asp:Label ID="lblHelpTopicHeader" runat="server"></asp:Label></h3>

        <asp:Panel id="noTopics" runat="server" visible="false">
            <p><i class="fa fa-exclamation-triangle" aria-hidden="true"></i> This topic does not have any related help topics.</p>
            </asp:Panel>

        <table class="table table-hover table-responsive" style="border-top:hidden;">
    <asp:Repeater ID="rptRelatedHelpTopics" runat="server" OnItemDataBound="rptRelatedHelpTopics_ItemDataBound">
        <HeaderTemplate>

            <thead>
                        <tr>
                            <th>Category</th>
                            <th>Title</th>
                            <th>Remove</th>
                        </tr>
                </thead>
            <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Label ID="lblTopicCategory" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblTopicHeader" runat="server"></asp:Label></td>
                <td><asp:Button runat="server" CssClass="btn btn-danger" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click"/></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
        </table>

        
     
        <div class="row">
        <asp:Label Text="Choose a help topic to add" runat="server"></asp:Label>
    <asp:DropDownList ID="ddlHelpTopics" class="form-control" runat="server"></asp:DropDownList> <br />
            <asp:Button Text="Add" CssClass="btn btn-primary" ID="btnAdd" OnClick="btnAdd_Click"  runat="server"/>
            <button class="btn btn-default" onClick="javascript:window.location.href='../../Admin/RelatedTopics/List.aspx'; return false;">Back to list</button>
        </div>
        <br />
    <p><asp:Label ID="lblResult" runat="server"></asp:Label></p>

    </fieldset>
    </div>
    <% } %>

    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
