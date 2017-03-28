Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLAccountGroupMapping
    Shared Function GetAccounSubGroup(ByVal EL As ELAccountGroupMapping) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id
        arParms(3) = New SqlParameter("@AccountGroupId", SqlDbType.Int)
        arParms(3).Value = EL.AccountGroupId
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AcclountGroupLoad", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAccounSubGroup2(ByVal EL As ELAccountGroupMapping) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id
        arParms(3) = New SqlParameter("@AccountGroup2", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.AccountGroup2
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AcclountGroup2Load", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetClientAccounSubGroup(ByVal EL As ELAccountGroupMapping) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id
        arParms(3) = New SqlParameter("@AccountGroupId", SqlDbType.Int)
        arParms(3).Value = EL.AccountGroupId
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ClientAcclountGroupLoad", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal EL As ELAccountGroupMapping) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(7) {}
        param(0) = New SqlClient.SqlParameter("@AccountGroup2", SqlDbType.VarChar, 50)
        param(0).Value = EL.AccountGroup2
        param(1) = New SqlClient.SqlParameter("@AccountGroupId", SqlDbType.Int)
        param(1).Value = EL.AccountGroupId
        param(2) = New SqlClient.SqlParameter("@AccountSubGroup", SqlDbType.VarChar, 50)
        param(2).Value = EL.AccountSubGroup
        param(3) = New SqlClient.SqlParameter("@AccountSubGroupId", SqlDbType.Int)
        param(3).Value = EL.AccountSubGroupId
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("EmpCode")
        param(6) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("UserCode")
        param(7) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(7).Value = HttpContext.Current.Session("Office")
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateAccountGroupMapping", param)
        Return AffectedRows
    End Function
End Class
