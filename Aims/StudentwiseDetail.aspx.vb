Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Partial Class IndStudentResult
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
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtBatch.Text <> "" And txtCourse.Text <> "" And txtStdCode.Text <> "" Then
            Dim dtM As New Data.DataTable
            dtM = StudentDB.RPT_GetStudentwiseDetails(Session("InstituteID"), Session("BranchID"), GlobalFunction.IdCutter(txtCourse.Text), GlobalFunction.IdCutter(txtBatch.Text), GlobalFunction.IdCutter(Me.txtStdCode.Text)).Tables(0)
            If dtM.Rows.Count <> 0 Then
                'Response.Redirect("RptStudentwiseDetail.aspx?Course=" & GlobalFunction.IdCutter(txtCourse.Text) & "&Branch=" & Session("BranchID") & "&Insti=" & Session("InstituteID") & "&BatchVal=" & GlobalFunction.IdCutter(txtBatch.Text) & "&Stdid=" & GlobalFunction.IdCutter(txtStdCode.Text))
                Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptStudentwiseDetail.aspx?" & QueryStr.Querystring() & "&Course=" & GlobalFunction.IdCutter(txtCourse.Text) & "&BatchVal=" & GlobalFunction.IdCutter(txtBatch.Text) & "&Stdid=" & GlobalFunction.IdCutter(txtStdCode.Text)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

            Else
                lblErrorMsg.Text = "No Records Found."
            End If
        Else
            Dim dtM As New Data.DataTable
            dtM = StudentDB.RPT_GetStudentwiseDetails(Session("InstituteID"), Session("BranchID"), GlobalFunction.IdCutter(txtCourse.Text), GlobalFunction.IdCutter(txtBatch.Text), 0).Tables(0)
            If dtM.Rows.Count <> 0 Then
                Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptStudentwiseDetail.aspx?" & QueryStr.Querystring() & "&Course=" & GlobalFunction.IdCutter(txtCourse.Text) & "&BatchVal=" & GlobalFunction.IdCutter(txtBatch.Text) & "&Stdid=" & 0
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                lblErrorMsg.Text = "No Records Found."
            End If
        End If
    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        alert = "alert('" & str & "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alert, True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblErrorMsg.Text = ""
        txtCourse.Focus()
    End Sub
    Protected Sub AutoCompleteExtender1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.PreRender
        Try
            If txtBatch.Text <> "" Then
                Session("sesBatch") = GlobalFunction.IdCutter(txtBatch.Text)
                'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptStudentwiseDetail.aspx?" & QueryStr.Querystring() & "&Course=" & GlobalFunction.IdCutter(txtCourse.Text) & "&BatchVal=" & GlobalFunction.IdCutter(txtBatch.Text)
                'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
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
