Imports System.Data.SqlClient

Public Class Mfg_DLSaleReturn
    Public Function GetSupplierStock(ByVal Id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Id", SqlDbType.Int)
            Parms(2).Value = Id

            'Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            'Parms(3).Value = Supp_Id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProductName", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
        para(3) = New SqlParameter("@SaleReturnNo ", SqlDbType.Int)
        para(3).Value = SaleReturnId
        para(4) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(4).Value = StartDate
        para(5) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(5).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SaleReturn_Report", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSaleReturnReport(ByVal Rbid As Integer, ByVal Fromdate As DateTime, ByVal Todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@value ", SqlDbType.Int)
        para(2).Value = Rbid
        para(3) = New SqlParameter("@StartDate ", SqlDbType.Date)
        para(3).Value = Fromdate
        para(4) = New SqlParameter("@EndDate ", SqlDbType.Date)
        para(4).Value = Todate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_StockReturnReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetSaleReturn(ByVal Id As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Id", SqlDbType.VarChar)
            Parms(1).Value = Id

           

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_sale_ReturnReport", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Drilldown(ByVal Product_ID As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Product_ID", SqlDbType.Int)
        param(2).Value = Product_ID

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_DrillDownStockStatus", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SelectProductName(ByVal Supplier As Integer, ByVal id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Id", SqlDbType.Int)
            Parms(2).Value = id
            Parms(3) = New SqlParameter("@Buyer", SqlDbType.Int)
            Parms(3).Value = Supplier

            'Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            'Parms(3).Value = Supp_Id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectStockProductNameforBuyer", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Shared Function GetReturnNo() As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}
            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Mfg_SelectSaleReturnNo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function Insert(ByVal Id As Mfg_ELSaleReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(7) {}

            Parms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("EmpCode")
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("UserCode")
            Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            Parms(3).Value = Id.Supplier
            Parms(4) = New SqlParameter("@ReturnNo", SqlDbType.VarChar, 50)
            Parms(4).Value = Id.ReturnNo
            Parms(5) = New SqlParameter("@ReturnId", SqlDbType.Int)
            Parms(5).Value = Id.ReturnId
            Parms(6) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            Parms(6).Value = Id.ReturnDate
            Parms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
            Parms(7).Value = Id.Remarks

            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertSaleReturnM", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    Public Function Insertrecord(ByVal Id As Mfg_ELSaleReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(16) {}

            Parms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("EmpCode")
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("UserCode")
            Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            Parms(3).Value = Id.Supplier
            Parms(4) = New SqlParameter("@Currency", SqlDbType.Int)
            Parms(4).Value = Id.Currency
            Parms(5) = New SqlParameter("@ExchangeRate", SqlDbType.Money)
            Parms(5).Value = Id.ExchRate
            Parms(6) = New SqlParameter("@Productid", SqlDbType.Int)
            Parms(6).Value = Id.Product
            Parms(7) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(7).Value = Id.Batch
            Parms(8) = New SqlParameter("@ProductType", SqlDbType.Int)
            Parms(8).Value = Id.ProductType
            Parms(9) = New SqlParameter("@StockId", SqlDbType.Int)
            Parms(9).Value = Id.StockId
            Parms(10) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
            Parms(10).Value = Id.RemarksS
            Parms(11) = New SqlParameter("@prd_id", SqlDbType.Int)
            Parms(11).Value = Id.PRD_ID
            Parms(12) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            Parms(12).Value = Id.ReturnDate
            Parms(13) = New SqlParameter("@PurchaseReturnID", SqlDbType.Int)
            Parms(13).Value = Id.HidPurchaseReturnId
            Parms(14) = New SqlParameter("@QtyReturned", SqlDbType.Float)
            Parms(14).Value = Id.ReturnedQty
            Parms(15) = New SqlParameter("@PuruchaseInvoiceId", SqlDbType.Int)
            Parms(15).Value = Id.InvoiceID
            Parms(16) = New SqlParameter("@Flatrate", SqlDbType.Money)
            Parms(16).Value = Id.FlatRate
            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertSaleReturnS", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    Public Function UpdateRecord(ByVal Id As Mfg_ELSaleReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(17) {}
            Parms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("EmpCode")
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("UserCode")
            Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            Parms(3).Value = Id.Supplier
            Parms(4) = New SqlParameter("@Currency", SqlDbType.Int)
            Parms(4).Value = Id.Currency
            Parms(5) = New SqlParameter("@ExchangeRate", SqlDbType.Money)
            Parms(5).Value = Id.ExchRate
            Parms(6) = New SqlParameter("@Productid", SqlDbType.Int)
            Parms(6).Value = Id.Product
            Parms(7) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(7).Value = Id.Batch
            Parms(8) = New SqlParameter("@ProductType", SqlDbType.Int)
            Parms(8).Value = Id.ProductType
            Parms(9) = New SqlParameter("@StockId", SqlDbType.Int)
            Parms(9).Value = Id.StockId
            Parms(10) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
            Parms(10).Value = Id.RemarksS
            Parms(11) = New SqlParameter("@prd_id", SqlDbType.Int)
            Parms(11).Value = Id.PRD_ID
            Parms(12) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            Parms(12).Value = Id.ReturnDate
            Parms(13) = New SqlParameter("@PurchaseReturnID", SqlDbType.Int)
            Parms(13).Value = Id.HidPurchaseReturnId
            Parms(14) = New SqlParameter("@QtyReturned", SqlDbType.Float)
            Parms(14).Value = Id.ReturnedQty
            Parms(15) = New SqlParameter("@PuruchaseInvoiceId", SqlDbType.Int)
            Parms(15).Value = Id.InvoiceID
            Parms(16) = New SqlParameter("@id", SqlDbType.Int)
            Parms(16).Value = Id.PID
            Parms(17) = New SqlParameter("@FlatRate", SqlDbType.Money)
            Parms(17).Value = Id.FlatRate
            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpateSaleReturnS", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function Update(ByVal Id As Mfg_ELSaleReturn) As Integer
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
            Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            Parms(3).Value = Id.Supplier
            Parms(4) = New SqlParameter("@ReturnNo", SqlDbType.VarChar, 50)
            Parms(4).Value = Id.ReturnNo
            Parms(5) = New SqlParameter("@ReturnId", SqlDbType.Int)
            Parms(5).Value = Id.ReturnId
            Parms(6) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            Parms(6).Value = Id.ReturnDate
            Parms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
            Parms(7).Value = Id.Remarks
            Parms(8) = New SqlParameter("@id", SqlDbType.Int)
            Parms(8).Value = Id.id

            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateSaleReturnM", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function GetPurchaseReturnM(ByVal El As Mfg_ELSaleReturn) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.Int)
            Parms(2).Value = El.id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleReturnM", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetPurchaseReturnIDDetails(ByVal El As Mfg_ELSaleReturn) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.Int)
            Parms(2).Value = El.HidPurchaseReturnId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleReturnDetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetPurchaseReturnS(ByVal El As Mfg_ELSaleReturn) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetSaleReturnS", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function BatchAutofill(ByVal El As Mfg_ELSaleReturn) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@InvoiceId", SqlDbType.Int)
            Parms(2).Value = El.InvoiceID

            Parms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
            Parms(3).Value = El.Batch
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_DDLBatchAutoFillforSaleReturnNew", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function DeletePurchasReturn(ByVal id As Mfg_ELSaleReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = id.id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteSaleReturnM", param)
        Return rowsaffected
    End Function

    Public Function DeletePurchaseReturnS(ByVal id As Mfg_ELSaleReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = id.PID
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteSaleReturnS", param)
        Return rowsaffected
    End Function
    Public Function PostPurchaseReturn(ByVal i As Mfg_ELSaleReturn) As Integer
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostSaleReturn", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GetBatchDDL(ByVal Id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@product", SqlDbType.Int)
            Parms(2).Value = Id

            'Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            'Parms(3).Value = Supp_Id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_StockBatchDDLforSaleReturn", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetFreeIssueStatement(ByVal ProductId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@ProductId ", SqlDbType.Int)
        para(2).Value = ProductId
        para(3) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(3).Value = StartDate
        para(4) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(4).Value = EndDate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_DetailedStockStatus", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDetailedStockStatus(ByVal ProductId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@ProductId ", SqlDbType.Int)
        para(2).Value = ProductId
        para(3) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(3).Value = StartDate
        para(4) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(4).Value = EndDate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_FreeIssueStatement", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetCreditNote(ByVal SupplierId As Integer, ByVal InvoiceNo As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@SupplierId ", SqlDbType.Int)
        para(2).Value = SupplierId
        para(3) = New SqlParameter("@InvoiceNo ", SqlDbType.Int)
        para(3).Value = InvoiceNo
        para(4) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(4).Value = StartDate
        para(5) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(5).Value = EndDate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_CreditNoteReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPendingPO(ByVal SupplierId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_rptPendingPONew", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDebitNote(ByVal SupplierId As Integer, ByVal InvoiceNo As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@SupplierId ", SqlDbType.Int)
        para(2).Value = SupplierId
        para(3) = New SqlParameter("@InvoiceNo ", SqlDbType.Int)
        para(3).Value = InvoiceNo
        para(4) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(4).Value = StartDate
        para(5) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(5).Value = EndDate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_DebitNoteReport", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSupplierDetails() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlSuppName", arParms)
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
End Class
