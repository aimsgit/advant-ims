
Partial Class RptCalEventsold
    Inherits BasePage
    Dim dt As New DataTable

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Calendar1.Visible = True
    '    Calendar2.Visible = True
    '    Calendar1.ShowNextPrevMonth = False
    '    Dim MyCultureInfo As System.Globalization.CultureInfo
    '    MyCultureInfo = New System.Globalization.CultureInfo("en-US")
    '    Dim dtString As String = "01/" & Now.Month.ToString & "/" & Now.Year.ToString
    '    Dim dt As DateTime = DateTime.Parse(dtString, MyCultureInfo)
    '    Calendar1.FirstDayOfWeek = dt.DayOfWeek
    '    Calendar1.TodaysDate = Now
    '    Calendar1.VisibleDate = Now
    'End Sub


    'Private Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
    '    If e.Day.IsOtherMonth Then
    '        e.Cell.Text = " "
    '    End If
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtFrmDate.Text = Format(Today(), "dd-MMM-yyyy")
            txtToDate.Text = Format(Today(), "dd-MMM-yyyy")
            div2.Visible = False
        End If


    End Sub


    Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As DayRenderEventArgs) Handles Calendar1.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

        'Dim weeknum As Integer = weeknum(e.Day.Date)
        '    TableCell cell = ((DayRenderEventArgs)e).Cell
        'cell.Controls.Add(New LiteralControl("weekmum:" + weeknum.ToString()))
    End Sub
    'Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As DayRenderEventArgs)
    '    Dim weeknum As Integer = NoOfWeek(e.Day.[Date])
    '    Dim cell As TableCell = DirectCast(e, DayRenderEventArgs).Cell
    '    cell.Controls.Add(New LiteralControl("weekmum:" & weeknum.ToString()))
    'End Sub


    Protected Sub Calendar2_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar2.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar3_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar3.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar4_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar4.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar5_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar5.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar6_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar6.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar7_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar7.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar8_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar8.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar9_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar9.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar10_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar10.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar11_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar11.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Calendar12_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar12.DayRender
        'If e.Day.IsOtherMonth Then
        '    e.Cell.Text = ""
        'End If
        Try

            msginfo.Text = ""
            dt = TimeTableDl.ViewHolidayDeatils()
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        If dt.Rows(i).Item("Status") = "H" Then

                            e.Cell.BackColor = System.Drawing.Color.Red
                            e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        Else
                            'e.Cell.BackColor = System.Drawing.Color.Red
                            'e.Cell.ForeColor = System.Drawing.Color.White
                            'lb.Text = dt.Rows(i).Item("HolidayName")
                            e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                            'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        'Dim STARTDATE As Date = Calendar2.SelectedDate
        Dim Frmdate, Todate As Date
        div2.Visible = True
        Calendar1.ShowNextPrevMonth = False
        Calendar2.ShowNextPrevMonth = False
        Calendar3.ShowNextPrevMonth = False
        Calendar4.ShowNextPrevMonth = False
        Calendar5.ShowNextPrevMonth = False
        Calendar6.ShowNextPrevMonth = False
        Calendar7.ShowNextPrevMonth = False
        Calendar8.ShowNextPrevMonth = False
        Calendar9.ShowNextPrevMonth = False
        Calendar10.ShowNextPrevMonth = False
        Calendar11.ShowNextPrevMonth = False
        Calendar12.ShowNextPrevMonth = False

        Frmdate = txtFrmDate.Text
        Todate = txtToDate.Text

        Dim M As Integer = Math.Abs((Frmdate.Year - Todate.Year))
        Dim months As Integer = ((M * 12) + Math.Abs((Frmdate.Month - Todate.Month))) + 1
        If months > 12 Then
            msginfo.Text = "Cannot generate Calendar more than 1 Year."
        Else

            If months = 1 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = False
                Calendar3.Visible = False
                Calendar4.Visible = False
                Calendar5.Visible = False
                Calendar6.Visible = False
                Calendar7.Visible = False
                Calendar8.Visible = False
                Calendar9.Visible = False
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 2 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = False
                Calendar4.Visible = False
                Calendar5.Visible = False
                Calendar6.Visible = False
                Calendar7.Visible = False
                Calendar8.Visible = False
                Calendar9.Visible = False
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 3 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = False
                Calendar5.Visible = False
                Calendar6.Visible = False
                Calendar7.Visible = False
                Calendar8.Visible = False
                Calendar9.Visible = False
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 4 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = False
                Calendar6.Visible = False
                Calendar7.Visible = False
                Calendar8.Visible = False
                Calendar9.Visible = False
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 5 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = True
                Calendar5.VisibleDate = DateAdd(DateInterval.Month, 4, Frmdate)
                Calendar6.Visible = False
                Calendar7.Visible = False
                Calendar8.Visible = False
                Calendar9.Visible = False
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 6 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = True
                Calendar5.VisibleDate = DateAdd(DateInterval.Month, 4, Frmdate)
                Calendar6.Visible = True
                Calendar6.VisibleDate = DateAdd(DateInterval.Month, 5, Frmdate)
                Calendar7.Visible = False
                Calendar8.Visible = False
                Calendar9.Visible = False
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 7 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = True
                Calendar5.VisibleDate = DateAdd(DateInterval.Month, 4, Frmdate)
                Calendar6.Visible = True
                Calendar6.VisibleDate = DateAdd(DateInterval.Month, 5, Frmdate)
                Calendar7.Visible = True
                Calendar7.VisibleDate = DateAdd(DateInterval.Month, 6, Frmdate)
                Calendar8.Visible = False
                Calendar9.Visible = False
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 8 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = True
                Calendar5.VisibleDate = DateAdd(DateInterval.Month, 4, Frmdate)
                Calendar6.Visible = True
                Calendar6.VisibleDate = DateAdd(DateInterval.Month, 5, Frmdate)
                Calendar7.Visible = True
                Calendar7.VisibleDate = DateAdd(DateInterval.Month, 6, Frmdate)
                Calendar8.Visible = True
                Calendar8.VisibleDate = DateAdd(DateInterval.Month, 7, Frmdate)
                Calendar9.Visible = False
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 9 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = True
                Calendar5.VisibleDate = DateAdd(DateInterval.Month, 4, Frmdate)
                Calendar6.Visible = True
                Calendar6.VisibleDate = DateAdd(DateInterval.Month, 5, Frmdate)
                Calendar7.Visible = True
                Calendar7.VisibleDate = DateAdd(DateInterval.Month, 6, Frmdate)
                Calendar8.Visible = True
                Calendar8.VisibleDate = DateAdd(DateInterval.Month, 7, Frmdate)
                Calendar9.Visible = True
                Calendar9.VisibleDate = DateAdd(DateInterval.Month, 8, Frmdate)
                Calendar10.Visible = False
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 10 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = True
                Calendar5.VisibleDate = DateAdd(DateInterval.Month, 4, Frmdate)
                Calendar6.Visible = True
                Calendar6.VisibleDate = DateAdd(DateInterval.Month, 5, Frmdate)
                Calendar7.Visible = True
                Calendar7.VisibleDate = DateAdd(DateInterval.Month, 6, Frmdate)
                Calendar8.Visible = True
                Calendar8.VisibleDate = DateAdd(DateInterval.Month, 7, Frmdate)
                Calendar9.Visible = True
                Calendar9.VisibleDate = DateAdd(DateInterval.Month, 8, Frmdate)
                Calendar10.Visible = True
                Calendar10.VisibleDate = DateAdd(DateInterval.Month, 9, Frmdate)
                Calendar11.Visible = False
                Calendar12.Visible = False
            ElseIf months = 11 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = True
                Calendar5.VisibleDate = DateAdd(DateInterval.Month, 4, Frmdate)
                Calendar6.Visible = True
                Calendar6.VisibleDate = DateAdd(DateInterval.Month, 5, Frmdate)
                Calendar7.Visible = True
                Calendar7.VisibleDate = DateAdd(DateInterval.Month, 6, Frmdate)
                Calendar8.Visible = True
                Calendar8.VisibleDate = DateAdd(DateInterval.Month, 7, Frmdate)
                Calendar9.Visible = True
                Calendar9.VisibleDate = DateAdd(DateInterval.Month, 8, Frmdate)
                Calendar10.Visible = True
                Calendar10.VisibleDate = DateAdd(DateInterval.Month, 9, Frmdate)
                Calendar11.Visible = True
                Calendar11.VisibleDate = DateAdd(DateInterval.Month, 10, Frmdate)
                Calendar12.Visible = False
            ElseIf months = 12 Then
                Calendar1.Visible = True
                Calendar1.VisibleDate = DateAdd(DateInterval.Month, 0, Frmdate)
                Calendar2.Visible = True
                Calendar2.VisibleDate = DateAdd(DateInterval.Month, 1, Frmdate)
                Calendar3.Visible = True
                Calendar3.VisibleDate = DateAdd(DateInterval.Month, 2, Frmdate)
                Calendar4.Visible = True
                Calendar4.VisibleDate = DateAdd(DateInterval.Month, 3, Frmdate)
                Calendar5.Visible = True
                Calendar5.VisibleDate = DateAdd(DateInterval.Month, 4, Frmdate)
                Calendar6.Visible = True
                Calendar6.VisibleDate = DateAdd(DateInterval.Month, 5, Frmdate)
                Calendar7.Visible = True
                Calendar7.VisibleDate = DateAdd(DateInterval.Month, 6, Frmdate)
                Calendar8.Visible = True
                Calendar8.VisibleDate = DateAdd(DateInterval.Month, 7, Frmdate)
                Calendar9.Visible = True
                Calendar9.VisibleDate = DateAdd(DateInterval.Month, 8, Frmdate)
                Calendar10.Visible = True
                Calendar10.VisibleDate = DateAdd(DateInterval.Month, 9, Frmdate)
                Calendar11.Visible = True
                Calendar11.VisibleDate = DateAdd(DateInterval.Month, 10, Frmdate)
                Calendar12.Visible = True
                Calendar12.VisibleDate = DateAdd(DateInterval.Month, 11, Frmdate)
                'GetWeekNumber(Today())

            End If

        End If




    End Sub
    'Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As DayRenderEventArgs)
    '    Dim currentCulture As System.Globalization.CultureInfo
    '    Dim weeknum As Integer = currentCulture.Calendar.GetWeekOfYear(e.Day.[Date], currentCulture.DateTimeFormat.CalendarWeekRule, currentCulture.DateTimeFormat.FirstDayOfWeek)
    '    e.Cell.Controls.Add(New LiteralControl(String.Format("({0})", weeknum)))
    'End Sub
    'Public Function GetWeekNumber(ByVal dtTime As DateTime) As Integer
    '    Dim currentCulture As System.Globalization.CultureInfo
    '    currentCulture = Globalization.CultureInfo.CurrentCulture
    '    Dim weekNum As Integer
    '    If dtTime.Year < 2000 Then
    '        weekNum = currentCulture.Calendar.GetWeekOfYear(dtTime, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
    '    Else
    '        weekNum = currentCulture.Calendar.GetWeekOfYear(dtTime, Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday)
    '    End If
    '    Return weekNum
    'End Function


End Class
