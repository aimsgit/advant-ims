
Partial Class FrmRptEndowmentDetails
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ValidationMessage(1014)
        Dim QS As String
        Dim fromdate As Date
        Dim todate As Date
        Try
            If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                If CType(txtfromdate.Text, Date) > CType(txttodate.Text, Date) Then
                    msginfo.Text = ValidationMessage(1075)
                    Exit Sub
                End If
            End If
            If txtfromdate.Text = "" Then
                fromdate = "04-01-1900"
            Else
                fromdate = txtfromdate.Text
            End If
            If txttodate.Text = "" Then
                todate = "04-01-9000"
            Else
                todate = txttodate.Text
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptEndowmentDetailsV.aspx?" & QueryStr.Querystring() & "&fromdate=" & fromdate & "&todate=" & todate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

            If txtfromdate.Text = "04-01-1900" Then
                txtfromdate.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1022)
        End Try

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim cd As String
            
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txttodate.Text = cd
            txtfromdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()

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
End Class