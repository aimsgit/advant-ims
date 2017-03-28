
Partial Class Rpt_DailyAttendanceStatus
    Inherits BasePage
    Dim id1 As String = ""

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click


        GetBatchid()
        Dim BatchId As String = ViewState("id1")
        Dim batchName As String = ViewState("id2")
        If (ListBatch.SelectedValue = "" Or "0") Then
            lblErrorMsg.Text = "Batch field is Mandatory."
            Exit Sub
        End If

        If ddlSemester.SelectedValue = 0 Then
            lblErrorMsg.Text = "Semester field is mandatory."
            Exit Sub
        End If

        Dim semid As Integer = ddlSemester.SelectedValue
        Dim FrmDate, ToDate As DateTime
        If txtFromDate.Text = "" Then
            FrmDate = "01/01/1990"
        Else
            FrmDate = txtFromDate.Text
            lblErrorMsg.Text = ValidationMessage(1014)
        End If

        If txtToDate.Text = "" Then
            ToDate = "01/01/3000"

        Else
            ToDate = txtToDate.Text
            lblErrorMsg.Text = ValidationMessage(1014)
        End If


        If txtFromDate.Text <> "" And txtToDate.Text <> "" Then
            If CDate(FrmDate) > CDate(ToDate) Then
                lblErrorMsg.Text = ValidationMessage(1075)
            Else
                Dim qrystring As String = "Rpt_DailyAttendanceStatusV.aspx?" & "&BatchId=" & BatchId & "&Semester=" & semid & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate & "&BatchName=" & batchName
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblErrorMsg.Text = ValidationMessage(1014)
            End If
        End If
    End Sub
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
    Sub GetBatchid()
        Dim str As String = ""
        Dim str1 As String = ""

        Dim id2 As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBatch.Items.Count - 1

        If ListBatch.Items.Count <> 0 Then
            For Each items In ListBatch.Items
                If (ListBatch.Items(i).Selected = True) Then
                    str = ListBatch.Items(i).Value
                    str1 = ListBatch.Items(i).Text
                    id1 = str + "," + id1
                    id2 = str1 + " ,  " + id2
                End If
                i = i + 1
            Next
        End If
        ViewState("id1") = id1
        ViewState("id2") = id2
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            txtFromDate.Text = Format(Today.Date(), "dd-MMM-yyyy")

            txtToDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
