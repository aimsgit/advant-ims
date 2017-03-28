
Partial Class PopFile
    Inherits BasePage
    Dim EL As New ELDocUpload
    Dim BL As New BLDocUpload
    Dim DL As New DLDocUpload
    Dim dt As DataTable
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        lblR.Text = ""
        lblG.Text = ""
        If btnsearch.Text.Equals("SEARCH") Then
            disp()
        Else
            btnsearch.CommandName = "SEARCH"
            btnsearch.Text = "SEARCH"
            disp()
        End If
    End Sub
    Sub disp()
        EL.Desc = txtdesc.Text
        EL.id = 0
        dt = BL.GetGridData(EL)
        If dt.Rows.Count > 0 Then
            gvdoc.DataSource = dt
            gvdoc.DataBind()
        Else
            lblR.Text = "No Records to display."
            lblG.Text = ""
        End If
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim link As String = ""
        Dim flag As Integer = 0
        For Each grid As GridViewRow In gvdoc.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                link = CType(grid.FindControl("lbllink"), HiddenField).Value.ToString
                'link = link.Replace("\\", "\\\\")
                link = link.Replace("\", "\\")
                flag = flag + 1
            End If
        Next
        If (flag = 2) Then
            lblR.Text = "Please Select One File."
            lblG.Text = ""
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "callFunctionsStartupScript", "javascript:changeparent( '" + link + "');", True)
          End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         Dim txt As String = Request.QueryString.Get("txt")
        HidtxtId.Value = txt
        Session("txt") = txt
        Dim flag As Integer = 0
        For Each grid As GridViewRow In gvdoc.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                flag = flag + 1
            End If
        Next
        If (flag > 1) Then
            lblG.Text = ""
            lblR.Text = "Please select one file."
        End If
    End Sub

End Class
