<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Chrome.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Featurz.Web._Default" %>

<%@ Register Src="~/Controls/Features/List.ascx" TagName="FeatureList" TagPrefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Content Header (Page header) -->
	<section class="content-header">
		<h1>Dashboard
		</h1>
	</section>
	<!-- Main content -->
	<section class="content">
		<uc1:FeatureList ID="FeatureList1" runat="server" />
	</section>
	<!-- /.content -->
</asp:Content>