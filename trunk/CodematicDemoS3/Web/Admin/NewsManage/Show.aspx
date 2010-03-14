<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsManage.Show" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>

<%@ Register Src="~/Controls/copyright.ascx" TagName="CopyRight" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="LtpPageControl" Assembly="LtpPageControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../Style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <cc1:Navigation01 ID="Navigation011" runat="server" Key_Str="Id" Page_Mode="Show"
                Page_Index="Index.aspx" Page_Add="add.aspx" Page_Modify="modify.aspx"></cc1:Navigation01>
                
            <table width="600" border="0" align="center" cellpadding="5" cellspacing="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
            bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                <tr>
                    <td >
                        <table width="100%" border="0" cellpadding="5" cellspacing="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
            bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                            <tr  align="left">
                                <td height="22" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' align="left">
                                    详细信息，点击修改可以修改当前信息，点击删除可删除当前信息</td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
												<td width="150" height="16" align="right">
													编号：
												</td>
												<td height="16" width="*" align="left">
													&nbsp;<asp:Label id="lblNewsId" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
													标题：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblHeading" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
													关键字：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblFocus" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
													点击率：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblFrequency" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
													状态：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblDormancy" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
                                                    是否滚动新闻：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblistop" runat="server"></asp:Label>
													
													</td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
													发布时间：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblIssueDate" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
													所属类别：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblClass" runat="server"></asp:Label></td>
											</tr>
                                       
                                    </table>
                                </td>
                            </tr>
                            <tr>
                            <td align=left>
                            <asp:Label id="lblContent" runat="server" Width="100%"></asp:Label>
                            </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <uc1:CopyRight ID="CopyRight1" runat="server" />
        &nbsp;&nbsp;
        <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>

