<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopic.Form" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>Help Topic</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.2/css/bootstrap.min.css">
</head>
<body>
<div class="container">
<form runat="server">
        
   <div class="col-xs-8 col-xs-offset-1">

       <h2 style="padding-top:20px"><asp:Label ID ="heading" runat="server"></asp:Label></h2>
     
      <fieldset class="form-group">
    <label for="exampleInputEmail1">Help Topic Category</label>
  
  <asp:DropDownList runat="server" id="helpTopicCategory" class="form-control" required>
  </asp:DropDownList>
   </fieldset>  
   
    <fieldset class="form-group">
      <div class="checkbox">
  <label><input runat="server" id="availableLoggedOut" type="checkbox" value="" />Available Logged Out</label>
</div>
  </fieldset>
       
  <fieldset class="form-group">
    <label for="exampleInputEmail1">Help Topic Title</label>
    <asp:Textbox id="helpTopicTitle" runat="server" class="form-control" placeholder="Enter Help Topic Title" maxlength="50" required></asp:Textbox>
  </fieldset>
    
    <fieldset class="form-group">
    <label for="exampleTextarea">Help Topic Text</label>
    <asp:Textbox id="helpTopicText" TextMode="MultiLine" runat="server" class="form-control"  rows="8" placeholder="Enter Help Topic Text" required></asp:Textbox>
  </fieldset>
  
 <asp:Button id="submitButton" class="btn btn-primary" Text="Submit" runat="server" onClick="submitButton_Click" OnClientClick="" />
       <Button id="returnButton" class="btn" onClick="javascript:window.location.href='../../Admin/HelpTopic/List.aspx'; return false;">Return to list</Button>
  
   <asp:Label ID="result" runat="server" Width="48%" Height="25px" style="text-align:center"></asp:Label>
   </div>

    
    
 </form>
 </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.2/js/bootstrap.min.js"></script>
</body>
</html>