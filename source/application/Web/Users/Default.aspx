<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Chrome.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Featurz.Web.Users._Default" %>

<%@ Register Src="~/Controls/Userss/List.ascx" TagName="UserList" TagPrefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Content Header (Page header) -->
	<section class="content-header">
		<h1>Users</h1>
	</section>
	<!-- Main content -->
	<section class="content">
		<uc1:UserList ID="UserList1" runat="server" />
	</section>
	<!-- /.content -->
</asp:Content>