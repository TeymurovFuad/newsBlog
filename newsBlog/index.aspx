<%@ Page Title="" Language="C#" MasterPageFile="~/structure.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="newsBlog.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="wrapper col4">
  <div id="container">
    <div id="content">
      <div id="featured_post"><img id="mainImg" runat="server" src="HTML/images/demo/620x270.gif" alt="" />
        <p>This is a W3C standards compliant free website template from <a href="HTML/http://www.os-templates.com/">OS Templates</a>.</p>
        <p>This template is distributed using a <a href="HTML/http://www.os-templates.com/template-terms">Website Template Licence</a>, which allows you to use and modify the template for both personal and commercial use when you keep the provided credit links in the footer. For more CSS templates visit <a href="HTML/http://www.os-templates.com/">Free Website Templates</a>.</p>
      </div>
    </div>
    <div id="column">
      <ol id="latestnews" runat="server" class="ol">
        
      </ol>
    </div>
    <br class="clear" />
  </div>
  <br class="clear" />
</div>
</asp:Content>
