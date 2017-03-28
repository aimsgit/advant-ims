Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLExamHallTicket
    Shared Function GetExamBatchDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ExamBatchDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetExamBatchCenter() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ExamBatchCenter", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function InsertMapStudentExamCenter(ByVal ExamBatchId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("UserCode")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(3).Value = ExamBatchId

        arParms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertMapStudentExamCenter", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function MapStudentExamCenter(ByVal ExamBatchId As Integer, ByVal StdCenter As String, ByVal ExamCenter As String, ByVal GridRowID As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
        arParms(1).Value = StdCenter

        arParms(2) = New SqlParameter("@ExamCenter", SqlDbType.VarChar)
        arParms(2).Value = ExamCenter

        arParms(3) = New SqlParameter("@GridRowId", SqlDbType.Int)
        arParms(3).Value = GridRowID

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_MapStudentExamCenter", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ClearMapStudentExamCenter(ByVal ExamBatchId As Integer, ByVal StdCenter As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
        arParms(1).Value = StdCenter

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ClearMapStudentExamCenter", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GridViewMapStdExamCenter(ByVal ExamBatchId As Integer, ByVal StdCenter As String, ByVal ExamCenter As String, ByVal StdCode As String, ByVal StdName As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
            Parms(1).Value = StdCenter

            Parms(2) = New SqlParameter("@ExamCenter", SqlDbType.VarChar)
            Parms(2).Value = ExamCenter

            Parms(3) = New SqlParameter("@StdCode", SqlDbType.VarChar)
            Parms(3).Value = StdCode

            Parms(4) = New SqlParameter("@StdName", SqlDbType.VarChar)
            Parms(4).Value = StdName

            Parms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(5).Value = HttpContext.Current.Session("BranchCode")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GridViewMapStudentExamCenter", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckGenerateStatus(ByVal ExamBatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckGenerateStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckHallTicketGenerationStatus(ByVal ExamBatchId As Integer, ByVal StdCenter As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@StdCenter", SqlDbType.VarChar)
            Parms(1).Value = StdCenter

            Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckHallTicketGeneration", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteMapStudentExamCenter(ByVal GridRowID As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@GridRowId", SqlDbType.Int)
        arParms(0).Value = GridRowID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteMapStudentExamCenter", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CountRecordsMapStdExamCenter(ByVal ExamBatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CountRecordsMapStdExamCenter", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RecordsMapStudent(ByVal ExamBatchId As Integer) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CountRecordsMapStd", Parms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function LockMapStdExamCenter(ByVal ExamBatchId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_LockMapStdExamCenter", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UnLockMapStdExamCenter(ByVal ExamBatchId As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = ExamBatchId

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UnLockMapStdExamCenter", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CheckStdMapLockStatus(ByVal ExamBatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckStdMapLockStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UnlockExam(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetUnlockExam", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
