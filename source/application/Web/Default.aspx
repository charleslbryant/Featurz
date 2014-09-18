<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Chrome.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Featurz.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Content Header (Page header) -->
	<section class="content-header">
		<h1><%= Page.Title %>
		</h1>
	</section>
	<!-- Main content -->
	<section class="content">
		<asp:Panel ID="PageControllers" runat="server" />
	</section>
	<!-- /.content -->
</asp:Content>