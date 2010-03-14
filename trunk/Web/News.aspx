<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Maticsoft.Web.News" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align:center">
<table cellpadding=0 cellspacing=0 border=0 width="80%">
<tr>
<td align="center"><%=strHeading %></td>
</tr>
<tr>
<td align="center"><%=strDate %></td>
</tr>
<tr>
<td><%=strContent%></td>
</tr>
</table></div>
</asp:Content>
