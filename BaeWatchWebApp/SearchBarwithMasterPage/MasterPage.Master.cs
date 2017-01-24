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

namespace SearchBarwithMasterPage
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        public static string passingText;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public Panel SearchPanel
        { 
         get 
         {
             return this.panelSearch;
         }
        }

        public Button SearchButton
        {
            get
            {
                return this.btnSearch;
            }
        }

        public string SearchTerm
        {

            get 
            {
                return this.txtSearch.Text;
            }    
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~/SearchBar.aspx?"+txtSearch.Text); 
            
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Homepage.aspx");
        }

        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void Friends_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/FriendsListaspx.aspx");
        }

        protected void btnYourProfile_Click(object sender, EventArgs e)
        {
            string username = HttpContext.Current.User.Identity.GetUserName();
            int ID=0;
             string cs = ConfigurationManager.ConnectionStrings["BaewatchConnectionString"].ConnectionString;
             using (SqlConnection con = new SqlConnection(cs))
             {
                 SqlCommand cmd = new SqlCommand("spGetProfileByName",con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 SqlParameter paramUser = new SqlParameter()
                 {
                     ParameterName = "@Username",
                     Value = username
                 };
                 cmd.Parameters.Add(paramUser);
                 con.Open();
                 SqlDataReader rdr = cmd.ExecuteReader();
                 while(rdr.Read())
                 {
                     ID = Convert.ToInt32(rdr["ID"]);
                 }
                 string UserID = ID.ToString();
                 con.Close();
                  Response.Redirect("~/UserProfile.aspx?ID=" + UserID);

             }
        }

        protected void btnSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccountSettings.aspx");
        }

        protected void btnWinks_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Winks.aspx");
            
        }

        protected void btnNotfications_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Notifications.aspx");
        }

    }
}