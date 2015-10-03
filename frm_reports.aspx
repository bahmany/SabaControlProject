<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_reports.aspx.cs" Inherits="frm_reports" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="Telerik.Charting" namespace="Telerik.Charting" tagprefix="telerik" %>

<%@ Register src="frm_obj_report_TotalView.ascx" tagname="frm_obj_report_TotalView" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
    <telerik:RadStyleSheetManager runat="server">
    </telerik:RadStyleSheetManager>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    
        <br />
        
        <br />
 
        <br />
        <br />
        <br />
        
        <br />
      
        <br />
            <table  class="main_table">
    <tr>
    <td>
              <br />
              منحنی حضور پرسنل در سایت&nbsp; <br />
              <br />
              <table>
                  <tr>
                      <td>
                          از</td>
                      <td>
                          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                      </td>
                      <td>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; تا &nbsp;</td>
                      <td>
                          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td colspan="4">
                          &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <br />
                        <br />
              <table>
                  <tr>
                      <td>
                          <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                              Text="مرور کلی اطلاعات جداول" />
                      </td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                  </tr>
              </table>
              <br />
              <asp:Panel ID="Panel2" runat="server">
                  <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                      BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                      CellSpacing="1" GridLines="None" Width="100%">
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                      <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                  </asp:GridView>
              </asp:Panel>
                        <br />
                        
                        <br />
                        &nbsp;</td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
