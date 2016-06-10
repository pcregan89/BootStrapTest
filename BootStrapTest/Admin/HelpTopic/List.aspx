<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopic.List" MasterPageFile="~/Master/AdminMaster.Master"%>

<asp:Content ContentPlaceHolderId="ContentPlaceHolder1" runat="server">
        <h2>List of Help Topics</h2>
    
        <button type="button" class="btn btn-primary" onclick="javascript:window:location.href='../../Admin/HelpTopic/form.aspx?id=-1'; return false;"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Add New</button>
        <button type="button" id="deleteButton" class="btn btn-danger" data-toggle="modal" data-target="#dlModal"><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button>
    <p style="display:inline">Filter By Category:</p>
   <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-default dropdown-toggle" style="width:40%"></asp:DropDownList>
    <asp:Button ID="btnRefresh" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnRefresh_Click" />
    <table class="table table-hover table-bordered table-responsive" style="border-top:hidden;">          
            <asp:Repeater ID="rptHelpTopic" runat="server" OnItemDataBound="rptHelpTopic_ItemDataBound" >

                <HeaderTemplate>
                    <thead style="border:none;">
                        <tr>
                            <th style="border-right:hidden;border-left:hidden;">Select</th>
                            <th style="border-right:hidden;">Category</th>
                            <th style="border-right:hidden;">Title</th>
                            <th style="border-right:hidden;">View Count</th>
                            <th style="border-right:hidden;">Share Count</th>
                            <th style="border-right:hidden;">Last Updated</th>
                            <th style="border-right:hidden;">Priority</th>
                            <th style="border-right:hidden;">Logged Out Available</th>
                            <th style="border-right:hidden;">Likes</th>
                            <th style="border-right:hidden;">Dislikes</th>
                            <th style="border-right:hidden;">Edit</th>
                            <th style="border-right:hidden;">Permalink</th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr style="border-bottom:hidden;">
                        
                        <td style="border-right:hidden;"><asp:checkbox id="selectedRow" runat="server" Checked="false" OnClientClick="return false;"/>
                        <td style="border-right:hidden;"><asp:Label runat="server" ID="lblCatParent" Text='<%# Eval("Help_Category_ID") %>' /></td>
                        <td style="border-right:hidden;"><%# Eval("Help_Topic_Header") %></td>
                        <td style="border-right:hidden;"><%# Eval("Help_Topic_View_Count") %></td>
                        <td style="border-right:hidden;"><%# Eval("Help_Topic_Share_Count") %></td>
                        <td style="border-right:hidden;"><asp:Label runat="server" ID="lastupdated" Text='<%# String.Format("{0:dd MMM yyyy}", Eval("Help_Topic_Last_Updated")) %>' /></td>
                        <td style="border-right:hidden;"><asp:Label runat="server" ID="lblPriority" Text='<%# Eval("Help_Topic_Priority") %>' /></td>
                        <td style="border-right:hidden;"><%# Eval("Help_Topic_Logged_Out_Available") %></td>
                        <td style="border-right:hidden;"><%# Eval("Help_Topic_Likes") %></td>
                        <td style="border-right:hidden;"><%# Eval("Help_Topic_Dislikes") %></td>
                        <td style="border-right:hidden;"><button id="editButton" onclick="javascript:window.location.href='../../Admin/HelpTopic/Form.aspx?id=<%# Eval("Help_Topic_ID")  %>'; return false;">Edit</button></td>
                        <td><a href='../../HelpTopic.aspx?id=<%# Eval("Help_Topic_ID")  %>'>Permalink</a></td>   
                    </tr>
                    <tr style="border-bottom:hidden">
                        <th colspan="12">Help Topic Text</th>
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