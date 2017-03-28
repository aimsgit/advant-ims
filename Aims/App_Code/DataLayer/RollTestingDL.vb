Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Public Class RollTestingDL
    Shared Function GetInstitute() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet

        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetInstituteDDL")
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
        Return dt.Tables(0)
    End Function
    Shared Function GetBranchRollTesting(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBranchRollTestingDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetRole(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetRollDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function View(ByVal EL As RoleTestingEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
            Parms(0).Value = EL.branch

            Parms(1) = New SqlParameter("@Role", SqlDbType.Int)
            Parms(1).Value = EL.role

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ViewRoleTesting", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function View1(ByVal EL As RoleTestingEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@Role", SqlDbType.Int)
            Parms(0).Value = EL.role

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ViewSuperAdminRoleTesting", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetRoleTestingreport(ByVal branch As String, ByVal role As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@Role", SqlDbType.Int)
            Parms(0).Value = role

            Parms(1) = New SqlParameter("@Branchcode", SqlDbType.VarChar)
            Parms(1).Value = branch
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_RoleTestingReport", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
