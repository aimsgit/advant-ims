Imports System.Data
Imports System.IO
Partial Class StudentPerformance
    Inherits BasePage
    Dim alert As String
    Dim BAL As New CourseManager
    Dim GlobalFunction As New GlobalFunction
    Dim shdtls As Boolean
    Sub FillSubject()
        Try
            If txtBatch.Text <> "" Then
                Dim Subject As New SubjectManager
                ddlSubject.DataSource = Subject.GetBatchWiseSubject(GlobalFunction.IdCutter(txtBatch.Text))
                ddlSubject.DataBind()
            End If
        Catch
            msginfo.Text = "Please select Academic Year."
        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If HttpContext.Current.Session("InstituteID") <> Nothing And txtBatch.Text <> "" And HttpContext.Current.Session("BranchID") <> Nothing And txtCourse.Text <> "" And ddlSubject.SelectedItem.Value <> 0 Then
            Dim dtM As New Data.DataTable
            Dim ins As Int32 = HttpContext.Current.Session("InstituteID")
            Dim bra As Int32 = HttpContext.Current.Session("BranchID")
            Dim bl As New StdResultB

            dtM = bl.GetStdPerformance(ins, bra, GlobalFunction.IdCutter(txtCourse.Text), GlobalFunction.IdCutter(txtBatch.Text), ddlSubject.SelectedItem.Value)
            If dtM.Rows.Count > 0 Then
                Dim qrystring As String = "RptStdPerformance.aspx?" & QueryStr.Querystring() & "&Course=" & GlobalFunction.IdCutter(txtCourse.Text) & "&BatchVal=" & GlobalFunction.IdCutter(txtBatch.Text) & "&Subject=" & ddlSubject.SelectedItem.Value
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                msginfo.Visible = True
                msginfo.Text = "No Records Found."
            End If
        Else
            msginfo.Visible = True
            msginfo.Text = "Select all the required fields."
        End If
        shdtls = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        shdtls = False
    End Sub
    Protected Sub AutoCompleteExtender1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.PreRender
        If shdtls = False Then
            FillSubject()
        End If
    End Sub
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

    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
