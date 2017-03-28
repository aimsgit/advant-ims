Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class MfgSaleInvoiceDL
    Public Function GetSaleOrderRpt(ByVal id As String) As System.Data.DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleOrder", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Public Function getSaleInv(ByVal ID As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id", SqlDbType.VarChar, 1000)
        arParms(1).Value = ID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_SaleInvoiceReceipt", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function BuyerComboD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBuyerCombo", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function BuyerCombo() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBuyerCombo3", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function SaleReturnNoCombo(ByVal PartyId As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@Party_ID", SqlDbType.Int)
        param(2).Value = PartyId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSaleReturnNoCombo", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetSalesOrder() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlPostedSaleOrder", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Public Function GetSaleOrder(ByVal Buyer_ID As Integer, ByVal SI_No As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}


            Parms(0) = New SqlParameter("@Buyer_ID", SqlDbType.Int)
            Parms(0).Value = Buyer_ID

            Parms(1) = New SqlParameter("@SI_No", SqlDbType.Int)
            Parms(1).Value = SI_No

            Parms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
            Parms(2).Value = StartDate

            Parms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
            Parms(3).Value = EndDate

            Parms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(4).Value = HttpContext.Current.Session("BranchCode")

            Parms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(5).Value = HttpContext.Current.Session("Office")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_SaleInvoice", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Public Function transportationComboD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetTransportationCombo", param)

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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "H_GetBatch", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function TaxDesc() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetTaxDesc", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function InsertSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(42) {}
        param(0) = New SqlParameter("@Buyer", SqlDbType.Int)
        param(0).Value = EL.Buyer_ID

        param(1) = New SqlParameter("@SaleInvoiceNo", SqlDbType.VarChar, 50)
        param(1).Value = EL.Sale_Invoice_No


        param(2) = New SqlParameter("@InvoiceDate", SqlDbType.DateTime)
        param(2).Value = EL.Invoice_Date

        param(3) = New SqlParameter("@InvoiceType", SqlDbType.VarChar, 100)
        param(3).Value = EL.Invoice_Type

        param(4) = New SqlParameter("@SE", SqlDbType.Int)
        param(4).Value = EL.SE

        param(5) = New SqlParameter("@PaymentMethod", SqlDbType.Int)
        param(5).Value = EL.Payment_Method

        param(6) = New SqlParameter("@ChequeNo ", SqlDbType.VarChar, 50)
        param(6).Value = EL.Cheque_No


        param(7) = New SqlParameter("@Bank", SqlDbType.Int)
        param(7).Value = EL.Bank


        param(8) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        param(8).Value = EL.Branch

        param(9) = New SqlParameter("@Flat_Disc_Amt ", SqlDbType.Money)
        param(9).Value = EL.Flat_disc_Amt

        param(10) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        param(10).Value = EL.Entry_Date

        param(11) = New SqlParameter("@Transcation_Type", SqlDbType.Int)
        param(11).Value = EL.Transaction_Type


        param(12) = New SqlParameter("@Flat_Disc", SqlDbType.Money)
        param(12).Value = EL.Flat_Disc

        param(13) = New SqlParameter("@No_Of_Item", SqlDbType.Int)
        param(13).Value = EL.NO_Of_Item

        param(14) = New SqlParameter("@SO_NO", SqlDbType.Int)
        param(14).Value = EL.SO_NO

        param(15) = New SqlParameter("@Freight_charges", SqlDbType.Money)
        param(15).Value = EL.Freight_charges

        param(16) = New SqlParameter("@credit_Note", SqlDbType.Int)
        param(16).Value = EL.Credit

        param(17) = New SqlParameter("@Debit_Note", SqlDbType.Int)
        param(17).Value = EL.Debit

        param(18) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        param(18).Value = EL.Remarks

        param(19) = New SqlParameter("@Challan_No", SqlDbType.VarChar, 50)
        param(19).Value = EL.Challan_NO


        param(20) = New SqlParameter("@Note", SqlDbType.VarChar, 250)
        param(20).Value = EL.Note


        param(21) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(21).Value = HttpContext.Current.Session("BranchCode")

        param(22) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        param(22).Value = HttpContext.Current.Session("EmpCode")

        param(23) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(23).Value = HttpContext.Current.Session("UserCode")


        param(24) = New SqlParameter("@Transport_No", SqlDbType.VarChar, 50)
        param(24).Value = EL.Transport_NO

        param(25) = New SqlParameter("@Sent_By", SqlDbType.VarChar, 50)
        param(25).Value = EL.Sent_By

        param(26) = New SqlParameter("@Dispatched_From", SqlDbType.VarChar, 50)
        param(26).Value = EL.Dispatched_From

        param(27) = New SqlParameter("@Dispatched_To", SqlDbType.VarChar, 50)
        param(27).Value = EL.Dispatched_To

        param(28) = New SqlParameter("@Received_Address", SqlDbType.VarChar, 250)
        param(28).Value = EL.Received_Address

        param(29) = New SqlParameter("@transpotation_Mode", SqlDbType.Int)
        param(29).Value = EL.Transportation_Mode

        If EL.Received_Date = "01-Jan-3000" Then
            param(30) = New SqlParameter("@Received_Date", SqlDbType.DateTime)
            param(30).Value = DBNull.Value
        Else
            param(30) = New SqlParameter("@Received_Date", SqlDbType.DateTime)
            param(30).Value = EL.Received_Date
        End If

        param(31) = New SqlParameter("@Curr_rec_Amt", SqlDbType.Money)
        param(31).Value = EL.Curr_rec_Amt

        param(32) = New SqlParameter("@TradeDiscAmt", SqlDbType.Money)
        param(32).Value = EL.TradeDiscAmount

        param(33) = New SqlParameter("@TotalAmt", SqlDbType.Money)
        param(33).Value = EL.TotalAmount

        param(34) = New SqlParameter("@FlatDiscAmt", SqlDbType.Money)
        param(34).Value = EL.FlatDiscAmount

        param(35) = New SqlParameter("@TotalVatAmt", SqlDbType.Money)
        param(35).Value = EL.TotalVATAmount

        param(36) = New SqlParameter("@InvoiceID", SqlDbType.Int)
        param(36).Value = EL.InvoiceID

        param(37) = New SqlParameter("@AddFriCharges", SqlDbType.Money)
        param(37).Value = EL.AddFriCharges

        param(38) = New SqlParameter("@FinalAmt", SqlDbType.Money)
        param(38).Value = EL.TotalFinalAmt

        param(39) = New SqlParameter("@RoundOff", SqlDbType.Money)
        param(39).Value = EL.RoundOff

        param(40) = New SqlParameter("@ProfitLoss", SqlDbType.Money)
        param(40).Value = EL.profitLoss

        param(41) = New SqlParameter("@GrandFinalAmt", SqlDbType.Money)
        param(41).Value = EL.TotalGrandFinalAmt

        param(42) = New SqlParameter("@TotalCSTAmt", SqlDbType.Money)
        param(42).Value = EL.TotalCSTAmount

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertSaleInvoice", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Public Function PostsaleInvoice(ByVal i As Mfg_ELSaleInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode", SqlDbType.NVarChar, 4000)
        arParms(3).Value = i.ChkID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostSaleInvoice", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function PaymentRecPaidPurchaseInvoice(ByVal i As Mfg_ELSaleInvoice) As Integer
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PaymentMadeSaleInvoice", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function PaymentRecPaidPurchaseInvoice2(ByVal EL As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@ID ", SqlDbType.NVarChar, 4000)
        arParms(3).Value = EL

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PaymentMadeSaleInvoice2", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function PaymentRecPaidPurchaseInvoice1(ByVal i As Mfg_ELSaleInvoice) As Integer
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PaymentMadeSaleInvoice1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function PostSI(ByVal i As Mfg_ELSaleInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode", SqlDbType.NVarChar, 4000)
        arParms(3).Value = i.ChkID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostSI", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function Pushtostock(ByVal El As Mfg_ELSaleInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@invoiceid", SqlDbType.Int)
        arParms(3).Value = El.InvoiceID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertSaleInvoicePushToStock", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GetSaleInvoiceIDDetails(ByVal El As Mfg_ELSaleInvoice) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
            Parms(2).Value = El.Id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleInvoiceDetails", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Shared Function UpdateSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(43) {}
        param(0) = New SqlParameter("@Buyer", SqlDbType.Int)
        param(0).Value = EL.Buyer_ID

        param(1) = New SqlParameter("@SaleInvoiceNo", SqlDbType.VarChar, 50)
        param(1).Value = EL.Sale_Invoice_No


        param(2) = New SqlParameter("@InvoiceDate", SqlDbType.DateTime)
        param(2).Value = EL.Invoice_Date

        param(3) = New SqlParameter("@InvoiceType", SqlDbType.VarChar, 100)
        param(3).Value = EL.Invoice_Type

        param(4) = New SqlParameter("@SE", SqlDbType.Int)
        param(4).Value = EL.SE

        param(5) = New SqlParameter("@PaymentMethod", SqlDbType.Int)
        param(5).Value = EL.Payment_Method

        param(6) = New SqlParameter("@ChequeNo ", SqlDbType.VarChar, 50)
        param(6).Value = EL.Cheque_No


        param(7) = New SqlParameter("@Bank", SqlDbType.Int)
        param(7).Value = EL.Bank


        param(8) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        param(8).Value = EL.Branch

        param(9) = New SqlParameter("@Flat_Disc_Amt ", SqlDbType.Money)
        param(9).Value = EL.Flat_disc_Amt

        param(10) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        param(10).Value = EL.Entry_Date

        param(11) = New SqlParameter("@Transcation_Type", SqlDbType.Int)
        param(11).Value = EL.Transaction_Type


        param(12) = New SqlParameter("@Flat_Disc", SqlDbType.Money)
        param(12).Value = EL.Flat_Disc

        param(13) = New SqlParameter("@No_Of_Item", SqlDbType.Int)
        param(13).Value = EL.NO_Of_Item

        param(14) = New SqlParameter("@SO_NO", SqlDbType.Int)
        param(14).Value = EL.SO_NO

        param(15) = New SqlParameter("@Freight_charges", SqlDbType.Money)
        param(15).Value = EL.Freight_charges

        param(16) = New SqlParameter("@credit_Note", SqlDbType.Int)
        param(16).Value = EL.Credit

        param(17) = New SqlParameter("@Debit_Note", SqlDbType.Int)
        param(17).Value = EL.Debit

        param(18) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        param(18).Value = EL.Remarks

        param(19) = New SqlParameter("@Challan_No", SqlDbType.VarChar, 50)
        param(19).Value = EL.Challan_NO


        param(20) = New SqlParameter("@Note", SqlDbType.VarChar, 250)
        param(20).Value = EL.Note


        param(21) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(21).Value = HttpContext.Current.Session("BranchCode")

        param(22) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        param(22).Value = HttpContext.Current.Session("EmpCode")

        param(23) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(23).Value = HttpContext.Current.Session("UserCode")


        param(24) = New SqlParameter("@Transport_No", SqlDbType.VarChar, 50)
        param(24).Value = EL.Transport_NO

        param(25) = New SqlParameter("@Sent_By", SqlDbType.VarChar, 50)
        param(25).Value = EL.Sent_By

        param(26) = New SqlParameter("@Dispatched_From", SqlDbType.VarChar, 50)
        param(26).Value = EL.Dispatched_From

        param(27) = New SqlParameter("@Dispatched_To", SqlDbType.VarChar, 50)
        param(27).Value = EL.Dispatched_To

        param(28) = New SqlParameter("@Received_Address", SqlDbType.VarChar, 250)
        param(28).Value = EL.Received_Address

        param(29) = New SqlParameter("@transpotation_Mode", SqlDbType.Int)
        param(29).Value = EL.Transportation_Mode

        If EL.Received_Date = "01-Jan-3000" Then
            param(30) = New SqlParameter("@Received_Date", SqlDbType.DateTime)
            param(30).Value = System.DBNull.Value
        Else
            param(30) = New SqlParameter("@Received_Date", SqlDbType.DateTime)
            param(30).Value = EL.Received_Date
        End If

        param(31) = New SqlParameter("@Curr_rec_Amt", SqlDbType.Money)
        param(31).Value = EL.Curr_rec_Amt

        param(32) = New SqlParameter("@id", SqlDbType.Int)
        param(32).Value = EL.Id

        param(33) = New SqlParameter("@InvoiceID", SqlDbType.Int)
        param(33).Value = EL.InvoiceID

        param(34) = New SqlParameter("@TradeDiscAmt", SqlDbType.Money)
        param(34).Value = EL.TradeDiscAmount


        param(35) = New SqlParameter("@TotalVatAmt", SqlDbType.Money)
        param(35).Value = EL.TotalVATAmount

        param(36) = New SqlParameter("@TotalCSTAmt", SqlDbType.Money)
        param(36).Value = EL.TotalCSTValue

        param(37) = New SqlParameter("@AddFriCharges", SqlDbType.Money)
        param(37).Value = EL.AddFriCharges

        param(38) = New SqlParameter("@FinalAmt", SqlDbType.Money)
        param(38).Value = EL.TotalFinalAmt

        param(39) = New SqlParameter("@RoundOff", SqlDbType.Money)
        param(39).Value = EL.RoundOff

        param(40) = New SqlParameter("@ProfitLoss", SqlDbType.Money)
        param(40).Value = EL.profitLoss

        param(41) = New SqlParameter("@GrandFinalAmt", SqlDbType.Money)
        param(41).Value = EL.TotalGrandFinalAmt

        'param(42) = New SqlParameter("@TotalCSTAmt", SqlDbType.Money)
        'param(42).Value = EL.TotalCSTAmount

        param(42) = New SqlParameter("@TotalAmt", SqlDbType.Money)
        param(42).Value = EL.TotalAmount

        param(43) = New SqlParameter("@FlatDiscAmt", SqlDbType.Money)
        param(43).Value = EL.FlatDiscAmount


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateSaleInvoice", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.Id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleInvoice", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetSaleInvoiceID(ByVal EL As Mfg_ELSaleInvoice) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(2).Value = EL.InvoiceID


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleInvoiceID", arParms)
        Return ds.Tables(0)
    End Function

    Public Function GetSaleInvoiceID1(ByVal Party_Id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Party_Id", SqlDbType.Int)
        arParms(2).Value = Party_Id


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSalesInvNoCombo", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteSaleInvoice", arParms)
        Return rowsaffected
    End Function
    Public Function CheckDuplicateSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@saleinvoiceno", SqlDbType.VarChar, 50)
        para(1).Value = EL.Sale_Invoice_No
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.Id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_DuplicateSaleInvoice", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function filltax(ByVal El As Mfg_ELSaleInvoice) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@TaxPlan", SqlDbType.Int)
        arParms(0).Value = El.TaxPlan
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockEntryTaxFill", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function PostStatus(ByVal EL As Mfg_ELSaleInvoice) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(2).Value = EL.Id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetSaleInvoicePostStatus", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function PostStatusCheck(ByVal EL As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@ID", SqlDbType.VarChar, 50)
        arParms(2).Value = EL

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_SIPostCheck", arParms)
        Return ds.Tables(0)
    End Function
    Public Shared Function InsertSaleInvoiceDetails(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(33) {}
        param(0) = New SqlParameter("@ProductID", SqlDbType.Int)
        param(0).Value = EL.ProductID

        param(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        param(1).Value = EL.Batch


        param(2) = New SqlParameter("@TotalQty", SqlDbType.Float)
        param(2).Value = EL.TotalQty

        param(3) = New SqlParameter("@Deal", SqlDbType.Float)
        param(3).Value = EL.Deal

        param(4) = New SqlParameter("@Deal1", SqlDbType.Float)
        param(4).Value = EL.Deal1

        param(5) = New SqlParameter("@TradeRate", SqlDbType.Money)
        param(5).Value = EL.Trade_Rate

        param(6) = New SqlParameter("@DiscountPer", SqlDbType.Float)
        param(6).Value = EL.DiscPer


        param(7) = New SqlParameter("@DiscountAmt", SqlDbType.Money)
        param(7).Value = EL.Disc_Amt


        param(8) = New SqlParameter("@TaxAB", SqlDbType.Int)
        param(8).Value = EL.TaxAB

        param(9) = New SqlParameter("@TaxOn", SqlDbType.VarChar, 50)
        param(9).Value = EL.TaxON

        param(10) = New SqlParameter("@TaxPlan", SqlDbType.VarChar, 50)
        param(10).Value = EL.TaxPlan

        param(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(11).Value = HttpContext.Current.Session("BranchCode")

        param(12) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        param(12).Value = HttpContext.Current.Session("EmpCode")

        param(13) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(13).Value = HttpContext.Current.Session("UserCode")

        param(14) = New SqlParameter("@InvoiceID", SqlDbType.Int)
        param(14).Value = EL.InvoiceID

        param(15) = New SqlParameter("@Amount", SqlDbType.Float)
        param(15).Value = EL.Amount

        param(16) = New SqlParameter("@FinalAmount", SqlDbType.Float)
        param(16).Value = EL.FinalAmount

        param(17) = New SqlParameter("@MRP", SqlDbType.Float)
        param(17).Value = EL.MRP

        param(18) = New SqlParameter("@Margin", SqlDbType.Float)
        param(18).Value = EL.Margin

        param(19) = New SqlParameter("@CST", SqlDbType.Float)
        param(19).Value = EL.CST

        param(20) = New SqlParameter("@VAT", SqlDbType.Float)
        param(20).Value = EL.VAT

        param(21) = New SqlParameter("@Currency", SqlDbType.Int)
        param(21).Value = EL.Currency

        param(22) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        param(22).Value = EL.ExchangeRate
        '-----------------------------------------------------------------------------------------------------------
        param(23) = New SqlParameter("@Qty", SqlDbType.Money)
        param(23).Value = EL.Qty
        param(24) = New SqlParameter("@free", SqlDbType.Money)
        param(24).Value = EL.free
        param(25) = New SqlParameter("@sngPurchRate", SqlDbType.Money)
        param(25).Value = EL.sngPurchRate
        param(26) = New SqlParameter("@sngTradeDiscount", SqlDbType.Money)
        param(26).Value = EL.sngTradeDiscount
        param(27) = New SqlParameter("@sngFlatDiscount", SqlDbType.Money)
        param(27).Value = EL.sngFlatDiscount
        param(28) = New SqlParameter("@VATRate", SqlDbType.Money)
        param(28).Value = EL.VATRate
        param(29) = New SqlParameter("@CSTRate", SqlDbType.Money)
        param(29).Value = EL.CSTRate
        param(30) = New SqlParameter("@FlatRate", SqlDbType.Money)
        param(30).Value = EL.FlatRate

        param(31) = New SqlParameter("@HIDELFlatRate", SqlDbType.Money)
        param(31).Value = EL.HIDELFlatRate

        param(32) = New SqlParameter("@PurchaseInvoiceMain", SqlDbType.Int)
        param(32).Value = EL.PurchaseInvoiceMain

        param(33) = New SqlParameter("@PurchaseInvoiceDetails", SqlDbType.Int)
        param(33).Value = EL.PurchaseInvoiceDetails
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertSaleInvoiceDetails", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function BankComboDDL() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBankDDL", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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

    Public Shared Function UpdateSaleInvoiceDetails(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(33) {}
        param(0) = New SqlParameter("@ProductID", SqlDbType.Int)
        param(0).Value = EL.ProductID

        param(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        param(1).Value = EL.Batch


        param(2) = New SqlParameter("@TotalQty", SqlDbType.Float)
        param(2).Value = EL.TotalQty

        param(3) = New SqlParameter("@Deal", SqlDbType.Float)
        param(3).Value = EL.Deal

        param(4) = New SqlParameter("@Deal1", SqlDbType.Float)
        param(4).Value = EL.Deal1

        param(5) = New SqlParameter("@TradeRate", SqlDbType.Money)
        param(5).Value = EL.Trade_Rate

        param(6) = New SqlParameter("@DiscountPer", SqlDbType.Float)
        param(6).Value = EL.DiscPer


        param(7) = New SqlParameter("@DiscountAmt", SqlDbType.Money)
        param(7).Value = EL.Disc_Amt


        param(8) = New SqlParameter("@TaxAB", SqlDbType.Int)
        param(8).Value = EL.TaxAB

        param(9) = New SqlParameter("@TaxOn", SqlDbType.VarChar, 50)
        param(9).Value = EL.TaxON

        param(10) = New SqlParameter("@TaxPlan", SqlDbType.VarChar, 50)
        param(10).Value = EL.TaxPlan

        param(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(11).Value = HttpContext.Current.Session("BranchCode")

        param(12) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        param(12).Value = HttpContext.Current.Session("EmpCode")

        param(13) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(13).Value = HttpContext.Current.Session("UserCode")

        param(14) = New SqlParameter("@id", SqlDbType.Int)
        param(14).Value = EL.Id

        param(15) = New SqlParameter("@Amount", SqlDbType.Float)
        param(15).Value = EL.Amount

        param(16) = New SqlParameter("@FinalAmount", SqlDbType.Float)
        param(16).Value = EL.FinalAmount

        param(17) = New SqlParameter("@MRP", SqlDbType.Float)
        param(17).Value = EL.MRP

        param(18) = New SqlParameter("@Margin", SqlDbType.Float)
        param(18).Value = EL.Margin

        param(19) = New SqlParameter("@CST", SqlDbType.Float)
        param(19).Value = EL.CST

        param(20) = New SqlParameter("@VAT", SqlDbType.Float)
        param(20).Value = EL.VAT

        param(21) = New SqlParameter("@Currency", SqlDbType.Int)
        param(21).Value = EL.Currency

        param(22) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        param(22).Value = EL.ExchangeRate
        '---------------------------------------------------------------------------------------------------------'

        param(23) = New SqlParameter("@Qty", SqlDbType.Money)
        param(23).Value = EL.Qty
        param(24) = New SqlParameter("@free", SqlDbType.Money)
        param(24).Value = EL.free
        param(25) = New SqlParameter("@sngPurchRate", SqlDbType.Money)
        param(25).Value = EL.sngPurchRate
        param(26) = New SqlParameter("@sngTradeDiscount", SqlDbType.Money)
        param(26).Value = EL.sngTradeDiscount
        param(27) = New SqlParameter("@sngFlatDiscount", SqlDbType.Money)
        param(27).Value = EL.sngFlatDiscount
        param(28) = New SqlParameter("@VATRate", SqlDbType.Money)
        param(28).Value = EL.VATRate
        param(29) = New SqlParameter("@CSTRate", SqlDbType.Money)
        param(29).Value = EL.CSTRate
        param(30) = New SqlParameter("@FlatRate", SqlDbType.Money)
        param(30).Value = EL.FlatRate

        param(31) = New SqlParameter("@HIDELFlatRate", SqlDbType.Money)
        param(31).Value = EL.HIDELFlatRate

        param(32) = New SqlParameter("@PurchaseInvoiceMain", SqlDbType.Int)
        param(32).Value = EL.PurchaseInvoiceMain

        param(33) = New SqlParameter("@PurchaseInvoiceDetails", SqlDbType.Int)
        param(33).Value = EL.PurchaseInvoiceDetails

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateSaleInvoiceDetails", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetSaleInvoiceDetails(ByVal EL As Mfg_ELSaleInvoice) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.Id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleInvoiceDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSaleInvoiceDetailsFORPrint(ByVal EL As Mfg_ELSaleInvoice) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
     

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        'arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("UserCode")

        arParms(1) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(1).Value = EL.Id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_SaleInvoiceRecpt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function DeleteSaleInvoiceDetails(ByVal EL As Mfg_ELSaleInvoice) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteSaleInvoiceDetails", arParms)
        Return rowsaffected
    End Function
    Public Function GetInvoiceNo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectSaleInvoiceNo", arParms)
        Return ds.Tables(0)
    End Function
    Public Function Getmrp() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetsaleDetailsFill", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function AutoGenerateNo(ByVal EL As Mfg_ELSaleInvoice) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectSaleInvoiceNo", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function SearchInvoice(ByVal EL As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@Search", SqlDbType.VarChar, 50)
        para(2).Value = EL

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SearchSaleInvoiceNo", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Credit(ByVal EL As Mfg_ELSaleInvoice) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCredit", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SelectBatchName(ByVal ProductId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@product", SqlDbType.Int)
        para(2).Value = ProductId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_BatchComboAutoComplete", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SaleDelete(ByVal Invoice As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New Integer
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@Invoice", SqlDbType.VarChar, 50)
        para(2).Value = Invoice
        Try
            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteSaleInvoicePos", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function BuyerComboAll() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBuyerComboAll", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function BuyerComboAllNew() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBuyerComboAllNew", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function PartyTypeCombo() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_RptPartyTypeddl", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetPartyNameddl(ByVal PartyName As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@PartyType", SqlDbType.Int)
        arParms(2).Value = PartyName

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_RptPartyNameddl", arParms)
        Return ds.Tables(0)
    End Function
End Class

