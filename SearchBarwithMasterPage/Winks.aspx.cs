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
    public partial class Winks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = User.Identity.GetUserName();
            GetData(name);

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserProfile.aspx?ID=" + ((LinkButton)sender).Text);

        }

        private void GetData(string name)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("getWinks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter searchParameter = new SqlParameter("@Receiver", name ?? string.Empty);
                cmd.Parameters.Add(searchParameter);
                con.Open();

                WinkList.DataSource = cmd.ExecuteReader();
                WinkList.DataBind();
            }
        }

        protected void btnClearWinks_Click(object sender, EventArgs e)
        {
            string name = User.Identity.GetUserName();
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spClearWinks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter searchParameter = new SqlParameter("@Reciver", name);
                cmd.Parameters.Add(searchParameter);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/Winks.aspx");
            }
        }
    }
}