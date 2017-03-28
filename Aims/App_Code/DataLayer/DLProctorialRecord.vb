Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Public Class DLProctorialRecord
    Public Function GetStudentNameCombo(ByVal BatchID As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = BatchID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetDDLStdProctotrial", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBatchCombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "GetDDLStdProctorial", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
