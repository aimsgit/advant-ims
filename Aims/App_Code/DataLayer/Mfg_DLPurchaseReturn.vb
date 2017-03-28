Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLPurchaseReturn
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
    Shared Function SelectProductName(ByVal Supplier As Integer, ByVal id As Integer) As DataTable
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
            Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            Parms(3).Value = Supplier

            'Parms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
            'Parms(3).Value = Supp_Id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectStockProductName", Parms)
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
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Mfg_SelectReturnNo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function Insert(ByVal Id As Mfg_ELPurchaseReturn) As Integer
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
            
            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPurchaseReturnM", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    Shared Function Insertrecord(ByVal Id As Mfg_ELPurchaseReturn) As Integer
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
            Parms(16) = New SqlParameter("@flatrate", SqlDbType.Money)
            Parms(16).Value = Id.FlatRate
            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPurchaseReturnS", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    Shared Function UpdateRecord(ByVal Id As Mfg_ELPurchaseReturn) As Integer
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
            Parms(16) = New SqlParameter("@id", SqlDbType.Int)
            Parms(16).Value = Id.PID
            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpatePurchaseReturnS", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function Update(ByVal Id As Mfg_ELPurchaseReturn) As Integer
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

            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePurchaseReturnM", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function GetPurchaseReturnM(ByVal El As Mfg_ELPurchaseReturn) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchasePurchaseM", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetPurchaseReturnIDDetails(ByVal El As Mfg_ELPurchaseReturn) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseIReturnDetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetPurchaseReturnS(ByVal El As Mfg_ELPurchaseReturn) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPurchaseReturnS", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function BatchAutofill(ByVal El As Mfg_ELPurchaseReturn) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@InvoiceId", SqlDbType.Int)
            Parms(2).Value = El.InvoiceID

            Parms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
            Parms(3).Value = El.Batch

            Parms(4) = New SqlParameter("@Product", SqlDbType.Int)
            Parms(4).Value = El.Product
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_DDLBatchAutoFill", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function DeletePurchasReturn(ByVal id As Mfg_ELPurchaseReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = id.id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeletePurchaseReturnM", param)
        Return rowsaffected
    End Function

    Public Function DeletePurchaseReturnS(ByVal id As Mfg_ELPurchaseReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = id.PID
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeletePurchaseReturnS", param)
        Return rowsaffected
    End Function
    Public Function PostPurchaseReturn(ByVal i As Mfg_ELPurchaseReturn) As Integer
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostPurchaseReturn", arParms)
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_StockBatchDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetPurchaseReturnReport(ByVal id As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@id", SqlDbType.VarChar)
            Parms(1).Value = id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rpt_PurchaseReturnReport", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

End Class
