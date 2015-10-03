<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_frm_view_all_records_sazeha.aspx.cs" Inherits="frm_frm_view_all_records_sazeha" %>

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
                <asp:BoundField DataField="سازه صنعتی" HeaderText="سازه صنعتی" 
                    SortExpression="سازه صنعتی" />
                <asp:BoundField DataField="فعالیت انجام شده" HeaderText="فعالیت انجام شده" 
                    SortExpression="فعالیت انجام شده" />
                <asp:BoundField DataField="مقدار" HeaderText="مقدار" SortExpression="مقدار" />
                <asp:BoundField DataField="واحد" HeaderText="واحد" SortExpression="واحد" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ProjectMeterConnectionString %>" 
            SelectCommand="SELECT tbl_static_drp_toolsw_name.sdtwn_name AS [سازه صنعتی], tbl_static_tools_exp.stw_faaliate_anjam_shode AS [فعالیت انجام شده], tbl_static_tools_exp.stw_meghdare_ekhtesasi AS مقدار, tbl_static_tools_exp.stw_vahed AS واحد FROM tbl_static_tools_exp INNER JOIN tbl_static_drp_toolsw_name ON tbl_static_tools_exp.stw_name_sazeh_link = tbl_static_drp_toolsw_name.sdtwn_id WHERE (tbl_static_tools_exp.stw_link_to_statics = @stw_link_to_statics)">
            <SelectParameters>
                <asp:QueryStringParameter Name="stw_link_to_statics" QueryStringField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
