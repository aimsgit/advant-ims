Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLApprisalForm
    Shared Function GetDeptName(ByVal DeptID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@DeptID", SqlDbType.VarChar)
            Parms(0).Value = DeptID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Getdept", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
