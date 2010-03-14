<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Show.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsClassManage.Show" %>

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
            <cc1:Navigation01 ID="Navigation011" runat="server" Key_Str="id" Page_Mode="Show"
                Page_Index="Index.aspx" Page_Add="add.aspx" Page_Modify="modify.aspx"></cc1:Navigation01>
            <table width="600" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
                bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                <tr>
                    <td>
                        <table width="100%" border="1" cellpadding="0" cellspacing="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
                            bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                            bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                            <tr align="left">
                                <td height="22" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>'
                                    align="left">
                                    详细信息，点击修改可以修改当前信息，点击删除可删除当前信息。</td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td align="right">
                                                编码：
                                            </td>
                                            <td align="left">
                                                &nbsp;<asp:Label ID="lblClassId" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                类别名：
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                                <asp:Label ID="lblClassDesc" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                类别图片：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                &nbsp;<asp:Label ID="lblClassPicture" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                父类：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                &nbsp;<asp:Label ID="lblParentId" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <uc1:CopyRight ID="CopyRight1" runat="server" />
        <uc2:checkright ID="Checkright1" runat="server"></uc2:checkright>
    </form>
</body>
</html>
