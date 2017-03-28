Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class Mfg_RptStockAudit
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim product As Integer
        Dim fromdate As Date
        Dim todate As Date
        msginfo.Text = ""
        Try
            If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                If CType(txtfromdate.Text, Date) > CType(txttodate.Text, Date) Then
                    msginfo.Text = "From Date Can't be greater than To Date"
                    Exit Sub
                End If
            End If
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

            product = ddlProduct.SelectedValue

            Dim qrystring As String = "Mfg_RptStockAuditV.aspx?" & QueryStr.Querystring() & "&product=" & product & "&fromdate=" & fromdate & "&todate=" & todate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            msginfo.Text = ""

        Catch ex As Exception
            msginfo.Text = "Enter Correct Date."
        End Try

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim TDate As Date
        Dim Cd As String
        If Not IsPostBack Then
            TDate = System.DateTime.Now
            Cd = TDate.ToString("dd-MMM-yyyy")
            txtfromdate.Text = Cd
            txttodate.Text = Cd
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
