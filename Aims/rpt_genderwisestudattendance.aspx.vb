
Partial Class rpt_genderwisestudattendance
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim course As Integer
        Dim subject As Integer
        Dim attdate As DateTime
        Try

            course = ddlCourseName.SelectedValue
            subject = ddlSubject.SelectedValue
            attdate = txtFromDate.Text





            Dim qrystring As String = "rpt_genderwisestudattendanceV.aspx?" & QueryStr.Querystring() & "&course=" & ddlCourseName.SelectedValue & "&subject=" & ddlSubject.SelectedValue & "&attdate=" & txtFromDate.Text

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            msginfo.Text = "Enter correct Data."
            lblmsg.Text = ""
        End Try

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtFromDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
