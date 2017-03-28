Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class DLResetPwd
    Shared Function Resetpwd(ByVal r As ResetPwd) As Integer

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim para() As SqlParameter = New SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        'para(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        'para(1).Value = HttpContext.Current.Session("EmpCode")

        para(1) = New SqlParameter("@UserName", SqlDbType.VarChar)
        para(1).Value = r.UserCode

        para(2) = New SqlParameter("@Password", SqlDbType.VarChar)
        para(2).Value = r.Password
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_ResetPassword", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function getusername(ByVal r As ResetPwd) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@UserName", SqlDbType.VarChar)
        para(1).Value = r.UserCode

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_Getusername", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ResetParentpwd(ByVal r As ResetPwd) As Integer

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        para(1).Value = HttpContext.Current.Session("EmpCode")

        para(2) = New SqlParameter("@UserName", SqlDbType.VarChar)
        para(2).Value = r.UserCode

        para(3) = New SqlParameter("@Password", SqlDbType.VarChar)
        para(3).Value = r.Password
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_ResetParentPassword", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ResetSParentpwd(ByVal r As ResetPwd) As Integer

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim para() As SqlParameter = New SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        para(1).Value = HttpContext.Current.Session("EmpCode")

        para(2) = New SqlParameter("@Password", SqlDbType.VarChar)
        para(2).Value = r.Password
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_ResetSParentPassword", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function getParentusername(ByVal r As ResetPwd) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@UserName", SqlDbType.VarChar)
        para(1).Value = r.UserCode

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetParentusername", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
