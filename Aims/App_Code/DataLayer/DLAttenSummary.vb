Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLAttenSummary

    Shared Function RunSummary(ByVal El As ELAttenSummary) As Integer
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

            Parms(3) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(3).Value = El.Bid

            Parms(4) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(4).Value = El.Sid

            Parms(5) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(5).Value = El.SubId

            Parms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(6).Value = HttpContext.Current.Session("UserCode")

            Parms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(7).Value = HttpContext.Current.Session("EmpCode")



            Rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertAttendSummary", Parms)
            Return Rowsaffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function ViewSummary(ByVal El As ELAttenSummary) As DataTable
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

            Parms(3) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(3).Value = El.Bid

            Parms(4) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(4).Value = El.Sid

            Parms(5) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(5).Value = El.SubId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_ViewAttendSummary]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ClearSummary(ByVal El As ELAttenSummary) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = El.Bid

            Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(3).Value = El.Sid

            Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(4).Value = El.SubId

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_ClearAttendSummary]", Parms)
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

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_UpdateAttendSummary]", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function DuplicateSummary(ByVal El As ELAttenSummary) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}


            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(1).Value = El.Bid

            Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(2).Value = El.Sid

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = El.SubId

            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_DuplicateAttendSummary]", Parms)
            Return Dt.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ChkLockSummary(ByVal El As ELAttenSummary) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}


            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = El.Bid

            Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(3).Value = El.Sid

            Parms(4) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(4).Value = El.SubId

            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckLockAttenSummary]", Parms)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function LockSummary(ByVal EL As ELAttenSummary) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}


            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(1).Value = El.Bid

            Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(2).Value = EL.Sid

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = EL.SubId

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_LockAttenSummary]", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function UnLockSummary(ByVal EL As ELAttenSummary) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}


            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(1).Value = EL.Bid

            Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(2).Value = EL.Sid

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = EL.SubId


            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_UnLockAttenSummary]", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboBatchPlanner(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(6) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            Parms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(4).Value = HttpContext.Current.Session("EmpID")

            Parms(5) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(5).Value = HttpContext.Current.Session("UserRole")

            Parms(6) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(6).Value = HttpContext.Current.Session("DeptId")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_AllSubjectFromBatchBlanner", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function RptAttenSummary(ByVal Bid As Integer, ByVal Sid As Integer, ByVal SubId As Integer, ByVal Sort As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(1).Value = Bid

            Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(2).Value = Sid

            Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
            Parms(3).Value = SubId

            Parms(4) = New SqlParameter("@Sort", SqlDbType.Int)
            Parms(4).Value = Sort

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_AttenSummary]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
