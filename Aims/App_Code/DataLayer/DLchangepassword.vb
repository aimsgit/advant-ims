Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DLchangepassword
    Shared Function Updatechangepassword(ByVal c As changepassword) As Integer
        '10-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("EmpCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("EmpCode")

        para(2) = New SqlParameter("UserDetailsID", SqlDbType.Int)
        para(2).Value = c.UserDetailsID

        para(3) = New SqlParameter("Password", SqlDbType.VarChar, 50)
        para(3).Value = c.Password

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_UpdatePassword", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function getpassword(ByVal c As changepassword) As DataTable
        '10-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("UserDetailsID", SqlDbType.Int)
        para(1).Value = c.UserDetailsID

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetuserDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateParentchangepassword(ByVal c As changepassword) As Integer
        '10-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("EmpCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("StudentCode")

        para(2) = New SqlParameter("UserName", SqlDbType.VarChar, 100)
        para(2).Value = c.UserName

        para(3) = New SqlParameter("Password", SqlDbType.VarChar, 50)
        para(3).Value = c.Password

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_UpdateParentPassword", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function getParentpassword(ByVal c As changepassword) As DataTable
        '10-12-2010 Kusum.C.Akki. Function for Updating the data into table'
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("UserDetailsID", SqlDbType.Int)
        para(1).Value = c.UserDetailsID

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetParentpassword", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
