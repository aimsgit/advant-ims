Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLEmpAttendanceSummary
    '-->Code By Jinapriya 25-May-2015

    Public Shared Function RptAttendanceSummary(ByVal FromDate As Date, ByVal ToDate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@FromDate", SqlDbType.Date)
            Parms(1).Value = FromDate

            Parms(2) = New SqlParameter("@ToDate", SqlDbType.Date)
            Parms(2).Value = ToDate

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_EmpAttendanceSummaryMonthWise]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
