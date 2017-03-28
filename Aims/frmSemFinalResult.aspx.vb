Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient
Partial Class frmSemFinalResult
    Inherits BasePage
    Dim DL As New DLSemFinalResult
    Dim EL As New ELSemFinalResult

    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        Gridsubject.Visible = False
        GridView1.Visible = False
        btnCalc.Visible = False
        GVSemResult.Visible = False
        lblFinalAsessment.Visible = False
        ddlFinalAsessment.Visible = False
        btnUpdate.Visible = False
        msginfo.Text = ""
        lblmsg.Text = ""
        Dim dt As New DataTable
        dt = DLSemFinalResult.GetAssesmentCombo(cmbSemester.SelectedValue)
        GVSemResult.DataSource = dt
        GVSemResult.DataBind()
        GVSemResult.Visible = True
        lblFinalAsessment.Visible = False
        ddlFinalAsessment.Visible = False

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim Str As String = ""
            Dim ID As String = ""
            btnCalc.Enabled = True
            For Each grid As GridViewRow In GVSemResult.Rows
                If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                    Str = CType(grid.FindControl("Label1"), HiddenField).Value
                    ID = Str + "," + ID

                End If
            Next

            If ID = "" Then
                msginfo.Text = "Select atleast one Record."
                lblmsg.Text = ""
            Else
                ID = Left(ID, ID.Length - 1)
                lblmsg.Text = ""
                msginfo.Text = ""
                lblFinalAsessment.Visible = True
                ddlFinalAsessment.Visible = True
                Dim dt1 As DataTable
                dt1 = DLSemFinalResult.GetAssesmentId(ID)
                ddlFinalAsessment.DataSource = dt1
                ddlFinalAsessment.DataBind()
                lblFinalAsessment.Visible = True
                ddlFinalAsessment.Visible = True
                btnCalc.Visible = True
                Dim dt3 As New DataTable
                EL.Batch = cmbBatch.SelectedValue
                EL.Semester = cmbSemester.SelectedValue
                EL.AssesmentTypeID = ID
                GridView1.Dispose()
                dt3.Dispose()
                dt3 = DLSemFinalResult.GetData(EL)
                GridView1.DataSource = dt3
                GridView1.DataBind()
                GridView1.Visible = True

                Gridsubject.Visible = True
                GridView1.Visible = True
                btnCalc.Visible = True
                GVSemResult.Visible = True
                lblFinalAsessment.Visible = True
                ddlFinalAsessment.Visible = True
                btnUpdate.Visible = True

                Gridsubject.DataSourceID = "ObjSubject"
                Gridsubject.DataBind()
                Gridsubject.Rows(0).Visible = False
                Gridsubject.Visible = True

                GridView1.Columns(2).HeaderText = ""
                GridView1.Columns(3).HeaderText = ""
                GridView1.Columns(4).HeaderText = ""
                GridView1.Columns(5).HeaderText = ""
                GridView1.Columns(6).HeaderText = ""
                GridView1.Columns(7).HeaderText = ""
                GridView1.Columns(8).HeaderText = ""
                GridView1.Columns(9).HeaderText = ""
                GridView1.Columns(10).HeaderText = ""
                GridView1.Columns(11).HeaderText = ""
                GridView1.Columns(12).HeaderText = ""
                GridView1.Columns(13).HeaderText = ""
                GridView1.Columns(14).HeaderText = ""
                GridView1.Columns(15).HeaderText = ""
                GridView1.Columns(16).HeaderText = ""
                GridView1.Columns(17).HeaderText = ""
                GridView1.Columns(18).HeaderText = ""
                GridView1.Columns(19).HeaderText = ""
                GridView1.Columns(20).HeaderText = ""
                GridView1.Columns(21).HeaderText = ""
                GridView1.Columns(22).HeaderText = ""
                GridView1.Columns(23).HeaderText = ""
                GridView1.Columns(24).HeaderText = ""
                GridView1.Columns(25).HeaderText = ""
                GridView1.Columns(26).HeaderText = ""
                GridView1.Columns(27).HeaderText = ""
                GridView1.Columns(28).HeaderText = ""
                GridView1.Columns(29).HeaderText = ""
                GridView1.Columns(30).HeaderText = ""
                GridView1.Columns(31).HeaderText = ""
                GridView1.Columns(32).HeaderText = ""
                GridView1.Columns(33).HeaderText = ""
                GridView1.Columns(34).HeaderText = ""
                GridView1.Columns(35).HeaderText = ""
                GridView1.Columns(36).HeaderText = ""
                GridView1.Columns(37).HeaderText = ""

                If dt3.Rows(0).Item("A1").ToString = "" Then
                    GridView1.Columns(2).Visible = False
                Else
                    GridView1.Columns(2).HeaderText = dt3.Rows(0).Item("A1").ToString
                    GridView1.Columns(2).Visible = True
                End If


                If dt3.Rows(0).Item("A2").ToString = "" Then
                    GridView1.Columns(3).Visible = False
                Else
                    GridView1.Columns(3).HeaderText = dt3.Rows(0).Item("A2").ToString
                    GridView1.Columns(3).Visible = True
                End If

                If dt3.Rows(0).Item("A3").ToString = "" Then
                    GridView1.Columns(4).Visible = False
                Else
                    GridView1.Columns(4).HeaderText = dt3.Rows(0).Item("A3").ToString
                    GridView1.Columns(4).Visible = True
                End If
                If dt3.Rows(0).Item("A4").ToString = "" Then
                    GridView1.Columns(5).Visible = False
                Else
                    GridView1.Columns(5).HeaderText = dt3.Rows(0).Item("A4").ToString
                    GridView1.Columns(5).Visible = True
                End If
                If dt3.Rows(0).Item("A5").ToString = "" Then
                    GridView1.Columns(6).Visible = False
                Else
                    GridView1.Columns(6).HeaderText = dt3.Rows(0).Item("A5").ToString
                    GridView1.Columns(6).Visible = True
                End If
                If dt3.Rows(0).Item("A6").ToString = "" Then
                    GridView1.Columns(7).Visible = False
                Else
                    GridView1.Columns(7).HeaderText = dt3.Rows(0).Item("A6").ToString
                    GridView1.Columns(7).Visible = True
                End If
                If dt3.Rows(0).Item("A7").ToString = "" Then
                    GridView1.Columns(8).Visible = False
                Else
                    GridView1.Columns(8).HeaderText = dt3.Rows(0).Item("A7").ToString
                    GridView1.Columns(8).Visible = True
                End If
                If dt3.Rows(0).Item("A8").ToString = "" Then
                    GridView1.Columns(9).Visible = False
                Else
                    GridView1.Columns(9).HeaderText = dt3.Rows(0).Item("A8").ToString
                    GridView1.Columns(9).Visible = True
                End If
                If dt3.Rows(0).Item("A9").ToString = "" Then
                    GridView1.Columns(10).Visible = False
                Else
                    GridView1.Columns(10).HeaderText = dt3.Rows(0).Item("A9").ToString
                    GridView1.Columns(10).Visible = True
                End If
                If dt3.Rows(0).Item("A10").ToString = "" Then
                    GridView1.Columns(11).Visible = False
                Else
                    GridView1.Columns(11).HeaderText = dt3.Rows(0).Item("A10").ToString
                    GridView1.Columns(11).Visible = True
                End If
                If dt3.Rows(0).Item("A11").ToString = "" Then
                    GridView1.Columns(12).Visible = False
                Else
                    GridView1.Columns(12).HeaderText = dt3.Rows(0).Item("A11").ToString
                    GridView1.Columns(12).Visible = True
                End If
                If dt3.Rows(0).Item("A12").ToString = "" Then
                    GridView1.Columns(13).Visible = False
                Else
                    GridView1.Columns(13).HeaderText = dt3.Rows(0).Item("A12").ToString
                    GridView1.Columns(13).Visible = True
                End If
                If dt3.Rows(0).Item("A13").ToString = "" Then
                    GridView1.Columns(14).Visible = False
                Else
                    GridView1.Columns(14).HeaderText = dt3.Rows(0).Item("A13").ToString
                    GridView1.Columns(14).Visible = True
                End If
                If dt3.Rows(0).Item("A14").ToString = "" Then
                    GridView1.Columns(15).Visible = False
                Else
                    GridView1.Columns(15).HeaderText = dt3.Rows(0).Item("A14").ToString
                    GridView1.Columns(15).Visible = True
                End If
                If dt3.Rows(0).Item("A15").ToString = "" Then
                    GridView1.Columns(16).Visible = False
                Else
                    GridView1.Columns(16).HeaderText = dt3.Rows(0).Item("A15").ToString
                    GridView1.Columns(16).Visible = True
                End If
                If dt3.Rows(0).Item("A16").ToString = "" Then
                    GridView1.Columns(17).Visible = False
                Else
                    GridView1.Columns(17).HeaderText = dt3.Rows(0).Item("A16").ToString
                    GridView1.Columns(17).Visible = True
                End If
                If dt3.Rows(0).Item("A17").ToString = "" Then
                    GridView1.Columns(18).Visible = False
                Else
                    GridView1.Columns(18).HeaderText = dt3.Rows(0).Item("A17").ToString
                    GridView1.Columns(18).Visible = True
                End If
                If dt3.Rows(0).Item("A18").ToString = "" Then
                    GridView1.Columns(19).Visible = False
                Else
                    GridView1.Columns(19).HeaderText = dt3.Rows(0).Item("A18").ToString
                    GridView1.Columns(19).Visible = True
                End If
                If dt3.Rows(0).Item("A19").ToString = "" Then
                    GridView1.Columns(20).Visible = False
                Else
                    GridView1.Columns(20).HeaderText = dt3.Rows(0).Item("A19").ToString
                    GridView1.Columns(20).Visible = True
                End If
                If dt3.Rows(0).Item("A20").ToString = "" Then
                    GridView1.Columns(21).Visible = False
                Else
                    GridView1.Columns(21).HeaderText = dt3.Rows(0).Item("A20").ToString
                    GridView1.Columns(21).Visible = True
                End If

                If dt3.Rows(0).Item("A21").ToString = "" Then
                    GridView1.Columns(22).Visible = False
                Else
                    GridView1.Columns(22).HeaderText = dt3.Rows(0).Item("A21").ToString
                    GridView1.Columns(22).Visible = True
                End If
                If dt3.Rows(0).Item("A22").ToString = "" Then
                    GridView1.Columns(23).Visible = False
                Else
                    GridView1.Columns(23).HeaderText = dt3.Rows(0).Item("A22").ToString
                    GridView1.Columns(23).Visible = True
                End If
                If dt3.Rows(0).Item("A23").ToString = "" Then
                    GridView1.Columns(24).Visible = False
                Else
                    GridView1.Columns(24).HeaderText = dt3.Rows(0).Item("A23").ToString
                    GridView1.Columns(24).Visible = True
                End If
                If dt3.Rows(0).Item("A24").ToString = "" Then
                    GridView1.Columns(25).Visible = False
                Else
                    GridView1.Columns(25).HeaderText = dt3.Rows(0).Item("A24").ToString
                    GridView1.Columns(25).Visible = True
                End If
                If dt3.Rows(0).Item("A25").ToString = "" Then
                    GridView1.Columns(26).Visible = False
                Else
                    GridView1.Columns(26).HeaderText = dt3.Rows(0).Item("A25").ToString
                    GridView1.Columns(26).Visible = True
                End If
                If dt3.Rows(0).Item("A26").ToString = "" Then
                    GridView1.Columns(27).Visible = False
                Else
                    GridView1.Columns(27).HeaderText = dt3.Rows(0).Item("A26").ToString
                    GridView1.Columns(27).Visible = True
                End If
                '''''''''''
                If dt3.Rows(0).Item("A27").ToString = "" Then
                    GridView1.Columns(28).Visible = False
                Else
                    GridView1.Columns(28).HeaderText = dt3.Rows(0).Item("A27").ToString
                    GridView1.Columns(28).Visible = True
                End If

                If dt3.Rows(0).Item("A28").ToString = "" Then
                    GridView1.Columns(29).Visible = False
                Else
                    GridView1.Columns(29).HeaderText = dt3.Rows(0).Item("A28").ToString
                    GridView1.Columns(29).Visible = True
                End If
                If dt3.Rows(0).Item("A29").ToString = "" Then
                    GridView1.Columns(30).Visible = False
                Else
                    GridView1.Columns(30).HeaderText = dt3.Rows(0).Item("A29").ToString
                    GridView1.Columns(30).Visible = True
                End If
                If dt3.Rows(0).Item("A30").ToString = "" Then
                    GridView1.Columns(31).Visible = False
                Else
                    GridView1.Columns(31).HeaderText = dt3.Rows(0).Item("A30").ToString
                    GridView1.Columns(31).Visible = True
                End If
                If dt3.Rows(0).Item("A31").ToString = "" Then
                    GridView1.Columns(32).Visible = False
                Else
                    GridView1.Columns(32).HeaderText = dt3.Rows(0).Item("A31").ToString
                    GridView1.Columns(32).Visible = True
                End If
                If dt3.Rows(0).Item("A32").ToString = "" Then
                    GridView1.Columns(33).Visible = False
                Else
                    GridView1.Columns(33).HeaderText = dt3.Rows(0).Item("A32").ToString
                    GridView1.Columns(33).Visible = True
                End If
                If dt3.Rows(0).Item("A33").ToString = "" Then
                    GridView1.Columns(34).Visible = False
                Else
                    GridView1.Columns(34).HeaderText = dt3.Rows(0).Item("A33").ToString
                    GridView1.Columns(34).Visible = True
                End If
                If dt3.Rows(0).Item("A34").ToString = "" Then
                    GridView1.Columns(35).Visible = False
                Else
                    GridView1.Columns(35).HeaderText = dt3.Rows(0).Item("A34").ToString
                    GridView1.Columns(35).Visible = True
                End If
                If dt3.Rows(0).Item("A35").ToString = "" Then
                    GridView1.Columns(36).Visible = False
                Else
                    GridView1.Columns(36).HeaderText = dt3.Rows(0).Item("A35").ToString
                    GridView1.Columns(36).Visible = True
                End If
            End If
            GridView1.DataBind()
        Catch ex As Exception
            msginfo.Text = " Select Maximum of 4 Assessment Types."
            lblmsg.Text = ""
            btnCalc.Enabled = False
        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            lblFinalAsessment.Visible = False
            ddlFinalAsessment.Visible = False
            btnCalc.Visible = False
            btnUpdate.Visible = False

        End If

    End Sub

    'Protected Sub cmbAcademic_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.TextChanged
    '    Gridsubject.Visible = False
    '    GridView1.Visible = False
    '    btnCalc.Visible = False
    '    GVSemResult.Visible = False
    '    lblFinalAsessment.Visible = False
    '    ddlFinalAsessment.Visible = False
    '    btnUpdate.Visible = False
    '    msginfo.Text = ""
    '    lblmsg.Text = ""
    '    cmbAcademic.Focus()
    'End Sub

    Protected Sub cmbBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.TextChanged
        Gridsubject.Visible = False
        GridView1.Visible = False
        btnCalc.Visible = False
        GVSemResult.Visible = False
        lblFinalAsessment.Visible = False
        ddlFinalAsessment.Visible = False
        btnUpdate.Visible = False
        msginfo.Text = ""
        lblmsg.Text = ""
        cmbBatch.Focus()
    End Sub

    Protected Sub btnCalc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalc.Click
        Try
            btnUpdate.Visible = True
            Dim Str, subjectlist As String
            Str = ""
            subjectlist = ""
            Dim ID As String = ""
            For Each grid As GridViewRow In GVSemResult.Rows
                If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                    Str = CType(grid.FindControl("Label1"), HiddenField).Value
                    ID = Str + "," + ID

                End If
            Next
            For Each grid As GridViewRow In Gridsubject.Rows
                If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                    subjectlist = CType(grid.FindControl("AssessType"), Label).Text + "," + subjectlist
                End If
            Next
            If subjectlist = "" Then
                msginfo.Text = "Select Excluding subject."
                lblmsg.Text = ""
                Exit Sub
            Else
                subjectlist = Left(subjectlist, subjectlist.Length - 1)
            End If
            If ID = "" Then
                msginfo.Text = "Select Assessment Type."
                lblmsg.Text = ""
            Else
                ID = Left(ID, ID.Length - 1)
                lblmsg.Text = ""
                msginfo.Text = ""
                lblFinalAsessment.Visible = True
                ddlFinalAsessment.Visible = True
                lblFinalAsessment.Visible = True
                ddlFinalAsessment.Visible = True
                btnCalc.Visible = True
                Dim dt3 As New DataTable
                EL.Batch = cmbBatch.SelectedValue
                EL.Semester = cmbSemester.SelectedValue
                EL.AssesmentTypeID = ID
                GridView1.Dispose()
                dt3.Dispose()
                dt3 = DLSemFinalResult.GetData(EL)
                GridView1.DataSource = dt3
                GridView1.DataBind()
                GridView1.Visible = True
                GridView1.Columns(2).HeaderText = ""
                GridView1.Columns(3).HeaderText = ""
                GridView1.Columns(4).HeaderText = ""
                GridView1.Columns(5).HeaderText = ""
                GridView1.Columns(6).HeaderText = ""
                GridView1.Columns(7).HeaderText = ""
                GridView1.Columns(8).HeaderText = ""
                GridView1.Columns(9).HeaderText = ""
                GridView1.Columns(10).HeaderText = ""
                GridView1.Columns(11).HeaderText = ""
                GridView1.Columns(12).HeaderText = ""
                GridView1.Columns(13).HeaderText = ""
                GridView1.Columns(14).HeaderText = ""
                GridView1.Columns(15).HeaderText = ""
                GridView1.Columns(16).HeaderText = ""
                GridView1.Columns(17).HeaderText = ""
                GridView1.Columns(18).HeaderText = ""
                GridView1.Columns(19).HeaderText = ""
                GridView1.Columns(20).HeaderText = ""
                GridView1.Columns(21).HeaderText = ""
                GridView1.Columns(22).HeaderText = ""
                GridView1.Columns(23).HeaderText = ""
                GridView1.Columns(24).HeaderText = ""
                GridView1.Columns(25).HeaderText = ""
                GridView1.Columns(26).HeaderText = ""
                GridView1.Columns(27).HeaderText = ""
                GridView1.Columns(28).HeaderText = ""
                GridView1.Columns(29).HeaderText = ""
                GridView1.Columns(30).HeaderText = ""
                GridView1.Columns(31).HeaderText = ""
                GridView1.Columns(32).HeaderText = ""
                GridView1.Columns(33).HeaderText = ""
                GridView1.Columns(34).HeaderText = ""
                GridView1.Columns(35).HeaderText = ""
                GridView1.Columns(36).HeaderText = ""
                GridView1.Columns(37).HeaderText = ""
                GridView1.Columns(2).HeaderText = dt3.Rows(0).Item("A1").ToString
                GridView1.Columns(3).HeaderText = dt3.Rows(0).Item("A2").ToString
                GridView1.Columns(4).HeaderText = dt3.Rows(0).Item("A3").ToString
                GridView1.Columns(5).HeaderText = dt3.Rows(0).Item("A4").ToString
                GridView1.Columns(6).HeaderText = dt3.Rows(0).Item("A5").ToString
                GridView1.Columns(7).HeaderText = dt3.Rows(0).Item("A6").ToString
                GridView1.Columns(8).HeaderText = dt3.Rows(0).Item("A7").ToString
                GridView1.Columns(9).HeaderText = dt3.Rows(0).Item("A8").ToString
                GridView1.Columns(10).HeaderText = dt3.Rows(0).Item("A9").ToString
                GridView1.Columns(11).HeaderText = dt3.Rows(0).Item("A10").ToString
                GridView1.Columns(12).HeaderText = dt3.Rows(0).Item("A11").ToString
                GridView1.Columns(13).HeaderText = dt3.Rows(0).Item("A12").ToString
                GridView1.Columns(14).HeaderText = dt3.Rows(0).Item("A13").ToString
                GridView1.Columns(15).HeaderText = dt3.Rows(0).Item("A14").ToString
                GridView1.Columns(16).HeaderText = dt3.Rows(0).Item("A15").ToString
                GridView1.Columns(17).HeaderText = dt3.Rows(0).Item("A16").ToString
                GridView1.Columns(18).HeaderText = dt3.Rows(0).Item("A17").ToString
                GridView1.Columns(19).HeaderText = dt3.Rows(0).Item("A18").ToString
                GridView1.Columns(20).HeaderText = dt3.Rows(0).Item("A19").ToString
                GridView1.Columns(21).HeaderText = dt3.Rows(0).Item("A20").ToString
                GridView1.Columns(22).HeaderText = dt3.Rows(0).Item("A21").ToString
                GridView1.Columns(23).HeaderText = dt3.Rows(0).Item("A22").ToString
                GridView1.Columns(24).HeaderText = dt3.Rows(0).Item("A23").ToString
                GridView1.Columns(25).HeaderText = dt3.Rows(0).Item("A24").ToString
                GridView1.Columns(26).HeaderText = dt3.Rows(0).Item("A25").ToString
                GridView1.Columns(27).HeaderText = dt3.Rows(0).Item("A26").ToString
                GridView1.Columns(28).HeaderText = dt3.Rows(0).Item("A27").ToString
                GridView1.Columns(29).HeaderText = dt3.Rows(0).Item("A28").ToString
                GridView1.Columns(30).HeaderText = dt3.Rows(0).Item("A29").ToString
                GridView1.Columns(31).HeaderText = dt3.Rows(0).Item("A30").ToString
                GridView1.Columns(32).HeaderText = dt3.Rows(0).Item("A31").ToString
                GridView1.Columns(33).HeaderText = dt3.Rows(0).Item("A32").ToString
                GridView1.Columns(34).HeaderText = dt3.Rows(0).Item("A33").ToString
                GridView1.Columns(35).HeaderText = dt3.Rows(0).Item("A34").ToString
                GridView1.Columns(36).HeaderText = dt3.Rows(0).Item("A35").ToString
                GridView1.Columns(37).HeaderText = dt3.Rows(0).Item("A36").ToString
                GridView1.DataBind()
            End If
            Dim dt4 As New DataTable
            dt4 = DLSemFinalResult.GetGradeData()

            GridView1.Visible = True
            Dim Sum, Max As New Double
            Sum = 0
            Max = 0
            For Each rows As GridViewRow In GridView1.Rows
                Dim Per As Double
                Per = 0
                Max = 0
                Sum = 0
                For i As Integer = 2 To 36

                    Dim header As String() = GridView1.Columns(i).HeaderText.ToString.Split(":")
                    If header(0) <> "" Then
                        Dim subject As String = Trim(header(0)) + ":" + Trim(header(1))

                        Dim column As String = "lblValue" + CStr(i - 1)
                        Dim Maxlbl As String = "lblMax" + CStr(i - 1)
                        Dim Minlbl As String = "lblMin" + CStr(i - 1)
                        If GridView1.Columns(i).HeaderText.Contains(": " + ddlFinalAsessment.SelectedItem.Text) Then
                            If subjectlist.Contains(Trim(subject)) Then
                                Sum = CInt(IIf(CType(rows.FindControl(column), Label).Text = "", 0, CType(rows.FindControl(column), Label).Text)) + Sum

                                Dim K As Double = IIf(CType(rows.FindControl(Maxlbl), Label).Text = "", 0, CType(rows.FindControl(Maxlbl), Label).Text)
                                Max = K + Max
                            End If
                        End If
                        Dim mark As String = CType(rows.FindControl(column), Label).Text
                        Dim Maxmark As String = CType(rows.FindControl(Maxlbl), Label).Text
                        Dim Minmark As String = CType(rows.FindControl(Minlbl), Label).Text

                        If CType(rows.FindControl("lblGrade"), Label).Text <> "Fail" Then
                            If CInt(IIf(CType(rows.FindControl(column), Label).Text = "", 0, CType(rows.FindControl(column), Label).Text)) < CInt(IIf(CType(rows.FindControl(Minlbl), Label).Text = "", 0, CType(rows.FindControl(Minlbl), Label).Text)) Then
                                CType(rows.FindControl("lblGrade"), Label).Text = "Fail"
                            Else
                                CType(rows.FindControl("lblGrade"), Label).Text = ""
                            End If
                        End If
                    End If

                Next
                CType(rows.FindControl("lblTotal"), Label).Text = CStr(Sum) + "/" + CStr(Max)
                Per = (Sum / Max) * 100

                CType(rows.FindControl("lblTotalPer"), Label).Text = Format(Per, "0.00")
                lblmsg.Text = "Result calculated Successfully."
                msginfo.Text = ""

            Next

            For Each rows As GridViewRow In GridView1.Rows
                For GI As Integer = 0 To dt4.Rows.Count - 1
                    If CType(rows.FindControl("lblGrade"), Label).Text <> "Fail" Then
                        If CDbl(IIf(CType(rows.FindControl("lblTotalPer"), Label).Text = "", 0, CType(rows.FindControl("lblTotalPer"), Label).Text) >= dt4.Rows(GI).Item("MinMarks")) And CDbl(IIf(CType(rows.FindControl("lblTotalPer"), Label).Text = "", 0, CType(rows.FindControl("lblTotalPer"), Label).Text) <= dt4.Rows(GI).Item("MaxMarks")) Then
                            CType(rows.FindControl("lblGrade"), Label).Text = dt4.Rows(GI).Item("Grade")
                            Exit For
                        End If
                    End If
                Next
            Next
            GridView1.Visible = True
        Catch ex As Exception
            lblmsg.Text = ""
            msginfo.Text = "Error in calculation."
        End Try
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
        Page.Response.AddHeader("content-disposition", "attachment;filename=SemesterResult.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        GridView1.Parent.Controls.Add(frm)
        frm.Controls.Add(GridView1)
        frm.RenderControl(hw)
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            msginfo.Text = ""
            lblmsg.Text = ""
            Dim EL As New ELBatchSemester
            EL.batchId = cmbBatch.SelectedValue
            EL.Assesmentid = 0
            EL.sem = cmbSemester.SelectedValue
            Dim dt5 As New DataTable
            Dim bl As New BLBatchSemester
            dt5 = bl.DuplicateSemResult(EL)
            If dt5.Rows.Count = 0 Then
                lblmsg.Text = ""
                msginfo.Text = "Generate records in Semester Result table."
            Else
                If dt5.Rows.Count <> 0 And dt5.Rows(0)(0) = "N" Then
                    For Each grid As GridViewRow In GridView1.Rows
                        IIf(CType(grid.FindControl("lblTotal"), Label).Text = "", 0, CType(grid.FindControl("lblTotal"), Label).Text)
                        EL.batchId = IIf(CType(grid.FindControl("BatchCode1"), Label).Text = "", 0, CType(grid.FindControl("BatchCode1"), Label).Text)
                        EL.StdId = IIf(CType(grid.FindControl("StdId1"), Label).Text = "", 0, CType(grid.FindControl("StdId1"), Label).Text)
                        EL.sem = IIf(CType(grid.FindControl("SemId1"), Label).Text = "", 0, CType(grid.FindControl("SemId1"), Label).Text)
                        EL.Assesmentid = 0
                        EL.Result = CType(grid.FindControl("lblGrade"), Label).Text
                        Dim parts As String() = IIf(CType(grid.FindControl("lblTotal"), Label).Text = "", 0, CType(grid.FindControl("lblTotal"), Label).Text).ToString.Split("/")
                        EL.TotalMarks = parts(0)
                        EL.Division = ""
                        EL.Rank = ""
                        bl.UpdateResult(EL)
                    Next
                    lblmsg.Text = "Data Updated Successfully."
                    GridView1.Visible = True
                    msginfo.Text = ""
                Else
                    lblmsg.Text = ""
                    msginfo.Text = "Records are locked in Semester Result Table unlock before update."
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot update data."
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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        btnUpdate.Visible = True
        Dim Str, subjectlist As String
        Str = ""
        subjectlist = ""
        Dim ID As String = ""
        For Each grid As GridViewRow In GVSemResult.Rows
            If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                Str = CType(grid.FindControl("Label1"), HiddenField).Value
                ID = Str + "," + ID

            End If
        Next
        For Each grid As GridViewRow In Gridsubject.Rows
            If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                subjectlist = CType(grid.FindControl("AssessType"), Label).Text + "," + subjectlist
            End If
        Next
        If subjectlist = "" Then
            msginfo.Text = "Select Excluding subject."
            lblmsg.Text = ""
            Exit Sub
        Else
            subjectlist = Left(subjectlist, subjectlist.Length - 1)
        End If
        If ID = "" Then
            msginfo.Text = "Select Assessment Type."
            lblmsg.Text = ""
        Else
            ID = Left(ID, ID.Length - 1)
            lblmsg.Text = ""
            msginfo.Text = ""
            lblFinalAsessment.Visible = True
            ddlFinalAsessment.Visible = True
            lblFinalAsessment.Visible = True
            ddlFinalAsessment.Visible = True
            btnCalc.Visible = True
            Dim dt3, dt As New DataTable
            EL.Batch = cmbBatch.SelectedValue
            EL.Semester = cmbSemester.SelectedValue
            EL.AssesmentTypeID = ID
            dt3 = DLSemFinalResult.GetData(EL)
            GridView1.DataSource = dt3
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Columns(2).HeaderText = ""
            GridView1.Columns(3).HeaderText = ""
            GridView1.Columns(4).HeaderText = ""
            GridView1.Columns(5).HeaderText = ""
            GridView1.Columns(6).HeaderText = ""
            GridView1.Columns(7).HeaderText = ""
            GridView1.Columns(8).HeaderText = ""
            GridView1.Columns(9).HeaderText = ""
            GridView1.Columns(10).HeaderText = ""
            GridView1.Columns(11).HeaderText = ""
            GridView1.Columns(12).HeaderText = ""
            GridView1.Columns(13).HeaderText = ""
            GridView1.Columns(14).HeaderText = ""
            GridView1.Columns(15).HeaderText = ""
            GridView1.Columns(16).HeaderText = ""
            GridView1.Columns(17).HeaderText = ""
            GridView1.Columns(18).HeaderText = ""
            GridView1.Columns(19).HeaderText = ""
            GridView1.Columns(20).HeaderText = ""
            GridView1.Columns(21).HeaderText = ""
            GridView1.Columns(22).HeaderText = ""
            GridView1.Columns(23).HeaderText = ""
            GridView1.Columns(24).HeaderText = ""
            GridView1.Columns(25).HeaderText = ""
            GridView1.Columns(26).HeaderText = ""
            GridView1.Columns(27).HeaderText = ""
            GridView1.Columns(28).HeaderText = ""
            GridView1.Columns(29).HeaderText = ""
            GridView1.Columns(30).HeaderText = ""
            GridView1.Columns(31).HeaderText = ""
            GridView1.Columns(32).HeaderText = ""
            GridView1.Columns(33).HeaderText = ""
            GridView1.Columns(34).HeaderText = ""
            GridView1.Columns(35).HeaderText = ""
            GridView1.Columns(36).HeaderText = ""
            GridView1.Columns(37).HeaderText = ""
            GridView1.Columns(2).HeaderText = dt3.Rows(0).Item("A1").ToString
            GridView1.Columns(3).HeaderText = dt3.Rows(0).Item("A2").ToString
            GridView1.Columns(4).HeaderText = dt3.Rows(0).Item("A3").ToString
            GridView1.Columns(5).HeaderText = dt3.Rows(0).Item("A4").ToString
            GridView1.Columns(6).HeaderText = dt3.Rows(0).Item("A5").ToString
            GridView1.Columns(7).HeaderText = dt3.Rows(0).Item("A6").ToString
            GridView1.Columns(8).HeaderText = dt3.Rows(0).Item("A7").ToString
            GridView1.Columns(9).HeaderText = dt3.Rows(0).Item("A8").ToString
            GridView1.Columns(10).HeaderText = dt3.Rows(0).Item("A9").ToString
            GridView1.Columns(11).HeaderText = dt3.Rows(0).Item("A10").ToString
            GridView1.Columns(12).HeaderText = dt3.Rows(0).Item("A11").ToString
            GridView1.Columns(13).HeaderText = dt3.Rows(0).Item("A12").ToString
            GridView1.Columns(14).HeaderText = dt3.Rows(0).Item("A13").ToString
            GridView1.Columns(15).HeaderText = dt3.Rows(0).Item("A14").ToString
            GridView1.Columns(16).HeaderText = dt3.Rows(0).Item("A15").ToString
            GridView1.Columns(17).HeaderText = dt3.Rows(0).Item("A16").ToString
            GridView1.Columns(18).HeaderText = dt3.Rows(0).Item("A17").ToString
            GridView1.Columns(19).HeaderText = dt3.Rows(0).Item("A18").ToString
            GridView1.Columns(20).HeaderText = dt3.Rows(0).Item("A19").ToString
            GridView1.Columns(21).HeaderText = dt3.Rows(0).Item("A20").ToString
            GridView1.Columns(22).HeaderText = dt3.Rows(0).Item("A21").ToString
            GridView1.Columns(23).HeaderText = dt3.Rows(0).Item("A22").ToString
            GridView1.Columns(24).HeaderText = dt3.Rows(0).Item("A23").ToString
            GridView1.Columns(25).HeaderText = dt3.Rows(0).Item("A24").ToString
            GridView1.Columns(26).HeaderText = dt3.Rows(0).Item("A25").ToString
            GridView1.Columns(27).HeaderText = dt3.Rows(0).Item("A26").ToString
            GridView1.Columns(28).HeaderText = dt3.Rows(0).Item("A27").ToString
            GridView1.Columns(29).HeaderText = dt3.Rows(0).Item("A28").ToString
            GridView1.Columns(30).HeaderText = dt3.Rows(0).Item("A29").ToString
            GridView1.Columns(31).HeaderText = dt3.Rows(0).Item("A30").ToString
            GridView1.Columns(32).HeaderText = dt3.Rows(0).Item("A31").ToString
            GridView1.Columns(33).HeaderText = dt3.Rows(0).Item("A32").ToString
            GridView1.Columns(34).HeaderText = dt3.Rows(0).Item("A33").ToString
            GridView1.Columns(35).HeaderText = dt3.Rows(0).Item("A34").ToString
            GridView1.Columns(36).HeaderText = dt3.Rows(0).Item("A35").ToString
            GridView1.Columns(37).HeaderText = dt3.Rows(0).Item("A36").ToString
            GridView1.DataBind()
            Dim sortedView As New DataView(dt3)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            ViewState("SortExpression") = e.SortExpression
            ViewState("sortingDirection") = sortingDirection
            GridView1.DataSource = sortedView
            GridView1.DataBind()
        End If
        Dim dt4 As New DataTable
        dt4 = DLSemFinalResult.GetGradeData()

        GridView1.Visible = True
        Dim Sum, Max As New Double
        Sum = 0
        Max = 0
        For Each rows As GridViewRow In GridView1.Rows
            Dim Per As Double
            Per = 0
            Max = 0
            Sum = 0
            For i As Integer = 2 To 36

                Dim header As String() = GridView1.Columns(i).HeaderText.ToString.Split(":")
                If header(0) <> "" Then
                    Dim subject As String = Trim(header(0)) + ":" + Trim(header(1))

                    Dim column As String = "lblValue" + CStr(i - 1)
                    Dim Maxlbl As String = "lblMax" + CStr(i - 1)
                    Dim Minlbl As String = "lblMin" + CStr(i - 1)
                    If GridView1.Columns(i).HeaderText.Contains(": " + ddlFinalAsessment.SelectedItem.Text) Then
                        If subjectlist.Contains(Trim(subject)) Then
                            Sum = CInt(IIf(CType(rows.FindControl(column), Label).Text = "", 0, CType(rows.FindControl(column), Label).Text)) + Sum

                            Dim K As Double = IIf(CType(rows.FindControl(Maxlbl), Label).Text = "", 0, CType(rows.FindControl(Maxlbl), Label).Text)
                            Max = K + Max
                        End If
                    End If
                    Dim mark As String = CType(rows.FindControl(column), Label).Text
                    Dim Maxmark As String = CType(rows.FindControl(Maxlbl), Label).Text
                    Dim Minmark As String = CType(rows.FindControl(Minlbl), Label).Text

                    If CType(rows.FindControl("lblGrade"), Label).Text <> "Fail" Then
                        If CInt(IIf(CType(rows.FindControl(column), Label).Text = "", 0, CType(rows.FindControl(column), Label).Text)) < CInt(IIf(CType(rows.FindControl(Minlbl), Label).Text = "", 0, CType(rows.FindControl(Minlbl), Label).Text)) Then
                            CType(rows.FindControl("lblGrade"), Label).Text = "Fail"
                        Else
                            CType(rows.FindControl("lblGrade"), Label).Text = ""
                        End If
                    End If
                End If

            Next
            CType(rows.FindControl("lblTotal"), Label).Text = CStr(Sum) + "/" + CStr(Max)
            Per = (Sum / Max) * 100

            CType(rows.FindControl("lblTotalPer"), Label).Text = Format(Per, "0.00")
            lblmsg.Text = ""
            msginfo.Text = ""

        Next

        For Each rows As GridViewRow In GridView1.Rows
            For GI As Integer = 0 To dt4.Rows.Count - 1
                If CType(rows.FindControl("lblGrade"), Label).Text <> "Fail" Then
                    If CDbl(IIf(CType(rows.FindControl("lblTotalPer"), Label).Text = "", 0, CType(rows.FindControl("lblTotalPer"), Label).Text) >= dt4.Rows(GI).Item("MinMarks")) And CDbl(IIf(CType(rows.FindControl("lblTotalPer"), Label).Text = "", 0, CType(rows.FindControl("lblTotalPer"), Label).Text) <= dt4.Rows(GI).Item("MaxMarks")) Then
                        CType(rows.FindControl("lblGrade"), Label).Text = dt4.Rows(GI).Item("Grade")
                        Exit For
                    End If
                End If
            Next
        Next
        GridView1.Visible = True
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
