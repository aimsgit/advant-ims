Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports StudentManager
Imports System.Data.SqlClient
Imports FreeTextBoxControls
Partial Class frmSendingExamMarks
    Inherits BasePage
    Dim DL As New DLSendExamMarks
    Dim dt As New DataTable
    Dim Mode As String
    Dim MsgCount As Integer
    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then

            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True
            Next
        Else

            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub btnViewMsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewMsg.Click
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        ViewState("PageIndex") = 0
        GridView1.PageIndex = 0
        DisplayGrid()
        MsgCount = dt.Rows.Count
        If MsgCount <> 0 Then
            lblMsg.Text = MsgCount.ToString + "  Message(s) generated."
            GridView1.Visible = True
        Else
            lblMsg.Text = ""
        End If
       
    End Sub
    Sub DisplayGrid()
        Dim Batchid As Integer = ddlbatch.SelectedValue
        Dim Semesterid As Integer = ddlsemester.SelectedValue
        Dim Assessmentid As Integer = ddlass.SelectedValue
        If ChkMarks.Checked = False And ChkAttendance.Checked = False Then
            lblErrorMsg.Text = "Please check message type to send."
            lblMsg.Text = ""
            Exit Sub
        End If
        If ChkMarks.Checked = True And ChkAttendance.Checked = False Then
            dt = DL.ViewSendMessage(Batchid, Semesterid, Assessmentid)
        End If
        If ChkAttendance.Checked = True And ChkMarks.Checked = True Then
            dt = DL.ViewSendMessage1(Batchid, Semesterid, Assessmentid)
        End If
        If ChkMarks.Checked = False And ChkAttendance.Checked = True Then
            dt = DL.ViewSendMessage2(Batchid, Semesterid, Assessmentid)
        End If

        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display."
        Else
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
        End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If GridView1.EditIndex <> -1 Then
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
        Else
            GridView1.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GridView1.PageIndex
            DisplayGrid()
        End If
    End Sub
    Protected Sub btnSendMsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendMsg.Click
        Dim prefix As String, ContactNo As String, Message As String, Mode As String, Email As String
        Dim count As Integer = 0
        Dim Assessment1 As Integer = ddlass.SelectedItem.Value
        Dim Batch As Integer = ddlbatch.SelectedItem.Value
        Dim Semester As Integer = ddlsemester.SelectedItem.Value
        Dim Assessment As String = ddlass.SelectedItem.Text
        Dim premsg As String = txtPreMsg.Text
        If (Session("BranchCode") = Session("ParentBranch")) Then
            For Each Grid As GridViewRow In GridView1.Rows
                If CType(Grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                    count = count + 1
                End If
            Next
            If count = 0 Then
                lblMsg.Text = ""
                lblErrorMsg.Text = "Please select the record to send message."
                Exit Sub
            End If
            If CheckSMS.Checked = False And CheckEmail.Checked = False Then
                lblErrorMsg.Text = "Please select sending mode."
                lblMsg.Text = ""
                Exit Sub
            End If
            For Each Grid As GridViewRow In GridView1.Rows
                If CType(Grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                    prefix = "Student Marks/Attendance"
                    If CType(Grid.FindControl("lblFContact"), Label).Text = "" Then
                        ContactNo = CType(Grid.FindControl("lblSContact"), Label).Text
                    Else
                        ContactNo = CType(Grid.FindControl("lblSContact"), Label).Text + "," + CType(Grid.FindControl("lblFContact"), Label).Text
                    End If
                    If CType(Grid.FindControl("lblFMail"), Label).Text = "" Then
                        Email = CType(Grid.FindControl("lblSMail"), Label).Text
                    Else
                        Email = CType(Grid.FindControl("lblSMail"), Label).Text + "," + CType(Grid.FindControl("lblFMail"), Label).Text
                    End If
                    If ContactNo <> "" Or Email <> "" Then

                        Message = premsg + "-" + CType(Grid.FindControl("lblSem"), Label).Text

                        If CheckSMS.Checked = True And CheckEmail.Checked = False Then
                            Mode = "SMS"
                            SendSMS(prefix, ContactNo, Message, Mode, Batch, Semester, Assessment1)

                        ElseIf CheckEmail.Checked = True And CheckSMS.Checked = False Then
                            Mode = "Email"
                            SendEmail(prefix, Email, Message, Mode, Batch, Semester, Assessment1)

                        ElseIf CheckEmail.Checked = True And CheckSMS.Checked = True Then
                            Mode = "SMS"
                            SendSMS(prefix, ContactNo, Message, Mode, Batch, Semester, Assessment1)
                            Mode = "Email"
                            SendEmail(prefix, Email, Message, Mode, Batch, Semester, Assessment1)
                        End If
                    End If
                End If
            Next
            lblErrorMsg.Text = ""
            lblMsg.Text = "Message(s) scheduled for sending."
            CheckSMS.Checked = False
            CheckEmail.Checked = False
            txtPreMsg.Text = ""
            For Each Grid As GridViewRow In GridView1.Rows
                CType(Grid.FindControl("ChkSelect"), CheckBox).Checked = False

            Next

        Else
            lblErrorMsg.Text = "You Do Not Belongs to this Branch."
            lblMsg.Text = ""
        End If
    End Sub
    Sub SendSMS(ByVal prefix As String, ByVal ContactNo As String, ByVal Message As String, ByVal Mode As String, ByVal Batch As Integer, ByVal Semester As Integer, ByVal Assessment As Integer)
        DL.InsertSendMessage(prefix, ContactNo, Message, Mode, Batch, Semester, Assessment)
    End Sub
    Sub SendEmail(ByVal prefix As String, ByVal Email As String, ByVal Message As String, ByVal Mode As String, ByVal Batch As Integer, ByVal Semester As Integer, ByVal Assessment As Integer)
        DL.InsertSendMessage(prefix, Email, Message, Mode, Batch, Semester, Assessment)
    End Sub

    Protected Sub LinkMsgHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkMsgHistory.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim BatchId As Integer
            Dim SemId As Integer
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            If ddlbatch.SelectedValue = 0 Then
                lblErrorMsg.Text = "Please select batch."
                Exit Sub
            Else
                BatchId = ddlbatch.SelectedValue
            End If
            If ddlsemester.SelectedValue = 0 Then
                lblErrorMsg.Text = "Please select semester."
                Exit Sub
            Else
                SemId = ddlsemester.SelectedValue
            End If

            
            Dim qrystring As String = "ViewMsgHistory.aspx?" & QueryStr.Querystring() & "&BatchId=" & BatchId & "&SemId=" & SemId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot view."
            lblMsg.Text = ""
        End If
    End Sub
End Class
