
Partial Class frmbookIssueReport
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim bookissue As String
        Dim DeptID As String
        Dim BranchCode As String = ddlbranch.SelectedValue
        Try
            DeptID = ddlDept.SelectedValue
            If CType(txtfromdate.Text, Date) > CType(txttodate.Text, Date) Then
                msginfo.Text = "'From Date' cannot be greater than 'To Date'."
                msginfo.Width = 350
            Else
                If cmbBookIssue.SelectedValue = "ALL" Then
                    bookissue = cmbBookIssue.SelectedValue
                ElseIf cmbBookIssue.SelectedValue = "STUDENT" Then
                    bookissue = cmbBookIssue.SelectedValue
                Else
                    bookissue = cmbBookIssue.SelectedValue
                End If
                Dim fromdate As Date = CDate(txtfromdate.Text)
                Dim todate As Date = CDate(txttodate.Text)
                QS = Request.QueryString.Get("QS")
                If cmbBookIssue.SelectedItem.Text = "Select" Or txtfromdate.Text = "" Or txttodate.Text = "" Then
                    msginfo.Text = ""
                Else
                    Dim qrystring As String = "BookIssue1.aspx?" & QueryStr.Querystring() & "&BranchCode=" & BranchCode & "&bookissue=" & bookissue & "&fromdate=" & fromdate & "&todate=" & todate & "&DeptID=" & DeptID
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                End If
            End If
        Catch ex As Exception
            msginfo.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QS, heading As String

        QS = Request.QueryString.Get("QS")
        heading = Request.QueryString.Get("heading")
        Me.Lblheading.Text = heading

        If Not IsPostBack Then
            ddlbranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            Dim CloseDate As Date
            Dim cd As String
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txttodate.Text = cd
            txtfromdate.Text = cd
        End If

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
