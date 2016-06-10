<%@ Page Title="" Language="C#" MasterPageFile="~/Master/PopupMaster.Master" AutoEventWireup="true" CodeBehind="PopupTopic.aspx.cs" Inherits="BootStrapTest.PopupTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="col-xs-8 col-xs-offset-1" style="padding:20px;">
     <%--<h3><%#Eval("Help_Topic_Header") %></h3>--%>
    <asp:Label runat="server" ID="lblHeader" CssClass="h3"></asp:Label>
    <div class="body">
        <asp:Label runat="server" ID="lblText"></asp:Label>
        <br />

        <asp:Label runat="server" ID="lblUpdated" Font-Size="11px" Text="Last Updated: "></asp:Label><br />
        <asp:Repeater runat="server" ID="rptRelated" OnItemDataBound="rptRelated_ItemDataBound">
            <HeaderTemplate>
                Related Topics: 
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label runat="server" ID="lblRelID" Visible="false"></asp:Label>
                <li><asp:LinkButton runat="server" ID="lnkRel" OnClick="lnkRel_Click" OnClientClick="aspnetForm.target = '_blank';"></asp:LinkButton></li>
            </ItemTemplate>
            <FooterTemplate>
                <br />
            </FooterTemplate>
        </asp:Repeater>
    </div>
        <div class="row">
            <br /><br /><br />
            <div class="jumbotron">
             <p>Do you think this help topic was helpful?</p>
            <asp:LinkButton id="btnLike" class="btn btn-success" runat="server" OnClick="btnLike_Click" Text='<i class="fa fa-thumbs-o-up" aria-hidden="true"></i>'></asp:LinkButton>
            <asp:LinkButton id="btnDislike" class="btn btn-danger" runat="server" OnClick="btnDislike_Click" Text='<i class="fa fa-thumbs-o-down" aria-hidden="true"></i>'></asp:LinkButton>
            <asp:LinkButton id="btnShare" class="btn btn-default" runat="server" OnClick="btnShare_Click" Text='<i class="fa fa-envelope" aria-hidden="true" fa-lg"></i> Share'></asp:LinkButton>
                </div>

            <asp:Label ID="result" runat="server"></asp:Label>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
