Partial Class DayBookDetails
    Inherits BasePage
    Dim alt As String
    Dim ExpenseID As HiddenField
    Dim ExpID As Int64
    Dim cmd As OleDbCommand
    Dim Rda As OleDbDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'new_dbconn1.ConnectionString = Application("Strcontent")
        'AccessDataSource1.SelectCommand = "Select * from DispGV_Expenses"
        'GVDayBookDetails.DataBind()
        Lblmsg.Text = ""
    End Sub
    Protected Sub GVDayBookDetails_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GVDayBookDetails.RowDeleted
        GVDayBookDetails.DataBind()
    End Sub
    Protected Sub GVDayBookDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVDayBookDetails.RowDeleting
        If GVDayBookDetails.EditIndex <> -1 Then
            Lblmsg.Text = "First Cancel Edit."
        Else
            ExpenseID = CType(GVDayBookDetails.Rows(e.RowIndex).Cells(1).FindControl("EID"), HiddenField)
            ExpID = Int64.Parse(ExpenseID.Value)
            Dim BLL As New DayBookManager
            Dim ELL As New DayBookEL
            ELL.Expense_ID = ExpID
            'BLL.ChangeFlag(ELL)
            Lblmsg.Text = "Data Deleted Successfully."
        End If
    End Sub
    Protected Sub GVDayBookDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVDayBookDetails.RowEditing
        ExpenseID = CType(GVDayBookDetails.Rows(e.NewEditIndex).Cells(1).FindControl("EID"), HiddenField)
        ExpID = Int64.Parse(ExpenseID.Value)
        Session("Gstatus") = "EDIT"
        Response.Redirect("DayBook.aspx?Expense=" & ExpID)
        Session("Gstatus") = "UPDATE"
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session("Gstatus") = "ADD"
        Response.Redirect("DayBook.aspx")
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim myDS As New GlobalDataSetTableAdapters.Test_Acct_DayBook_QryTableAdapter
        Dim dt As New Data.DataTable
        Dim brch As Integer = HttpContext.Current.Session("BranchID")
        Dim ins As Integer = HttpContext.Current.Session("InstituteID")
        Dim fstartdate As Date = HttpContext.Current.Session("FinStartDate")
        Dim fenddate As Date = HttpContext.Current.Session("FinEndDate")

        'dt = myDS.GetData(ins, brch, fstartdate, fenddate)
        If dt.Rows.Count() <= 0 Then
            alt = "<script language='javascript'>" + "alert('No records to display.');" + "</script>"
            ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
        Else
            Dim qrystring As String = "DayBookRpt.aspx?" & QueryStr.Querystring() & "&FinStartDate=" & Session("FinStartDate") & "&FinEndDate=" & Session("FinEndDate")
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
