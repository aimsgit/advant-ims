Imports System.Data.SqlClient

Partial Class rpttrialbalance
    Inherits BasePage
    Dim Dt As New DataTable
    Dim StartDate As DateTime
    Dim EndDate As DateTime
    Dim DL As New DLTrialBookReport

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            Try
                Dim qry_str As String = "&FinStartDate=" & CDate(txtStartDate.Text) & "&FinEndDate=" & Session("FinEndDate")
                Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "TrialBalanceN.aspx?" & QueryStr.Querystring() & qry_str
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Catch ex As Exception
                msginfo.Text = "Date is not valid."
            End Try
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(CDate(Session("FinEndDate")), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then
           

            StartDate = txtStartDate.Text
            EndDate = txtEndDate.Text
            Dt = DL.DisplayGridview(StartDate, EndDate)
            If Dt.Rows.Count > 0 Then

                GVTrialBalance.DataSource = Dt
                GVTrialBalance.DataBind()
                'Multilingual()
                GVTrialBalance.Visible = True
                GVTrialBalance.Enabled = True
            Else

                msginfo.Text = "No Records Display."
                'Multilingual()


            End If
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub

    Protected Sub GVTrialBalance_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVTrialBalance.RowEditing
        Dim accsubgrpId As Integer = Request.QueryString.Get(("accsubgroup"))
        'Dim accsubgrpId As Integer
        StartDate = txtStartDate.Text
        EndDate = txtEndDate.Text
        Dt = DL.DisplayGridview(StartDate, EndDate)

        If CType(GVTrialBalance.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text = "" Then
            accsubgrpId = 0
        Else
            accsubgrpId = CType(GVTrialBalance.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
        End If
        Dim qrystring As String = "rpttrialbalanceDrilDown.aspx?" & QueryStr.Querystring() & "&StartDate=" & txtStartDate.Text & "&EndDate=" & txtEndDate.Text & "&accsubgrpId=" & accsubgrpId
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
    End Sub

    

End Class
