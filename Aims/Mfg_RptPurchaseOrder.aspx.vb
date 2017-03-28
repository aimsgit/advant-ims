
Partial Class Mfg_RptPurchaseOrder
    Inherits BasePage
    ''Created By -->Ajit Kumar Singh
    ''Date-->11-Jan-2013
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim Supp_ID As Integer
        Dim PO_ID As Integer
        Dim StartDate As Date
        Dim EndDAte As Date
        Try

            If cmbSuppName.SelectedValue = "" Then
                Supp_ID = 0
            Else
                Supp_ID = cmbSuppName.SelectedValue
            End If

            If cmbPurOrd.SelectedValue = "" Then
                PO_ID = 0
            Else
                PO_ID = cmbPurOrd.SelectedValue
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

            Dim qrystring As String = "Mfg_RptPurchaseOrderV.aspx?" & QueryStr.Querystring() & "&Supp_ID=" & Supp_ID & "&PO_ID=" & PO_ID & "&StartDate=" & StartDate & "&EndDAte=" & EndDAte
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cmbPurOrd.Enabled = False

        If IsPostBack Then
            If cmbSuppName.SelectedValue = 0 Then
                cmbPurOrd.Enabled = False
                txtEndDate.Enabled = True
                txtStartDate.Enabled = True
            Else
                cmbPurOrd.Enabled = True
                If cmbPurOrd.SelectedValue = 0 Then
                    txtEndDate.Enabled = True
                    txtStartDate.Enabled = True
                Else
                    txtEndDate.Enabled = False
                    txtStartDate.Enabled = False
                End If

            End If

        End If

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()

    End Sub


    'Protected Sub cmbSuppName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSuppName.SelectedIndexChanged
    '    If cmbSuppName.SelectedValue = 0 Then
    '        cmbPurOrd.Enabled = False
    '        txtEndDate.Enabled = True
    '        txtStartDate.Enabled = True
    '    Else
    '        cmbPurOrd.Enabled = True
    '        If cmbPurOrd.SelectedValue = 0 Then
    '            txtEndDate.Enabled = True
    '            txtStartDate.Enabled = True
    '        Else
    '            txtEndDate.Enabled = False
    '            txtStartDate.Enabled = False
    '        End If

    '    End If
    'End Sub

    'Protected Sub cmbPurOrd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPurOrd.SelectedIndexChanged
    '    If cmbPurOrd.SelectedValue = 0 Then
    '        txtEndDate.Enabled = False
    '        txtStartDate.Enabled = False
    '    Else
    '        txtEndDate.Enabled = True
    '        txtStartDate.Enabled = True
    '    End If
    'End Sub
End Class
