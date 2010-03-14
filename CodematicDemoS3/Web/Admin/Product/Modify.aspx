<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Maticsoft.Web.Admin.Product.Modify" %>

<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
   <div align="center">
           
            <table cellspacing="0" cellpadding="5" width="700" border="0">
                <tr>
                   <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                        <table cellspacing="0" bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                            bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'
                            cellpadding="5" width="100%" border="1">
                            <tr bgcolor="#e4e4e4">
                                <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' height="22" align="left">
                                    信息添加，请详细填写下列信息。</td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td height="25" width="20%" align="right">
                                                类别：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <asp:DropDownList ID="dropCategory" runat="server" Width="200px" 
                                                    >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr style="display:none">
                                            <td height="25" width="20%" align="right">
                                                品牌：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <asp:DropDownList ID="dropBrand" runat="server" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%" align="right" style="height: 25px">
                                                商品编号：
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                &nbsp;
                                                <asp:Label ID="lblProductId" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td width="20%" align="right" style="height: 25px">
                                                商品名：
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                                    ErrorMessage="不能为空！"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="20%" align="right">
                                                商品描述：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <ftb:FreeTextBox id="txtDescn" runat="server" Width="100%" height="350" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="20%" align="right">
                                                商品图片：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                                                    <tr>
                                                        <td width="400" height="100%" valign="middle">
                                                            <input id="FileUp" style="width: 253px; height: 22px" type="file" size="23" name="File1"
                                                                runat="server" onchange="checkData()">
                                                        </td>
                                                        <td>
                                                            <div id="previewImage">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="right">
                                                参考价格：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <asp:TextBox ID="txtPrice" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="right">
                                                会员价格：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <asp:TextBox ID="txtvipPrice" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="right">
                                                是否是优惠商品：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                &nbsp;<asp:RadioButton ID="radbtn_CheapNo" runat="server" Checked="True" Text="否"
                                                    GroupName="2" />
                                                <asp:RadioButton ID="radbtn_Cheap" runat="server" Text="是" GroupName="2" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>                            
                            <tr>
                                <td style="height: 22px">
                                    <div align="center">
                                        <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click"></asp:Button>
                                        <asp:Button ID="btnCancel" runat="server" Text="· 取消 ·"></asp:Button></div>
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
