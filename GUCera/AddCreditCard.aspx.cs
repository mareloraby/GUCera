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
    public partial class AddCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int sid = (int)Session["field1"];
        }

        protected void add(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            if(Number.Text == "" || CHName.Text == "" || EXDate.Text == "" || CVV.Text == "")
            {
                txt.Text = "<p style='color:red '> Please enter all required fields. </p>";
            }
            else { 
            //   int id = Int16.Parse(ID.Text);
            string number = Number.Text;
            string cardholdername = CHName.Text;
                SqlCommand addcd = new SqlCommand("addCreditCard", conn);
                addcd.CommandType = CommandType.StoredProcedure;
                try
                {
                    DateTime expirydate = DateTime.Parse(EXDate.Text);
                    addcd.Parameters.Add(new SqlParameter("@expiryDate", expirydate));
                }
                catch
                {
                    credit.Text = "<p style='color:green '> Please Enter the ExpiryDate in this format Y-M-D. </p>";
                }
            int cvv = Int16.Parse(CVV.Text);


           

            
            addcd.Parameters.Add(new SqlParameter("@sid", (int)Session["field1"]));
            addcd.Parameters.Add(new SqlParameter("@cvv", cvv));
            addcd.Parameters.Add(new SqlParameter("@number", number));
            addcd.Parameters.Add(new SqlParameter("@cardHolderName", cardholdername));




/*

                if (number == "" || cardholdername == "" || EXDate.Text == "" || CVV.Text == "")
                {
                    // Response.Write("Please fill in all fields");
                    // AddCD.Text = "<p style='color:red '> Please fill in all fields </p>";

                    Label lbl_error = new Label();
                    lbl_error.Text = "Please fill in all fields";
                    form1.Controls.Add(lbl_error);


                }*/
                



                    try
                    {
                        conn.Open();
                        addcd.ExecuteNonQuery();

                        conn.Close();



                       /* Label lbl_error = new Label();
                        lbl_error.Text = "Credit card details are added";
                        form1.Controls.Add(lbl_error);*/

                    txt.Text = "<p style='color:green '> Your credit card details has been added. </p>";
                }
                    catch
                    {


                       /* Label lbl_error = new Label();
                        lbl_error.Text = "You are already added this credit card";
                        form1.Controls.Add(lbl_error);*/

                    txt.Text = "<p style='color:red '> This credit card has been added before. </p>";

                }
                }
            




        }
    }
}