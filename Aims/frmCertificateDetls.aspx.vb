Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Partial Class frmCertificateDetls
    Inherits BasePage
    Dim alert As String
    Dim BAL As New CourseManager
    Dim BLL As New StdResultB
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
    Protected Sub btnCertificate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCertificate.Click
        Dim DAL As New CertificateMasterB
        Dim dtM As New Data.DataTable
        'dtM = DAL.GetCertificateDetail(GlobalFunction.IdCutter(txtStdCode.Text), GlobalFunction.IdCutter(txtBatch.Text), GlobalFunction.IdCutter(txtCourse.Text), Session("InstituteID"), Session("BranchID"))
        If dtM.Rows.Count <> 0 Then
            'Updated by sendhil-Abishek Type:Formview-UP
            Dim qrystring As String = "RptCertificateViewer.aspx?" & QueryStr.Querystring() & "&Course=" & GlobalFunction.IdCutter(txtCourse.Text) & "&BatchVal=" & GlobalFunction.IdCutter(txtBatch.Text) & "&StdCode=" & GlobalFunction.IdCutter(txtStdCode.Text)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            'Response.Redirect("RptCertificateViewer.aspx?Course=" & GlobalFunction.IdCutter(txtCourse.Text) & "&Branch=" & Session("BranchID") & "&Insti=" & Session("InstituteID") & "&BatchVal=" & GlobalFunction.IdCutter(txtBatch.Text) & "&StdCode=" & GlobalFunction.IdCutter(txtStdCode.Text))
        Else
            lblErrorMsg.Text = "No Records Found."
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblErrorMsg.Text = ""
        txtCourse.Focus()
    End Sub

    Protected Sub AutoCompleteExtender1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.PreRender
        Try
            If txtBatch.Text <> "" Then
                Session("sesBatch") = GlobalFunction.IdCutter(txtBatch.Text)
            End If
        Catch
            txtBatch.Text = "Not a valid option.Try again."
            txtBatch.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class


