Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class Mfg_DLUnit
    Public Function Insert(ByVal i As Mfg_ELUnit) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Unit", SqlDbType.VarChar, 50)
        arParms(0).Value = i.Name
        arParms(1) = New SqlParameter("@ConverionType", SqlDbType.Float)
        arParms(1).Value = i.Conversion
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")
        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")
        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertUnit", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELUnit) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = s.id
        para(1) = New SqlParameter("@Unit", SqlDbType.VarChar, 50)
        para(1).Value = s.Name
        para(2) = New SqlParameter("@ConverionType", SqlDbType.Float)
        para(2).Value = s.Conversion
        para(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Mfg_DuplicateUnit", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Update(ByVal i As Mfg_ELUnit) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Unit", SqlDbType.VarChar, 50)
        arParms(0).Value = i.Name
        arParms(1) = New SqlParameter("@ConversionType", SqlDbType.Float)
        arParms(1).Value = i.Conversion
        arParms(2) = New SqlParameter("@UnitIDAutoNo", SqlDbType.Int)
        arParms(2).Value = i.id
        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")
        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateUnitDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function getUnit(ByVal s As Mfg_ELUnit) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = s.id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetUnitDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteUnit(ByVal s As Mfg_ELUnit) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@UnitIDAutoNo", SqlDbType.Int)
        arParms.Value = s.id
        arParms = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms.Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteUnitDetails", arParms)
        Return rowsaffected
    End Function
End Class
