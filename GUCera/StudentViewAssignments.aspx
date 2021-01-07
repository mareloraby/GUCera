﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentViewAssignments.aspx.cs" Inherits="GUCera.StudentViewAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body> 
    <form id="form1" runat="server">
        <asp:Literal  ID="NoEntries" runat="server"></asp:Literal>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
   <Columns>
      
      
        <asp:BoundField DataField="number" HeaderText="Number" />
        <asp:BoundField DataField="type" HeaderText="Type" />
        <asp:BoundField DataField="fullGrade" HeaderText="Full Grade" />
        <asp:BoundField DataField="weight" HeaderText="Weight" />
        <asp:BoundField DataField="deadline" HeaderText="Deadline" />
       <asp:BoundField DataField="content" HeaderText="Content" />
 
       </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </form>
</body>
</html>
