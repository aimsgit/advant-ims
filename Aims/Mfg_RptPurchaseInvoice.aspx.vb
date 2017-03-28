
Partial Class Mfg_RptPurchaseInvoice
    Inherits BasePage
    ''Created By -->Ajit Kumar Singh
    ''Date-->17-Jan-2013
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim Supp_ID As Integer
        Dim PI_ID As Integer
        Dim StartDate As Date
        Dim EndDAte As Date
        Try
            If cmbSuppName.SelectedValue = "" Then
                Supp_ID = 0
            Else
                Supp_ID = cmbSuppName.SelectedValue
            End If
            If cmbPurInv.SelectedValue = "" Then
                PI_ID = 0
            Else
                PI_ID = cmbPurInv.SelectedValue
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

            Dim qrystring As String = "Mfg_RptPurchaseInvoiceV.aspx?" & QueryStr.Querystring() & "&Supp_ID=" & Supp_ID & "&PI_ID=" & PI_ID & "&StartDate=" & StartDate & "&EndDAte=" & EndDAte
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cmbPurInv.Enabled = False

        If IsPostBack Then
            If cmbSuppName.SelectedValue = 0 Then
                cmbPurInv.Enabled = False
                txtEndDate.Enabled = True
                txtStartDate.Enabled = True
            Else
                cmbPurInv.Enabled = True
                If cmbPurInv.SelectedValue = 0 Then
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
End Class
