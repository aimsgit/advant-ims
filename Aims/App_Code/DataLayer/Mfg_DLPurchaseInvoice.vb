Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLPurchaseInvoice
    Public Function getPurchaseInv(ByVal ID As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.VarChar, 1000)
        arParms(1).Value = ID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_PurchaseInvoiceReceipt", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getPurchaseInv2(ByVal ID As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.VarChar, 1000)
        arParms(1).Value = ID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetGRN_Details", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetPurchaseOrder2(ByVal id As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.VarChar, 1000)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseOrder", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
   

    Public Function GetPurchaseOrder() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlPurchaseOrder", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Shared Function GetSupplierAutoFill(ByVal El As Mfg_ELPurchaseInvoice) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
            Parms(2).Value = El.Supplier
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSupplierBalance", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetSupplierDetails3(ByVal Product_Id As Integer) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Product_Id", SqlDbType.Int)
            arParms(1).Value = Product_Id

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSupplierDetailsDDL3", arParms)
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
    Public Function PaymentMethodDDL() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetPaymentMethodDDL", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetSupplierDetails() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(0) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")



            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSupplierDetailsDDL", arParms)
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
    Shared Function GetInvoiceNo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectPurchaseInvoiceNo", arParms)
        Return ds.Tables(0)
    End Function
    Public Function Insert(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(36) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Supplier", SqlDbType.Int)
        arParms(0).Value = i.Supplier
        arParms(1) = New SqlParameter("@PurchInvNo", SqlDbType.VarChar, 50)
        arParms(1).Value = i.PurchaseInvoiceNo
        arParms(2) = New SqlParameter("@InvoiceDate", SqlDbType.DateTime)
        arParms(2).Value = i.InvoiceDate
        arParms(3) = New SqlParameter("@ReceiptDate", SqlDbType.DateTime)
        arParms(3).Value = i.ReceiptDate
        arParms(4) = New SqlParameter("@PaymentType", SqlDbType.Int)
        arParms(4).Value = i.PaymentType
        arParms(5) = New SqlParameter("@GRN", SqlDbType.VarChar, 50)
        arParms(5).Value = i.GRN
        arParms(6) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(6).Value = i.Remarks
        arParms(7) = New SqlParameter("@MiscExpValue", SqlDbType.Money)
        arParms(7).Value = i.MiscExpValue
        arParms(8) = New SqlParameter("@FlatDiscount", SqlDbType.Money)
        arParms(8).Value = i.FlatDiscount
        arParms(9) = New SqlParameter("@FlatDiscountAmt", SqlDbType.Money)
        arParms(9).Value = i.FlatDiscountAmt
        arParms(10) = New SqlParameter("@DifferenceAmount", SqlDbType.Money)
        arParms(10).Value = i.DiffAmt
        arParms(11) = New SqlParameter("@TaxDiff", SqlDbType.Money)
        arParms(11).Value = i.TaxDiff
        arParms(12) = New SqlParameter("@DiscDiff", SqlDbType.Money)
        arParms(12).Value = i.DiscDiff
        arParms(13) = New SqlParameter("@ExciseDiff", SqlDbType.Money)
        arParms(13).Value = i.ExiciseDiff
        arParms(14) = New SqlParameter("@RoundOff", SqlDbType.Money)
        arParms(14).Value = i.RoundOff
        arParms(15) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("EmpCode")
        arParms(16) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("BranchCode")
        arParms(17) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("Office")
        arParms(18) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(18).Value = HttpContext.Current.Session("UserCode")
        arParms(19) = New SqlParameter("@InvoiceID", SqlDbType.Int)
        arParms(19).Value = i.PurchaseInvoiceID
        arParms(20) = New SqlParameter("@PONO", SqlDbType.Int)
        arParms(20).Value = i.PONO
        arParms(21) = New SqlParameter("@DispatchFrom", SqlDbType.VarChar, 50)
        arParms(21).Value = i.DispatchFrom
        arParms(22) = New SqlParameter("@DispatchTo", SqlDbType.VarChar, 50)
        arParms(22).Value = i.DispatchTo
        arParms(23) = New SqlParameter("@TransporatationId", SqlDbType.Int)
        arParms(23).Value = i.TransporatationId
        arParms(24) = New SqlParameter("@TransportationNo", SqlDbType.VarChar, 50)
        arParms(24).Value = i.TransportationNo
        arParms(25) = New SqlParameter("@ReceivedBy", SqlDbType.VarChar, 50)
        arParms(25).Value = i.ReceivedBy
        arParms(26) = New SqlParameter("@ReceivedAddress", SqlDbType.VarChar, 250)
        arParms(26).Value = i.ReceivedAddress
        arParms(27) = New SqlParameter("@PaymentDate", SqlDbType.DateTime)
        arParms(27).Value = i.PaymentDate
        arParms(28) = New SqlParameter("@TotalAmount", SqlDbType.Money)
        arParms(28).Value = i.TotalAmount
        arParms(29) = New SqlParameter("@TotalDiscAmount", SqlDbType.Money)
        arParms(29).Value = i.TradeDiscAmount
        arParms(30) = New SqlParameter("@TotalExciseDuty", SqlDbType.Money)
        arParms(30).Value = i.TotalExcise
        arParms(31) = New SqlParameter("@TotalVATAmount", SqlDbType.Money)
        arParms(31).Value = i.TotalVATAmount
        arParms(32) = New SqlParameter("@TotalCSTAmount", SqlDbType.Money)
        arParms(32).Value = i.TotalCSTAmount
        arParms(33) = New SqlParameter("@TotalFinalAmount", SqlDbType.Money)
        arParms(33).Value = i.TotalFinalAmount
        arParms(34) = New SqlParameter("@TotalGrandFinalAmount", SqlDbType.Money)
        arParms(34).Value = i.GrandFinalAmount
        arParms(35) = New SqlParameter("@MRPValue", SqlDbType.Money)
        arParms(35).Value = i.MRPTotalValue
        arParms(36) = New SqlParameter("@InvoiceType", SqlDbType.VarChar, 100)
        arParms(36).Value = i.Invoice_Type

        Try
            'SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntry", arParms)
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPurchaseInvoiceM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function Update(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(37) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Supplier", SqlDbType.Int)
        arParms(0).Value = i.Supplier
        arParms(1) = New SqlParameter("@PurchInvNo", SqlDbType.VarChar, 50)
        arParms(1).Value = i.PurchaseInvoiceNo
        arParms(2) = New SqlParameter("@InvoiceDate", SqlDbType.DateTime)
        arParms(2).Value = i.InvoiceDate
        arParms(3) = New SqlParameter("@ReceiptDate", SqlDbType.DateTime)
        arParms(3).Value = i.ReceiptDate
        arParms(4) = New SqlParameter("@PaymentType", SqlDbType.Int)
        arParms(4).Value = i.PaymentType
        arParms(5) = New SqlParameter("@GRN", SqlDbType.VarChar, 50)
        arParms(5).Value = i.GRN
        arParms(6) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(6).Value = i.Remarks
        arParms(7) = New SqlParameter("@MiscExpValue", SqlDbType.Money)
        arParms(7).Value = i.MiscExpValue
        arParms(8) = New SqlParameter("@FlatDiscount", SqlDbType.Money)
        arParms(8).Value = i.FlatDiscount
        arParms(9) = New SqlParameter("@FlatDiscountAmt", SqlDbType.Money)
        arParms(9).Value = i.FlatDiscountAmt
        arParms(10) = New SqlParameter("@DifferenceAmount", SqlDbType.Money)
        arParms(10).Value = i.DiffAmt
        arParms(11) = New SqlParameter("@TaxDiff", SqlDbType.Money)
        arParms(11).Value = i.TaxDiff
        arParms(12) = New SqlParameter("@DiscDiff", SqlDbType.Money)
        arParms(12).Value = i.DiscDiff
        arParms(13) = New SqlParameter("@ExciseDiff", SqlDbType.Money)
        arParms(13).Value = i.ExiciseDiff
        arParms(14) = New SqlParameter("@RoundOff", SqlDbType.Money)
        arParms(14).Value = i.RoundOff
        arParms(15) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("EmpCode")
        arParms(16) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("BranchCode")
        arParms(17) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("Office")
        arParms(18) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(18).Value = HttpContext.Current.Session("UserCode")
        arParms(19) = New SqlParameter("@InvoiceID", SqlDbType.Int)
        arParms(19).Value = i.PurchaseInvoiceID
        arParms(20) = New SqlParameter("@PONO", SqlDbType.Int)
        arParms(20).Value = i.PONO
        arParms(21) = New SqlParameter("@DispatchFrom", SqlDbType.VarChar, 50)
        arParms(21).Value = i.DispatchFrom
        arParms(22) = New SqlParameter("@DispatchTo", SqlDbType.VarChar, 50)
        arParms(22).Value = i.DispatchTo
        arParms(23) = New SqlParameter("@TransporatationId", SqlDbType.Int)
        arParms(23).Value = i.TransporatationId
        arParms(24) = New SqlParameter("@TransportationNo", SqlDbType.VarChar, 50)
        arParms(24).Value = i.TransportationNo
        arParms(25) = New SqlParameter("@ReceivedBy", SqlDbType.VarChar, 50)
        arParms(25).Value = i.ReceivedBy
        arParms(26) = New SqlParameter("@ReceivedAddress", SqlDbType.VarChar, 250)
        arParms(26).Value = i.ReceivedAddress
        arParms(27) = New SqlParameter("@PaymentDate", SqlDbType.DateTime)
        arParms(27).Value = i.PaymentDate
        arParms(28) = New SqlParameter("@PID", SqlDbType.Int)
        arParms(28).Value = i.PID
        arParms(29) = New SqlParameter("@TotalAmount", SqlDbType.Money)
        arParms(29).Value = i.TotalAmount
        arParms(30) = New SqlParameter("@TotalDiscAmount", SqlDbType.Money)
        arParms(30).Value = i.TradeDiscAmount
        arParms(31) = New SqlParameter("@TotalExciseDuty", SqlDbType.Money)
        arParms(31).Value = i.ExciseDuty
        arParms(32) = New SqlParameter("@TotalVATAmount", SqlDbType.Money)
        arParms(32).Value = i.TotalVATAmount
        arParms(33) = New SqlParameter("@TotalCSTAmount", SqlDbType.Money)
        arParms(33).Value = i.TotalCSTAmount
        arParms(34) = New SqlParameter("@TotalFinalAmount", SqlDbType.Money)
        arParms(34).Value = i.TotalFinalAmount
        arParms(35) = New SqlParameter("@TotalGrandFinalAmount", SqlDbType.Money)
        arParms(35).Value = i.GrandFinalAmount
        arParms(36) = New SqlParameter("@MRPValue", SqlDbType.Money)
        arParms(36).Value = i.MRPTotalValue
        arParms(37) = New SqlParameter("@InvoiceType", SqlDbType.VarChar, 100)
        arParms(37).Value = i.Invoice_Type
        Try
            'SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntry", arParms)
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePurchaseInvoiceM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function InsertPurchaseInvoice(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(41) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(0).Value = i.Currency
        arParms(1) = New SqlParameter("@ExchangeRate", SqlDbType.Money)
        arParms(1).Value = i.ExchangeRate
        arParms(2) = New SqlParameter("@Productid", SqlDbType.Int)
        arParms(2).Value = i.ProductId
        arParms(3) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(3).Value = i.BatchID
        arParms(4) = New SqlParameter("@Expiry", SqlDbType.DateTime)
        arParms(4).Value = i.Expiry
        arParms(5) = New SqlParameter("@PurchaseDeal", SqlDbType.Float)
        arParms(5).Value = i.PurchaseDeal
        arParms(6) = New SqlParameter("@PurchaseDeal1", SqlDbType.Float)
        arParms(6).Value = i.PurchaseDeal1
        arParms(7) = New SqlParameter("@QtyAccept", SqlDbType.Float)
        arParms(7).Value = i.QtyAccept
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
        arParms(16) = New SqlParameter("@Discountamt", SqlDbType.Money)
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
        arParms(23) = New SqlParameter("@Excise", SqlDbType.Money)
        arParms(23).Value = i.Excise
        arParms(24) = New SqlParameter("@QtyRecvd", SqlDbType.Float)
        arParms(24).Value = i.QtyRecd
        arParms(25) = New SqlParameter("@Purchase_VAT", SqlDbType.Float)
        arParms(25).Value = i.VAT
        arParms(26) = New SqlParameter("@Purchase_CST", SqlDbType.Float)
        arParms(26).Value = i.CST
        arParms(27) = New SqlParameter("@ProductType", SqlDbType.Int)
        arParms(27).Value = i.ProductType
        arParms(28) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(28).Value = i.RemarksProduct
        arParms(29) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(29).Value = i.HIDPurchaseInvoice
        arParms(30) = New SqlParameter("@PurchRateIV", SqlDbType.VarChar, 50)
        arParms(30).Value = i.PurchRateIV
        arParms(31) = New SqlParameter("@FlatRate", SqlDbType.Money)
        arParms(31).Value = i.FlatRate
        arParms(32) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(32).Value = i.Amount
        arParms(33) = New SqlParameter("@FinalAmount", SqlDbType.Money)
        arParms(33).Value = i.FinalAmount
        arParms(34) = New SqlParameter("@Batch_Name", SqlDbType.VarChar, 50)
        arParms(34).Value = i.Batch
        '------------------------------------------------------------------------------------------------------'
        arParms(35) = New SqlParameter("@Qty", SqlDbType.Money)
        arParms(35).Value = i.Qty
        arParms(36) = New SqlParameter("@free", SqlDbType.Money)
        arParms(36).Value = i.free
        arParms(37) = New SqlParameter("@sngPurchRate", SqlDbType.Money)
        arParms(37).Value = i.sngPurchRate
        arParms(38) = New SqlParameter("@sngTradeDiscount", SqlDbType.Money)
        arParms(38).Value = i.sngTradeDiscount
        arParms(39) = New SqlParameter("@sngFlatDiscount", SqlDbType.Money)
        arParms(39).Value = i.sngFlatDiscount
        arParms(40) = New SqlParameter("@VATRate", SqlDbType.Money)
        arParms(40).Value = i.VATRate
        arParms(41) = New SqlParameter("@CSTRate", SqlDbType.Money)
        arParms(41).Value = i.CSTRate
        Try
            'SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntry", arParms)
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPurchaseInvoice", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function


    Public Function InsertToPost(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@InvoiceID", SqlDbType.Int)
        arParms(3).Value = i.HIDPurchaseInvoice

        Try
            'SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntry", arParms)
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPurchaseInvoicePosttoStock", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function UpdatePurchaseInvoiceDetails(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(42) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(0).Value = i.Currency
        arParms(1) = New SqlParameter("@ExchangeRate", SqlDbType.Money)
        arParms(1).Value = i.ExchangeRate
        arParms(2) = New SqlParameter("@Productid", SqlDbType.Int)
        arParms(2).Value = i.ProductId
        arParms(3) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(3).Value = i.BatchID
        If i.Expiry = "01/01/1900" Then
            arParms(4) = New SqlParameter("@Expiry", SqlDbType.DateTime)
            arParms(4).Value = System.DBNull.Value
        Else
            arParms(4) = New SqlParameter("@Expiry", SqlDbType.DateTime)
            arParms(4).Value = i.Expiry
        End If
        arParms(5) = New SqlParameter("@PurchaseDeal", SqlDbType.Float)
        arParms(5).Value = i.PurchaseDeal
        arParms(6) = New SqlParameter("@PurchaseDeal1", SqlDbType.Float)
        arParms(6).Value = i.PurchaseDeal1
        arParms(7) = New SqlParameter("@QtyAccept", SqlDbType.Float)
        arParms(7).Value = i.QtyAccept
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
        arParms(16) = New SqlParameter("@Discountamt", SqlDbType.Money)
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
        arParms(23) = New SqlParameter("@Excise", SqlDbType.Money)
        arParms(23).Value = i.Excise
        arParms(24) = New SqlParameter("@QtyRecvd", SqlDbType.Float)
        arParms(24).Value = i.QtyRecd
        arParms(25) = New SqlParameter("@Purchase_VAT", SqlDbType.Float)
        arParms(25).Value = i.VAT
        arParms(26) = New SqlParameter("@Purchase_CST", SqlDbType.Float)
        arParms(26).Value = i.CST
        arParms(27) = New SqlParameter("@ProductType", SqlDbType.Int)
        arParms(27).Value = i.ProductType
        arParms(28) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(28).Value = i.RemarksProduct
        arParms(29) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(29).Value = i.HIDPurchaseInvoice
        arParms(30) = New SqlParameter("@PurchRateIV", SqlDbType.VarChar, 50)
        arParms(30).Value = i.PurchRateIV
        arParms(31) = New SqlParameter("@FlatRate", SqlDbType.Money)
        arParms(31).Value = i.FlatRate
        arParms(32) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(32).Value = i.Amount
        arParms(33) = New SqlParameter("@FinalAmount", SqlDbType.Money)
        arParms(33).Value = i.FinalAmount
        arParms(34) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(34).Value = i.id
        arParms(35) = New SqlParameter("@Batch_Name", SqlDbType.VarChar, 50)
        arParms(35).Value = i.Batch
        '------------------------------------------------------------------------------------------------------'
        arParms(36) = New SqlParameter("@Qty", SqlDbType.Money)
        arParms(36).Value = i.Qty
        arParms(37) = New SqlParameter("@free", SqlDbType.Money)
        arParms(37).Value = i.free
        arParms(38) = New SqlParameter("@sngPurchRate", SqlDbType.Money)
        arParms(38).Value = i.sngPurchRate
        arParms(39) = New SqlParameter("@sngTradeDiscount", SqlDbType.Money)
        arParms(39).Value = i.sngTradeDiscount
        arParms(40) = New SqlParameter("@sngFlatDiscount", SqlDbType.Money)
        arParms(40).Value = i.sngFlatDiscount
        arParms(41) = New SqlParameter("@VATRate", SqlDbType.Money)
        arParms(41).Value = i.VATRate
        arParms(42) = New SqlParameter("@CSTRate", SqlDbType.Money)
        arParms(42).Value = i.CSTRate
        Try
            'SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockEntry", arParms)
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePurchaseInvoiceDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function GetPurchaseInvoiceM(ByVal El As Mfg_ELPurchaseInvoice) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.Int)
            Parms(2).Value = El.PID
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseInvoiceM", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Public Function GetPurchaseInvoiceDetails(ByVal El As Mfg_ELPurchaseInvoice) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
            Parms(2).Value = El.id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseInvoiceDetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetChkID(ByVal El As Mfg_ELPurchaseInvoice) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}


            Parms(0) = New SqlParameter("@CKID", SqlDbType.Int)
            Parms(0).Value = El.ChkID
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetChkPurchaseID", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetPurchaseInvoiceIDDetails(ByVal El As Mfg_ELPurchaseInvoice) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
            Parms(2).Value = El.PurchaseInvoiceID
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseInvoiceNODetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
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

    Shared Function GetfillProduct(ByVal autoid As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@ProductAutoNo", SqlDbType.Int)
        param(0).Value = autoid
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductAutoFill", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function filltax(ByVal i As Mfg_ELPurchaseInvoice) As DataTable
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
    Public Function PostPurchaseInvoice(ByVal i As Mfg_ELPurchaseInvoice) As Integer
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostPurchaseInvoice", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function PaymentRecPaidPurchaseInvoice(ByVal i As Mfg_ELPurchaseInvoice) As Integer
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PaymentMadePurchaseInvoice", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function PaymentRecPaidPurchaseInvoice1(ByVal i As Mfg_ELPurchaseInvoice) As Integer
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PaymentMadePurchaseInvoice1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function CheckDuplicate(ByVal s As Mfg_ELPurchaseInvoice) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = s.PID
        para(1) = New SqlParameter("@InvoiceNO", SqlDbType.VarChar, 50)
        para(1).Value = s.PurchaseInvoiceNo

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Mfg_DuplicatePurchaseInvoice", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function DeletePurchaseInvoice(ByVal id As Mfg_ELPurchaseInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = id.PID
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeletePurchaseInvoiceM", param)
        Return rowsaffected
    End Function
    Public Function DeletePurchaseInvoiceS(ByVal id As Mfg_ELPurchaseInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = id.id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeletePurchaseInvoiceS", param)
        Return rowsaffected
    End Function
End Class
