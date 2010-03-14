<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Add.aspx.cs" Inherits="Maticsoft.Web.Admin.Product.Add" %>

<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
<link href="../style.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
		function checkData()
		{
				var fileName=document.getElementById("FileUp").value;
				if(fileName=="")
					return;
				//检查文件类型
				var exName=fileName.substr(fileName.lastIndexOf(".")+1).toUpperCase()				
				if(exName=="JPG"||exName=="BMP"||exName=="GIF")
				{
				    //document.getElementById("myimg").src=fileName;
				    document.getElementById("previewImage").innerHTML='<img src=\''+fileName+'\' width=100 height=100 >';
				}
				else
				if(exName=="SWF")
				{
					document.getElementById("previewImage").innerHTML='<embed src=\''+fileName+'\' width=\'100\' height=\'100\' quality=\'high\' bgcolor=\'#f5f5f5\' ></embed>';					
				}
				else
				if(exName=="WMV"||exName=="MPEG"||exName=="ASF"||exName=="AVI")
				{
					var strcode='<embed src=\''+fileName+'\' border=\'0\' width=\'100\' height=\'100\' quality=\'high\' ';
					strcode+=' autoStart=\'1\' playCount=\'0\' enableContextMenu=\'0\' type=\'application/x-mplayer2\'></embed>';
					document.getElementById("previewImage").innerHTML=strcode;
				}
				else				
				{
					alert("请选择正确的图片文件");
					document.getElementById("FileUp").value="";
				}	
		}
		function checkData2()
		{
				var fileName=document.getElementById("FileUpSmall").value;
				if(fileName=="")
					return;
				//检查文件类型
				var exName=fileName.substr(fileName.lastIndexOf(".")+1).toUpperCase()				
				if(exName=="JPG"||exName=="BMP"||exName=="GIF")
				{
				    //document.getElementById("myimg").src=fileName;
				    document.getElementById("previewSmallImage").innerHTML='<img src=\''+fileName+'\' width=100 height=100 >';
				}
				else
				if(exName=="SWF")
				{
					document.getElementById("previewSmallImage").innerHTML='<embed src=\''+fileName+'\' width=\'100\' height=\'100\' quality=\'high\' bgcolor=\'#f5f5f5\' ></embed>';					
				}
				else
				if(exName=="WMV"||exName=="MPEG"||exName=="ASF"||exName=="AVI")
				{
					var strcode='<embed src=\''+fileName+'\' border=\'0\' width=\'100\' height=\'100\' quality=\'high\' ';
					strcode+=' autoStart=\'1\' playCount=\'0\' enableContextMenu=\'0\' type=\'application/x-mplayer2\'></embed>';
					document.getElementById("previewSmallImage").innerHTML=strcode;
				}
				else				
				{
					alert("请选择正确的图片文件");
					document.getElementById("FileUpSmall").value="";
				}	
		}
			
		
		</script>

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
                            <tr bgcolor="#e4e4e4" >
                                <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' height="22" align="left">
                                    信息添加，请详细填写下列信息，带有 <font class="form_requestcolor">*</font> 的必须填写。</td>
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
                                                <asp:TextBox ID="txtProductId" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProductId"
                                                    ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
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
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td width="150" height="22">
                                                &nbsp;</td>
                                            <td height="22" align="left">
                                                <asp:CheckBox ID="chkAddContinue" runat="server" Text="连续添加"></asp:CheckBox>&nbsp;[
                                                添加成功后直接跳回此页进行再次添加 ]
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <div align="center">
                                        <uc2:checkright ID="Checkright1" runat="server" />
                                        <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click"></asp:Button><font
                                            face="宋体">&nbsp;</font>
                                        <asp:Button ID="btnCancel" runat="server" Text="· 重填 ·"></asp:Button></div>
                                </td>
                            </tr>
                        </table>
                        <uc1:copyright ID="Copyright1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
