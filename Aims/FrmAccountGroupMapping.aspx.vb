
Partial Class FrmAccountGroupMapping
    Inherits BasePage
    Dim EL As New ELAccountGroupMapping
    Dim BL As New BLAccountGroupMapping
    Dim dt, dt1 As New DataTable

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        EL.AccountGroupId = cmbAGOne.SelectedValue
        dt = BL.GetAccounSubGroup(EL)
        GV1.DataSource = dt
        GV1.DataBind()
        GV1.Visible = True
        dt1 = BL.GetClientAccounSubGroup(EL)
        GV2.DataSource = dt1
        GV2.DataBind()
        GV2.Visible = True

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        For Each grid As GridViewRow In GV2.Rows
            If CType(grid.FindControl("ChkPresent1"), CheckBox).Checked = True Then
                EL.AccountGroup2 = CType(grid.FindControl("lblAcct"), Label).Text
                For Each grid1 As GridViewRow In GV1.Rows
                    If CType(grid1.FindControl("ChkPresent"), CheckBox).Checked = True Then
                        EL.AccountSubGroupId = CType(grid1.FindControl("Label2"), Label).Text
                        EL.AccountGroupId = CType(grid1.FindControl("Label9"), Label).Text
                        EL.AccountSubGroup = CType(grid1.FindControl("Label1"), Label).Text
                        BL.Update(EL)
                    End If
                Next
            End If
        Next
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        For Each Grid1 As GridViewRow In GV2.Rows
            If CType(Grid1.FindControl("ChkPresent1"), CheckBox).Checked = False Then
                lblErrorMsg.Text = "Select Account Group 2."
                lblmsg.Text = ""
                Exit For
            End If
        Next
        For Each grid As GridViewRow In GV2.Rows
            If CType(grid.FindControl("ChkPresent1"), CheckBox).Checked = True Then
                EL.AccountGroup2 = CType(grid.FindControl("lblAcct"), Label).Text
                dt = BL.GetAccounSubGroup2(EL)
                GV1.DataSource = dt
                GV1.DataBind()
                GV1.Visible = True
                lblErrorMsg.Text = ""
                lblmsg.Text = ""
                For Each grid1 As GridViewRow In GV1.Rows
                    CType(grid1.FindControl("ChkPresent"), CheckBox).Checked = True
                Next
                Exit For
            End If
        Next
    End Sub
    Sub CheckAll()
        If CType(GV1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            'BL.UpdateCollectionVerification(EL)
            For Each grid As GridViewRow In GV1.Rows
                CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True
            Next
        Else
            'BL.UpdateCollectionVerification(EL)
            For Each grid As GridViewRow In GV1.Rows
                CType(grid.FindControl("ChkPresent"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Sub CheckAll1()
        If CType(GV2.HeaderRow.FindControl("ChkAll1"), CheckBox).Checked = True Then
            'BL.UpdateCollectionVerification(EL)
            For Each grid As GridViewRow In GV2.Rows
                CType(grid.FindControl("ChkPresent1"), CheckBox).Checked = True
            Next
        Else
            'BL.UpdateCollectionVerification(EL)
            For Each grid As GridViewRow In GV2.Rows
                CType(grid.FindControl("ChkPresent1"), CheckBox).Checked = False
            Next
        End If
    End Sub
End Class
