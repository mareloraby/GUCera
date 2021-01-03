﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class EnrollInACourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Enroll(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            int id = Int16.Parse(en.Text);

            SqlCommand enroll = new SqlCommand("enrollInCourse", conn);
            enroll.CommandType = CommandType.StoredProcedure;

        

            conn.Open();
            enroll.ExecuteNonQuery();
            conn.Close();



        }
        }
}