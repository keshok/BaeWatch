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
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace SearchBarwithMasterPage
{
    public partial class AccountSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Homepage.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DeleteConfirm.aspx");
        }

        protected void btnUpdateDesc_Click(object sender, EventArgs e)
        {
            string username = User.Identity.GetUserName();
            string Description = txtDescription.Text;
            int ID = 0;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetProfileByName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramUser);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["ID"]);
                }
                con.Close();

                SqlCommand cmd2 = new SqlCommand("spUpdateDescription", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = ID
                };
                cmd2.Parameters.Add(paramID);

                SqlParameter paramDesc = new SqlParameter()
                {
                    ParameterName = "@Description",
                    Value = Description
                };
                cmd2.Parameters.Add(paramDesc);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Your description has been changed";
            }
        }

        protected void btnUpdateInt_Click(object sender, EventArgs e)
        {
            string username = User.Identity.GetUserName();
            string Interests = txtInterests.Text;
            int ID = 0;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetProfileByName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramUser);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["ID"]);
                }
                con.Close();

                SqlCommand cmd2 = new SqlCommand("spUpdateIntrests", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = ID
                };
                cmd2.Parameters.Add(paramID);

                SqlParameter paramInt = new SqlParameter()
                {

                    ParameterName = "@Intrest",
                    Value = Interests
                };
                cmd2.Parameters.Add(paramInt);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Your interests has been changed";
            }
        }

        protected void btnUpdateGender_Click(object sender, EventArgs e)
        {
            String Gender = "";
            string username = User.Identity.GetUserName();
            if (Male.Checked)
            {
                Gender = "Male";
            }

            else if (Female.Checked)
            {
                Gender = "Female";
            }

            else if (Other.Checked)
            {

                Gender = "Other";
            }


            int ID = 0;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetProfileByName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramUser);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["ID"]);
                }
                con.Close();

                SqlCommand cmd2 = new SqlCommand("spUpdateGender", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramid = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = ID
                };
                cmd2.Parameters.Add(paramid);

                SqlParameter paramGender = new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = Gender
                };
                cmd2.Parameters.Add(paramGender);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Your gender has been changed";
            }
        }

        protected void btnOrientation_Click(object sender, EventArgs e)
        {
            String O = "";
            string username = User.Identity.GetUserName();
            if (Strait.Checked)
            {
                O = "Straight ";
            }

            if (Gay.Checked)
            {
                O = "Gay";

            }

            if (OtherOrientation.Checked)
            {
                O = "Other";
            }

            int ID = 0;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetProfileByName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramUser);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["ID"]);
                }
                con.Close();

                SqlCommand cmd2 = new SqlCommand("spUpdateOrein", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter()
                {
                    ParameterName = "ID",
                    Value = ID
                };
                cmd2.Parameters.Add(paramID);

                SqlParameter paramO = new SqlParameter()
                {
                    ParameterName = "@Orientation",
                    Value = O

                };
                cmd2.Parameters.Add(paramO);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Your sexual orientation has been changed";
            }
        }

        protected void btnUpdateType_Click(object sender, EventArgs e)
        {
            String Type = "";
            String username = User.Identity.GetUserName();
            if (ShortT.Checked)
            {
                Type = "Short Term";
            }

            if (LongT.Checked)
            {
                Type = "Long Term";
            }

            if (Friends.Checked)
            {
                Type = "Friends";
            }

            int ID = 0;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetProfileByName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramUser);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["ID"]);
                }
                con.Close();

                SqlCommand cmd2 = new SqlCommand("spUpdateType", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = ID
                };
                cmd2.Parameters.Add(paramID);

                SqlParameter paramType = new SqlParameter()
                {
                    ParameterName = "@Type",
                    Value = Type
                };
                cmd2.Parameters.Add(paramType);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Your relationship type has been updated";
            }
        }

        protected void btnUpdateImage_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = ImageSearch.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            String username = User.Identity.GetUserName();
            int ID = 0;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetProfileByName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramUser);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["ID"]);
                }
                con.Close();
                Stream stream = postedFile.InputStream;
                BinaryReader binaryreader = new BinaryReader(stream);
                byte[] bytes = binaryreader.ReadBytes((int)stream.Length);

                SqlCommand cmd2 = new SqlCommand("spUpdateProfilePic", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = ID
                };
                cmd2.Parameters.Add(paramId);

                SqlParameter paramPic = new SqlParameter()
                {
                    ParameterName = "@ImageData",
                    Value = bytes
                };
                cmd2.Parameters.Add(paramPic);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                lblMessage.Text = "Your profile picture has been updated";
            }
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            String username = User.Identity.GetUserName();

            int ID = 0;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetProfileByName", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramUser);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["ID"]);
                }
                con.Close();

                SqlCommand cmd2 = new SqlCommand("spUpdatePassword ", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value=ID
                };
                cmd2.Parameters.Add(paramID);

                SqlParameter paramPass = new SqlParameter()
                {
                    ParameterName = "@Password",
                    Value=Password.Text
                };
                cmd2.Parameters.Add(paramPass);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

                UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                string GetIDPass = User.Identity.GetUserId();
                string PWord= Password.Text;
                userManager.RemovePassword(User.Identity.GetUserId());
                userManager.AddPassword(User.Identity.GetUserId(), Password.Text);
                lblMessage.Text = "Your password was successfully changed";
            }
        }
    }
}
