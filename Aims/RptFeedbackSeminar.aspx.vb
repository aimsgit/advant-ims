
Partial Class RptFeedbackSeminar
    Inherits BasePage
    ''Created By -->Ajit Kumar Singh
    ''Date-->01-Apr-2013

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim DeptID As Integer
        Dim EmpID As Integer
        Dim FromDate As Date
        Dim ToDate As Date
        Try

            If ddlDepartment.SelectedValue = "" Then
                DeptID = 0
            Else
                DeptID = ddlDepartment.SelectedValue
            End If
            If ddlEmployee.SelectedValue = "" Then
                EmpID = 0
            Else
                EmpID = ddlEmployee.SelectedValue
            End If
            If txtFromDate.Text = "" Then
                FromDate = "1/1/1900"
            Else
                FromDate = txtFromDate.Text
            End If
            If txtToDate.Text = "" Then
                ToDate = "1/1/3000"
            Else
                ToDate = txtToDate.Text
            End If
            If CDate(IIf(txtFromDate.Text <> "", txtFromDate.Text, "1/1/1900")) > CDate(IIf(txtToDate.Text <> "", txtToDate.Text, "1/1/9100")) Then
                msginfo.Text = "From Date Cannot be greater than To Date."
                lblmsg.Text = ""
                Exit Sub
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptFeedbackSeminarV.aspx?" & QueryStr.Querystring() & "&DeptID=" & DeptID & "&EmpID=" & EmpID & "&FromDate=" & FromDate & "&ToDate=" & ToDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtToDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub Btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
