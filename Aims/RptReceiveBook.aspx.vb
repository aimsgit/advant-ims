
Partial Class RptReceiveBook
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim id As Integer
        Dim startdate As Date
        Dim enddate As Date
        'If txtfromdate.Text = "" And txttodate.Text = "" Then
        '    startdate = "1/1/1900"
        '    enddate = "1/1/1900"
        'Else
        '    startdate = txtfromdate.Text
        '    enddate = txttodate.Text
        'End If
        If txtfromdate.Text = "" Then
            startdate = "01/01/1900"
        Else
            startdate = txtfromdate.Text
        End If

        If txttodate.Text = "" Then
            enddate = "01/01/1900"
            txttodate.Text = Format(Today, "dd-MMM-yyyy")
        Else
            enddate = txttodate.Text
        End If
        
        If startdate <> "1/1/1900" And enddate <> "1/1/1900" And CType(startdate, Date) > CType(enddate, Date) Then

            'If CType(txtfromdate.Text, Date) > CType(txttodate.Text, Date) Then
            msginfo.Text = "'From Date' cannot be greater than 'To Date'."
            msginfo.Width = 350
            '    Exit Sub
            'End If

        Else
            id = cmbsubject.SelectedValue
            If txtfromdate.Text = "" Then
                startdate = "1/1/1900"
            Else
                startdate = CDate(txtfromdate.Text)
            End If
            If txttodate.Text = "" Then
                enddate = "1/1/1900"
                txttodate.Text = Format(Today, "dd-MMM-yyyy")
            Else
                enddate = CDate(txttodate.Text)
            End If

            QS = Request.QueryString.Get("QS")
            If QS = "RptRecBook" Then
                If cmbsubject.SelectedItem.Text = "Select" Then
                    msginfo.Text = ""
                Else
                    Dim qrystring As String = "RptReceiveBookV.aspx?" & QueryStr.Querystring() & "&id=" & id & "&startdate=" & startdate & "&enddate=" & enddate
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                End If
            End If
        End If

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QS, heading As String
        QS = Request.QueryString.Get("QS")
        heading = Request.QueryString.Get("heading")
        Me.Lblheading.Text = heading

        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim cd As String
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txttodate.Text = cd
            txtfromdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
        End If

    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
