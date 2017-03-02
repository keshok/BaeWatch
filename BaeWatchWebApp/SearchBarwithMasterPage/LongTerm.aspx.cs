using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Configuration;

namespace SearchBarwithMasterPage
{
    public partial class LongTerm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Long ="Long Term";
            GetData(Long);

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserProfile.aspx?ID=" + ((LinkButton)sender).Text);

        }

        private void GetData(string Type)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetType", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter searchParameter = new SqlParameter("@Type", Type);
                cmd.Parameters.Add(searchParameter);
                con.Open();

                HomepageGridView.DataSource = cmd.ExecuteReader();
                HomepageGridView.DataBind();
                con.Close();
            }
        }
    }
}