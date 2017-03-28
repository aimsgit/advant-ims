Imports System.IO
Imports System.Collections.Generic
Imports System.Data

Partial Class frmAdmissionDetails
    Inherits BasePage
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        If CInt(ddlFromAge.SelectedValue) > CInt(ddlToAge.SelectedValue) Then
            msginfo.Text = ValidationMessage(1179)
            Exit Sub
        End If
        If txtFromDateExt.Text = "" Then
            msginfo.Text = ValidationMessage(1117)
            Exit Sub
        End If

        If DDLA_Year.SelectedValue = "" Then
            msginfo.Text = ValidationMessage(1117)
        Else
            Dim qrystring As String = ""
            qrystring = "RegistrationV.aspx?" & "&Branch=" & DDLBranch.SelectedValue & "&Batch=" & cmbBatch.SelectedValue & "&Course=" & ddlCourse.SelectedValue & "&AYear=" & DDLA_Year.SelectedValue & "&Gender=" & DDLGender.SelectedItem.Text & "&State=" & DDLState.SelectedValue & "&Feecollected=" & ddlFeecollected.SelectedValue & "&Country=" & DDLCountry.SelectedValue & "&District=" & ddlDistrict.SelectedItem.Text & "&FromAge=" & ddlFromAge.SelectedValue & "&ToAge=" & ddlToAge.SelectedValue & "&categry=" & ddlcategry.SelectedValue & "&Sort=" & ddlSort.SelectedValue & "&Caste=" & ddlcaste.SelectedValue & "&Hostel=" & ddlHostel.SelectedValue & "&Transport=" & ddlTransport.SelectedValue & "&CurrentDate=" & txtFromDateExt.Text
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("Report.aspx")
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            
            DDLBranch.SelectedValue = Session("BranchCode")
            DDLBranch.Focus()
        End If
    End Sub

    Protected Sub DDLA_Year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLA_Year.SelectedIndexChanged
        msginfo.Text = ValidationMessage(1014)
    End Sub


    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub cmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.SelectedIndexChanged
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub ddlFromAge_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFromAge.SelectedIndexChanged
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub ddlToAge_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToAge.SelectedIndexChanged
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub DDLGender_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLGender.SelectedIndexChanged
        msginfo.Text = ValidationMessage(1014)
    End Sub
    

    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class
