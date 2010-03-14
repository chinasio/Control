<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Codebehind="Default.aspx.cs"
    Inherits="Maticsoft.Web.Default" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="549" border="0">
        <tbody>
            <tr>
                <td valign="bottom" width="549" height="40">
                    <img height="25" src="images/cpzs1.gif" width="549"></td>
            </tr>
            <tr>
                <td valign="center" height="160">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td align="middle" width="27%">
                                    <!-- 滚动图片控制-->
                                    <marquee scrollamount='2' scrolldelay='2' direction='left' width="96%" id="xiaoqing"
                                        onmouseover="xiaoqing.stop()" onmouseout="xiaoqing.start()">
                                        <TABLE style="BORDER-COLLAPSE: collapse; HEIGHT: 100%" id="uctrlNotification_lstMain" cellSpacing=0 cellPadding=2 border=0>
                                        
                                        <TR>
                                        <TD vAlign=middle noWrap>
                                        <!-- 滚动图片路径-->
                                        <A href="cpzs.aspx" title="Maticsoft" >
                                        <%=strImglist%>
                                          </A>
                                          </TD>
                                          </TR>
                                          </TABLE></marquee>
                                    <!--滚动图片控制end-->
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table cellspacing="0" cellpadding="0" width="530" border="0">
                        <tbody>
                            <tr>
                                <td align="right">
                                    <a href="cpzs.aspx">
                                        <img height="9" src="images/more.gif" width="38" border="0"></a></td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <table cellspacing="0" cellpadding="0" width="549" border="0">
        <tbody>
            <tr>
                <td width="549">
                    <img height="28" src="images/shouye_r1_c2.gif" width="559"></td>
            </tr>
            <tr>
                <td height="6">
                </td>
            </tr>
            <tr>
                <td valign="top" background="images/shouye_r4_c2.gif" height="120">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr align="middle">
                                <td valign="top" width="51%">
                                    <!--新闻-->
                                    <asp:DataList ID="DataList1" runat="server" Width="87%">
                                        <ItemTemplate>
                                            <tr>
                                                <td height="25">
                                                    <a class="0" href="news.aspx?id=<%# Eval("NewsId").ToString() %>" target="_blank">
                                                        <%# FormatString(Eval("Heading").ToString())%>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td background="images/shouye_r8_c4.gif" height="1">
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <div style="text-align: right; width: 87%">
                                        <a href="GSXW.aspx">
                                            <img height="9" src="images/more.gif" width="38" border="0"></a>
                                    </div>
                                </td>
                                <td valign="top" width="49%">
                                    <!--产品-->
                                    <asp:DataList ID="DataList2" runat="server" Width="87%">
                                        <ItemTemplate>
                                            <tr>
                                                <td height="25">
                                                    <a class="0" href="ProductDetail.aspx?productID=<%# Eval("ProductID").ToString() %>" title="产品信息" rel="gb_page_center[700, 530]">
                                                        <%# FormatString(Eval("Name").ToString())%>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td background="images/shouye_r8_c4.gif" height="1">
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <div style="text-align: right; width: 87%">
                                        <a href="cpzs.aspx">
                                            <img height="9" src="images/more.gif" width="38" border="0"></a>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
