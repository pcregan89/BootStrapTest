
<!DOCTYPE html>
<html lang="en">
  <head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Help Section</title>

	<!-- Bootstrap core CSS -->
	<link href="Content/bootstrap.css" rel="stylesheet" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
	  <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/bootstrap-rating.css" rel="stylesheet">
  </head>

  <body>

	<nav class="navbar navbar-inverse navbar-top" style="margin-top:-50px;">
	  <div class="container">
		<div class="navbar-header">
            <a class="navbar-brand" href="#" style="color: #ffffff;">Help Centre</a>
		</div>
		<div id="navbar" class="navbar-collapse collapse">
		  <form class="navbar-form navbar-right">
			<button type="submit" class="btn btn-primary">Log in</button>
		  </form>
		</div><!--/.navbar-collapse -->
	  </div>
	</nav>

	<!-- Main jumbotron for a primary marketing message or call to action -->
	<div class="jumbotron" style="margin-top:-20px;">
	  <div class="container">
		<div class="row">
			<div class="span4" style="height:70px; text-align:right;">
				<form class="form-search">
					<div id="custom-search-input" style="padding-left:400px;">
						<div class="input-group"">
							<input type="text" class="  search-query form-control" placeholder="Search" style=" width:600px; height:50px" />
							<span class="input-group-btn">
								<button class="btn btn-primary" type="button" style="height:50px">
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
	<div class="list-group" style="background-color:#dededd; color:#5890FF; font-weight:bold;">
		<span class="list-group-item" style="background-color:#dededd;">
			<i class="fa fa-home" style="margin-right:5px; margin-left:50px;"></i>
			<a href="#" style="border-bottom:solid 2px #5890FF; height:50px;">Desktop Help</a>
		</span>
	</div>  

	<div class="container" style="width:100%;">
	  <!-- Example row of columns -->
	  <div class="row">
		<div class="col-md-3">
			<ul class="list-group product-category-all">
				<li class="list-group-item">
					<a href="#">Login & Password</a>
				</li>
				<li class="list-group-item"><span class="badge" >
					<i class="fa fa-angle-right icon-data fa-fw"></i></span>
					<a href="#">Get Started</a>
				</li>
				 <li class="list-group-item"><span class="badge" >
					<i class="fa fa-angle-right icon-data fa-fw"></i></span>
					<a href="#">Manage Your Account</a>
				</li>
				 <li class="list-group-item"><span class="badge" >
					<i class="fa fa-angle-right icon-data fa-fw"></i></span>
					<a href="#">Privacy</a>
				</li>
				 <li class="list-group-item"><span class="badge" >
					<i class="fa fa-angle-right icon-data fa-fw"></i></span>
					<a href="#">Security</a>
				</li>
				<li class="list-group-item"><span class="badge" >
				    <i class="fa fa-angle-right icon-data fa-fw"></i></span>
					<a href="#">Messaging</a>
				</li>
				 <li class="list-group-item"><span class="badge" >
					<i class="fa fa-external-link icon-data fa-fw"></i></span>
					<a href="#">Ads</a>
				</li>
			</ul>
		</div>
		<%--<div class="col-md-9">
		  <b>Popular Topics</b>
			<div style="width:100%; height:100px; background-color:#C4CCE1; padding:25px; border-radius:5px;">
				<div class="col-md-2">
					<i class="fa fa-key fa-4x" style="text-align:left; color:white; text-shadow:2px 2px 0px #A3A9BB;"></i>
				</div>
				<div class="col-md-7">
					<b>Having trouble getting logged in?</b>
					<a href="#" class="row">Get help logging in and changing your password</a>
				</div>
			</div>
		  <div class="col-md-9 row" style="width:100%;">
			  <div class="col-md-3" style="width:250px; height:120px; background-color:#B8D696; color:#ffffff; padding:20px; border-radius:5px; margin:10px; text-align:center;">
				  <i class="fa fa-user-plus fa-5x" style="text-shadow:2px 2px 0px #8AA669;"></i>
			  </div>
			  <div class="col-md-3" style="width:250px; height:120px; background-color:#DECBAB; padding:20px; border-radius:5px; margin:10px; text-align:center;">
				  <span class="fa-stack fa-lg" style="position:absolute;">
					  <i class="fa fa-user fa-stack-1x fa-3x" style="padding-top:15px; color:#ECE1CE; text-shadow:2px 2px 0px #C9B490;"></i>
					  <i class="fa fa-ban fa-stack-1x fa-5x" style="padding-top:15px; color:#ffffff; text-shadow:2px 2px 0px #C9B490;"></i>
					</span>
			  </div>
			  <div class="col-md-3" style="width:250px; height:120px; background-color:#F4DE9E; color:#ffffff; padding:20px; border-radius:5px; margin:10px; text-align:center;">
				  <i class="fa fa-exclamation-triangle fa-5x" style=" text-shadow:2px 2px 0px #C2AE71;"></i>
			  </div>
		  </div>
			<div class="col-md-9 row" style="width:100%;">
			  <div class="col-md-3" style="width:200px; margin-left:10px;">Creating an Account </div>
			  <div class="col-md-3" style="width:200px; margin-left:60px;">Disabled Accounts   </div>
			  <div class="col-md-3" style="width:200px; margin-left:80px;">Report an Issue     </div>
		  </div>
			
		  <div class="col-md-8 row" style="margin-top:20px; width:100%;">
			  <div class="col-md-5" style="width:60%;">
				  <b>Top Questions</b><br />
				  <a href="#">How do I change my password?</a><br />
				  <a href="#">What names are allowed on Facebook?</a><br />
				  <a href="#">How do I sign up for Facebook?</a><br />
				  <a href="#">When I post something, how do I choose who can see it?</a>
			  </div>
			  <div class="col-md-3" style="width:40%;">
				  <b>More Help</b><br />
				  <a href="#">Privacy Basics</a><br />
				  <a href="#">Help Community</a>
			  </div>
		  </div>
		</div>--%>
        <div>
            <h2 class="help-question"><i class="fa fa-chevron-right icon-data"></i>
                <a href="#" style="margin-left:0px">How Can I Reset My Password?</a></h2>
            <div style="display:none;">Click this link and enter your email address. You will be sent a link to reset your password.<br />
                <i class="fa fa-minus-circle fa-lg" style="color:red; vertical-align:15%"></i>
                <input type="hidden" class="rating-tooltip-manual" data-filled="fa fa-star fa-2x custom-star"  data-empty="fa fa-star-o fa-2x" data-fractions="2"/>
            </div>
            <h2 class="help-question"><i class="fa fa-chevron-right icon-data"></i>
                <a href="#" style="margin-left:0px">My Account Has Been Locked</a></h2>
            <div style="display:none;">Accounts are locked because of inactivity. Click this link to reactivate your account.<br />
                <i class="fa fa-minus-circle fa-lg" style="color:red; vertical-align:15%"></i>
                <input type="hidden" class="rating-tooltip-manual" data-filled="fa fa-star fa-2x custom-star"  data-empty="fa fa-star-o fa-2x" data-fractions="2"/>
            </div>
            <h2 class="help-question"><i class="fa fa-chevron-right icon-data"></i>
                <a href="#" style="margin-left:0px">How Can I Delete My Account?</a></h2>
            <div style="display:none;">Click this link if you wish to delete your account<br />
                <i class="fa fa-minus-circle fa-lg" style="color:red; vertical-align:15%"></i>
                <input type="hidden" class="rating-tooltip-manual" data-filled="fa fa-star fa-2x custom-star"  data-empty="fa fa-star-o fa-2x" data-fractions="2"/>
            </div>
          </div>
	  </div>

	  <hr>
	</div> <!-- /container -->
	<footer class="footer">
	    <div class="container">
	        <p class="text-muted">Place sticky footer content here.</p>
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
      <script src="Plugins/bootstrap-rating.js"></script>
  </body>
</html>
