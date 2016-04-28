<%@ Page Title="Help Topic" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="HelpTopic.aspx.cs" Inherits="BootStrapTest.HelpTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-8 col-xs-offset-1">

            <h3 style="padding-top:20px"><asp:Label ID ="helpTopicTitle" runat="server"></asp:Label></h3> 
        <br />
        <asp:Label ID="helpTopicText" runat="server"></asp:Label>
        <br /><br />
        <asp:Label ID="lblLastUpdated" runat="server"></asp:Label><br />
        <asp:Label ID="helpTopicCategory" runat="server"></asp:Label>

        <% if (hasRelatedTopics) { %> 
        <br /><br />
        <div class="row">
            <ol>
            <asp:Repeater ID="rptRelatedHelpTopics" runat="server" OnItemDataBound="rptRelatedHelpTopics_ItemDataBound">
            <HeaderTemplate><strong>Related Topics</strong></HeaderTemplate>
                
                <ItemTemplate>
                    <li><asp:Label runat="server" ID="relatedTopics" Text=''></asp:Label></li>
                </ItemTemplate>
                    
            </asp:Repeater>
                </ol>
            </div>
        <% } %>
      
        <% if (!invalidHelpTopic) { %> 
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
        <% } %>

        
    </div>
</asp:Content>
