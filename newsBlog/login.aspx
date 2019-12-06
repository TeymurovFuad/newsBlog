<%@ Page Title="" Language="C#" MasterPageFile="~/structure.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="newsBlog.login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	
	<div class="limiter">
		<div class="container-login100" style="background-image: url('images/bg-01.jpg');">
			<div class="wrap-login100">
				<%--<form class="login100-form validate-form">--%>
					<span class="login100-form-logo">
						<i class="zmdi zmdi-landscape"></i>
					</span>

					<span class="login100-form-title p-b-34 p-t-27">
						Log in
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Enter username">
                        <asp:TextBox ID="userName" runat="server" class="input100"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xf207;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password">
                        <asp:TextBox ID="userPassword" runat="server"  class="input100 password"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xf191;"></span>
					</div>

					<div class="container-login100-form-btn">
                        <asp:Button ID="loginBtn" runat="server" Text="Login" class="login100-form-btn" OnClick="loginBtn_Click"/>&nbsp;&nbsp;&nbsp;
                        <input class="btn-show-pass" type="checkbox" name="password" id="checkbox"/>
                        <label for="checkbox" class="pswLabel"></label>
					</div>

					<div class="text-center p-t-90">
                        <span id="invalidPsw" class="txt1 btn-danger" runat="server"></span>
                        <br />
                        <asp:Button ID="forgotPassword" runat="server" Text="Forgot Password?" class="txt1"/>
					</div>
				<%--</form>--%>
			</div>
		</div>
	</div>
	<div id="dropDownSelect1">
</div>

</asp:Content>
