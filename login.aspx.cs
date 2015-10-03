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
using MainDataModuleTableAdapters;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void first_login_redirector(string username)
    {
        int u_t = Convert.ToInt16(new tbl_usersTableAdapter().getUserType(username).Value.ToString());
        if (u_t == 1) { Response.Redirect("Default.aspx"); } // تهیه کننده
        if (u_t == 2) { Response.Redirect("frm_frm_view_all_records.aspx"); } // تائید کننده
        if (u_t == 3) { Response.Redirect("frm_frm_view_modir_site_all_records.aspx"); } // دفتر تهران مشاهده کننده
        if (u_t == 4) { Response.Redirect("Default.aspx"); } // دفتر تهران مشاهده کننده
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie hc1 = new HttpCookie("username",new main_class().Encode(TextBox1.Text));
        HttpCookie hc2 = new HttpCookie("password", new main_class().Encode(TextBox2.Text));

        if (new main_class().is_user_valid(TextBox1.Text, TextBox2.Text))
        {
            Response.Cookies.Add(hc1);
            Response.Cookies.Add(hc2);
            first_login_redirector(TextBox1.Text);
        }
    }
}
