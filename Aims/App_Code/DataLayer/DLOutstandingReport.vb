
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
    Public Class DLOutstandingReport
    Shared Function GetOutstanding(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(3).Value = EndDate
        'para(4) = New SqlParameter("@Party_Id ", SqlDbType.Int)
        'para(4).Value = Party_Id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptOutstanding", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    End Class