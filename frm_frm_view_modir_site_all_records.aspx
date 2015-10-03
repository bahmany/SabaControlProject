<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_frm_view_modir_site_all_records.aspx.cs" Inherits="frm_frm_view_modir_site_all_records" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .__style1
        {
            color: #009900;
        }
        .__style2
        {
            color: #CC0000;
        }
    </style>
</head>
<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
<body dir="rtl" style="font-family: tahoma; font-size: 12px">
    <form id="form1" runat="server">



    <script type="text/javascript">
function open_win(url) {
window.open(url,"_blank","toolbar=yes, location=yes, directories=no, status=no, menubar=yes, scrollbars=yes, resizable=no, copyhistory=yes, width=400, height=400");
}
</script>

    
    <div>
        <table  class="main_table">
    <tr>
    <td>
    
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="کد ثبت" DataSourceID="ObjectDataSource1" 
            GridLines="Horizontal" onrowcreated="GridView1_RowCreated" 
            onrowdatabound="GridView1_RowDataBound" AllowPaging="True">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="کد ثبت" HeaderText="کد ثبت" InsertVisible="False" 
                    ReadOnly="True" SortExpression="کد ثبت" />
                <asp:BoundField DataField="تاریخ ورودی" HeaderText="تاریخ ورودی" 
                    ReadOnly="True" SortExpression="تاریخ ورودی" />
                <asp:BoundField DataField="روز" HeaderText="روز" SortExpression="روز" />
                <asp:BoundField DataField="شماره" HeaderText="شماره" SortExpression="شماره" />
                <asp:BoundField DataField="وضعیت جوی" HeaderText="وضعیت جوی" 
                    SortExpression="وضعیت جوی" />
                <asp:BoundField DataField="درجه حرارت" HeaderText="درجه حرارت" 
                    SortExpression="درجه حرارت" />
                <asp:BoundField DataField="کمینه" HeaderText="کمینه" SortExpression="کمینه" />
                <asp:BoundField DataField="پیشینه" HeaderText="پیشینه" 
                    SortExpression="پیشینه" />
                <asp:BoundField DataField="توضیحات مدیر سایت" HeaderText="توضیحات مدیر سایت" 
                    SortExpression="توضیحات مدیر سایت" >
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="تخلفات" HeaderText="تخلفات" 
                    SortExpression="تخلفات" >
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="تنظیم کننده" HeaderText="تنظیم کننده" 
                    ReadOnly="True" SortExpression="تنظیم کننده" />
                <asp:BoundField DataField="نظر تائید کننده" HeaderText="نظر تائید کننده" 
                    SortExpression="نظر تائید کننده" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                            <tr>
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
                                <td colspan="4" style="font-weight: bold">
                                
                                    <asp:Panel ID="Panel1" runat="server" ondatabinding="Panel1_DataBinding" 
                                        onload="Panel1_Load" ToolTip='<%# Eval("position") %>'>
                                        آیا این گزارش مشاهده گردید؟&nbsp;&nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" 
                                        ToolTip='<%# Eval("[کد ثبت]") %>' onclick="LinkButton1_Click">بلی</asp:LinkButton>
                                    &nbsp;|
                                    <asp:LinkButton ID="LinkButton2" runat="server" 
                                        ToolTip='<%# Eval("[کد ثبت]") %>' onclick="LinkButton2_Click">خیر</asp:LinkButton>
                                        <br />
                                        <br />
                                        <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="#0000CC" 
                                            onclick="LinkButton3_Click" ToolTip='<%# Eval("[کد ثبت]") %>'>ویرایش و تصحیح گزارش</asp:LinkButton>
                                        <br />
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server" 
                                        ondatabinding="Panel2_DataBinding" ToolTip='<%# Eval("position") %>'>
                                    
                                        <span class="__style1">این گزارش تکمیل شده است</span></asp:Panel>
                                     <asp:Panel ID="Panel3" runat="server" 
                                        ondatabinding="Panel3_DataBinding" ToolTip='<%# Eval("position") %>'>
                                    
                                        <span class="__style2">این گزارش مورد تائید نیست</span></asp:Panel>
                                    
                                    
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MainDataModuleTableAdapters.tbl_statics11TableAdapter">
        </asp:ObjectDataSource>
    
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
