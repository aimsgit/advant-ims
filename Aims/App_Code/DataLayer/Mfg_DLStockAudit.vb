Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLStockAudit
    Public Function ProductComboD(ByVal Suppid As Integer) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@Supplier", SqlDbType.Int)
        param(0).Value = Suppid
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")
       
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectStockProduct", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetDrilldownSupplireWiseStock(ByVal Product_ID As Integer) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@Product_ID", SqlDbType.Int)
        param(0).Value = Product_ID
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetDrillDownSupplireWiseStock", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Public Function getSupplierWiseStock(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal SupplierId As Integer) As System.Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(4) {}
    '    arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    arParms(0).Value = HttpContext.Current.Session("Office")

    '    arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    arParms(1).Value = HttpContext.Current.Session("BranchCode")

    '    arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
    '    arParms(2).Value = fromdate

    '    arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
    '    arParms(3).Value = todate

    '    arParms(4) = New SqlParameter("@SupplierId", SqlDbType.Int)
    '    arParms(4).Value = SupplierId
    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSupplierWiseStock", arParms)

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    Public Function getSupplierWiseStock_Epired(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal SupplierId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        arParms(4) = New SqlParameter("@SupplierId", SqlDbType.Int)
        arParms(4).Value = SupplierId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSupplierWiseStock_Expired", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Public Function getProductsaleDetails(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Product As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        arParms(4) = New SqlParameter("@Product", SqlDbType.Int)
        arParms(4).Value = Product
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductSaleDetails", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getSupplierWiseStock(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal SupplierId As Integer, ByVal expired As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        arParms(4) = New SqlParameter("@SupplierId", SqlDbType.Int)
        arParms(4).Value = SupplierId

        arParms(5) = New SqlParameter("@expired", SqlDbType.VarChar, 10)
        arParms(5).Value = expired
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSupplierWiseStock", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getSaleInvoiceSummary(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Party As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        arParms(4) = New SqlParameter("@Party", SqlDbType.Int)
        arParms(4).Value = Party
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleInvoiceSummary", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getPendingSo(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Party As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        arParms(4) = New SqlParameter("@Party", SqlDbType.Int)
        arParms(4).Value = Party
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPendingSo", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function getSEPerformance(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Party As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        arParms(4) = New SqlParameter("@Party", SqlDbType.Int)
        arParms(4).Value = Party
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSEPerformance", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetDueSlipDetails(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Party_Id As Integer, ByVal Sale_Invoice_No As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        arParms(4) = New SqlParameter("@Party_Id", SqlDbType.Int)
        arParms(4).Value = Party_Id

        arParms(5) = New SqlParameter("@Sale_Invoice_No", SqlDbType.Int)
        arParms(5).Value = Sale_Invoice_No
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetDueSlip", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getFastMovingItems(ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetFastMovingItems", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getSaleInvoiceSummary(ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleInvSummaryReport", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getSaleRegisterSummary(ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleRegisterSummary", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getProductWiseNearsetEx(ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Product As Integer, ByVal PurchaseInvNo As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        arParms(4) = New SqlParameter("@Product", SqlDbType.Int)
        arParms(4).Value = Product

        arParms(5) = New SqlParameter("@PurchaseInvNo", SqlDbType.Int)
        arParms(5).Value = PurchaseInvNo
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductWiseNearestEx", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function BatchCombo(ByVal ProductId As Int16) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@ProductId", SqlDbType.Int)
        param(2).Value = ProductId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetBatch", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetInvoiceNo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectStockAudit", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function AutoGenerateNo(ByVal EL As Mfg_ELStockAudit) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectStockAudit", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetStockAuditReport(ByVal FromDate As Date, ByVal Todate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        para(2).Value = FromDate
        para(3) = New SqlParameter("@Todate", SqlDbType.DateTime)
        para(3).Value = Todate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_StockAuditReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSaleDiscountReport(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(3).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SaleDiscountReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPurchaseInvoiceSummary(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(3).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_PurchaseInvoiceSummary", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetProductPriceList(ByVal ProductId As Integer, ByVal ManufacturerId As Integer, ByVal suppId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@ProductId", SqlDbType.Int)
        para(2).Value = ProductId
        para(3) = New SqlParameter("@Category ", SqlDbType.Int)
        para(3).Value = ManufacturerId

        para(4) = New SqlParameter("@suppId ", SqlDbType.Int)
        para(4).Value = suppId



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ProductPriceList", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSEAnalysis(ByVal SEId As Integer, ByVal CompanyId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@SEId", SqlDbType.Int)
        para(2).Value = SEId
        para(3) = New SqlParameter("@CompanyId ", SqlDbType.Int)
        para(3).Value = CompanyId
        para(4) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(4).Value = StartDate
        para(4) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(4).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ProductPriceList", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetProductwisesale(ByVal AreaId As Integer, ByVal Fromdate As DateTime, ByVal Todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@AreaId", SqlDbType.Int)
        para(2).Value = AreaId

        para(3) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(3).Value = Fromdate
        para(4) = New SqlParameter("@todate ", SqlDbType.DateTime)
        para(4).Value = Todate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_AreaWiseProductWiseSale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Getcustomerwisesalesummary(ByVal AreaId As Integer, ByVal Fromdate As DateTime, ByVal Todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@AreaCode", SqlDbType.Int)
        para(2).Value = AreaId

        para(3) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(3).Value = Fromdate
        para(4) = New SqlParameter("@todate ", SqlDbType.DateTime)
        para(4).Value = Todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_AreaWiseCustomerWiseSaleSummary", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAreawisesale(ByVal AreaId As Integer, ByVal CompanyId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@AreaId", SqlDbType.Int)
        para(2).Value = AreaId
        para(3) = New SqlParameter("@CompanyId ", SqlDbType.Int)
        para(3).Value = CompanyId
        para(4) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(4).Value = StartDate
        para(5) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(5).Value = EndDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptAreaWiseSale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RptInventoryShortage(ByVal product As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
       
        para(1) = New SqlParameter("@product", SqlDbType.Int)
        para(1).Value = product
       
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_RptInventoryShortage]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAreaAnalysis(ByVal AreaId As Integer, ByVal Fromdate As DateTime, ByVal Todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@AreaCode", SqlDbType.Int)
        para(2).Value = AreaId
        para(3) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(3).Value = Fromdate
        para(4) = New SqlParameter("@todate ", SqlDbType.DateTime)
        para(4).Value = Todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_AreaWiseCustomerWiseSale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSupplierWisePriceList(ByVal SupplierId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@SupplierId ", SqlDbType.Int)
        para(2).Value = SupplierId



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SupplierWisePriceList", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Qty(ByVal EL As Mfg_ELStockAudit) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        para(2).Value = EL.Batch
        para(3) = New SqlParameter("@ProdId", SqlDbType.Int)
        para(3).Value = EL.ProductID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetQtyFromBatch", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function InsertSaleInvoiceDetails(ByVal EL As Mfg_ELStockAudit) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(29) {}
        Dim rowsAffected As Integer = 0
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        para(1).Value = EL.Remarks


        para(2) = New SqlParameter("@SupplierId", SqlDbType.Int)
        para(2).Value = EL.Supp_ID

        'para(3) = New SqlParameter("@StkAuditDate", SqlDbType.DateTime)
        'para(3).Value = EL.Stock_Audit

        para(3) = New SqlParameter("@QtyinStk", SqlDbType.Float)
        para(3).Value = EL.QtyinStk

        para(4) = New SqlParameter("@AuditNo", SqlDbType.Int)
        para(4).Value = EL.AuditNo

        para(5) = New SqlParameter("@Productid", SqlDbType.Int)
        para(5).Value = EL.ProductID

        para(6) = New SqlParameter("@Batchid", SqlDbType.Int)
        para(6).Value = EL.Batch

        'para(7) = New SqlParameter("@Qtyinstk", SqlDbType.Int)
        'para(7).Value = EL.QtyIn


        para(7) = New SqlParameter("@Qtyin", SqlDbType.Float)
        para(7).Value = EL.QtyIn


        para(8) = New SqlParameter("@Qtyout", SqlDbType.Float)
        para(8).Value = EL.QtyOut

        para(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(9).Value = HttpContext.Current.Session("EmpCode")

        para(10) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        para(10).Value = HttpContext.Current.Session("UserCode")

        para(11) = New SqlParameter("@Purchaseinvoiceid", SqlDbType.Int)
        para(11).Value = EL.Purchaseinvoiceid

        para(12) = New SqlParameter("@PRDID", SqlDbType.Int)
        para(12).Value = EL.PRDID

        para(13) = New SqlParameter("@Packingdetails", SqlDbType.VarChar, 50)
        para(13).Value = EL.Packingdetails

        para(14) = New SqlParameter("@RefDate", SqlDbType.Date)
        para(14).Value = EL.RefDate

        para(15) = New SqlParameter("@PurchaseRate", SqlDbType.Money)
        para(15).Value = EL.PurchaseRate

        para(16) = New SqlParameter("@TradeDisc", SqlDbType.Float)
        para(16).Value = EL.TradeDisc

        para(17) = New SqlParameter("@FlatDisc", SqlDbType.Float)
        para(17).Value = EL.FlatDisc

        para(18) = New SqlParameter("@PurchseTaxstrid", SqlDbType.Int)
        para(18).Value = EL.PurchseTaxstrid

        para(19) = New SqlParameter("@PurchseTaxBeforafterDisc", SqlDbType.Int)
        para(19).Value = EL.PurchseTaxBeforafterDisc

        para(20) = New SqlParameter("@PurchseTaxPlan", SqlDbType.Int)
        para(20).Value = EL.PurchseTaxPlan

        para(21) = New SqlParameter("@PurchseVAT", SqlDbType.Float)
        para(21).Value = EL.PurchseVAT

        para(22) = New SqlParameter("@PurchseCAT", SqlDbType.Float)
        para(22).Value = EL.PurchseCAT

        para(23) = New SqlParameter("@FlatRate", SqlDbType.Money)
        para(23).Value = EL.FlatRate

        para(24) = New SqlParameter("@SaleRate", SqlDbType.Money)
        para(24).Value = EL.SaleRate

        para(25) = New SqlParameter("@MRP", SqlDbType.Money)
        para(25).Value = EL.MRP

        para(26) = New SqlParameter("@CurrencyRate", SqlDbType.Float)
        para(26).Value = EL.CurrencyRate

        para(27) = New SqlParameter("@PurchaseVAT_Amount", SqlDbType.Money)
        para(27).Value = EL.PurchaseVAT_Amount

        para(28) = New SqlParameter("@PurchaseCST_Amount", SqlDbType.Money)
        para(28).Value = EL.PurchaseCST_Amount

        para(29) = New SqlParameter("@Stock_Date", SqlDbType.DateTime)
        para(29).Value = EL.Stock_Date
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertProdDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetSECompanyWise(ByVal CompanyId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@CompanyId ", SqlDbType.Int)
        para(2).Value = CompanyId
        para(3) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(3).Value = StartDate
        para(4) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(4).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_CompanywiseSale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSaleReturn(ByVal BuyerId As Integer, ByVal SaleReturnId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@BuyerId ", SqlDbType.Int)
        para(2).Value = BuyerId
        para(3) = New SqlParameter("@SaleReturnId ", SqlDbType.Int)
        para(3).Value = SaleReturnId
        para(4) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(4).Value = StartDate
        para(5) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(5).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SaleReturnReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSESupplierWise(ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(3).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptSupplierwiseSale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSEInvoiceWise(ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(3).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptInvoicewiseSale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Shared Function GetSEDailyWise(ByVal SEId As Integer, ByVal CompanyId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

    '    para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    para(0).Value = HttpContext.Current.Session("BranchCode")
    '    para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    para(1).Value = HttpContext.Current.Session("Office")
    '    para(2) = New SqlParameter("@SEId", SqlDbType.Int)
    '    para(2).Value = SEId
    '    para(3) = New SqlParameter("@CompanyId ", SqlDbType.Int)
    '    para(3).Value = CompanyId
    '    para(4) = New SqlParameter("@StartDate ", SqlDbType.Date)
    '    para(4).Value = StartDate
    '    para(4) = New SqlParameter("@EndDate ", SqlDbType.Date)
    '    para(4).Value = EndDate


    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ProductPriceList", para)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    Shared Function GetSEProductWise(ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(3).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptProductwiseSale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetProdDetails(ByVal EL As Mfg_ELStockAudit) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Supplierid", SqlDbType.Int)
        arParms(1).Value = EL.Supp_ID

        arParms(2) = New SqlParameter("@ProdId", SqlDbType.Int)
        arParms(2).Value = EL.ProductID


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProdDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetProdAddDetails(ByVal el As Mfg_ELStockAudit) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Supplierid", SqlDbType.Int)
        arParms(1).Value = el.Supp_ID

        arParms(2) = New SqlParameter("@AuditNo", SqlDbType.Int)
        arParms(2).Value = el.AuditNo


        arParms(3) = New SqlParameter("@Stkid", SqlDbType.Int)
        arParms(3).Value = el.Id



        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetProdAddDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteProdDetails(ByVal El As Mfg_ELStockAudit) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = El.Id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteProdDetails", param)
        Return rowsaffected
    End Function
    'Public Function UpdateProdDetails(ByVal i As Mfg_ELPurchaseInvoice) As Integer
    '    Dim ds As New DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim arParms() As SqlParameter = New SqlParameter(6) {}
    '    Dim rowsAffected As Integer = 0

    '    arParms(0) = New SqlParameter("@Supplier", SqlDbType.Int)
    '    arParms(0).Value = i.Supplier

    '    arParms(1) = New SqlParameter("@PurchInvNo", SqlDbType.VarChar, 50)
    '    arParms(1).Value = i.PurchaseInvoiceNo

    '    arParms(2) = New SqlParameter("@InvoiceDate", SqlDbType.DateTime)
    '    arParms(2).Value = i.InvoiceDate

    '    arParms(3) = New SqlParameter("@ReceiptDate", SqlDbType.DateTime)
    '    arParms(3).Value = i.ReceiptDate
    '    arParms(4) = New SqlParameter("@PaymentType", SqlDbType.Int)
    '    arParms(4).Value = i.PaymentType
    '    arParms(5) = New SqlParameter("@GRN", SqlDbType.Int)
    '    arParms(5).Value = i.GRN
    '    arParms(6) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
    '    arParms(6).Value = i.Remarks

    '    Try
    '        'SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntry", arParms)
    '        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePurchaseInvoiceM", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return rowsAffected
    'End Function
    Public Function GetSuppAuditDetails(ByVal el As Mfg_ELStockAudit) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Supp_ID", SqlDbType.VarChar, 50)
        arParms(1).Value = el.Supp_ID


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSupplierAuditDetails", arParms)
        Return ds.Tables(0)
    End Function

    Public Function GetSuppAuditDetail(ByVal el As Mfg_ELStockAudit) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@AuditNo", SqlDbType.Int)
        arParms(1).Value = el.AuditNo

        arParms(2) = New SqlParameter("@Supp_ID", SqlDbType.Int)
        arParms(2).Value = el.Supp_ID

        arParms(3) = New SqlParameter("@Stock_Date", SqlDbType.Date)
        arParms(3).Value = el.Stock_Date


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSupplierAuditDetail", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal El As Mfg_ELStockAudit) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(8) {}

            Parms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("EmpCode")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("UserCode")

            Parms(3) = New SqlParameter("@prodid", SqlDbType.Int)
            Parms(3).Value = El.ProductID

            Parms(4) = New SqlParameter("@Batchid", SqlDbType.VarChar, 50)
            Parms(4).Value = El.Batch

            Parms(5) = New SqlParameter("@Qtyin", SqlDbType.Float)
            Parms(5).Value = El.QtyIn

            Parms(6) = New SqlParameter("@Qtyout", SqlDbType.Float)
            Parms(6).Value = El.QtyOut


            Parms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
            Parms(7).Value = El.Remarks

            Parms(8) = New SqlParameter("@StkId", SqlDbType.Int)
            Parms(8).Value = El.Id

            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatestockAudit", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function GetBatchWisestock(ByVal CompanyId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@CompanyId ", SqlDbType.Int)
        para(2).Value = CompanyId
        para(3) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        para(3).Value = StartDate
        para(4) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(4).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_BatchWisReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetStockLevel(ByVal CompanyId As Integer, ByVal StartDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@CompanyId ", SqlDbType.Int)
        para(2).Value = CompanyId
        para(3) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        para(3).Value = StartDate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_StockLevelReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPurchaseInvoiceRegister(ByVal SupplierId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@SupplierId ", SqlDbType.Int)
        para(2).Value = SupplierId
        para(3) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(3).Value = StartDate
        para(4) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(4).Value = EndDate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptPurchaseInvoiceRegister", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSaleReturnRegister(ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(3).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SaleReturnRegister", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSaleStock(ByVal SupplierId As Integer, ByVal StartDate As Date, ByVal enddate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@SuppId ", SqlDbType.Int)
        para(2).Value = SupplierId
        para(3) = New SqlParameter("@startdate ", SqlDbType.Date)
        para(3).Value = StartDate

        para(4) = New SqlParameter("@enddate ", SqlDbType.Date)
        para(4).Value = enddate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleStockNew", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSaleInvoiceRegister(ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        para(2).Value = StartDate
        para(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        para(3).Value = EndDate


        Try
            'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SaleInvoiceRegister", para)
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSIRegister", para)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RptStockAudit(ByVal product As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@product", SqlDbType.Int)
        para(1).Value = product

        para(2) = New SqlParameter("@FromDate", SqlDbType.Date)
        para(2).Value = FromDate

        para(3) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(3).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_RptStockAudit]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetStockIssue(ByVal CatId As Integer, ByVal StartDate As Date, ByVal enddate As Date) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@CatId ", SqlDbType.Int)
        para(2).Value = CatId

        para(3) = New SqlParameter("@startdate ", SqlDbType.Date)
        para(3).Value = StartDate

        para(4) = New SqlParameter("@enddate ", SqlDbType.Date)
        para(4).Value = enddate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleAndIssue", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetSaleReturnReport(ByVal Buyer As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Buyer", SqlDbType.Int)
        arParms(2).Value = Buyer


        arParms(3) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(3).Value = fromdate

        arParms(4) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(4).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_GetSaleReturn", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetReceiptsDelay(ByVal Buyer As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Buyer", SqlDbType.Int)
        arParms(2).Value = Buyer


        arParms(3) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(3).Value = fromdate

        arParms(4) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(4).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_GetReceiptDelay", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetOverdueStatement(ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_OverdueStatement", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBuyerwisePerformance(ByVal Buyer As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Buyer", SqlDbType.Int)
        arParms(2).Value = Buyer

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_BuyerwisePerformance", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAreawiseSales(ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        arParms(2) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(2).Value = fromdate

        arParms(3) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(3).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_GetAreawiseSale", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAccountPayable(ByVal PartyTypeId As Integer, ByVal PartyNameId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@PartyTypeId", SqlDbType.Int)
        arParms(2).Value = PartyTypeId
        arParms(3) = New SqlParameter("@PartyNameId", SqlDbType.Int)
        arParms(3).Value = PartyNameId


        arParms(4) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(4).Value = fromdate

        arParms(5) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(5).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_GetAccountPayable", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
