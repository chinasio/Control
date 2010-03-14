<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProductDetail.aspx.cs"
    Inherits="Maticsoft.Web.ProductDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品详细</title>
    <link href="images/css.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table cellspacing="0" cellpadding="1" width="100%" border="0">
                <tr>
                    <td width="30%" align="right" style="height: 25px">
                        &nbsp;</td>
                    <td width="*" align="left" style="height: 25px">
                        <asp:Label ID="lblName" runat="server" Text="Label" Font-Bold="True" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">
                        &nbsp;</td>
                    <td height="25" width="*" align="left">
                        <asp:Image ID="Image1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="30%" align="right" style="height: 25px">
                        商品编号：
                    </td>
                    <td width="*" align="left" style="height: 25px">
                       <asp:Label ID="lblProductId" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">
                        类别：
                    </td>
                    <td height="25" width="*" align="left">
                        <asp:Label ID="lblCategoryId" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">
                        商品描述：
                    </td>
                    <td height="25" width="*" align="left">
                        <asp:Label ID="lblDescn" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">
                        参考价格：
                    </td>
                    <td height="25" width="*" align="left">
                        <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label>元</td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">
                        会员价格：
                    </td>
                    <td height="25" width="*" align="left">
                        <asp:Label ID="lblvipprice" runat="server"></asp:Label>元</td>
                </tr>
                <tr>
                    <td height="25" width="30%" align="right">
                        是否是优惠商品：
                    </td>
                    <td height="25" width="*" align="left">
                        <asp:Label ID="Label1" runat="server"></asp:Label></td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
