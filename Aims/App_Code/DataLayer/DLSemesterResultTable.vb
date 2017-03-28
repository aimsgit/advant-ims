Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLSemesterResultTable
    Shared Function InsertSemesterTable(ByVal EL As ELSemesterResultTable) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(5) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = EL.Batch

        Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(2).Value = EL.Semester

        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")

        Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("EmpCode")

        Parms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertSemesterTable", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function InsertSemesterTableIndStd(ByVal EL As ELSemesterResultTable) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(6) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = EL.Batch

        Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(2).Value = EL.Semester

        Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("UserCode")

        Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(4).Value = HttpContext.Current.Session("EmpCode")

        Parms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("Office")

        Parms(6) = New SqlParameter("@Stdid", SqlDbType.Int)
        Parms(6).Value = EL.Stdid
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertSemesterTableIndStd", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ViewSemesterTable(ByVal m As ELSemesterResultTable) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = m.Batch

        Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(2).Value = m.Semester

        Parms(3) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Parms(3).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewSemesterResultTable", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckLockMarks(ByVal m As ELSemesterResultTable) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = m.Batch

        Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(2).Value = m.Semester

        Parms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CheckLockResult", Parms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function LockStdMarks(ByVal m As ELSemesterResultTable) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = m.Batch

        Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(2).Value = m.Semester


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_LockResult", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UNLockStdMarks(ByVal m As ELSemesterResultTable) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = m.Batch

        Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(2).Value = m.Semester

       
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UNLockResult", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal El As ELSemesterResultTable) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = El.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_DelStdFrmBatchSemResult]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function getduplicate(ByVal EL As ELSemesterResultTable) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.Batch
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.Semester
        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDuplBatchSemResult]", param)
        Return ds.Tables(0)
    End Function
    Shared Function getduplicateIndStd(ByVal EL As ELSemesterResultTable) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.Batch
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.Semester
        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        param(4) = New SqlClient.SqlParameter("@Stdid", SqlDbType.Int)
        param(4).Value = EL.Stdid


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDuplBatchSemResultIndStd]", param)
        Return ds.Tables(0)
    End Function
End Class
