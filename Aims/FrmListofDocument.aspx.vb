
Partial Class FrmListofDocument
    Inherits BasePage
    Dim DL As New DLListofSubmitted
    Dim dt1 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim str As String = ""
        Dim str1 As String = ""
        Dim stdid As Integer
        Dim id1 As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        If (ListBatch.SelectedValue = "" Or "0") Then
            lblErrorMsg.Text = "Batch field is Mandatory."
            Exit Sub
        End If
        stdid = ddlStudent.SelectedValue
        i = 0
        j = ListBatch.Items.Count - 1
        If ListBatch.Items.Count <> 0 Then
            For Each items In ListBatch.Items
                If (ListBatch.Items(i).Selected = True) Then
                    str = ListBatch.Items(i).Value
                    id1 = str + "," + id1
                End If
                i = i + 1
            Next
        End If
       

        Dim qrystring As String = "FrmListofDocumentV.aspx?" & "&stdid=" & stdid & "&id1=" & id1
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        lblErrorMsg.Text = ""
    End Sub

    Protected Sub ListBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBatch.SelectedIndexChanged
        lblErrorMsg.Text = ""

        Dim str As String = ""
        Dim str1 As String = ""
        Dim id1 As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer

        If (ListBatch.SelectedValue = "" Or "0") Then
            lblErrorMsg.Text = "Batch field is Mandatory."
            Exit Sub
        End If
        i = 0
        j = ListBatch.Items.Count - 1
        If ListBatch.Items.Count <> 0 Then
            For Each items In ListBatch.Items
                If (ListBatch.Items(i).Selected = True) Then
                    str = ListBatch.Items(i).Value
                    id1 = str + "," + id1
                End If
                i = i + 1
            Next
        End If
        dt1 = DL.GetStudentNameCombo(id1)

        ddlStudent.DataSource = dt1
        ddlStudent.DataBind()


    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
