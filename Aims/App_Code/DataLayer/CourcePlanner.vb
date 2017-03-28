Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace GlobalDataSetTableAdapters
    'Partial Class CoursePlannerSubjectTableAdapter
    '    Private _transaction As SqlTransaction
    '    Public Property Transaction() As SqlTransaction
    '        Get
    '            Return Me._transaction
    '        End Get
    '        Set(ByVal value As SqlTransaction)
    '            Me._transaction = value
    '        End Set
    '    End Property
    '    Public Sub BeginTransaction()
    '        If Me.Connection.State <> ConnectionState.Open Then
    '            Me.Connection.Open()
    '        End If
    '        Me.Transaction = Me.Connection.BeginTransaction
    '        For Each Command As SqlCommand In Me.CommandCollection
    '            Command.Transaction = Me.Transaction
    '        Next
    '        Me.Adapter.InsertCommand.Transaction = Me.Transaction
    '        Me.Adapter.UpdateCommand.Transaction = Me.Transaction
    '        Me.Adapter.DeleteCommand.Transaction = Me.Transaction
    '    End Sub
    '    Public Sub CommitTransaction()
    '        Me.Transaction.Commit()
    '        Me.Connection.Close()
    '    End Sub
    '    Public Sub RollbackTransaction()
    '        Me.Transaction.Rollback()
    '        Me.Connection.Close()
    '    End Sub
    '    Public Function UpdateWithTransaction(ByVal dataTable As GlobalDataSet.CoursePlannerSubjectDataTable) As Integer
    '        Me.BeginTransaction()
    '        Try
    '            Dim RetrunValue As Int16 = Me.Adapter.Update(dataTable)
    '            Me.CommitTransaction()
    '            Me.Connection.Close()
    '        Catch ex As Exception
    '            Me.RollbackTransaction()
    '            Throw
    '        End Try
    '    End Function
    'End Class

    Public Class CoursePlannerDB
        Dim Str As String
        Dim Dt As Data.DataTable
        Dim DA As OleDb.OleDbDataAdapter
        Public Function GetData(ByVal ID As Int64) As Data.DataTable
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms As SqlParameter = New SqlParameter
            Dim ds As New DataSet

            arParms = New SqlParameter("@ID", SqlDbType.Int)
            arParms.Value = ID

            Try
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_getDatacourcePlannerByID", arParms)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return ds.Tables(0)

        End Function
        'Public Function GetDataCPID(ByVal BranchId As Int64, ByVal InsId As Int64, ByVal Courseid As Int64, ByVal batch As Int64) As Data.DataTable
        '    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        '    Dim DBConnection As Data.IDbConnection = New Data.OleDb.OleDbConnection(ConnectionString)
        '    Dim DBCommand As Data.IDbCommand = New Data.OleDb.OleDbCommand

        '    Str = "SELECT ID, Date_Commenecement, Date_Completion, FinalExam_date,Tentative_Result_Date, No_Session FROM CoursePlanner WHERE ((Course_ID =@Course) And (Branch_ID = @Branch) And (Institute_ID =@ins) And (Batch_No =@Batch) And (Del_flag = 0))"

        '    DBCommand.CommandText = Str
        '    DBCommand.Connection = DBConnection

        '    Dim DbParramCourse As New OleDb.OleDbParameter
        '    DbParramCourse.DbType = DbType.Int64
        '    DbParramCourse.Value = Courseid
        '    DbParramCourse.ParameterName = "@Course"
        '    DBCommand.Parameters.Add(DbParramCourse)

        '    Dim dbparramBranch As New OleDb.OleDbParameter
        '    dbparramBranch.DbType = DbType.Int64
        '    dbparramBranch.Value = BranchId
        '    dbparramBranch.ParameterName = "@Branch"
        '    DBCommand.Parameters.Add(dbparramBranch)

        '    Dim dbparramIns As New OleDb.OleDbParameter
        '    dbparramIns.DbType = DbType.Int64
        '    dbparramIns.Value = InsId
        '    dbparramIns.ParameterName = "@ins"
        '    DBCommand.Parameters.Add(dbparramIns)

        '    Dim dbparramBatch As New OleDb.OleDbParameter
        '    dbparramBatch.DbType = DbType.Int64
        '    dbparramBatch.Value = batch
        '    dbparramBatch.ParameterName = "@Batch"
        '    DBCommand.Parameters.Add(dbparramBatch)

        '    DBConnection.Open()
        '    DA = New OleDb.OleDbDataAdapter(DBCommand)
        '    Dt = New Data.DataTable
        '    DA.Fill(Dt)
        '    DBConnection.Close()
        '    Return Dt
        'End Function
       
        Public Function GetBatchAvail(ByVal BranchId As Int64, ByVal InsId As Int64, ByVal Courseid As Int64, ByVal batch As String) As Boolean
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(4) {}
          
            arParms(0) = New SqlParameter("@ins", SqlDbType.Int)
            arParms(0).Value = InsId

            arParms(1) = New SqlParameter("@brn", SqlDbType.Int)
            arParms(1).Value = BranchId

            arParms(2) = New SqlParameter("@crs", SqlDbType.Int)
            arParms(2).Value = Courseid

            arParms(3) = New SqlParameter("@batch_no", SqlDbType.VarChar)
            arParms(3).Value = batch

            arParms(4) = New SqlParameter("@status", SqlDbType.Bit)
            arParms(4).Direction = ParameterDirection.Output
            Try
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_getCheckBatchnoAvailable", arParms)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return arParms(4).Value
        End Function
        Public Function GetBatch(ByVal BranchId As Int64, ByVal InsId As Int64, ByVal Courseid As Int64) As DataTable
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(0).Value = InsId

            arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(1).Value = BranchId

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = Courseid
           
            Try
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetBatchForCoursePlanner", arParms)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return ds.Tables(0)
        End Function
        Public Function GetDataForGV(ByVal BranchId As Int64, ByVal InsId As Int64, ByVal Courseid As Int64) As DataTable
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(0).Value = InsId

            arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(1).Value = BranchId

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = Courseid

            Try
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetCourcePlannerDetailsforGV", arParms)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return ds.Tables(0)
        End Function
        Public Function GetCoursePlannerRpt(ByVal Courseid As Long, ByVal InsId As Long, ByVal BranchId As Long) As DataTable
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(0).Value = InsId

            arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(1).Value = BranchId

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = Courseid

            Try
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_CoursePlannerRpt", arParms)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return ds.Tables(0)
        End Function


        Public Function UpdateCp(ByVal Prop As CourcePlanner.CoursePlannerP) As Int16
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim Id As Int64

            Dim arParms() As SqlParameter = New SqlParameter(13) {}

            arParms(0) = New SqlParameter("@C_Duration", SqlDbType.Int)
            arParms(0).Value = Prop.CourseDuration

            arParms(1) = New SqlParameter("@C_Remarks", SqlDbType.VarChar, Prop.DurationRemarks.Length)
            arParms(1).Value = Prop.DurationRemarks

            arParms(2) = New SqlParameter("@Final_Exam_Date", SqlDbType.DateTime)
            arParms(2).Value = Prop.FinalExamDate

            arParms(3) = New SqlParameter("@Date_Commencement", SqlDbType.DateTime)
            arParms(3).Value = Prop.DateCommencement

            arParms(4) = New SqlParameter("@Date_Completion", SqlDbType.DateTime)
            arParms(4).Value = Prop.DateCompletion

            arParms(5) = New SqlParameter("@Tentative_Result_Date", SqlDbType.DateTime)
            arParms(5).Value = Prop.ResultOn

            arParms(6) = New SqlParameter("@Number_Days", SqlDbType.Int)
            arParms(6).Value = Prop.NoDays

            arParms(7) = New SqlParameter("@Number_Holidays", SqlDbType.Int)
            arParms(7).Value = Prop.NoHolidays

            arParms(8) = New SqlParameter("@Number_Working_Days", SqlDbType.Int)
            arParms(8).Value = Prop.NoWorkingDays

            arParms(9) = New SqlParameter("@Exam_Days", SqlDbType.Int)
            arParms(9).Value = Prop.ExamDays

            arParms(10) = New SqlParameter("@SessionPerDay", SqlDbType.Int)
            arParms(10).Value = Prop.SessionPerDay

            arParms(11) = New SqlParameter("@Session_Allotment", SqlDbType.VarChar, Prop.SessionAllotment.Length)
            arParms(11).Value = Prop.SessionAllotment

            arParms(12) = New SqlParameter("@coordinator", SqlDbType.VarChar, Prop.Coordinator.Length)
            arParms(12).Value = Prop.Coordinator

            arParms(13) = New SqlParameter("@ID", SqlDbType.Int)
            arParms(13).Value = Prop.ID


            Try
                Id = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_SaveCourcePlanner", arParms)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try
            Return Id
        End Function
        Public Function GetSelectCourse(ByVal Branch_ID As Int64, ByVal Ins_ID As Int64) As Data.DataTable
            'Dim dt As New Data.DataTable
            'Dim DbCommand As Data.IDbCommand = New Data.OleDb.OleDbCommand
            'Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
            'Dim DbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(ConnectionString)
            ''Str = "Select  DISTINCT CourseMaster.CourseName,CourseMaster.Course_ID From CourseMaster Right Join CoursePlanner ON CourseMaster.Course_ID=CoursePlanner.Course_ID Where (CoursePlanner.Institute_ID=@insID) AND (CoursePlanner.Branch_ID=@branchId) and  (CoursePlanner.Del_flag=0)"
            'Str = "SELECT DISTINCT [CourseCode] & ' ' & [CourseName] AS CourseName, CourseMaster.Course_ID FROM CourseMaster RIGHT JOIN CoursePlanner ON CourseMaster.Course_ID = CoursePlanner.Course_ID WHERE (((CoursePlanner.Institute_ID)=[@insID]) AND ((CoursePlanner.Branch_ID)=[@branchId]) AND ((CoursePlanner.Del_flag)=0))"

            'DbCommand.CommandText = Str
            'DbCommand.Connection = DbConnection

            'Dim DbParam_insID As Data.IDbDataParameter = New Data.OleDb.OleDbParameter
            'DbParam_insID.DbType = DbType.Int64
            'DbParam_insID.Value = Ins_ID
            'DbParam_insID.ParameterName = "@insID"
            'DbCommand.Parameters.Add(DbParam_insID)

            'Dim DbParam_branch_ID As Data.IDbDataParameter = New Data.OleDb.OleDbParameter
            'DbParam_branch_ID.Value = Branch_ID
            'DbParam_branch_ID.DbType = DbType.Int64
            'DbParam_branch_ID.ParameterName = "@branchId"
            'DbCommand.Parameters.Add(DbParam_branch_ID)

            'DbConnection.Open()
            'DA = New OleDb.OleDbDataAdapter(DbCommand)
            'DA.Fill(dt)
            'DbConnection.Close()
            'Return dt
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

            arParms(0) = New SqlClient.SqlParameter("@insID", SqlDbType.Int)
            arParms(0).Value = Ins_ID

            arParms(1) = New SqlClient.SqlParameter("@branchId", SqlDbType.Int)
            arParms(1).Value = Branch_ID

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetSelectCourse", arParms)
            Return ds.Tables(0)
        End Function
        Public Function Delete(ByVal Id As Int64) As Int16
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms As SqlParameter = New SqlParameter
            Dim idd As Int32

            arParms = New SqlParameter("@ID", SqlDbType.Int)
            arParms.Value = Id

            Try
                idd = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_DeleteSubjectByCp", arParms)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return idd
        End Function
        Public Function DELUpdate(ByVal Id As Int64) As Int16
            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms As SqlParameter = New SqlParameter
            Dim idd As Int32

            arParms = New SqlParameter("@ID", SqlDbType.Int)
            arParms.Value = Id

            Try
                idd = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_DeleteCourcePlanner", arParms)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return idd
        End Function
    End Class
End Namespace

