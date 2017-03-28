Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLExamhallAllocation
    Shared Function GetExamHallDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ddlExamHall", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSubjectCombo(ByVal ExamBatch_Autoid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(2).Value = ExamBatch_Autoid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectComboForExamHall", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCapacityAutoFill(ByVal EL As ELExamHallAllocation) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@RoomId", SqlDbType.Int)
            Parms(2).Value = EL.RoomId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetExamHallCapacity", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function Insert(ByVal El As ELExamHallAllocation) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = El.ExamBatchId

        arParms(1) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(1).Value = El.SubId

        arParms(2) = New SqlParameter("@ExamRoomId", SqlDbType.Int)
        arParms(2).Value = El.RoomId

        arParms(3) = New SqlParameter("@StdFrom", SqlDbType.VarChar, 50)
        arParms(3).Value = El.Fromsl

        arParms(4) = New SqlParameter("@StdTo", SqlDbType.VarChar, 50)
        arParms(4).Value = El.Tosl

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_InsertExamHall]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal El As ELExamHallAllocation) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = El.ExamBatchId

        arParms(1) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(1).Value = El.SubId

        arParms(2) = New SqlParameter("@ExamRoomId", SqlDbType.Int)
        arParms(2).Value = El.RoomId

        arParms(3) = New SqlParameter("@StdFrom", SqlDbType.VarChar, 50)
        arParms(3).Value = El.Fromsl

        arParms(4) = New SqlParameter("@StdTo", SqlDbType.VarChar, 50)
        arParms(4).Value = El.Tosl

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(8).Value = El.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateExamHall", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayGridValue(ByVal El As ELExamHallAllocation) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.id
        arParms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(3).Value = El.ExamBatchId



        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetRoom", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal EL As ELExamHallAllocation) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.ID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteExamHall_Allocation", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetPublishData(ByVal El As ELExamHallAllocation) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
      
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.id
        arParms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(3).Value = El.ExamBatchId


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MapStudentToExanHall", arParms)
        
        Return ds.Tables(0)
    End Function

    Shared Function ChangeFlagReg(ByVal EL As ELExamHallAllocation) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}



        arParms(0) = New SqlParameter("@Branchcode", SqlDbType.Int)
        arParms(0).Value = EL.BranchCode
        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = EL.ExamBatchId



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_MapFlagExamHall_Allocation", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_LockMapStudentToExamHall", Parms)
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UnLockMapStudentToExamHall]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetunlockData(ByVal id As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        arParms(1).Value = id



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetUnlockHall]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CountData(ByVal Exambatchid As Integer) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        Parms(1).Value = Exambatchid

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CountRecordsExamHall]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function CheckBatchLockStatus(ByVal ExamBatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
            Parms(0).Value = ExamBatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckBatchLockStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CountData1(ByVal Exambatchid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        Parms(1).Value = Exambatchid

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CountRecordsExamHall]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Shared Function CheckDuplicate(ByVal El As ELExamHallAllocation) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@ExamBatchId", SqlDbType.Int)
        arParms(0).Value = El.ExamBatchId

        arParms(1) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(1).Value = El.SubId

        arParms(2) = New SqlParameter("@ExamRoomId", SqlDbType.Int)
        arParms(2).Value = El.RoomId

        arParms(3) = New SqlParameter("@StdFrom", SqlDbType.VarChar, 50)
        arParms(3).Value = El.Fromsl

        arParms(4) = New SqlParameter("@StdTo", SqlDbType.VarChar, 50)
        arParms(4).Value = El.Tosl

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CheckDuplicateForExamHall]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class



