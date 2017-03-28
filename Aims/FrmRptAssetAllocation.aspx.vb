
Partial Class FrmRptAssetAllocation
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim AssetType As String
        Dim AssetName As String
        Dim fromdate As String
        Dim todate As String
        Try
            If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                If CType(txtfromdate.Text, Date) > CType(txttodate.Text, Date) Then
                    msginfo.Text = "'Issued Date From' cannot be greater than 'Issued Date To'."
                    Exit Sub
                End If
            End If
            AssetType = ddlassetType.SelectedValue
            AssetName = ddlAssetName.SelectedValue
            If txtfromdate.Text = "" Then
                fromdate = "04-01-1900"
            Else
                fromdate = txtfromdate.Text
            End If
            If txttodate.Text = "" Then
                todate = Format(Today, "dd-MMM-yyyy")
            Else
                todate = txttodate.Text
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptAssetAllocationV.aspx?" & QueryStr.Querystring() & "&AssetType=" & AssetType & "&AssetName=" & AssetName & "&fromdate=" & fromdate & "&todate=" & todate & "&EmpDept=" & RBReport.SelectedValue
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

            If txtfromdate.Text = "04-01-1900" Then
                txtfromdate.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
        End Try

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim cd As String
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txttodate.Text = cd
            txtfromdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
        End If
        If ddlassetType.SelectedItem.Text = "ALL" Then
            ddlAssetName.Enabled = False
        Else
            ddlAssetName.Enabled = True
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub ddlassetType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassetType.SelectedIndexChanged
        If ddlassetType.SelectedItem.Text = "ALL" Then
            ddlAssetName.Enabled = False
        Else
            ddlAssetName.Enabled = True
        End If
    End Sub
End Class


