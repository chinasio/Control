<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.Admin.Product.Show" %>

<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div  style="text-align:center">
            
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
                                            <td width="30%" align="right" style="height: 25px">
                                                商品编号：
                                            </td>
                                            <td width="*" align=left style="height: 25px">
                                                &nbsp;<asp:Label ID="lblProductId" runat="server" Text="Label"></asp:Label></td>
                                        </tr>
                                        <tr>
												<td height="25" width="30%" align="right">
													类别：
												</td>
												<td height="25" width="*" align=left>
                                                    <asp:Label ID="lblCategoryId" runat="server" Text="Label"></asp:Label></td>
											</tr>
                                        
											 
                                      
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                商品名：
                                            </td>
                                            <td width="*" align=left style="height: 25px">
                                                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                商品描述：
                                            </td>
                                            <td height="25" width="*" align=left>
                                                <asp:Label ID="lblDescn" runat="server" Text="Label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                商品图片：
                                            </td>
                                            <td height="25" width="*" align=left>
                                                <asp:Label ID="lblImage" runat="server" Text="Label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                参考价格：
                                            </td>
                                            <td height="25" width="*" align=left>
                                                <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                会员价格：
                                            </td>
                                            <td height="25" width="*" align=left>
                                                <asp:Label ID="lblvipprice" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                               是否是优惠商品：
                                            </td>
                                            <td height="25" width="*" align=left>
                                                <asp:Label ID="Label1" runat="server"></asp:Label></td>
                                        </tr>
                                       
                                    </table>
                                </td>
                            </tr>
                           
                            <tr>
                                <td height="22">
                                    <div align="center">
                                        <font
                                            face="宋体">&nbsp;</font><uc1:copyright ID="Copyright1" runat="server" />
                                        <uc2:checkright ID="Checkright1" runat="server" />
                                        </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
