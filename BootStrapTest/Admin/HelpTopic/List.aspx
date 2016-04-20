<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopic.List" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>List Of Help Topics</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.1/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.2/css/bootstrap.min.css" />
</head>
<body>
<form id="list" runat="server">
    <div class="container">
        
        <h2>List of Help Topics</h2>
        <button type="button" class="btn btn-primary" onclick="javascript:window:location.href='../../Admin/HelpTopic/form.aspx?id=-1'; return false;"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Add New</button>
        <button type="button" id="deleteButton" class="btn btn-danger" data-toggle="modal" data-target="#myModal"><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button>
        <table class="table table-hover">
            <asp:ScriptManager ID="scr" runat="server">
        </asp:ScriptManager>
            <asp:Repeater ID="rptHelpTopic" runat="server" OnItemDataBound="rptHelpTopic_ItemDataBound" >

                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>Select</th>
                            <th>Category</th>
                            <th>Title</th>
                            <th>Text</th>
                            <th>View Count</th>
                            <th>Share Count</th>
                            <th>Last Updated</th>
                            <th>Priority</th>
                            <th>Logged Out Available</th>
                            <th>Likes</th>
                            <th>Dislikes</th>
                            <th>Edit</th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        
        <asp:UpdatePanel ID="Upd" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="selectedRow" EventName="CheckedChanged" />
            </Triggers>
        </asp:UpdatePanel>
                        
                        <td><asp:checkbox id="selectedRow" runat="server" checked="false" OnCheckedChanged="selected_CheckedChanged" AutoPostBack="true" OnClientClick="return false;"/>
                        <td><asp:Label runat="server" ID="lblCatParent" Text='<%# Eval("Help_Category_ID") %>' /></td>
                        <td><%# Eval("Help_Topic_Header") %></td>
                        <td><%# Eval("Help_Topic_Text") %></td>
                        <td><%# Eval("Help_Topic_View_Count") %></td>
                        <td><%# Eval("Help_Topic_Share_Count") %></td>
                        <td>
                            <asp:Label runat="server" ID="lastupdated" Text='<%# String.Format("{0:ddd MMM yyyy}", Eval("Help_Topic_Last_Updated")) %>' /></td>
                        <td><asp:Label runat="server" ID="lblPriority" Text='<%# Eval("Help_Topic_Priority") %>' /></td>
                        <td><%# Eval("Help_Topic_Logged_Out_Available") %></td>
                        <td><%# Eval("Help_Topic_Likes") %></td>
                        <td><%# Eval("Help_Topic_Dislikes") %></td>
                        <td><button id="editButton" onclick="javascript:window.location.href='../../Admin/HelpTopic/Form.aspx?id=<%# Eval("Help_Topic_ID")  %>'; return false;">Edit</button></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
        </table>
    </div>

     <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
    </form>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.2/js/bootstrap.min.js"></script>
        
</body>
</html>