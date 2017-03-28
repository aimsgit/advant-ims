Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLQualficationDtsRpt
    Public Function GetQualificaitonDetailsReportt(ByVal stdid As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@stdid", SqlDbType.Int)
        param(0).Value = stdid

        param(1) = New SqlParameter("@id", SqlDbType.Int)
        param(1).Value = 0

        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetQualicDetails", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function GetExperienceDetailsReportt(ByVal stdid As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@std_code", SqlDbType.Int)
        param(0).Value = stdid

        param(1) = New SqlParameter("@id", SqlDbType.Int)
        param(1).Value = 0

        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetExperienceDetails", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function GetCertificateDetailsReportt(ByVal stdid As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@std_code", SqlDbType.Int)
        param(0).Value = stdid

        param(1) = New SqlParameter("@id", SqlDbType.Int)
        param(1).Value = 0

        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCertiDetails", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function



    Shared Function GetBatchCombo(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@CourseCode", SqlDbType.Int)
            Parms(2).Value = Courseid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TimeTableBatchCombo", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
