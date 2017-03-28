Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DepreciationRateDB
    Shared Function GetDepreciationRate(ByVal c As DepreiciationRate) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = c.Depreciation_ID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDepreciationRate", arParms)
        Return ds
    End Function
    Shared Function GetDepreciationCmpRpt() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_DepreciationRpt")
        Return ds.Tables(0)
    End Function
    Shared Function insert(ByVal c As DepreiciationRate) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@CommodityName", SqlDbType.VarChar, 50)
        arParms(0).Value = c.CommodityName
        arParms(1) = New SqlParameter("@CommodityRate", SqlDbType.Float)
        arParms(1).Value = c.CommodityRate
        arParms(2) = New SqlParameter("@Comodity_CompanyRates", SqlDbType.Float)
        arParms(2).Value = c.Comodity_CompanyRates
        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")
        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertDepreciationRate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CheckDuplicate(ByVal s As DepreiciationRate) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@Name", SqlDbType.VarChar, 50)
        para(0).Value = s.CommodityName
        para(1) = New SqlParameter("@Comodity_CompanyRates", SqlDbType.Float)
        para(1).Value = s.Comodity_CompanyRates
        para(2) = New SqlParameter("@CommodityRate", SqlDbType.Float)
        para(2).Value = s.CommodityRate
        para(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("BranchCode")
        para(4) = New SqlParameter("@id", SqlDbType.Int)
        para(4).Value = s.Depreciation_ID

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetDuplicateDepreciation", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function

    Shared Function Update(ByVal c As DepreiciationRate) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@Depreciation_ID", SqlDbType.Int)
        arParms(0).Value = c.Depreciation_ID

        arParms(1) = New SqlParameter("@CommodityName", SqlDbType.VarChar, 50)
        arParms(1).Value = c.CommodityName

        arParms(2) = New SqlParameter("@CommodityRate", SqlDbType.Float)
        arParms(2).Value = c.CommodityRate

        arParms(3) = New SqlParameter("@Comodity_CompanyRates", SqlDbType.Float)
        arParms(3).Value = c.Comodity_CompanyRates
        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateDepreciationRate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Depreciation_ID", SqlDbType.BigInt)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteDeprecRate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function RptDepreciationRate(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDepreciationRate", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function GetAssetTypecombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}

        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")

        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("Office")
        
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetAssetTypeCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetDepreciationRateRpt() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = 0
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDepreciationRate", arParms)
        Return ds.Tables(0)
    End Function
End Class
