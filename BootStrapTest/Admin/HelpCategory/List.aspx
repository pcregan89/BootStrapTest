<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BootStrapTest.Admin.HelpCategory.List" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Help Category List</title>

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
            <div class="col-md-3">
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
                        <form runat="server">
                        <button class="btn btn-primary" onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=-1'">Add New Category</button>
                        <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" OnClick="btnDelete_Click" Text="Delete Selected" />
                        <br />
                        <br />
                        <table id="catList" class="table table-striped table-bordered table-hover" style="cursor: pointer;" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Order</th>
                                    <th>Parent</th>
                                    <th>Logged Out Available</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckDelete" runat="server">
                                                </asp:CheckBox>
                                            </td>
                                            <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                                            onmouseover="$(this).css('cursor', 'pointer')" >
                                                <%# Eval("Help_Category_ID") %></td>
                                            <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                                            onmouseover="$(this).css('cursor', 'pointer')" >
                                                <%# Eval("Help_Category_Name") %></td>
                                            <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                                            onmouseover="$(this).css('cursor', 'pointer')" >
                                                <%# Eval("Help_Category_Order") %></td>
                                            <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                                            onmouseover="$(this).css('cursor', 'pointer')" >
                                                <asp:Label ID="lblCatParent" runat="server" /></td>
                                            <td onclick="location.href='../../Admin/HelpCategory/Form.aspx?id=<%# Eval("Help_Category_ID")  %>'"
                                            onmouseover="$(this).css('cursor', 'pointer')" >
                                                <%# Eval("Help_Category_Logged_Out_Available") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        </form>
                    </div>
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
