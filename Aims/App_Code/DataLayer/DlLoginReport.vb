Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class DlLoginReport
    Shared Function InstCombo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter() {}

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInstitute", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function BranchCombo(ByVal BranchCode As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranch", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RptLogin(ByVal Institute As String, ByVal Branch As String, ByVal FrmDate As DateTime, ByVal ToDate As DateTime) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Institute", SqlDbType.VarChar, 100)
        arParms(0).Value = Institute

        arParms(1) = New SqlParameter("@Branch", SqlDbType.VarChar, 100)
        arParms(1).Value = Branch

        arParms(2) = New SqlParameter("@FrmDate", SqlDbType.DateTime)
        arParms(2).Value = FrmDate

        arParms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(3).Value = ToDate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_Logincount", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
