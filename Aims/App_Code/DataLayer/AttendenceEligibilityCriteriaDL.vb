Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class AttendenceEligibilityCriteriaDL
    Public Function getGrid(ByVal El As AttendenceEligibilityCriteriaEL) As DataTable
     
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        param(2).Value = El.BatchId

        param(3) = New SqlParameter("@SemId", SqlDbType.Int)
        param(3).Value = El.SemId

        param(4) = New SqlParameter("@Perentage ", SqlDbType.Int)
        param(4).Value = El.Min

        param(5) = New SqlParameter("@SubjectId", SqlDbType.VarChar, 50)
        param(5).Value = El.SubjectID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_AttendanceEligibility]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function UpdateRecord(ByVal El As AttendenceEligibilityCriteriaEL) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(9) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("EmpCode")

        param(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("UserCode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@StdId ", SqlDbType.Int)
        param(4).Value = El.Id

        param(5) = New SqlParameter("@Eligible", SqlDbType.VarChar, 2)
        param(5).Value = El.Eligible

        param(6) = New SqlParameter("@Subject", SqlDbType.VarChar, 500)
        param(6).Value = El.SubjectID

        param(7) = New SqlParameter("Batch", SqlDbType.Int)
        param(7).Value = El.BatchId

        param(8) = New SqlParameter("SemId", SqlDbType.Int)
        param(8).Value = El.SemId

        param(9) = New SqlParameter("SubjectName", SqlDbType.VarChar, 5000)
        param(9).Value = El.SubjectNamne

        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[proc_UpdateAttendanceEligibility]", param)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Function

    Shared Function InsertStudent(ByVal EL As AttendenceEligibilityCriteriaEL) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
        param(0) = New SqlClient.SqlParameter("@StdId", SqlDbType.VarChar, 2000)
        param(0).Value = EL.StdId

        param(1) = New SqlClient.SqlParameter("@StdCode", SqlDbType.VarChar, 2000)
        param(1).Value = EL.StdCode

        param(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("EmpCode")

        param(3) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("UserCode")

        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")

        param(5) = New SqlClient.SqlParameter("@BatchID", SqlDbType.Int)
        param(5).Value = EL.TBatchid

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_PromotionTransfer", param)
        Return AffectedRows
    End Function
    Shared Function UndoStudent(ByVal EL As AttendenceEligibilityCriteriaEL) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        param(0) = New SqlClient.SqlParameter("@StdId", SqlDbType.VarChar, 2000)
        param(0).Value = EL.StdId

        param(1) = New SqlClient.SqlParameter("@StdCode", SqlDbType.VarChar, 2000)
        param(1).Value = EL.StdCode

        param(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("EmpCode")

        param(3) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("UserCode")

        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")

        param(5) = New SqlClient.SqlParameter("@BatchID", SqlDbType.Int)
        param(5).Value = EL.TBatchid

        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UndoPromotionTransfer", param)
        Return AffectedRows
    End Function


    Public Function GetSubjectDetails(ByVal BatchId As Integer, ByVal SemId As Integer) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(3) {}

        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        param(2).Value = BatchId

        param(3) = New SqlParameter("@SemId", SqlDbType.Int)
        param(3).Value = SemId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_SubjectDetails]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Drilldown(ByVal StdId As Integer, ByVal BatchId As Integer, ByVal sem As Integer, ByVal min As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(5) {}

        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@Batchid", SqlDbType.Int)
        param(2).Value = BatchId

        param(3) = New SqlParameter("@min", SqlDbType.Int)
        param(3).Value = min

        param(4) = New SqlParameter("@Semester", SqlDbType.Int)
        param(4).Value = sem

        param(5) = New SqlParameter("@STDID", SqlDbType.Int)
        param(5).Value = StdId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AttendanceDrilldownEligibility", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Drilldown1(ByVal StdId As Integer, ByVal BatchId As Integer, ByVal sem As Integer, ByVal min As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(5) {}

        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@Batchid", SqlDbType.Int)
        param(2).Value = BatchId

        param(3) = New SqlParameter("@min", SqlDbType.Int)
        param(3).Value = min

        param(4) = New SqlParameter("@Semester", SqlDbType.Int)
        param(4).Value = sem

        param(5) = New SqlParameter("@STDID", SqlDbType.Int)
        param(5).Value = StdId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AttendanceDrilldownEligibility2", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
