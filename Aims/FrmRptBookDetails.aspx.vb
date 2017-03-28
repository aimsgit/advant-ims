
Partial Class FrmRptBookDetails
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim fromdate As String
        Dim todate As String
        Dim DeptID As String
        Try
            DeptID = ddlDept.SelectedValue
            If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                If CType(txtfromdate.Text, Date) > CType(txttodate.Text, Date) Then
                    msginfo.Text = "'Receipt Date From' cannot be greater than 'Receipt Date To'."
                    Exit Sub
                End If
            End If
            If txtfromdate.Text = "" Then
                fromdate = "01-01-1900"
            Else
                fromdate = txtfromdate.Text
            End If
            If txttodate.Text = "" Then
                todate = Format(Today, "dd-MMM-yyyy")
            Else
                todate = txttodate.Text
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptBookDetailsV.aspx?" & QueryStr.Querystring() & "&fromdate=" & fromdate & "&todate=" & todate & "&DeptID=" & DeptID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

            If txtfromdate.Text = "01-01-1900" Then
                txtfromdate.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Enter correct Data."
        End Try

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim EndDate As Date
            Dim cd As String
            Dim ed As String
            CloseDate = System.DateTime.Now
            EndDate = System.DateTime.Now
            ed = CloseDate.ToString("dd-MMM-yyyy")
            cd = CloseDate.ToString("dd-MMM-yyyy")
            'txttodate.Text = cd
            txtfromdate.Text = ed
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()

    End Sub
End Class
