<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopic.List" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>List Of Help Topics</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>

    <div class="container">
        <h2>List of Help Topics</h2>
        <button type="button" class="btn btn-primary">Add New</button>
        <table class="table table-hover">
            <asp:Repeater ID="rptHelpTopic" runat="server" OnItemDataBound="rptHelpTopic_ItemDataBound">

                <HeaderTemplate>
                    <thead>
                        <tr>
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

                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblCatParent" Text='<%# Eval("Help_Category_ID") %>' /></td>
                        <td><%# Eval("Help_Topic_Header") %></td>
                        <td><%# Eval("Help_Topic_Text") %></td>
                        <td><%# Eval("Help_Topic_View_Count") %></td>
                        <td><%# Eval("Help_Topic_Share_Count") %></td>
                        <td>
                            <asp:Label runat="server" ID="Label1" Text='<%# String.Format("{0:ddd MMM yyyy}", Eval("Help_Topic_Last_Updated")) %>' /></td>
                        <td><%# Eval("Help_Topic_Priority") %></td>
                        <td><%# Eval("Help_Topic_Logged_Out_Available") %></td>
                        <td><%# Eval("Help_Topic_Likes") %></td>
                        <td><%# Eval("Help_Topic_Dislikes") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
        </table>
    </div>
    </form>

</body>
</html>
