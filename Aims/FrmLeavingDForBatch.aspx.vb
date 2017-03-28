
Partial Class FrmLeavingDForBatch
    Inherits BasePage
    Dim DL As DLLeaveApplication
    Dim dt As New DataTable
    Dim EL As Student

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        lblMsg.Text = ""
        msginfo.Text = ""
        Dim batch As Integer
        Dim leaving As String
        batch = cmbBatch.SelectedValue

        dt = DLLeaveApplication.GetLeavingDateDetials(batch)
        If dt.Rows.Count > 0 Then
            G1.Visible = True
            G1.DataSource = dt
            G1.DataBind()
            txtLod.Text = ""

        Else
            txtLod.Text = ""
            lblMsg.Text = ""
            msginfo.Text = "No Record to display"
            G1.Visible = False

        End If
        btnUpdate.Enabled =True 

    End Sub
    Sub CheckAll()
        If CType(G1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In G1.Rows
                CType(grid.FindControl("ChkLeavingDate"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In G1.Rows
                CType(grid.FindControl("ChkLeavingDate"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim check As String = ""
        Dim count1, chk As New Integer
        Dim leaving As String
        count1 = 0
        chk = 0
        Dim std As String = ""
        For Each Grid As GridViewRow In G1.Rows

            If (CType(Grid.FindControl("ChkLeavingDate"), CheckBox).Checked = True) Then
                chk = chk + 1
                If (CType(Grid.FindControl("lblLvDate"), Label).Text = "") Then
                    check = CType(Grid.FindControl("IID"), Label).Text

                    std = check + "," + std
                    count1 = count1 + 1

                End If
            End If

        Next
        If chk = 0 Then

            msginfo.Text = "Select alteast one Record. "
            lblMsg.Text = ""
            Exit Sub
        End If
        If std = "" Then
            std = 0
        Else
            std = Left(std, std.Length - 1)
        End If





        leaving = txtLod.Text

        DLLeaveApplication.Update(std, leaving)
        If std <> 0 Then
            msginfo.Text = ""
            lblMsg.Text = "Data Updated Successfully"
        Else
            lblMsg.Text = ""
            msginfo.Text = "Leaving Date is Already Exist."
        End If

        Dim Batch As Integer = cmbBatch.SelectedValue

        dt = DLLeaveApplication.GetLeavingDateDetials(Batch)
        G1.DataSource = dt
        G1.DataBind()


    End Sub

    
End Class
