<%@ Page Title="Help Topic Tags" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BootStrapTest.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Home</h2>
    <asp:Panel ID="pnlHome" runat="server">
        Welcome to the help section
    </asp:Panel>
    <asp:Panel ID="pnlTopics" runat="server">
        <%--<div class="panel-group" id="dvAccordion" role="tablist" aria-multiselectable="true">
            <asp:Repeater ID="rptTopics" runat="server" Visible="false">
                <ItemTemplate>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingOne">
                        <h4 class="panel-title">
                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                <%# Eval("Help_Topic_Header") %>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                        <div class="panel-body">
                            <%# Eval("Help_Topic_Text") %>
                        </div>
                    </div>
                </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>
        <div id="dvAccordian" style = "width:400px">
            <asp:Repeater ID="rptTopics" runat="server">
                <ItemTemplate>
                    <h3>
                        <%# Eval("Help_Topic_Header") %></h3>
                    <div>
                        <p>
                            <%# Eval("Help_Topic_Text") %>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>

</asp:Content>
<asp:Content ContentPlaceHolderID="javascript" runat="server">
<%--    <script type="text/javascript">
    $(function () {
        $("#dvAccordian").accordion();
    });
</script>--%>
</asp:Content>
