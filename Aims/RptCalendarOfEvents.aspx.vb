
Partial Class RptCalendarOfEvents
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtFrmDate.Text = Format(Today(), "dd-MMM-yyyy")
            txtToDate.Text = Format(Today(), "dd-MMM-yyyy")

            'BtnExport.Visible = False

            btnReport1.Visible = False

        End If
    End Sub

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click

        'BtnExport.Visible = True

        btnReport1.Visible = True

        Dim dt, dt1 As New DataTable
        Dim FrmDate, ToDate As Date
        If CDate(txtFrmDate.Text) > CDate(txtToDate.Text) Then
            msginfo.Text = "Fromdate cannot be greater than Todate."
            Exit Sub
        ElseIf txtFrmDate.Text = "" Then
            txtFrmDate.Text = Format(Today, "dd-MMM-yyyy")
        ElseIf txtToDate.Text = "" Then

            txtToDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
        FrmDate = txtFrmDate.Text
        ToDate = txtToDate.Text


        dt = TimeTableDl.ViewCalOfEvents(FrmDate, ToDate)
        If dt.Rows.Count > 0 Then
            GVCal.DataSource = dt
            GVCal.DataBind()
            GVCal.Enabled = True
            GVCal.Visible = True
            For Each Grid As GridViewRow In GVCal.Rows
                If CType(Grid.FindControl("lblMonth"), Label).Text = "1" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Jan"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "2" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Feb"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "3" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Mar"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "4" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Apr"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "5" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "May"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "6" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Jun"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "7" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Jul"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "8" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Aug"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "9" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Sep"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "10" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Oct"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "11" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Nov"
                Else
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Dec"


                End If
            Next

            msginfo.Text = ""
            dt1 = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt1.Rows.Count > 0) Then

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblSun"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblSun"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date1 As String() = CType(Grid.FindControl("lblSun"), Label).Text.Split(New Char() {"/"})

                                    Dim HolidayShortName1 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName1 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName1 = dt1.Rows(i).Item("ShortName")
                                    End If
                                    CType(Grid.FindControl("lblSun"), Label).Text = CType(Grid.FindControl("lblSun"), Label).Text + " " + HolidayShortName1
                                    CType(Grid.FindControl("lblSun"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblSun"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblSun"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblSun"), Label).Text = Date1(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins
                                End If
                            End If
                        Else
                            Dim HolidayShortName2 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName2 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName2 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblSun"), Label).Text <> "" Then
                                Dim Date2 As String() = CType(Grid.FindControl("lblSun"), Label).Text.Split(New Char() {"/"})
                                If CType(Grid.FindControl("lblSun"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblSun"), Label).Text = Date2(1) + " " + HolidayShortName2
                                    CType(Grid.FindControl("lblSun"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblSun"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins
                                End If
                            End If
                        End If


                    Next
ins:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblSun"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblSun"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date3 As String() = CType(Grid.FindControl("lblSun"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblSun"), Label).Text = Date3(1)
                        End If
                    End If

                Next

                '-----------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblMon"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblMon"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date4 As String() = CType(Grid.FindControl("lblMon"), Label).Text.Split(New Char() {"/"})
                                    Dim HolidayShortName3 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName3 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName3 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblMon"), Label).Text = CType(Grid.FindControl("lblMon"), Label).Text + " " + HolidayShortName3
                                    CType(Grid.FindControl("lblMon"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblMon"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblMon"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblMon"), Label).Text = Date4(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins1
                                End If
                            End If
                        Else
                            Dim HolidayShortName4 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName4 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName4 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblMon"), Label).Text <> "" Then
                                Dim Date5 As String() = CType(Grid.FindControl("lblMon"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblMon"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblMon"), Label).Text = Date5(1) + " " + HolidayShortName4
                                    CType(Grid.FindControl("lblMon"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblMon"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins1
                                End If
                            End If
                        End If


                    Next
ins1:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblMon"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblMon"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date6 As String() = CType(Grid.FindControl("lblMon"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblMon"), Label).Text = Date6(1)
                        End If
                    End If

                Next
                '-------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblTue"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblTue"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date7 As String() = CType(Grid.FindControl("lblTue"), Label).Text.Split(New Char() {"/"})
                                    Dim HolidayShortName5 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName5 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName5 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblTue"), Label).Text = CType(Grid.FindControl("lblTue"), Label).Text + " " + HolidayShortName5
                                    CType(Grid.FindControl("lblTue"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblTue"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblTue"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblTue"), Label).Text = Date7(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins2
                                End If
                            End If
                        Else
                            Dim HolidayShortName6 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName6 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName6 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblTue"), Label).Text <> "" Then
                                Dim Date8 As String() = CType(Grid.FindControl("lblTue"), Label).Text.Split(New Char() {"/"})
                                If CType(Grid.FindControl("lblTue"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblTue"), Label).Text = Date8(1) + " " + HolidayShortName6
                                    CType(Grid.FindControl("lblTue"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblTue"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins2
                                End If
                            End If
                        End If


                    Next
ins2:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblTue"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblTue"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date9 As String() = CType(Grid.FindControl("lblTue"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblTue"), Label).Text = Date9(1)
                        End If
                    End If

                Next
                '--------------------------------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblWed"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblWed"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date10 As String() = CType(Grid.FindControl("lblWed"), Label).Text.Split(New Char() {"-"})
                                    Dim HolidayShortName7 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName7 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName7 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblWed"), Label).Text = CType(Grid.FindControl("lblWed"), Label).Text + " " + HolidayShortName7
                                    CType(Grid.FindControl("lblWed"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblWed"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblWed"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblWed"), Label).Text = Date10(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins3
                                End If
                            End If
                        Else
                            Dim HolidayShortName8 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName8 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName8 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblWed"), Label).Text <> "" Then
                                Dim Date11 As String() = CType(Grid.FindControl("lblWed"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblWed"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblWed"), Label).Text = Date11(1) + " " + HolidayShortName8
                                    CType(Grid.FindControl("lblWed"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblWed"), Label).ForeColor = Drawing.Color.White

                                    GoTo ins3
                                End If
                            End If
                        End If


                    Next
ins3:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblWed"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblWed"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date12 As String() = CType(Grid.FindControl("lblWed"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblWed"), Label).Text = Date12(1)
                        End If
                    End If

                Next
                '--------------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblThur"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblThur"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date13 As String() = CType(Grid.FindControl("lblThur"), Label).Text.Split(New Char() {"-"})

                                    Dim HolidayShortName9 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName9 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName9 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblThur"), Label).Text = CType(Grid.FindControl("lblThur"), Label).Text + " " + HolidayShortName9
                                    CType(Grid.FindControl("lblThur"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblThur"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblThur"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblThur"), Label).Text = Date13(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins4
                                End If
                            End If
                        Else
                            Dim HolidayShortName10 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName10 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName10 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblThur"), Label).Text <> "" Then
                                Dim Date14 As String() = CType(Grid.FindControl("lblThur"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblThur"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblThur"), Label).Text = Date14(1) + " " + HolidayShortName10
                                    CType(Grid.FindControl("lblThur"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblThur"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins4
                                End If
                            End If
                        End If


                    Next
ins4:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblThur"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblThur"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date15 As String() = CType(Grid.FindControl("lblThur"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblThur"), Label).Text = Date15(1)
                        End If
                    End If

                Next
                '---------------------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblFri"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblFri"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date16 As String() = CType(Grid.FindControl("lblFri"), Label).Text.Split(New Char() {"-"})
                                    Dim HolidayShortName11 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName11 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName11 = dt1.Rows(i).Item("ShortName")
                                    End If


                                    CType(Grid.FindControl("lblFri"), Label).Text = CType(Grid.FindControl("lblFri"), Label).Text + " " + HolidayShortName11
                                    CType(Grid.FindControl("lblFri"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblFri"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblFri"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblFri"), Label).Text = Date16(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins5
                                End If
                            End If
                        Else
                            Dim HolidayShortName12 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName12 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName12 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblFri"), Label).Text <> "" Then
                                Dim Date17 As String() = CType(Grid.FindControl("lblFri"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblFri"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblFri"), Label).Text = Date17(1) + " " + HolidayShortName12
                                    CType(Grid.FindControl("lblFri"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblFri"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins5
                                End If
                            End If
                        End If


                    Next
ins5:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblFri"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblFri"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date18 As String() = CType(Grid.FindControl("lblFri"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblFri"), Label).Text = Date18(1)
                        End If
                    End If

                Next
                '-----------------------------------------
                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblSat"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblSat"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date19 As String() = CType(Grid.FindControl("lblSat"), Label).Text.Split(New Char() {"-"})

                                    Dim HolidayShortName13 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName13 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName13 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblSat"), Label).Text = CType(Grid.FindControl("lblSat"), Label).Text + " " + HolidayShortName13
                                    CType(Grid.FindControl("lblSat"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblSat"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblSat"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblSat"), Label).Text = Date19(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins6
                                End If
                            End If
                        Else
                            Dim HolidayShortName14 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName14 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName14 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblSat"), Label).Text <> "" Then
                                Dim Date20 As String() = CType(Grid.FindControl("lblSat"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblSat"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblSat"), Label).Text = Date20(1) + " " + HolidayShortName14
                                    CType(Grid.FindControl("lblSat"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblSat"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins6
                                End If
                            End If
                        End If


                    Next
ins6:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblSat"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblSat"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date21 As String() = CType(Grid.FindControl("lblSat"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblSat"), Label).Text = Date21(1)
                        End If
                    End If

                Next
                '----------------------

            End If

            Dim M, Tu, W, Tr, F, St As Integer
            Dim Tot As Integer = 6

            For Each Grid As GridViewRow In GVCal.Rows

                If CType(Grid.FindControl("lblMon"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblMon"), Label).BackColor = Drawing.Color.Red Then
                        M = M + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblTue"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblTue"), Label).BackColor = Drawing.Color.Red Then
                        Tu = Tu + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblWed"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblWed"), Label).BackColor = Drawing.Color.Red Then
                        W = W + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblThur"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblThur"), Label).BackColor = Drawing.Color.Red Then
                        Tr = Tr + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblFri"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblFri"), Label).BackColor = Drawing.Color.Red Then
                        F = F + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblSat"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblSat"), Label).BackColor = Drawing.Color.Red Then
                        St = St + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                Tot = Tot - M - Tu - W - Tr - F - St
                CType(Grid.FindControl("lblWorkDays"), Label).Text = Tot
                Tot = 6
                M = 0
                Tu = 0
                W = 0
                Tr = 0
                F = 0
                St = 0

            Next

        End If

        Dim dt2 As New DataTable
        dt2 = TimeTableDl.GetHolidayDeatils()
        If dt2.Rows.Count > 0 Then
            GridView1.DataSource = dt2
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True

            For Each Grid As GridViewRow In GridView1.Rows
                CType(Grid.FindControl("lblEvents"), Label).Text = CType(Grid.FindControl("lblEDate"), Label).Text + " : " + CType(Grid.FindControl("lblEvents"), Label).Text
                CType(Grid.FindControl("lblHolidays"), Label).Text = CType(Grid.FindControl("lblHDate"), Label).Text + " : " + CType(Grid.FindControl("lblHolidays"), Label).Text
            Next


        End If
        'panel2.Visible = True
        'dt1 = TimeTableDl.ViewHolidayDeatils()
        'Dim i1 As Integer = 0
        'i1 = dt1.Rows.Count
        'While (i1 > 0)
        '    l1.Text = dt1.Rows(i1 - 1)("HolidayName").ToString()
        '    l2.Text = dt1.Rows(i1 - 2)("HolidayName").ToString()
        '    l3.Text = dt1.Rows(i1 - 3)("HolidayName").ToString()
        '    i1 = i1 - 4

        'End While


    End Sub
 
    Protected Sub btnReport1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport1.Click
        Dim FrmDate, ToDate As Date
        If CDate(txtFrmDate.Text) > CDate(txtToDate.Text) Then
            msginfo.Text = "Fromdate cannot be greater than Todate."
            Exit Sub
        ElseIf txtFrmDate.Text = "" Then
            txtFrmDate.Text = Format(Today, "dd-MMM-yyyy")
        ElseIf txtToDate.Text = "" Then

            txtToDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
        FrmDate = txtFrmDate.Text
        ToDate = txtToDate.Text
       
        Dim qrystring As String = "RptCalOfEventsV.aspx?" & QueryStr.Querystring() & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        msginfo.Text = ""
         
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        'ViewState("PageIndex") = GridView1.PageIndex
        ' DisplayGridView()
    End Sub

   

    Protected Sub GVCal_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVCal.PageIndexChanging
        GVCal.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVCal.PageIndex
        btnReport1.Visible = True

        Dim dt, dt1 As New DataTable
        Dim FrmDate, ToDate As Date
        If CDate(txtFrmDate.Text) > CDate(txtToDate.Text) Then
            msginfo.Text = "Fromdate cannot be greater than Todate."
            Exit Sub
        ElseIf txtFrmDate.Text = "" Then
            txtFrmDate.Text = Format(Today, "dd-MMM-yyyy")
        ElseIf txtToDate.Text = "" Then

            txtToDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
        FrmDate = txtFrmDate.Text
        ToDate = txtToDate.Text


        dt = TimeTableDl.ViewCalOfEvents(FrmDate, ToDate)
        If dt.Rows.Count > 0 Then
            GVCal.DataSource = dt
            GVCal.DataBind()
            GVCal.Enabled = True
            GVCal.Visible = True
            For Each Grid As GridViewRow In GVCal.Rows
                If CType(Grid.FindControl("lblMonth"), Label).Text = "1" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Jan"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "2" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Feb"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "3" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Mar"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "4" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Apr"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "5" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "May"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "6" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Jun"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "7" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Jul"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "8" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Aug"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "9" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Sep"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "10" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Oct"
                ElseIf CType(Grid.FindControl("lblMonth"), Label).Text = "11" Then
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Nov"
                Else
                    CType(Grid.FindControl("lblMonth"), Label).Text = "Dec"


                End If
            Next

            msginfo.Text = ""
            dt1 = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt1.Rows.Count > 0) Then

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblSun"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblSun"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date1 As String() = CType(Grid.FindControl("lblSun"), Label).Text.Split(New Char() {"-"})

                                    Dim HolidayShortName1 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName1 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName1 = dt1.Rows(i).Item("ShortName")
                                    End If
                                    CType(Grid.FindControl("lblSun"), Label).Text = CType(Grid.FindControl("lblSun"), Label).Text + " " + HolidayShortName1
                                    CType(Grid.FindControl("lblSun"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblSun"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblSun"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblSun"), Label).Text = Date1(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins
                                End If
                            End If
                        Else
                            Dim HolidayShortName2 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName2 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName2 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblSun"), Label).Text <> "" Then
                                Dim Date2 As String() = CType(Grid.FindControl("lblSun"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblSun"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblSun"), Label).Text = Date2(1) + " " + HolidayShortName2
                                    CType(Grid.FindControl("lblSun"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblSun"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins
                                End If
                            End If
                        End If


                    Next
ins:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblSun"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblSun"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date3 As String() = CType(Grid.FindControl("lblSun"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblSun"), Label).Text = Date3(1)
                        End If
                    End If

                Next

                '-----------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblMon"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblMon"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date4 As String() = CType(Grid.FindControl("lblMon"), Label).Text.Split(New Char() {"-"})
                                    Dim HolidayShortName3 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName3 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName3 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblMon"), Label).Text = CType(Grid.FindControl("lblMon"), Label).Text + " " + HolidayShortName3
                                    CType(Grid.FindControl("lblMon"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblMon"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblMon"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblMon"), Label).Text = Date4(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins1
                                End If
                            End If
                        Else
                            Dim HolidayShortName4 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName4 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName4 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblMon"), Label).Text <> "" Then
                                Dim Date5 As String() = CType(Grid.FindControl("lblMon"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblMon"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblMon"), Label).Text = Date5(1) + " " + HolidayShortName4
                                    CType(Grid.FindControl("lblMon"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblMon"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins1
                                End If
                            End If
                        End If


                    Next
ins1:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblMon"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblMon"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date6 As String() = CType(Grid.FindControl("lblMon"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblMon"), Label).Text = Date6(1)
                        End If
                    End If

                Next
                '-------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblTue"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblTue"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date7 As String() = CType(Grid.FindControl("lblTue"), Label).Text.Split(New Char() {"-"})
                                    Dim HolidayShortName5 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName5 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName5 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblTue"), Label).Text = CType(Grid.FindControl("lblTue"), Label).Text + " " + HolidayShortName5
                                    CType(Grid.FindControl("lblTue"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblTue"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblTue"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblTue"), Label).Text = Date7(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins2
                                End If
                            End If
                        Else
                            Dim HolidayShortName6 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName6 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName6 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblTue"), Label).Text <> "" Then
                                Dim Date8 As String() = CType(Grid.FindControl("lblTue"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblTue"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblTue"), Label).Text = Date8(1) + " " + HolidayShortName6
                                    CType(Grid.FindControl("lblTue"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblTue"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins2
                                End If
                            End If
                        End If


                    Next
ins2:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblTue"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblTue"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date9 As String() = CType(Grid.FindControl("lblTue"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblTue"), Label).Text = Date9(1)
                        End If
                    End If

                Next
                '--------------------------------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblWed"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblWed"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date10 As String() = CType(Grid.FindControl("lblWed"), Label).Text.Split(New Char() {"-"})
                                    Dim HolidayShortName7 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName7 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName7 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblWed"), Label).Text = CType(Grid.FindControl("lblWed"), Label).Text + " " + HolidayShortName7
                                    CType(Grid.FindControl("lblWed"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblWed"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblWed"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblWed"), Label).Text = Date10(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins3
                                End If
                            End If
                        Else
                            Dim HolidayShortName8 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName8 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName8 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblWed"), Label).Text <> "" Then
                                Dim Date11 As String() = CType(Grid.FindControl("lblWed"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblWed"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblWed"), Label).Text = Date11(1) + " " + HolidayShortName8
                                    CType(Grid.FindControl("lblWed"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblWed"), Label).ForeColor = Drawing.Color.White

                                    GoTo ins3
                                End If
                            End If
                        End If


                    Next
ins3:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblWed"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblWed"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date12 As String() = CType(Grid.FindControl("lblWed"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblWed"), Label).Text = Date12(1)
                        End If
                    End If

                Next
                '--------------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblThur"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblThur"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date13 As String() = CType(Grid.FindControl("lblThur"), Label).Text.Split(New Char() {"-"})

                                    Dim HolidayShortName9 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName9 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName9 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblThur"), Label).Text = CType(Grid.FindControl("lblThur"), Label).Text + " " + HolidayShortName9
                                    CType(Grid.FindControl("lblThur"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblThur"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblThur"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblThur"), Label).Text = Date13(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins4
                                End If
                            End If
                        Else
                            Dim HolidayShortName10 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName10 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName10 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblThur"), Label).Text <> "" Then
                                Dim Date14 As String() = CType(Grid.FindControl("lblThur"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblThur"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblThur"), Label).Text = Date14(1) + " " + HolidayShortName10
                                    CType(Grid.FindControl("lblThur"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblThur"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins4
                                End If
                            End If
                        End If


                    Next
ins4:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblThur"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblThur"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date15 As String() = CType(Grid.FindControl("lblThur"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblThur"), Label).Text = Date15(1)
                        End If
                    End If

                Next
                '---------------------------------------

                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblFri"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblFri"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date16 As String() = CType(Grid.FindControl("lblFri"), Label).Text.Split(New Char() {"-"})
                                    Dim HolidayShortName11 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName11 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName11 = dt1.Rows(i).Item("ShortName")
                                    End If


                                    CType(Grid.FindControl("lblFri"), Label).Text = CType(Grid.FindControl("lblFri"), Label).Text + " " + HolidayShortName11
                                    CType(Grid.FindControl("lblFri"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblFri"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblFri"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblFri"), Label).Text = Date16(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins5
                                End If
                            End If
                        Else
                            Dim HolidayShortName12 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName12 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName12 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblFri"), Label).Text <> "" Then
                                Dim Date17 As String() = CType(Grid.FindControl("lblFri"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblFri"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblFri"), Label).Text = Date17(1) + " " + HolidayShortName12
                                    CType(Grid.FindControl("lblFri"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblFri"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins5
                                End If
                            End If
                        End If


                    Next
ins5:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblFri"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblFri"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date18 As String() = CType(Grid.FindControl("lblFri"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblFri"), Label).Text = Date18(1)
                        End If
                    End If

                Next
                '-----------------------------------------
                For Each Grid As GridViewRow In GVCal.Rows
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Status") = "H" Then
                            If CType(Grid.FindControl("lblSat"), Label).Text <> "" Then
                                If CType(Grid.FindControl("lblSat"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then

                                    Dim Date19 As String() = CType(Grid.FindControl("lblSat"), Label).Text.Split(New Char() {"-"})

                                    Dim HolidayShortName13 As String
                                    If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                        HolidayShortName13 = dt1.Rows(i).Item("HolidayName")
                                    Else
                                        HolidayShortName13 = dt1.Rows(i).Item("ShortName")
                                    End If

                                    CType(Grid.FindControl("lblSat"), Label).Text = CType(Grid.FindControl("lblSat"), Label).Text + " " + HolidayShortName13
                                    CType(Grid.FindControl("lblSat"), Label).BackColor = Drawing.Color.Red
                                    CType(Grid.FindControl("lblSat"), Label).ForeColor = Drawing.Color.White

                                    Dim parts As String() = CType(Grid.FindControl("lblSat"), Label).Text.Split(New Char() {"M"})
                                    CType(Grid.FindControl("lblSat"), Label).Text = Date19(1) + " " + parts(1).ToString
                                    'Grid.Cells(i + 2).BackColor = Drawing.Color.Red
                                    'Grid.Cells(i + 2).ForeColor = Drawing.Color.White
                                    GoTo ins6
                                End If
                            End If
                        Else
                            Dim HolidayShortName14 As String
                            If dt1.Rows(i).Item("ShortName").ToString = "" Then
                                HolidayShortName14 = dt1.Rows(i).Item("HolidayName")
                            Else
                                HolidayShortName14 = dt1.Rows(i).Item("ShortName")
                            End If
                            If CType(Grid.FindControl("lblSat"), Label).Text <> "" Then
                                Dim Date20 As String() = CType(Grid.FindControl("lblSat"), Label).Text.Split(New Char() {"-"})
                                If CType(Grid.FindControl("lblSat"), Label).Text = dt1.Rows(i).Item("HolidayDate").Date Then
                                    CType(Grid.FindControl("lblSat"), Label).Text = Date20(1) + " " + HolidayShortName14
                                    CType(Grid.FindControl("lblSat"), Label).BackColor = Drawing.Color.Green
                                    CType(Grid.FindControl("lblSat"), Label).ForeColor = Drawing.Color.White
                                    GoTo ins6
                                End If
                            End If
                        End If


                    Next
ins6:

                Next

                For Each Grid As GridViewRow In GVCal.Rows
                    If CType(Grid.FindControl("lblSat"), Label).Text <> "" Then
                        If CType(Grid.FindControl("lblSat"), Label).ForeColor <> Drawing.Color.White Then
                            Dim Date21 As String() = CType(Grid.FindControl("lblSat"), Label).Text.Split(New Char() {"-"})
                            CType(Grid.FindControl("lblSat"), Label).Text = Date21(1)
                        End If
                    End If

                Next
                '----------------------

            End If

            Dim M, Tu, W, Tr, F, St As Integer
            Dim Tot As Integer = 6

            For Each Grid As GridViewRow In GVCal.Rows

                If CType(Grid.FindControl("lblMon"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblMon"), Label).BackColor = Drawing.Color.Red Then
                        M = M + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblTue"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblTue"), Label).BackColor = Drawing.Color.Red Then
                        Tu = Tu + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblWed"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblWed"), Label).BackColor = Drawing.Color.Red Then
                        W = W + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblThur"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblThur"), Label).BackColor = Drawing.Color.Red Then
                        Tr = Tr + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblFri"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblFri"), Label).BackColor = Drawing.Color.Red Then
                        F = F + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                If CType(Grid.FindControl("lblSat"), Label).Text <> "" Then
                    If CType(Grid.FindControl("lblSat"), Label).BackColor = Drawing.Color.Red Then
                        St = St + 1
                    End If
                Else
                    Tot = Tot - 1
                End If
                Tot = Tot - M - Tu - W - Tr - F - St
                CType(Grid.FindControl("lblWorkDays"), Label).Text = Tot
                Tot = 6
                M = 0
                Tu = 0
                W = 0
                Tr = 0
                F = 0
                St = 0

            Next

        End If

        Dim dt2 As New DataTable
        dt2 = TimeTableDl.GetHolidayDeatils()
        If dt2.Rows.Count > 0 Then
            GridView1.DataSource = dt2
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True

            For Each Grid As GridViewRow In GridView1.Rows
                CType(Grid.FindControl("lblEvents"), Label).Text = CType(Grid.FindControl("lblEDate"), Label).Text + " : " + CType(Grid.FindControl("lblEvents"), Label).Text
                CType(Grid.FindControl("lblHolidays"), Label).Text = CType(Grid.FindControl("lblHDate"), Label).Text + " : " + CType(Grid.FindControl("lblHolidays"), Label).Text
            Next
        End If

    End Sub
End Class

