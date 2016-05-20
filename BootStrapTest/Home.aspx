<%@ Page Title="Help Topic Tags" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BootStrapTest.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlHome" runat="server" Visible="true">
        <h2>Home</h2>
        Welcome to the help section
        <div class="col-md-9 row" style="width: 100%;">
            <asp:Repeater runat="server" ID="rptPriority">
                <ItemTemplate>
                    <a href="HelpTopic.aspx?id=<%#Eval("Help_Topic_ID") %>">
                        <div id="divPriority" class="col-md-3 home-tiles" style="width: 250px; color: #ffffff; padding: 20px; border-radius: 5px; margin: 10px; text-align: center;">
                            <i class="fa fa-question-circle"></i>
                            <%--<asp:LinkButton runat="server" ID="lnkPriority" ForeColor="White" OnClick="lnkPriority_Click"><%#Eval("Help_Topic_Header") %></asp:LinkButton>--%>
                            <asp:Label runat="server" ID="lblText" Text='<%#Eval("Help_Topic_Header") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("Help_Topic_ID") %>' Visible="false"></asp:Label>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ContentPlaceHolderID="javascript" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/jquery-1.12.2.min.js") %>"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript">
        // Add background color to tiles
        var colors = ["#8398cf", "#83cfcb", "#8acf83", "#cfae83", "#cf8383"];

        var i = 0;
        $(".home-tiles").each(function () {
            $(this).css("background-color", colors[i++]); // increment here
            if (i == 5) i = 0; // reset the counter here
        });
    </script>
</asp:Content>
