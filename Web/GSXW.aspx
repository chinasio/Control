<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GSXW.aspx.cs" Inherits="Maticsoft.Web.GSXW" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellspacing="0" cellpadding="0" width="549" border="0">
        
            <tr>
                <td width="549">
                    <img height="28" src="images/gsxw.gif" width="559"></td>
            </tr>
            </table>
<form runat="server" id="form2">
    <div style="text-align: center">    
    <table cellspacing="0" cellpadding="5" width="85%" border="0">                
                <tr>
                <td align="left">页次：<asp:Label ID="lblCurrentPage" runat="server" ForeColor="#e78a29"></asp:Label>页/<asp:Label ID="lblPageCount"
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
        <table cellspacing="0" cellpadding="5" width="85%" border="0">                
                <tr>
                    <td >
                        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" Width="100%"
                            AllowPaging="True" AllowSorting="False" OnRowCreated="gridView_RowCreated" OnPageIndexChanging="gridView_PageIndexChanging"
                             CellPadding="3" BorderWidth="0px" PageSize="10"  ShowHeader="false" 
                            DataKeyNames="NewsId">
                            <Columns>                                                
                                <asp:HyperLinkField DataNavigateUrlFields="NewsId" DataNavigateUrlFormatString="news.aspx?id={0}" Target="_blank"  DataTextField="Heading" />
                                <asp:BoundField DataField="IssueDate" HeaderText="IssueDate"  >
                                    <ItemStyle Width="100px"  />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        </asp:GridView>
                        <asp:Label ID="Label1" runat="server" Visible="False" ForeColor="Red">没有数据！！</asp:Label></td>
                </tr>
            </table>           
            
    </div></form>
</asp:Content>
