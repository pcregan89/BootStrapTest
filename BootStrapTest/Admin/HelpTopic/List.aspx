<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopic.List" MasterPageFile="~/Master/AdminMaster.Master"%>


<asp:Content ContentPlaceHolderId="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="scr" runat="server">
        </asp:ScriptManager> 
        <h2>List of Help Topics</h2>
    
        <button type="button" class="btn btn-primary" onclick="javascript:window:location.href='../../Admin/HelpTopic/form.aspx?id=-1'; return false;"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Add New</button>
        <button type="button" id="deleteButton" class="btn btn-danger" data-toggle="modal" data-target="#dlModal"><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button>
    <p style="display:inline">Filter By Category:</p>
   <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-default dropdown-toggle"></asp:DropDownList>
    <asp:Button ID="btnRefresh" runat="server" Text="Filter" CssClass="btn btn-default" OnClick="btnRefresh_Click" />
    <table class="table table-hover table-responsive" style="border-top:hidden;">          
            <asp:Repeater ID="rptHelpTopic" runat="server" OnItemDataBound="rptHelpTopic_ItemDataBound" >

                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>Select</th>
                            <th>Category</th>
                            <th>Title</th>
                            <th>View Count</th>
                            <th>Share Count</th>
                            <th>Last Updated</th>
                            <th>Priority</th>
                            <th>Logged Out Available</th>
                            <th>Likes</th>
                            <th>Dislikes</th>
                            <th>Edit</th>
                            <th>Permalink</th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr style="border-bottom:hidden;">
                        
        <asp:UpdatePanel ID="Upd" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="selectedRow" EventName="CheckedChanged" />
            </Triggers>
        </asp:UpdatePanel>
                        
                        <td><asp:checkbox id="selectedRow" runat="server" Checked="false" OnClientClick="return false;"/>
                        <td><asp:Label runat="server" ID="lblCatParent" Text='<%# Eval("Help_Category_ID") %>' /></td>
                        <td><%# Eval("Help_Topic_Header") %></td>
                        <td><%# Eval("Help_Topic_View_Count") %></td>
                        <td><%# Eval("Help_Topic_Share_Count") %></td>
                        <td><asp:Label runat="server" ID="lastupdated" Text='<%# String.Format("{0:dd MMM yyyy}", Eval("Help_Topic_Last_Updated")) %>' /></td>
                        <td><asp:Label runat="server" ID="lblPriority" Text='<%# Eval("Help_Topic_Priority") %>' /></td>
                        <td><%# Eval("Help_Topic_Logged_Out_Available") %></td>
                        <td><%# Eval("Help_Topic_Likes") %></td>
                        <td><%# Eval("Help_Topic_Dislikes") %></td>
                        <td><button id="editButton" onclick="javascript:window.location.href='../../Admin/HelpTopic/Form.aspx?id=<%# Eval("Help_Topic_ID")  %>'; return false;">Edit</button></td>
                        <td><a href='../../HelpTopic.aspx?id=<%# Eval("Help_Topic_ID")  %>'>Permalink</a></td>   
                    </tr>
                    <tr style="border-bottom:hidden">
                        <th>Text</th>
                    </tr>
                    <tr style="border-bottom:inset">
                        <td colspan="12"><%# Eval("Help_Topic_Text") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

     <div class="modal fade" id="dlModal" tabindex="-1" role="dialog" aria-labelledby="Delete Modal">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Confirm Delete</h4>
      </div>
      <div class="modal-body">
        Are you sure you wish to delete these help topics?
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <asp:button type="button" class="btn btn-danger" runat="server" OnClick="deleteButton_Click" Text="Delete"></asp:button>
      </div>
    </div>
      </div>
</div>
</asp:Content>