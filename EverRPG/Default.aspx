<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EverRPG.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* --------------------------
base styles 
-------------------------- */

body
{
	margin: 0;
	padding: 0;
	color: #000;
	background: #fff;
	font: 1em/1.2 helvetica, arial, sans-serif;
}

h1
{
	margin: 0;
	font-size: 1.5em;
	font-weight: 500;
}

h2,h3
{
	margin: 0 0 1em;
	font-size: 1.3em;
	font-weight: 500;
}

p
{
	margin: 0 0 1.5em;
	line-height: 1.5;
}

/* --------------------------
layout 
-------------------------- */

.header
{
	background-color: #ccc;
	padding: 1em;
}

.nav-bar
{
	color: #fff;
	background-color: #000;
}

.content { padding: 1em; }
.col1 { margin-bottom: 1em; }
.col2 { margin-bottom: 1em; }
.col3 { margin-bottom: 1em; }

.footer
{
	clear: both;
	padding: 1em;
	background-color: #ccc;
}

/* --------------------------
nav 
-------------------------- */

.nav
{
	margin: 0;
	padding: 0;
	list-style: none;
}

.nav li
{
	display: inline;
	margin: 0;
}

.nav a
{
	display: block;
	padding: .7em 1.25em;
	color: #fff;
	text-decoration: none;
	border-bottom: 1px solid gray;
}

.nav a:link { color: white; }
.nav a:visited { color: white; }

.nav a:focus
{
	color: black;
	background-color: white;
}

.nav a:hover
{
	color: white;
	background-color: green;
}

.nav a:active
{
	color: white;
	background-color: red;
}

/* --------------------------
wide screen 
-------------------------- */

@media (min-width:800px)
{
	.header { padding: 1em 3%; }
	.nav-bar { padding: 1em 3%; }
	
	.nav li
	{
		display: inline;
		margin: 0 1em 0 0;
	}
	
	.nav a
	{
		display: inline;
		padding: 0;
		border-bottom: 0;
	}
	
	.content
	{
		overflow: hidden;
		padding: 2em 0 1em;
	}
	
	.col1,.col2,.col3
	{
		float: left;
		margin-bottom: 1em;
		margin-left: 3%;
	}
	
	.col1 { width: 48%; }
	.col2 { width: 20%; }
	.col3 { width: 20%; }
	.footer { padding: 1em 3%; }
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <body>
		<div class="sample5">
			<div class="header">
				<h1><asp:Label ID="lblHeader" runat="server"></asp:Label></h1>
			</div>
			<div class="nav-bar">
				<ul class="nav">
					<li><a href="#"><asp:Label ID="lblNav1" runat="server"></asp:Label></a></li>
					<li><a href="#"><asp:Label ID="lblNav2" runat="server"></asp:Label></a></li>
					<li><a href="#"><asp:Label ID="lblNav3" runat="server"></asp:Label></a></li>
				</ul>
			</div>
			<div class="content">
                
				<div class="col1">
					<h2><asp:Label ID="lblMainHeader" runat="server"></asp:Label></h2>
					<asp:Label ID="lblMain" runat="server"></asp:Label>
				</div>
				<div class="col2">
					<h3><asp:Label ID="lblMenu1Header" runat="server"></asp:Label></h3>
					<asp:Label ID="lvlMenu1" runat="server"></asp:Label>
				</div>
				<div class="col3">
					<h3><asp:Label ID="lblMenu2Header" runat="server"></asp:Label></h3>
					<asp:Label ID="lblMenu2" runat="server"></asp:Label>
				</div>
			</div>
			<div class="footer">
				<asp:Label ID="lblFooter" runat="server"></asp:Label>
			</div>
		</div>
	</body>
    </form>
</body>
</html>
