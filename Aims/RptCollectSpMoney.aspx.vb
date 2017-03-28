
Partial Class RptCollectSpMoney
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim Academicyear As Integer
        Dim Batch As Integer
        Dim student As Integer


        Try
            
            Academicyear = DDLA_Year.SelectedValue
            Batch = cmbBatch.SelectedValue
            student = DropDownList1.SelectedValue
            Dim payment As Integer = ddlpaymentmethod.SelectedValue


           
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptCollectSpMoneyV.aspx?" & QueryStr.Querystring() & "&Academicyear=" & Academicyear & "&Batch=" & Batch & "&student=" & student & "&payment=" & payment
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

           
        Catch ex As Exception
            msginfo.Text = "Enter correct Data."
        End Try
    End Sub
End Class
