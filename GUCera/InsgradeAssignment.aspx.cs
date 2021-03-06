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
    public partial class InsgradeAssignment : System.Web.UI.Page
    {
        int courseID;
        int assno;
        string type;
        SqlConnection conn;
        int id;
        int sid;
        int fullG;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["field1"] == null)
            {
                Response.Redirect("Error.aspx");
            }


            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
            {



                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
                conn = new SqlConnection(connStr);
                int s = Int32.Parse((String)Request.QueryString["cid"]);
                assno = Int32.Parse((String)Request.QueryString["assignmentNumber"]);
                type = ((String)Request.QueryString["type"]);
                sid = Int32.Parse(((String)Request.QueryString["sid"]));
                courseID = s;


                head.Text =
                            "<p>CourseID " + courseID + "</p>" +
                            "Assignment#" + assno + " type: " + type +
                            "<p> Update Grade of: " +
                            "StudentID " + sid + "</p>";

                Literal1.Text = "<a href='InstructorAssignments.aspx?cid="+courseID+"'>Back</a>";


                SqlConnection conn3 = new SqlConnection(connStr);
                SqlCommand cmd3 = new SqlCommand("SELECT * FROM Assignment WHERE cid=" + courseID + " AND number=" + assno + " AND type = '" + type + "'", conn3);
                cmd3.CommandType = CommandType.Text;
                conn3.Open();
                SqlDataReader rdr3 = cmd3.ExecuteReader(CommandBehavior.SingleRow);
                rdr3.Read();
                fullG = rdr3.GetInt32(rdr3.GetOrdinal("fullGrade"));
                conn3.Close();


                Literal2.Text = "/" + fullG;

            }
            else Response.Redirect("No Data was found");

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            //obtain connection info and create sql connection to database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
            conn = new SqlConnection(connStr);

            //create a new SQL command which takes as parameters the name of the stored procedure and the SQLconnection name
            SqlCommand cmd = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            id = (int)Session["field1"];
            

            if (TextBox1.Text == "") { msg.Text = "<p style='color: Red'> Please Enter a grade </p>"; }
            else
            {
                Decimal gr = Decimal.Parse(TextBox1.Text.ToString());

                cmd.Parameters.Add(new SqlParameter("@instrId", id));
                cmd.Parameters.Add(new SqlParameter("@sid", sid));
                cmd.Parameters.Add(new SqlParameter("@cid", courseID));
                cmd.Parameters.Add(new SqlParameter("@assignmentNumber", assno));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                cmd.Parameters.Add(new SqlParameter("@grade", gr));


                try
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    msg.Text = "<p style='color: green'> Grade Updated Successfully</p>";
                       

                }

                catch (SqlException ex)
                {
                    if (ex.Message.Contains("data type numeric")) { msg.Text = ("<p style='color:red'> Entered Value is too Big</p>"); }
                    else
                    msg.Text = ("<p style='color:red'> Error:" + ex.Number + " " + ex.Message + "</p>");


                }
            }



        }

       
    }
}