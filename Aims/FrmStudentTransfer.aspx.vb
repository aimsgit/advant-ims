
Partial Class FrmStudentTransfer
    Inherits BasePage



    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim st As New Student()
        st.Name = DdlStdCode.SelectedValue
        st.A_year = cmbAcademic.SelectedValue

    End Sub

    Protected Sub ddlToBatch_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToBatch.PreRender
        If ddlToBatch.Items.Count > 0 Then
            If ddlToBatch.Items(0).Text <> "Select" Then
                ddlToBatch.Items.Insert(0, "Select")
            End If
        Else
            ddlToBatch.Items.Insert(0, "Select")
        End If
    End Sub

    'Protected Sub DdlStdCode_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlStdCode.PreRender
    '    If DdlStdCode.Items.Count > 0 Then
    '        If DdlStdCode.Items(0).Text <> "Select" Then
    '            DdlStdCode.Items.Insert(0, "Select")
    '        End If
    '    Else
    '        DdlStdCode.Items.Insert(0, "Select")
    '    End If
    'End Sub

    'Protected Sub ddlFromBatch_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFromBatch.PreRender
    '    If ddlFromBatch.Items.Count > 0 Then
    '        If ddlFromBatch.Items(0).Text <> "Select" Then
    '            ddlFromBatch.Items.Insert(0, "Select")
    '        End If
    '    Else
    '        ddlFromBatch.Items.Insert(0, "Select")
    '    End If
    'End Sub
    <System.Web.Services.WebMethod()> _
       Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
