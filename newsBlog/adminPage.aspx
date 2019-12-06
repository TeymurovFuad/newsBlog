<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="newsBlog.adminPage" %>

<!DOCTYPE html>
<html>
<head>
<title>SpringTime</title>
<meta http-equiv="Content-type" content="text/html; charset=utf-8">
<link rel="stylesheet" href="adminPage/css/style.css" type="text/css" media="all" />
</head>
<body style="height: 386px">
    <form runat="server">
<!-- Header -->
<div id="header">
  <div class="shell">
    <!-- Logo + Top Nav -->
    <div id="top">
      <h1><a href="#">SpringTime</a></h1>
      <div id="top-navigation">
        <strong>Welcome Mudur</strong>
        <span>|</span>
        <a href="index.aspx">Log out</a></div>
    </div>
    <!-- End Logo + Top Nav -->
    <!-- Main Nav -->
    <!-- End Main Nav -->
  </div>
</div>
<!-- End Header -->
<!-- Container -->
<div id="container">
  <div class="shell">
    <!-- Small Nav -->
    
    <!-- End Small Nav -->
    <br>
    <!-- Main -->
    <div id="main">
      <div class="cl">&nbsp;</div>
      <!-- Content -->
      <div id="content">
        <!-- Box -->
        <div class="box hide" id="hide"  runat="server">
          <!-- Box Head -->
          <div class="box-head">
            <h2 class="left">Current Articles</h2>
            
          </div>
          <!-- End Box Head -->
          <!-- Table -->
          <div class="table">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <th>News Tittle</th>
                        <th>News Status</th>
                        <th>Admin ID</th>
                        <th width="110" class="ac">Content Control</th>
                    </tr>
                </thead>
                <tbody runat="server" id="existingNews">
                    
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="previous" runat="server" Text="Previous" class="button previous" OnClick="previous_Click"/>
                            <asp:Button ID="next" runat="server" Text="Next" class="button next" OnClick="next_Click"/>
                            <asp:Button ID="changeNews" runat="server" Text="Change" class="button next" OnClick="changeNews_Click"/>
                        </td>
                    </tr>
                </tfoot>
            </table>
            <!-- Pagging -->
            
            <!-- End Pagging -->
          </div>
          <!-- Table -->
        </div>
        <!-- End Box -->

          <!-- Box 2-->
        <div class="box hide" id="hide2"  runat="server">
          <!-- Box Head -->
          <div class="box-head">
            <h2 class="left">Users</h2>
            
          </div>
          <!-- End Box Head -->
          <!-- Table -->
          <div class="table">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <th>User ID</th>
                        <th>User Password</th>
                        <th>User Status</th>
                        <th width="110" class="ac">User Control</th>
                    </tr>
                </thead>
                <tbody runat="server" id="existingUsers">
                    
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="submitUserChange" runat="server" Text="Submit" class="button next" OnClick="submitUserChange_Click"/>

                        </td>
                    </tr>
                </tfoot>
            </table>
            <!-- Pagging -->
            
            <!-- End Pagging -->
          </div>
          <!-- Table -->
        </div>
        <!-- End Box 2 -->

        <!-- Box -->
        <div class="box">
          <!-- Box Head -->
          <div class="box-head">
            <h2>Add New Article</h2>
            <asp:Button ID="reset" class="button reset" runat="server" Text="Reset" OnClick="reset_Click"/>
          </div>
          <!-- End Box Head -->
            <!-- Form -->
            <div class="form">
                <p id="hideNewsID" runat="server">
                    <label>Content ID</label>
                    <asp:TextBox ID="newsID"  style="resize:none" class="field size1" runat="server" MaxLength="15" ReadOnly="true"></asp:TextBox>
                </p>

                <p>
                    <span class="req">max 200 symbols</span>
                    <label>Article Title <span>(Required Field)</span></label>
                    <asp:TextBox ID="contentTittle"  style="resize:none" class="field size1" runat="server" Columns="30" MaxLength="200" Rows="2" Width="714px"></asp:TextBox>
                </p>

                <p>
                    <span class="req">max 4000 symbols</span>
                    <label>Content <span>(Required Field)</span></label> 
                    <asp:TextBox ID="contentBody" TextMode="multiline" style="resize:none" class="field size1" runat="server" Columns="30" MaxLength="4000" Rows="10" Height="101px" Width="715px"></asp:TextBox>
                </p>
            </div>
            <!-- End Form -->
            <!-- Form Buttons -->
            <div class="buttons">
                <asp:DropDownList class="button dropDown" ID="categorySelection" runat="server" >
                        <asp:ListItem Text="Category" value=""/>
                </asp:DropDownList>
                <asp:FileUpload ID="uploadImg" runat="server" class="button"/>
                <asp:TextBox ID="imgName" runat="server" class="field"></asp:TextBox>
                <asp:Button ID="SubmitContent" class="button" runat="server" Text="Submit" OnClick="SubmitContent_Click" />
            </div>
            <!-- End Form Buttons -->
        </div>
        <!-- End Box -->
      </div>
      <!-- End Content -->
      <!-- Sidebar -->
      <div id="sidebar">
        <!-- Box -->
        <div class="box" id="categoryBox" runat="server">
            <!-- Box Head -->
            <div class="box-head">
                <h2>Add New Category</h2>
            </div>
            <!-- End Box Head-->
            <div class="box-content">
                <div class="cl">&nbsp;</div>
                <!-- Sort -->
                <label>New Category Name</label>
                <asp:TextBox ID="newCategory" runat="server" class="field" OnClick="newCategory_Click"></asp:TextBox>
                <!-- End Sort -->
                <asp:Button ID="submitNewCategory" runat="server" Text="Submit" class="add-button" OnClick="submitNewCategory_Click"/>
            </div>
        </div>
        <!-- End Box -->

          <!-- Box 2-->
        <div class="box" id="passwordBox" runat="server">
            <!-- Box Head -->
            <div class="box-head">
                <h2>Password Coder</h2>
            </div>
            <!-- End Box Head-->
            <div class="box-content">
                <div class="cl">&nbsp;</div>
                <!-- Sort -->
                <label>User ID</label>
                <asp:TextBox ID="userLoginName" runat="server" class="field"></asp:TextBox>
                <label>Old Password</label>
                <asp:TextBox ID="oldPasswordHolder" runat="server" class="field"></asp:TextBox>
                <label>New Password</label>
                <asp:TextBox ID="newPasswordHolder" runat="server" class="field"></asp:TextBox>
                <!-- End Sort -->
                <asp:Button ID="changePassword" runat="server" Text="Code Password" class="add-button" OnClick="changePassword_Click"/>
                <asp:Button ID="addNewPassword" runat="server" Text="Add Changed Password" class="add-button" OnClick="addNewPassword_Click"/>
                <asp:Button ID="reset2" runat="server" Text="Reset" class="button btn" OnClick="reset2_Click"/>
            </div>
        </div>
        <!-- End Box 2-->

      </div>
      <!-- End Sidebar -->
      <div class="cl">&nbsp;</div>
    </div>
    <!-- Main -->
  </div>
</div>
<!-- End Container -->

</form>
</body>
</html>

