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
    public partial class SearchBar : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.SearchButton.Click +=new EventHandler(SearchButton_Click);
        }

       protected void SearchButton_Click(object sender, EventArgs e)
        {
            GetData(Master.SearchTerm);
        }
       protected void LinkButton1_Click(object sender, EventArgs e)
       {
           Response.Redirect("~/UserProfile.aspx?ID=" + ((LinkButton)sender).Text);

       }

        protected void Page_Load(object sender, EventArgs e)
        {
            String search = Request.QueryString.ToString();
            if (!IsPostBack)
            {
                GetData(search);
            }

        }

        private void GetData(string searchTerm)
        {
           string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
           using(SqlConnection con = new SqlConnection(cs))
           {
               SqlCommand cmd = new SqlCommand("spSearch", con);
               cmd.CommandType = CommandType.StoredProcedure;

               SqlParameter searchParameter = new SqlParameter("@SearchTerm",searchTerm ?? string.Empty);
               cmd.Parameters.Add(searchParameter);
               con.Open();
               GridView1.DataSource = cmd.ExecuteReader();
               GridView1.DataBind();
            }
        }
    }
}