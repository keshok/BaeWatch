using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using Microsoft.AspNet.Identity;

namespace SearchBarwithMasterPage
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblMessage.Visible = false;
                string userID = Request.QueryString["ID"];

                if (userID == null)
                {
                    Response.Redirect("Homepage.aspx");
                }


                string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {

                    SqlCommand cmd2 = new SqlCommand("getImageID", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramID = new SqlParameter()
                    {

                        ParameterName = "@Id",
                        Value = userID
                    };
                    cmd2.Parameters.Add(paramID);

                    SqlCommand cmd3 = new SqlCommand("viewComments", conn);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    SqlParameter PID = new SqlParameter()
                    {
                        ParameterName = "@ID",
                        Value = userID
                    };
                    cmd3.Parameters.Add(PID);

                    SqlCommand cmd = new SqlCommand("spGetUserID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter("@ID", userID);
                    cmd.Parameters.Add(param);
                    conn.Open();
                    gridview1.DataSource = cmd3.ExecuteReader();
                    gridview1.DataBind();
                    conn.Close();
                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lblID.Text = rdr["ID"].ToString();
                            lblUsername.Text = rdr["Username"].ToString();
                            lblDesc.Text = rdr["Description"].ToString();
                            lblIntest.Text = rdr["Intrests"].ToString();
                            lblGender.Text = rdr["Gender"].ToString();
                            lblO.Text = rdr["Orientation"].ToString();
                            lblType.Text = rdr["Type"].ToString();

                        }
                    }

                    byte[] bytes = (byte[])cmd2.ExecuteScalar();
                    string strBase64 = Convert.ToBase64String(bytes);
                    ProfilePic.ImageUrl = "data:Image/png;base64," + strBase64;
                    conn.Close();

                }

            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            String Comments = txrComments.Text;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertCommments", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = Request.QueryString["ID"]
                };
                cmd.Parameters.Add(paramID);

                SqlParameter paramCom = new SqlParameter()
                {
                    ParameterName = "@Comments",
                    Value = Comments

                };
                cmd.Parameters.Add(paramCom);

                SqlParameter paramNewID = new SqlParameter()
                {

                    ParameterName = "@NewID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(paramNewID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Visible = true;

                //Comment Notifications
                SqlCommand Notify = new SqlCommand("spGetNotifications", con);
                Notify.CommandType = CommandType.StoredProcedure;
                //Get Username
                string username = "";
                string userID = Request.QueryString["ID"];
                SqlCommand cmd2 = new SqlCommand("spGetUserID", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ID", userID);
                cmd2.Parameters.Add(param);
                con.Open();
                SqlDataReader rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {
                    username = rdr["Username"].ToString();
                }
                con.Close();

                SqlParameter Sender = new SqlParameter()
                {
                    ParameterName = "@Sender",
                    Value = username
                };
                Notify.Parameters.Add(Sender);
                SqlParameter Reciver = new SqlParameter()
                {
                    ParameterName = "@Reciver",
                    Value = User.Identity.GetUserName()
                };
                Notify.Parameters.Add(Reciver);
                SqlParameter Message = new SqlParameter()
                {
                    ParameterName = "@Message",
                    Value = User.Identity.GetUserName() + " has posted a comment saying " + Comments + " on your profile"
                };
                Notify.Parameters.Add(Message);
                SqlParameter RID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = Request.QueryString["ID"]
                };
                Notify.Parameters.Add(RID);
                int ID1 = 0;

                SqlCommand cmd3 = new SqlCommand("spGetProfileByName", con);
                cmd3.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUser1 = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = User.Identity.GetUserName()
                };
                cmd3.Parameters.Add(paramUser1);
                con.Open();
                SqlDataReader rdr2 = cmd3.ExecuteReader();
                while (rdr2.Read())
                {
                    ID1 = Convert.ToInt32(rdr2["ID"]);
                }
                con.Close();
                SqlParameter SID = new SqlParameter()
                {
                    ParameterName = "@SID",
                    Value = ID1
                };
                Notify.Parameters.Add(SID);
                SqlParameter paramNewID1 = new SqlParameter()
                {

                    ParameterName = "@NewID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                Notify.Parameters.Add(paramNewID1);

                con.Open();
                Notify.ExecuteNonQuery();
                con.Close();
                



            }
            string userID1 = Request.QueryString["ID"];
Response.Redirect("~/UserProfile.aspx?ID=" + userID1);
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            //Get Name and ID of profile
            string username = "";
            string userID = Request.QueryString["ID"];
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand cmd2 = new SqlCommand("spGetUserID", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ID", userID);
                cmd2.Parameters.Add(param);
                conn.Open();
                SqlDataReader rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {
                    username = rdr["Username"].ToString();
                }
                SqlCommand cmd = new SqlCommand("spMakeFriends", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramUser);

                SqlParameter paramID = new SqlParameter()
                {

                    ParameterName = "@FriendID",
                    Value = userID
                };
                cmd.Parameters.Add(paramID);

                SqlParameter paramName = new SqlParameter()
                {

                    ParameterName = "@Name",
                    Value = User.Identity.GetUserName()
                };
                cmd.Parameters.Add(paramName);
                SqlParameter paramNewID = new SqlParameter()
                {

                    ParameterName = "@NewID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                conn.Close();
                conn.Open();
                cmd.Parameters.Add(paramNewID);
                cmd.ExecuteNonQuery();
                conn.Close();

                lblMessage.Visible = true;
                lblMessage.Text = "Added to Friends List";

                //Notifications for adding for adding to friends list
                SqlCommand Notify = new SqlCommand("spGetNotifications", conn);
                Notify.CommandType = CommandType.StoredProcedure;
                SqlParameter Sender = new SqlParameter()
                {
                    ParameterName = "@Sender",
                    Value = User.Identity.GetUserName()
                };
                Notify.Parameters.Add(Sender);
                SqlParameter Reciver = new SqlParameter()
                {
                    ParameterName = "@Reciver",
                    Value = username
                };
                Notify.Parameters.Add(Reciver);
                SqlParameter Message = new SqlParameter()
                {
                    ParameterName = "@Message",
                    Value = "You have been added to " + User.Identity.GetUserName() + "'s friends list"
                };
                Notify.Parameters.Add(Message);

                string yourusername = User.Identity.GetUserName();
                int ID = 0;

                SqlCommand cmd3 = new SqlCommand("spGetProfileByName", conn);
                cmd3.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUser1 = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = yourusername
                };
                cmd3.Parameters.Add(paramUser1);
                conn.Open();
                SqlDataReader rdr2 = cmd3.ExecuteReader();
                while (rdr2.Read())
                {
                    ID = Convert.ToInt32(rdr2["ID"]);
                }
                conn.Close();

                SqlParameter RID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = Request.QueryString["ID"]
                };
                Notify.Parameters.Add(RID);
                SqlParameter SID = new SqlParameter()
                {
                    ParameterName = "@SID",
                    Value = ID
                };
                Notify.Parameters.Add(SID);
                SqlParameter paramNewID1 = new SqlParameter()
                {

                    ParameterName = "@NewID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                Notify.Parameters.Add(paramNewID1);
                conn.Open();
                Notify.ExecuteNonQuery();
                conn.Close();



            }
        }

        protected void btnWink_Click(object sender, EventArgs e)
        {
            string username = "";
            string userID = Request.QueryString["ID"];
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetUserID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ID", userID);
                cmd.Parameters.Add(param);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    username = rdr["Username"].ToString();
                }
                conn.Close();
                SqlCommand cmd2 = new SqlCommand("spWink", conn);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramReceiver = new SqlParameter()
                {
                    ParameterName = "@Receiver",
                    Value = username
                };
                cmd2.Parameters.Add(paramReceiver);

                SqlParameter paramReceiverID = new SqlParameter()
                {
                    ParameterName = "@RecieverId",
                    Value = userID
                };
                cmd2.Parameters.Add(paramReceiverID);
                string yourusername = User.Identity.GetUserName();
                int ID = 0;

                SqlCommand cmd3 = new SqlCommand("spGetProfileByName", conn);
                cmd3.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = yourusername
                };
                cmd3.Parameters.Add(paramUser);
                conn.Open();
                SqlDataReader rdr2 = cmd3.ExecuteReader();
                while (rdr2.Read())
                {
                    ID = Convert.ToInt32(rdr2["ID"]);
                }
                conn.Close();
                SqlParameter paramSender = new SqlParameter()
                {
                    ParameterName = "@Sender",
                    Value = yourusername
                };
                cmd2.Parameters.Add(paramSender);
                SqlParameter paramSenderID = new SqlParameter()
                {

                    ParameterName = "@SenderId",
                    Value = ID

                };
                SqlParameter paramNewID = new SqlParameter()
                {

                    ParameterName = "@NewID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                cmd2.Parameters.Add(paramNewID);
                cmd2.Parameters.Add(paramSenderID);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                lblMessage.Visible = true;
                lblMessage.Text = "You've sent a wink ;)";
                //Add to notifications table
                SqlCommand Notify = new SqlCommand("spGetNotifications", conn);
                Notify.CommandType = CommandType.StoredProcedure;
                SqlParameter sendername = new SqlParameter()
                {
                    ParameterName = "@Sender",
                    Value = yourusername
                };
                Notify.Parameters.Add(sendername);
                SqlParameter recivername = new SqlParameter()
                {
                    ParameterName = "@Reciver",
                    Value = username
                };
                Notify.Parameters.Add(recivername);
                SqlParameter message = new SqlParameter()
                {
                    ParameterName = "@Message",
                    Value = "New wink from " + yourusername
                };
                Notify.Parameters.Add(message);
                SqlParameter id = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = userID
                };
                Notify.Parameters.Add(id);
                SqlParameter SID = new SqlParameter()
                {
                    ParameterName = "@SID",
                    Value = ID
                };
                Notify.Parameters.Add(SID);
                SqlParameter paramNewID2 = new SqlParameter()
                {

                    ParameterName = "@NewID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                Notify.Parameters.Add(paramNewID2);
                conn.Open();
                Notify.ExecuteNonQuery();
                conn.Close();



            }

        }

        protected void btnDeleteComment_Click(object sender, EventArgs e)
        {
            // string CID = txtDeleteComment.Text;
            int CID = int.Parse(txtDeleteComment.Text);
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteComment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ID", CID);
                cmd.Parameters.Add(param);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                lblMessage.Visible = true;
                lblMessage.Text = "Comment Deleted";
            }


        }

        protected void btnBlock_Click(object sender, EventArgs e)
        {
            string username = "";
            string userID = Request.QueryString["ID"];
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetUserID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ID", userID);
                cmd.Parameters.Add(param);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    username = rdr["Username"].ToString();
                }
                conn.Close();

                SqlCommand cmd2 = new SqlCommand("spBlock",conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlParameter paramBlocker = new SqlParameter()
                {
                    ParameterName = "@Blocker",
                    Value=User.Identity.GetUserName()
                };
                cmd2.Parameters.Add(paramBlocker);
                SqlParameter paramBlocked = new SqlParameter()
                {
                    ParameterName = "@Blocked",
                    Value=username
                };
                cmd2.Parameters.Add(paramBlocked);
                SqlParameter paramNewID2 = new SqlParameter()
                {

                    ParameterName = "@NewID",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                cmd2.Parameters.Add(paramNewID2);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                lblMessage.Visible = true;
                lblMessage.Text = "User Blocked";
            }
        }
    }
}