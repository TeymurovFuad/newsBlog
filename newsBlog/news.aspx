<%@ Page Title="" Language="C#" MasterPageFile="~/structure.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="newsBlog.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper col5">
  <div class="gallery">
    <h2>Latest Gallery Pics</h2>
      <asp:DropDownList class="btn btn-outline-light select2-search--dropdown" ID="categories" runat="server" OnSelectedIndexChanged="categories_SelectedIndexChanged">
          <asp:ListItem Text="Select category"/>
      </asp:DropDownList>
    <ul runat="server" id="newsImgCont">
      <%--<li>
          <span class="topLeft">25</span>
          <a href="index.aspx">
            <img src="HTML/images/demo/174x174.gif" alt=""/></a>
          <span class="bottomRight">25.07.1993</span>
        </li>--%>
    </ul>
    <br class="clear" />
  </div>
</div>
</asp:Content>
