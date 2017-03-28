Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class MultiCurrencyDB
    Dim MultiCurrency As New MultiCurrency
    Shared Function GetMultiCurrency() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMultiCurrency", para)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetMultiCurrencyRate(ByVal id As Int64) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try

            If id = 0 Then
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMultiCurrency")
            Else
                Dim arParms As SqlParameter = New SqlParameter("@CurrencyCode", SqlDbType.Int, 10)
                arParms.Value = id
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMultiCurrencyDB", arParms)
            End If
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
End Class
