Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient
Partial Class frmAttendenceEligibilityCriteria
    'Created by Ajit,Jinapriya
    Inherits BasePage
    Dim El As New AttendenceEligibilityCriteriaEL
    Dim Bl As New AttendenceEligibilityCriteriaBL
    Dim DL As New AttendenceEligibilityCriteriaDL
    Dim dt As New DataTable
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        DdlBatch.Focus()
        LinkButton1.Focus()
        lblS.Text = ""
        lblE.Text = ""
        'ViewState("PageIndex") = 0
        El.BatchId = DdlBatch.SelectedValue
        El.SemId = DdlSemester.SelectedValue
        El.Min = txtMin.Text
        DispGrid(El)
    End Sub
    Sub DispGrid(ByVal El As AttendenceEligibilityCriteriaEL)
        dt.Clear()
        Dim Str As String = ""
        Dim ID As String = ""
        For Each grid As GridViewRow In GVSubjectDetails.Rows
            If CType(grid.FindControl("ChkSubject"), CheckBox).Checked = True Then
                Str = CType(grid.FindControl("lblsubid"), HiddenField).Value
                ID = Str + "," + ID
            End If
        Next
        El.SubjectID = ID
        dt = Bl.getGrid(El)
        If dt.Rows.Count > 0 Then
            GEligiblity.DataSource = dt
            GEligiblity.DataBind()
            For Each rows As GridViewRow In GEligiblity.Rows
                If CType(rows.FindControl("lblEligible"), Label).Text = "Y" Then
                    CType(rows.FindControl("ChkBx"), CheckBox).Checked = True
                End If
            Next
            GEligiblity.Visible = True
            lblE.Text = ""
            lblS.Text = ""
            btnUpdate.Visible = True
        Else
            GEligiblity.Visible = False
            lblE.Text = "No Records to Display."
            lblS.Text = ""
            btnUpdate.Visible = False
        End If

    End Sub
    Sub CheckAll()
        If CType(GVSubjectDetails.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVSubjectDetails.Rows
                CType(grid.FindControl("ChkSubject"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVSubjectDetails.Rows
                CType(grid.FindControl("ChkSubject"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim R As Integer
            Dim Str As String = ""
            Dim ID As String = ""
            Dim Str1 As String = ""
            Dim ID1 As String = ""
            For Each rows As GridViewRow In GEligiblity.Rows
                If CType(rows.FindControl("ChkBx"), CheckBox).Checked = False Then
                    El.Id = CType(rows.FindControl("STD"), HiddenField).Value
                    El.Min = txtMin.Text
                    El.BatchId = DdlBatch.SelectedValue
                    El.SemId = DdlSemester.SelectedValue
                    El.Eligible = "N"
                    dt = DL.Drilldown(El.Id, El.BatchId, El.SemId, El.Min)
                    While dt.Rows.Count > 0
                        Str = dt.Rows(0).Item("subjectid").ToString()
                        ID = Str + "," + ID
                    End While
                    El.SubjectID = ID
                    R = Bl.UpdateRecord(El)
                    If R = 0 Then
                        lblE.Text = "Records are Locked."
                        lblS.Text = ""
                        Exit Sub
                    End If
                    lblE.Text = ""
                    lblS.Text = "Records Updated successfully."

                Else
                    El.Id = CType(rows.FindControl("STD"), HiddenField).Value
                    El.Min = txtMin.Text
                    El.BatchId = DdlBatch.SelectedValue
                    El.SemId = DdlSemester.SelectedValue
                    El.Eligible = "N"
                    dt = DL.Drilldown1(El.Id, El.BatchId, El.SemId, El.Min)
                    Dim i As Integer
                    i = 0
                    While dt.Rows.Count > i
                        Str = dt.Rows(i).Item("subjectid").ToString()
                        ID = Str + "," + ID
                        Str1 = dt.Rows(i).Item("Subject_Name").ToString()
                        ID1 = Str1 + "," + ID1
                        i = i + 1
                    End While
                    El.SubjectID = ID
                    El.SubjectNamne = ID1
                    El.Eligible = "Y"
                    R = Bl.UpdateRecord(El)
                    If R = 0 Then
                        lblE.Text = "Records are Locked."
                        lblS.Text = ""
                        Exit Sub
                    End If
                    lblE.Text = ""
                    lblS.Text = "Records Updated successfully."

                End If
            Next
        Else
            lblE.Text = "You do not belong to this branch, Cannot update data."
            lblS.Text = ""
        End If


    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub DdlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBatch.SelectedIndexChanged
        btnUpdate.Visible = False
        GVSubjectDetails.Visible = False
    End Sub
    Protected Sub btntransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntransfer.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim id1 As String = ""
            Dim check As String = ""
            Dim check1 As String = ""
            Dim chk As Integer = 0

            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GEligiblity.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = False Then
                    check = CType(grid.FindControl("STD"), HiddenField).Value.ToString
                    check1 = CType(grid.FindControl("stdcode"), Label).Text.ToString
                    id = check + "," + id
                    id1 = check1 + "," + id1
                    count = count + 1
                End If
            Next
            If ddltrsfrBatch.SelectedValue = 0 Then
                lblE.Text = "Select Any Batch to Transfer."
                lblS.Text = ""
                Exit Sub
            Else
                If id = "" Then
                    id = "0"
                    count = 0
                    lblE.Text = "Please Deselect Atleast One Student to Transfer."
                    lblS.Text = ""
                    Exit Sub
                Else
                    id = Left(id, id.Length - 1)
                End If

                If id1 = "" Then
                    id1 = "0"
                    count = 0
                Else
                    id1 = Left(id1, id1.Length - 1)
                End If
            End If
            El.StdId = id
            El.StdCode = id1
            El.TBatchid = ddltrsfrBatch.SelectedValue
            chk = Bl.InsertStudent(El)
            If chk = 0 Then
                lblE.Text = "No Records to Transfer."
                lblS.Text = ""
            Else
                lblS.Text = "Student(s) Transferred Successfully."
                lblE.Text = ""
            End If

            GEligiblity.Visible = "false"
        Else
            lblE.Text = "You do not belong to this branch, Cannot transfer data."
            lblS.Text = ""
        End If
    End Sub

    Protected Sub btnUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim id1 As String = ""
            Dim check As String = ""
            Dim check1 As String = ""
            Dim chk As Integer = 0

            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GEligiblity.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = False Then
                    check = CType(grid.FindControl("STD"), HiddenField).Value.ToString
                    check1 = CType(grid.FindControl("stdcode"), Label).Text.ToString
                    id = check + "," + id
                    id1 = check1 + "," + id1
                    count = count + 1
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
                
            Else
                id = Left(id, id.Length - 1)
            End If

            If id1 = "" Then
                id1 = "0"
                count = 0
            Else
                id1 = Left(id1, id1.Length - 1)
            End If
            El.StdId = id
            El.StdCode = id1
            El.TBatchid = ddltrsfrBatch.SelectedValue
            chk = Bl.UndoStudent(El)
            If id = 0 Then
                lblE.Text = "No Records to Undo."
                lblS.Text = ""
            Else
                If chk <> count Then
                    lblS.Text = "Transfer Rolled Back Successfully."
                    lblE.Text = ""
                    GEligiblity.DataSource = Nothing
                    GEligiblity.DataBind()
                Else
                    lblE.Text = "No Records to Undo."
                    lblS.Text = ""
                    GEligiblity.Visible = False
                End If
            End If
        Else
            lblE.Text = "You do not belong to this branch, Cannot undo data."
            lblS.Text = ""
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.Clear()
        Response.ClearHeaders()
        Response.ClearContent()
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254")
        Response.Charset = "windows-1254"

        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=AttendanceEligibility.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        GEligiblity.Parent.Controls.Add(frm)
        frm.Controls.Add(GEligiblity)
        frm.RenderControl(hw)
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()       
    End Sub

    Protected Sub GEligiblity_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GEligiblity.RowUpdating
        Dim StdId, BatchId, sem, min As Integer
        BatchId = DdlBatch.SelectedValue
        StdId = CType(GEligiblity.Rows(e.RowIndex).Cells(1).FindControl("STD"), HiddenField).Value
        'BatchId = CType(GElEigiblity.Rows(e.RowIndex).Cells(1).FindControl("HidBatchId"), HiddenField).Value
        sem = DdlSemester.SelectedValue
        min = txtMin.Text
        Dim qrystring As String = "frmAttendanceEligibiltyDrillDown.aspx?" & QueryStr.Querystring() & "&StdId=" & StdId & "&BatchId=" & BatchId & "&sem=" & sem & "&min=" & min
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

    End Sub

    Protected Sub GEligiblity_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GEligiblity.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        El.BatchId = DdlBatch.SelectedValue
        El.SemId = DdlSemester.SelectedValue
        El.Min = txtMin.Text
        Dim Str As String = ""
        Dim ID As String = ""
        For Each grid As GridViewRow In GVSubjectDetails.Rows
            If CType(grid.FindControl("ChkSubject"), CheckBox).Checked = True Then
                Str = CType(grid.FindControl("lblsubid"), HiddenField).Value
                ID = Str + "," + ID
            End If
        Next
        El.SubjectID = ID
        dt = Bl.getGrid(El)
        
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GEligiblity.DataSource = sortedView
        GEligiblity.DataBind()
    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property

    Protected Sub DdlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSemester.SelectedIndexChanged
        ' DdlBatch.Focus()
        Dim BatchId, SemId As Integer
        BatchId = DdlBatch.SelectedValue
        SemId = DdlSemester.SelectedValue
        Dim dt As New DataTable
        dt = Bl.GetSubjectDetails(BatchId, SemId)
        GVSubjectDetails.DataSource = dt
        GVSubjectDetails.DataBind()
        'lblSubject.Visible = True
        GVSubjectDetails.Visible = True
    End Sub
End Class