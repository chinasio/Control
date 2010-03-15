<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td style="width: 90px">
                    First Name :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxFirstName" runat="server" Width="176px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLastName" runat="server" Width="179px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Age :</td>
                <td>
                    <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" 
                        onclick="ButtonSave_Click" />&nbsp;
                    <asp:Button ID="ButtonClear" runat="server" Text="Clear" 
                        onclick="ButtonClear_Click" />&nbsp;
                    <asp:Button ID="ButtonSyncGet" runat="server" Text="Get [Sync]" 
                        onclick="ButtonSyncGet_Click" />&nbsp;
                    <asp:Button ID="ButtonAsynGet" runat="server" Text="Get [Async]" 
                        onclick="ButtonAsynGet_Click" style="height: 26px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
