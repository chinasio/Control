<%@ Page language="c#" %>
<script runat="server">

private void Page_Load(object sender, System.EventArgs e) {
}

</script>
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD runat="server">
<META HTTP-EQUIV="Expires" CONTENT="0">
<title>������</title>
<style>

body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff; 
	width: 100%;
	overflow:hidden;
	border: 0;
}

body,tr,td {
	color: #000000;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10pt;
}
</style>


<script language="javascript">
function returnTable() {
	var arr = new Array();

	arr["width"] = document.getElementById('Width').value;  
	arr["height"] = document.getElementById('Height').value;
	arr["cellpadding"] = document.getElementById('Cellpadding').value;  
	arr["cellspacing"] = document.getElementById('Cellspacing').value;
	arr["border"] = document.getElementById('Border').value;  	

	arr["cols"] = document.getElementById('Columns').value;
	arr["rows"] = document.getElementById('Rows').value;
	arr["valigncells"] = document.getElementById('VAlignCells')[document.getElementById('VAlignCells').selectedIndex].value;
	arr["haligncells"] = document.getElementById('HAlignCells')[document.getElementById('HAlignCells').selectedIndex].value;
	arr["percentcols"] = document.getElementById('PercentCols').checked;	
			 
	window.returnValue = arr;
	window.close();	
}		
</script>		
</HEAD>
<body>
<table width=100% cellpadding=1 cellspacing=3 border=0>
<tr><td valign=top>
	<fieldset ><legend>���</legend>
	<table width=100% height=100% cellpadding=0 cellspacing=0 border=0>
		<tr>
			<td>���</td>
			<td><input type=text id="Width" name="Width" value=100 style="width:50px;"></td>
		</tr><tr>
			<td>�߶�</td>
			<td><input type=text id="Height" name="Height" value=100 style="width:50px;"></td>
		</tr><tr>
			<td>��Ԫ��߾�</td>
			<td><input type=text id="Cellpadding" name="Cellpadding" style="width:50px;" value=0></td>
		</tr><tr>
			<td>��Ԫ����</td>
			<td><input type=text id="Cellspacing" name="Cellspacing" style="width:50px;" value=0></td>
		</tr><tr>
			<td>�߿��ϸ</td>
			<td><input type=text id="Border" name="Border" style="width:50px;" value=1></td>
		</tr>
	</table>
	</fieldset>
</td>
<td>&nbsp;&nbsp;</td>

<td valign=top>
	<fieldset ><legend>��Ԫ��</legend>
	<table width=100% height=100% cellpadding=0 cellspacing=0 border=0>
		<tr>
			<td>����</td>
			<td><input type=text id="Columns" name="Columns" style="width:80px;" value=2></td>
		</tr><tr>
			<td>����</td>
			<td><input type=text id="Rows" name="Rows" style="width:80px;" value=2></td>
		</tr><tr>
			<td>��ֱ���뷽ʽ</td>
			<td><select id="VAlignCells" name="VAlignCells" style="width:80px;">
					<option>Ĭ��</option>
					<option value="top">���˶���</option>
					<option value="center">��Դ�ֱ����</option>
					<option value="bottom">��Եױ߶���</option>				
				</select>
			</td>
		</tr><tr>
			<td>ˮƽ���뷽ʽ</td>
			<td><select id="HAlignCells" name="HAlignCells" style="width:80px;">
					<option>Ĭ��</option>
					<option value="left">�����</option>
					<option value="center">����</option>
					<option value="right">�Ҷ���</option>				
				</select>
			</td>
		</tr><tr>		
			<td>ƽ���������</td>
			<td><input type="checkbox" id="PercentCols" name="PercentCols" value="1"></td>			
		</tr>
	</table>
	</fieldset>
</td></tr>
<tr><td colspan=3 align=center>
	<input type="button" onclick="returnTable();return false;" value="������">
</td></tr>
</table>

</body>
</html>
