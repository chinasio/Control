<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Release.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsManage.Release" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="LtpPageControl" Assembly="LtpPageControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script type="text/javascript" language="JavaScript" src="CheckBox.js"></script>
    <link href="../../Style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" runat="server">
    <div>
    <center>
    <table cellSpacing="0" cellPadding="5" width="700" align="center" border="0">
					<tr>
						<td vAlign="middle" height="25">&nbsp;&nbsp;&nbsp; 快速查询：
							<asp:textbox id="txtKey" runat="server" ToolTip="新闻名称关键字"></asp:textbox>&nbsp;
							<asp:dropdownlist id="DropField" runat="server" Width="150px">
								<asp:ListItem Value="Heading">新闻标题</asp:ListItem>
								<asp:ListItem Value="NewsId">新闻编号</asp:ListItem>
								<asp:ListItem Value="ClassId">类别编码</asp:ListItem>
							</asp:dropdownlist><asp:imagebutton id="btn_Search" runat="server" ToolTip="快速检索广告" ImageUrl="../images/button_search.GIF" OnClick="btn_Search_Click"></asp:imagebutton></td>
					</tr>
				</table>
    <cc1:page01 id="Page011" runat="server" Page_Index="index.aspx" Page_Add="add.aspx" Page_Makesql="AllList.aspx"></cc1:page01>
			<table cellSpacing="0" cellPadding="5" width="700" align="center" border="0">
				<tr>
					<td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
					
					<asp:datagrid id="grid" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
							DataKeyField="NewsId" OnItemDataBound="grid_ItemDataBound" SkinID="datagridSkin" CellPadding="10" BorderWidth="1px" HeaderStyle-Font-Bold=true>
							<Columns>
							<asp:TemplateColumn HeaderText="选择">
										<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="30px"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="SelectThis" onclick="javascript:CCA(this);" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								
								<asp:BoundColumn DataField="NewsId" ReadOnly="True" HeaderText="编号" HeaderStyle-Width="30px"></asp:BoundColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="NewsId" DataNavigateUrlFormatString="show.aspx?id={0}" DataTextField="Heading"
									HeaderText="新闻标题">
									<HeaderStyle Wrap="False"></HeaderStyle>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Left" />
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="Frequency" ReadOnly="True" HeaderText="点击">
									<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="28px"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Dormancy" ReadOnly="True" HeaderText="状态">
									<HeaderStyle Wrap="False" Width="28px"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ClassId" HeaderText="类别">
									<HeaderStyle Wrap="False" Width="50px"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IssueDate" HeaderText="时间">
									<HeaderStyle Wrap="False" Width="110px"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								
								
							</Columns>
							<PagerStyle Visible="False"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<cc1:page02 id="Page021" runat="server" Page_Index="index.aspx"></cc1:page02>
               <table cellPadding="0" width="700" border="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>' >
					<tr>
						<td width="80" height="25"><input onclick="CA();" type="checkbox" name="allbox">全选</td>
						<td align=left><asp:button id="btn_Relese" runat="server" ToolTip="让新闻变为发布状态" Text=" 发 布 " BorderStyle="Groove"
								BackColor="Transparent" BorderColor="RoyalBlue" Height="20px" BorderWidth="1px" OnClick="btn_Relese_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btn_NoRelease" runat="server" ToolTip="取消新闻的发布" Text=" 休 眠 " BorderStyle="Groove"
								BackColor="Transparent" BorderColor="RoyalBlue" Height="20px" BorderWidth="1px" OnClick="btn_NoRelease_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="Confirm" runat="server" ToolTip="删除相应的新闻" Text=" 删 除 " BorderStyle="Groove"
								BackColor="Transparent" BorderColor="RoyalBlue" Height="20px" BorderWidth="1px" OnClick="Confirm_Click"></asp:button></td>
					</tr>
					
					
				</table></center>
    </div>
        <uc1:checkright id="Checkright1" runat="server">
        </uc1:checkright>
    </form>
</body>
</html>