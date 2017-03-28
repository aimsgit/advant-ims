Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLProffessionTax
    Shared Function GenerateProffessionTaxReport(ByVal year As Integer, ByVal month As String) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(2) {}

        Params(0) = New SqlParameter("@year", Data.SqlDbType.Int)
        Params(0).Value = year

        Params(1) = New SqlParameter("@month", Data.SqlDbType.VarChar, 50)
        Params(1).Value = month


        Params(2) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
        Params(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_ProffessionTaxStatementReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GenerateProvidentReport(ByVal year As Integer, ByVal month As String) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(2) {}

        Params(0) = New SqlParameter("@year", Data.SqlDbType.Int)
        Params(0).Value = year

        Params(1) = New SqlParameter("@month", Data.SqlDbType.VarChar, 50)
        Params(1).Value = month


        Params(2) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
        Params(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_ProvidentReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function SummaryProvidentReport(ByVal FromYear As Integer, ByVal ToYear As Integer, ByVal FromMonth As Integer, ByVal ToMonth As Integer) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@FromYear", SqlDbType.Int)
        arParms(1).Value = FromYear

        arParms(2) = New SqlParameter("@ToYear", SqlDbType.Int)
        arParms(2).Value = ToYear

        arParms(3) = New SqlParameter("@FromMonth", SqlDbType.Int)
        arParms(3).Value = FromMonth

        arParms(4) = New SqlParameter("@ToMonth", SqlDbType.Int)
        arParms(4).Value = ToMonth

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_PFSalaryStatment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetYearDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetYearLookupDDL")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
