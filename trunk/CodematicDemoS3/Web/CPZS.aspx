<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CPZS.aspx.cs" Inherits="Maticsoft.Web.CPZS" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellspacing="0" cellpadding="0" width="549" border="0">
        
            <tr>
                <td width="549">
                    <img height="28" src="images/cpzs.gif" width="559"></td>
            </tr>
            </table>
<form runat="server" id="form2">
    <div style="text-align: center"> 
    <table cellspacing="0" cellpadding="5" width="85%" border="0">                
                
                <tr>
                    <td >
    <!--普通产品展示-->
                    <asp:DataList ID="MyList" RepeatColumns="3" runat="server" Width="100%" BorderWidth="0px"
                        CellPadding="0">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td align="center" valign="middle">
                                        <a href='ProductDetail.aspx?productID=<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'
                                            title="产品信息" rel="gb_page_center[700, 530]">
                                            <img width="150" height="150" border="0" src='ProductImages/<%# DataBinder.Eval(Container.DataItem, "Image") %>'>
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="175" height="32" background="images/0079.GIF" align="center" valign="middle">
                                        <a href='ProductDetails.aspx?productID=<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'
                                            target="_blank"><span class="c001">
                                                <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                            </span></a>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    </td>
                </tr>
            </table>  
            <!--分页导航-->
        <table width="85%" height="28" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" valign="middle" class="c001">
                    ○ 页次：<asp:Label ID="lblCurrentPage" runat="server" ForeColor="#E78A29"></asp:Label>/
                    <asp:Label ID="lblpagesum" runat="server"></asp:Label>， 共：<font color="#e78a29"><asp:Label
                        ID="lblrowscount" runat="server"></asp:Label></font>条
                </td>
                <td align="right" valign="middle" class="c001">
                    <asp:HyperLink ID="lnkFirst" runat="server">[首 页]</asp:HyperLink>
                    <asp:HyperLink ID="lnkPrev" runat="server">[上一页]</asp:HyperLink>
                    <asp:HyperLink ID="lnkNext" runat="server">[下一页]</asp:HyperLink>
                    <asp:HyperLink ID="lnkLast" runat="server">[尾 页]</asp:HyperLink>
                </td>
            </tr>
        </table>         
    </div>
</form>
</asp:Content>
