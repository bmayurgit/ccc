using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CRMAPP1
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Image Image1;
		public SqlConnection con=new SqlConnection ("server=.;database=crm;uid=sa;pwd=;");
		
		public SqlCommand cmd=new SqlCommand();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{

			
			con.Open();
			cmd.Connection =con;
			cmd.CommandText ="select count(*) from crm_admin where adminname='"+TextBox1.Text+"' and pwd='"+TextBox2.Text+"'";
			object re=cmd.ExecuteScalar();
			con.Close();

			int chk=Convert.ToInt32(re);
   
			if(chk==1)
			{
				Response.Redirect("..//AdminModule/adminmain.aspx");
			}
			else
			{
				Response.Redirect("..//AdminModule/Invaliduidpwd.aspx");

			}

		
		}
	}
}
