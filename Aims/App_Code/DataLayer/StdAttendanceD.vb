Imports System.Data
Imports System.Data.SqlClient

Namespace GlobalDataSetTableAdapters
    Partial Public Class AttendanceTableAdapter
        'Dim dt As Data.DataTable
        Dim str As String
        Dim da As OleDb.OleDbDataAdapter
        Private _transaction As SqlTransaction
        Private Property Transaction() As SqlClient.SqlTransaction
            Get
                Return Me._transaction
            End Get
            Set(ByVal Value As SqlTransaction)
                Me._transaction = Value
            End Set
        End Property
        'Public Sub BeginTransaction()
        '    ' Open the connection, if needed
        '    If Me.Connection.State <> ConnectionState.Open Then
        '        Me.Connection.Open()
        '    End If
        '    ' Create the transaction and assign it to the Transaction property
        '    Me.Transaction = Me.Connection.BeginTransaction()
        '    ' Attach the transaction to the Adapters
        '    For Each command As SqlCommand In Me.CommandCollection
        '        command.Transaction = Me.Transaction
        '    Next
        '    Me.Adapter.InsertCommand.Transaction = Me.Transaction
        '    Me.Adapter.UpdateCommand.Transaction = Me.Transaction
        '    Me.Adapter.DeleteCommand.Transaction = Me.Transaction
        'End Sub
        'Public Sub CommitTransaction()
        '    ' Commit the transaction
        '    Me.Transaction.Commit()
        '    ' Close the connection
        '    Me.Connection.Close()
        'End Sub
        'Public Sub RollbackTransaction()
        '    ' Rollback the transaction
        '    Me.Transaction.Rollback()
        '    ' Close the connection
        '    Me.Connection.Close()
        'End Sub
        'Public Function UpdateWithTransaction(ByVal dataTable As GlobalDataSet.AttendanceDataTable) As Integer
        '    Me.BeginTransaction()
        '    Try                ' Perform the update on the DataTable
        '        Dim returnValue As Integer = Me.Adapter.Update(DataTable)
        '        ' If we reach here, no errors, so commit the transaction
        '        Me.CommitTransaction()
        '        Return returnValue
        '    Catch
        '        ' If we reach here, there was an error, so rollback the transaction
        '        Me.RollbackTransaction()
        '        Throw
        '    End Try
        'End Function
        Public Function GetDataByEmp(ByVal DeptId As Int32, ByVal doj As Date, ByVal dol As Date, ByVal Category As Int16, ByVal insid As Int64, ByVal brnid As Int64) As Data.DataTable
            Dim ds As New DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Try
                Dim arParms() As SqlParameter = New SqlParameter(5) {}

                arParms(0) = New SqlParameter("@Deptid", SqlDbType.Int)
                arParms(0).Value = DeptId

                arParms(1) = New SqlParameter("@doj", SqlDbType.DateTime)
                arParms(1).Value = doj

                arParms(2) = New SqlParameter("@dol", SqlDbType.DateTime)
                arParms(2).Value = dol

                arParms(3) = New SqlParameter("@Category", SqlDbType.Int)
                arParms(3).Value = Category

                arParms(4) = New SqlParameter("@insid", SqlDbType.Int)
                arParms(4).Value = insid

                arParms(5) = New SqlParameter("@brnid", SqlDbType.Int)
                arParms(5).Value = brnid

                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetDataByEmp", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
    End Class
End Namespace
Public Class StudentAttendance
    'Dim dt As Data.DataTable
    Dim str As String
    Public Function GetDataByChecking(ByVal CrsId As Int32, ByVal batchno As String, ByVal SubjectId As Int32, ByVal AttdDate As DateTime, ByVal Assessment_ID As Int64) As Boolean
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@CrsId", SqlDbType.Int)
        arParms(2).Value = CrsId
        arParms(3) = New SqlParameter("@batchno", SqlDbType.Int)
        arParms(3).Value = batchno
        arParms(4) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(4).Value = SubjectId
        arParms(5) = New SqlParameter("@AttdDate", SqlDbType.DateTime)
        arParms(5).Value = AttdDate
        arParms(6) = New SqlParameter("@Assessment_ID", SqlDbType.Int)
        arParms(6).Value = Assessment_ID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByChecking_Atten", arParms)

        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function GetDataByCourseDate(ByVal batchno As Int64, ByVal SubjectId As Int32, ByVal monthid As String, ByVal yearid As Int32, ByVal SemsterId As Int64, ByVal AttdDate As DateTime, ByVal Assessment_ID As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If AttdDate = Nothing Then
            Dim arParms() As SqlParameter = New SqlParameter(5) {}
            arParms(0) = New SqlParameter("@monthid", SqlDbType.Int)
            arParms(0).Value = monthid
            arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
            arParms(1).Value = yearid
            arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            arParms(2).Value = batchno
            arParms(3) = New SqlParameter("@Semster_Id", SqlDbType.Int)
            arParms(3).Value = SemsterId
            arParms(4) = New SqlParameter("@SubjectId", SqlDbType.Int)
            arParms(4).Value = SubjectId
            arParms(5) = New SqlParameter("@Assessment_ID", SqlDbType.Int)
            arParms(5).Value = Assessment_ID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByCourseDate_Atten", arParms)

            Return ds.Tables(0)
        Else
            Dim arParms() As SqlParameter = New SqlParameter(4) {}
            arParms(0) = New SqlParameter("@Batch", SqlDbType.Int)
            arParms(0).Value = batchno
            arParms(1) = New SqlParameter("@Semster_Id", SqlDbType.Int)
            arParms(1).Value = SemsterId
            arParms(2) = New SqlParameter("@SubjectId", SqlDbType.Int)
            arParms(2).Value = SubjectId
            arParms(3) = New SqlParameter("@AttDate", SqlDbType.DateTime)
            arParms(3).Value = AttdDate
            arParms(4) = New SqlParameter("@Assessment_ID", SqlDbType.Int)
            arParms(4).Value = Assessment_ID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByCourseDate_AttenBYDate", arParms)
            If ds.Tables(0).Rows(0)("AttdChk") = 0 Then
                ds.Tables(0).Rows.Clear()
            End If
            Return ds.Tables(0)
        End If
    End Function

    Public Function GetDataByStdCode(ByVal batchno As Int64, ByVal StdCode As String, ByVal SemsterId As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@stdCode", SqlDbType.Char, StdCode.Length)
        arParms(0).Value = StdCode
        arParms(1) = New SqlParameter("@batchno", SqlDbType.Int)
        arParms(1).Value = batchno
        arParms(2) = New SqlParameter("@Semster_Id", SqlDbType.Int)
        arParms(2).Value = SemsterId

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByStdCode_Atten", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetDataByStdCodeDate(ByVal batchno As Int64, ByVal StdCode As String, ByVal monthid As Int32, ByVal yearid As Int32, ByVal SemsterId As Int64, ByVal SubjectId As Int64, ByVal attDate As DateTime, ByVal Assessment_ID As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If attDate <> Nothing Then
            Dim arParms() As SqlParameter = New SqlParameter(7) {}
            arParms(0) = New SqlParameter("@stdCode", SqlDbType.Char, StdCode.Length)
            arParms(0).Value = StdCode
            arParms(1) = New SqlParameter("@month", SqlDbType.Int)
            arParms(1).Value = monthid
            arParms(2) = New SqlParameter("@Year", SqlDbType.Int)
            arParms(2).Value = yearid
            arParms(3) = New SqlParameter("@batchno", SqlDbType.Int)
            arParms(3).Value = batchno
            arParms(4) = New SqlParameter("@Semster_Id", SqlDbType.Int)
            arParms(4).Value = SemsterId
            arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
            arParms(5).Value = SubjectId
            arParms(6) = New SqlParameter("@attDate", SqlDbType.DateTime)
            arParms(6).Value = attDate
            arParms(7) = New SqlParameter("@Assessment_ID", SqlDbType.Int)
            arParms(7).Value = Assessment_ID
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByStdCodeDate_Atten_ByDate", arParms)

        Else
            Dim arParms() As SqlParameter = New SqlParameter(6) {}
            arParms(0) = New SqlParameter("@stdCode", SqlDbType.Char, StdCode.Length)
            arParms(0).Value = StdCode
            arParms(1) = New SqlParameter("@month", SqlDbType.Int)
            arParms(1).Value = monthid
            arParms(2) = New SqlParameter("@Year", SqlDbType.Int)
            arParms(2).Value = yearid
            arParms(3) = New SqlParameter("@batchno", SqlDbType.Int)
            arParms(3).Value = batchno
            arParms(4) = New SqlParameter("@Semster_Id", SqlDbType.Int)
            arParms(4).Value = SemsterId
            arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
            arParms(5).Value = SubjectId
            arParms(6) = New SqlParameter("@Assessment_ID", SqlDbType.Int)
            arParms(6).Value = Assessment_ID
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDataByStdCodeDate_Atten", arParms)
        End If
        Return ds.Tables(0)
    End Function
    Public Function GvStdAttendance(ByVal prop As Attendance.StdAttendanceP) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@batchno", SqlDbType.Int)
        arParms.Value = prop.Batch
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetGvStdAttendance", arParms)
        Return ds.Tables(0)
    End Function
    Public Function UpdateStdAttd(ByVal StdId As Int64, ByVal InsId As Int64, ByVal BrnId As Int64, ByVal Courseid As Int64, ByVal SubjectId As Int64, ByVal Month1 As Int64, ByVal Year1 As Int64, ByVal Batch As Int64, ByVal AttendanceDate As DateTime, ByVal id As Int64, ByVal SemesterID As Int64, ByVal Attendance As Boolean, ByVal Assessment_ID As Int32) As Int16
        'Public Function UpdateStdAttd(ByVal id As Int64, ByVal Attendance As Boolean) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Try
            If id <> 0 Then
                Dim arParms() As SqlParameter = New SqlParameter(1) {}
                arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
                arParms(0).Value = id
                arParms(1) = New SqlParameter("@Attendance", SqlDbType.Int)
                arParms(1).Value = Attendance
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateStdAttendance", arParms)
            Else
                Dim arParms() As SqlParameter = New SqlParameter(11) {}

                'arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                'arParms(0).Value = InsId
                arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(0).Value = BrnId
                arParms(1) = New SqlParameter("@CrsId", SqlDbType.Int)
                arParms(1).Value = Courseid
                arParms(2) = New SqlParameter("@batchno", SqlDbType.Int)
                arParms(2).Value = Batch
                arParms(3) = New SqlParameter("@stdCode", SqlDbType.Int)
                arParms(3).Value = StdId
                arParms(4) = New SqlParameter("@SubjectId", SqlDbType.Int)
                arParms(4).Value = SubjectId
                arParms(5) = New SqlParameter("@monthid", SqlDbType.Int)
                arParms(5).Value = Month1
                arParms(6) = New SqlParameter("@Year", SqlDbType.Int)
                arParms(6).Value = Year1
                arParms(7) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
                arParms(7).Value = Today.Date
                arParms(8) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
                arParms(8).Value = AttendanceDate
                arParms(9) = New SqlParameter("@SemesterID", SqlDbType.Int)
                arParms(9).Value = SemesterID
                arParms(10) = New SqlParameter("@Attendance", SqlDbType.Int)
                arParms(10).Value = Attendance
                arParms(11) = New SqlParameter("@Assessment_ID", SqlDbType.Int)
                arParms(11).Value = Assessment_ID
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveStdAttendance", arParms)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function

    Public Function DeletebyStdAttd(ByVal id As Int64) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@ID", SqlDbType.BigInt)
        arParms.Value = id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteStdAttendance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function BatchComboStdAtt(ByVal Batchid As Int64, ByVal AttdDate As DateTime) As System.Data.DataSet
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        arParms(0).Value = AttdDate
        arParms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(1).Value = Batchid

        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetBatchStdAttd", arParms)
        Return ds
    End Function

    Public Function fillCourseBatch(ByVal StdId As Int32) As DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@stdid", SqlDbType.Int)
        arParms(0).Value = StdId

        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetCourseBatch", arParms)
        Return ds.Tables(0)
    End Function
End Class


