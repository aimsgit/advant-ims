Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLExamPaperEvaluation
    Shared Function GetExamSubjddl(ByVal Batch As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Batch", SqlDbType.Int)
        para(2).Value = Batch


        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetExamSubj", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetExamFacultyddl() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetExamFacultyName", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal EL As ELExamPaperEvaluation) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@ExamBatch", SqlDbType.Int)
        arParms(0).Value = EL.Batch

        arParms(1) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(1).Value = EL.Subject

        arParms(2) = New SqlParameter("@Faculty", SqlDbType.Int)
        arParms(2).Value = EL.Faculty

        arParms(3) = New SqlParameter("@FrmSrlNo", SqlDbType.VarChar, 100)
        arParms(3).Value = EL.FrmSerialNo

        arParms(4) = New SqlParameter("@ToSrlNo", SqlDbType.VarChar, 100)
        arParms(4).Value = EL.ToSerialNo

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")


        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "[Proc_InsertExamPaperEvaluation]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As ELExamPaperEvaluation) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.Id

        arParms(1) = New SqlParameter("@ExamBatch", SqlDbType.Int)
        arParms(1).Value = EL.Batch

        arParms(2) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(2).Value = EL.Subject

        arParms(3) = New SqlParameter("@Faculty", SqlDbType.Int)
        arParms(3).Value = EL.Faculty

        arParms(4) = New SqlParameter("@FrmSrlNo", SqlDbType.VarChar, 100)
        arParms(4).Value = EL.FrmSerialNo

        arParms(5) = New SqlParameter("@ToSrlNo", SqlDbType.VarChar, 100)
        arParms(5).Value = EL.ToSerialNo

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateExamPaperEvaluation]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ViewData(ByVal id As Integer, ByVal Batch As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlParameter = New SqlParameter(3) {}
        Dim ds As New DataSet

        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = id

        para(3) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        para(3).Value = Batch

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_ViewExampaperEvaluation", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDuplicateData(ByVal El As ELExamPaperEvaluation) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@ExamBatch", SqlDbType.Int)
        arParms(2).Value = El.Batch

        arParms(3) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(3).Value = El.Subject

        arParms(4) = New SqlParameter("@Faculty", SqlDbType.Int)
        arParms(4).Value = El.Faculty

        arParms(5) = New SqlParameter("@FrmSrlNo", SqlDbType.VarChar, 100)
        arParms(5).Value = El.FrmSerialNo

        arParms(6) = New SqlParameter("@ToSrlNo", SqlDbType.VarChar, 100)
        arParms(6).Value = El.ToSerialNo

        arParms(7) = New SqlParameter("@id", SqlDbType.Int)
        arParms(7).Value = El.Id

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_ViewDuplicateData", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal EL As ELExamPaperEvaluation) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        'Dim arParms As SqlParameter = New SqlParameter
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = EL.Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_DeleteExamPaperEvaluation]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CntData(ByVal Exambatchid As Integer, ByVal Subject As Integer, ByVal Faculty As Integer) As Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        Parms(1).Value = Exambatchid

        Parms(2) = New SqlParameter("@Subject", SqlDbType.Int)
        Parms(2).Value = Subject

        Parms(3) = New SqlParameter("@EmpId", SqlDbType.Int)
        Parms(3).Value = Faculty

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CntExamPaperEvaluation]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function CountData(ByVal Exambatchid As Integer) As Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        Parms(1).Value = Exambatchid

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CountRecordsExamPaperEvaluation]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function GetunlockData(ByVal role As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(1).Value = role

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetUnlockExamPaperEvaluation]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function LockData(ByVal Exambatchid As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        Parms(1).Value = Exambatchid

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_LockExamPaperEvaluation]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UnLockData(ByVal Exambatchid As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        Parms(1).Value = Exambatchid


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UnLockExamPaperEvaluation]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckLockExamPaperEvaluation(ByVal id As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As String = ""

        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        Try
            Rowseffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "proc_CheckLockAttendance", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
End Class
