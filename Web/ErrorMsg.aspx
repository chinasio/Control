<%@ Page language="c#" Codebehind="ErrorMsg.aspx.cs" AutoEventWireup="True" Inherits="Maticsoft.Web.ErrorMsg" %>
<%@ Register TagPrefix="uc1" TagName="CopyRight" Src="Controls/CopyRight.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ErrorMsg</title>
		
		
		
		
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<table width="600" border="0" align="center" cellpadding="5" cellspacing="0">
					<tr>
						<td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
							<table width="100%" border="1" cellpadding="5" cellspacing="0" 
							
							bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
							bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'>
							
								<tr bgcolor="#e4e4e4">
									<td height="22" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>'><STRONG><FONT color="red">发生问题：</FONT></STRONG></td>
								</tr>
								<tr>
									<td height="22">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td height="22">
													<asp:Label id="lblMsg" runat="server" Width="100%"></asp:Label>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td height="22">
										<div align="center"><input type="button" value="返 回" style="WIDTH: 120px" onclick="javascript:history.back();"></div>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
			<uc1:CopyRight id="CopyRight1" runat="server"></uc1:CopyRight>
		</form>
	</body>
</HTML>
