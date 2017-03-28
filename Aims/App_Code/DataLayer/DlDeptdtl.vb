Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DlDeptdtl
    Shared Function insertEDeptdtl(ByVal d As EDeptdtl) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        para(0).Value = d.code
        para(1) = New SqlParameter("@name", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("name")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_SaveDepartmentDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function

    Shared Function getEDeptdtl(ByVal d As EDeptdtl) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@deptid", SqlDbType.Int)
        para(0).Value = d.id
        para(1) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Code")
        para(2) = New SqlParameter("@name", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("name")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDeptDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function updateEDeptdtl(ByVal d As EDeptdtl) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@deptid", SqlDbType.VarChar, 50)
        para(0).Value = d.id
        para(1) = New SqlParameter("@code", SqlDbType.Int)
        para(1).Value = d.code
        para(2) = New SqlParameter("@name", SqlDbType.VarChar, 50)
        para(2).Value = d.name
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_UpdateDepartment", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function deleteEDeptdtl(ByVal id As Long) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_DeleteDepartment", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function

    Shared Function getDeptpduplicate(ByVal c As EDeptdtl) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("FMIS").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(0) {}
        para(0) = New SqlParameter("@Name", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Name")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_getcropduplicate", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RptDeptdtl() As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = 0
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDeptDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
