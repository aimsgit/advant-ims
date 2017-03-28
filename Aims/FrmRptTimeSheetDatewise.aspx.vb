﻿
Partial Class FrmRptTimeSheetDatewise
    Inherits BasePage
    'Code Written by Niraj on 31 May 2013
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim EmployeeId As String
        Dim fromdate As Date
        Dim todate As Date
        Try
            If Txtfdate.Text <> "" And Txttodate.Text <> "" Then

                If CType(Txtfdate.Text, Date) > CType(Txttodate.Text, Date) Then
                    msginfo.Text = "'From Date' cannot be greater than 'To Date'."
                    Exit Sub
                End If
            End If
            EmployeeId = ddlEmployeeName.SelectedValue
            If Txtfdate.Text = "" Then
                fromdate = "01-01-1900"
            Else
                fromdate = Txtfdate.Text
            End If
            If Txttodate.Text = "" Then
                todate = "01-01-9000"
            Else
                todate = Txttodate.Text
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "FrmTimeSheetDatewiseV.aspx?" & QueryStr.Querystring() & "&EmployeeId=" & EmployeeId & "&fromdate=" & fromdate & "&todate=" & todate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

            If Txtfdate.Text = "01-01-1900" Then
                Txtfdate.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Enter correct date."
        End Try

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim cd As String
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            Txttodate.Text = cd
            Txtfdate.Text = cd
        End If

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class