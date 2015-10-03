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

public partial class frm_frm_view_modir_site_all_records : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string generate_string_for_popup_windows(int code)
    {
        string rt = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;;
        if (code == 1) { rt += "/frm_frm_view_all_records_AmareNafarat.aspx"; }
        if (code == 2) { rt += "/frm_frm_view_all_records_MachineAlat.aspx"; }
        if (code == 3) { rt += "/frm_frm_view_all_records_MasaleheVoroodi.aspx"; }
        if (code == 4) { rt += "/frm_frm_view_all_records_sazeha.aspx"; }
        if (rt != "")
        {
            
        }
        return rt;

    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //(e.Row.Cells[12].Controls.FindControl("LinkButton2") as LinkButton).Text = "ddddddddddddddddddddd";
    }
    protected void Panel1_DataBinding(object sender, EventArgs e)
    {
        if ( (sender as Panel).ToolTip == "2" )
        {
            (sender as Panel).Visible = true;
        }
        else { (sender as Panel).Visible = false; }
    }
    protected void Panel1_Load(object sender, EventArgs e)
    {
  
    }
    protected void Panel2_DataBinding(object sender, EventArgs e)
    {
        if ((sender as Panel).ToolTip.Equals("3"))
        {
            (sender as Panel).Visible = true;
        }
        else { (sender as Panel).Visible = false; }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string username = Request.Cookies["username"].Value;
        username = new main_class().Decode(username);
        int userID = (int)new tbl_usersTableAdapter().getUserType(username);
        new MainDataModuleTableAdapters.rbl_statics_okTableAdapter().Insert(
            Convert.ToInt32((sender as LinkButton).ToolTip),
            3, userID);
        GridView1.DataBind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string username = Request.Cookies["username"].Value;
        username = new main_class().Decode(username);
        int userID = (int)new tbl_usersTableAdapter().getUserType(username);

        new MainDataModuleTableAdapters.rbl_statics_okTableAdapter().Insert(
            Convert.ToInt32((sender as LinkButton).ToolTip),
            4, userID);
        GridView1.DataBind();
    }
    protected void Panel3_DataBinding(object sender, EventArgs e)
    {
        if ((sender as Panel).ToolTip.Equals("4"))
        {
            (sender as Panel).Visible = true;
        }
        else { 
            (sender as Panel).Visible = false;
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Session["modir_view_mode"] = (sender as LinkButton).ToolTip;
        Response.Redirect("default.aspx");
    }
}
