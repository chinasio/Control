<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsManage.Index" %>

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
    <div style="text-align: center">
            <table cellspacing="0" cellpadding="5" width="700" border="0">
                <tr>
                    <td height="25" align="left">
                        &nbsp;&nbsp;&nbsp; 快速查询：
                        <asp:TextBox ID="txtKey" runat="server" ToolTip="关键字"></asp:TextBox>&nbsp;
                        <asp:DropDownList ID="DropField" runat="server" Width="150px">
                            <asp:ListItem Value="Heading">标题</asp:ListItem>
                            <asp:ListItem Value="Focus">关键字</asp:ListItem>
                            <asp:ListItem Value="Content">内容</asp:ListItem>
                            
                        </asp:DropDownList>
                        <asp:ImageButton ID="btn_Search" runat="server" ImageUrl="../images/button_search.GIF"
                            ToolTip="快速检索广告" OnClick="btn_Search_Click"></asp:ImageButton>
                    </td>
                </tr>
            </table>
            
            <table cellspacing="0" cellpadding="5" width="700" border="0">                
                <tr>
                <td align="left">○页次：<asp:Label ID="lblCurrentPage" runat="server" ForeColor="#e78a29"></asp:Label>页/<asp:Label ID="lblPageCount"
                        runat="server"></asp:Label>页，共<asp:Label ID="lblRowsCount" runat="server" ForeColor="#e78a29"></asp:Label>条记录
                        </td>
                <td align="right">
                [<asp:linkbutton id="btnFirst" runat="server" OnCommand="NavigateToPage" CommandArgument="First"
								CommandName="Pager" Text="首 页">首 页</asp:linkbutton>]
				[<asp:linkbutton id="btnPrev" runat="server" OnCommand="NavigateToPage" CommandArgument="Prev"
								CommandName="Pager" Text="上一页">上一页</asp:linkbutton>]
				[<asp:linkbutton id="btnNext" runat="server" OnCommand="NavigateToPage" CommandArgument="Next"
								CommandName="Pager" Text="下一页">下一页</asp:linkbutton>]
				[<asp:linkbutton id="btnLast" runat="server" OnCommand="NavigateToPage" CommandArgument="Last"
								CommandName="Pager" Text="尾 页">尾 页</asp:linkbutton>]
                </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="5" width="700" border="0">                
                <tr>
                    <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" Width="100%"
                            AllowPaging="True" AllowSorting="True" OnRowCreated="gridView_RowCreated" OnPageIndexChanging="gridView_PageIndexChanging"
                            OnRowDataBound="gridView_RowDataBound" CellPadding="5" BorderWidth="1px" PageSize="15" OnRowDeleting="gridView_RowDeleting" OnSorting="gridView_Sorting"
                            DataKeyNames="NewsId">
                            <Columns>   
                            <asp:BoundField DataField="NewsId" HeaderText="编号" SortExpression="NewsId" /> 
                            <asp:HyperLinkField HeaderText="标题" DataNavigateUrlFields="NewsId" DataNavigateUrlFormatString="show.aspx?id={0}"
                                    Text="标题"  DataTextField="Heading" />                           
                                
                                <asp:BoundField DataField="Frequency" HeaderText="点击" />        
                                <asp:BoundField DataField="Dormancy" HeaderText="状态" />     
                                <asp:BoundField DataField="IsTop" HeaderText="首页显示" />                                
                                <asp:BoundField DataField="ClassId" HeaderText="类别" />      
                                <asp:BoundField DataField="IssueDate" HeaderText="时间" />      
                                <asp:HyperLinkField HeaderText="修改" DataNavigateUrlFields="NewsId" DataNavigateUrlFormatString="modify.aspx?id={0}"
                                    Text="修改" Visible="False" />
                                <asp:TemplateField HeaderText="删除" ShowHeader="False" Visible="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick='return confirm("您真的要删除这条记录吗？")' Text="删除"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        </asp:GridView>
                        <asp:Label ID="Label1" runat="server" Visible="False" ForeColor="Red">没有数据！！</asp:Label>
                        <uc1:copyright ID="Copyright1" runat="server" />
                        <uc2:checkright ID="Checkright1" runat="server" />
                    </td>
                </tr>
            </table>           
        </div>
    </form>
</body>
</html>
