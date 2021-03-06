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
    public partial class InstructorRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registration(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string firstn = firstname.Text;
            string lastn = lastname.Text;
            string pass = password.Text;
            string em = email.Text;
            string add = address.Text;
            string g = gender.Text;

            SqlCommand instructorreg = new SqlCommand("InstructorRegister", conn);
            instructorreg.CommandType = CommandType.StoredProcedure;

            instructorreg.Parameters.Add(new SqlParameter("@first_name", firstn));
            instructorreg.Parameters.Add(new SqlParameter("@last_name", lastn));
            instructorreg.Parameters.Add(new SqlParameter("@password", pass));
            instructorreg.Parameters.Add(new SqlParameter("@email", em));
            instructorreg.Parameters.Add(new SqlParameter("@gender", ((g == "F") ? 1 : 0)));
            instructorreg.Parameters.Add(new SqlParameter("@address", add));


            if (firstn == "" || lastn == "" || pass == "" || em == "" || g == "")
            {
                txt.Text = "<p style='color:red '> Please fill in all fields </p>";
            }
            else
            {
                try
                {
                    conn.Open();
                    instructorreg.ExecuteNonQuery();
                    //   txt.Text = ("<p style='color:green'> Registration Successful </p>");

                    SqlCommand cmd = new SqlCommand("select max(id) as max from Instructor", conn);
                    cmd.CommandType = CommandType.Text;


                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);

                    if (rdr.Read())
                    {
                        conn.Close();
                        conn.Open();
                        rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                        rdr.Read();
                        int uid = rdr.GetInt32(rdr.GetOrdinal("max"));
                        conn.Close();
                        txt.Text = ("<p style='color:green'> Registration Successful, UserID:  " + uid + "</p>");
                        redirect.Text =  "<a href='Login.aspx' style='color:Blue'> Log-in</a>";

                       



                    }


                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("duplicate key")) { txt.Text = "<p style='color:red'> This email is already used.</p>"; } 
                    else
                    txt.Text = ("<p style='color:red'> Error:" + ex.Number + " " + ex.Message + "</p>");


                }
            }


        }
    }
}