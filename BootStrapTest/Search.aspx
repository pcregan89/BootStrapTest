<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BootStrapTest.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Search Results</h2>
    <asp:Repeater ID="rptSearch" runat="server">
        <ItemTemplate>
            <div style="border-bottom:dashed 1px black; margin-bottom:10px;">
                <asp:Label ID="lblID" runat="server" Text='<%# Eval("Help_Topic_ID") %>' Visible="false"></asp:Label>
                <asp:LinkButton ID="lnkHead" runat="server" CssClass="h3" OnClick="lnkHead_Click"><%#Eval("Help_Topic_Header") %></asp:LinkButton>
                <br />
                <asp:Label ID="lblSummary" runat="server" CssClass="body-content" Text='<%# Eval("Help_Topic_Text") %>'></asp:Label>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
