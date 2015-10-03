<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_frm_view_all_records_MachineAlat.aspx.cs" Inherits="frm_frm_view_all_records_MachineAlat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
<body dir="rtl">
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Horizontal" 
            Width="100%">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="نام ماشین" HeaderText="نام ماشین" 
                    SortExpression="نام ماشین" />
                <asp:BoundField DataField="روز" HeaderText="روز" SortExpression="روز" />
                <asp:BoundField DataField="شب" HeaderText="شب" SortExpression="شب" />
                <asp:BoundField DataField="غیر فعال" HeaderText="غیر فعال" 
                    SortExpression="غیر فعال" />
                <asp:BoundField DataField="ساعت" HeaderText="ساعت" SortExpression="ساعت" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ProjectMeterConnectionString %>" 
            SelectCommand="SELECT tbl_static_drp_machine_names.sdmn_name AS [نام ماشین], tbl_static_machines.sm_tedata_dar_rooz AS روز, tbl_static_machines.sm_shab AS شب, tbl_static_machines.sm_gheire_faal AS [غیر فعال], tbl_static_machines.saat AS ساعت FROM tbl_static_machines INNER JOIN tbl_static_drp_machine_names ON tbl_static_machines.sm_name_machine_link = tbl_static_drp_machine_names.sdmn_id WHERE (tbl_static_machines.sm_link_to_tbl_statics = @sm_link_to_tbl_statics)">
            <SelectParameters>
                <asp:QueryStringParameter Name="sm_link_to_tbl_statics" QueryStringField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
