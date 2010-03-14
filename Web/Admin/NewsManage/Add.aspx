<%@ Page Language="C#"  ValidateRequest=false AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsManage.Add" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
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
            <cc1:Navigation01 ID="Navigation011" runat="server" Table_Name="Form1" Key_Str="id"
                Page_Modify="modify.aspx" Page_Index="Index.aspx" Page_Add="add.aspx"></cc1:Navigation01>
                
            <table cellspacing="0" cellpadding="5" width="600" border="0" >
                <tr>
                    <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                        <table cellspacing="0" cellpadding="5" width="100%" border="1" bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                            bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                            <tr bgcolor="#e4e4e4">
                                <td  height="22" align="left" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>'>
                                    信息添加，请详细填写下列信息，带有 <font>*</font> 的必须填写。</td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>'>
                                        <tr>
                                            <td align="right">
                                                类别：</td>
                                            <td height="14" width="*" style="height: 14px; text-align: left;">
                                                <asp:DropDownList ID="dropNewsClass" runat="server" Width="200px">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                标题：
                                            </td>
                                            <td height="25" width="*" style="text-align: left">
                                                <asp:TextBox ID="txtHeading" runat="server" Width="200px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 24px">
                                                关键字：</td>
                                            <td style="text-align: left; height: 24px;">
                                                <asp:TextBox ID="txtFocus" runat="server" Width="400px" MaxLength="50" BorderStyle="Groove"></asp:TextBox></td>
                                        </tr>                                      
                                        <tr>
                                            <td align="right">
                                                是否发布：</td>
                                            <td height="22" style="text-align: left">
                                                <asp:CheckBox ID="chkDormancy" runat="server" Text="发布" Checked="True"></asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                是否发布到首页：</td>
                                            <td height="22" style="text-align: left">
                                                <asp:CheckBox ID="chkIsTop" runat="server" Text="是滚动新闻" Checked="True"></asp:CheckBox></td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                            <tr>
									<td height="22"  align="center">
										<FTB:FreeTextBox id="FreeTextBox1" runat="server" Width="700" height="350" ButtonPath="images/ftb/office2003/" />
									</td>
								</tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td width="150" height="22">
                                                &nbsp;</td>
                                            <td height="22" align="left">
                                                <asp:CheckBox ID="chkAddContinue" runat="server" Text="连续添加"></asp:CheckBox>&nbsp;[
                                                添加成功后直接跳回此页进行再次添加 ]
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <div align="center">
                                        <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click"></asp:Button><font
                                            face="宋体">&nbsp;</font>
                                        <asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click"></asp:Button></div>
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
