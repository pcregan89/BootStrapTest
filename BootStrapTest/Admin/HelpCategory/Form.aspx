<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="BootStrapTest.Admin.HelpCategory.Form" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Add/Edit Help Category</title>

    <!-- Bootstrap core CSS -->
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
</head>

<body>
    <nav class="navbar navbar-inverse navbar-top" style="margin-top: -50px;">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" href="#" style="color: #ffffff;">Help Centre</a>
            </div>
            <div id="navbar" class="navbar-collapse collapse">
                <form class="navbar-form navbar-right">
                    <!--<button type="submit" class="btn btn-primary">Sign in</button>-->
                </form>
            </div>
            <!--/.navbar-collapse -->
        </div>
    </nav>

    <!-- Main jumbotron for a primary marketing message or call to action -->
    <div class="jumbotron" style="margin-top: -20px;">
        <div class="container">
            <div class="row">
                <div class="span4" style="height: 70px; text-align: right;">
                    <form class="form-search">
                        <div id="custom-search-input" style="padding-left: 400px;">
                            <div class="input-group">
                                <input type="text" class="  search-query form-control" placeholder="Search" style="width: 600px; height: 50px" />
                                <span class="input-group-btn">
                                    <button class="btn btn-primary" type="button" style="height: 50px">
                                        <span class="fa fa-search"></span>
                                    </button>
                                </span>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Breadcrumb bar-->
    <div class="list-group" style="background-color: #dededd; color: #5890FF; font-weight: bold;">
        <%--<span class="list-group-item" style="background-color:#dededd;">
			<i class="fa fa-home" style="margin-right:5px; margin-left:50px;"></i>
			<a href="#" style="border-bottom:solid 2px #5890FF; height:50px;">Desktop Help</a>
		</span>--%>
    </div>

    <div class="container" style="width: 100%;">
        <!-- Example row of columns -->
        <div class="row">
            <div class="col-md-3" style="min-height:500px">
                <ul class="list-group product-category-all">
                    <li class="list-group-item">
                        <a href="#">Help Categories</a>
                    </li>
                    <li class="list-group-item"><span class="badge">
                        <i class="fa fa-angle-right icon-data fa-fw"></i></span>
                        <a href="#">Help Topics</a>
                    </li>
                    <li class="list-group-item"><span class="badge">
                        <i class="fa fa-angle-right icon-data fa-fw"></i></span>
                        <a href="#">Help Topic Tags</a>
                    </li>
                </ul>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-9">
                        <asp:Label ID="lblHead" runat="server" CssClass="h3"></asp:Label><br /><br />
                    </div>
                    <form runat="server">
                          <div class="form-group">
                                <asp:Label ID="lblID" runat="server" style="font-weight:bold;">Category ID: </asp:Label>
                          </div>
                          <div class="form-group">
                                <label>Category Name</label><br />
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                          </div>
                            <div class="form-group">
                                <label>Order</label><br />
                                <asp:TextBox ID="txtOrder" runat="server"></asp:TextBox>
                          </div>
                        <div class="form-group">
                                <label>Parent Category</label><br />
                                <%--<asp:TextBox ID="txtParent" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlParent" runat="server"></asp:DropDownList>
                          </div>
                        <div class="form-group">
                                <label>Available When Logged Out</label><br />
                                <asp:RadioButtonList ID="rbLoggedOut" runat="server">
                                    <asp:ListItem>True</asp:ListItem>
                                    <asp:ListItem>False</asp:ListItem>
                                </asp:RadioButtonList>
                          </div>
                        <%--<button id="btnSubmit" class="btn btn-primary">Submit</button>--%>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                        <button id="btnCancel" class="btn btn-default">Cancel</button>
                        <asp:Label runat="server" ID="lblWarning"></asp:Label>
                    </form>
                </div>
            </div>

            <hr>
        </div>
        <!-- /container -->
        <footer class="footer">
            <div class="container">
                <%--<p class="text-muted">Place sticky footer content here.</p>--%>
            </div>
        </footer>


        <!-- Bootstrap core JavaScript
	================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>--%>
        <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
        <script src="Scripts/jquery-1.12.2.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
        <script src="Scripts/SiteCode.js"></script>
</body>
</html>
