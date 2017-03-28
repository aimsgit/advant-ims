Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class BinCard
    Inherits BasePage
    
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim QS As String
        Dim Product_Id As Integer
        
        Try
            Product_Id = DDLPRODUCT.SelectedValue
           QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptBinCardV.aspx?" & QueryStr.Querystring() & "&Product_Id=" & Product_Id
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

End Class
