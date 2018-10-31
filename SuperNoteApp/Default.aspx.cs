using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SuperNoteApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {    
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from UserInformation where UserName =@username and Password=@password", con);
            cmd.Parameters.AddWithValue("@username", username1.Text);
            cmd.Parameters.AddWithValue("@password", password1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["currentUser"] = username1.Text; 
                Response.Redirect("MainPage.aspx");
            }

            else
            {
                password1.Text = "";
                username1.Text = "";
                info.Visible = true;
                info.Text = "Wrong username or password!";
            }    
        }

        protected void register_Click(object sender, EventArgs e)
        {
            if (isUserExist() == false)
            {
                if (username1.Text != null && password1.Text != null && username1.Text.Length > 5 && password1.Text.Length > 5)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserInformation values (@Username, @Password)", con);

                    cmd.Parameters.AddWithValue("Username", username1.Text);
                    cmd.Parameters.AddWithValue("Password", password1.Text);

                    cmd.ExecuteNonQuery();
                    info.Visible = true;
                    info.Text = "User registered successfully!";

                    username1.Text = "";
                    password1.Text = "";

                    username1.Focus();
                }
                else
                {
                    info.Text = "Minimum 6 characters required, space is not allowed.";
                }
            }

            else
            {
                info.Text = "Username already exist.";
            }         
        }

        public bool isUserExist()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [UserInformation] WHERE ([username] = @user)", con);
            check_User_Name.Parameters.AddWithValue("@user", username1.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();
            
            if (UserExist > 0)
            {   
                return true;
            }
            else
            {  
                return false;
            }
        }
    }
}