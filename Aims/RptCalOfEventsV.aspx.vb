
Partial Class RptCalOfEventsV
    Inherits System.Web.UI.Page
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Dim dt1, dt3, dt4 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim dm, dm1 As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim FrmDate As Date = Request.QueryString.Get("FrmDate")
        Dim ToDate As Date = Request.QueryString.Get("ToDate")

        dt1 = TimeTableDl.RptCalOfEvents(FrmDate, ToDate)
        dt3 = TimeTableDl.ViewHolidayDeatils()
        dt4 = TimeTableDl.GetHolidayDeatils()

        Dim count1, count2 As Integer

        count1 = dt1.Rows.Count
        count2 = dt3.Rows.Count

        While count1 > 0
            count2 = dt3.Rows.Count
            While count2 > 0
                If dt1.Rows(count1 - 1).Item("Mon") <> "0" Then
                    If dt1.Rows(count1 - 1).Item("Mon") = (dt3.Rows(count2 - 1).Item("HolidayDate")) Then
                        If dt3.Rows(count2 - 1).Item("Status") = "E" Then
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Mon")) + "-" + (dt3.Rows(count2 - 1).Item("ShortName"))
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Mon") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        Else
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Mon")) + "-" + "H"
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Mon") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        End If

                    End If
                End If
                count2 = count2 - 1
            End While
            Dim parts3 As String() = (dt1.Rows(count1 - 1).Item("Mon")).Split(New Char() {"-"})
            If parts3.Length > 1 Then
                dt1.Rows(count1 - 1).Item("MOn") = parts3(2)
                count1 = count1 - 1
            Else

                count1 = count1 - 1
            End If
        End While
        '-------------------------------------------
        count1 = dt1.Rows.Count
        count2 = dt3.Rows.Count
        While count1 > 0
            count2 = dt3.Rows.Count
            While count2 > 0
                If dt1.Rows(count1 - 1).Item("Tue") <> "0" Then
                    If dt1.Rows(count1 - 1).Item("Tue") = (dt3.Rows(count2 - 1).Item("HolidayDate")) Then
                        If dt3.Rows(count2 - 1).Item("Status") = "E" Then
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Tue")) + "-" + (dt3.Rows(count2 - 1).Item("ShortName"))
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Tue") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        Else
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Tue")) + "-" + "H"
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Tue") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        End If
                    End If
                End If
                count2 = count2 - 1
            End While
            Dim parts3 As String() = (dt1.Rows(count1 - 1).Item("Tue")).Split(New Char() {"-"})
            If parts3.Length > 1 Then
                dt1.Rows(count1 - 1).Item("Tue") = parts3(2)
                count1 = count1 - 1
            Else

                count1 = count1 - 1
            End If
        End While
        '===========================
        count1 = dt1.Rows.Count
        count2 = dt3.Rows.Count
        While count1 > 0
            count2 = dt3.Rows.Count
            While count2 > 0
                If dt1.Rows(count1 - 1).Item("Wed") <> "0" Then
                    If dt1.Rows(count1 - 1).Item("Wed") = (dt3.Rows(count2 - 1).Item("HolidayDate")) Then
                        If dt3.Rows(count2 - 1).Item("Status") = "E" Then
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Wed")) + "-" + (dt3.Rows(count2 - 1).Item("ShortName"))
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Wed") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        Else
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Wed")) + "-" + "H"
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Wed") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        End If
                    End If
                End If
                count2 = count2 - 1
            End While
            Dim parts3 As String() = (dt1.Rows(count1 - 1).Item("Wed")).Split(New Char() {"-"})
            If parts3.Length > 1 Then
                dt1.Rows(count1 - 1).Item("Wed") = parts3(2)
                count1 = count1 - 1
            Else

                count1 = count1 - 1
            End If
        End While
        '===========================
        count1 = dt1.Rows.Count
        count2 = dt3.Rows.Count
        While count1 > 0
            count2 = dt3.Rows.Count
            While count2 > 0
                If dt1.Rows(count1 - 1).Item("Thu") <> "0" Then
                    If dt1.Rows(count1 - 1).Item("Thu") = (dt3.Rows(count2 - 1).Item("HolidayDate")) Then
                        If dt3.Rows(count2 - 1).Item("Status") = "E" Then
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Thu")) + "-" + (dt3.Rows(count2 - 1).Item("ShortName"))
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Thu") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        Else
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Thu")) + "-" + "H"
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Thu") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        End If
                    End If
                End If
                count2 = count2 - 1
            End While
            Dim parts3 As String() = (dt1.Rows(count1 - 1).Item("Thu")).Split(New Char() {"-"})
            If parts3.Length > 1 Then
                dt1.Rows(count1 - 1).Item("Thu") = parts3(2)
                count1 = count1 - 1
            Else

                count1 = count1 - 1
            End If
        End While
        '===========================
        count1 = dt1.Rows.Count
        count2 = dt3.Rows.Count
        While count1 > 0
            count2 = dt3.Rows.Count
            While count2 > 0
                If dt1.Rows(count1 - 1).Item("Fri") <> "0" Then
                    If dt1.Rows(count1 - 1).Item("Fri") = (dt3.Rows(count2 - 1).Item("HolidayDate")) Then
                        If dt3.Rows(count2 - 1).Item("Status") = "E" Then
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Fri")) + "-" + (dt3.Rows(count2 - 1).Item("ShortName"))
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Fri") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        Else
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Fri")) + "-" + "H"
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Fri") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        End If
                    End If
                End If
                count2 = count2 - 1
            End While
            Dim parts3 As String() = (dt1.Rows(count1 - 1).Item("Fri")).Split(New Char() {"-"})
            If parts3.Length > 1 Then
                dt1.Rows(count1 - 1).Item("Fri") = parts3(2)
                count1 = count1 - 1
            Else

                count1 = count1 - 1
            End If
        End While
        '===========================

        count1 = dt1.Rows.Count
        count2 = dt3.Rows.Count
        While count1 > 0
            count2 = dt3.Rows.Count
            While count2 > 0
                If dt1.Rows(count1 - 1).Item("Sat") <> "0" Then
                    If dt1.Rows(count1 - 1).Item("Sat") = (dt3.Rows(count2 - 1).Item("HolidayDate")) Then
                        If dt3.Rows(count2 - 1).Item("Status") = "E" Then
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Sat")) + "-" + (dt3.Rows(count2 - 1).Item("ShortName"))
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Sat") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        Else
                            Dim parts1 As String = (dt1.Rows(count1 - 1).Item("Sat")) + "-" + "H"
                            Dim parts As String() = parts1.Split(New Char() {"-"})
                            dt1.Rows(count1 - 1).Item("Sat") = parts(2) + ":" + parts(3)
                            count2 = count2 - 1
                            Exit While
                        End If
                    End If
                End If
                count2 = count2 - 1
            End While
            Dim parts3 As String() = (dt1.Rows(count1 - 1).Item("Sat")).Split(New Char() {"-"})
            If parts3.Length > 1 Then
                dt1.Rows(count1 - 1).Item("Sat") = parts3(2)
                count1 = count1 - 1
            Else

                count1 = count1 - 1
            End If
        End While
        '===========================
        count1 = dt1.Rows.Count
        While count1 > 0
            If dt1.Rows(count1 - 1).Item("Sun") <> "0" Then

                Dim parts3 As String() = (dt1.Rows(count1 - 1).Item("Sun")).Split(New Char() {"-"})
                If parts3.Length > 1 Then
                    dt1.Rows(count1 - 1).Item("Sun") = parts3(2)

                End If
            End If
            count1 = count1 - 1
        End While
        '===========================




        If dt1.Rows.Count > 0 Then
            If dt4.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "RptCalOfEvents.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_CalOfEvents", dt1)
                dm1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_New_GetHolidayDetails", dt4)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FrmDate", FrmDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                Me.ReportViewer1.LocalReport.DataSources.Add(dm1)
                ReportViewer1.LocalReport.Refresh()

                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblMsg.Text = "No Records to display."
            End If
        Else
            lblMsg.Text = "No Records to display."
        End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
