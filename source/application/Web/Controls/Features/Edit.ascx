<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Featurz.Web.Controls.Features.Edit" %>

<div class="alertMsg <%: Vm.MessageStyle.ToString().ToLower() %>">
	<%: Vm.Message %>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="box">
			<div class="box-body no-padding">
				<div class="box-body">
					<div id="Messages" runat="server"></div>
					<div class="form-group <%: Vm.NameMessage.GroupError %>">
						<label class="control-label" for="FeatureName"><i class="fa <%: Vm.NameMessage.Error %>"></i>Name: <span><%: Vm.NameMessage.Message %></span></label>
						<asp:Label ID="FeatureName" runat="server"></asp:Label>
					</div>
					<div class="form-group <%: Vm.TicketMessage.GroupError %>">
						<label class="control-label" for="FeatureTicket"><i class="fa <%: Vm.TicketMessage.Error %>"></i>Ticket<span><%: Vm.TicketMessage.Message %></span></label>
						<asp:TextBox CssClass="form-control" ID="FeatureTicket" runat="server" MaxLength="50"></asp:TextBox>
					</div>
					<div class="form-group">
						<label class="control-label" for="FeatureOwner"><i class="fa"></i>Owner</label>
						<asp:DropDownList CssClass="form-control" ID="FeatureOwner" runat="server"></asp:DropDownList>
					</div>
					<div class="form-group">
						<label class="control-label" for="FeatureActive"><i class="fa"></i>Is Active</label>
						<asp:CheckBox CssClass="" ID="FeatureActive" runat="server" Checked="true" />
					</div>
					<div class="form-group">
						<label class="control-label" for="FeatureEnabled"><i class="fa"></i>Enabled</label>
						<asp:CheckBox CssClass="" ID="FeatureEnabled" runat="server" Checked="true" />
					</div>
					<div class="form-group">
						<div>
							Feature Id:
							<asp:Label ID="FeatureId" runat="server"></asp:Label>
						</div>
						<div>
							Date Added:
							<asp:Label ID="FeatureDateAdded" runat="server"></asp:Label>
						</div>
					</div>
					<div class="form-group">
						<asp:Button CssClass="btn btn-default" ID="Submit" runat="server" OnClick="SubmitForm" Text="Submit" />
						<asp:Button CssClass="btn btn-default" ID="Cancel" runat="server" OnClick="CancelForm" Text="Cancel" />
					</div>
				</div>
				<!-- /.box-body -->
			</div>
			<!-- /.box-body -->
		</div>
		<!-- /.box -->
	</div>
</div>