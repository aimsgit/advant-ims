Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class Mfg_DLmanufacturer
    Public Function Insert(ByVal i As Mfg_ELmanufacturer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        arParms(0).Value = i.Country

        arParms(1) = New SqlParameter("@Manufaturer_Name", SqlDbType.VarChar, 50)
        arParms(1).Value = i.Manufacturer

        arParms(2) = New SqlParameter("@DiscountLock", SqlDbType.VarChar, 2)
        arParms(2).Value = i.DisLock

        arParms(3) = New SqlParameter("@MfgMkt_Type", SqlDbType.VarChar, 50)
        arParms(3).Value = i.Type

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_Insertmanufacturer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function Update(ByVal i As Mfg_ELmanufacturer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@ManufAutoNo", SqlDbType.VarChar, 50)
        arParms(0).Value = i.id

        arParms(1) = New SqlParameter("@Manufaturer_Name", SqlDbType.VarChar, 50)
        arParms(1).Value = i.Manufacturer

        arParms(2) = New SqlParameter("@DiscountLock", SqlDbType.VarChar, 2)
        arParms(2).Value = i.DisLock

        arParms(3) = New SqlParameter("@MfgMkt_Type", SqlDbType.VarChar, 50)
        arParms(3).Value = i.Type

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        arParms(7).Value = i.Country
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_updateManufacturer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function getManufacturer(ByVal s As Mfg_ELmanufacturer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = s.Id

        arParms(3) = New SqlParameter("@Manufacturer", SqlDbType.VarChar, 50)
        arParms(3).Value = s.Manufacturer
        arParms(4) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        arParms(4).Value = s.Country
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_getManufacturer", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteManufacturer(ByVal s As Mfg_ELmanufacturer) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@ManufAutoNo", SqlDbType.Int)
        arParms(0).Value = s.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_deleteManufacturer", arParms)
        Return rowsaffected
    End Function
    Shared Function GetProductWiseSale(ByVal Rbid As Integer, ByVal CompanyId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@Rbid", SqlDbType.Int)
        para(2).Value = Rbid
        para(3) = New SqlParameter("@CompanyId ", SqlDbType.Int)
        para(3).Value = CompanyId
        para(4) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(4).Value = StartDate
        para(5) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(5).Value = EndDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_AreaAnalysisReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBuyerWiseSale(ByVal Rbid As Integer, ByVal CompanyId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@Rbid", SqlDbType.Int)
        para(2).Value = Rbid
        para(3) = New SqlParameter("@CompanyId ", SqlDbType.Int)
        para(3).Value = CompanyId
        para(4) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(4).Value = StartDate
        para(5) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(5).Value = EndDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_rptMfg_Buyerwisesale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
