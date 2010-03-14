<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsManage.Search" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Assembly="MyCalendar" Namespace="OwnDefineControl" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/copyright.ascx" TagName="CopyRight" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../Style.css" type="text/css" rel="stylesheet">
    <link href="../../js/calendar.js" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td height="22">
						<div align="right">[ <a href="index.aspx">返回</a> ]
						</div>
					</td>
				</tr>
			</table>
			<table width="600" border="0" align="center" cellpadding="5" cellspacing="0" >
				<tr>
					<td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
						<table width="100%" border="1" cellpadding="5" cellspacing="0" 
						bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                             bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
							<tr  bgcolor="#e4e4e4">
								<td height="22" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' align="left">信息检索，您可以有选择的选取相应条件进行检索，不填写表示不加以限制</td>
							</tr>
							<tr>
								<td height="22"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
												<td width="150" height="22">
													<div align="right">编号：</div>
												</td>
												<td height="22">
													<asp:TextBox id="txtNewsId" runat="server" Width="210px" BorderStyle="Groove"></asp:TextBox></td>
											</tr>
											<tr>
												<td width="150" height="22">
													<div align="right">标题关键字：</div>
												</td>
												<td height="22">
													<asp:TextBox id="txtHeading" runat="server" Width="210px" BorderStyle="Groove"></asp:TextBox></td>
											</tr>
											<tr>
												<td width="150" height="22">
													<div align="right">内容关键字：</div>
												</td>
												<td height="22">
													<asp:TextBox id="txtFocus" runat="server" Width="210px" BorderStyle="Groove"></asp:TextBox></td>
											</tr>
											<tr>
												<td width="150" style="height: 22px">
													<div align="right">发布时间：</div>
												</td>
												<td style="height: 22px">
                                                    <cc1:mycalendar id="StartRegTime" runat="server" width="93px" ReadOnly="True"></cc1:mycalendar>
                                                    &nbsp;<A href="javascript:show_calendar('Form1.txtIssueDate1');"></A>
													&nbsp;至
                                                    <cc1:MyCalendar ID="EndRegTime" runat="server" Width="93px" ReadOnly="True"></cc1:MyCalendar>&nbsp;<A href="javascript:show_calendar('Form1.txtIssueDate2');"></A>
													&nbsp;之间</td>
											</tr>
											<tr>
												<td width="150" height="22">
													<div align="right">点击率：</div>
												</td>
												<td height="22">
													<asp:TextBox id="txtFrequency1" runat="server" Width="83px" MaxLength="4" BorderStyle="Groove"></asp:TextBox><FONT face="宋体">&nbsp;至
														<asp:TextBox id="txtFrequency2" runat="server" Width="90px" MaxLength="2" BorderStyle="Groove"></asp:TextBox>&nbsp;之间</FONT></td>
											</tr>
											<tr>
												<td width="150" height="16" style="HEIGHT: 16px">
													<div align="right">
														状态：</div>
												</td>
												<td height="16" style="HEIGHT: 16px">
													<asp:DropDownList id="dropDormancy" runat="server" Width="200px">
														<asp:ListItem Value="0">--全部--</asp:ListItem>
														<asp:ListItem Value="true">发布</asp:ListItem>
														<asp:ListItem Value="false">休眠</asp:ListItem>
													</asp:DropDownList></td>
											</tr>
											<tr>
												<td width="150" height="22">
													<div align="right">类别：</div>
												</td>
												<td height="22">
													<asp:DropDownList id="dropNewsClass" runat="server" Width="200px"></asp:DropDownList></td>
											</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="22">
									<div align="center">&nbsp;
										<asp:button id="btnSearch" runat="server" Text="· 查询 ·" OnClick="btnSearch_Click"></asp:button>&nbsp;
										<asp:button id="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click"></asp:button>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
    </div>
        <uc1:CopyRight ID="CopyRight1" runat="server" />
        &nbsp;
    </form>
</body>
</html>
