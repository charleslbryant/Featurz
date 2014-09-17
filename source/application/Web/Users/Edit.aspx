<%@ Page Language="C#" MasterPageFile="~/Chrome.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Featurz.Web.Users.Edit" %>

<%@ Register Src="~/Controls/Users/Edit.ascx" TagName="UserEdit" TagPrefix="uc1" %>

<asp:Content ID="PageStyles" ContentPlaceHolderID="PageStyles" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Content Header (Page header) -->
	<section class="content-header">
		<h1>Edit User
		</h1>
	</section>
	<!-- Main content -->
	<section class="content">
		<uc1:UserEdit ID="UserEdit" runat="server" />
	</section>
	<!-- /.content -->
</asp:Content>

<asp:Content ID="PageScripts" ContentPlaceHolderID="PageScripts" runat="server">
</asp:Content>