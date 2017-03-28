
Partial Class RptTimeSheet
    Inherits BasePage
    ''Created By -->Ajit Kumar Singh
    ''Date-->08-Apr-2013

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim EmpID As Integer
        Dim BatchID As Integer
        Dim SemID As Integer
        Dim SubjectID As Integer
        Try

            If ddlEmployeeName.SelectedValue = "" Then
                EmpID = 0
            Else
                EmpID = ddlEmployeeName.SelectedValue
            End If
            If ddlBatchName.SelectedValue = "" Then
                BatchID = 0
            Else
                BatchID = ddlBatchName.SelectedValue
            End If
            If ddlSemester.SelectedValue = "" Then
                SemID = 0
            Else
                SemID = ddlSemester.SelectedValue
            End If
            If ddlSubject.SelectedValue = "" Then
                SubjectID = 0
            Else
                SubjectID = ddlSubject.SelectedValue
            End If

            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptTimeSheetV.aspx?" & QueryStr.Querystring() & "&EmpID=" & EmpID & "&BatchID=" & BatchID & "&SemID=" & SemID & "&SubjectID=" & SubjectID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub Btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
