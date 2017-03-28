
Partial Class Mfg_RptPurchseReturn
    Inherits BasePage
    ''Created By -->Ajit Kumar Singh
    ''Date-->01-Feb-2013
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim Supp_ID As Integer
        Dim PR_ID As Integer
        Dim StartDate As Date
        Dim EndDAte As Date
        Try
            If cmbSuppName.SelectedValue = "" Then
                Supp_ID = 0
            Else
                Supp_ID = cmbSuppName.SelectedValue
            End If
            If cmbPurRet.SelectedValue = "" Then
                PR_ID = 0
            Else
                PR_ID = cmbPurRet.SelectedValue
            End If
            If txtStartDate.Text = "" Then
                StartDate = "1/1/1900"
            Else
                StartDate = txtStartDate.Text
            End If
            If txtEndDate.Text = "" Then
                EndDAte = "1/1/3000"
            Else
                EndDAte = txtEndDate.Text
            End If

            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "Mfg_RptPurchaseReturnV.aspx?" & QueryStr.Querystring() & "&Supp_ID=" & Supp_ID & "&PR_ID=" & PR_ID & "&StartDate=" & StartDate & "&EndDAte=" & EndDAte
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'cmbPurRet.Enabled = False

        If IsPostBack Then
           
            'If cmbSuppName.SelectedValue = 0 Then

            '    cmbPurRet.Enabled = False
            '    txtEndDate.Enabled = True
            '    txtStartDate.Enabled = True
            '    txtEndDate.Text = ""
            '    txtStartDate.Text = ""
            'Else
            '    cmbPurRet.Enabled = True
            '    If cmbPurRet.SelectedValue = 0 Then
            '        txtEndDate.Enabled = True
            '        txtStartDate.Enabled = True
            '    Else
            '        txtEndDate.Enabled = False
            '        txtStartDate.Enabled = False
            '        txtEndDate.Text = ""
            '        txtStartDate.Text = ""
            '    End If

            'End If
        Else
            txtEndDate.Text = Format(Today, "dd-MMM-yyyy")
            txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()

    End Sub

    Protected Sub cmbSuppName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSuppName.SelectedIndexChanged
        If cmbSuppName.SelectedValue = 0 Then
            'cmbPurRet.Enabled = False
            txtEndDate.Enabled = True
            txtStartDate.Enabled = True
            txtEndDate.Text = Format(Today, "dd-MMM-yyyy")
            txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
        Else
            'cmbPurRet.Enabled = True
            If cmbPurRet.SelectedValue = 0 Then
                txtEndDate.Enabled = True
                txtStartDate.Enabled = True
            Else
                'txtEndDate.Enabled = False
                'txtStartDate.Enabled = False
                txtEndDate.Text = Format(Today, "dd-MMM-yyyy")
                txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
            End If


        End If
    End Sub

    Protected Sub cmbPurRet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPurRet.SelectedIndexChanged
        If cmbPurRet.SelectedValue = 0 Then
            txtEndDate.Enabled = True
            txtStartDate.Enabled = True
        Else
            'txtEndDate.Enabled = False
            'txtStartDate.Enabled = False
            txtEndDate.Text = Format(Today, "dd-MMM-yyyy")
            txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
End Class
