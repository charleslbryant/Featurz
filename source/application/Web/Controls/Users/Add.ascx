<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="Featurz.Web.Controls.Users.Add" %>

<div class="alertMsg <%: Vm.MessageStyle.ToString().ToLower() %>">
	<%: Vm.Message %>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="box">
			<div class="box-body no-padding">
				<div class="box-body">
					<div id="Messages" runat="server"></div>
					<div class="form-group <%: Vm.NameGroupError %>">
						<label class="control-label" for="UserName"><i class="fa <%: Vm.NameError %>"></i>Name<span><%: Vm.NameMessage %></span></label>
						<asp:TextBox CssClass="form-control" ID="UserName" runat="server" MaxLength="100"></asp:TextBox>
					</div>
					<div class="form-group <%: Vm.TicketGroupError %>">
						<label class="control-label" for="UserTicket"><i class="fa <%: Vm.TicketError %>"></i>Ticket<span><%: Vm.TicketMessage %></span></label>
						<asp:TextBox CssClass="form-control" ID="UserTicket" runat="server" MaxLength="50"></asp:TextBox>
					</div>
					<div class="form-group">
						<label class="control-label" for="UserOwner"><i class="fa"></i>Owner</label>
						<asp:DropDownList CssClass="form-control" ID="UserOwner" runat="server" ClientIDMode="Static"></asp:DropDownList>
					</div>
					<div class="form-group">
						<label class="control-label" for="UserActive"><i class="fa"></i>Is Active</label>
						<asp:CheckBox CssClass="" ID="UserActive" runat="server" Checked="true" />
					</div>
					<div class="form-group">
						<label class="control-label" for="UserEnabled"><i class="fa"></i>Enabled</label>
						<asp:CheckBox CssClass="" ID="UserEnabled" runat="server" Checked="true" />
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