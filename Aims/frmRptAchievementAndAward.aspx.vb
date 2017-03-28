
Partial Class frmRptAchievementAndAward
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim DeptID As String
        Dim fromdate As Date
        Dim todate As Date
        If ddlEmployee.selectedvalue = 0 Then
            msginfo.text = "Employee/Student is Mandatory."
            Exit Sub
        End If
        Try
            If Txtfdate.Text <> "" And Txttodate.Text <> "" Then

                If CType(Txtfdate.Text, Date) > CType(Txttodate.Text, Date) Then
                    msginfo.Text = "'From Date' cannot be greater than 'To Date'."
                    Exit Sub
                End If
            End If
            DeptID = ddlDept.SelectedValue
            If Txtfdate.Text = "" Then
                fromdate = "1/1/1900"
            Else
                fromdate = Txtfdate.Text
            End If
            If Txttodate.Text = "" Then
                todate = "1/1/4000"
            Else
                todate = Txttodate.Text
            End If
            Dim EmpStd As Integer = ddlEmployee.SelectedValue
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "frmRptAchievementAndAwardV.aspx?" & QueryStr.Querystring() & "&DeptID=" & DeptID & "&fromdate=" & fromdate & "&todate=" & todate & "&EmpStd=" & EmpStd
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            msginfo.Text = "Enter correct date."
        End Try
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim cd As String
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txttodate.Text = cd
            Txttodate.Text = Format(Today, "dd-MMM-yyyy")
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
