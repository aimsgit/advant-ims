Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLRptMarksAtten
    Public Function RptGetMarksAtten(ByVal RType As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@RType", SqlDbType.VarChar, 5)
        arParms(2).Value = RType

        arParms(3) = New SqlParameter("@FromDate", SqlDbType.Date)
        arParms(3).Value = FromDate

        arParms(4) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(4).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_MarksAttendanceEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
