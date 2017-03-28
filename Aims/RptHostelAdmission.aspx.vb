
Partial Class RptHostelAdmission
    Inherits BasePage

    Dim dt As New DataTable
    Dim BL As New HostelAdmissionBL

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim HID As Integer = cmbHosName.SelectedValue
        Dim RID As Integer = cmbRoomType.SelectedValue
        Dim Status As Integer = ddlStstus.SelectedValue
        Dim BranchCode As String = ddlbranch.SelectedValue
        Dim FrmDate As Date
        Dim ToDate As Date
        Try
            If txtFrmDate.Text = "" Then
                FrmDate = "01/01/1900"
            Else
                FrmDate = txtFrmDate.Text
            End If

            If txtToDate.Text = "" Then
                ToDate = "01/01/1900"
            Else
                ToDate = txtToDate.Text

            End If
            If FrmDate > ToDate Then
                lblMsg.Text = "From Date should be greater than To Date."

            Else

                Dim qrystring As String = "RptHostelAdmissionV.aspx?" & QueryStr.Querystring() & "&BranchCode=" & BranchCode & "&HID=" & HID & "&RID=" & RID & "&Status=" & Status & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            End If
        Catch ex As Exception
            lblMsg.Text = "Enter Valid Date."
        End Try
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Text = ""
        If Not IsPostBack Then
            ddlbranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            txtToDate.Text = Format(Today, "dd-MMM-yyyy")
            dt = BL.GetHosNameCombo1(HttpContext.Current.Session("BranchCode"))
            cmbHosName.DataSource = dt
            cmbHosName.DataBind()
        End If
    End Sub

    Protected Sub cmbHosName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbHosName.TextChanged
        cmbHosName.Focus()
    End Sub

    Protected Sub cmbRoomType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRoomType.TextChanged
        cmbRoomType.Focus()
    End Sub

    Protected Sub ddlStstus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStstus.TextChanged
        ddlStstus.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlbranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbranch.SelectedIndexChanged
        'ddlbranch.SelectedValue = HttpContext.Current.Session("BranchCode")
        cmbHosName.Items.Clear()
        dt = BL.GetHosNameCombo1(ddlbranch.SelectedValue)
        cmbHosName.DataSource = dt
        cmbHosName.DataBind()

    End Sub
End Class
