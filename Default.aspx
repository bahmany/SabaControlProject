<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="PersianDateValidator" namespace="BehooControls" tagprefix="cc1" %>

<%@ Register src="WebUserControl_MenuAndHeader.ascx" tagname="WebUserControl_MenuAndHeader" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            font-size: 18pt;
        }
    </style>
</head>
<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
<body dir="rtl" style="font-family: tahoma; font-size: 12px">
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    
    <table  class="main_table">
    <tr>
    <td>
    <table>
            <tr>
                <td class="td_devider">
                    <uc1:WebUserControl_MenuAndHeader ID="WebUserControl_MenuAndHeader1" 
                        runat="server" />
                    <b>
                    <br class="style1" />
                    <font size="5">گزارشات روزانه                     <br />
                    <br />
                    </font></b></td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                تاریخ
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="txt_tarikh" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <cc1:PersianDateValidator ID="PersianDateValidator1" runat="server" 
                                    ControlToValidate="txt_tarikh" ErrorMessage="اصلاح" 
                                    FirstWhat="FirstYear"></cc1:PersianDateValidator>
                            </td>
                            <td>
                                روز<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txt_rooz_name" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                            <td>
                                شماره</td>
                            <td>
                                            وضعیت جوی
                                        </td>
                            <td>
                                ددرجه حرارت</td>
                            <td>
                                کمینه</td>
                            <td>
                                پشینه</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txt_tarikh" runat="server" Width="86px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_rooz_name" runat="server" Width="86px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_shomareh_gozaresh" runat="server" Width="86px"></asp:TextBox>
                            </td>
                            <td>
                                            <asp:DropDownList ID="drp_vaziate_javi" runat="server" >
                                                <asp:ListItem Selected="True" Value="1">آفتابی</asp:ListItem>
                                                <asp:ListItem Value="2">ابری</asp:ListItem>
                                                <asp:ListItem Value="3">بارانی</asp:ListItem>
                                                <asp:ListItem Value="4">وزش باد</asp:ListItem>
                                            </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_daraje_hararat" runat="server" Width="86px">0</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_kamineh" runat="server" Width="86px">0</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_pishine" runat="server" Width="86px">0</asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="td_devider">
                    <img alt="" src="img/h_divider.jpg" style="width: 653px; height: 17px" /></td>
            </tr>
            <tr>
                <td>
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server" onload="UpdatePanel1_Load" 
                        onprerender="UpdatePanel1_PreRender">
                     <ContentTemplate>
                                        
                                  
                    <table>
                        <tr>
                            <td>
                                <b>آمار نفرات </b>
                                
                                

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td rowspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <table>
                                                <tr>
                                                    <td>
                                                        نام شرکت</td>
                                                    <td>
                                                        تخصص</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ListBox ID="lb_companynames" runat="server" AutoPostBack="True" 
                                                            DataSourceID="ObjectDataSource2" DataTextField="sdcn_name" 
                                                            DataValueField="sdcn_id" 
                                                            onselectedindexchanged="lb_companynames_SelectedIndexChanged"></asp:ListBox>
                                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                                                            TypeName="MainDataModuleTableAdapters.tbl_static_drp_company_namesTableAdapter">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="lb_skill_name" runat="server" DataSourceID="ObjectDataSource3" 
                                                            DataTextField="swdc_name" DataValueField="swdc_id"></asp:ListBox>
                                                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBy" 
                                                            TypeName="MainDataModuleTableAdapters.tbl_static_workers_detail_carieerTableAdapter">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="lb_companynames" Name="companyID" 
                                                                    PropertyName="SelectedValue" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                        
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        
                                        
                                        
                                        </td>
                                        <td>
                                            تعداد حاضرین&nbsp;</td>
                                        <td>
                                            شب کارها</td>
                                        <td>
                                            مرخصی</td>
                                        <td>
                                            غایب</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txt_tedade_hazerin" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_shabkarha" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_morekhasi" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_ghayeb" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_ok_amare_nafarat" runat="server" Text="+" 
                                                onclick="btn_ok_amare_nafarat_Click" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                AssociatedUpdatePanelID="UpdatePanel1">
                                                <ProgressTemplate>
                                                    لطفا صبر کنید ...
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:ObjectDataSource ID="ods_amarenafarat" runat="server" 
                                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                                                TypeName="MainDataModuleTableAdapters.tbl_static_drp_company_namesTableAdapter">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                      
                                    <asp:GridView ID="gv_amare_nafarat" runat="server" BackColor="White" 
                             BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                             GridLines="Vertical" Width="100%">
                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                                        ToolTip='<%# Eval("نام شرکت") %>'>حذف</asp:LinkButton>
                                                    &nbsp;
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                         </asp:GridView>
                      
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="td_devider">
                            <img alt="" src="img/h_divider.jpg" style="width: 653px; height: 17px" /></td>
            </tr>
            <tr>
                <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                           
          
                    <table>
                        <tr>
                            <td>
                                <b>ماشین </b><b>آلات</b></td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            نام شرکت </td>
                                        <td>
                                            نام ماشین</td>
                                        <td>
                                            تعداد در روز</td>
                                        <td>
                                            شب</td>
                                        <td>
                                            غیر فعال
                                        </td>
                                        <td>
                                            ساعت</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="lb_companynames0" runat="server" AutoPostBack="True" 
                                                DataSourceID="ObjectDataSource2" DataTextField="sdcn_name" 
                                                DataValueField="sdcn_id" 
                                                onselectedindexchanged="lb_companynames_SelectedIndexChanged"></asp:ListBox>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lb_name_machine" runat="server" DataSourceID="ods_machines" 
                                                DataTextField="sdmn_name" DataValueField="sdmn_id"></asp:ListBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_rooz" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_shab" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_gheire_faal" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_saat" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="ok_machines" runat="server" Text="+" 
                                                onclick="ok_machines_Click" />
                                        </td>
                                        <td>
                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td colspan="6">
                                            <asp:ObjectDataSource ID="ods_machines" runat="server" 
                                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                                                TypeName="MainDataModuleTableAdapters.tbl_static_drp_machine_namesTableAdapter">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    
                          
                                                    <asp:GridView ID="gv_machines" runat="server" BackColor="White" 
                                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                                        GridLines="Vertical" Width="100%">
                                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lb_del_machine" runat="server" 
                                                                        onclick="lb_del_machine_Click" ToolTip='<%# Eval("ماشین آلات") %>'>حذف</asp:LinkButton>
                                                                    &nbsp;
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                                    </asp:GridView>
                    
                          
                                                </ContentTemplate>
                                            </asp:UpdatePanel>   
                </td>
            </tr>
            <tr>
           
                
               
            
                <td class="td_devider">
                       <img alt="" src="img/h_divider.jpg" style="width: 653px; height: 17px" /></td>
             
         
            </tr>
            <tr>
           
                
               
            
                <td>
                       <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
         
                
                    <table>
                        <tr>
                            <td>
                                <b>مصالح ورودی</b></td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            نام شرکت</td>
                                        <td>
                                            نام</td>
                                        <td>
                                            مقدار</td>
                                        <td>
                                            واحد</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="lb_companynames1" runat="server" AutoPostBack="True" 
                                                DataSourceID="ObjectDataSource2" DataTextField="sdcn_name" 
                                                DataValueField="sdcn_id" 
                                                onselectedindexchanged="lb_companynames_SelectedIndexChanged"></asp:ListBox>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lb_tools_name" runat="server" DataSourceID="ObjectDataSource1" 
                                                DataTextField="sdtn_name" DataValueField="sdtn_id"></asp:ListBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_meghdar" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_vahed" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="ok_tools" runat="server" Text="+" onclick="ok_tools_Click" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td colspan="6">
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                                                TypeName="MainDataModuleTableAdapters.tbl_static_drp_tools_namesTableAdapter">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>   
                    
                     <asp:GridView ID="gv_tools" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Width="100%">
                         <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                         <Columns>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lb_del_machine0" runat="server" 
                                         onclick="lb_del_machine0_Click" ToolTip='<%# Eval("مصالح ورودی") %>'>حذف</asp:LinkButton>
                                     &nbsp;
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                         <AlternatingRowStyle BackColor="#DCDCDC" />
                    </asp:GridView>
                    
                     </ContentTemplate>
                </asp:UpdatePanel>
                </td>
             
         
            </tr>
            <tr>
                <td class="td_devider">
                
                    <img alt="" src="img/h_divider.jpg" style="width: 653px; height: 17px" /></td>
            </tr>
            <tr>
                <td>
                
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                         <table>
                        <tr>
                            <td>
                                <b>شرح سازه های صنعتی</b></td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            نام شرکت </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            فعالیت انجام شده</td>
                                        <td>
                                            مقدار اختصاصی</td>
                                        <td>
                                            واحد</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="lb_companynames2" runat="server" AutoPostBack="True" 
                                                DataSourceID="ObjectDataSource2" DataTextField="sdcn_name" 
                                                DataValueField="sdcn_id" 
                                                onselectedindexchanged="lb_companynames_SelectedIndexChanged"></asp:ListBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                <asp:TextBox ID="txt_sharh" runat="server" Width="296px">0</asp:TextBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_emtiaz" runat="server" Width="86px">0</asp:TextBox>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txt_emtiaz_vahed" runat="server" Width="70px">امتیاز</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button4" runat="server" Text="+" onclick="Button4_Click" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td colspan="7">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>    
                         <asp:GridView ID="gv_toolsw" runat="server" BackColor="White" 
                             BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                             GridLines="Vertical" Width="100%">
                             <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                             <Columns>
                                 <asp:TemplateField>
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lb_del_machine1" runat="server" 
                                             onclick="lb_del_machine1_Click" ToolTip='<%# Eval("سازه های صنعتی") %>'>حذف</asp:LinkButton>
                                         &nbsp;
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                             <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                             <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                             <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                             <AlternatingRowStyle BackColor="#DCDCDC" />
                         </asp:GridView>
                    </ContentTemplate>
                    </asp:UpdatePanel>
           
                
                
                </td>
            </tr>
            <tr>
                <td class="td_devider">
                
                    <img alt="" src="img/h_divider.jpg" style="width: 653px; height: 17px" /></td>
            </tr>
            <tr>
                <td>
                
                    <b>توضیحات                          <br />
                    </b>
                    <br />
                    <asp:TextBox ID="txt_tozihate_modire_site" runat="server" Height="57px" TextMode="MultiLine" 
                        Width="701px" ontextchanged="txt_tozihate_modire_site_TextChanged"></asp:TextBox>
                    <br />
           
                
                
                </td>
            </tr>
            <tr>
                <td>
                    <b>تخلفات</b> <b>&nbsp;<br />
                    </b>
                    <br />
                    <asp:TextBox ID="txt_takhalofat" runat="server" Height="57px" TextMode="MultiLine" 
                        Width="701px" ontextchanged="txt_tozihate_modire_site_TextChanged"></asp:TextBox>
                    <br />
           
                
                
                                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" 
                        Text="اطلاعات وارد شده طبق فرم های تائید شده بوسیله ی پیمانکاران، مشاورین و مدیر سایت مبیاشد." />
                    <br />
                    کد ثبت را یادداشت نموده و تا جهت پیگیری از آن استفاده نمایید.</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                        Text="ثبت و ارسال گزارش روزانه" />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            </table>
    </td>
    </tr>
    </table>
    
        
    
    </div>
    </form>
</body>
</html>
