Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DLRolemap
    Shared Function GetRolemap(ByVal role As Rolemap) As DataTable
        '10-12-2010 Kusum.C.Akki. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(3) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("Office")
        Para(2) = New SqlParameter("@RMID", SqlDbType.Int)
        Para(2).Value = role.RMID
        Para(3) = New SqlParameter("@role", SqlDbType.Int)
        Para(3).Value = role.RoleCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetRolemap", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckDuplicate(ByVal role As Rolemap) As DataTable
        '10-12-2010 Kusum.C.Akki. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")

        Para(1) = New SqlParameter("@role", SqlDbType.Int)
        Para(1).Value = role.RoleCode

        Para(2) = New SqlParameter("@TreeViewID", SqlDbType.Int)
        Para(2).Value = role.Code
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateRolemap", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function InsertRolemap(ByVal role As Rolemap) As Integer
        '10-12-2010 Kusum.C.Akki. Function for Inserting the data into table'
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@TreeViewID", SqlDbType.Int)
        para(1).Value = role.Code

        para(2) = New SqlParameter("@UserRoleID", SqlDbType.Int)
        para(2).Value = role.RoleCode
        para(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("EmpCode")
        para(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        para(4).Value = HttpContext.Current.Session("UserCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveRolemap", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateRolemap(ByVal role As Rolemap) As Integer
        '10-12-2010 Kusum.C.Akki. Function for Inserting the data into table'
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@TreeViewID", SqlDbType.VarChar, 8000)
        para(1).Value = role.ID

        para(2) = New SqlParameter("@UserRoleID", SqlDbType.Int)
        para(2).Value = role.RoleCode

        para(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("EmpCode")

        para(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        para(4).Value = HttpContext.Current.Session("UserCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateRolemap", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DeleteRolemap(ByVal RMID As Long) As Integer
        '10-12-2010 Kusum.C.Akki. Function for deleting the data into table'
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@RMID", SqlDbType.Int)
        para(0).Value = RMID
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_DeleteRolemap", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function 'Proc_GetuserformDDL
    Shared Function Getuserformddl(ByVal role As Rolemap) As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@InstituteCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("InstituteCode")

        arParms(1) = New SqlParameter("@RoleCode", SqlDbType.Int)
        arParms(1).Value = role.RoleCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetuserformDDL", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Getuserroleddl() As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetroleDDL", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetModuleName() As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentName", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
