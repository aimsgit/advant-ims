Imports System.Data
Imports System.Data.SqlClient

Namespace GlobalDataSetTableAdapters
    Partial Public Class StudentResultTableAdapter
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
        'Public Function UpdateWithTransaction(ByVal dataTable As GlobalDataSet.StudentResultDataTable) As Integer
        '    Me.BeginTransaction()
        '    Try                ' Perform the update on the DataTable
        '        Dim returnValue As Integer = Me.Adapter.Update(dataTable)
        '        ' If we reach here, no errors, so commit the transaction
        '        Me.CommitTransaction()
        '        Return returnValue
        '    Catch
        '        ' If we reach here, there was an error, so rollback the transaction
        '        Me.RollbackTransaction()
        '        Throw
        '    End Try
        'End Function
        'Private _transaction As OleDbTransaction
        'Private Property Transaction() As OleDbTransaction
        '    Get
        '        Return Me._transaction
        '    End Get
        '    Set(ByVal value As OleDbTransaction)
        '        Me._transaction = value
        '    End Set
        'End Property

        'Public Sub BeginTransaction()
        '    If Me.Connection.State <> ConnectionState.Open Then
        '        Me.Connection.Open()
        '    End If

        '    Me.Transaction = Me.Connection.BeginTransaction()
        '    For Each command As OleDbCommand In Me.CommandCollection
        '        command.Transaction = Me.Transaction
        '    Next
        '    Me.Adapter.InsertCommand.Transaction = Me.Transaction
        '    Me.Adapter.UpdateCommand.Transaction = Me.Transaction
        '    Me.Adapter.DeleteCommand.Transaction = Me.Transaction
        'End Sub

        'Public Sub CommitTransaction()
        '    Me.Transaction.Commit()
        '    Me.Connection.Close()
        'End Sub
        'Public Sub RollbackTransaction()
        '    Me.Transaction.Rollback()
        '    Me.Connection.Close()
        'End Sub
        'Public Function UpdateWithTransaction(ByVal dataTable As GlobalDataSet.StudentResultDataTable) As Integer
        '    Me.BeginTransaction()
        '    Try
        '        Dim returnValue As Integer = Me.Adapter.Update(dataTable)
        '        Me.CommitTransaction()
        '        Return returnValue
        '    Catch
        '        Me.RollbackTransaction()
        '        Throw
        '    End Try
        'End Function
    End Class
End Namespace
Public Class StudentResultD
    Dim Sql As String
    Sub New()

    End Sub
    Public Function GetStudent(ByVal Prop As StudentResult.StudentResultP, ByVal ChkArrear As Boolean) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(0).Value = Prop.Subjectid

        arParms(1) = New SqlParameter("@Semster", SqlDbType.Int)
        arParms(1).Value = Prop.SemesterId

        arParms(2) = New SqlParameter("@Assessment", SqlDbType.Int)
        arParms(2).Value = Prop.AssessmentId

        arParms(3) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(3).Value = Prop.BatchNo

        arParms(4) = New SqlParameter("@Subject1", SqlDbType.Int)
        arParms(4).Value = Prop.Subjectid

        arParms(5) = New SqlParameter("@Batch1", SqlDbType.Int)
        arParms(5).Value = Prop.BatchNo
        If ChkArrear = True Then
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStudentResult_full", arParms)
        Else
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStudentResult", arParms)
        End If
        Return ds.Tables(0)
    End Function
    Public Function FillGrid(ByVal Prop As StudentResult.StudentResultP) As Data.DataTable
        'Public Function FillGrid(ByVal Prop As StudentResultP) As Data.DataTable
        'Dim DT As New Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim Cmd As New OleDb.OleDbCommand
        'Dim Connecton As New OleDb.OleDbConnection(ConnectionString)
        'Dim DA As OleDb.OleDbDataAdapter
        'Sql = "SELECT StudentResult.ResultID, StudentMaster.StdId, StudentMaster.StdName, StudentMaster.StdCode, StudentResult.Marks,  StudentResult.Skill, StudentResult.Max_Mark, StudentResult.AssessmentType " & _
        '"FROM ((StudentResult LEFT JOIN StudentMaster ON StudentResult.StdCode = StudentMaster.StdId) LEFT JOIN CourseMaster ON StudentResult.Course_ID = CourseMaster.Course_ID) LEFT JOIN SubjectMaster " & _
        '"ON StudentResult.Subject_ID = SubjectMaster.Subject_ID " & _
        '"WHERE (((StudentResult.Marks) Is Not Null) AND ((CourseMaster.Course_ID)=[@Course]) AND ((StudentResult.SemesterType)=[@Semster]) AND ((SubjectMaster.Subject_ID)=[@Subject]) AND ((StudentResult.Batch_No)=[@Batch]) AND ((StudentMaster.Branch_ID)=[@Brn]) AND ((StudentMaster.Institute_ID)=[@Ins]) AND ((StudentResult.Del_Flag)=0) AND ((StudentResult.AssessmentType)=[@assessment]))"


        'Dim Param_Course As New OleDb.OleDbParameter
        'Param_Course.Value = Prop.CourseId
        'Param_Course.ParameterName = "@Course"
        'Param_Course.DbType = DbType.Int64
        'Cmd.Parameters.Add(Param_Course)

        'Dim Param_Semster As New OleDb.OleDbParameter
        'Param_Semster.Value = Prop.SemesterId
        'Param_Semster.ParameterName = "@Semster"
        'Param_Semster.DbType = DbType.Int64
        'Cmd.Parameters.Add(Param_Semster)

        'Dim Param_Subject As New OleDb.OleDbParameter
        'Param_Subject.Value = Prop.Subjectid
        'Param_Subject.ParameterName = "@Subject"
        'Param_Subject.DbType = DbType.Int64
        'Cmd.Parameters.Add(Param_Subject)

        'Dim Param_Batch As New OleDb.OleDbParameter
        'Param_Batch.Value = Prop.BatchNo
        'Param_Batch.ParameterName = "@Batch"
        'Param_Batch.DbType = DbType.Int64
        'Cmd.Parameters.Add(Param_Batch)

        'Dim Param_Branch As New OleDb.OleDbParameter
        'Param_Branch.Value = Prop.BranchId
        'Param_Branch.ParameterName = "@Brn"
        'Param_Branch.DbType = DbType.Int64
        'Cmd.Parameters.Add(Param_Branch)

        'Dim Param_Ins As New OleDb.OleDbParameter
        'Param_Ins.Value = Prop.InstituteId
        'Param_Ins.ParameterName = "@Ins"
        'Param_Ins.DbType = DbType.Int64
        'Cmd.Parameters.Add(Param_Ins)

        'Dim Param_Assessment As New OleDb.OleDbParameter
        'Param_Assessment.Value = Prop.AssessmentId
        'Param_Assessment.ParameterName = "@Assessment"
        'Param_Assessment.DbType = DbType.Int64
        'Cmd.Parameters.Add(Param_Assessment)


        'Cmd.CommandType = CommandType.Text
        'Cmd.CommandText = Sql
        'Cmd.Connection = Connecton
        'DA = New OleDb.OleDbDataAdapter(Cmd)
        'Connecton.Open()
        'DA.Fill(DT)
        'Connecton.Close()

        'Return DT
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(0).Value = Prop.CourseId

        arParms(1) = New SqlParameter("@Semster", SqlDbType.Int)
        arParms(1).Value = Prop.SemesterId

        arParms(2) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(2).Value = Prop.Subjectid

        arParms(3) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(3).Value = Prop.BatchNo

        arParms(4) = New SqlParameter("@Brn", SqlDbType.Int)
        arParms(4).Value = Prop.BranchId

        arParms(5) = New SqlParameter("@Ins", SqlDbType.Int)
        arParms(5).Value = Prop.InstituteId

        arParms(6) = New SqlParameter("@Assessment", SqlDbType.Int)
        arParms(6).Value = Prop.AssessmentId

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_StudentResultGridFill", arParms)
        Return ds.Tables(0)
    End Function
    'Public Sub UpdateDel(ByVal i As Int64)
    Public Function UpdateDel(ByVal i As Int64) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        'Dim Cmd As New OleDb.OleDbCommand
        'Dim Connecton As New OleDb.OleDbConnection(ConnectionString)

        'Sql = "Update StudentResult set Del_Flag=-1 where ResultID=@Id"

        'Dim Param_id As New OleDb.OleDbParameter
        'Param_id.Value = i
        'Param_id.ParameterName = "@Id"
        'Param_id.DbType = DbType.Int64
        'Cmd.Parameters.Add(Param_id)

        'Cmd.CommandType = CommandType.Text
        'Cmd.CommandText = Sql
        'Cmd.Connection = Connecton

        'Connecton.Open()
        'Cmd.ExecuteNonQuery()
        'Connecton.Close()
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = i

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_DeleteStudentResult", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    'Public Function Update(ByVal Prop As StudentResult.StudentResultP)
    '    'Public Function Update(ByVal Prop As StudentResultP) As Integer
    '    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim rowsAffected As Integer = 0
    '    'Dim Cmd As New OleDb.OleDbCommand
    '    'Dim Connecton As New OleDb.OleDbConnection(ConnectionString)

    '    'Sql = "Update StudentResult set StdCode=@StdId,Marks=@Marks, Skill=@Skill where ResultID=@Id"

    '    'Dim Param_Stdid As New OleDb.OleDbParameter
    '    'Param_Stdid.Value = Prop.StdCode
    '    'Param_Stdid.ParameterName = "@StdId"
    '    'Param_Stdid.DbType = DbType.Int64
    '    'Cmd.Parameters.Add(Param_Stdid)

    '    'Dim Param_Mark As New OleDb.OleDbParameter
    '    'Param_Mark.Value = Prop.marks
    '    'Param_Mark.ParameterName = "@Marks"
    '    'Param_Mark.DbType = DbType.String
    '    'Cmd.Parameters.Add(Param_Mark)

    '    'Dim Param_id As New OleDb.OleDbParameter
    '    'Param_id.Value = Prop.ReusltId
    '    'Param_id.ParameterName = "@Id"
    '    'Param_id.DbType = DbType.Int64
    '    'Cmd.Parameters.Add(Param_id)

    '    'Cmd.CommandType = CommandType.Text
    '    'Cmd.CommandText = Sql
    '    'Cmd.Connection = Connecton

    '    'Connecton.Open()
    '    'Cmd.ExecuteNonQuery()
    '    'Connecton.Close()

    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}

    '    arParms(0) = New SqlParameter("@StdId", SqlDbType.Int)
    '    arParms(0).Value = Prop.StdCode

    '    arParms(1) = New SqlParameter("@Marks", SqlDbType.Float)
    '    arParms(1).Value = Prop.marks

    '    arParms(2) = New SqlParameter("@Skill", SqlDbType.Int)
    '    arParms(2).Value = Prop.Skill

    '    arParms(3) = New SqlParameter("@Id", SqlDbType.Int)
    '    arParms(3).Value = Prop.ReusltId

    '    Try
    '        rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_UpdateStudentResult", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    '    Return rowsAffected
    'End Function
    Public Function GetStdCode(ByVal ins As Int64, ByVal brn As Int64, ByVal crs As Int64, ByVal btch As Int64) As Data.DataTable
        'Dim DT As New Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim Cmd As New OleDb.OleDbCommand
        'Dim Connecton As New OleDb.OleDbConnection(ConnectionString)
        'Dim DA As OleDb.OleDbDataAdapter

        'Sql = "Select StdId,StdCode from StudentMaster where  Institute_ID=@Ins and  Branch_ID=@Brn and Course_ID=@Crs and Batch_No=@btch"


        'Dim dbParam_instituteid As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_instituteid.ParameterName = "@Ins"
        'dbParam_instituteid.Value = ins
        'dbParam_instituteid.DbType = System.Data.DbType.[Int64]
        'Cmd.Parameters.Add(dbParam_instituteid)


        'Dim dbParam_branchid As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_branchid.ParameterName = "@Brn"
        'dbParam_branchid.Value = brn
        'dbParam_branchid.DbType = System.Data.DbType.[Int64]
        'Cmd.Parameters.Add(dbParam_branchid)

        'Dim dbParam_courseid As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_courseid.ParameterName = "@Crs"
        'dbParam_courseid.Value = crs
        'dbParam_courseid.DbType = System.Data.DbType.[Int64]
        'Cmd.Parameters.Add(dbParam_courseid)

        'Dim dbParam_Batch As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
        'dbParam_Batch.ParameterName = "@btch"
        'dbParam_Batch.Value = btch
        'dbParam_Batch.DbType = System.Data.DbType.[Int64]
        'Cmd.Parameters.Add(dbParam_Batch)

        'Cmd.CommandType = CommandType.Text
        'Cmd.CommandText = Sql
        'Cmd.Connection = Connecton
        'DA = New OleDb.OleDbDataAdapter(Cmd)
        'Connecton.Open()
        'DA.Fill(DT)
        'Connecton.Close()
        'Return DT

        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Ins", SqlDbType.Int)
        arParms(0).Value = ins

        arParms(1) = New SqlParameter("@Brn", SqlDbType.Int)
        arParms(1).Value = brn

        arParms(2) = New SqlParameter("@Crs", SqlDbType.Int)
        arParms(2).Value = crs

        arParms(3) = New SqlParameter("@btch", SqlDbType.Int)
        arParms(3).Value = btch

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStdCode", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetstdEligible(ByVal batchno As Int64, ByVal insid As Int64, ByVal brnid As Int64, ByVal crsid As Int64) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Ins", SqlDbType.Int)
        arParms(0).Value = insid

        arParms(1) = New SqlParameter("@Brn", SqlDbType.Int)
        arParms(1).Value = brnid

        arParms(2) = New SqlParameter("@Crs", SqlDbType.Int)
        arParms(2).Value = crsid

        arParms(3) = New SqlParameter("@btch", SqlDbType.Int)
        arParms(3).Value = batchno

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetstdEligible", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetstdEligibleRpt(ByVal insid As Int64, ByVal brnid As Int64, ByVal crsid As Int64, ByVal batchno As Int64) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Ins", SqlDbType.Int)
        arParms(0).Value = insid

        arParms(1) = New SqlParameter("@Brn", SqlDbType.Int)
        arParms(1).Value = brnid

        arParms(2) = New SqlParameter("@Crs", SqlDbType.Int)
        arParms(2).Value = crsid

        arParms(3) = New SqlParameter("@btch", SqlDbType.Int)
        arParms(3).Value = batchno

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetstdEligibleRpt", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetBatchData(ByVal Institute_ID As Int64, ByVal Branch_ID As Int64, ByVal Course_ID As Int64) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = Institute_ID

        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = Branch_ID

        arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
        arParms(2).Value = Course_ID

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetBatchData", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetStudentReportCombo(ByVal BatchID As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = BatchID

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchByStdCode", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetSemesterByStdCode(ByVal StdId As Int32) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@Stdcode", SqlDbType.Int)
        arParms.Value = StdId
        'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSemesterByStudentCode", arParms)
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSemesterByStdCode", arParms)
        Return ds.Tables(0)
    End Function


    Public Function GetResultByStdCode(ByVal BranchCode As String, ByVal StdId As Integer, ByVal batch As Integer, ByVal sem As Integer, ByVal ass As Integer, ByVal ClassType As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode
        arParms(1) = New SqlParameter("@STDID", SqlDbType.Int)
        arParms(1).Value = StdId

        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = batch

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = sem

        arParms(4) = New SqlParameter("@AssessmentType", SqlDbType.Int)
        arParms(4).Value = ass

        arParms(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        arParms(5).Value = ClassType

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StdSemesterResult", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetStdPerformance(ByVal Institute As Integer, ByVal Branch As Integer, ByVal course As Integer, ByVal batch As Integer, ByVal Subject As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Institute", SqlDbType.Int)
        arParms(0).Value = Institute

        arParms(1) = New SqlParameter("@Branch", SqlDbType.Int)
        arParms(1).Value = Branch

        arParms(2) = New SqlParameter("@course", SqlDbType.Int)
        arParms(2).Value = course

        arParms(3) = New SqlParameter("@batch", SqlDbType.Int)
        arParms(3).Value = batch

        arParms(4) = New SqlParameter("@subjectid", SqlDbType.Int)
        arParms(4).Value = Subject

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Rpt_StdPerformanceSubjtWise", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertSem() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectSemester", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function getass() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectAssesmentRPT", arParms)
        Return ds.Tables(0)
    End Function
End Class


