<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Maticsoft.Web.Admin.PBrand.Add" %>

<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../Style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
   <div align="center">
            
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
												<td height="25" width="30%" align="right">
													父类别：
												</td>
												<td height="25" width="*" align=left>
                                                    &nbsp;<asp:DropDownList ID="DropCategory" runat="server" Width="200px">                                                      
                                                    </asp:DropDownList></td>
											</tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                子类编号：
                                            </td>
                                            <td width="*" align=left style="height: 25px">
                                                <asp:TextBox ID="txtBrandId" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrandId"
                                                    ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                名称：
                                            </td>
                                            <td height="25" width="*" align=left>
                                                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
												<td height="25" width="30%" align="right">
													描述：
												</td>
												<td height="25" width="*" align=left>
                                                    &nbsp;<asp:TextBox ID="txtDescn" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox></td>
											</tr>
											
                                    </table>
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
                                        <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button><font
                                            face="宋体">&nbsp;</font>
                                        <asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" ></asp:Button></div>
                                </td>
                            </tr>
                        </table>
                        <uc1:copyright ID="Copyright1" runat="server" />
                        <uc2:checkright ID="Checkright1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
