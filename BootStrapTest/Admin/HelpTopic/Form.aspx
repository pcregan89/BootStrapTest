<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="BootStrapTest.Admin.HelpTopic.Form" MasterPageFile="~/Master/AdminMaster.Master" ValidateRequest="false"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Content/trumbowyg.min.css" />
</asp:Content>
<asp:Content ContentPlaceHolderId="ContentPlaceHolder1" runat="server">
        
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
           <label>Priority</label>
           <asp:DropDownList runat="server" id="ddlPriority" class="form-control" required>
            </asp:DropDownList>

       </fieldset>
       
  <fieldset class="form-group">
    <label for="lblTopicTitle">Help Topic Title</label>
    <asp:Textbox id="helpTopicTitle" runat="server" class="form-control" placeholder="Enter Help Topic Title" maxlength="50" required></asp:Textbox>
  </fieldset>
    
    <fieldset class="form-group">
    <label for="lblTopicText">Help Topic Text</label>
    <asp:Textbox id="helpTopicText" runat="server" TextMode="MultiLine" required></asp:Textbox>
  </fieldset>

  
 <asp:Button id="submitButton" class="btn btn-primary" Text="Submit" runat="server" onClick="submitButton_Click" OnClientClick="" />
       <Button id="returnButton" class="btn" onClick="javascript:window.location.href='../../Admin/HelpTopic/List.aspx'; return false;">Return to list</Button>
  
   <asp:Label ID="result" runat="server" Width="48%" Height="25px" style="text-align:center"></asp:Label>
   </div>


</asp:Content>

<asp:Content ContentPlaceHolderID="javascript" runat="server">

    <script src="../../Scripts/trumbowyg.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        $('#ContentPlaceHolder1_helpTopicText').trumbowyg({
            btns: [
                ['viewHTML'],
                'btnGrp-semantic',
                ['formatting'],
                ['superscript', 'subscript'],
                ['link'],
                ['insertImage'],
                'btnGrp-lists',
                ['removeformat'],
            ]
        });
    </script>
</asp:Content>