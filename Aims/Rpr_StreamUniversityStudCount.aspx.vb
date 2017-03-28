
Partial Class Rpr_StreamUniversityStudCount
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            'ddlBranchName.SelectedValue = Session("BranchCode")
            txtFromDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtToDate.Text = Format(Today.Date(), "dd-MMM-yyyy")

        End If
    End Sub

    Protected Sub BtnGReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGReport.Click
        lblE.Text = ""
        Dim BranchCode1 As String
        Dim BranchCode As String
        Dim Stream As Integer
        Dim Stream1 As String
        Dim fromdateE As DateTime
        Dim todateE As DateTime
        Dim dt1 As New DataTable
        Dim DS As New DataSet
        Dim DL As New TotalStudentCount
        Stream1 = ddlStream.SelectedItem.Text
        If ddlBranchName.SelectedValue = "" Then
            BranchCode = 0
        Else
            BranchCode = ddlBranchName.SelectedValue
        End If
        If ddlBranchName.SelectedItem.ToString = "" Then
            BranchCode1 = 0
        Else
            BranchCode1 = ddlBranchName.SelectedItem.ToString
        End If
        If ddlStream.SelectedValue = 0 Then
            lblE.Text = "Select any stream."
            Exit Sub
        Else
            Stream = ddlStream.SelectedValue
        End If
        If txtFromDate.Text = "" Then
            fromdateE = "4/1/1900"
        Else
            fromdateE = txtFromDate.Text
        End If
        If txtToDate.Text = "" Then
            todateE = "4/1/9000"
        Else
            todateE = txtToDate.Text
        End If
        If fromdateE > todateE Then
            lblE.Text = "Start date should not be greater than End date."
            txtFromDate.Focus()
            Exit Sub
        End If
        dt1 = DL.UniStudentStudCountStreamWise(BranchCode, fromdateE, todateE, Stream)

        Dim qrystring As String = "RPT_SteramWiseUniversityStudCount.aspx?" & QueryStr.Querystring() & "&StartDate=" & fromdateE & "&EndDate=" & todateE & "&BranchCode=" & BranchCode & "&BranchCode1=" & BranchCode1 & "&Stream=" & Stream & "&Stream1=" & Stream1
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)


    End Sub
End Class
