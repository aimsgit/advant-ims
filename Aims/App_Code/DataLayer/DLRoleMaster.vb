Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DLRoleMaster
    Shared Function InsertRoleMaster(ByVal m As RoleMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")
        Parms(1) = New SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("UserCode")
        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")
        Parms(3) = New SqlParameter("@UserRole", SqlDbType.NVarChar, 50)
        Parms(3).Value = m.UserRole

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_InsertUserRole]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DeleteRoleMaster(ByVal m As RoleMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@UserRoleID", SqlDbType.Int)
        Parms(0).Value = m.UserRoleID
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_DeleteUserRole]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    Shared Function UpdateRoleMaster(ByVal m As RoleMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim s As String = ""
        Dim Parms() As SqlParameter = New SqlParameter(4) {}
        Parms(0) = New SqlParameter("@UserRoleID", SqlDbType.Int)
        Parms(0).Value = HttpContext.Current.Session("UserRoleID")
        s = Parms(0).Value
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")
        s = Parms(1).Value
        Parms(2) = New SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("UserCode")
        s = Parms(2).Value
        Parms(3) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("EmpCode")
        s = Parms(3).Value
        Parms(4) = New SqlParameter("@UserRole", SqlDbType.NVarChar, 50)
        Parms(4).Value = m.UserRole
        s = Parms(4).Value
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_UpdateRoleMaster]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetAllRoleMaster(ByVal p As RoleMaster) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}
            If p.UserRoleID = "0" Then
                Parms(0) = New SqlParameter("@UserRoleID", SqlDbType.NVarChar, 100)
                Parms(0).Value = ""
            Else
                Parms(0) = New SqlParameter("@UserRoleID", SqlDbType.Int)
                Parms(0).Value = p.UserRoleID
            End If
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 1)
            Parms(2).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetAllRoleMaster]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDuplicateRoleMaster(ByVal p As String, ByVal Id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@role", SqlDbType.VarChar, 50)
            Parms(0).Value = p

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@Id", SqlDbType.VarChar, 50)
            Parms(2).Value = Id

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_RoleDuplicate]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
