Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Public Class CourseActionPlan
    'Commented by Nethra during Build 13-Apr-2012

    'Public Function MakeChildTable2(ByVal TDate As Date, ByVal BatchID As Long) As List(Of CourseActionPlanE)
    '    Dim CPlan As New List(Of CourseActionPlanE)
    '    Dim dataset As DataSet = DataPayroll.GetPayroll(0)

    '    Dim table As DataTable = New DataTable("childTable")
    '    Dim column As DataColumn
    '    Dim row As DataRow
    '    Dim year, Tmonth As Int16
    '    year = TDate.Year
    '    Tmonth = TDate.Month

    '    column = New DataColumn()
    '    column.DataType = System.Type.GetType("System.String")
    '    column.ColumnName = "SUN"
    '    column.AutoIncrement = False
    '    column.Caption = "SUN"
    '    column.ReadOnly = False
    '    column.Unique = False
    '    table.Columns.Add(column)

    '    ' Create fourth column.
    '    column = New DataColumn()
    '    column.DataType = System.Type.GetType("System.String")
    '    column.ColumnName = "MON"
    '    column.AutoIncrement = False
    '    column.Caption = "MON"
    '    column.ReadOnly = False
    '    column.Unique = False
    '    table.Columns.Add(column)


    '    column = New DataColumn()
    '    column.DataType = System.Type.GetType("System.String")
    '    column.ColumnName = "TUE"
    '    column.AutoIncrement = False
    '    column.Caption = "TUE"
    '    column.ReadOnly = False
    '    column.Unique = False
    '    table.Columns.Add(column)

    '    ' Create fourth column.
    '    column = New DataColumn()
    '    column.DataType = System.Type.GetType("System.String")
    '    column.ColumnName = "WED"
    '    column.AutoIncrement = False
    '    column.Caption = "WED"
    '    column.ReadOnly = False
    '    column.Unique = False
    '    table.Columns.Add(column)

    '    column = New DataColumn()
    '    column.DataType = System.Type.GetType("System.String")
    '    column.ColumnName = "THU"
    '    column.AutoIncrement = False
    '    column.Caption = "THU"
    '    column.ReadOnly = False
    '    column.Unique = False
    '    table.Columns.Add(column)

    '    column = New DataColumn()
    '    column.DataType = System.Type.GetType("System.String")
    '    column.ColumnName = "FRI"
    '    column.AutoIncrement = False
    '    column.Caption = "FRI"
    '    column.ReadOnly = False
    '    column.Unique = False
    '    table.Columns.Add(column)

    '    column = New DataColumn()
    '    column.DataType = System.Type.GetType("System.String")
    '    column.ColumnName = "SAT"
    '    column.AutoIncrement = False
    '    column.Caption = "SAT"
    '    column.ReadOnly = False
    '    column.Unique = False
    '    table.Columns.Add(column)

    '    Dim dS As New DataSet()
    '    dS.Tables.Add(table)


    '    Dim s As Int16
    '    Dim j As Int16 = Date.DaysInMonth(year, Tmonth)
    '    Dim dt As New DataTable
    '    Dim dayID, i As Int16
    '    Dim idate As Int16 = 1
    '    i = 1
    '    For l As Int16 = 1 To 6
    '        row = table.NewRow()
    '        i = DateValue(TDate.Month & "/" & idate & "/" & TDate.Year).DayOfWeek

    '        While (i + 1 <= 7 And idate <= j)
    '            dt.Clear()
    '            s = DateValue(TDate.Month & "/" & idate & "/" & TDate.Year).DayOfWeek
    '            dayID = s + 1
    '            dt = TimeTableRPTDB.RPT_GetTimeTable(1, 1, 1, BatchID, s + 1).Tables(0)
    '            If dt.Rows.Count > 0 Then


    '                Select Case dayID
    '                    Case 1
    '                        row("SUN") = idate & vbCrLf & "Sub :" & dt.Rows(0)("Subject_Name").ToString & vbCrLf & "Session :" & dt.Rows(0)("Session").ToString
    '                        idate = idate + 1
    '                    Case 2
    '                        row("MON") = idate & vbCrLf & "Sub :" & dt.Rows(0)("Subject_Name").ToString & vbCrLf & "Session :" & dt.Rows(0)("Session").ToString
    '                        idate = idate + 1
    '                    Case 3
    '                        row("TUE") = idate & vbCrLf & "Sub :" & dt.Rows(0)("Subject_Name").ToString & vbCrLf & "Session :" & dt.Rows(0)("Session").ToString
    '                        idate = idate + 1
    '                    Case 4
    '                        row("WED") = idate & vbCrLf & "Sub :" & dt.Rows(0)("Subject_Name").ToString & vbCrLf & "Session :" & dt.Rows(0)("Session").ToString
    '                        idate = idate + 1
    '                    Case 5
    '                        row("THU") = idate & vbCrLf & "Sub :" & dt.Rows(0)("Subject_Name").ToString & vbCrLf & "Session :" & dt.Rows(0)("Session").ToString
    '                        idate = idate + 1
    '                    Case 6
    '                        row("FRI") = idate & vbCrLf & "Sub :" & dt.Rows(0)("Subject_Name").ToString & vbCrLf & "Session :" & dt.Rows(0)("Session").ToString
    '                        idate = idate + 1
    '                    Case 7
    '                        row("SAT") = idate & vbCrLf & "Sub :" & dt.Rows(0)("Subject_Name").ToString & vbCrLf & "Session :" & dt.Rows(0)("Session").ToString
    '                        idate = idate + 1
    '                End Select
    '                i = i + 1
    '            Else
    '            End If
    '        End While
    '        Dim cnt As Integer = 0
    '        row("SUN") = row("SUN").ToString()
    '        row("MON") = row("MON").ToString()
    '        row("TUE") = row("TUE").ToString()
    '        row("WED") = row("WED").ToString()
    '        row("THU") = row("THU").ToString()
    '        row("FRI") = row("FRI").ToString()
    '        row("SAT") = row("SAT").ToString()
    '        CPlan.Add(New CourseActionPlanE(row("Sun"), row("Mon"), row("Tue"), row("Wed"), row("Thu"), row("Fri"), row("Sat")))
    '        If idate > j Then
    '            Exit For
    '        End If
    '    Next
    '    Return CPlan
    'End Function
End Class
