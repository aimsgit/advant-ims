Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class Mfg_DLStockEntry
    Public Function GetSalesOrder() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlSaleOrder", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetManufacturerMFG() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlManufaturerMFG", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetManufacturerMKT() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}
            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlManufaturerMKT", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function ProductComboD(ByVal Id As Integer) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Id", SqlDbType.Int)
        param(2).Value = Id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProductName", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function UnitCombo() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlUnit", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetMultiCurrency() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMultiCurrency", para)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function fillProduct(ByVal autoid As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@ProductAutoNo", SqlDbType.Int)
        param(0).Value = autoid
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockEntryFill", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function FillSaleProduct(ByVal autoid As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@ProductAutoNo", SqlDbType.Int)
        param(0).Value = autoid
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductFill", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function fillProductBatch(ByVal autoid As Integer, ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@ProductAutoNo", SqlDbType.Int)
        param(0).Value = autoid
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch_id", SqlDbType.Int)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductBatchDetails", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function Mfg_getBatchInvoiceNo(ByVal autoid As Integer, ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(3) {}
        param(0) = New SqlParameter("@ProductID", SqlDbType.Int)
        param(0).Value = autoid
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        param(2).Value = batch
        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_getBatchInvoiceNo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetInvoiceNo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectInvoiceNo", arParms)
        Return ds.Tables(0)
    End Function
    Public Function Insert(ByVal i As Mfg_ELStockEntry) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(37) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(0).Value = i.Currency
        arParms(1) = New SqlParameter("@ExchangeRate", SqlDbType.Money)
        arParms(1).Value = i.ExchangeRate
        arParms(2) = New SqlParameter("@Productid", SqlDbType.Int)
        arParms(2).Value = i.Productid
        arParms(3) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(3).Value = i.BatchId
        arParms(4) = New SqlParameter("@Expiry", SqlDbType.DateTime)
        arParms(4).Value = i.Expiry
        arParms(5) = New SqlParameter("@PurchaseDeal", SqlDbType.Float)
        arParms(5).Value = i.PurchaseDeal
        arParms(6) = New SqlParameter("@PurchaseDeal1", SqlDbType.Float)
        arParms(6).Value = i.PurchaseDeal1
        arParms(7) = New SqlParameter("@Qty", SqlDbType.Float)
        arParms(7).Value = i.Qty
        arParms(8) = New SqlParameter("@Unit", SqlDbType.Int)
        arParms(8).Value = i.Unit
        arParms(9) = New SqlParameter("@MFG", SqlDbType.Int)
        arParms(9).Value = i.MFG
        arParms(10) = New SqlParameter("@MKT", SqlDbType.Int)
        arParms(10).Value = i.MKT
        arParms(11) = New SqlParameter("@Packing", SqlDbType.VarChar, 50)
        arParms(11).Value = i.Packing
        arParms(12) = New SqlParameter("@SaleRate", SqlDbType.Money)
        arParms(12).Value = i.SaleRate
        arParms(13) = New SqlParameter("@PurchRate", SqlDbType.Money)
        arParms(13).Value = i.PurchRate
        arParms(14) = New SqlParameter("@MRP", SqlDbType.Money)
        arParms(14).Value = i.MRP
        arParms(15) = New SqlParameter("@Discount", SqlDbType.Float)
        arParms(15).Value = i.Discount
        arParms(16) = New SqlParameter("@Discountamt", SqlDbType.Float)
        arParms(16).Value = i.Discountamt
        arParms(17) = New SqlParameter("@Taxon", SqlDbType.VarChar, 50)
        arParms(17).Value = i.Taxon
        arParms(18) = New SqlParameter("@TaxAB", SqlDbType.VarChar, 50)
        arParms(18).Value = i.TaxAB
        arParms(19) = New SqlParameter("@TaxPlan", SqlDbType.Int)
        arParms(19).Value = i.TaxPlan
        arParms(20) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("UserCode")
        arParms(21) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(21).Value = HttpContext.Current.Session("EmpCode")
        arParms(22) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("BranchCode")
        arParms(23) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(23).Value = i.Amount
        arParms(24) = New SqlParameter("@FlatRate", SqlDbType.Money)
        arParms(24).Value = i.flatRate
        arParms(25) = New SqlParameter("@Purchase_VAT", SqlDbType.Float)
        arParms(25).Value = i.VAT
        arParms(26) = New SqlParameter("@Purchase_CST", SqlDbType.Float)
        arParms(26).Value = i.CST
        arParms(27) = New SqlParameter("@ProductType", SqlDbType.Int)
        arParms(27).Value = i.ProductType
        arParms(28) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(28).Value = i.InvoiceID
        arParms(29) = New SqlParameter("@FinalAmount", SqlDbType.Money)
        arParms(29).Value = i.FinalAmt
        '-------------------------------------------------------------------------------------------------
        arParms(30) = New SqlParameter("@BatchName", SqlDbType.VarChar, 50)
        arParms(30).Value = i.Batch
        arParms(31) = New SqlParameter("@Deal", SqlDbType.Money)
        arParms(31).Value = i.Deal
        arParms(32) = New SqlParameter("@free", SqlDbType.Money)
        arParms(32).Value = i.Free
        arParms(33) = New SqlParameter("@sngPurchRate", SqlDbType.Money)
        arParms(33).Value = i.sngPurchRate
        arParms(34) = New SqlParameter("@sngTradeDiscount", SqlDbType.Money)
        arParms(34).Value = i.sngTradeDiscount
        arParms(35) = New SqlParameter("@sngFlatDiscount", SqlDbType.Money)
        arParms(35).Value = i.sngFlatDiscount
        arParms(36) = New SqlParameter("@VATRate", SqlDbType.Money)
        arParms(36).Value = i.VATRate
        arParms(37) = New SqlParameter("@CSTRate", SqlDbType.Money)
        arParms(37).Value = i.CSTRate
        Try
            'SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntry", arParms)

            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntry", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function UpdateRecord(ByVal i As Mfg_ELStockEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(37) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(0).Value = i.Currency
        arParms(1) = New SqlParameter("@ExchangeRate", SqlDbType.Money)
        arParms(1).Value = i.ExchangeRate
        arParms(2) = New SqlParameter("@Productid", SqlDbType.Int)
        arParms(2).Value = i.Productid
        arParms(3) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(3).Value = i.BatchId
        arParms(4) = New SqlParameter("@Expiry", SqlDbType.DateTime)
        arParms(4).Value = i.Expiry
        arParms(5) = New SqlParameter("@PurchaseDeal", SqlDbType.Float)
        arParms(5).Value = i.PurchaseDeal
        arParms(6) = New SqlParameter("@PurchaseDeal1", SqlDbType.Float)
        arParms(6).Value = i.PurchaseDeal1
        arParms(7) = New SqlParameter("@Qty", SqlDbType.Float)
        arParms(7).Value = i.Qty
        arParms(8) = New SqlParameter("@Unit", SqlDbType.Int)
        arParms(8).Value = i.Unit
        arParms(9) = New SqlParameter("@MFG", SqlDbType.Int)
        arParms(9).Value = i.MFG
        arParms(10) = New SqlParameter("@MKT", SqlDbType.Int)
        arParms(10).Value = i.MKT
        arParms(11) = New SqlParameter("@Packing", SqlDbType.VarChar, 50)
        arParms(11).Value = i.Packing
        arParms(12) = New SqlParameter("@SaleRate", SqlDbType.Money)
        arParms(12).Value = i.SaleRate
        arParms(13) = New SqlParameter("@PurchRate", SqlDbType.Money)
        arParms(13).Value = i.PurchRate
        arParms(14) = New SqlParameter("@MRP", SqlDbType.Money)
        arParms(14).Value = i.MRP
        arParms(15) = New SqlParameter("@Discount", SqlDbType.Float)
        arParms(15).Value = i.Discount
        arParms(16) = New SqlParameter("@Discountamt", SqlDbType.Float)
        arParms(16).Value = i.Discountamt
        arParms(17) = New SqlParameter("@Taxon", SqlDbType.VarChar, 50)
        arParms(17).Value = i.Taxon
        arParms(18) = New SqlParameter("@TaxAB", SqlDbType.VarChar, 50)
        arParms(18).Value = i.TaxAB
        arParms(19) = New SqlParameter("@TaxPlan", SqlDbType.Int)
        arParms(19).Value = i.TaxPlan
        arParms(20) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(20).Value = HttpContext.Current.Session("UserCode")
        arParms(21) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(21).Value = HttpContext.Current.Session("EmpCode")
        arParms(22) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("BranchCode")
        arParms(23) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(23).Value = i.Amount
        arParms(24) = New SqlParameter("@FlatRate", SqlDbType.Money)
        arParms(24).Value = i.flatRate
        arParms(25) = New SqlParameter("@Purchase_VAT", SqlDbType.Float)
        arParms(25).Value = i.VAT
        arParms(26) = New SqlParameter("@Purchase_CST", SqlDbType.Float)
        arParms(26).Value = i.CST
        arParms(27) = New SqlParameter("@ProductType", SqlDbType.Int)
        arParms(27).Value = i.ProductType
        arParms(28) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(28).Value = i.id
        arParms(29) = New SqlParameter("@FinalAmount", SqlDbType.Money)
        arParms(29).Value = i.FinalAmt
        '----------------------------------------------------------------------------------------------
        arParms(30) = New SqlParameter("@BatchName", SqlDbType.VarChar, 50)
        arParms(30).Value = i.Batch
        arParms(31) = New SqlParameter("@Deal", SqlDbType.Money)
        arParms(31).Value = i.Deal
        arParms(32) = New SqlParameter("@free", SqlDbType.Money)
        arParms(32).Value = i.Free
        arParms(33) = New SqlParameter("@sngPurchRate", SqlDbType.Money)
        arParms(33).Value = i.sngPurchRate
        arParms(34) = New SqlParameter("@sngTradeDiscount", SqlDbType.Money)
        arParms(34).Value = i.sngTradeDiscount
        arParms(35) = New SqlParameter("@sngFlatDiscount", SqlDbType.Money)
        arParms(35).Value = i.sngFlatDiscount
        arParms(36) = New SqlParameter("@VATRate", SqlDbType.Money)
        arParms(36).Value = i.VATRate
        arParms(37) = New SqlParameter("@CSTRate", SqlDbType.Money)
        arParms(37).Value = i.CSTRate
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateStockEntryDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Public Function filltax(ByVal i As Mfg_ELStockEntry) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@TaxPlan", SqlDbType.Int)
        arParms(0).Value = i.TaxPlan
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockEntryTaxFill", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function getStockEntry(ByVal s As Mfg_ELStockEntry) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
      
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = s.id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockEntry", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeteteM(ByVal s As Mfg_ELStockEntry) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = s.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteStockEntryM", arParms)
        Return rowsaffected
    End Function

    Public Function DeteteStockEntry(ByVal s As Mfg_ELStockEntry) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = s.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteStockEntry", arParms)
        Return rowsaffected
    End Function
    Public Function getStockEntryM(ByVal s As Mfg_ELStockEntry) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = s.PID

        arParms(3) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        arParms(3).Value = s.EntryDate

        arParms(4) = New SqlParameter("@TranscationId", SqlDbType.Int)
        arParms(4).Value = s.TranscationTypeid

        arParms(5) = New SqlParameter("@SOID", SqlDbType.Int)
        arParms(5).Value = s.SO

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockEntryM", arParms)
        Return ds.Tables(0)
    End Function
    Public Function getStockEntryReport(ByVal id As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@id", SqlDbType.VarChar, 1000)
        arParms(2).Value = id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockEntryReport", arParms)
        Return ds.Tables(0)
    End Function


    Public Function getStockEntryInvoice(ByVal s As Mfg_ELStockEntry) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(2).Value = s.InvoiceID


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockEntryInvoice", arParms)
        Return ds.Tables(0)
    End Function
    Public Function getCurrency(ByVal s As Mfg_ELStockEntry) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(2).Value = s.InvoiceID


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockEntryInvoice", arParms)
        Return ds.Tables(0)
    End Function

    Public Function InsertStock(ByVal i As Mfg_ELStockEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        arParms(0).Value = i.EntryDate
        arParms(1) = New SqlParameter("@TrascationTypeItem", SqlDbType.VarChar, 50)
        arParms(1).Value = i.TranscationType
        arParms(2) = New SqlParameter("@SO", SqlDbType.Int)
        arParms(2).Value = i.SO
        arParms(3) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(3).Value = i.Remarks
        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        arParms(7) = New SqlParameter("@TrascationTypeID", SqlDbType.Int)
        arParms(7).Value = i.TranscationTypeid
        arParms(8) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(8).Value = i.InvoiceID
        arParms(9) = New SqlParameter("@InvoiceNo", SqlDbType.VarChar, 50)
        arParms(9).Value = i.InvoiceNo
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntryM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function UpdateRecordM(ByVal i As Mfg_ELStockEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        arParms(0).Value = i.EntryDate
        arParms(1) = New SqlParameter("@TrascationTypeItem", SqlDbType.VarChar, 50)
        arParms(1).Value = i.TranscationType
        arParms(2) = New SqlParameter("@SO", SqlDbType.Int)
        arParms(2).Value = i.SO
        arParms(3) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(3).Value = i.Remarks
        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        arParms(7) = New SqlParameter("@TrascationTypeID", SqlDbType.Int)
        arParms(7).Value = i.TranscationTypeid
        arParms(8) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(8).Value = i.PID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateStockEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function PostPurchaseOrder(ByVal i As Mfg_ELStockEntry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0
        
        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode ", SqlDbType.NVarChar, 4000)
        arParms(3).Value = i.ChkID
        
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostStockEntry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function PostStatus(ByVal s As Mfg_ELStockEntry) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@PID", SqlDbType.Int)
        arParms(2).Value = s.PID

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetStockEntryPostStatus", arParms)
        Return ds.Tables(0)
    End Function
    Public Function RptStockEntrydate() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptStockEntry", arParms)
        Return ds.Tables(0)
    End Function


    Public Function RptStockEntry(ByVal StkEntrydate As Date, ByVal Startdate As Date, ByVal Enddate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@StkEntryDate", SqlDbType.Date)
        arParms(2).Value = StkEntrydate

        arParms(3) = New SqlParameter("@Startdate ", SqlDbType.Date)
        arParms(3).Value = Startdate

        arParms(4) = New SqlParameter("@Enddate", SqlDbType.Date)
        arParms(4).Value = Enddate

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStkEntryDetails", arParms)
        Return ds.Tables(0)
    End Function

End Class
