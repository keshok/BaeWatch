using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SearchBarwithMasterPage
{
    public partial class straight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Orientaion = "Strait";
            GetData(Orientaion);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserProfile.aspx?ID=" + ((LinkButton)sender).Text);
        }

        private void GetData(string Orientation)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetOrietation", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter searchParameter = new SqlParameter("@Orientation", Orientation);
                cmd.Parameters.Add(searchParameter);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
            }
        }
    }
}