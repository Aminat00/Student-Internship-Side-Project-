<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="studentInternship.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
            height: 464px;
        }
        .auto-style6 {
            background-color: #D8BBE6;
        font-family: 'Trebuchet MS';
        }
        .auto-style7 {
            background-color: #D8BBE6;
            font-family: 'Trebuchet MS';
            width: 531px;
        }
        .auto-style8 {
            background-color: #D8BBE6;
            font-family: 'Trebuchet MS';
            width: 531px;
            height: 60px;
        }
        .auto-style9 {
            background-color: #D8BBE6;
            font-family: 'Trebuchet MS';
            height: 60px;
        }
        .auto-style10 {
            background-color: #D8BBE6;
            font-family: 'Trebuchet MS';
            width: 531px;
            height: 58px;
        }
        .auto-style11 {
            background-color: #D8BBE6;
            font-family: 'Trebuchet MS';
            height: 58px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table class="auto-style2">
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">STUDENT Primary Key</td>
            <td class="auto-style6">
                <asp:Label ID="labStudentPK" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Name</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBoxName" runat="server" Height="35px" Width="346px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Surname</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBoxSurname" runat="server" Height="36px" Width="339px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Student ID</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBoxStudentID" runat="server" Height="30px" Width="341px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Faculty</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBoxFaculty" runat="server" Height="36px" Width="340px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Button ID="btnInsert1" runat="server" Height="52px" OnClick="btnInsert1_Click" Text="Search" Width="283px" />
            </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style11"></td>
        </tr>
    </table>
    </form>
</body>
</html>
