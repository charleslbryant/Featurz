<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Featurz.Web.Controls.Users.Edit" %>

<div class="alertMsg <%: Vm.MessageStyle.ToString().ToLower() %>">
	<%: Vm.Message %>
</div>
<div class="row">
	<div class="col-xs-12">
		<div class="box">
			<div class="box-body no-padding">
				<div class="box-body">
					<div id="Messages" runat="server"></div>
					<div class="form-group <%: Vm.EmailMessage.GroupError %>">
						<label class="control-label" for="UserEmail"><i class="fa <%: Vm.EmailMessage.Error %>"></i>Email<span><%: Vm.EmailMessage.Message %></span></label>
						<asp:TextBox CssClass="form-control" ID="UserEmail" runat="server" MaxLength="100"></asp:TextBox>
					</div>
					<div class="form-group <%: Vm.FirstNameMessage.GroupError %>">
						<label class="control-label" for="UserFirstName"><i class="fa <%: Vm.FirstNameMessage.Error %>"></i>First Name<span><%: Vm.FirstNameMessage.Message %></span></label>
						<asp:TextBox CssClass="form-control" ID="UserFirstName" runat="server" MaxLength="100"></asp:TextBox>
					</div>
					<div class="form-group <%: Vm.LastNameMessage.GroupError %>">
						<label class="control-label" for="UserLastName"><i class="fa <%: Vm.LastNameMessage.Error %>"></i>Last Name<span><%: Vm.LastNameMessage.Message %></span></label>
						<asp:TextBox CssClass="form-control" ID="UserLastName" runat="server" MaxLength="100"></asp:TextBox>
					</div>
					<div class="form-group">
						<label class="control-label" for="UserRoles"><i class="fa"></i>User Roles</label>
						<asp:CheckBoxList ID="UserRoles" runat="server" ClientIDMode="Static"></asp:CheckBoxList>
					</div>
					<div class="form-group">
						<label class="control-label" for="UserGroups"><i class="fa"></i>User Groups</label>
						<asp:CheckBoxList ID="UserGroups" runat="server" ClientIDMode="Static"></asp:CheckBoxList>
					</div>
					<div class="form-group">
						<label class="control-label" for="UserIsEnabled"><i class="fa"></i>Enabled</label>
						<asp:CheckBox CssClass="" ID="UserIsEnabled" runat="server" Checked="true" />
					</div>
					<div class="form-group">
						<div>
							Username:
							<asp:Label ID="Username" runat="server"></asp:Label>
						</div>
						<div>
							Date Added:
							<asp:Label ID="UserDateAdded" runat="server"></asp:Label>
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