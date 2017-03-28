Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ManufacturerDB
     Public Function GetManufacturer(ByVal e As ManufacturerE) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.Int)
        Parms(0).Value = e.id
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetManufacturer", Parms)
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal mfname As ManufacturerE) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@ManuFacturer", SqlDbType.NVarChar, 50)
        arParms(0).Value = mfname.Name
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("empCode")
        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
        arParms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_SaveManufacturer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function Update(ByVal mf As ManufacturerE) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@ManuFacturer", SqlDbType.NVarChar, 50)
        arParms(0).Value = mf.Name
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("empCode")
        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
        arParms(4) = New SqlParameter("@ManufacturerId", SqlDbType.Int)
        arParms(4).Value = mf.id
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateManufacturer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function Delete(ByVal id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Manufacturerid", SqlDbType.Int)
        arParms(0).Value = id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteManufacturer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function GetDuplicateManfMaster(ByVal EL As ManufacturerE) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        If EL.Name = "" Then
            para(0) = New SqlParameter("@Name", SqlDbType.VarChar, 50)
            para(0).Value = ""
            para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(1).Value = ""
            para(2) = New SqlParameter("@id", SqlDbType.Int)
            para(2).Value = ""
        Else
            para(0) = New SqlParameter("@Name", SqlDbType.NVarChar, 50)
            para(0).Value = EL.Name
            para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(1).Value = HttpContext.Current.Session("BranchCode")
            para(2) = New SqlParameter("@id", SqlDbType.Int)
            para(2).Value = EL.id
        End If
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_GetDuplicateManufacturer", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
