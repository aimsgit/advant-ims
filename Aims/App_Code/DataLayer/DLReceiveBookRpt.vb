Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLReceiveBookRpt
    Public Function Rpt_ReceiveBook(ByVal id As Integer, ByVal startdate As DateTime, ByVal enddate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@Subjectid", SqlDbType.Int)
        arParms(2).Value = id

        arParms(3) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(3).Value = startdate

        arParms(4) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(4).Value = enddate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_ReceiveBook", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
