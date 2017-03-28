Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLFacultyAllocation
    Shared Function getduplicate(ByVal EL As ELFacultyAllocation) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseID
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        param(4) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(4).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_DuplicateFacultyAllocation]", param)
        Return ds.Tables(0)
    End Function
    Shared Function generate(ByVal EL As ELFacultyAllocation) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}
        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("EmpCode")
        param(4) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("UserCode")
        param(5) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("BranchCode")
        param(6) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(6).Value = HttpContext.Current.Session("Office")

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_GenerateFacultyAllocation]", param)
        Return AffectedRows
    End Function
    Shared Function GetData(ByVal EL As ELFacultyAllocation) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        param(4) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(4).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetFacultyAllocation]", param)
        Return ds.Tables(0)
    End Function
    Shared Function CheckLock(ByVal EL As ELFacultyAllocation) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        param(4) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(4).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CheckLockFacultyAllocation]", param)
        Return ds.Tables(0)
    End Function
    Shared Function clear(ByVal EL As ELFacultyAllocation) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.CourseId
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.BatchId
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.SemesterId
        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_ClearFacultyAllocation]", param)
        Return AffectedRows
    End Function
    Shared Function Lock(ByVal EL As ELFacultyAllocation) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        param(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
        param(0).Value = EL.Id
        param(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_LockFacultyAllocation]", param)
        Return AffectedRows
    End Function
    Shared Function UnLock(ByVal EL As ELFacultyAllocation) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        param(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
        param(0).Value = EL.Id
        param(1) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UnLockFacultyAllocation]", param)
        Return AffectedRows
    End Function
    Shared Function Update(ByVal EL As ELFacultyAllocation) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(10) {}

        param(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
        param(0).Value = EL.Id
        param(1) = New SqlClient.SqlParameter("@TeacherID1", SqlDbType.Int)
        param(1).Value = EL.TeacherID1
        param(2) = New SqlClient.SqlParameter("@TeacherID2", SqlDbType.Int)
        param(2).Value = EL.TeacherID2
        param(3) = New SqlClient.SqlParameter("@TeacherID3", SqlDbType.Int)
        param(3).Value = EL.TeacherID3
        param(4) = New SqlClient.SqlParameter("@TeacherID4", SqlDbType.Int)
        param(4).Value = EL.TeacherID4
        param(5) = New SqlClient.SqlParameter("@Hours1", SqlDbType.Int)
        param(5).Value = EL.Hours1
        param(6) = New SqlClient.SqlParameter("@Hours2", SqlDbType.Int)
        param(6).Value = EL.Hours2
        param(7) = New SqlClient.SqlParameter("@Hours3", SqlDbType.Int)
        param(7).Value = EL.Hours3
        param(8) = New SqlClient.SqlParameter("@Hours4", SqlDbType.Int)
        param(8).Value = EL.Hours4
        param(9) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(9).Value = HttpContext.Current.Session("EmpCode")
        param(10) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(10).Value = HttpContext.Current.Session("BranchCode")

        
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateFacultyAllocation", param)
        Return AffectedRows
    End Function
    Shared Function GetFacultyAllocationReport() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_FacultyAllocation", para)
        Return ds.Tables(0)

    End Function
End Class
