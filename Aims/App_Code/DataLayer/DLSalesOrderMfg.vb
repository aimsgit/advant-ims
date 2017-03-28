Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLSalesOrderMfg
    Shared Function GetSaleOrderView(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.VarChar, 20)
        para(0).Value = ELSalesOrderMfg.Sale_Order_Number
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_Proc_GetProduct", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function InsertSaleOrder(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(12) {}

        arParms(0) = New SqlParameter("@Sale_Order_Number", SqlDbType.VarChar, 50)
        arParms(0).Value = ELSalesOrderMfg.Sale_Order_Number

        arParms(1) = New SqlParameter("@Sale_Order_Date", SqlDbType.DateTime)
        arParms(1).Value = ELSalesOrderMfg.Sale_Order_Date

        arParms(2) = New SqlParameter("@Party_ID", SqlDbType.Int)
        arParms(2).Value = ELSalesOrderMfg.Party_ID

        arParms(3) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(3).Value = ELSalesOrderMfg.Remarks

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        If ELSalesOrderMfg.Ship_Date = "1/1/1900" Then
            arParms(7) = New SqlParameter("@Ship_Date", SqlDbType.DateTime)
            arParms(7).Value = DBNull.Value
        Else
            arParms(7) = New SqlParameter("@Ship_Date", SqlDbType.DateTime)
            arParms(7).Value = ELSalesOrderMfg.Ship_Date
        End If
        arParms(8) = New SqlParameter("@Ship_Address", SqlDbType.VarChar, 250)
        arParms(8).Value = ELSalesOrderMfg.Ship_Address

        If ELSalesOrderMfg.Ship_Method = "Select" Then
            arParms(9) = New SqlParameter("@Ship_Method", SqlDbType.VarChar, 50)
            arParms(9).Value = DBNull.Value
        Else
            arParms(9) = New SqlParameter("@Ship_Method", SqlDbType.VarChar, 50)
            arParms(9).Value = ELSalesOrderMfg.Ship_Method
        End If

        If ELSalesOrderMfg.Valid_Upto = "1/1/1900" Then
            arParms(10) = New SqlParameter("@Valid_Upto", SqlDbType.DateTime)
            arParms(10).Value = DBNull.Value
        Else
            arParms(10) = New SqlParameter("@Valid_Upto", SqlDbType.DateTime)
            arParms(10).Value = ELSalesOrderMfg.Valid_Upto
        End If

        arParms(11) = New SqlParameter("@Payment_Methods", SqlDbType.VarChar, 50)
        arParms(11).Value = ELSalesOrderMfg.PaymentMethod

        arParms(12) = New SqlParameter("@Field1", SqlDbType.VarChar, 50)
        arParms(12).Value = ELSalesOrderMfg.Sale_Invoice_No
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Mfg_Proc_InsertIntoSO]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function UpdateSaleOrder(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        arParms(0) = New SqlParameter("@Sale_Order_Number", SqlDbType.VarChar, 50)
        arParms(0).Value = ELSalesOrderMfg.Sale_Order_Number

        arParms(1) = New SqlParameter("@Sale_Order_Date", SqlDbType.DateTime)
        arParms(1).Value = ELSalesOrderMfg.Sale_Order_Date

        arParms(2) = New SqlParameter("@Party_ID", SqlDbType.Int)
        arParms(2).Value = ELSalesOrderMfg.Party_ID

        arParms(3) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(3).Value = ELSalesOrderMfg.Remarks

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        If ELSalesOrderMfg.Ship_Date = "1/1/1900" Then
            arParms(7) = New SqlParameter("@Ship_Date", SqlDbType.DateTime)
            arParms(7).Value = DBNull.Value
        Else
            arParms(7) = New SqlParameter("@Ship_Date", SqlDbType.DateTime)
            arParms(7).Value = ELSalesOrderMfg.Ship_Date
        End If
        arParms(8) = New SqlParameter("@Ship_Address", SqlDbType.VarChar, 250)
        arParms(8).Value = ELSalesOrderMfg.Ship_Address

        If ELSalesOrderMfg.Ship_Method = "Select" Then
            arParms(9) = New SqlParameter("@Ship_Method", SqlDbType.VarChar, 50)
            arParms(9).Value = DBNull.Value
        Else
            arParms(9) = New SqlParameter("@Ship_Method", SqlDbType.VarChar, 50)
            arParms(9).Value = ELSalesOrderMfg.Ship_Method
        End If

        If ELSalesOrderMfg.Valid_Upto = "1/1/1900" Then
            arParms(10) = New SqlParameter("@Valid_Upto", SqlDbType.DateTime)
            arParms(10).Value = DBNull.Value
        Else
            arParms(10) = New SqlParameter("@Valid_Upto", SqlDbType.DateTime)
            arParms(10).Value = ELSalesOrderMfg.Valid_Upto
        End If

        arParms(11) = New SqlParameter("@Payment_Methods", SqlDbType.VarChar, 50)
        arParms(11).Value = ELSalesOrderMfg.PaymentMethod

        arParms(12) = New SqlParameter("@Sales_Order_ID", SqlDbType.Int)
        arParms(12).Value = ELSalesOrderMfg.Sales_Order_ID

        arParms(13) = New SqlParameter("@Field1", SqlDbType.VarChar, 50)
        arParms(13).Value = ELSalesOrderMfg.Sale_Invoice_No

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateSalesorder]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function DeleteSaleOrder(ByVal id As Integer) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(0) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        
        para(0).Value = id
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Mfg_DeleteSO_Details", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function getTransportByCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlannerCombofill", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
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
    'Public Function ProductComboD() As DataTable
    '    Dim ds As New DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim param() As SqlParameter = New SqlParameter(1) {}
    '    param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    param(0).Value = HttpContext.Current.Session("Office")
    '    param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    param(1).Value = HttpContext.Current.Session("BranchCode")
    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetProductCombo", param)
    '        Return ds.Tables(0)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Function
    Shared Function filltextbox(ByVal ELSalesOrderMfg As ELSaleorderMfg) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        para(0) = New SqlParameter("@PartyAutoNo", SqlDbType.VarChar, 50)
        para(0).Value = ELSalesOrderMfg.PartyAutoNo
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        'para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'para(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_FillBuyeraddrs", para)
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
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSaleOrderGrid(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = ELSalesOrderMfg.PartyAutoNo
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function AutoGenerateNo(ByVal ELSalesOrderMfg As ELSaleorderMfg) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
       
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
   
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_SelectSONo]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckDuplicate(ByVal ELSalesOrderMfg As ELSaleorderMfg) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Party_ID", SqlDbType.Int)
        para(1).Value = ELSalesOrderMfg.Party_ID
        para(2) = New SqlParameter("@Sales_Order_ID", SqlDbType.Int)
        para(2).Value = ELSalesOrderMfg.ID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_DuplicateCheck", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSaleOrderId(ByVal ELSalesOrderMfg As ELSaleorderMfg) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Party_ID", SqlDbType.Int)
        para(1).Value = ELSalesOrderMfg.Party_ID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetSaleOrderID", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckProduct(ByVal ELSalesOrderMfg As ELSaleorderMfg) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Product_ID", SqlDbType.Int)
        para(1).Value = ELSalesOrderMfg.Party_ID
       
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetProductId", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
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

    Shared Function EditSaleOrder(ByVal ELSalesOrderMfg As ELSaleorderMfg) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
        para(0) = New SqlParameter("@SODetailSubID", SqlDbType.VarChar, 20)
        para(0).Value = ELSalesOrderMfg.Sales_Order_ID
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@Buyer", SqlDbType.Int)
        para(3).Value = ELSalesOrderMfg.Party_ID
        If ELSalesOrderMfg.Sale_Order_Number = Nothing Then
            para(4) = New SqlParameter("@SONO", SqlDbType.VarChar, 50)
            para(4).Value = DBNull.Value
        Else
            para(4) = New SqlParameter("@SONO", SqlDbType.VarChar, 50)
            para(4).Value = ELSalesOrderMfg.Sale_Order_Number
        End If
      
        para(5) = New SqlParameter("@SODate", SqlDbType.DateTime)
        para(5).Value = ELSalesOrderMfg.Sale_Order_Date
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_EditSalesOrder", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Sale_Invoice_Rev2(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Sale_Invoice_No", SqlDbType.VarChar, 50)
        arParms(0).Value = ELSalesOrderMfg.Sale_Invoice_No

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Mfg_InsertIntoSale_Invoice_Rev2]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateSale_Invoice_Rev2(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Sale_Invoice_No", SqlDbType.VarChar, 50)
        arParms(0).Value = ELSalesOrderMfg.Sale_Invoice_No

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")
        arParms(4) = New SqlParameter("@SaleMain_ID", SqlDbType.Int)
        arParms(4).Value = ELSalesOrderMfg.SaleMain_ID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[UpdateSaleInvoice]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetSaleInvoiceNO(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@Sales_Order_ID", SqlDbType.Int)
        para(0).Value = ELSalesOrderMfg.Sales_Order_ID
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[Mfg_GetsaleinvoiceNo]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteSaleOrder1(ByVal id As Integer) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(0) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = id
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Mfg_DeleteSaleorder", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function checkproductandbuyer(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
       
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        'para(2) = New SqlParameter("@id", SqlDbType.Int)
        'para(2).Value = ELSalesOrderMfg.Party_ID
        para(2) = New SqlParameter("@id1", SqlDbType.Int)
        para(2).Value = ELSalesOrderMfg.ID
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_CheckProductandBuyer", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getsaleorderidField(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@Buyer", SqlDbType.VarChar, 50)
        para(2).Value = ELSalesOrderMfg.Sale_Order_Number
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "[Mfg_ProcGetSaleorderID]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    ' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' '' ''DL
    Shared Function InsertSODetails(ByVal AddSO As ELSaleorderMfg)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@Product_ID", SqlDbType.Int)
        arParms(0).Value = AddSO.Product_ID1

        arParms(1) = New SqlParameter("@Quantity_Ordered", SqlDbType.Float)
        arParms(1).Value = AddSO.Quantity_Ordered1

        arParms(2) = New SqlParameter("@Currency_Rate", SqlDbType.Float)
        arParms(2).Value = AddSO.Currency_Rate

        arParms(3) = New SqlParameter("@Currency_Code", SqlDbType.Float)
        arParms(3).Value = AddSO.Currency_Code

        arParms(4) = New SqlParameter("@Currency_Factor", SqlDbType.Float)
        arParms(4).Value = AddSO.Currency_Factor

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@Sales_Order_Id", SqlDbType.Int)
        arParms(8).Value = AddSO.Sales_Order_ID1

        arParms(9) = New SqlParameter("@SONO", SqlDbType.VarChar, 50)
        arParms(9).Value = AddSO.Sale_Order_Number

        arParms(10) = New SqlParameter("@RBProduct", SqlDbType.Int)
        arParms(10).Value = AddSO.RBProduct

        arParms(11) = New SqlParameter("@EstimatedVaalue", SqlDbType.Float)
        arParms(11).Value = AddSO.EstimatedValue

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Mfg_InsertAddsODetails]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function ProductComboD() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetProductCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Getproduct(ByVal AddSO As ELSaleorderMfg) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        param(2).Value = AddSO.Sale_Order_Number
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_Proc_GetProduct]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Update(ByVal AddSO As ELSaleorderMfg)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Product_ID", SqlDbType.Int)
        arParms(0).Value = AddSO.Product_ID1

        arParms(1) = New SqlParameter("@Quantity_Ordered", SqlDbType.Float)
        arParms(1).Value = AddSO.Quantity_Ordered1

        arParms(2) = New SqlParameter("@Currency_Rate", SqlDbType.Int)
        arParms(2).Value = AddSO.Currency_Rate

        arParms(3) = New SqlParameter("@Currency_Code", SqlDbType.Int)
        arParms(3).Value = AddSO.Currency_Code

        arParms(4) = New SqlParameter("@Currency_Factor", SqlDbType.Int)
        arParms(4).Value = AddSO.Currency_Factor

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@SODetailSubID", SqlDbType.Int)
        arParms(8).Value = AddSO.SODetailSubID

        arParms(9) = New SqlParameter("@RBProduct", SqlDbType.Int)
        arParms(9).Value = AddSO.RBProduct

        arParms(10) = New SqlParameter("@EstimatedVaalue", SqlDbType.Float)
        arParms(10).Value = AddSO.EstimatedValue
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Mfg_UpdateSO_Details]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdatepostFlag(ByVal ElsaleorderMfg As ELSaleorderMfg) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowsaffected As Integer
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@Sale_Order_Number ", SqlDbType.VarChar, 20)
        para(0).Value = ElsaleorderMfg.Sale_Order_Number
        para(1) = New SqlParameter("@BranchCode ", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        'para(2) = New SqlParameter("@UserCode ", SqlDbType.VarChar, 50)
        'para(2).Value = HttpContext.Current.Session("UserCode")
        'para(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        'para(3).Value = HttpContext.Current.Session("EmpCode")

        Try

            Rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "[Mfg_UpdatePostFlag]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Rowsaffected
    End Function
    Public Function Getproduct1(ByVal AddSO As ELSaleorderMfg) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@id", SqlDbType.Int)
        param(2).Value = AddSO.Sale_Order_Number
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_Proc_GetProduct]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function CheckDuplicateforProduct(ByVal AddSO As ELSaleorderMfg) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(3) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Product_ID", SqlDbType.Int)
        param(2).Value = AddSO.Product_ID1
        param(3) = New SqlParameter("@Field1", SqlDbType.VarChar, 100)
        param(3).Value = AddSO.Sale_Order_Number

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_CheckDuplicateForProduct]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function CheckDuplicateforBuyer(ByVal AddSO As ELSaleorderMfg) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@SONO", SqlDbType.VarChar, 50)
        param(2).Value = AddSO.Sale_Order_Number
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_CheckDuplicateForBuyer]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function ProductComboDD(ByVal Id As Integer) As Data.DataTable
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
    Public Function GetSOPostStatus(ByVal AddSO As ELSaleorderMfg) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@SONO", SqlDbType.VarChar, 50)
        param(2).Value = AddSO.Sale_Order_Number
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_Proc_GetSOPostStatus]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function EstimatedRate(ByVal AddSO As ELSaleorderMfg) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@ProductId", SqlDbType.Int)
        param(2).Value = AddSO.Product_ID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetEsitimatedRate", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetproductEdit(ByVal AddSO As ELSaleorderMfg) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        param(2).Value = AddSO.SODetailSubID
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_Proc_GetProductEdit]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetproductEditMorethanone(ByVal AddSO As ELSaleorderMfg) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@id", SqlDbType.VarChar, 50)
        param(2).Value = AddSO.Sale_Order_Number
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_Proc_GetProductEditmorethanone]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetSaleInvNoDetails(ByVal Party_Id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@Party_Id", Data.SqlDbType.Int)
        arParms(2).Value = Party_Id


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SaleInvDetails", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class

