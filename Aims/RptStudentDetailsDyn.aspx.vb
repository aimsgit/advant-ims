
Partial Class RptStudentDetailsDyn
    Inherits BasePage
    Dim DL As New DLStudentDetAICTE
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim dt2 As New DataTable
    Dim dt3 As New DataTable
    Dim dt4 As New DataTable
    Dim dt5 As New DataTable



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dt = DLStudentDetAICTE.StdDetail()
            GVAdmission.DataSource = dt
            GVAdmission.DataBind()
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            '    DDLBranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If
    End Sub
    Sub CheckAll()
        If CType(GVAdmission.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVAdmission.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
                btnAdmission.Focus()
            Next
        Else
            For Each grid As GridViewRow In GVAdmission.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub btnAdmission_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdmission.Click
        Dim QS As String
        QS = Request.QueryString.Get("QS")
        Dim semid As Integer
        Dim semid1 As Integer
        Dim semid2 As Integer
        Dim semid3 As Integer
        Dim BatchID As Integer
        Dim Course As Integer
        Dim id As String = ""
        Dim check As String = ""
        Dim str As String = ""
        Dim count As New Integer
        count = GVAdmission.Rows.Count
        Dim i As Integer = 0
        If DDLCourse.SelectedValue = 0 Then
            lblError.Text = "Please Select the Mandatory Fields."
            Exit Sub
        Else
            Course = DDLCourse.SelectedValue
        End If

        If DDLBatch.SelectedValue = 0 Then

            dt5 = DLStudentDetAICTE.batch(Course)

            For Each row As DataRow In dt5.Rows
                BatchID = (row.Item("BatchID"))
                str = str + "," + BatchID.ToString
          

            Next
        Else
            str = DDLBatch.SelectedValue
        End If


        For Each grid As GridViewRow In GVAdmission.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                If CType(grid.FindControl("lblModule"), Label).Text.ToString = "Year1 (% marks)" Then
                    dt1 = DLStudentDetAICTE.sem1
                    semid = dt1.Rows(0).Item("semcode")
                End If

            End If
        Next
        For Each grid As GridViewRow In GVAdmission.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                If CType(grid.FindControl("lblModule"), Label).Text.ToString = "Year2 (% marks)" Then
                    dt2 = DLStudentDetAICTE.sem2
                    semid1 = dt2.Rows(0).Item("semcode")
                End If

            End If
        Next
        For Each grid As GridViewRow In GVAdmission.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                If CType(grid.FindControl("lblModule"), Label).Text.ToString = "Year3 (% marks)" Then
                    dt3 = DLStudentDetAICTE.sem3
                    semid2 = dt3.Rows(0).Item("semcode")
                End If

            End If
        Next
        For Each grid As GridViewRow In GVAdmission.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                If CType(grid.FindControl("lblModule"), Label).Text.ToString = "Year4 (% marks)" Then
                    dt4 = DLStudentDetAICTE.sem4
                    semid3 = dt4.Rows(0).Item("semcode")
                End If

            End If

        Next
        For Each grid As GridViewRow In GVAdmission.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                check = "[" + CType(grid.FindControl("lblModule"), Label).Text.ToString + "]"
                id = id + "," + check
            End If
        Next
        If id <> "" Then
            lblError.Text = ""
            id = Right(id, id.Length - 1)
            Dim qrystring As String = "RptStudentDetailsDynamic.aspx?" & QueryStr.Querystring() & "&id=" & id & "&Course=" & DDLCourse.SelectedValue & "&Batch=" & DDLBatch.SelectedValue & "&semid=" & semid & "&semid1=" & semid1 & "&semid2=" & semid2 & "&semid3=" & semid3 & "&str=" & str
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Else
            lblError.Text = " Select atleast one column name."
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
