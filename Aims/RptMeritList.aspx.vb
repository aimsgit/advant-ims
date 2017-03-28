
Partial Class RptMeritList
    Inherits BasePage
    Dim dl As New feeCollectionDL
    Dim str As String = ""
    Dim str1 As String = ""
    Dim id1 As String = ""
    Dim id2 As String = ""

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim QS As String
        Dim course As Integer = ddlCourseName.SelectedValue
        GetBatchid()
        Dim Batch As String = id1
        Dim Semester As Integer = ddlSemester.SelectedValue
        'Dim Subject As Integer = ddlSubject.SelectedValue
        'Dim AssessmentType As Integer = ddlassesment.SelectedValue
        Dim RBType As Integer = RBReport.SelectedValue
        
        Dim batName As String = id2
        Dim Top As Integer
        Dim Bottom As Integer
        If txtTop.Text = "" And txtBottom.Text = "" Then
            Top = 500
            Bottom = 500
        ElseIf txtTop.Text <> "" And txtBottom.Text <> "" Then
            Top = txtTop.Text
            Bottom = txtBottom.Text
        ElseIf txtTop.Text = "" And txtBottom.Text <> "" Then
            Top = 0
            Bottom = txtBottom.Text
        Else
            Top = txtTop.Text
            Bottom = 0
        End If

      
        Dim Gender As Integer
        If chkMale.Checked = True And chkFemale.Checked = False Then
            Gender = 1
        ElseIf chkFemale.Checked = True And chkMale.Checked = False Then
            Gender = 2
        Else
            Gender = 0
        End If

        QS = Request.QueryString.Get("QS")

        If Batch = "" Or ddlSemester.SelectedItem.Text = "Select" Then
            'Or ddlassesment.SelectedValue = 0 
            lblMsg.Text = "Please Select Mandatory Fields."
        Else
            Dim qrystring As String = "RptMeritListV.aspx?" & QueryStr.Querystring() & "&Course=" & course & "&Batch=" & Batch & "&Semester=" & Semester & "&Top=" & Top & "&Bottom=" & Bottom & "&Gender=" & Gender & "&RBType=" & RBType & "&batName=" & batName
            '& "&AssessmentType=" & AssessmentType & "&Subject=" & Subject
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblMsg.Text = ""
        End If



    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlCourseName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseName.SelectedIndexChanged
        Dim dt As New DataTable
        dt = TimeTableDl.GetMeritListBatchCombo(ddlCourseName.SelectedValue)
        If dt.Rows.Count > 0 Then
            lblMsg.Text = ""
            For i As Integer = 0 To dt.Rows.Count - 1

                ListBox1.DataSource = dt
                ListBox1.DataBind()
                ListBox1.Visible = True
                ListBox1.DataTextField = "Batch_No"
                lblMsg.Text = ""
            Next
        Else

            ListBox1.Items.Clear()
        End If
    End Sub

   
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim dt As New DataTable
            dt = TimeTableDl.GetMeritListBatchCombo(0)
            If dt.Rows.Count > 0 Then
                lblMsg.Text = ""
                For i As Integer = 0 To dt.Rows.Count - 1

                    ListBox1.DataSource = dt
                    ListBox1.DataBind()
                    ListBox1.Visible = True
                    ListBox1.DataTextField = "Batch_No"
                    lblMsg.Text = ""
                Next
            Else

                ListBox1.Items.Clear()
            End If
        End If
    End Sub

    Protected Sub Btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn1.Click
        GetBatchid()
        Dim dt1 As New DataTable
        dt1 = dl.SemesterComboMeritList(id1)
        ddlSemester.Items.Clear()
        ddlSemester.DataSource = dt1
        ddlSemester.DataBind()

      
    End Sub

    'Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
    '    Dim Sem As New Integer
    '    Sem = ddlSemester.SelectedValue
    '    GetBatchid()
    '    Dim dt2 As New DataTable
    '    dt2 = DLReportsR.GetSubjectMeritList(id1, Sem)

    '    ddlSubject.Items.Clear()
    '    ddlSubject.DataSource = dt2
    '    ddlSubject.DataBind()


    'End Sub
    Sub GetBatchid()
       
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBox1.Items.Count - 1

        If ListBox1.Items.Count <> 0 Then
            For Each items In ListBox1.Items
                If (ListBox1.Items(i).Selected = True) Then
                    str = ListBox1.Items(i).Value
                    str1 = ListBox1.Items(i).Text
                    id1 = str + "," + id1
                    id2 = str1 + " ,  " + id2
                End If
                i = i + 1
            Next
        End If

    End Sub
End Class
