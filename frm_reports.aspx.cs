using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public partial class frm_reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {






    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        CallData();




    }

    public void CallData()
    {
        DateTime _to = Convert.ToDateTime(new main_class().Convert_to_Midaly(TextBox2.Text));
        DateTime from = Convert.ToDateTime(new main_class().Convert_to_Midaly(TextBox1.Text));

        SqlConnection sc = new SqlConnection(new main_class().get_connection_string());
        sc.Open();
        SqlCommand scm = new SqlCommand("select * from dbo.func_get_total_view('" + from.ToString("yyyy/MM/dd") + "','" + _to.ToString("yyyy/MM/dd") + "')", sc);
        SqlDataReader sqldr = scm.ExecuteReader();
        GridView1.DataSource = sqldr;
        GridView1.DataBind();
        sqldr.Close();
        sc.Close();
    }

}
