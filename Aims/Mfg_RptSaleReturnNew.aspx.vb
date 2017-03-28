Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class Mfg_RptSaleReturnNew
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try
            If txtstartdate.Text <> "" And txtenddate.Text <> "" Then

                If CType(txtstartdate.Text, Date) > CType(txtenddate.Text, Date) Then
                    msginfo.Text = "Start Date Can't be greater than End Date"
                    Exit Sub
                End If
            End If
            Dim FromDate As DateTime
            Dim ToDate As DateTime
            Dim Buyer As Integer

            Buyer = DDlBuyer.SelectedValue

            If txtstartdate.Text = "" Then
                Fromdate = "04/01/1900"
            Else
                Fromdate = txtstartdate.Text

            End If

            If txtenddate.Text = "" Then
                ToDate = "04/01/9000"
            Else
                Todate = txtenddate.Text
            End If


            Dim qrystring As String = "Rpt_SaleReturnNewV.aspx?" & QueryStr.Querystring() & "&Buyer=" & Buyer & "&FromDate=" & Fromdate & "&ToDate=" & Todate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        Catch ex As Exception
            msginfo.Text = "Please enter the valid date."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtstartdate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            txtenddate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class
