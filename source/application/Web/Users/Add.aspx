<%@ Page Language="C#" MasterPageFile="~/Chrome.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Featurz.Web.Userss.Add" %>

<%@ Register Src="~/Controls/Userss/Add.ascx" TagName="UserAdd" TagPrefix="uc1" %>

<asp:Content ID="PageStyles" ContentPlaceHolderID="PageStyles" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Content Header (Page header) -->
	<section class="content-header">
		<h1>Add User
		</h1>
	</section>
	<!-- Main content -->
	<section class="content">
		<uc1:UserAdd ID="UserAdd" runat="server" />
	</section>
	<!-- /.content -->
</asp:Content>

<asp:Content ID="PageScripts" ContentPlaceHolderID="PageScripts" runat="server">
</asp:Content>