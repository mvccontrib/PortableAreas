<%@ Page Title="" Language="C#" MasterPageFile="LoginPortableArea.Master" Inherits="System.Web.Mvc.ViewPage<LoginInput>" %>
<%@ Import Namespace="LoginPortableArea.Models"%>
<%@ Import Namespace="MvcContrib.UI.InputBuilder.Views"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
    <%=Html.InputForm() %>
    <span class="forgot-password-link"><a href="<%=Url.Action("ForgotPassword") %>">Forgot Password</a></span>
</asp:Content>
