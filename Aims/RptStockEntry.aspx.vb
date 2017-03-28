
Partial Class RptStockEntry
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim Br As String = Session("BranchCode")
            'DDLBranch.DataTextFormatString = "{0:dd-MMM-yyyy}"
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today(), "dd-MMM-yyyy")
        End If
     
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim StkEntrydate As Date
        Dim Startdate As Date
        Dim Enddate As Date

       
        If DDLBranch.SelectedValue = "All" Then
            StkEntrydate = "1/1/1900"
        Else
            StkEntrydate = DDLBranch.SelectedValue
        End If

        If txtStartDate.Enabled = False Or txtStartDate.Text = "" Then
            Startdate = "1/1/1900"
        Else
            Startdate = txtStartDate.Text
        End If


        If txtEndDate.Enabled = False Or txtEndDate.Text = "" Then
            Enddate = "1/1/1900"
        Else
            Enddate = txtEndDate.Text
        End If

        If DDLBranch.SelectedValue <> "" Then
            'txtStartDate.Text = CDate("1/1/1900")
            'txtEndDate.Text = CDate("1/1/1900")
            txtStartDate.Enabled = True
            txtEndDate.Enabled = True

            Dim qrystring As String = "RptStockEntryV.aspx?" & QueryStr.Querystring() & "&StkEntrydate=" & StkEntrydate & "&Startdate=" & Startdate & "&Enddate=" & Enddate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
        Else

            'DDLBranch.Enabled = False
            txtStartDate.Enabled = True
            txtEndDate.Enabled = True
            If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
                msginfo.Text = " Enter Start/End date."
            Else


                Dim qrystring As String = "RptStockEntryV.aspx?" & QueryStr.Querystring() & "&StkEntrydate=" & StkEntrydate & "&Startdate=" & Startdate & "&Enddate=" & Enddate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
            End If
        End If
           

    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

  

    Protected Sub DDLBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLBranch.TextChanged
        DDLBranch.Focus()
        If DDLBranch.SelectedValue = "All" Then
            txtStartDate.Enabled = True
            txtEndDate.Enabled = True

        Else
            txtStartDate.Enabled = False
            txtEndDate.Enabled = False
        End If
    End Sub


End Class
