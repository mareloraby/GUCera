﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorAssignments.aspx.cs" Inherits="GUCera.InstructorAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Assignments</title>

	<style>
	    .card {
	        background-color: lightgray;
	    }

		  .h {
	        background-image: url('loginbg.jpg');
			background-repeat: no-repeat;
			background-attachment: fixed;
			background-size: cover;
			color: white;
			text-shadow: 0.5px 0.5px #0000004d;
              height: 10px;
        line-height: 10px;
        padding: 15px;        
        
        }
	</style>
</head>

<body>
    <form id="form1" runat="server">
		<p class="h">
        <asp:Literal ID="redir" runat="server"></asp:Literal></p>
        <asp:Literal ID="title" runat="server"></asp:Literal>
		<br>

        <details>
        <summary>Define an Assignment of a Certain Type</summary>
        <p>
                 <table cellpadding="2" >
	            <tbody>
		            
					<tr>
			            <td>Number</td>
			            <td> <asp:TextBox ID="ano" runat="server"  type="number"  ></asp:TextBox> <br /> </td>
		            </tr>
		            <tr>
			            <td> Type</td>
			          <%--  <td> <asp:TextBox ID="ty" runat="server" ></asp:TextBox><br /></td>--%>
						<td> <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="164px">

							<asp:listitem text="Exam" value="1"></asp:listitem>
							 <asp:listitem text="Project" value="2"></asp:listitem>
							 <asp:listitem text="Quiz"  value="3"></asp:listitem>


						     </asp:DropDownList><br /></td>

		            </tr>
					
					 <tr>
			            <td> <asp:Label ID="lbl_grade" runat="server" Text="Full Grade"  ></asp:Label> </td>
			            <td>   <asp:TextBox ID="full" runat="server" type="number"  ></asp:TextBox><br /></td>
		            </tr>
					
					<tr>
			            <td> Weight</td>
			            <td>   <asp:TextBox ID="wgt" runat="server" MaxLength="3" ></asp:TextBox><br /></td>
		            </tr>
					
					<tr>
			            <td> Deadline (MM-dd-yyyy HH:mm:ss) </td>
			            <td>   <asp:TextBox ID="dead" runat="server" ></asp:TextBox><br />

                        </td>
		            </tr>
					
					<tr>
			            <td> <asp:Label ID="lbl_content" runat="server" Text="Content"   ></asp:Label> </td>
			            <td>   <asp:TextBox ID="cnt" runat="server" Height="104px" Width="356px" TextMode="MultiLine" Rows="10" ></asp:TextBox><br /></td>
		            </tr>
					
					
					
		            <tr>
			            <td>&nbsp;</td>
			            <td> <asp:Button ID="defAss" runat="server" OnClick="define" Text="Add Assignment" /> </td>
		            </tr>
					
					
	            </tbody>
            </table>


        </p>

        </details>
					 <asp:Literal ID="msg" runat="server"></asp:Literal>


		<hr>
		
        <asp:Button ID="Button1" runat="server" Text="View Student Submissions" OnClick="viewSubmissions" Width="462px" />
        <br>
		<asp:Literal ID="Literal1" runat="server"></asp:Literal>

	<%--	<div id="slist" runat="server">
		</div>--%>
	
		 <asp:Panel ID="slist" runat="server"></asp:Panel>



       
    </form>
</body>
</html>
