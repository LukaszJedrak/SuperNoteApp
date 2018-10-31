using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace SuperNoteApp
{
    public partial class MainPage : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ReadSubjectOnly(Session["currentUser"]);

            if (Session["currentUser"] != null)
            {
                welcomeUser.Text = "Hi, " + "<b>" + Session["currentUser"].ToString() + "</b>";
            }
        }

        protected void addNoteButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into UserNotesData values (@UserName, @Subject, @Message)", con);

            cmd.Parameters.AddWithValue("UserName", Session["currentUser"]);
            cmd.Parameters.AddWithValue("Subject", textArea.InnerText);
            cmd.Parameters.AddWithValue("Message", textArea2.InnerText);

            cmd.ExecuteNonQuery();

            ReadSubjectOnly(Session["currentUser"]);
            con.Close();
        }

        public void ReadValues(object session)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT Subject, Message FROM UserNotesData WHERE UserName=@currentSession;", con);
            command.Parameters.AddWithValue("@currentSession", session);

            SqlDataReader reader = command.ExecuteReader();
            List<string> subjects = new List<string>();
            List<string> messages = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    subjects.Add(reader.GetString(0));
                    messages.Add(reader.GetString(1));
                }
            }
            else
            {
                //Console.WriteLine("No rows found.");
            }
            reader.Close();

            for (int i = 0; i < subjects.Count; i++)
            {
                if (subjects[i] == listItems.SelectedItem.ToString())
                {
                    textArea.InnerText = subjects[i];
                    textArea.DataBind();
                    break;
                }
            }

            for (int i = 0; i < messages.Count; i++)
            {
                if (subjects[i] == listItems.SelectedItem.ToString())
                {
                    textArea2.InnerText = messages[i];
                    textArea2.DataBind();
                    break;
                }
            }

            con.Close();
        }

        public void ReadSubjectOnly(object session)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT Subject FROM UserNotesData WHERE UserName=@currentSession;", con);
            command.Parameters.AddWithValue("@currentSession", session);

            SqlDataReader reader = command.ExecuteReader();
            List<string> subjects = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    subjects.Add(reader.GetString(0));

                }
            }
            else
            {
                //No rows found
            }

            listItems.Items.Clear();

            for (int i = 0; i < subjects.Count; i++)
            {
                listItems.Items.Add(subjects[i]);
            }

            listItems.DataBind();
            reader.Close();
            con.Close();
        }

        protected void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadValues(Session["currentUser"]);
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Default.aspx");
        }
    }
}