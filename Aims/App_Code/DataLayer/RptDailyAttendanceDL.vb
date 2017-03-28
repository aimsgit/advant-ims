Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class RptDailyAttendanceDL

    Public Function GetDailyAttendanceReport(ByVal BatchId As String, ByVal SemId As Integer, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@BatchId", SqlDbType.VarChar, 250)
        param(1).Value = BatchId

        'param(2) = New SqlParameter("@BatchName", SqlDbType.VarChar, 250)
        'param(2).Value = BatchName

        param(2) = New SqlParameter("@SemId", SqlDbType.Int)
        param(2).Value = SemId

        param(3) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        param(3).Value = FromDate

        param(4) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        param(4).Value = ToDate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_DailyAttendanceStatus", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
