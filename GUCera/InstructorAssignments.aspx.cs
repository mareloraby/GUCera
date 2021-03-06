﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class InstructorAssignments : System.Web.UI.Page
    {

        int courseID;
        SqlConnection conn;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

     
            if (Session["field1"] == null)
            {
                Response.Redirect("Error.aspx");
            }




            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
            {


                //If courseid can be obtained from the request
                //take it from the request and store it
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
                conn = new SqlConnection(connStr);
                int s = Int32.Parse((String)Request.QueryString["cid"]);
                courseID = s;

                SqlCommand cmd = new SqlCommand("select * from Course where id=" + courseID, conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (rdr.Read())
                {
                    conn.Close();
                    conn.Open();
                    rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    rdr.Read();
                    String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                    conn.Close();

                    title.Text = "<h2>" + courseName + "</h2>";

                }
            }
            else Response.Redirect("No Course Data was found");
            msg.Text = "";
            redir.Text = "<a href='instructorHome.aspx' style='color:white'> Home </a>";

        }


        protected void define(object sender, EventArgs e)
        {


            //obtain connection info and create sql connection to database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
            conn = new SqlConnection(connStr);

            //create a new SQL command which takes as parameters the name of the stored procedure and the SQLconnection name
            SqlCommand cmd = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
            cmd.CommandType = CommandType.StoredProcedure;


         

            if (ano.Text == "" ||  full.Text == "" || wgt.Text == "" || dead.Text == "" || cnt.Text == "")
            {
                msg.Text = "<p style='color:red '> Please fill in all fields </p>";
            }
            else
            {
                id = (int)Session["field1"];
                int num = int.Parse(ano.Text);
                //string type = ty.Text.ToString();
                String type = DropDownList1.SelectedItem.Text.ToString();
                int fullgrade = int.Parse(full.Text);
                decimal weight = decimal.Parse(wgt.Text);
                DateTime deadline = DateTime.Parse(dead.Text.ToString());
                string content = cnt.Text.ToString();

            

                //Add input of procedure
                cmd.Parameters.Add(new SqlParameter("@instId", id));
                cmd.Parameters.Add(new SqlParameter("@cid", courseID));
                cmd.Parameters.Add(new SqlParameter("@number", num));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                cmd.Parameters.Add(new SqlParameter("@fullGrade", fullgrade));
                cmd.Parameters.Add(new SqlParameter("@weight", weight));
                cmd.Parameters.Add(new SqlParameter("@deadline", deadline));
                cmd.Parameters.Add(new SqlParameter("@content", content));

                try
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    msg.Text = "<p style='color:green '> Assignment#"+ num + " of type: "+type+" added Successfully! </p>";


                }
                catch (SqlException ex)
                {

                    if (ex.Message.Contains("duplicate key")){msg.Text = "<p style='color:red'> This assignment is already added for this course</p>"; }
                    else
                    msg.Text = ("<p style='color:red'> Error:" + ex.Number + " " + ex.Message + "</p>");


                }


            }

        }


        protected void viewSubmissions(object sender, EventArgs e)
        {


            //obtain connection info and create sql connection to database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
            conn = new SqlConnection(connStr);

            //create a new SQL command which takes as parameters the name of the stored procedure and the SQLconnection name
            SqlCommand cmd = new SqlCommand("InstructorViewAssignmentsStudents", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            id = (int)Session["field1"];
            //inputs
            cmd.Parameters.Add(new SqlParameter("@instrId", id));
            cmd.Parameters.Add(new SqlParameter("@cid", courseID));


            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (!rdr.HasRows)
            {
                Literal1.Text = "<p style='color: Red'> No submissions for this course yet. </p>";
            }
           
               
                
                while (rdr.Read())
            {
                int sid = rdr.GetInt32(rdr.GetOrdinal("sid"));
                int cid = rdr.GetInt32(rdr.GetOrdinal("cid"));
                int asN = rdr.GetInt32(rdr.GetOrdinal("assignmentNumber"));
                string asT = rdr.GetString(rdr.GetOrdinal("assignmenttype"));
                Decimal gr;
                int fullG;

                try
                {
                     gr = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                }
                catch {
                     gr = 0;
                }


            
                SqlConnection conn3 = new SqlConnection(connStr);
                SqlCommand cmd3 = new SqlCommand("SELECT * FROM Assignment WHERE cid=" + cid + " AND number=" + asN + " AND type = '"+ asT +"'", conn3);
                cmd3.CommandType = CommandType.Text;
                conn3.Open();
                SqlDataReader rdr3 = cmd3.ExecuteReader(CommandBehavior.SingleRow);
                rdr3.Read();
                fullG = rdr3.GetInt32(rdr3.GetOrdinal("fullGrade"));

                conn3.Close();


                Literal1.Text = "";


                Literal a = new Literal();
                Panel c = new Panel();

                a.Text =

                "<div >" +
                "<p> StudentID " + sid + "</p>" +
                "<p> Assignment# " + asN + "</p>" +
                "<p> Assignment Type: " + asT + "</p>" +
                "<p> Student Grade: " + gr + "/" + fullG + "</p>" +
                "</div>";



                Button MyButtonA = new Button();
                MyButtonA.UseSubmitBehavior = false;
                MyButtonA.PostBackUrl = "InsgradeAssignment.aspx?cid=" + cid.ToString() + "&sid=" + sid.ToString() + "&assignmentNumber=" + asN.ToString() + "&type=" + asT.ToString();
                MyButtonA.Text = "Edit Grade";


                Literal line = new Literal();
                line.Text = "<hr>";

                c.Controls.Add(a);
                c.Controls.Add(MyButtonA);
                c.Controls.Add(line);
                c.CssClass = "card";


                slist.Controls.Add(c);




            }
            

        }

      
    
    }
}