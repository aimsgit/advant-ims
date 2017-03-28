Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLUserManagement
    Shared Function GetAccessLevels() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetAccesslevel]")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetRoles(ByVal m As UserManagement) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 1)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetRoles]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetSearchResults(ByVal m As String, ByVal e As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@UserName", SqlDbType.NVarChar, 50)
        Parms(0).Value = m
        Parms(1) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        Parms(1).Value = e
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Parms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_SearchUserDetails]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBranchName(ByVal EmpCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 200)
        Parms(0).Value = EmpCode

        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("Office")

        Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar)
        Parms(3).Value = HttpContext.Current.Session("UserRole")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetBranchNameUserDetails]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function InsertUserManagement(ByVal m As UserManagement) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Dim str As String = HttpContext.Current.Session("BranchCode").ToString()
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")
        Parms(1) = New SqlParameter("@UserName", SqlDbType.VarChar, 100)
        Parms(1).Value = m.UserName
        Parms(2) = New SqlParameter("@PassWord", SqlDbType.VarChar, 100)
        Parms(2).Value = m.Password
        Parms(3) = New SqlParameter("@Roles", SqlDbType.VarChar, 6000)
        Parms(3).Value = m.Roles
        Parms(4) = New SqlParameter("@Privilages", SqlDbType.VarChar, 100)
        Parms(4).Value = m.Privilages
        Dim s As String = HttpContext.Current.Session("BranchName")
        Parms(5) = New SqlParameter("@Branch_Code", SqlDbType.VarChar, 100)
        Parms(5).Value = m.BranchCode
        Parms(6) = New SqlParameter("@EmpNum", SqlDbType.VarChar, 100)
        Parms(6).Value = HttpContext.Current.Session("Empnum")
        Parms(7) = New SqlParameter("@AccessLevel", SqlDbType.VarChar, 100)
        Parms(7).Value = m.AccessLevel
        Parms(8) = New SqlParameter("@Emp_Id", SqlDbType.VarChar, 100)
        Parms(8).Value = HttpContext.Current.Session("EmpCode")
        Parms(9) = New SqlParameter("@ExpDate", SqlDbType.DateTime)
        Parms(9).Value = m.ExpDate
        'Parms(10) = New SqlParameter("@RValue", SqlDbType.Int)
        'Parms(10).Direction = ParameterDirection.Output

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_InsertUserDetails]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetUserDetails(ByVal p As UserManagement) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}
            If p.UserDetailsID = "0" Then
                Parms(0) = New SqlParameter("@UserDetailsId", SqlDbType.NVarChar, 100)
                Parms(0).Value = ""
            Else
                Parms(0) = New SqlParameter("@UserDetailsId", SqlDbType.NVarChar, 100)
                Parms(0).Value = p.UserDetailsID
            End If
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 100)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 1)
            Parms(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[SP_GetUserDetails]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function DeleteUserDetails(ByVal m As UserManagement) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@UserDetailsID", SqlDbType.Int)
        Parms(0).Value = m.UserDetailsID
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 100)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_DeleteUserDetails]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function

    Shared Function GetRolesFromUserDetails(ByVal m As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As String = ""
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@RoleCode", SqlDbType.VarChar, m.Length())
        Parms(0).Value = m
        'Parms(1) = New SqlParameter("@Roles", SqlDbType.VarChar, 6000)
        'Parms(1).Direction = ParameterDirection.Output
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 100)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "[SP_GetUserRoleDetails]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function

    Shared Function GetRolesFromUserDetailsForUpdate(ByVal m As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As String = ""
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@RoleCode", SqlDbType.VarChar, m.Length())
        Parms(0).Value = m
        'Parms(1) = New SqlParameter("@Roles", SqlDbType.NVarChar, 6000)
        'Parms(1).Direction = ParameterDirection.Output
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "[SP_GetUserRoleDetailsForUpdate]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function

    Shared Function UpdateUserDetails(ByVal m As UserManagement) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim Parms() As SqlParameter = New SqlParameter(8) {}
        Parms(0) = New SqlParameter("@UserName", SqlDbType.NVarChar, 100)
        Parms(0).Value = m.UserName
        Parms(1) = New SqlParameter("@PassWord", SqlDbType.NVarChar, 100)
        Parms(1).Value = m.Password
        Parms(2) = New SqlParameter("@Roles", SqlDbType.VarChar, 6000)
        Parms(2).Value = m.Roles
        Parms(3) = New SqlParameter("@Privilages", SqlDbType.NVarChar, 100)
        Parms(3).Value = m.Privilages
        Parms(4) = New SqlParameter("@AccessLevel", SqlDbType.NVarChar, 100)
        Parms(4).Value = m.AccessLevel
        Parms(5) = New SqlParameter("@ExpDate", SqlDbType.DateTime)
        Parms(5).Value = m.ExpDate
        Parms(6) = New SqlParameter("@UserDetailsId", SqlDbType.Int)
        Parms(6).Value = m.UserDetailsID
        Parms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(7).Value = HttpContext.Current.Session("EmpCode")
        Parms(8) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(8).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[SP_UpdateUserDetails]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    ' global or local table

    Public Function GetConfigTable() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select TableName,TableAccessLevel From TableMaster")
        Return ds
    End Function
    ' user role 

    Public Function RoleMap() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim BranchCode As String = HttpContext.Current.Session("Branchcode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * From View_RoleMap where View_RoleMap.Branchcode='" + BranchCode + "'")
            Return ds.Tables(0)
        Catch e As Exception
            MsgBox(e.ToString)
        End Try
    End Function
    Public Function Rpt_UserDetails(ByVal DeptID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 1)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(2).Value = DeptID


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetUserDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function StudRptCard() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * From Configuration")
            Return ds.Tables(0)
        Catch e As Exception
            MsgBox(e.ToString)
        End Try
    End Function
End Class
