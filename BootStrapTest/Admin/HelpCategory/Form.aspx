<%@ Page Title="Add/Edit Help Category" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="BootStrapTest.Admin.HelpCategory.Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <asp:Label ID="lblHead" runat="server" CssClass="h3"></asp:Label>
    </div>
    <div class="form-group">
        <br /><asp:Label ID="lblID" runat="server" Style="font-weight: bold;">Category ID: </asp:Label><br />
    </div>
    <div class="form-group">
        <label>Category Name</label><span class="text-danger" style="font-size:18px; font-weight:bold;">*</span><br />
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Order</label><br />
        <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Parent Category</label><br />
        <asp:DropDownList ID="ddlParent" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Available When Logged Out</label><span class="text-danger" style="font-size:18px; font-weight:bold;">*</span><br />
        <asp:RadioButtonList ID="rbLoggedOut" runat="server" CssClass="radio">
            <asp:ListItem>True</asp:ListItem>
            <asp:ListItem>False</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <span  class="text-danger" style="font-size:18px;">*</span><span  class="text-danger" style="font-size:16px;"> Indicates required fields</span><br />
    <asp:Label runat="server" ID="lblWarning"></asp:Label><br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-danger" />
    <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" CssClass="btn btn-default" />
</asp:Content>
