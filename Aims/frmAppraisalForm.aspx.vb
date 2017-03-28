Imports System.Data.SqlClient
Partial Class frmAppraisalForm
    Inherits BasePage
    Dim Dt, Dt1, Dt2, dt3, dt4, dt5 As New DataTable
    Dim ApprasialId, Max, Min, AutoId As Integer
    Dim Emp As String
    Dim DL As New DLAppraisalform
    Dim EL As New ELAppraisalform
    Dim i As Integer


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("LoginType") <> "Others" Then
                Dt1 = DLAppraisalform.GetApprasialCycle
                If (Dt1.Rows.Count = 0) Then
                    msginfo.Text = "No Appraisal has found."
                    Exit Sub
                   Else
                    ApprasialId = Dt1.Rows(0).Item("ACID")
                    ViewState("ACID") = ApprasialId
                    Dt = DLAppraisalform.EmployeeCode(ddlAppraisaltype.SelectedValue)
                    ddlempcode.DataSource = Dt
                    ddlempcode.DataBind()
                    If Dt.Rows.Count > 0 Then
                        If ddlAppraisaltype.SelectedValue = 1 Then
                            For Each row In GVApprisal.Rows
                                Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                                Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                                self.Enabled = False
                                Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                                manager.Enabled = False
                                Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                                reviwer.Enabled = False
                                Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                                finalscore.Enabled = False
                            Next

                        ElseIf ddlAppraisaltype.SelectedValue = 2 Then
                            For Each row In GVApprisal.Rows
                                Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                                Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                                self.Enabled = False
                                Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                                manager.Enabled = True
                                Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                                reviwer.Enabled = False
                                Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                                finalscore.Enabled = False
                            Next
                        ElseIf ddlAppraisaltype.SelectedValue = 3 Then
                            For Each row In GVApprisal.Rows
                                Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                                Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                                self.Enabled = False
                                Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                                manager.Enabled = False
                                Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                                reviwer.Enabled = True
                                Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                                finalscore.Enabled = False
                            Next


                        End If

                    End If
                End If
            End If
        End If
     
    End Sub
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
    Protected Sub ddlAppraisaltype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAppraisaltype.SelectedIndexChanged
        '    'If Not IsPostBack Then
        msginfo.Text = ValidationMessage(1014)
        lblMsg.Text = ValidationMessage(1014)

        Dt = DLAppraisalform.EmployeeCode(ddlAppraisaltype.SelectedValue)

        ddlempcode.DataSource = Dt
        ddlempcode.DataBind()
        GVApprisal.Visible = False
        '    If Dt.Rows.Count > 0 Then
        '        If ddlAppraisaltype.SelectedValue = 1 Then
        '            For Each row In GVApprisal.Rows
        '                Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
        '                Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
        '                self.Enabled = True
        '                Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
        '                manager.Enabled = False
        '                Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
        '                reviwer.Enabled = False
        '                Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
        '                finalscore.Enabled = False
        '            Next

        '        ElseIf ddlAppraisaltype.SelectedValue = 2 Then

        '            For Each row In GVApprisal.Rows
        '                Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
        '                Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
        '                self.Enabled = False
        '                Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
        '                manager.Enabled = True
        '                Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
        '                reviwer.Enabled = False
        '                Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
        '                finalscore.Enabled = False
        '            Next
        '        ElseIf ddlAppraisaltype.SelectedValue = 3 Then
        '            For Each row In GVApprisal.Rows
        '                Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
        '                Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
        '                self.Enabled = False
        '                Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
        '                manager.Enabled = False
        '                Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
        '                reviwer.Enabled = True
        '                Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
        '                finalscore.Enabled = True
        '            Next

        '        End If
        '        'Else
        '        '    GVApprisal.Visible = False
        '    End If
    End Sub

    'Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
    '    Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))

    '    If (Dt.Rows.Count > 0) Then
    '        If (Dt.Rows(0).Item("Emp_ID") IsNot DBNull.Value) Then
    '            '    GVApprisal.DataSource = Dt
    '            '    GVApprisal.DataBind()
    '            '    GVApprisal.Visible = False
    '            'Else
    '            Dim i As Integer = 0
    '            GVApprisal.DataSource = Dt
    '            GVApprisal.DataBind()
    '            'For Each dtrow In Dt.Rows
    '            For Each row In GVApprisal.Rows
    '                'Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
    '                Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
    '                self.Enabled = False
    '                Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
    '                manager.Enabled = False
    '                Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
    '                reviwer.Enabled = False
    '                Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
    '                finalscore.Enabled = False
    '                If (Dt.Rows(i).Item(6) Is DBNull.Value) Then
    '                    self.Text = ""
    '                Else
    '                    self.Text = Dt.Rows(i).Item(6)
    '                End If
    '                If (Dt.Rows(i).Item(7) Is DBNull.Value) Then
    '                    manager.Text = ""
    '                Else
    '                    manager.Text = Dt.Rows(i).Item(7)
    '                End If
    '                If (Dt.Rows(i).Item(8) Is DBNull.Value) Then
    '                    reviwer.Text = ""
    '                Else
    '                    reviwer.Text = Dt.Rows(i).Item(8)
    '                End If

    '                If (Dt.Rows(i).Item(9) Is DBNull.Value) Then
    '                    finalscore.Text = ""
    '                Else
    '                    finalscore.Text = Dt.Rows(i).Item(9)
    '                End If

    '                i = i + 1
    '            Next
    '            'Next

    '        Else

    '            Dim i As Integer = 1
    '            GVApprisal.DataSource = Dt
    '            GVApprisal.DataBind()
    '            'For Each dtrow In Dt.Rows
    '            For Each row In GVApprisal.Rows
    '                Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))

    '                Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)

    '                Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)

    '                Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)

    '                Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
    '                i = i + 1
    '            Next
    '        End If
    '    End If
    '    'If Dt.Rows.Count = 0 Then
    '    '    msginfo.Text = ValidationMessage(1023)
    '    '    lblMsg.Text = ValidationMessage(1014)
    '    '    GVApprisal.Visible = False
    '    'Else
    '    '    msginfo.Text = ValidationMessage(1014)
    '    '    lblMsg.Text = ValidationMessage(1014)
    '    '    GVApprisal.Visible = True
    '    '    GVApprisal.DataSource = Dt
    '    '    GVApprisal.DataBind()
    '    '    'Multilingual()
    '    'End If
    'End Sub

    Protected Sub btnsub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsub.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            msginfo.Text = ValidationMessage(1014)
            lblMsg.Text = ValidationMessage(1014)
            Try
                EL.AppraisalType = ddlAppraisaltype.SelectedValue
                EL.Empid = ddlempcode.SelectedValue
                ApprasialId = CInt(ViewState("ACID"))
                If ApprasialId = 0 Then
                    msginfo.Text = "No Appraisal has found."
                    Exit Sub
                End If
                i = 0

                Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))

                If ddlempcode.SelectedValue = 0 Then
                    For Each row In GVApprisal.Rows
                        Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                        self.Enabled = False
                        Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                        manager.Enabled = False
                        Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                        reviwer.Enabled = False
                        Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                        finalscore.Enabled = False
                    Next
                    msginfo.Text = "You Can't Submit the Data."
                    Exit Sub
                Else
                    If ddlAppraisaltype.SelectedValue = 1 Then
                        For Each row In GVApprisal.Rows
                            If CType(row.FindControl("txtSelf"), TextBox).Text = "" Then
                                msginfo.Text = "Please Fill All the Details."
                                Exit Sub
                                   End If
                            Max = Dt.Rows(i).Item("Max")
                            Min = Dt.Rows(i).Item("Min")

                            Dim a As Int16 = CType(row.FindControl("txtSelf"), TextBox).Text
                            If (a > Max) Or (a < Min) Then
                                msginfo.Text = "Data Should be less than or Equal Max Value."
                                Exit Sub
                            End If
                            If (a < Max) And (a < Min) Then
                                msginfo.Text = "Data Should be less than or Equal Max Value."
                                Exit Sub

                            End If

                            i = i + 1
                        Next
                        For Each row In GVApprisal.Rows
                            EL.id = CInt(ViewState("id"))
                            EL.APID = CInt(ViewState("ACID"))
                            EL.P_Id = CType(row.FindControl("lblpno"), Label).Text
                            If CType(row.FindControl("txtSelf"), TextBox).Text Is DBNull.Value Then
                                EL.S_score = ""
                            Else
                                EL.S_score = CType(row.FindControl("txtSelf"), TextBox).Text

                            End If

                            'EL.M_score = CType(row.FindControl("txtManager"), TextBox).Text
                            'EL.R_score = CType(row.FindControl("txtReviwer"), TextBox).Text
                            'EL.F_score = CType(row.FindControl("txtfinalscore"), TextBox).Text 
                            DL.InsertAprrisalScore(EL)
                            lblMsg.Text = ValidationMessage(1020)
                            msginfo.Text = ValidationMessage(1014)
                        Next

                    ElseIf ddlAppraisaltype.SelectedValue = 2 Then
                        EL.id = CInt(ViewState("id"))
                        For Each row In GVApprisal.Rows
                            If CType(row.FindControl("txtManager"), TextBox).Text = "" Then
                                msginfo.Text = "Please Fill All the Details."
                                Exit Sub

                            End If
                            Max = Dt.Rows(i).Item("Max")
                            Min = Dt.Rows(i).Item("Min")


                            Dim a As Integer = CType(row.FindControl("txtManager"), TextBox).Text
                            If (a > Max) Or (a < Min) Then
                                msginfo.Text = "Data Should be less than or Equal Max Value."
                                Exit Sub
                            End If
                            If (a < Max) And (a < Min) Then
                                msginfo.Text = "Data Should be less than or Equal Max Value."
                                Exit Sub

                            End If

                            i = i + 1
                        Next
                        'DL.UpdateAprrisalScore(EL)
                        For Each row In GVApprisal.Rows
                            EL.id = CInt(ViewState("id"))
                            EL.APID = CInt(ViewState("ACID"))
                            'AutoId = Dt.Rows(0).Item("AS_ID")
                            If Dt.Rows(0).Item("AS_ID") Is DBNull.Value Then
                                msginfo.Text = "Self hasn't Submitted Data ."
                                Exit Sub
                            Else
                                EL.P_Id = CType(row.FindControl("lblpno"), Label).Text
                                If CType(row.FindControl("txtManager"), TextBox).Text Is DBNull.Value Then
                                    EL.M_score = ""
                                Else
                                    EL.M_score = CType(row.FindControl("txtManager"), TextBox).Text
                                End If

                                DL.UpdateAprrisalScore(EL)
                            End If
                            i = i + 1
                        Next
                        lblMsg.Text = ValidationMessage(1017)
                        msginfo.Text = ValidationMessage(1014)

                    ElseIf ddlAppraisaltype.SelectedValue = 3 Then
                        EL.id = CInt(ViewState("id"))
                        For Each row In GVApprisal.Rows
                            If CType(row.FindControl("txtReviwer"), TextBox).Text = "" Then
                                msginfo.Text = "Please Fill All the Details."
                                Exit Sub

                            End If
                            Max = Dt.Rows(i).Item("Max")
                            Min = Dt.Rows(i).Item("Min")

                            Dim a As Integer = CType(row.FindControl("txtReviwer"), TextBox).Text
                            If (a > Max) Or (a < Min) Then
                                msginfo.Text = "Data Should be less than or Equal Max Value."
                                Exit Sub
                            End If
                            If (a < Max) And (a < Min) Then
                                msginfo.Text = "Data Should be less than or Equal Max Value."
                                Exit Sub

                            End If

                            i = i + 1
                        Next
                        i = 0
                        For Each row In GVApprisal.Rows

                            EL.APID = CInt(ViewState("ACID"))
                            'AutoId = Dt.Rows(0).Item("AS_ID")
                            If Dt.Rows(0).Item("AS_ID") Is DBNull.Value Then
                                msginfo.Text = "Self hasn't Submitted Data ."
                                Exit Sub
                            Else
                                EL.P_Id = CType(row.FindControl("lblpno"), Label).Text
                                'EL.S_score = CType(row.FindControl("txtSelf"), TextBox).Text
                                'EL.M_score = CType(row.FindControl("txtManager"), TextBox).Text
                                If CType(row.FindControl("txtReviwer"), TextBox).Text Is DBNull.Value Then
                                    EL.R_score = ""
                                Else
                                    EL.R_score = CType(row.FindControl("txtReviwer"), TextBox).Text
                                End If

                                Dt2 = DLAppraisalform.FinalScore()
                                EL.F_score = EL.R_score + Dt2.Rows(i).Item(0) + Dt2.Rows(i).Item(1)
                                CType(row.FindControl("txtfinalscore"), TextBox).Text = EL.F_score
                                DL.UpdateAprrisalScore1(EL)
                                lblMsg.Text = ValidationMessage(1020)
                                msginfo.Text = ValidationMessage(1014)
                            End If
                            i = i + 1
                        Next
                        lblMsg.Text = ValidationMessage(1017)
                        msginfo.Text = ValidationMessage(1014)



                    End If
                End If
            Catch e1 As Exception
                lblMsg.Text = ValidationMessage(1022)
                msginfo.Text = ValidationMessage(1014)
            End Try
        Else
            lblMsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If
        'Else
        'lblerrmsg.Text = "You don't have Write Privilages. "

    End Sub

    Protected Sub ddlempcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlempcode.SelectedIndexChanged
        msginfo.Text = ValidationMessage(1014)
        lblMsg.Text = ValidationMessage(1014)
       
        Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
        If ViewState("ACID") Is Nothing Or 0 Then
            msginfo.Text = "No Appraisal has found."
            Exit Sub

        End If
        Dim i As Integer = 0
        If (Dt.Rows.Count > 0) Then
            If (Dt.Rows(0).Item("Emp_ID") IsNot DBNull.Value) Then
                '    GVApprisal.DataSource = Dt
                '    GVApprisal.DataBind()
                '    GVApprisal.Visible = False
                'Else

                GVApprisal.DataSource = Dt
                GVApprisal.DataBind()
                GVApprisal.Visible = True
                'For Each dtrow In Dt.Rows
                If ddlAppraisaltype.SelectedValue = 1 Then
                    For Each row In GVApprisal.Rows

                        'Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                        Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                        'self.Enabled = False
                        Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                        manager.Enabled = False
                        Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                        reviwer.Enabled = False
                        Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                        finalscore.Enabled = False
                        If (Dt.Rows(i).Item(6) Is DBNull.Value) Then
                            self.Text = ""
                        Else
                            self.Text = Dt.Rows(i).Item(6)
                            self.Enabled = False
                        End If
                        If (Dt.Rows(i).Item(7) Is DBNull.Value) Then
                            manager.Text = ""
                        Else
                            manager.Text = Dt.Rows(i).Item(7)
                            manager.Enabled = False
                        End If
                        If (Dt.Rows(i).Item(8) Is DBNull.Value) Then
                            reviwer.Text = ""
                        Else
                            reviwer.Text = Dt.Rows(i).Item(8)
                            reviwer.Enabled = False
                        End If

                        If (Dt.Rows(i).Item(9) Is DBNull.Value) Then
                            finalscore.Text = ""
                        Else
                            finalscore.Text = Dt.Rows(i).Item(9)
                            finalscore.Enabled = False
                        End If

                        i = i + 1
                    Next
                ElseIf ddlAppraisaltype.SelectedValue = 2 Then
                    For Each row In GVApprisal.Rows

                        'Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                        Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                        self.Enabled = False
                        Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                        'manager.Enabled = False
                        Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                        reviwer.Enabled = False
                        Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                        finalscore.Enabled = False
                        If (Dt.Rows(i).Item(6) Is DBNull.Value) Then
                            self.Text = ""
                        Else
                            self.Text = Dt.Rows(i).Item(6)
                            self.Enabled = False
                        End If
                        If (Dt.Rows(i).Item(7) Is DBNull.Value) Then
                            manager.Text = ""
                        Else
                            manager.Text = Dt.Rows(i).Item(7)
                            manager.Enabled = False

                        End If
                        If (Dt.Rows(i).Item(8) Is DBNull.Value) Then
                            reviwer.Text = ""
                        Else
                            reviwer.Text = Dt.Rows(i).Item(8)
                            reviwer.Enabled = False
                        End If

                        If (Dt.Rows(i).Item(9) Is DBNull.Value) Then
                            finalscore.Text = ""
                        Else
                            finalscore.Text = Dt.Rows(i).Item(9)
                            finalscore.Enabled = False
                        End If

                        i = i + 1
                    Next
                ElseIf ddlAppraisaltype.SelectedValue = 3 Then
                    For Each row In GVApprisal.Rows

                        'Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                        Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                        self.Enabled = False
                        Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                        manager.Enabled = False
                        Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                        'reviwer.Enabled = False
                        Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                        finalscore.Enabled = False
                        If (Dt.Rows(i).Item(6) Is DBNull.Value) Then
                            self.Text = ""
                        Else
                            self.Text = Dt.Rows(i).Item(6)
                            self.Enabled = False
                        End If
                        If (Dt.Rows(i).Item(7) Is DBNull.Value) Then
                            manager.Text = ""
                        Else
                            manager.Text = Dt.Rows(i).Item(7)
                            manager.Enabled = False
                        End If
                        If (Dt.Rows(i).Item(8) Is DBNull.Value) Then
                            reviwer.Text = ""
                        Else
                            reviwer.Text = Dt.Rows(i).Item(8)
                            reviwer.Enabled = False
                        End If

                        If (Dt.Rows(i).Item(9) Is DBNull.Value) Then
                            finalscore.Text = ""
                        Else
                            finalscore.Text = Dt.Rows(i).Item(9)
                            finalscore.Enabled = False

                        End If

                        i = i + 1
                    Next
                    'Next
                End If

            Else

                'Dim i As Integer = 1
                GVApprisal.DataSource = Dt
                GVApprisal.DataBind()
                GVApprisal.Visible = True
                'For Each dtrow In Dt.Rows
                'For Each row In GVApprisal.Rows
                '    Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))

                '    Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)

                '    Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)

                '    Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)

                '    Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                '    i = i + 1
                'Next

                If ddlAppraisaltype.SelectedValue = 1 Then
                    For Each row In GVApprisal.Rows
                        Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                        Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                        self.Enabled = True
                        Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                        manager.Enabled = False
                        Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                        reviwer.Enabled = False
                        Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                        finalscore.Enabled = False
                    Next

                ElseIf ddlAppraisaltype.SelectedValue = 2 Then

                    For Each row In GVApprisal.Rows
                        Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                        Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                        self.Enabled = False
                        Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                        manager.Enabled = True
                        Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                        reviwer.Enabled = False
                        Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                        finalscore.Enabled = False
                    Next
                ElseIf ddlAppraisaltype.SelectedValue = 3 Then
                    For Each row In GVApprisal.Rows
                        Dt = DLAppraisalform.ViewParameters(ddlempcode.SelectedValue, CInt(ViewState("ACID")))
                        Dim self As TextBox = CType(row.FindControl("txtSelf"), TextBox)
                        self.Enabled = False
                        Dim manager As TextBox = CType(row.FindControl("txtManager"), TextBox)
                        manager.Enabled = False
                        Dim reviwer As TextBox = CType(row.FindControl("txtReviwer"), TextBox)
                        reviwer.Enabled = True
                        Dim finalscore As TextBox = CType(row.FindControl("txtfinalscore"), TextBox)
                        finalscore.Enabled = False
                    Next

                End If
                If ((ddlAppraisaltype.SelectedValue = 2) Or (ddlAppraisaltype.SelectedValue = 3)) Then
                    For Each row In GVApprisal.Rows
                        If CType(row.FindControl("txtSelf"), TextBox).Text = "" Then

                            msginfo.Text = ddlempcode.SelectedItem.ToString + " has not Filled Apprasial Data."
                            GVApprisal.Visible = False
                            Exit Sub
                        End If

                    Next
                End If
            End If
        End If
        'If Dt.Rows.Count = 0 Then
        '    msginfo.Text = ValidationMessage(1023)
        '    lblMsg.Text = ValidationMessage(1014)
        '    GVApprisal.Visible = False
        'Else
        '    msginfo.Text = ValidationMessage(1014)
        '    lblMsg.Text = ValidationMessage(1014)
        '    GVApprisal.Visible = True
        '    GVApprisal.DataSource = Dt
        '    GVApprisal.DataBind()
        '    'Multilingual()
        'End If
    End Sub
End Class
