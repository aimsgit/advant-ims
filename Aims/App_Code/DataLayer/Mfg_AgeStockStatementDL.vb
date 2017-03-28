Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class Mfg_AgeStockStatementDL
    Shared Function GenerateAgeStockStatementReport(ByVal CompanyName As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(4) {}

        Params(0) = New SqlParameter("@CompId", Data.SqlDbType.Int)
        Params(0).Value = CompanyName

        Params(1) = New SqlParameter("@Startdate", Data.SqlDbType.DateTime)
        Params(1).Value = StartDate

        Params(2) = New SqlParameter("@EndDate", Data.SqlDbType.DateTime)
        Params(2).Value = EndDate

        Params(3) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
        Params(3).Value = HttpContext.Current.Session("BranchCode")

        Params(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Params(4).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[proc_GenerateAgeStockStatementReport]", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Public Function Get_CompanyName() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlManfCompany", arParms)
        Return ds.Tables(0)
    End Function

End Class
