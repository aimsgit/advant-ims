Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class BatchDB

    Shared Function GetDtaBatch(ByVal Course_ID As Integer, ByVal StdCode As String) As DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}


        'arParms(0) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, prefixText.Length)
        'arParms(0).Value = prefixText

        'arParms(0) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, prefixText.Length)
        'arParms(0).Value = prefixText

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(2).Value = Course_ID

        arParms(3) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        arParms(3).Value = StdCode
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetBatchExt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Dim dt As New DataTable()
        dt = ds.Tables(0)
        Return dt
    End Function
    Shared Function GetDtaBatch1(ByVal Course_ID As Integer) As DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}


        'arParms(0) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, prefixText.Length)
        'arParms(0).Value = prefixText

        'arParms(0) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, prefixText.Length)
        'arParms(0).Value = prefixText



        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")



        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(2).Value = Course_ID

        'arParms(3) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        'arParms(3).Value = StdCode
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetBatchExt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Dim dt As New DataTable()
        dt = ds.Tables(0)
        Return dt
    End Function
    
    Shared Function GetDtaBatch1(ByVal StdCode As String) As DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}


        'arParms(0) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, prefixText.Length)
        'arParms(0).Value = prefixText

        'arParms(0) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, prefixText.Length)
        'arParms(0).Value = prefixText



        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")




        arParms(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        arParms(2).Value = StdCode
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetYearCombo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Dim dt As New DataTable()
        dt = ds.Tables(0)
        Return dt
    End Function
    Shared Function GetBatchExtForCoursePlanner(ByVal prefixText As String, ByVal insId As Long, ByVal BrnId As Long, ByVal course_id As Long) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Batch_No", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(1).Value = insId

        arParms(2) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(2).Value = BrnId

        arParms(3) = New SqlParameter("@Course_ID", SqlDbType.Int)
        arParms(3).Value = course_id

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetBatchExtForCoursePlanner", arParms)
        Dim dt As New DataTable()
        dt = ds.Tables(0)
        Return dt
    End Function
    'Shared Function GetBatch(ByVal Bid As Long) As System.Data.DataSet
    '    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(connectionstring)
    '    Dim sql As String

    '    If Bid = 0 Then
    '        sql = "Select * from BatchMaster where Del_Flag=0  order by Batch_Name"
    '    Else
    '        sql = "Select BatchMaster.Batch_ID,BatchMaster.Batch_Name from BatchMaster where Del_Flag=0 and Batch_ID=@id order by Batch_Name"
    '    End If

    '    Dim dbcommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
    '    dbcommand.CommandText = sql
    '    dbcommand.Connection = dbConnection

    '    If Not (Bid = 0) Then
    '        Dim dbParam_id As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '        dbParam_id.ParameterName = "@id"
    '        dbParam_id.Value = Bid
    '        dbParam_id.DbType = System.Data.DbType.Int16
    '        dbcommand.Parameters.Add(dbParam_id)
    '    End If

    '    Dim dbadapter As System.Data.IDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
    '    dbadapter.SelectCommand = dbcommand
    '    Dim dataset As System.Data.DataSet = New System.Data.DataSet
    '    dbadapter.Fill(dataset)
    '    Return dataset
    'End Function


    'Shared Function Insert(ByVal B As Batch) As Integer
    '    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(connectionstring)
    '    Dim sql As String

    '    sql = "Insert into BatchMaster(Batch_Name)select @BatchName"

    '    Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
    '    dbConnection.ConnectionString = connectionstring
    '    dbCommand.CommandText = sql
    '    dbCommand.Connection = dbConnection

    '    Dim dbParam_Bname As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter

    '    dbParam_Bname.ParameterName = "@BatchName"
    '    dbParam_Bname.Value = B.BatchName
    '    dbParam_Bname.DbType = System.Data.DbType.String
    '    dbCommand.Parameters.Add(dbParam_Bname)


    '    Dim rowsAffected As Integer = 0
    '    dbConnection.Open()
    '    Try
    '        rowsAffected = dbCommand.ExecuteNonQuery
    '    Finally
    '        dbConnection.Close()
    '    End Try
    '    Return rowsAffected

    'End Function


    'Shared Function Update(ByVal B As Batch) As Integer
    '    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection
    '    Dim dbcommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
    '    Dim sql As String = "UPDATE BatchMaster SET [Batch_Name]=@BatchName  WHERE (((BatchMaster.Batch_ID)=@Bid))"


    '    dbConnection.ConnectionString = connectionstring
    '    dbcommand.CommandText = sql
    '    dbcommand.Connection = dbConnection

    '    Dim dbParam_Bname As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter

    '    dbParam_Bname.ParameterName = "@BatchName"
    '    dbParam_Bname.Value = B.BatchName
    '    dbParam_Bname.DbType = System.Data.DbType.String
    '    dbcommand.Parameters.Add(dbParam_Bname)

    '    Dim dbParam_Bid As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_Bid.ParameterName = "@Bid"
    '    dbParam_Bid.Value = B.BatchID
    '    dbParam_Bid.DbType = System.Data.DbType.[Int64]
    '    dbcommand.Parameters.Add(dbParam_Bid)

    '    Dim rowsAffected As Integer = 0
    '    dbConnection.Open()
    '    Try
    '        rowsAffected = dbcommand.ExecuteNonQuery
    '    Finally
    '        dbConnection.Close()
    '    End Try
    '    Return rowsAffected

    'End Function


    'Shared Function ChangeFlag(ByVal id As Long) As Integer
    '    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbconnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection
    '    Dim dbcommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
    '    Dim sql As String = "Update BatchMaster set [Del_Flag]=-1 where BatchMaster.Batch_ID=@Bid"

    '    dbconnection.ConnectionString = connectionstring

    '    dbcommand.CommandText = sql
    '    dbcommand.Connection = dbconnection

    '    Dim dbParam_id As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_id.ParameterName = "@Bid"
    '    dbParam_id.Value = id
    '    dbParam_id.DbType = System.Data.DbType.Int16
    '    dbcommand.Parameters.Add(dbParam_id)

    '    Dim rowsAffected As Integer = 0
    '    dbconnection.Open()
    '    Try
    '        rowsAffected = dbcommand.ExecuteNonQuery
    '    Finally
    '        dbconnection.Close()
    '    End Try
    '    Return rowsAffected
    'End Function

    'Shared Function BatchCoursePlannerCombo(ByVal id As Long) As System.Data.DataSet
    Shared Function BatchCoursePlannerCombo(ByVal BRid As Int64, ByVal Insid As Int64, ByVal Courseid As Int64) As System.Data.DataSet
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim dbconnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection
        'Dim qryString As String
        'If HttpContext.Current.Session("UserRole") = 1 Then
        '    qryString = "Select Batch_No from DispCourse_CoursePlanner where Course_ID=" & id & " "
        'Else
        '    qryString = "Select Batch_No from DispCourse_CoursePlanner where Course_ID=" & id & " and  Institute_ID=" & HttpContext.Current.Session("sesLoginInstitute") & "  And Branch_ID = " & HttpContext.Current.Session("sesLoginBranch") & "  "
        'End If
        'Dim dbcommand As IDbCommand = New System.Data.OleDb.OleDbCommand
        'dbconnection.ConnectionString = connectionstring
        'dbcommand.CommandText = qryString
        'dbcommand.Connection = dbconnection
        'Dim dataAdapter As IDbDataAdapter = New OleDb.OleDbDataAdapter
        'dataAdapter.SelectCommand = dbcommand
        'Dim dataSet As DataSet = New DataSet
        'dataAdapter.Fill(dataSet)
        'Return dataSet

        Dim ds As DataSet
        'If HttpContext.Current.Session("UserRole") = 1 Then
        '    Dim arParms() As SqlParameter = New SqlParameter(0) {}

        '    arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        '    arParms(0).Value = id
        '    ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_BatchCoursePlannerCombo")
        'Else
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Course_ID", SqlDbType.Int)
        arParms(0).Value = Courseid

        arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(1).Value = Insid

        arParms(2) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(2).Value = BRid

        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetBatchData", arParms)
        'End If
        Return ds
    End Function
    Shared Function BatchCorsePlnnerCombobyCorse(ByVal id As Long) As System.Data.DataSet
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id

        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_BatchCoursePlannerCombo", arParms)

        Return ds
    End Function
    Shared Function GetBatchForTimeTable(ByVal Branch_ID As Int64, ByVal Institute_ID As Int64, ByVal Course_ID As Int64) As System.Data.DataSet
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Course_ID", SqlDbType.Int)
        arParms(0).Value = Course_ID

        arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(1).Value = Institute_ID

        arParms(2) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(2).Value = Branch_ID

        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetBatchForTimeTable", arParms)

        Return ds
    End Function
End Class
