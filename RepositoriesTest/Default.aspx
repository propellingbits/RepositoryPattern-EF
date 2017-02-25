<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RepositoriesTest.Default1" %>
<%@ Register TagPrefix="UC" TagName="NavigationButtons" Src="~/UserControls/NavigationButtons.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div>
    <UC:NavigationButtons id="ucNavigationButtons" runat="server" />    
    </div>    
</asp:Content>