
Partial Class Rpt_Earningdeduction
    Inherits BasePage
    Dim dt As DataTable
    'Code written By Niraj
    '21-Mar-2013

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim BN As String
        Dim Dept As String
        Dim EDType As String
        Dim EmpName As String
        Dim Year As Integer
        Dim month As String
        Try

            BN = DdlBranchName.SelectedValue
            Dept = ddlDept.SelectedValue
            EmpName = DdlEmpName.SelectedValue
            EDType = ddlEarnDed.SelectedValue
            Year = ddlYear.SelectedItem.Text
            month = ddlMonth.SelectedValue

            If ddlEarnDed.SelectedValue = "E" Then
                QS = Request.QueryString.Get("QS")
                Dim qrystring1 As String = "Rpt_EarnDedV.aspx?" & QueryStr.Querystring() & "&BN=" & BN & "&Dept=" & Dept & "&EDType=" & EDType & "&EmpName=" & EmpName & "&Year=" & Year & "&month=" & month
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring1 & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Else
                QS = Request.QueryString.Get("QS")
                Dim qrystring As String = "Rpt_DedEarnV.aspx?" & QueryStr.Querystring() & "&BN=" & BN & "&Dept=" & Dept & "&EDType=" & EDType & "&EmpName=" & EmpName & "&Year=" & Year & "&month=" & month
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            End If
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub DdlBranchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBranchName.SelectedIndexChanged
        DdlBranchName.Focus()
    End Sub

    Protected Sub ddlDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.SelectedIndexChanged
        ddlDept.Focus()
    End Sub

    Protected Sub ddlEarnDed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEarnDed.SelectedIndexChanged
        ddlEarnDed.Focus()
    End Sub

    Protected Sub DdlEmpName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlEmpName.SelectedIndexChanged
        DdlEmpName.Focus()
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        ddlYear.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DdlBranchName.SelectedValue = Session("BranchCode")
            DdlBranchName.Focus()
        End If
    End Sub
End Class
