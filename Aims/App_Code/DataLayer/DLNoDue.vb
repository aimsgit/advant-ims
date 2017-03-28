Imports System.Data
Imports System.Data.SqlClient
Imports EntNoDue
Namespace GlobalDataSetTableAdapters
    Partial Public Class DLNoDue
        Dim ds As New dataset
        Function GetNoDue(ByVal batch As String, ByVal cource As Int64) As System.Data.DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            'arParms(1) = New SqlParameter("@institute", SqlDbType.Int)
            'arParms(1).Value = HttpContext.Current.Session("InstituteID")

            'arParms(2) = New SqlParameter("@branch", SqlDbType.Int)
            'arParms(2).Value = HttpContext.Current.Session("BranchID")
            '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
            '    Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(connectionString)
            '    Dim queryString As String

            '    If NoDueid = 0 Then
            '        queryString = "SELECT NoDues.Due_ID, NoDues.Institute_ID, NoDues.Branch_ID, NoDues.Course_ID, NoDues.Batch_No, NoDues.Dept_ID,NoDues.StdId,NoDues.Performance,NoDues.Remarks FROM(NoDues)WHERE (((NoDues.Del_Flag)=0)AND ((NoDues.Institute_ID)=@institute) AND ((NoDues.Branch_ID)=@branch))"
            '    ElseIf (NoDueid <> 0) Then
            '        queryString = "SELECT NoDues.Due_ID, NoDues.Institute_ID, NoDues.Branch_ID, NoDues.Course_ID, NoDues.Batch_No, NoDues.Dept_ID,NoDues.StdId,NoDues.Performance,NoDues.Remarks FROM(NoDues)WHERE (((NoDues.Due_ID)=@id) AND ((NoDues.Del_Flag)=0))"
            '    Else
            '        queryString = "SELECT NoDues.Due_ID, NoDues.Institute_ID, NoDues.Branch_ID, NoDues.Course_ID, NoDues.Batch_No, NoDues.Dept_ID,NoDues.StdId,NoDues.Performance,NoDues.Remarks FROM(NoDues)WHERE (((NoDues.Del_Flag)=0))"
            '    End If
            '    Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
            '    dbCommand.CommandText = queryString
            '    dbCommand.Connection = dbConnection
            '    If (NoDueid <> 0) Then
            '        Dim dbParam_id As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            '        dbParam_id.ParameterName = "@dueid"
            '        dbParam_id.Value = NoDueid
            '        dbParam_id.DbType = System.Data.DbType.Int64
            '        dbCommand.Parameters.Add(dbParam_id)
            '    ElseIf (NoDueid = 0) Then
            '        Dim dbParam_institute As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            '        dbParam_institute.ParameterName = "@institute"
            '        dbParam_institute.Value = Inst
            '        dbParam_institute.DbType = System.Data.DbType.Int64
            '        dbCommand.Parameters.Add(dbParam_institute)

            '        Dim dbParam_branch As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            '        dbParam_branch.ParameterName = "@branch"
            '        dbParam_branch.Value = branch
            '        dbParam_branch.DbType = System.Data.DbType.Int64
            '        dbCommand.Parameters.Add(dbParam_branch)
            '    End If
            '    Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
            '    dataAdapter.SelectCommand = dbCommand
            '    Dim dataSet As System.Data.DataSet = New System.Data.DataSet
            '    dataAdapter.Fill(dataSet)
            '    Return dataSet
            Dim arParms() As SqlParameter = New SqlParameter(3) {}
            arParms(0) = New SqlParameter("@batch", SqlDbType.VarChar, 50)
            arParms(0).Value = batch

            arParms(1) = New SqlParameter("@institute", SqlDbType.Int)
            arParms(1).Value = HttpContext.Current.Session("InstituteID")

            arParms(2) = New SqlParameter("@branch", SqlDbType.Int)
            arParms(2).Value = HttpContext.Current.Session("BranchID")

            arParms(3) = New SqlParameter("@cource", SqlDbType.Int, 50)
            arParms(3).Value = cource



            ds.Clear()
            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * from NoDues where Del_Flag=0 and Branch_ID= @branch and Institute_ID= @institute and Course_ID=@cource and Batch_No=@batch", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        Shared Function Insert(ByVal ND As EntNoDue.EntNoDue) As Integer
            'Dim connectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
            'Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection
            'Dim querystring As String = "INSERT INTO NoDues(Institute_ID,Branch_ID,Course_ID,Batch_No,Dept_ID,StdId,Performance,Remarks)SELECT @institute,@branch,@course,@batchno,@deptid,@stdid,@performance,@remarks"

            'Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
            'dbConnection.ConnectionString = connectionString
            'dbCommand.CommandText = querystring
            'dbCommand.Connection = dbConnection

            'Dim dbParam_institute As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_institute.ParameterName = "@institute"
            'dbParam_institute.Value = ND.Institute
            'dbParam_institute.DbType = System.Data.DbType.Int64
            'dbCommand.Parameters.Add(dbParam_institute)

            'Dim dbParam_branch As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_branch.ParameterName = "@branch"
            'dbParam_branch.Value = ND.Branch
            'dbParam_branch.DbType = System.Data.DbType.Int64
            'dbCommand.Parameters.Add(dbParam_branch)

            'Dim dbParam_course As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_course.ParameterName = "@course"
            'dbParam_course.Value = ND.Course
            'dbParam_course.DbType = System.Data.DbType.Int64
            'dbCommand.Parameters.Add(dbParam_course)

            'Dim dbParam_batchno As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_batchno.ParameterName = "@batchno"
            'dbParam_batchno.Value = ND.BatchNo
            'dbParam_batchno.DbType = System.Data.DbType.String
            'dbCommand.Parameters.Add(dbParam_batchno)

            'Dim dbParam_dept As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_dept.ParameterName = "@deptid"
            'dbParam_dept.Value = ND.DeptId
            'dbParam_dept.DbType = System.Data.DbType.Int64
            'dbCommand.Parameters.Add(dbParam_dept)

            'Dim dbParam_std As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_std.ParameterName = "@stdid"
            'dbParam_std.Value = ND.StdId
            'dbParam_std.DbType = System.Data.DbType.Int64
            'dbCommand.Parameters.Add(dbParam_std)

            'Dim dbParam_performance As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_performance.ParameterName = "@performance"
            'dbParam_performance.Value = ND.Performance
            'dbParam_performance.DbType = System.Data.DbType.[String]
            'dbCommand.Parameters.Add(dbParam_performance)

            'Dim dbParam_remarks As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_remarks.ParameterName = "@remarks"
            'dbParam_remarks.Value = ND.Remarks
            'dbParam_remarks.DbType = System.Data.DbType.[String]
            'dbCommand.Parameters.Add(dbParam_remarks)

            'Dim rowsAffected As Integer = 0
            'dbConnection.Open()
            'Try
            '    rowsAffected = dbCommand.ExecuteNonQuery
            'Finally
            '    dbConnection.Close()
            'End Try
            'Return rowsAffected
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(7) {}
            Dim rowsAffected As Integer = 0
            'arParms(0) = New SqlParameter("@institute", SqlDbType.Int, 50)
            'arParms(0).Value = ND.Institute

            'arParms(1) = New SqlParameter("@branch", SqlDbType.Int, 50)
            'arParms(1).Value = ND.Branch

            arParms(0) = New SqlParameter("@institute", SqlDbType.Int)
            arParms(0).Value = HttpContext.Current.Session("InstituteID")

            arParms(1) = New SqlParameter("@branch", SqlDbType.Int)
            arParms(1).Value = HttpContext.Current.Session("BranchID")

            arParms(2) = New SqlParameter("@course", SqlDbType.Int, 100)
            arParms(2).Value = ND.Course

            arParms(3) = New SqlParameter("@batchno", SqlDbType.VarChar, 50)
            arParms(3).Value = ND.BatchNo

            arParms(4) = New SqlParameter("@deptid", SqlDbType.Int, 50)
            arParms(4).Value = ND.DeptId

            arParms(5) = New SqlParameter("@stdid", SqlDbType.Int, 50)
            arParms(5).Value = ND.StdId

            arParms(6) = New SqlParameter("@performance", SqlDbType.VarChar, 50)
            arParms(6).Value = ND.Performance

            arParms(7) = New SqlParameter("@remarks", SqlDbType.VarChar, 50)
            arParms(7).Value = ND.Remarks
            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertNoDueRecord", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Function
        Public Function Update(ByVal ND As EntNoDue.EntNoDue) As Integer

            'Dim dt As New Data.DataTable
            'Dim DbCommand As Data.IDbCommand = New Data.OleDb.OleDbCommand
            'Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
            'Dim DbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(ConnectionString)
            'Dim Str As String = "Update NoDues set Institute_ID=@institute,Branch_ID=@branch,Course_ID=@course,Batch_No=@batchno,Dept_ID=@deptid,StdId=@stdid,Performance=@performance,Remarks=@remarks WHERE Due_ID=@dueid"

            'Dim dbParam_institute As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_institute.ParameterName = "@institute"
            'dbParam_institute.Value = ND.Institute
            'dbParam_institute.DbType = System.Data.DbType.Int64
            'DbCommand.Parameters.Add(dbParam_institute)

            'Dim dbParam_branch As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_branch.ParameterName = "@branch"
            'dbParam_branch.Value = ND.Branch
            'dbParam_branch.DbType = System.Data.DbType.Int64
            'DbCommand.Parameters.Add(dbParam_branch)

            'Dim dbParam_course As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_course.ParameterName = "@course"
            'dbParam_course.Value = ND.Course
            'dbParam_course.DbType = System.Data.DbType.Int64
            'DbCommand.Parameters.Add(dbParam_course)

            'Dim dbParam_batch As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_batch.ParameterName = "@batchno"
            'dbParam_batch.Value = ND.BatchNo
            'dbParam_batch.DbType = System.Data.DbType.String
            'DbCommand.Parameters.Add(dbParam_batch)

            'Dim dbParam_dept As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_dept.ParameterName = "@deptid"
            'dbParam_dept.Value = ND.DeptId
            'dbParam_dept.DbType = System.Data.DbType.Int64
            'DbCommand.Parameters.Add(dbParam_dept)

            'Dim dbParam_stdid As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_stdid.ParameterName = "@stdid"
            'dbParam_stdid.Value = ND.StdId
            'dbParam_stdid.DbType = System.Data.DbType.Int64
            'DbCommand.Parameters.Add(dbParam_stdid)

            'Dim dbParam_performance As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_performance.ParameterName = "@performance"
            'dbParam_performance.Value = ND.Performance
            'dbParam_performance.DbType = System.Data.DbType.String
            'DbCommand.Parameters.Add(dbParam_performance)

            'Dim dbParam_remarks As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_remarks.ParameterName = "@remarks"
            'dbParam_remarks.Value = ND.Remarks
            'dbParam_remarks.DbType = System.Data.DbType.String
            'DbCommand.Parameters.Add(dbParam_remarks)

            'Dim dbParam_NoDue_Id As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
            'dbParam_NoDue_Id.ParameterName = "@dueid"
            'dbParam_NoDue_Id.Value = ND.DueId
            'dbParam_NoDue_Id.DbType = System.Data.DbType.Int64
            'DbCommand.Parameters.Add(dbParam_NoDue_Id)


            'DbCommand.CommandText = Str
            'DbCommand.Connection = DbConnection
            'DbConnection.Open()
            'DbCommand.ExecuteNonQuery()
            'DbConnection.Close()
            'Return dt

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(8) {}
            Dim rowsAffected As Integer = 0
            'arParms(0) = New SqlParameter("@institute", SqlDbType.Int, 50)
            'arParms(0).Value = ND.Institute

            'arParms(1) = New SqlParameter("@branch", SqlDbType.Int, 50)
            'arParms(1).Value = ND.Branch

            arParms(0) = New SqlParameter("@institute", SqlDbType.Int)
            arParms(0).Value = HttpContext.Current.Session("InstituteID")

            arParms(1) = New SqlParameter("@branch", SqlDbType.Int)
            arParms(1).Value = HttpContext.Current.Session("BranchID")

            arParms(2) = New SqlParameter("@course", SqlDbType.Int, 100)
            arParms(2).Value = ND.Course

            arParms(3) = New SqlParameter("@batchno", SqlDbType.VarChar, 50)
            arParms(3).Value = ND.BatchNo

            arParms(4) = New SqlParameter("@deptid", SqlDbType.Int, 50)
            arParms(4).Value = ND.DeptId

            arParms(5) = New SqlParameter("@stdid", SqlDbType.Int, 50)
            arParms(5).Value = ND.StdId

            arParms(6) = New SqlParameter("@performance", SqlDbType.VarChar, 50)
            arParms(6).Value = ND.Performance

            arParms(7) = New SqlParameter("@remarks", SqlDbType.VarChar, 50)
            arParms(7).Value = ND.Remarks

            arParms(8) = New SqlParameter("@dueid", SqlDbType.Int, 50)
            arParms(8).Value = ND.DueId

            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateNoDueRecord", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Return rowsAffected
        End Function
        Function Delete(ByVal Due_Id As Integer) As Integer
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim rowsAffected As Integer = 0
            Dim arParms As SqlParameter = New SqlParameter
            arParms = New SqlParameter("@dueid", SqlDbType.Int, 50)
            arParms.Value = Due_Id
            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteNoDueRecord", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        End Function
        Public Function GetReportNoDueData(ByVal ins As Integer, ByVal course As Integer, ByVal batch As Integer, ByVal stdcode As Integer) As DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms() As SqlParameter = New SqlParameter(4) {}
            arParms(0) = New SqlParameter("@batchid", SqlDbType.Int)
            arParms(0).Value = batch

            arParms(1) = New SqlParameter("@instituteid", SqlDbType.Int)
            ' arParms(1).Value = ins
            arParms(1).Value = ins

            ' MsgBox(HttpContext.Current.Session("InstituteID").ToString)

            arParms(2) = New SqlParameter("@branchid", SqlDbType.Int)
            arParms(2).Value = HttpContext.Current.Session("BranchID")

            arParms(3) = New SqlParameter("@courseid", SqlDbType.Int)
            arParms(3).Value = course

            arParms(4) = New SqlParameter("@stdcode", SqlDbType.Int)
            arParms(4).Value = stdcode

            ds.Clear()
            Try
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NoDueReport", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Return ds.Tables(0)
        End Function
    End Class
End Namespace
