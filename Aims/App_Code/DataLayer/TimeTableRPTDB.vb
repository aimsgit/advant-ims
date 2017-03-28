Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class TimeTableRPTDB
    Private dataSet As DataSet

    Private Sub MakeDataTables()
        ' Run all of the functions. 
        MakeParentTable()
        'MakeChildTable()
        MakeDataRelation()
        BindToDataGrid()
    End Sub

    Private Sub MakeParentTable()
        ' Create a new DataTable.
        Dim table As DataTable = New DataTable("ParentTable")

        ' Declare variables for DataColumn and DataRow objects.
        Dim column As DataColumn
        ' Create new DataColumn, set DataType, ColumnName 
        ' and add to DataTable.    
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True

        ' Add the Column to the DataColumnCollection.
        table.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.DateTime")
        column.ColumnName = "TDate"
        column.AutoIncrement = False
        column.Caption = "ParentItem"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        table.Columns.Add(column)

        ' Make the ID column the primary key column.
        Dim PrimaryKeyColumns(0) As DataColumn
        PrimaryKeyColumns(0) = table.Columns("id")
        table.PrimaryKey = PrimaryKeyColumns

        ' Instantiate the DataSet variable.
        dataSet = New DataSet()

        ' Add the new DataTable to the DataSet.
        dataSet.Tables.Add(table)

        ' Create three new DataRow objects and add 
        ' them to the DataTable

        'Dim i As Integer
        'For i = 0 To 2
        '    row = table.NewRow()
        '    row("id") = i
        '    row("ParentItem") = "ParentItem " + i.ToString()
        '    table.Rows.Add(row)
        'Next i
    End Sub

    Public Function MakeChildTable(ByVal TDate As Date) As DataSet
        ' Create a new DataTable.
        Dim table As DataTable = New DataTable("childTable")
        Dim column As DataColumn
        Dim row As DataRow
        Dim year, Tmonth As Int16
        year = 2009
        Tmonth = 11


        ' Create first column and add to the DataTable.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "ChildID"
        column.AutoIncrement = True
        column.Caption = "ID"
        column.ReadOnly = True
        column.Unique = True

        ' Add the column to the DataColumnCollection.
        table.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.DateTime")
        column.ColumnName = "CTDate"
        column.AutoIncrement = False
        column.Caption = "CTDate"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)

        '' Create third column.
        'column = New DataColumn()
        'column.DataType = System.Type.GetType("System.Int32")
        'column.ColumnName = "ParentID"
        'column.AutoIncrement = False
        'column.Caption = "ParentID"
        'column.ReadOnly = False
        'column.Unique = False
        'table.Columns.Add(column)

        '

        ' Create third column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "SubjectName"
        column.AutoIncrement = False
        column.Caption = "SubjectName"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)

        ' Create fourth column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "Session"
        column.AutoIncrement = False
        column.Caption = "Session"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)
        dataSet = New DataSet()
        dataSet.Tables.Add(table)


        Dim s As Int16
        Dim j As Int16 = Date.DaysInMonth(year, Tmonth)
        Dim dt As New DataTable
        For i As Int16 = 1 To j
            dt.Clear()
            s = DateValue(TDate.Month & "/" & i & "/" & TDate.Year).DayOfWeek
            dt = TimeTableRPTDB.RPT_GetTimeTable(11, 20, 1, 1, s + 1).Tables(0)

            row = table.NewRow()
            row("ChildID") = i
            row("CTDate") = DateValue(TDate.Month & "/" & i & "/" & TDate.Year)
            row("SubjectName") = dt.Rows(0)("Subject_Name").ToString
            row("Session") = dt.Rows(0)("Session").ToString
            table.Rows.Add(row)
        Next


        Return dataSet




        ' Create three sets of DataRow objects, five rows each, 
        ' and add to DataTable.
        'Dim i As Integer
        'For i = 0 To 4
        '    row = table.NewRow()
        '    row("childID") = i
        '    row("ChildItem") = "Item " + i.ToString()
        '    row("ParentID") = 0
        '    table.Rows.Add(row)
        'Next i
        'For i = 0 To 4
        '    row = table.NewRow()
        '    row("childID") = i + 5
        '    row("ChildItem") = "Item " + i.ToString()
        '    row("ParentID") = 1
        '    table.Rows.Add(row)
        'Next i
        'For i = 0 To 4
        '    row = table.NewRow()
        '    row("childID") = i + 10
        '    row("ChildItem") = "Item " + i.ToString()
        '    row("ParentID") = 2
        '    table.Rows.Add(row)
        'Next i
    End Function
    Public Function MakeChildTable2(ByVal TDate As Date) As DataSet
        ' Create a new DataTable.
        Dim table As DataTable = New DataTable("childTable")
        Dim column As DataColumn
        Dim row As DataRow
        Dim year, Tmonth As Int16
        year = 2009
        Tmonth = 11


        ' Create first column and add to the DataTable.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "ChildID"
        column.AutoIncrement = True
        column.Caption = "ID"
        column.ReadOnly = True
        column.Unique = True

        ' Add the column to the DataColumnCollection.
        table.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.DateTime")
        column.ColumnName = "CTDate"
        column.AutoIncrement = False
        column.Caption = "CTDate"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)

      
        ' Create third column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "SUN"
        column.AutoIncrement = False
        column.Caption = "SUN"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)

        ' Create fourth column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "MON"
        column.AutoIncrement = False
        column.Caption = "MON"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)
        dataSet = New DataSet()
        dataSet.Tables.Add(table)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "TUE"
        column.AutoIncrement = False
        column.Caption = "TUE"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)

        ' Create fourth column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "WED"
        column.AutoIncrement = False
        column.Caption = "WED"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)
        dataSet = New DataSet()
        dataSet.Tables.Add(table)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "THS"
        column.AutoIncrement = False
        column.Caption = "THS"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)

        ' Create fourth column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "FRI"
        column.AutoIncrement = False
        column.Caption = "FRI"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)
        dataSet = New DataSet()
        dataSet.Tables.Add(table)

        ' Create fourth column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "SAT"
        column.AutoIncrement = False
        column.Caption = "SAT"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)
        dataSet = New DataSet()
        dataSet.Tables.Add(table)


        Dim s As Int16
        Dim j As Int16 = Date.DaysInMonth(year, Tmonth)
        Dim dt As New DataTable
        Dim dayID, i As Int16
        Dim idate As Int16 = 1

        i = 1
        For l As Int16 = 1 To 6


            ' For k As Int16 = 1 To 7


            'For i As Int16 = 1 To 7
            i = DateValue(TDate.Month & "/" & idate & "/" & TDate.Year).DayOfWeek

            While (i + 1 <= 7)
                dt.Clear()
                s = DateValue(TDate.Month & "/" & idate & "/" & TDate.Year).DayOfWeek
                dayID = s
                dt = TimeTableRPTDB.RPT_GetTimeTable(11, 20, 1, 1, s + 1).Tables(0)

                Select Case dayID
                    Case 1
                        'row("ChildID") = i
                        'row("CTDate") = DateValue(TDate.Month & "/" & i & "/" & TDate.Year)
                        row("SUN") = i & vbCrLf & dt.Rows(0)("Subject_Name").ToString & vbCrLf & dt.Rows(0)("Session").ToString
                        'row("MON") = Nothing
                        'row("TUE") = Nothing
                        'row("WED") = Nothing
                        'row("THS") = Nothing
                        'row("FRI") = Nothing
                        'row("SAT") = Nothing
                        idate = idate + 1
                    Case 2
                        row("MON") = i & vbCrLf & dt.Rows(0)("Subject_Name").ToString & vbCrLf & dt.Rows(0)("Session").ToString
                        idate = idate + 1
                    Case 3
                        row("TUE") = i & vbCrLf & dt.Rows(0)("Subject_Name").ToString & vbCrLf & dt.Rows(0)("Session").ToString
                        idate = idate + 1
                    Case 4
                        row("WED") = i & vbCrLf & dt.Rows(0)("Subject_Name").ToString & vbCrLf & dt.Rows(0)("Session").ToString
                        idate = idate + 1
                    Case 5
                        row("THU") = i & vbCrLf & dt.Rows(0)("Subject_Name").ToString & vbCrLf & dt.Rows(0)("Session").ToString
                        idate = idate + 1
                    Case 6
                        row("FRI") = i & vbCrLf & dt.Rows(0)("Subject_Name").ToString & vbCrLf & dt.Rows(0)("Session").ToString
                        idate = idate + 1
                    Case 7
                        row("SAT") = i & vbCrLf & dt.Rows(0)("Subject_Name").ToString & vbCrLf & dt.Rows(0)("Session").ToString
                        idate = idate + 1
                End Select

                'Next

                i = i + 1
            End While

            'Next
            table.Rows.Add(row)
        Next





        'For i As Int16 = 1 To j
        '    dt.Clear()
        '    s = DateValue(TDate.Month & "/" & i & "/" & TDate.Year).DayOfWeek
        '    dt = TimeTableRPTDB.RPT_GetTimeTable(11, 20, 1, 1, s + 1).Tables(0)

        '    row("ChildID") = i
        '    row("CTDate") = DateValue(TDate.Month & "/" & i & "/" & TDate.Year)

        '    row = table.NewRow()
        '    row("ChildID") = i
        '    row("CTDate") = DateValue(TDate.Month & "/" & i & "/" & TDate.Year)
        '    row("SubjectName") = dt.Rows(0)("Subject_Name").ToString
        '    row("Session") = dt.Rows(0)("Session").ToString
        '    table.Rows.Add(row)
        'Next


        Return dataSet


    End Function
    Private Sub MakeDataRelation()
        ' DataRelation requires two DataColumn 
        ' (parent and child) and a name.
        Dim parentColumn As DataColumn = _
            dataSet.Tables("ParentTable").Columns("id")
        Dim childColumn As DataColumn = _
            dataSet.Tables("ChildTable").Columns("ParentID")
        Dim relation As DataRelation = New _
            DataRelation("parent2Child", parentColumn, childColumn)
        dataSet.Tables("ChildTable").ParentRelations.Add(relation)
    End Sub

    Private Sub BindToDataGrid()
        ' Instruct the DataGrid to bind to the DataSet, with the 
        ' ParentTable as the topmost DataTable.
        'DataGrid1.SetDataBinding(dataSet, "ParentTable")
    End Sub
    Public Function GenerateTimeTable(ByVal TDate As Date) As DataSet
        Dim year, Tmonth As Int16
        year = 2009
        Tmonth = 11

        Dim table As DataTable = New DataTable("ParentTable")
        Dim column As DataColumn
        Dim row As DataRow


        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True


        table.Columns.Add(column)


        column = New DataColumn()
        column.DataType = System.Type.GetType("System.DateTime")
        column.ColumnName = "TDate"
        column.AutoIncrement = False
        column.Caption = "TDate"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        table.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int16")
        column.ColumnName = "TDay"
        column.AutoIncrement = False
        column.Caption = "TDay"
        column.ReadOnly = False
        column.Unique = False
        table.Columns.Add(column)
        Dim PrimaryKeyColumns(0) As DataColumn
        PrimaryKeyColumns(0) = table.Columns("id")
        table.PrimaryKey = PrimaryKeyColumns


        dataSet = New DataSet()

        dataSet.Tables.Add(table)

        Dim s As Int16
        Dim j As Int16 = Date.DaysInMonth(year, Tmonth)
        For i As Int16 = 1 To j
            'r = DateValue(i & "/" & TDate.Month & "/" & TDate.Year).Day
            s = DateValue(TDate.Month & "/" & i & "/" & TDate.Year).DayOfWeek
            't = DateValue(i & "/" & TDate.Month & "/" & TDate.Year).DayOfYear
            '  s = CDate(i & "/" & TDate.Month & "/" & TDate.Year).DayOfWeek
            row = table.NewRow()
            row("id") = i
            row("TDate") = DateValue(TDate.Month & "/" & i & "/" & TDate.Year)
            row("TDay") = s + 1
            'row("TDate") = CDate(i & "/" & TDate.Month & "/" & TDate.Year)
            table.Rows.Add(row)
        Next

        Return dataSet

        'End If
        'Dim ds As DataSet
        'ds = RPT_GetTimeTable(56, 73, 1, 1)


    End Function
    Shared Function RPT_GetTimeTable(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16, ByVal dayID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            'arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            'arParms(0).Value = branchID

            'arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            'arParms(1).Value = instID

            'arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            'arParms(2).Value = corsID


            arParms(0) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(0).Value = batchID

            arParms(1) = New SqlParameter("@Day_Code", SqlDbType.Int)
            arParms(1).Value = dayID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_RPT_GetTimeTableDetails]", arParms)
            Return ds

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

End Class
