<%@ Page Title="Admin Home" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="BootStrapTest.Admin.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Admin Home</h2>
        Welcome to the admin section
        <div class="col-md-9 row" style="width: 100%;">
            <div class="col-md-5 home-tiles" style="padding: 20px; border-radius: 5px; margin: 10px; text-align: center;">
                <a href="HelpCategory/List.aspx" style="color:#ffffff">Help Category</a>
            </div>
            <div class="col-md-5 home-tiles" style="padding: 20px; border-radius: 5px; margin: 10px; text-align: center;">
                <a href="HelpTopic/List.aspx" style="color:#ffffff">Help Topic</a>
            </div>
            <div class="col-md-5 home-tiles" style="padding: 20px; border-radius: 5px; margin: 10px; text-align: center;">
                <a href="HelpTopicTags/List.aspx" style="color:#ffffff">Help Topic Tags</a>
            </div>
            <div class="col-md-5 home-tiles" style="padding: 20px; border-radius: 5px; margin: 10px; text-align: center;">
                <a href="RelatedTopics/List.aspx" style="color:#ffffff">Related Topics</a>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
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
