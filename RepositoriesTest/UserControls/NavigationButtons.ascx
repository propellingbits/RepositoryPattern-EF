<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationButtons.ascx.cs" Inherits="RepositoriesTest.UserControls.NavigationButtons" %>
<table>        
    <tr>
        <td>
            <asp:Button ID="btnPrev" runat="server" Text="Prev" onclick="btnPrev_Click" />
        </td>
        <td>
            <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" />
        </td>
    </tr>
</table>