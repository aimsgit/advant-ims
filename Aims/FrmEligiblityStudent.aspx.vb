Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient
Partial Class FrmEligiblityStudent
    Inherits BasePage
    Dim EL As New ELEligiblityPromotion
    Dim dt As New DataTable
    Dim BL As New BLEligiblityPromotion
    Dim count As Integer


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        LinkButton1.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'If btnSubmit.Text = "SUBMIT" Then
            '    EL.SBatchid = DdlBatchPlanner.SelectedValue
            '    EL.Semid = cmbSemester.SelectedValue
            '    EL.TBatchid = ddltrsfrBatch.SelectedValue
            '    EL.SFailed = cmbSFailed.SelectedValue
            '    'dt = BLEligiblityPromotion.getduplicate(EL)
            '    If dt.Rows.Count > 0 Then
            '        lblmsg.Text = ""
            '        msginfo.Text = "Data Already Exists."
            '        DdlBatchPlanner.Focus()
            '    Else
            '        Dim roweffected1 As Integer = BLEligiblityPromotion.generate(EL)
            '        msginfo.Text = ""
            '        lblmsg.Text = roweffected1.ToString + " Rows Are Generated."
            '        dt = BLEligiblityPromotion.GetData(EL)
            '        If dt.Rows.Count <> 0 Then
            '            GElEigiblity.DataSource = dt
            '            GElEigiblity.DataBind()
            '            GElEigiblity.Visible = True
            '            'If dt.Rows(0)("LockStatus").ToString() = "N" Then
            '            '    GElEigiblity.Enabled = "true"
            '            'Else
            '            '    GElEigiblity.Enabled = "false"
            '            'End If
            '        Else
            '            lblmsg.Text = ""
            '            msginfo.Text = "No records to generate."
            '            DdlBatchPlanner.Focus()
            '            GElEigiblity.Visible = False
            '        End If
            '    End If
            'End If
            EL.SBatchid = DdlBatchPlanner.SelectedValue
            EL.Semid = ddlSem1.SelectedValue
            EL.Semid2 = ddlSem2.SelectedValue
            If ddlSem1.SelectedValue = 0 And ddlSem2.SelectedValue = 0 Then
                msginfo.Text = "Please Select Semester."
                lblmsg.Text = ""
                GElEigiblity.Visible = False
                Exit Sub
            End If
            'Splitter(cmbSemester.SelectedValue)
            EL.Assisment = ddlassesment.SelectedValue
            EL.NoofSubject = cmbSFailed.SelectedValue
            dt = BL.GetResult(EL)
            If dt.Rows.Count > 0 Then
                msginfo.Text = ""
                lblmsg.Text = ""
                GElEigiblity.DataSource = dt
                GElEigiblity.DataBind()
                GElEigiblity.Visible = "true"
                count = count = 1
            Else

                msginfo.Text = "No Records to display."
                lblmsg.Text = ""
                GElEigiblity.Visible = False
            End If

        Else
            msginfo.Text = "You do not belong to this branch, Cannot submit data."
            lblmsg.Text = ""
        End If
    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = Value
        End Set
    End Property


    Sub Splitter(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            EL.Semid = parts(0).ToString()
            EL.Semid2 = parts(1).ToString()
        End If
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
            For Each grid As GridViewRow In GElEigiblity.Rows
                check = CType(grid.FindControl("STD_ID"), HiddenField).Value.ToString
                check1 = CType(grid.FindControl("stdcode"), Label).Text.ToString
                id = check + "," + id
                id1 = check1 + "," + id1
                count = count + 1
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
            EL.StdId = id
            EL.StdCode = id1
            EL.TBatchid = ddltrsfrBatch.SelectedValue
            chk = BL.InsertStudent(EL)
            If chk = 0 Then
                msginfo.Text = "No Records to Transfer."
                lblmsg.Text = ""
            Else
                lblmsg.Text = "Student(s) Transferred Successfully."
                msginfo.Text = ""
            End If

            GElEigiblity.Visible = "false"
        Else
            msginfo.Text = "You do not belong to this branch, Cannot transfer data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub DdlBatchPlanner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBatchPlanner.SelectedIndexChanged
        lblmsg.Text = ""
        msginfo.Text = ""
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
            For Each grid As GridViewRow In GElEigiblity.Rows
                check = CType(grid.FindControl("STD_ID"), HiddenField).Value.ToString
                check1 = CType(grid.FindControl("stdcode"), Label).Text.ToString
                id = check + "," + id
                id1 = check1 + "," + id1
                count = count + 1
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
            EL.StdId = id
            EL.StdCode = id1
            EL.TBatchid = ddltrsfrBatch.SelectedValue
            chk = BL.UndoStudent(EL)
            If id = 0 Then
                msginfo.Text = "No Records to Undo."
                lblmsg.Text = ""
            Else
                If chk <> count Then
                    lblmsg.Text = "Transfer Rolled Back Successfully."
                    msginfo.Text = ""
                    GElEigiblity.DataSource = Nothing
                    GElEigiblity.DataBind()
                Else
                    msginfo.Text = "No Records to Undo."
                    lblmsg.Text = ""
                    GElEigiblity.Visible = False
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot undo data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        If Not IsPostBack Then
            DdlBatchPlanner.Focus()
        End If
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        'End If

    End Sub
    Protected Sub GElEigiblity_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GElEigiblity.RowUpdating


        Dim StdId, BatchId, sem, sem1, assesment As Integer
        BatchId = CType(GElEigiblity.Rows(e.RowIndex).Cells(1).FindControl("lblBatchGV"), Label).Text
        StdId = CType(GElEigiblity.Rows(e.RowIndex).Cells(1).FindControl("STD_ID"), HiddenField).Value
        'BatchId = CType(GElEigiblity.Rows(e.RowIndex).Cells(1).FindControl("HidBatchId"), HiddenField).Value
        sem = ddlSem1.SelectedValue
        sem1 = ddlSem2.SelectedValue
        assesment = ddlassesment.SelectedValue
        Dim qrystring As String = "frmEligibiltyStudentDrillDown.aspx?" & QueryStr.Querystring() & "&StdId=" & StdId & "&BatchId=" & BatchId & "&sem=" & sem & "&sem1=" & sem1 & "&assesment=" & assesment
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GElEigiblity_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GElEigiblity.Sorting

        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.SBatchid = DdlBatchPlanner.SelectedValue
        EL.Semid = ddlSem1.SelectedValue
        EL.Semid2 = ddlSem2.SelectedValue
        If ddlSem1.SelectedValue = 0 And ddlSem2.SelectedValue = 0 Then
            msginfo.Text = "Please Select Semester."
            lblmsg.Text = ""
            GElEigiblity.Visible = False
            Exit Sub
        End If
        'Splitter(cmbSemester.SelectedValue)
        EL.Assisment = ddlassesment.SelectedValue
        EL.NoofSubject = cmbSFailed.SelectedValue
        dt = BL.GetResult(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GElEigiblity.DataSource = sortedView
        GElEigiblity.DataBind()

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
        Page.Response.AddHeader("content-disposition", "attachment;filename=PromotionEligibility.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        GElEigiblity.Parent.Controls.Add(frm)
        frm.Controls.Add(GElEigiblity)
        frm.RenderControl(hw)
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim batch As Integer = DdlBatchPlanner.SelectedValue
        Dim sem1 As Integer = ddlSem1.SelectedValue
        Dim sem2 As Integer = ddlSem2.SelectedValue
        If ddlSem1.SelectedValue = 0 And ddlSem2.SelectedValue = 0 Then
            msginfo.Text = "Please Select Semester."
            lblmsg.Text = ""
            'GElEigiblity.Visible = False
            Exit Sub
        End If
        'Splitter(cmbSemester.SelectedValue)
        Dim Assisment As Integer = ddlassesment.SelectedValue
        Dim NoofSubject As Integer = cmbSFailed.SelectedValue
        Dim semname1 As String = ddlSem1.SelectedItem.ToString
        Dim semname2 As String = ddlSem2.SelectedItem.ToString
        Dim qrystring As String = "RptPromotionEligibilityV.aspx?" & QueryStr.Querystring() & "&batch=" & batch & "&sem1=" & sem1 & "&sem2=" & sem2 & "&Assisment=" & Assisment & "&NoofSubject=" & NoofSubject & "&semname1=" & semname1 & "&semname2=" & semname2
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub
End Class
