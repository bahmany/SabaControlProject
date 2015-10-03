using System;
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
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["username"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            Session.Remove("AmareNafarat");
            Session.Remove("Machines");
            Session.Remove("Tools");
            Session.Remove("Toolsw");
            txt_tarikh.Text = new main_class().Convert_to_Shamsi(DateTime.Now);
            FarsiLibrary.Utils.PersianDate pd = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now);
            txt_rooz_name.Text = pd.LocalizedWeekDayName;
        }

        if (Session["modir_view_mode"] != null)
        {
            Session.Remove("AmareNafarat");
            Session.Remove("Machines");
            Session.Remove("Tools");
            Session.Remove("Toolsw");

            prepare_for_modir_editing(Convert.ToInt32(Session["modir_view_mode"].ToString()));
            txt_daraje_hararat.Enabled = false;
            txt_kamineh.Enabled = false;
            txt_pishine.Enabled = false;
            txt_takhalofat.Enabled = false;
            txt_tarikh.Enabled = false;
            txt_tozihate_modire_site.Enabled = false;
            drp_vaziate_javi.Enabled = false;

        }



    }





    protected void update_gv_amare_nafarat(MainDataModule.tmp_AmareNafaratDataTable ds)
    {
        DataTable dt = new DataTable();
        DataColumn dcol1 = new DataColumn("نام شرکت");
        dt.Columns.Add(dcol1);
        DataColumn _dcol1 = new DataColumn("تخصص");
        dt.Columns.Add(_dcol1);
        DataColumn dcol2 = new DataColumn("حاضرین");
        dt.Columns.Add(dcol2);
        DataColumn dcol5 = new DataColumn("شب کارها");
        dt.Columns.Add(dcol5);

        DataColumn dcol3 = new DataColumn("مرخصی ها");
        dt.Columns.Add(dcol3);
        DataColumn dcol4 = new DataColumn("غایبین");
        dt.Columns.Add(dcol4);
        foreach (DataRow dr in ds.Rows)
        {
            DataRow drr = dt.NewRow();
            drr["نام شرکت"] = dr["name_sherkat_string"];
            drr["تخصص"] = dr["skill_name"];
            drr["حاضرین"] = dr["tedad_hazerin"];
            drr["شب کارها"] = dr["shab_karha"];
            drr["مرخصی ها"] = dr["morekhasi"];
            drr["غایبین"] = dr["ghayeb"];
            dt.Rows.Add(drr);
            dt.AcceptChanges();
        }
        gv_amare_nafarat.DataSource = dt;
        gv_amare_nafarat.DataBind();
    }
    public void AddToAmareNafarat(int Name_Sherkat,int skill,string skillname, int TedadeHazerin, int shab_karha, int Morekhasi, int Ghyebat)
    {
        MainDataModule.tmp_AmareNafaratDataTable dt = new MainDataModule.tmp_AmareNafaratDataTable();
        if (Session["AmareNafarat"] != null)
        {
            dt = (MainDataModule.tmp_AmareNafaratDataTable)Session["AmareNafarat"];
        }
        DataRow dtr = dt.NewRow();
        dtr["name_sherkat"] = Name_Sherkat.ToString();
        dtr["tedad_hazerin"] = TedadeHazerin.ToString();
        dtr["morekhasi"] = Morekhasi.ToString();
        dtr["ghayeb"] = Ghyebat.ToString();
        dtr["shab_karha"] = shab_karha.ToString();
        dtr["id_skill"] = skill.ToString();
        dtr["skill_name"] = skillname;
        MainDataModuleTableAdapters.tbl_static_drp_company_namesTableAdapter nn = new tbl_static_drp_company_namesTableAdapter();
        dtr["name_sherkat_string"] = nn.GetCompnayName(Name_Sherkat);
        dt.Rows.Add(dtr);
        dt.AcceptChanges();
        Session["AmareNafarat"] = dt;



        updateAmareNafaratGrid();
    }
    protected void updateAmareNafaratGrid()
    {
        MainDataModule.tmp_AmareNafaratDataTable dt = new MainDataModule.tmp_AmareNafaratDataTable();
        if (Session["AmareNafarat"] != null)
        {
            dt = (MainDataModule.tmp_AmareNafaratDataTable)Session["AmareNafarat"];
        }

        update_gv_amare_nafarat(dt);
        
    }



    protected void update_machines(MainDataModule.tmp_MachinesDataTable ds)
    {
        DataTable dt = new DataTable();
        DataColumn dcol0 = new DataColumn("شرکت");
        dt.Columns.Add(dcol0);
        DataColumn dcol1 = new DataColumn("ماشین آلات");
        dt.Columns.Add(dcol1);
        DataColumn dcol2 = new DataColumn("روز");
        dt.Columns.Add(dcol2);
        DataColumn dcol3 = new DataColumn("شب");
        dt.Columns.Add(dcol3);
        DataColumn dcol4 = new DataColumn("غیر فعال");
        dt.Columns.Add(dcol4);
        DataColumn dcol5 = new DataColumn("ساعت");
        dt.Columns.Add(dcol5);
        foreach (DataRow dr in ds.Rows)
        {
            DataRow drr = dt.NewRow();
            drr["شرکت"] = new tbl_static_drp_company_namesTableAdapter().GetCompnayName(Convert.ToInt16(dr["sherkat"].ToString()));
            drr["ماشین آلات"] = dr["mashin_name"];
            drr["روز"] = dr["rooz"];
            drr["شب"] = dr["shab"];
            drr["غیر فعال"] = dr["gheire_faal"];
            drr["ساعت"] = dr["saat"];
            dt.Rows.Add(drr);
            dt.AcceptChanges();
        }
        gv_machines.DataSource = dt;
        gv_machines.DataBind();
    }
    protected void AddToMachines(int sherkat,int code_machine, string name_machine, int rooz, int shab, int gheire_faal, int saat)
    {
        MainDataModule.tmp_MachinesDataTable dt = new MainDataModule.tmp_MachinesDataTable();
        if (Session["Machines"] != null)
        {
            dt = (MainDataModule.tmp_MachinesDataTable)Session["Machines"];
        }
        DataRow dtr = dt.NewRow();
        dtr["sherkat"] = lb_companynames0.SelectedValue.ToString();
        dtr["machin_code"] = code_machine.ToString();
        MainDataModuleTableAdapters.tbl_static_drp_machine_namesTableAdapter nn = new tbl_static_drp_machine_namesTableAdapter();
        dtr["mashin_name"] = nn.GetMachineNames(code_machine);
        dtr["rooz"] = rooz.ToString();
        dtr["shab"] = shab.ToString();
        dtr["gheire_faal"] = gheire_faal.ToString();
        dtr["saat"] = saat.ToString();
        dt.Rows.Add(dtr);
        dt.AcceptChanges();
        Session["Machines"] = dt;
        update_machines(dt);
    }
    protected void updateMachinesGrid()
    {
        MainDataModule.tmp_MachinesDataTable dt = new MainDataModule.tmp_MachinesDataTable();
        if (Session["Machines"] != null)
        {
            dt = (MainDataModule.tmp_MachinesDataTable)Session["Machines"];
        }

        update_machines(dt);
    }





    protected void update_gv_tools(MainDataModule.tmp_ToolsDataTable ds)
    {
        DataTable dt = new DataTable();

        DataColumn dcol0 = new DataColumn("شرکت");
        dt.Columns.Add(dcol0);
        DataColumn dcol1 = new DataColumn("مصالح ورودی");
        dt.Columns.Add(dcol1);
        DataColumn dcol2 = new DataColumn("مقدار");
        dt.Columns.Add(dcol2);
        DataColumn dcol3 = new DataColumn("واحد");
        dt.Columns.Add(dcol3);

        foreach (DataRow dr in ds.Rows)
        {
            DataRow drr = dt.NewRow();
            drr["شرکت"] = dr["companyid"];
            drr["مصالح ورودی"] = dr["tool_name"];
            drr["مقدار"] = dr["meghdar"];
            drr["واحد"] = dr["vahed"];

            dt.Rows.Add(drr);
            dt.AcceptChanges();
        }
        gv_tools.DataSource = dt;
        gv_tools.DataBind();
    }
    public void AddToTools(int code_sherkat,int code_Tools, string name_tools, int meghdar, string vahed)
    {
        MainDataModule.tmp_ToolsDataTable dt = new MainDataModule.tmp_ToolsDataTable();
        if (Session["Tools"] != null)
        {
            dt = (MainDataModule.tmp_ToolsDataTable)Session["Tools"];
        }
        DataRow dtr = dt.NewRow();
        dtr["companyid"] = new tbl_static_drp_company_namesTableAdapter().GetCompnayName(code_sherkat);
        dtr["tool_code"] = code_Tools.ToString();
        dtr["tool_name"] = name_tools.ToString();
        dtr["meghdar"] = meghdar.ToString();
        dtr["vahed"] = vahed.ToString();
        dt.Rows.Add(dtr);
        dt.AcceptChanges();
        Session["Tools"] = dt;
        updateToolsGrid();
    }
    protected void updateToolsGrid()
    {
        MainDataModule.tmp_ToolsDataTable dt = new MainDataModule.tmp_ToolsDataTable();
        if (Session["Tools"] != null)
        {
            dt = (MainDataModule.tmp_ToolsDataTable)Session["Tools"];
        }

        update_gv_tools(dt);

    }




    protected void update_gv_toolsw(MainDataModule.tmp_ToolswDataTable ds)
    {
        DataTable dt = new DataTable();
        DataColumn dcol0 = new DataColumn("شرکت");
        dt.Columns.Add(dcol0);
        DataColumn dcol1 = new DataColumn("سازه های صنعتی");
        dt.Columns.Add(dcol1);
        DataColumn dcol2 = new DataColumn("فعالیت انجام شده");
        dt.Columns.Add(dcol2);
        DataColumn dcol3 = new DataColumn("نمره");
        dt.Columns.Add(dcol3);
        DataColumn dcol4 = new DataColumn("واحد");
        dt.Columns.Add(dcol4);

        foreach (DataRow dr in ds.Rows)
        {
            DataRow drr = dt.NewRow();
            drr["شرکت"] = dr["sherkat"];
            drr["سازه های صنعتی"] = dr["tool_name"];
            drr["فعالیت انجام شده"] = dr["faaliate_anjam_shode"];
            drr["نمره"] = dr["nomre"];
            drr["واحد"] = dr["vahed"];

            dt.Rows.Add(drr);
            dt.AcceptChanges();
        }
        gv_toolsw.DataSource = dt;
        gv_toolsw.DataBind();
    }
    public void AddToToolsw(int sherkat,int code_Toolsw, string name_toolsw,string faaliateAnjamShode ,float nomreh, string vahed)
    {
        MainDataModule.tmp_ToolswDataTable dt = new MainDataModule.tmp_ToolswDataTable();
        if (Session["Toolsw"] != null)
        {
            dt = (MainDataModule.tmp_ToolswDataTable)Session["Toolsw"];
        }
        DataRow dtr = dt.NewRow();
        dtr["sherkat"] = new tbl_static_drp_company_namesTableAdapter().GetCompnayName(Convert.ToInt16(sherkat.ToString()));
        dtr["tool_code"] = code_Toolsw.ToString();
        dtr["tool_name"] = name_toolsw.ToString();
        dtr["faaliate_anjam_shode"] = faaliateAnjamShode.ToString();
        dtr["nomre"] = nomreh.ToString();
        dtr["vahed"] = vahed.ToString();
        dt.Rows.Add(dtr);
        dt.AcceptChanges();
        Session["Toolsw"] = dt;
        updateToolswGrid();
    }
    protected void updateToolswGrid()
    {
        MainDataModule.tmp_ToolswDataTable dt = new MainDataModule.tmp_ToolswDataTable();
        if (Session["Toolsw"] != null)
        {
            dt = (MainDataModule.tmp_ToolswDataTable)Session["Toolsw"];
        }

        update_gv_toolsw(dt);

    }







    protected bool CheckDataToInsert()
    {
        bool ok = true;
        List<string> err_code = new List<string>();
        MainDataModule.tmp_AmareNafaratDataTable dt_amare_nafarat = new MainDataModule.tmp_AmareNafaratDataTable();
        MainDataModule.tmp_MachinesDataTable dt_machine = new MainDataModule.tmp_MachinesDataTable();
        MainDataModule.tmp_ToolsDataTable dt_tools = new MainDataModule.tmp_ToolsDataTable();
        MainDataModule.tmp_ToolswDataTable dt_toolsw = new MainDataModule.tmp_ToolswDataTable();


        if (Session["AmareNafarat"] != null)
        {
            dt_amare_nafarat = (MainDataModule.tmp_AmareNafaratDataTable)Session["AmareNafarat"];
        }
        else { ok = false; err_code.Add("لطفا اطلاعات آمار نفرات را تکمیل نمایید"); }
        if (Session["Machines"] != null)
        {
            dt_machine = (MainDataModule.tmp_MachinesDataTable)Session["Machines"];
        }
        else { ok = false; err_code.Add("لطفا اطلاعات ماشین آلات را تکمیل نمایید"); }
        if (Session["Tools"] != null)
        {
            dt_tools = (MainDataModule.tmp_ToolsDataTable)Session["Tools"];
        }
        else { ok = false; err_code.Add("لطفا اطلاعات مصالح ورودی را تکمیل نمایید"); }
        if (Session["Toolsw"] != null)
        {
            dt_toolsw = (MainDataModule.tmp_ToolswDataTable)Session["Toolsw"];
        }
        else { ok = false; err_code.Add("لطفا اطلاعات سازه های صنعتی را تکمیل نمایید"); }

        if (ok)
        {
            if (dt_amare_nafarat.Rows.Count == 0) { ok = false; err_code.Add("لطفا اطلاعات آمار نفرات را تکمیل نمایید"); }
            if (dt_machine.Rows.Count == 0) { ok = false; err_code.Add("لطفا اطلاعات ماشین آلات را تکمیل نمایید"); }
            if (dt_tools.Rows.Count == 0) { ok = false; err_code.Add("لطفا اطلاعات مصالح ورودی را تکمیل نمایید"); }
            if (dt_toolsw.Rows.Count == 0) { ok = false; err_code.Add("لطفا اطلاعات سازه های صنعتی را تکمیل نمایید"); }
        }
        if (!ok)
        {
            string err = "      ";
            for (int i = 0; i < err_code.Count; i++)
            {
                err += err_code[i]+ "     ";
            }
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "asdasd", "alert('در ورود اطلاعات دقیت کنید " + err + "')", true);
        }
        return ok;
    }

    protected void insert_data()
    {
        if (CheckDataToInsert())
        {
            MainDataModule.tmp_AmareNafaratDataTable dt_amare_nafarat = new MainDataModule.tmp_AmareNafaratDataTable();
            MainDataModule.tmp_MachinesDataTable dt_machine = new MainDataModule.tmp_MachinesDataTable();
            MainDataModule.tmp_ToolsDataTable dt_tools = new MainDataModule.tmp_ToolsDataTable();
            MainDataModule.tmp_ToolswDataTable dt_toolsw = new MainDataModule.tmp_ToolswDataTable();
            dt_amare_nafarat = (MainDataModule.tmp_AmareNafaratDataTable)Session["AmareNafarat"];
            dt_machine = (MainDataModule.tmp_MachinesDataTable)Session["Machines"];
            dt_tools = (MainDataModule.tmp_ToolsDataTable)Session["Tools"];
            dt_toolsw = (MainDataModule.tmp_ToolswDataTable)Session["Toolsw"];
            string username = Request.Cookies["username"].Value;
            username = new main_class().Decode(username);
            int userID = (int)new tbl_usersTableAdapter().getUserType(username);
     
            new tbl_staticsTableAdapter().Insert
                (DateTime.Now,
                Convert.ToDateTime(new main_class().Convert_to_Midaly(txt_tarikh.Text)),
                 FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(new main_class().Convert_to_Midaly(txt_tarikh.Text))).LocalizedWeekDayName,
                txt_shomareh_gozaresh.Text,
                Convert.ToInt16(drp_vaziate_javi.SelectedValue),
                Convert.ToInt16(txt_daraje_hararat.Text),
                Convert.ToInt16(txt_kamineh.Text),
                Convert.ToInt16(txt_pishine.Text),
                userID,
                txt_tozihate_modire_site.Text, txt_takhalofat.Text,0,0);
            int LastID = new tbl_staticsTableAdapter().GetLastID().Value;

            foreach (DataRow dr in dt_amare_nafarat.Rows)
            {
                new tbl_static_workersTableAdapter().Insert(
                    Convert.ToInt16(dr["name_sherkat"]),
                    Convert.ToInt16(dr["tedad_hazerin"]),
                    Convert.ToInt16(dr["morekhasi"]),
                    Convert.ToInt16(dr["ghayeb"]),
                    LastID, Convert.ToInt16(dr["shab_karha"]),
                    Convert.ToInt16(dr["id_skill"])
                    );
            }
            foreach (DataRow dr in dt_machine.Rows)
            {
                new tbl_static_machinesTableAdapter().Insert(
                    Convert.ToInt16(dr["machin_code"]),
                    Convert.ToInt16(dr["rooz"]),
                    Convert.ToInt16(dr["shab"]),
                    Convert.ToInt16(dr["gheire_faal"]),
                    Convert.ToInt16(dr["saat"]),
                    LastID,
                    Convert.ToInt16(dr["sherkat"])
                    );
            }
            foreach (DataRow dr in dt_tools.Rows)
            {
                new tbl_static_toolsTableAdapter().Insert(
                    Convert.ToInt16(dr["tool_code"]),
                    Convert.ToDouble(dr["meghdar"]),
                    dr["vahed"].ToString(),
                    LastID,
                    new tbl_static_drp_company_namesTableAdapter().getIDfromName(dr["companyid"].ToString()).Value);
            }
            foreach (DataRow dr in dt_toolsw.Rows)
            {
                new tbl_static_tools_expTableAdapter().Insert(
                    Convert.ToInt16(dr["tool_code"]),
                    dr["faaliate_anjam_shode"].ToString(),
                    Convert.ToDouble(dr["nomre"]),
                    dr["vahed"].ToString(),
                    LastID,
                    Convert.ToInt16(new tbl_static_drp_company_namesTableAdapter().getIDfromName(dr["sherkat"].ToString()).Value)
                    );
            }

            Session.Remove("AmareNafarat");
            Session.Remove("Machines");
            Session.Remove("Tools");
            Session.Remove("Toolsw");

           // ScriptManager.RegisterStartupScript(this.Page, GetType(), "alaOK", "alert('اطلاعات ورودی شما ثبت گردید'); window.location='" + Request.Url.AbsoluteUri + "'; ", true);
            Session["codeof"] = LastID.ToString();
            Response.Redirect("frm_dialy_report_ok_confirm.aspx");

        }

    }
    protected void insert_data_into_modir_view(int id)
    {
        if (CheckDataToInsert())
        {
            MainDataModule.tmp_AmareNafaratDataTable dt_amare_nafarat = new MainDataModule.tmp_AmareNafaratDataTable();
            MainDataModule.tmp_MachinesDataTable dt_machine = new MainDataModule.tmp_MachinesDataTable();
            MainDataModule.tmp_ToolsDataTable dt_tools = new MainDataModule.tmp_ToolsDataTable();
            MainDataModule.tmp_ToolswDataTable dt_toolsw = new MainDataModule.tmp_ToolswDataTable();
            dt_amare_nafarat = (MainDataModule.tmp_AmareNafaratDataTable)Session["AmareNafarat"];
            dt_machine = (MainDataModule.tmp_MachinesDataTable)Session["Machines"];
            dt_tools = (MainDataModule.tmp_ToolsDataTable)Session["Tools"];
            dt_toolsw = (MainDataModule.tmp_ToolswDataTable)Session["Toolsw"];
            string username = Request.Cookies["username"].Value;
            username = new main_class().Decode(username);
            int userID = (int)new tbl_usersTableAdapter().getUserType(username);
            new tbl_staticsTableAdapter().Insert
                (DateTime.Now,
                Convert.ToDateTime(new main_class().Convert_to_Midaly(txt_tarikh.Text)),
                 FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(new main_class().Convert_to_Midaly(txt_tarikh.Text))).LocalizedWeekDayName,
                txt_shomareh_gozaresh.Text,
                Convert.ToInt16(drp_vaziate_javi.SelectedValue),
                Convert.ToInt16(txt_daraje_hararat.Text),
                Convert.ToInt16(txt_kamineh.Text),
                Convert.ToInt16(txt_pishine.Text),
                userID,
                txt_tozihate_modire_site.Text, txt_takhalofat.Text,1,id);
            int LastID = new tbl_staticsTableAdapter().GetLastID().Value;

            foreach (DataRow dr in dt_amare_nafarat.Rows)
            {
                new tbl_static_workersTableAdapter().Insert(
                    Convert.ToInt16(dr["name_sherkat"]),
                    Convert.ToInt16(dr["tedad_hazerin"]),
                    Convert.ToInt16(dr["morekhasi"]),
                    Convert.ToInt16(dr["ghayeb"]),
                    LastID, Convert.ToInt16(dr["shab_karha"]),
                    Convert.ToInt16(dr["id_skill"])

                    );
            }
            foreach (DataRow dr in dt_machine.Rows)
            {
                new tbl_static_machinesTableAdapter().Insert(
                    Convert.ToInt16(dr["machin_code"]),
                    Convert.ToInt16(dr["rooz"]),
                    Convert.ToInt16(dr["shab"]),
                    Convert.ToInt16(dr["gheire_faal"]),
                    Convert.ToInt16(dr["saat"]),
                    LastID,
                    Convert.ToInt16(dr["sherkat"])
                    );
            }
            foreach (DataRow dr in dt_tools.Rows)
            {
                new tbl_static_toolsTableAdapter().Insert(
                    Convert.ToInt16(dr["tool_code"]),
                    Convert.ToDouble(dr["meghdar"]),
                    dr["vahed"].ToString(),
                    LastID,
                    Convert.ToInt16(dr["companyid"]));
            }
            foreach (DataRow dr in dt_toolsw.Rows)
            {
                new tbl_static_tools_expTableAdapter().Insert(
                    Convert.ToInt16(dr["tool_code"]),
                    dr["faaliate_anjam_shode"].ToString(),
                    Convert.ToDouble(dr["nomre"]),
                    dr["vahed"].ToString(),
                    LastID,
                    Convert.ToInt16(dr["sherkat"])
                    );
            }
            Session.Remove("AmareNafarat");
            Session.Remove("Machines");
            Session.Remove("Tools");
            Session.Remove("Toolsw");
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "alaOK1", "alert('کد ثبت   " + new tbl_staticsTableAdapter().getFinalRecord().Value.ToString() + "');alert('اطلاعات ورودی شما ثبت گردید'); window.location='" + Request.Url.AbsoluteUri + "'; ", true);
        }
        Session.Remove("modir_view_mode");
    }






    protected void btn_ok_amare_nafarat_Click(object sender, EventArgs e)
    {
        AddToAmareNafarat(
            Convert.ToInt16(lb_companynames.SelectedValue.ToString()),
            Convert.ToInt16(lb_skill_name.SelectedValue.ToString()),
lb_skill_name.SelectedItem.Text.ToString(),

            Convert.ToInt16(txt_tedade_hazerin.Text) ,
            Convert.ToInt16(txt_shabkarha.Text), 
            Convert.ToInt16(txt_morekhasi.Text.ToString()), 
            Convert.ToInt16(txt_ghayeb.Text));
    }
    protected void UpdatePanel1_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MainDataModule.tmp_AmareNafaratDataTable dt = new MainDataModule.tmp_AmareNafaratDataTable();
        if (Session["AmareNafarat"] != null)
        {
            dt = (MainDataModule.tmp_AmareNafaratDataTable)Session["AmareNafarat"];
        }
        string str1 = "";
        string str2 = "";

        foreach (DataRow dr in dt.Rows)
        {
            str1 = dr["name_sherkat_string"].ToString();
            str2 = (sender as LinkButton).ToolTip;
            str1.Trim();
            str2.Trim();


            if (str1.Equals(str2))
            {
                dt.Rows.Remove(dr);
                dt.AcceptChanges();
                break;
            }
        }
        Session["AmareNafarat"] = dt;
        updateAmareNafaratGrid();
  

    }
    protected void UpdatePanel1_PreRender(object sender, EventArgs e)
    {
      
    }
    protected void ok_machines_Click(object sender, EventArgs e)
    {
        AddToMachines(
            Convert.ToInt16(lb_companynames0.SelectedValue.ToString()),
            Convert.ToInt16(lb_name_machine.SelectedValue), 
            lb_name_machine.SelectedItem.Text, 
            Convert.ToInt16(txt_rooz.Text), 
            Convert.ToInt16(txt_shab.Text), 
            Convert.ToInt16(txt_gheire_faal.Text), 
            Convert.ToInt16(txt_saat.Text)
            
            );

    }
    protected void lb_machine_Click(object sender, EventArgs e)
    {
    }


    protected void lb_del_machine_Click(object sender, EventArgs e)
    {
        MainDataModule.tmp_MachinesDataTable dt = new MainDataModule.tmp_MachinesDataTable();
        if (Session["Machines"] != null)
        {
            dt = (MainDataModule.tmp_MachinesDataTable)Session["Machines"];
        }
        string str1 = "";
        string str2 = "";

        foreach (DataRow dr in dt.Rows)
        {
            str1 = dr["mashin_name"].ToString();
            str2 = (sender as LinkButton).ToolTip;
            str1.Trim();
            str2.Trim();


            if (str1.Equals(str2))
            {
                dt.Rows.Remove(dr);
                dt.AcceptChanges();
                Session["Machines"] = dt;
                updateMachinesGrid();
                break;
            }
        }
    }
    protected void lb_del_machine0_Click(object sender, EventArgs e)
    {
        MainDataModule.tmp_ToolsDataTable dt = new MainDataModule.tmp_ToolsDataTable();
        if (Session["Tools"] != null)
        {
            dt = (MainDataModule.tmp_ToolsDataTable)Session["Tools"];
        }
        string str1 = "";
        string str2 = "";

        foreach (DataRow dr in dt.Rows)
        {
            str1 = dr["tool_name"].ToString();
            str2 = (sender as LinkButton).ToolTip;
            str1.Trim();
            str2.Trim();


            if (str1.Equals(str2))
            {
                dt.Rows.Remove(dr);
                dt.AcceptChanges();
                Session["Tools"] = dt;
                updateToolsGrid();
                break;
            }
        }
    }
    protected void ok_tools_Click(object sender, EventArgs e)
    {
        AddToTools(
            Convert.ToInt16(lb_companynames1.SelectedValue),
            Convert.ToInt16(lb_tools_name.SelectedValue),
            lb_tools_name.SelectedItem.Text,
            Convert.ToInt16(txt_meghdar.Text),
            txt_vahed.Text
            );
    }
    protected void lb_del_machine1_Click(object sender, EventArgs e)
    {
        MainDataModule.tmp_ToolswDataTable dt = new MainDataModule.tmp_ToolswDataTable();
        if (Session["Toolsw"] != null)
        {
            dt = (MainDataModule.tmp_ToolswDataTable)Session["Toolsw"];
        }
        string str1 = "";
        string str2 = "";

        foreach (DataRow dr in dt.Rows)
        {
            str1 = dr["tool_name"].ToString();
            str2 = (sender as LinkButton).ToolTip;
            str1.Trim();
            str2.Trim();


            if (str1.Equals(str2))
            {
                dt.Rows.Remove(dr);
                dt.AcceptChanges();
                Session["Toolsw"] = dt;
                updateToolswGrid();
                break;
            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        AddToToolsw(
            Convert.ToInt16(lb_companynames2.SelectedValue),
            -1,
            "طبق توضیحات",
            txt_sharh.Text,
            (float)Convert.ToDouble(txt_emtiaz.Text),
            txt_emtiaz_vahed.Text);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        if (CheckBox1.Checked)
        {
            if (Session["modir_view_mode"] != null)
            {
                insert_data_into_modir_view(Convert.ToInt32(Session["modir_view_mode"].ToString()));
                Response.Redirect("frm_frm_view_modir_site_all_records.aspx");
            }
            else
            {
                insert_data();
            }
        }

    }
    protected void txt_tozihate_modire_site_TextChanged(object sender, EventArgs e)
    {

    }


    public void prepare_for_modir_editing(int id)
    {
        MainDataModuleTableAdapters.tbl_staticsTableAdapter sta = new tbl_staticsTableAdapter();
        foreach (DataRow dr in sta.GetDataByID(id).Rows)
        {

//            Session.Remove("AmareNafarat");
//            Session.Remove("Machines");
//            Session.Remove("Tools");
//            Session.Remove("Toolsw");


            txt_daraje_hararat.Text = dr["s_daraje_hararat"].ToString();
            txt_kamineh.Text = dr["s_kamineh"].ToString();
            txt_pishine.Text = dr["s_pishine"].ToString();
            txt_takhalofat.Text = dr["s_takhalofat"].ToString();
            txt_tarikh.Text = new main_class().Convert_to_Shamsi(Convert.ToDateTime(dr["s_tarikh"].ToString()));
            txt_tozihate_modire_site.Text = dr["s_tozihate_modire_site"].ToString();
            drp_vaziate_javi.SelectedValue = dr["s_vaziate_javi"].ToString();



            tbl_static_workersTableAdapter tbl1 = new tbl_static_workersTableAdapter();
            foreach (DataRow dr1 in tbl1.GetDataBy_Statics_ID(id))
            {
                AddToAmareNafarat(
                    (int)dr1["sw_name_sherkat_link"],
                    (int)dr1["sw_carieer_link"],
                    new tbl_static_workers_detail_carieerTableAdapter().getCarieerName((int)dr1["sw_carieer_link"]),
                    (int)dr1["sw_tedade_hazerin"], 
                    (int)dr1["sw_tedade_morekhasi"], 
                    (int)dr1["sw_tedade_ghaiebin"], 
                    (int)dr1["sw_tedade_shab_karha"]);
            }



            tbl_static_machinesTableAdapter tbl2 = new tbl_static_machinesTableAdapter();
            foreach (DataRow dr1 in tbl2.GetDataBy_sm_link_to_tbl_statics(id))
            {
                AddToMachines(
                    (int)dr1["sm_link_to_company"],
                    (int)dr1["sm_name_machine_link"],
                    new tbl_static_drp_machine_namesTableAdapter().GetMachineNames((int)dr1["sm_name_machine_link"]),
                    (int)dr1["sm_tedata_dar_rooz"], 
                    (int)dr1["sm_shab"],
                    (int)dr1["sm_gheire_faal"], 
                    (int)dr1["saat"]);
            }



            tbl_static_toolsTableAdapter tbl3 = new tbl_static_toolsTableAdapter();
            foreach (DataRow dr1 in tbl3.GetDataBy_st_link_to_tbl_static(id))
            {
                AddToTools(
                    (int)dr1["st_link_to_company"],
                    (int)dr1["st_name_masaleh_link"],
                    new tbl_static_drp_tools_namesTableAdapter().GetToolName((int)dr1["st_name_masaleh_link"]),
                    Convert.ToInt32(dr1["st_meghdar"]),
                    dr1["st_vahed"].ToString());
            }

            tbl_static_tools_expTableAdapter tbl4 = new tbl_static_tools_expTableAdapter();
            foreach (DataRow dr1 in tbl4.GetDataBy_stw_link_to_statics(id))
            {
                AddToToolsw(Convert.ToInt32(dr1["sw_carieer_link"]),
                    Convert.ToInt32(dr1["stw_name_sazeh_link"]),
                    new tbl_static_drp_toolsw_nameTableAdapter().GetToolWName((int)dr1["stw_name_sazeh_link"]),
                    (string)dr1["stw_faaliate_anjam_shode"],
                    (float)Convert.ToDouble(dr1["stw_meghdare_ekhtesasi"]),
                    (string)dr1["stw_vahed"]);
            }


        }
        Session["modir_view_mode"] = id.ToString();
    }


    protected void Button6_Click(object sender, EventArgs e)
    {
        
        
    }
    protected void lb_companynames_SelectedIndexChanged(object sender, EventArgs e)
    {
        lb_skill_name.DataBind();
    }
}
