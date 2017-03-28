Imports System.Data
Imports System.IO
Partial Class frmFeeFinancialYr
    Inherits BasePage
    Dim alert As String
    Dim BAL As New CoursePlanner
    Dim GlobalFunction As New GlobalFunction
    Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
        Try
            Session("sesInstitute") = Session("InstituteID")
            Session("sesbranch") = Session("BranchID")
            If txtCourse.Text <> "" Then
                Session("sesCourse") = GlobalFunction.IdCutter(txtCourse.Text)
            End If
        Catch
            txtCourse.Text = "Not a valid option.Try again."
            txtCourse.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If txtBatch.Text <> "" And txtCourse.Text <> "" Then
            Dim dtM As New Data.DataTable
            dtM = StudentDB.RPT_GetFinalResult(Session("InstituteID"), Session("BranchID"), GlobalFunction.IdCutter(txtCourse.Text), GlobalFunction.IdCutter(txtBatch.Text)).Tables(0)
            If dtM.Rows.Count <> 0 Then
                Dim qrystring As String = "rptGetFeeFinancialyrwise.aspx?" & QueryStr.Querystring() & "&Course=" & GlobalFunction.IdCutter(txtCourse.Text) & "&BatchVal=" & GlobalFunction.IdCutter(txtBatch.Text)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                AlertEnterAllFields("No Records Found.")
            End If
        Else
            AlertEnterAllFields("Select all the required fields.")
        End If
    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        alert = "alert('" & str & "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alert, True)
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
