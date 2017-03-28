Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class frmFastMovingItems
    Inherits BasePage


    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try
            If txtStartingDate.Text <> "" And txtEndDate.Text <> "" Then

                If CType(txtStartingDate.Text, Date) > CType(txtEndDate.Text, Date) Then
                    lblerrmsg.Text = "Start Date Can't be greater than End Date"
                    Exit Sub
                End If
            End If
            Dim Fromdate As DateTime
            Dim Todate As DateTime

            If txtStartingDate.Text = "" Then
                Fromdate = "04/01/1900"
            Else
                Fromdate = txtStartingDate.Text

            End If

            If txtEndDate.Text = "" Then
                Todate = "01/01/3000"
            Else
                Todate = txtEndDate.Text
            End If

            
            Dim qrystring As String = "Rpt_FastMovingItems.aspx?" & QueryStr.Querystring() & "&Fromdate=" & Fromdate & "&Todate=" & Todate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        Catch ex As Exception
            lblerrmsg.Text = "Please enter the valid date."
            lblmsgifo.Text = ""
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
            txtStartingDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class
