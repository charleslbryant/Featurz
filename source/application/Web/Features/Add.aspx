<%@ Page Language="C#" MasterPageFile="~/Chrome.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Featurz.Web.Features.Add" %>

<%@ Register Src="~/Controls/FeatureAdd.ascx" TagName="FeatureAdd" TagPrefix="uc1" %>


<asp:Content ID="PageStyles" ContentPlaceHolderID="PageStyles" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Content Header (Page header) -->
	<section class="content-header">
		<h1>
			Add Feature
		</h1>
	</section>
		<!-- Main content -->
		<section class="content">
			<uc1:FeatureAdd ID="FeatureAdd" runat="server" />
		</section>
		<!-- /.content -->
</asp:Content>

<asp:Content ID="PageScripts" ContentPlaceHolderID="PageScripts" runat="server">
</asp:Content>

