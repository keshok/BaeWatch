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
    public partial class DeleteConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            string username = User.Identity.GetUserName();
            string Password = "";
            int ID =0;
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
             {
                SqlCommand cmd = new SqlCommand("spDelete ", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd.Parameters.Add(paramName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd2 = new SqlCommand("spGetProfileByName", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUser = new SqlParameter()
                {
                    ParameterName = "@Username",
                    Value = username
                };
                cmd2.Parameters.Add(paramUser);
                con.Open();

                SqlDataReader rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {
                    Password = rdr["Password"].ToString();
                    ID = Convert.ToInt32(rdr["ID"]);
                }
                string UserID = ID.ToString();
                con.Close();

                UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
                var user = userManager.Find(username, Password);
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                string GetID = User.Identity.GetUserId();
                userManager.RemovePasswordAsync(GetID);
                authenticationManager.SignOut();
                Response.Redirect("~/StartScreen.aspx");
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Homepage.aspx");
        }
    }
}