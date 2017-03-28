Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DL_ShopWiseSalesReport
    Shared Function GetBranchCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "SelectBranchCombo", arParms)
        Return ds.Tables(0)
    End Function
    Public Function ShopWiseSaleReport(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            'Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            'Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(1).Value = FromDate

            Parms(2) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(2).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ShopWiseSaleReport", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function WeeklySalesReport(ByVal month As String, ByVal year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            'Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            'Parms(0).Value = BranchCode

            Parms(0) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@month", SqlDbType.VarChar)
            Parms(1).Value = month

            Parms(2) = New SqlParameter("@year", SqlDbType.VarChar)
            Parms(2).Value = year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_WeeklySalesReport", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
