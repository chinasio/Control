<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsClassManage.Search" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>

<%@ Register Src="~/Controls/copyright.ascx" TagName="CopyRight" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../Style.css" type="text/css" rel="stylesheet">
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
			<table width="600" border="0" align="center" cellpadding="5" cellspacing="0">
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
                                            <td height="25" width="30%" align="right">
                                                编码：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <asp:TextBox ID="txtClassid" runat="server" Width="200px"></asp:TextBox></td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                类别名：
                                            </td>
                                            <td width="*" align=left style="height: 25px">
                                                <asp:TextBox ID="txtClassDesc" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>                                       
                                       <tr>
												<td height="25" width="30%" align="right">
													父类：
												</td>
												<td height="25" width="*" align=left>
													<asp:DropDownList id="dropParent" runat="server" Width="200px"></asp:DropDownList>
												</td>
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
        <uc2:checkright id="Checkright1" runat="server">
        </uc2:checkright>
    </form>
</body>
</html>
