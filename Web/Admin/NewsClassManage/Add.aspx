<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsClassManage.Add" %>

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
            <cc1:Navigation01 ID="Navigation011" runat="server" Table_Name="Form1" Key_Str="id" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
                Page_Modify="modify.aspx" Page_Index="Index.aspx" Page_Add="add.aspx" ></cc1:Navigation01>
            <table cellspacing="0" cellpadding="5" width="600" border="0">
                <tr>
                    <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                        <table cellspacing="0" bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                        bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' cellpadding="5" width="100%" border="1">
                            <tr bgcolor="#e4e4e4">
                                <td  height="22" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' align="left">
                                    信息添加，请详细填写下列信息，带有 <font class="form_requestcolor">*</font> 的必须填写。</td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                       
                                        <tr>
                                            <td width="30%" align="right" style="height: 26px">
                                                类别名：
                                            </td>
                                            <td width="*" align=left style="height: 26px">
                                                <asp:TextBox ID="txtClassDesc" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClassDesc"
                                                    ErrorMessage="不能为空！"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                类别图片：
                                            </td>
                                            <td width="*" align=left style="height: 25px">
                                                <asp:TextBox ID="txtClassPicture" runat="server" Width="200px"></asp:TextBox>
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
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td width="150" style="height: 22px">
                                                &nbsp;</td>
                                            <td align="left" style="height: 22px">
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
        <uc2:checkright id="Checkright1" runat="server">
        </uc2:checkright>
    </form>
</body>
</html>