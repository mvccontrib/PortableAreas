<%@ Page Title="" Language="C#" MasterPageFile="LoginPortableArea.Master" Inherits="System.Web.Mvc.ViewPage<string>" %>
<%@ Import Namespace="MvcContrib.UI.InputBuilder.Views"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Password Sent</h2>
    <%=Model%>
</asp:Content>
