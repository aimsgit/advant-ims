Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.Strings
Partial Class frmEmployeeLogBook
    Inherits BasePage
    Dim EL As New ELEmployeeLogBook
    Dim BL As New BLStudentLogBook
    Dim dt As New DataTable


    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                ddlDepartment.Focus()
                EL.DeptID = ddlDepartment.SelectedValue
                EL.EmpID = ddlEmployee.SelectedValue
                'EL.FacultyID = ddlFaculty.SelectedValue

                If Txtdate.Text = "" Then
                    EL.LogDate = "01-01-1900"
                Else
                    EL.LogDate = Txtdate.Text
                End If
                EL.LogType = ddlLogtype.SelectedValue
                EL.Feedback = TxtFeedback.Text
                If TxtFeedback.Text = "" Then
                    msginfo.Text = ValidationMessage(1189)
                    Exit Sub
                End If
                If btnadd.Text = "UPDATE" Then
                    EL.ID = ViewState("Emp_LogBook_AutoId")
                    'If ddlEmployee.SelectedValue = ddlFaculty.SelectedValue Then
                    '    msginfo.Text = "You can't write your own Log."
                    '    Exit Sub
                    'End If


                    If EL.LogDate <> "1/1/1900" Then
                        If CDate(Txtdate.Text) > CDate(Today.Date) Then
                            lblmsg.Text = ValidationMessage(1014)
                            msginfo.Text = ValidationMessage(1190)
                            Txtdate.Focus()
                            Exit Sub
                        End If
                    End If
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1030)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        BL.UpdateRecordEmp(EL)
                        msginfo.Text = ValidationMessage(1014)


                        btnadd.Text = "ADD"
                        btndetails.Text = "VIEW"
                        lblmsg.Text = ValidationMessage(1017)
                        DisplayEmployeeLogBook()

                        GVLogBook.PageIndex = ViewState("PageIndex")



                        clear()

                    End If
                ElseIf btnadd.Text = "ADD" Then
                    EL.ID = 0
                    'If ddlEmployee.SelectedValue = ddlFaculty.SelectedValue Then
                    '    msginfo.Text = "You can't write your own Log."


                    'Else


                    If EL.LogDate <> "1/1/1900" Then
                        If CDate(Txtdate.Text) > CDate(Today.Date) Then
                            lblmsg.Text = ValidationMessage(1014)
                            msginfo.Text = ValidationMessage(1190)
                            Txtdate.Focus()
                            Exit Sub
                        End If

                        'End If
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = ValidationMessage(1030)
                            lblmsg.Text = ValidationMessage(1014)
                        Else
                            BL.InsertRecordEmp(EL)
                            msginfo.Text = ValidationMessage(1014)
                            btnadd.Text = "ADD"
                            lblmsg.Text = ValidationMessage(1020)
                            ViewState("PageIndex") = 0
                            GVLogBook.PageIndex = 0
                            DisplayEmployeeLogBook()
                            clear()
                            DisplayEmployeeLogBook()
                        End If
                End If
                End If
            Catch ex As Exception
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1055)
            End Try

        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Sub clear()
        Txtdate.Text = Format(Today, "dd-MMM-yyyy")
        TxtFeedback.Text = ""
        
    End Sub
    



    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try
            dt2 = Session("ValidationTable")
            Dim X As Integer = dt2.Rows.Count() - 1
            Dim str As String = " "
            For i As Integer = 0 To X
                If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                    Return dt2.Rows(i).Item("MessageText").ToString()
                End If
            Next
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
    Sub DisplayEmployeeLogBook()
        Dim dt As New DataTable
        EL.ID = 0
        EL.DeptID = ddlDepartment.SelectedValue
        EL.EmpID = ddlEmployee.SelectedValue()
        'EL.FacultyID = ddlFaculty.SelectedValue
        EL.LogType = ddlLogtype.SelectedValue
        dt = BL.DisplayEmp(EL)
        GVLogBook.DataSource = dt
        GVLogBook.DataBind()
        GVLogBook.Visible = True
        GVLogBook.Enabled = True
        LinkButton.Focus()
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ValidationMessage(1014)

            msginfo.Text = ValidationMessage(1023)
            'msginfo.Visible = True
        End If
    End Sub
    Protected Sub GVLogBook_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVLogBook.PageIndexChanging
        GVLogBook.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVLogBook.PageIndex
        DisplayEmployeeLogBook()
    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        msginfo.Text = ValidationMessage(1014)
        LinkButton.Focus()

        If btndetails.Text <> "BACK" Then
            EL.DeptID = ddlDepartment.SelectedValue
            EL.EmpID = ddlEmployee.SelectedValue()
            'EL.FacultyID = ddlFaculty.SelectedValue
            EL.LogType = ddlLogtype.SelectedValue
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVLogBook.PageIndex = 0
            DisplayEmployeeLogBook()
            GVLogBook.Visible = True

        Else
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)

            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
            clear()
            GVLogBook.Visible = True
            GVLogBook.PageIndex = ViewState("PageIndex")
            DisplayEmployeeLogBook()
        End If
    End Sub
    Protected Sub GVLogBook_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVLogBook.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If CType(GVLogBook.Rows(e.RowIndex).Cells(1).FindControl("logflag"), HiddenField).Value = "Y" Then
                msginfo.Text = " This Record is  Locked,You can't Delete the data,"
                lblmsg.Text = ""
                Exit Sub
            Else

                ViewState("Emp_LogBook_AutoId") = CType(GVLogBook.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
                EL.ID = ViewState("Emp_LogBook_AutoId")
                BL.ChangeFlagEmp(EL)
                DisplayEmployeeLogBook()
                GVLogBook.Visible = True
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1028)
                ddlDepartment.Focus()
                GVLogBook.PageIndex = ViewState("PageIndex")
                If Txtdate.Text = "" Then
                    EL.LogDate = "01-01-1900"
                Else
                    EL.LogDate = CDate(Txtdate.Text)
                End If
                If TxtFeedback.Text = "" Then
                    EL.Feedback = 0
                Else
                    EL.Feedback = TxtFeedback.Text
                End If
                dt = BL.DisplayEmp(EL)
                GVLogBook.DataSource = dt
                GVLogBook.DataBind()

                GVLogBook.Enabled = True
                GVLogBook.Visible = True
            End If
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If


    End Sub
    Protected Sub GVLogBook_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVLogBook.RowEditing

        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        EL.ID = ViewState("Emp_LogBook_AutoId")
        Dim dt As New DataTable
        'dt = BL.DisplayEmp(EL)
        If CType(GVLogBook.Rows(e.NewEditIndex).FindControl("logflag"), HiddenField).Value = "Y" Then
            msginfo.Text = " This Record is  Locked,You can't Edit the data,"
            lblmsg.Text = ""
            Exit Sub
        Else

            Txtdate.Text = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("lbl1"), Label).Text
            ddlLogtype.SelectedValue = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("LblLog"), Label).Text
            ddlDepartment.SelectedValue = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("empDept"), HiddenField).Value
            ddlEmployee.Items.Clear()
            ddlEmployee.DataSourceID = "ObjEmplyeeName"
            ddlEmployee.DataBind()
            ddlEmployee.SelectedValue = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("empHidden"), HiddenField).Value
            'ddlFaculty.Items.Clear()
            'ddlFaculty.DataSourceID = "ObjFaculty"
            'ddlFaculty.DataBind()
            'ddlFaculty.SelectedValue = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("FacultyHidden"), HiddenField).Value
            TxtFeedback.Text = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("Lbl5"), Label).Text
            ViewState("Emp_LogBook_AutoId") = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            btnadd.Text = "UPDATE"
            btndetails.Text = "BACK"
            EL.ID = ViewState("Emp_LogBook_AutoId")
            dt = BL.DisplayEmp(EL)
            GVLogBook.DataSource = dt
            GVLogBook.DataBind()

            GVLogBook.Enabled = False
        End If
    End Sub




    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Txtdate.Text = Format(Today, "dd-MMM-yyyy")

End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub




    Protected Sub ddlDepartment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartment.TextChanged
        msginfo.Text = ValidationMessage(1014)
        ddlDepartment.Focus()
    End Sub

    Protected Sub ddlEmployee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployee.TextChanged
        msginfo.Text = ValidationMessage(1014)
        ddlEmployee.Focus()
    End Sub

    'Protected Sub DdlFaculty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFaculty.TextChanged
    '    msginfo.Text = ValidationMessage(1014)
    '    ddlFaculty.Focus()
    'End Sub

    Protected Sub ddlLogtype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLogtype.TextChanged
        msginfo.Text = ValidationMessage(1014)
        ddlLogtype.Focus()
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

    Protected Sub btnLockUnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockUnlock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If ddlDepartment.SelectedValue = 0 Or ddlEmployee.SelectedValue = 0 Or ddlLogtype.SelectedValue = 0 Then
                msginfo.Text = "Department, Employee and LogType Type Fields are Mandatory."
                Exit Sub
            Else
                Dim Dept, EmpName, Logtype As Integer

                Dept = ddlDepartment.SelectedValue
                EmpName = ddlEmployee.SelectedValue
                Logtype = ddlLogtype.SelectedValue
                Dim dt3 As DataSet
                dt3 = DLStudentLogBook.CntData(Dept, EmpName, Logtype)
                If dt3.Tables(0).Rows.Count > 0 Then

                    EL.DeptID = ddlDepartment.SelectedValue
                    EL.EmpID = ddlEmployee.SelectedValue
                    EL.LogType = ddlLogtype.SelectedValue
                    ControlsPanel.Visible = False
                    PasswordPanel.Visible = True
                    txtPassword.Focus()
                    lblpassError.Text = ""
                    Image1.Visible = False
                    Image2.Visible = False
                Else
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblmsg.Text = ""
                    msginfo.Text = ""
                    msginfo.Text = "No Records to Lock/Unlock."
                    Image1.Visible = True
                    Image2.Visible = True

                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot Lock/Unlock data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            'Dim ExamBatchId As Integer
            Dim Dept, EmpName, Logtype As Integer
            Dept = ddlDepartment.SelectedValue
            EmpName = ddlEmployee.SelectedValue
            Logtype = ddlLogtype.SelectedValue
            '1
            'ViewState("ExamBatchId") = ddlExamBatch.SelectedValue
            If DLStudentLogBook.CntData1(Dept, EmpName, Logtype).Tables(0).Rows(0).Item(0) = "N" Then
                'If DL.CheckLockExamPaperEvaluation(ExamBatchId) = "N" Then
                'If DLExamPaperEvaluation.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = DLStudentLogBook.CntData2(Dept, EmpName, Logtype)
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    msginfo.Text = ""
                    lblmsg.Text = roweffected.ToString + " Records are Locked."
                    DisplayEmployeeLogBook()
                    GVLogBook.Enabled = False
                    Image1.Visible = True
                    Image2.Visible = True
                End If
                '1
            Else

                Dim role As String
                role = Session("UserRole")
                'Dim checkUnlock As String
                ' dt1 = DLNew_StudentMarks.CheckUnlockStatus(role)
                '2
                If Session("SecurityCheck") = "Security Check" Then

                    dt = DLStudentLogBook.GetunlockData(role)
                    '3
                    If dt.Rows.Count < 1 Then
                        msginfo.Text = "You don't have Unlock Permission."
                        lblmsg.Text = ""
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        GVLogBook.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    Else
                        Check = dt.Rows(0)("Result").ToString.Trim

                        'check = dt.Rows(0)("Result").ToString.Trim
                        '4
                        If Check = "" Then

                            msginfo.Text = "You don't have Unlock Permission."
                            lblmsg.Text = ""
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GVLogBook.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                            '4
                        Else
                            Dim roweffected As Integer = DLStudentLogBook.UnLockData(Dept, EmpName, Logtype)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                msginfo.Text = ""
                                lblmsg.Text = roweffected.ToString + " Records are  Unlocked."
                                DisplayEmployeeLogBook()
                                Image1.Visible = True
                                Image2.Visible = True
                            End If
                            '4
                        End If
                        '3
                    End If
                    '2
                Else
                    Dim roweffected As Integer = DLStudentLogBook.UnLockData(Dept, EmpName, Logtype)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        msginfo.Text = ""
                        lblmsg.Text = roweffected.ToString + " Records Unlocked."
                        DisplayEmployeeLogBook()
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                    '2
                End If
                '1
            End If
        ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
            ControlsPanel.Visible = True
            PasswordPanel.Visible = False
            lblmsg.Text = ""
            msginfo.Text = ""
            msginfo.Text = "Enter correct password"
            Image1.Visible = True
            Image2.Visible = True
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
