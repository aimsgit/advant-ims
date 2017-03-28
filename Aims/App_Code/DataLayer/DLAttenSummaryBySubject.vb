Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLAttenSummaryBySubject

    Shared Function GetSubComboForSummary() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_GetSubComboForSummary", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function RunSummary(ByVal El As ELAttenSummaryBySubject) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Rowsaffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(7) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@AsOnDate", SqlDbType.DateTime)
            Parms(2).Value = El.AsOnDate

            Parms(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            Parms(3).Value = El.Bid

            Parms(4) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
            Parms(4).Value = El.Sid

            Parms(5) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(5).Value = El.SubId

            Parms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(6).Value = HttpContext.Current.Session("UserCode")

            Parms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(7).Value = HttpContext.Current.Session("EmpCode")



            Rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertAttendanceSummary", Parms)
            Return Rowsaffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function BatchAccess(ByVal El As ELAttenSummaryBySubject) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@SubjectId", SqlDbType.Int)
        param(0).Value = El.SubId

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Branchcode")

        param(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BatchAccessFrSummary", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function SemAccess(ByVal El As ELAttenSummaryBySubject) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@BatchId", SqlDbType.VarChar, 50)
        param(0).Value = El.Bid

        param(1) = New SqlParameter("@SubjectId", SqlDbType.Int)
        param(1).Value = El.SubId

        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@AsOnDate", SqlDbType.Date)
        param(4).Value = El.AsOnDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SemAccessFrSummary", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Shared Function DuplicateSummary(ByVal El As ELAttenSummaryBySubject) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}


            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            Parms(1).Value = El.Bid

            Parms(2) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
            Parms(2).Value = El.Sid

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = El.SubId

            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_DuplicateAttendanceSummary]", Parms)
            Return Dt.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function ViewSummary(ByVal El As ELAttenSummaryBySubject) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@AsOnDate", SqlDbType.DateTime)
            Parms(2).Value = El.AsOnDate

            Parms(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            Parms(3).Value = El.Bid

            Parms(4) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
            Parms(4).Value = El.Sid

            Parms(5) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(5).Value = El.SubId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_ViewAttendanceSummary]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ChkLockSummary(ByVal El As ELAttenSummaryBySubject) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}


            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            Parms(2).Value = El.Bid

            Parms(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
            Parms(3).Value = El.Sid

            Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(4).Value = El.SubId

            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckLockAttendanceSummary]", Parms)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ClearSummary(ByVal El As ELAttenSummaryBySubject) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            Parms(2).Value = El.Bid

            Parms(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
            Parms(3).Value = El.Sid

            Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(4).Value = El.SubId

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_ClearAttendanceSummary]", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function UpdateSummary(ByVal Id As Integer, ByVal TotAttend As Integer, ByVal ActAttend As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}


            Parms(0) = New SqlParameter("@Id", SqlDbType.Int)
            Parms(0).Value = Id

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@TotAttend", SqlDbType.Int)
            Parms(2).Value = TotAttend

            Parms(3) = New SqlParameter("@ActAttend", SqlDbType.Int)
            Parms(3).Value = ActAttend

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_UpdateAttendanceSummary]", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function LockSummary(ByVal EL As ELAttenSummaryBySubject) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}


            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            Parms(1).Value = EL.Bid

            Parms(2) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
            Parms(2).Value = EL.Sid

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = EL.SubId

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_LockAttendanceSummary]", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function UnLockSummary(ByVal EL As ELAttenSummaryBySubject) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}


            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            Parms(1).Value = EL.Bid

            Parms(2) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
            Parms(2).Value = EL.Sid

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = EL.SubId


            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_UnLockAttendanceSummary]", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ClrSummary(ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}


            Parms(0) = New SqlParameter("@Id", SqlDbType.Int)
            Parms(0).Value = Id

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_ClrAttendSummary]", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
