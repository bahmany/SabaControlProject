<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_frm_view_all_records_AmareNafarat.aspx.cs" Inherits="frm_frm_view_all_records_AmareNafarat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
<body dir="rtl">
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            DataSourceID="SqlDataSource1" GridLines="Vertical" Width="100%">
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="نام شرکت" HeaderText="نام شرکت" 
                    SortExpression="نام شرکت" />
                <asp:BoundField DataField="حاضر" HeaderText="حاضر" SortExpression="حاضر" />
                <asp:BoundField DataField="مرخصی" HeaderText="مرخصی" SortExpression="مرخصی" />
                <asp:BoundField DataField="غایب" HeaderText="غایب" SortExpression="غایب" />
                <asp:BoundField DataField="شب کار" HeaderText="شب کار" 
                    SortExpression="شب کار" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ProjectMeterConnectionString %>" 
            SelectCommand="SELECT tbl_static_drp_company_names.sdcn_name AS [نام شرکت], tbl_static_workers.sw_tedade_hazerin AS حاضر, tbl_static_workers.sw_tedade_morekhasi AS مرخصی, tbl_static_workers.sw_tedade_ghaiebin AS غایب, tbl_static_workers.sw_tedade_shab_karha AS [شب کار] FROM tbl_static_workers INNER JOIN tbl_static_drp_company_names ON tbl_static_workers.sw_name_sherkat_link = tbl_static_drp_company_names.sdcn_id WHERE (tbl_static_workers.sw_link_to_statics = @sw_link_to_statics)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="sw_link_to_statics" 
                    QueryStringField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
