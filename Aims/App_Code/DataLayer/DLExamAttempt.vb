Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLExamAttempt
    Shared Function GetFinalIA() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_AssesmentType]", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function
    Shared Function GetExamAttempt(ByVal BatchID As Integer, ByVal SemesterID As Integer, ByVal FinalIAID As Integer, ByVal FinalExam As Integer, ByVal StudentID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
       
        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = BatchID
        arParms(3) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(3).Value = SemesterID
        arParms(4) = New SqlParameter("@FinalIA", SqlDbType.Int)
        arParms(4).Value = FinalIAID
        arParms(5) = New SqlParameter("@FinalExam", SqlDbType.Int)
        arParms(5).Value = FinalExam
        arParms(6) = New SqlParameter("@StudentId", SqlDbType.Int)
        arParms(6).Value = StudentID

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_SemesterExamAttempts]", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function
End Class
