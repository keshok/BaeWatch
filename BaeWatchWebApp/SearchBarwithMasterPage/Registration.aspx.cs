using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace SearchBarwithMasterPage
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            String Username = txtUserName.Text;
            String Description = txtDescription.Text;
            String Interests = txtInterests.Text;
            String Password = txtPassword.Text;
            String Gender = "";
            String O = "";
            String Type = "";
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

            if (Strait.Checked)
            {
                O = "Strait";
            }

            if (Gay.Checked)
            {
                O = "Gay";
            }

            if (OtherOrientation.Checked)
            {
                O = "Other";
            }

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

            HttpPostedFile postedFile = ImageSearch.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
                fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".gif" ||
                Username != null || Description != null || Interests != null)
            {
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);

                var user = new IdentityUser() { UserName = txtUserName.Text };
                IdentityResult result = manager.Create(user, txtPassword.Text);

                if (result.Succeeded)
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryreader = new BinaryReader(stream);
                    byte[] bytes = binaryreader.ReadBytes((int)stream.Length);

                    string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("spCreateUserProfile", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter paramName = new SqlParameter()
                        {

                            ParameterName = "@Username",
                            Value = Username
                        };
                        cmd.Parameters.Add(paramName);

                        SqlParameter pass = new SqlParameter()
                        {
                            ParameterName = "@Password",
                            Value = Password
                        };
                        cmd.Parameters.Add(pass);

                        SqlParameter paramDesc = new SqlParameter()
                        {
                            ParameterName = "@Description",
                            Value = Description
                        };
                        cmd.Parameters.Add(paramDesc);

                        SqlParameter paramItrest = new SqlParameter()
                        {
                            ParameterName = "@Intrests",
                            Value = Interests
                        };
                        cmd.Parameters.Add(paramItrest);

                        SqlParameter paramO = new SqlParameter()
                        {
                            ParameterName = "@Orientation",
                            Value = O
                        };
                        cmd.Parameters.Add(paramO);

                        SqlParameter pType = new SqlParameter()
                        {
                            ParameterName = "@Type",
                            Value = Type
                        };
                        cmd.Parameters.Add(pType);

                        SqlParameter paramImageData = new SqlParameter()
                        {
                            ParameterName = "@ImageData",
                            Value = bytes
                        };
                        cmd.Parameters.Add(paramImageData);

                        SqlParameter paramGender = new SqlParameter()
                        {
                            ParameterName = "@Gender",
                            Value = Gender
                        };
                        cmd.Parameters.Add(paramGender);

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
                    }
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = string.Format("User {0} was created successfully!", user.UserName);

                    authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                    // Response.Redirect("~/Login.aspx");
                }

                else
                {
                    lblMessage.Text = result.Errors.FirstOrDefault();
                }
            }

            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Failed. Please try again";
            }
        }
        /*
        protected void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (chkShowPassword.Checked)
            {
                txtPassword.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txtPassword.TextMode = TextBoxMode.Password;
            }

        }
        */
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}