<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsClassManage.Index" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/copyright.ascx" TagName="CopyRight" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="LtpPageControl" Assembly="LtpPageControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../Style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    
    <div style="text-align:center">
    <cc1:page01 id="Page011" runat="server" Page_Index="index.aspx" Page_Add="add.aspx" Page_Makesql="AllList.aspx"></cc1:page01>
			<table cellSpacing="0" cellPadding="5" width="90%" align="center" border="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
			bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
				<tr>
					<td >
                        <asp:GridView ID="grid" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                        CellPadding="5" BorderWidth="1px" DataKeyNames="ClassId" OnRowCreated="grid_RowCreated" OnRowCommand="grid_RowCommand" OnRowDataBound="grid_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ClassId" HeaderText="编号">
                                <ItemStyle HorizontalAlign="Center" />
                               </asp:BoundField> 
                                <asp:BoundField DataField="ClassDesc" HeaderText="类名" >
                                 <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField >
                                
                                <asp:BoundField DataField="ClassPicture" HeaderText="类图片">
                                 <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>     
                                <asp:BoundField DataField="ParentId" HeaderText="父类">
                                  <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField >
                                <asp:HyperLinkField DataNavigateUrlFields="ClassId" DataNavigateUrlFormatString="show.aspx?id={0}"
                                    HeaderText="详细" Text="详细" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField DataNavigateUrlFields="ClassId" DataNavigateUrlFormatString="modify.aspx?id={0}"
                                    HeaderText="修改" Text="修改" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:HyperLinkField>
                                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="DeleteByClassId"
                                            OnClientClick='return confirm("您真的要删除这条记录吗？")' Text="删除" CommandArgument='<%#Eval("Classid") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
					
				</tr>
			</table>
			<cc1:page02 id="Page021" runat="server" Page_Index="index.aspx"></cc1:page02>
        <uc1:CopyRight ID="CopyRight1" runat="server" />
        <uc2:checkright id="Checkright1" runat="server">
        </uc2:checkright></div>
    </form>
</body>
</html>