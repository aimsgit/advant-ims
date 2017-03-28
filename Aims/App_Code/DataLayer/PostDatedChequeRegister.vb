Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class PostDatedChequeRegister
    Shared Function Get_BankName() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Get_BankName", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GenerateSalesReport(ByVal ProductName As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(3) {}

        Params(0) = New SqlParameter("@BankId", Data.SqlDbType.Int)
        Params(0).Value = ProductName

        Params(1) = New SqlParameter("@Startdate", Data.SqlDbType.DateTime)
        Params(1).Value = StartDate

        Params(2) = New SqlParameter("@EndDate", Data.SqlDbType.DateTime)
        Params(2).Value = EndDate

        Params(3) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_PostDatedChequeRegisterReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
