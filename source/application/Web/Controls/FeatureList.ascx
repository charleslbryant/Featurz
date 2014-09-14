<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeatureList.ascx.cs" Inherits="Featurz.Web.Controls.FeatureList" %>

<div class="alertMsg <%: Vm.MessageStyle.ToString().ToLower() %>">
	<%: Vm.Message %>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="box">
			<div class="box-header">
				<h3 class="box-title">Feature List</h3>
				<div class="box-tools">
					<div class="input-group">
						<input type="text" name="table_search" class="form-control input-sm pull-right" style="width: 150px;" placeholder="Search" />
						<asp:Button CssClass="btn btn-sm btn-primary pull-right" ID="AddFeature" runat="server" OnClick="GoAddFeature" Text="Add Feature" />
						<div class="input-group-btn">
							<button class="btn btn-sm btn-default" id="Search" runat="server" onclick=""><i class="fa fa-search"></i></button>
						</div>
					</div>
				</div>
			</div>
			<!-- /.box-header -->
			<div class="box-body table-responsive no-padding">
				<asp:GridView ID="FeatureGrid" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" GridLines="None" PagerSettings-Mode="Numeric" AllowCustomPaging="True" AllowPaging="True" AllowSorting="True" ShowFooter="True" PageSize="100">
					<Columns>
						<asp:TemplateField HeaderText="Name">
							<ItemTemplate>
								<a href="<%# Eval("Id") %>" target="_blank"><%# Eval("Name") %></a>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Ticket">
							<ItemTemplate>
								<a href="<%# Eval("TicketLink") %>" target="_blank"><%# Eval("Ticket") %></a>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Active">
							<ItemTemplate>
								<span class="label label-<%# Eval("ActiveClass") %>"><%# Eval("Active") %></span>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField DataField="Owner" HeaderText="Owner" />
						<asp:BoundField DataField="DateAdded" HeaderText="Date Added" ReadOnly="True" SortExpression="DateAdded" />
					</Columns>
					<RowStyle BorderStyle="None" />
				</asp:GridView>
			</div>
			<!-- /.box-body -->
		</div>
		<!-- /.box -->
	</div>
</div>