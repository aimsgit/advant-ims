
Partial Class RptSubTeacherMap
    Inherits BasePage
    Dim DL As New DLRptSubTeacherMAp


    Protected Sub Loadsub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Loadsub.Click
        Dim sub1 As String
        sub1 = txtsub.Text
        Dim dt As New DataTable
        dt = DL.GetSubject(sub1)
        If dt.Rows.Count > 0 Then
            lblMsg.Text = ""
            For i As Integer = 0 To dt.Rows.Count - 1

                ListBox1.DataSource = dt
                ListBox1.DataBind()
                ListBox1.Visible = True
                ListBox1.DataTextField = "subject_Name"
                lblMsg.Text = ""
            Next
        Else
            lblMsg.Text = "No Records to Display."
            ListBox1.Items.Clear()
        End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim str As String = ""
        Dim id As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBox1.Items.Count - 1


        If ListBox1.Items.Count <> 0 Then
            'If (ListBox1.Items(i).Selected = True) Then
            For Each items In ListBox1.Items

                If (ListBox1.Items(i).Selected = True) Then
                    str = ListBox1.Items(i).Value
                    id = str + "," + id
                    'str = str + 1
                    'For i = 0 To ListBox1.Items.Count - 1
                    '    items &= ListBox1.SelectedValue(i) & ","
                    'Next
                End If
                i = i + 1
            Next
            If id <> "" Then
                Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptSubTeacherMapV.aspx?" & QueryStr.Querystring() & "&id=" & id
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                lblMsg.Text = ""
            Else
                lblMsg.Text = "Select atleast one Subject."
            End If

           
        Else
            lblMsg.Text = "Select atleast one Subject."

        End If
        'Else
        'lblMsg.Text = "Select atleast one Subject."

        'End If


    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
