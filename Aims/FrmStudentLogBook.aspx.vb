Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.Strings
Partial Class FrmStudentLogBook
    Inherits BasePage
    Dim EL As New ELStudentLogBook
    Dim BL As New BLStudentLogBook
    Dim dt As New DataTable
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                ddlBatch.Focus()
                EL.BatchID = ddlBatch.SelectedValue
                EL.STID = ddlStudent.SelectedValue
                EL.EmpID = DdlLecture.SelectedValue
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
                    EL.ID = ViewState("Std_LogBook_AutoId")
                    'dt = BL.CheckDuplicate(EL)
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
                        BL.UpdateRecord(EL)
                        msginfo.Text = ValidationMessage(1014)
                        btnadd.Text = "ADD"
                        btndetails.Text = "VIEW"
                        lblmsg.Text = ValidationMessage(1017)

                        DisplayStudentLogBook()
                        GVLogBook.PageIndex = ViewState("PageIndex")
                        'Displ()
                        clear()
                    End If
                ElseIf btnadd.CommandName = "ADD" Then
                    EL.ID = 0
                    'dt = BL.CheckDuplicate(EL)
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
                        BL.InsertRecord(EL)
                        msginfo.Text = ValidationMessage(1014)
                        btnadd.CommandName = "ADD"
                        lblmsg.Text = ValidationMessage(1020)
                        ViewState("PageIndex") = 0
                        GVLogBook.PageIndex = 0
                        DisplayStudentLogBook()
                        clear()
                        DisplayStudentLogBook()
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
    Sub DisplayStudentLogBook()
        Dim dt As New DataTable
        EL.ID = 0
        dt = BL.Display(EL)
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
    Sub clear()
        Txtdate.Text = Format(Today, "dd-MMM-yyyy")
        TxtFeedback.Text = ""
    End Sub
    Protected Sub GVLogBook_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVLogBook.PageIndexChanging
        GVLogBook.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVLogBook.PageIndex
        DisplayStudentLogBook()
    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        msginfo.Text = ValidationMessage(1014)
        LinkButton.Focus()

        If btndetails.CommandName <> "BACK" Then
            EL.BatchID = ddlBatch.SelectedValue
            EL.STID = ddlStudent.SelectedValue
            EL.EmpID = DdlLecture.SelectedValue
            EL.LogType = ddlLogtype.SelectedValue
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVLogBook.PageIndex = 0
            DisplayStudentLogBook()
            GVLogBook.Visible = True
            clear()
            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
        Else
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
           
            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
            clear()
            GVLogBook.Visible = True
            GVLogBook.PageIndex = ViewState("PageIndex")
            DisplayStudentLogBook()
        End If
    End Sub
    Protected Sub GVLogBook_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVLogBook.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Std_LogBook_AutoId") = CType(GVLogBook.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            EL.ID = ViewState("Std_LogBook_AutoId")
            BL.ChangeFlag(EL)
            DisplayStudentLogBook()
            GVLogBook.Visible = True
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1028)
            ddlBatch.Focus()
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
            dt = BL.Display(EL)
            GVLogBook.DataSource = dt
            GVLogBook.DataBind()
           
            GVLogBook.Enabled = True
            GVLogBook.Visible = True
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub GVLogBook_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVLogBook.RowEditing
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        EL.ID = ViewState("Std_LogBook_AutoId")
        Txtdate.Text = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("lbl1"), Label).Text
        ddlLogtype.SelectedValue = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("LblLog"), Label).Text
        ddlBatch.SelectedValue = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("StdBatch"), HiddenField).Value
        ddlStudent.Items.Clear()
        ddlStudent.DataSourceID = "ObjStudent"
        ddlStudent.DataBind()
        ddlStudent.SelectedValue = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("StdHidden"), HiddenField).Value
        DdlLecture.Items.Clear()
        DdlLecture.DataSourceID = "objLecturer"
        DdlLecture.DataBind()
        DdlLecture.SelectedValue = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("FacultyHidden"), HiddenField).Value
        TxtFeedback.Text = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("Lbl5"), Label).Text
        ViewState("Std_LogBook_AutoId") = CType(GVLogBook.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        btnadd.Text = "UPDATE"
        btndetails.Text = "BACK"
        EL.ID = ViewState("Std_LogBook_AutoId")
        dt = BL.Display(EL)
        GVLogBook.DataSource = dt
        GVLogBook.DataBind()
       
        GVLogBook.Enabled = False

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
           
            Txtdate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged

    End Sub

    'Protected Sub ddlBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.TextChanged
    '    msginfo.Text = ValidationMessage(1014)
    '    ddlBatch.Focus()
    'End Sub

    Protected Sub ddlStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStudent.TextChanged
        'msginfo.Text = ValidationMessage(1014)
        ddlStudent.Focus()
    End Sub

    Protected Sub DdlLecture_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlLecture.TextChanged
        'msginfo.Text = ValidationMessage(1014)
        DdlLecture.Focus()
    End Sub

    Protected Sub ddlLogtype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLogtype.TextChanged
        'msginfo.Text = ValidationMessage(1014)
        ddlLogtype.Focus()
    End Sub
   
    ''Retriving the text of controls based on Language

  
   
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try
            dt2 = Session("ValidationTable")
            If dt2 Is Nothing Then
                Response.Redirect("LogIn.aspx")
            End If
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
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub
End Class

