﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="GUCera.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <style>
        p {
            color:white; 
            font-size: 20px;
        }
        body {
            background-image: url("Student HomePage.jpg");
           
  	background-repeat: no-repeat;
			background-attachment: fixed;
			background-size: cover;
        }
        .options {
    font-size:20px;
  width: 700px;
  color:black;
  margin: auto;


text-align:center;

justify-content:center;
  
        }
        	
	  .h {
	        background-image: url('loginbg.jpg');
			background-repeat: no-repeat;
			background-attachment: fixed;
			background-size: cover;
			color: white;
			text-shadow: 0.px 0.5px #0000004d;
/*            height: 10px;
			line-height: 10px;
*/			padding: 2px;        
        
        }
    </style>
<head runat="server">
    <title>StudentHomePage </title>
</head>
<body>
    <form id="form1" runat="server">
        
             <p><asp:Literal ID="StName" runat="server"></asp:Literal></p>
           
			
       
        <div class="options">
           
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/StudentViewMyProfile.aspx" ForeColor="White">View My Profile</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink13" runat="server" ForeColor="White" NavigateUrl="~/EnrolledCourses.aspx">Enrolled Courses & Assignments</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/AddMobileNumber.aspx" ForeColor="White">Add Mobile Number</asp:HyperLink>
            <br/>
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/AllCourses.aspx" ForeColor="White">All Courses</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/EnrollInACourse.aspx" ForeColor="White">Enroll</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/AddCreditCard.aspx" ForeColor="White">Add Credit Card</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/ViewMyPromoCodes.aspx" ForeColor="White">View PromoCodes</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StudentSubmitAssignment.aspx" ForeColor="White">Submit Assignment</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/StudentViewAssignGrade.aspx" ForeColor="White">Check Grade</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/StudentAddFeedback.aspx" ForeColor="White">Add Course Feedback</asp:HyperLink>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
