
Partial Class RptVoucherForm
    Inherits BasePage

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim VType As String
        Dim fromdate As DateTime
        Dim todate As DateTime
        Dim FSerial As String
        Dim TSerial As String
        VType = cmbAGOne.SelectedValue

        FSerial = ddlS1.SelectedValue
        TSerial = ddlS2.SelectedValue
        If txtStartDate.Text = "" Then
            fromdate = "01-01-1900"
        Else
            fromdate = txtStartDate.Text
        End If
        If txtEndDate.Text = "" Then
            todate = "01-01-3000"
        Else
            todate = txtEndDate.Text
        End If
        Try
            QS = Request.QueryString.Get("QS")
            Dim qrystring As String = "RptVoucherPrint.aspx?" & QueryStr.Querystring() & "&VType=" & VType & "&fromdate=" & CDate(fromdate) & "&todate=" & CDate(todate) & "&FSerial=" & FSerial & "&TSerial=" & TSerial
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Catch ex As Exception
            msginfo.Text = "Date is not valid."
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
