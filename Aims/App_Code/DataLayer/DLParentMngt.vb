Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLParentMngt
    Dim el As ELParentMngt
    Public Function SearchParent(ByVal U As ELParentMngt) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(4) {}
        Parms(0) = New SqlParameter("@UserName", SqlDbType.VarChar, 50)
        Parms(0).Value = U.srchuser
        Parms(1) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        Parms(1).Value = U.StdCode
        Parms(2) = New SqlParameter("@Id", SqlDbType.Int)
        Parms(2).Value = U.Id
        Parms(3) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("BranchCode")
        Parms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(4).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SearchParentUserDetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetParentDetails(ByVal p As ELParentMngt) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}
            Parms(0) = New SqlParameter("@Id", SqlDbType.Int)
            Parms(0).Value = p.Id
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 100)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 1)
            Parms(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentUserDetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function InsertParentManagement(ByVal m As ELParentMngt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Dim str As String = HttpContext.Current.Session("BranchCode").ToString()
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")
        Parms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        Parms(1).Value = m.BatchID
        Parms(2) = New SqlParameter("@UserName", SqlDbType.VarChar, 100)
        Parms(2).Value = m.Username
        Parms(3) = New SqlParameter("@Password", SqlDbType.VarChar, 6000)
        Parms(3).Value = m.Password
        Parms(4) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 100)
        Parms(4).Value = m.StdCode
        Parms(5) = New SqlParameter("@ExpDate", SqlDbType.Date)
        Parms(5).Value = m.ExpDate
        Parms(6) = New SqlParameter("@Privilages", SqlDbType.VarChar, 50)
        Parms(6).Value = m.Privilages
        Parms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 6000)
        Parms(7).Value = HttpContext.Current.Session("EmpCode")
        Parms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
        Parms(8).Value = HttpContext.Current.Session("UserCode")
        Parms(9) = New SqlParameter("@LoginType", SqlDbType.VarChar, 50)
        Parms(9).Value = m.LoginType
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveParentUserDetails", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DeleteParentDetails(ByVal m As ELParentMngt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@Id", SqlDbType.Int)
        Parms(0).Value = m.Id
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteParentUserDetails", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    Shared Function UpdateParentDetails(ByVal m As ELParentMngt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim Parms() As SqlParameter = New SqlParameter(9) {}
        Parms(0) = New SqlParameter("@UserName", SqlDbType.NVarChar, 100)
        Parms(0).Value = m.UserName
        Parms(1) = New SqlParameter("@Password", SqlDbType.NVarChar, 100)
        Parms(1).Value = m.Password
        Parms(2) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 6000)
        Parms(2).Value = m.StdCode
        Parms(3) = New SqlParameter("@ExpDate", SqlDbType.DateTime)
        Parms(3).Value = m.ExpDate
        Parms(4) = New SqlParameter("@Privilages", SqlDbType.NVarChar, 100)
        Parms(4).Value = m.Privilages
        Parms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 6000)
        Parms(5).Value = HttpContext.Current.Session("EmpCode")
        Parms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
        Parms(6).Value = HttpContext.Current.Session("UserCode")
        Parms(7) = New SqlParameter("@Id", SqlDbType.Int)
        Parms(7).Value = m.Id
        Parms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        Parms(8).Value = HttpContext.Current.Session("BranchCode")
        Parms(9) = New SqlParameter("@LoginType", SqlDbType.VarChar, 50)
        Parms(9).Value = m.LoginType

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateParentUserDetails", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected

    End Function
    Public Function RoleMap() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * From View_RoleMap")
            Return ds.Tables(0)
        Catch e As Exception
            MsgBox(e.ToString)
        End Try
    End Function
    Shared Function getStudentNameBatchByCode(ByVal prefixText As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdCode", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetDuplicateUser(ByVal EL As ELParentMngt) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}

        para(0) = New SqlParameter("@UserID ", SqlDbType.VarChar, 50)
        para(0).Value = EL.Username
        para(1) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        para(1).Value = EL.StdCode
        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        para(3) = New SqlParameter("@LoginType", SqlDbType.VarChar, 50)
        para(3).Value = EL.LoginType

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_DuplicateParentLogin", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
