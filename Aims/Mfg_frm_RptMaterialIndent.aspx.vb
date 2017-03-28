
Partial Class Mfg_frmMaterialIndex
    Inherits BasePage
    Dim EL As New Mfg_ElStockIssue
    Dim dt As New DataTable
    Dim BL As New Mfg_BLStockIssue



    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try

            Dim ImNo As String
            Dim PartyType As String
            Dim Partyname As String
            Dim workorder As String

            ImNo = ddlMiNo.SelectedItem.Text
            PartyType = cmbPType.SelectedValue
            Partyname = ddlPName.SelectedValue
            workorder = ddlWorkOrder.SelectedValue

            Dim qrystring As String = "Mfg_Rpt_MaterialIndentReport.aspx?" & "&ImNo=" & ImNo & "&PartyType=" & PartyType & "&Partyname=" & Partyname & "&workorder=" & workorder
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblGreenM.Text = ""

          
        Catch ex As Exception
            lblRedM.Text = "Please enter the valid date."
            lblGreenM.Text = ""


        End Try



    End Sub
End Class

