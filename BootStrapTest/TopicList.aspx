<%@ Page Title="Help Topics" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="BootStrapTest.TopicList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Help Topics</h2>
    <div id="accordion">
        <asp:Repeater ID="rptTopics" runat="server" OnItemDataBound="rptTopics_ItemDataBound">
            <ItemTemplate>
                <h3><%#Eval("Help_Topic_Header") %></h3>
                <div>
                    <p><%#Eval("Help_Topic_Text") %></p>
                    <br />
                    <!--Hidden labels to store variables for code behind-->
                    <asp:Label runat="server" ID="lblID" Text='<%#Eval("Help_Topic_ID") %>' Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="lblHeader" Text='<%#Eval("Help_Topic_Header") %>' Visible="false"></asp:Label>
                        
                    <asp:Label runat="server" ID="lblUpdated" Font-Size="11px" Text="Last Updated: "></asp:Label><br />
                    <asp:Repeater runat="server" ID="rptTags">
                        <HeaderTemplate>
                            <i class="fa fa-tags"></i>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a href='Search.aspx?keyword=<%#Eval("Help_Topic_Tag_Text") %>'><%#Eval("Help_Topic_Tag_Text") %></a>  |  
                        </ItemTemplate>
                        <FooterTemplate><br /></FooterTemplate>
                    </asp:Repeater>
                    <i class="fa fa-link"></i> <a href='HelpTopic.aspx?id=<%#Eval("Help_Topic_ID") %>'>Permalink</a>  |  
                    <i class="fa fa-envelope-o"></i> <asp:LinkButton runat="server" ID="lnkShare" Text="Share" OnClick="lnkShare_Click"></asp:LinkButton>                    
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/jquery-1.12.2.min.js") %>"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        //Collapse accordion panel
        $(function() {
            $("#accordion").accordion({ collapsible: true, active: false });
      });
    </script>
</asp:Content>
