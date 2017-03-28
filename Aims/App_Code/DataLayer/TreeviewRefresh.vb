Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class TreeviewRefresh
    Shared Function Getuserformddl(ByVal Mid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@InstituteCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("InstituteCode")

        arParms(1) = New SqlParameter("@Mid", SqlDbType.Int)
        arParms(1).Value = Mid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetuserformDDLnew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Getuserroleddl() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetmoduleDDLnew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetClientCombo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Ds As New DataSet

        Try
            Ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetClientNameNew")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Ds.Tables(0)
    End Function
    Shared Function AssignModule(ByVal Mid As String, ByVal Cid As String, ByVal institute As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Mid", SqlDbType.VarChar, Mid.Length)
        arParms(1).Value = Mid

        arParms(2) = New SqlParameter("@Cid", SqlDbType.VarChar, Cid.Length)
        arParms(2).Value = Cid

        arParms(3) = New SqlParameter("@institute", SqlDbType.VarChar, 50)
        arParms(3).Value = institute

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Assignmodule", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ""
    End Function

    Shared Function RefreshModule(ByVal Modle As String, ByVal institute As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Mid", SqlDbType.VarChar, Modle.Length)
        arParms(1).Value = Modle

        arParms(2) = New SqlParameter("@institute", SqlDbType.VarChar, 50)
        arParms(2).Value = institute

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RefreshModule", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ""
    End Function
End Class
