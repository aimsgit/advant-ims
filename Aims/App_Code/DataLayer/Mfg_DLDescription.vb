Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class Mfg_DLDescription
    Public Function Insert(ByVal i As Mfg_ELDescription) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Description", SqlDbType.VarChar, 250)
        arParms(0).Value = i.Name
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertDescription", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELDescription) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = s.id
        para(1) = New SqlParameter("@description", SqlDbType.VarChar, 50)
        para(1).Value = s.Name

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Mfg_DuplicateDescriptionMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function Update(ByVal i As Mfg_ELDescription) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Description", SqlDbType.VarChar, 250)
        arParms(0).Value = i.Name
        arParms(1) = New SqlParameter("@DescIdAuto", SqlDbType.Int)
        arParms(1).Value = i.id
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateDescription", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function getDescription(ByVal s As Mfg_ELDescription) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = s.id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetDescriptionDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteDescription(ByVal s As Mfg_ELDescription) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@DescIdAuto", SqlDbType.Int)
        arParms.Value = s.id

        arParms = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms.Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteDescriptionDetails", arParms)
        Return rowsaffected
    End Function
End Class
