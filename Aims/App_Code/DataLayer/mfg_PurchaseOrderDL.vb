Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class mfg_PurchaseOrderDL
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
    Public Function PaymentMethodComboD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetPaymentMethodCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function DDLTransport() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetTransportationCombo", param)
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
    Public Function ProductComboD1(ByVal Id As Integer, ByVal PId As String) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(3) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Id", SqlDbType.Int)
        param(2).Value = Id
        param(3) = New SqlParameter("@PId", SqlDbType.VarChar, 50)
        param(3).Value = PId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProductName1", param)
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
    Public Function AddPODetails(ByVal el As mfg_PurchaseOrderEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(13) {}
            Parms(0) = New SqlParameter("@CurrencyID", SqlDbType.Int)
            Parms(0).Value = el.CurrencyID

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpCode")

            Parms(3) = New SqlParameter("@ExchRate", SqlDbType.Float)
            Parms(3).Value = el.ExchangeRate

            Parms(4) = New SqlParameter("@ProductID", SqlDbType.Int)
            Parms(4).Value = el.ProductID

            Parms(5) = New SqlParameter("@UnitID", SqlDbType.Int)
            Parms(5).Value = el.UnitID

            Parms(6) = New SqlParameter("@UnitRate", SqlDbType.Money)
            Parms(6).Value = el.UnitRate

            Parms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(7).Value = HttpContext.Current.Session("UserCode")

            Parms(8) = New SqlParameter("@Quantity", SqlDbType.Float)
            Parms(8).Value = el.Quantity

            Parms(9) = New SqlParameter("@EstimatedValue", SqlDbType.Money)
            Parms(9).Value = el.EstimatedValue

            Parms(10) = New SqlParameter("@EstimatedPrice", SqlDbType.Money)
            Parms(10).Value = el.EstimatedPrice

            Parms(11) = New SqlParameter("@SupplierId", SqlDbType.Int)
            Parms(11).Value = el.SupplierId

            Parms(12) = New SqlParameter("@ProductType", SqlDbType.Int)
            Parms(12).Value = el.ProductType

            Parms(13) = New SqlParameter("@PONo", SqlDbType.VarChar, 15)
            Parms(13).Value = el.PONo

            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertAddPODetails", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function GetPODetails(ByVal el As mfg_PurchaseOrderEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = el.Id
        arParms(3) = New SqlParameter("@SupplierId", SqlDbType.Int)
        arParms(3).Value = el.SupplierId
        arParms(4) = New SqlParameter("@PONo", SqlDbType.VarChar, 15)
        arParms(4).Value = el.PONo

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseOrderDetails", arParms)

        Return ds.Tables(0)

    End Function
    Public Function DeletePODetails(ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = Id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeletePODetails", param)
        Return rowsaffected
    End Function
    Public Function DeletePurchaseOrder(ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = Id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeletePurchaseOrder", param)
        Return rowsaffected
    End Function
    Public Function AddPurchaseOrder(ByVal el As mfg_PurchaseOrderEL) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(11) {}

        Parms(0) = New SqlParameter("@SupplierId", SqlDbType.Int)
        Parms(0).Value = el.SupplierId

        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        'Parms(3) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        'Parms(3).Value = el.Address

        Parms(3) = New SqlParameter("@PONo", SqlDbType.VarChar, 20)
        Parms(3).Value = el.PONo

        Parms(4) = New SqlParameter("@PODate", SqlDbType.DateTime)
        Parms(4).Value = el.PODate

        Parms(5) = New SqlParameter("@POvalDate", SqlDbType.DateTime)
        Parms(5).Value = el.POValidityDate

        Parms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(6).Value = HttpContext.Current.Session("UserCode")

        Parms(7) = New SqlParameter("@PaymentId", SqlDbType.Int)
        Parms(7).Value = el.PaymentMethodId

        Parms(8) = New SqlParameter("@DivideOrder", SqlDbType.Int)
        Parms(8).Value = el.DivideOrder

        Parms(9) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        Parms(9).Value = el.Remarks

        Parms(10) = New SqlParameter("@TranportationMode", SqlDbType.Int)
        Parms(10).Value = el.TransportationMode

        Parms(11) = New SqlParameter("@ShipmentAdd", SqlDbType.VarChar, 250)
        Parms(11).Value = el.ShipmentAddress

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPurchaseOrder", Parms)
        Return rowsaffected
    End Function
    Public Function UpdatePurchaseOrder(ByVal el As mfg_PurchaseOrderEL) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(12) {}

        Parms(0) = New SqlParameter("@SupplierId", SqlDbType.Int)
        Parms(0).Value = el.SupplierId

        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        'Parms(3) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        'Parms(3).Value = el.Address

        Parms(3) = New SqlParameter("@PONo", SqlDbType.VarChar, 20)
        Parms(3).Value = el.PONo

        Parms(4) = New SqlParameter("@PODate", SqlDbType.DateTime)
        Parms(4).Value = el.PODate

        Parms(5) = New SqlParameter("@POvalDate", SqlDbType.DateTime)
        Parms(5).Value = el.POValidityDate

        Parms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(6).Value = HttpContext.Current.Session("UserCode")

        Parms(7) = New SqlParameter("@PaymentId", SqlDbType.Int)
        Parms(7).Value = el.PaymentMethodId

        Parms(8) = New SqlParameter("@DivideOrder", SqlDbType.Int)
        Parms(8).Value = el.DivideOrder

        Parms(9) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        Parms(9).Value = el.Remarks

        Parms(10) = New SqlParameter("@TranportationMode", SqlDbType.Int)
        Parms(10).Value = el.TransportationMode

        Parms(11) = New SqlParameter("@ShipmentAdd", SqlDbType.VarChar, 250)
        Parms(11).Value = el.ShipmentAddress

        Parms(12) = New SqlParameter("@POID", SqlDbType.VarChar, 20)
        Parms(12).Value = el.Id

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePurchaseOrder", Parms)
        Return rowsaffected
    End Function
    Public Function getPurchaseRate(ByVal Id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@ProductId", SqlDbType.Int)
        arParms(1).Value = Id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseRate", arParms)

        Return ds.Tables(0)

    End Function
    Public Function getPurchaseQtyReceived(ByVal Id As Integer, ByVal PId As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@ProductId", SqlDbType.Int)
        arParms(1).Value = Id
        arParms(2) = New SqlParameter("@PurchaseReqNo", SqlDbType.VarChar, 50)
        arParms(2).Value = PId

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseReqQty", arParms)

        Return ds.Tables(0)

    End Function
    Public Function getProductforSupplierId(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@PONo", SqlDbType.VarChar, 15)
        arParms(2).Value = el.PONo

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductforSupplierId", arParms)

        Return ds.Tables(0)

    End Function
    Shared Function GetSupplierAutoFill(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(1).Value = el.Id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSupplierDetailsAutofill", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetPONo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectPONo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetProductforPONo(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@PONo", SqlDbType.VarChar, 15)
        arParms(2).Value = el.PONo

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_CheckProductForPONo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function getPurchaseOrderforEdit(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@POId", SqlDbType.Int)
        arParms(1).Value = el.Id
        arParms(2) = New SqlParameter("@PONo", SqlDbType.VarChar, 15)
        arParms(2).Value = el.PONo
        arParms(3) = New SqlParameter("@PODate", SqlDbType.DateTime)
        arParms(3).Value = el.PODate
        arParms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("Office")
        arParms(5) = New SqlParameter("@SuppId", SqlDbType.Int)
        arParms(5).Value = el.SupplierId


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseOrderForEdit", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetProductforPO(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@PONo", SqlDbType.VarChar, 15)
        arParms(1).Value = el.PONo
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductforPO", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DuplicatePurchaseOrder(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@PONo", SqlDbType.VarChar, 20)
        arParms(1).Value = el.PONo
        arParms(2) = New SqlParameter("@ID", SqlDbType.VarChar, 20)
        arParms(2).Value = el.Id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_DuplicatePurchaseOrder", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DuplicateProductPO(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@PONo", SqlDbType.VarChar, 20)
        arParms(1).Value = el.PONo
        arParms(2) = New SqlParameter("@ProdId", SqlDbType.Int)
        arParms(2).Value = el.ProductID
        arParms(3) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(3).Value = el.Id


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_DuplicateProductPO", arParms)
        Return ds.Tables(0)
    End Function
    Public Function UpdateProductPO(ByVal el As mfg_PurchaseOrderEL) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer

        Dim Parms() As SqlParameter = New SqlParameter(14) {}

        Parms(0) = New SqlParameter("@CurrencyID", SqlDbType.Int)
        Parms(0).Value = el.CurrencyID

        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")

        Parms(3) = New SqlParameter("@ExchRate", SqlDbType.Money)
        Parms(3).Value = el.ExchangeRate

        Parms(4) = New SqlParameter("@ProductID", SqlDbType.Int)
        Parms(4).Value = el.ProductID

        Parms(5) = New SqlParameter("@UnitID", SqlDbType.Int)
        Parms(5).Value = el.UnitID

        Parms(6) = New SqlParameter("@UnitRate", SqlDbType.Money)
        Parms(6).Value = el.UnitRate

        Parms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(7).Value = HttpContext.Current.Session("UserCode")

        Parms(8) = New SqlParameter("@Quantity", SqlDbType.Float)
        Parms(8).Value = el.Quantity

        Parms(9) = New SqlParameter("@EstimatedValue", SqlDbType.Money)
        Parms(9).Value = el.EstimatedValue

        Parms(10) = New SqlParameter("@EstimatedPrice", SqlDbType.Money)
        Parms(10).Value = el.EstimatedPrice

        Parms(11) = New SqlParameter("@SupplierId", SqlDbType.Int)
        Parms(11).Value = el.SupplierId

        Parms(12) = New SqlParameter("@ProductType", SqlDbType.Int)
        Parms(12).Value = el.ProductType

        Parms(13) = New SqlParameter("@PONo", SqlDbType.VarChar, 15)
        Parms(13).Value = el.PONo

        Parms(14) = New SqlParameter("@ProdId", SqlDbType.Int)
        Parms(14).Value = el.Id

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateProductPO", Parms)
        Return rowsaffected
    End Function
    Shared Function PostPurchaseOrder(ByVal el As mfg_PurchaseOrderEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@PONo", SqlDbType.VarChar, 100)
        arParms(1).Value = el.PONo
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostPO", arParms)
        Return rowsaffected
    End Function
    Shared Function PostStatus(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@PONo", SqlDbType.VarChar, 20)
        arParms(2).Value = el.PONo

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetPOPostStatus", arParms)
        Return ds.Tables(0)
    End Function
End Class

            
