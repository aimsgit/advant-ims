Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLPaymentMade
    Shared Function GetSupplier() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlSupplier", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetInvoiceNo(ByVal Supp_Id As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Supp_Id", SqlDbType.Int)
        arParms(2).Value = Supp_Id

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlInvoiceNo", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Shared Function GridviewDetails(ByVal El As Mfg_ElPaymentMade) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet


        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("id", SqlDbType.Int)
        arParms(2).Value = El.id


        Try

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPaymentMade", arParms)


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Shared Function Insert(ByVal El As Mfg_ElPaymentMade) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(16) {}

        arParms(0) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(0).Value = El.currency

        arParms(1) = New SqlParameter("@ExchangeRate", SqlDbType.Int)
        arParms(1).Value = El.ExchangeRate


        arParms(2) = New SqlParameter("@Supplier", SqlDbType.Int)
        arParms(2).Value = El.supplier

       
        arParms(3) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        arParms(3).Value = El.entrydate



        arParms(4) = New SqlParameter("@Address", SqlDbType.VarChar, 50)
        arParms(4).Value = El.Address




        arParms(5) = New SqlParameter("@AmtPaid", SqlDbType.Money)
        arParms(5).Value = El.AmtPaid

        arParms(6) = New SqlParameter("@InvoiceNo", SqlDbType.Int)
        arParms(6).Value = El.InvoiceNo

        arParms(7) = New SqlParameter("@RDate", SqlDbType.DateTime)
        arParms(7).Value = El.RecDate

        arParms(8) = New SqlParameter("@PMethod", SqlDbType.Int)
        arParms(8).Value = El.PaymentMethod

        arParms(9) = New SqlParameter("@Vno", SqlDbType.Int)
        arParms(9).Value = El.VoucherNo

        arParms(10) = New SqlParameter("@chqNo", SqlDbType.VarChar, 5)
        arParms(10).Value = El.ChequeNo

        arParms(11) = New SqlParameter("@bank", SqlDbType.Int)
        arParms(11).Value = El.Bank


        arParms(12) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(12).Value = El.Branch

        arParms(13) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(13).Value = El.Remarks


        arParms(14) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("BranchCode")

        arParms(15) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("EmpCode")

        arParms(16) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("UserCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPaymentMade", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Public Shared Function Update(ByVal El As Mfg_ElPaymentMade) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(17) {}

        arParms(0) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(0).Value = El.currency

        arParms(1) = New SqlParameter("@ExchangeRate", SqlDbType.Int)
        arParms(1).Value = El.ExchangeRate


        arParms(2) = New SqlParameter("@Supplier", SqlDbType.Int)
        arParms(2).Value = El.supplier

        If El.entrydate = "#1/1/3000#" Then
            arParms(3) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
            arParms(3).Value = System.DBNull.Value
        Else
            arParms(3) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
            arParms(3).Value = El.entrydate
        End If


        arParms(4) = New SqlParameter("@Address", SqlDbType.VarChar, 50)
        arParms(4).Value = El.Address




        arParms(5) = New SqlParameter("@AmtPaid", SqlDbType.Money)
        arParms(5).Value = El.AmtPaid

        arParms(6) = New SqlParameter("@InvoiceNo", SqlDbType.Int)
        arParms(6).Value = El.InvoiceNo

        arParms(7) = New SqlParameter("@RDate", SqlDbType.DateTime)
        arParms(7).Value = El.RecDate

        arParms(8) = New SqlParameter("@PMethod", SqlDbType.Int)
        arParms(8).Value = El.PaymentMethod

        arParms(9) = New SqlParameter("@Vno", SqlDbType.Int)
        arParms(9).Value = El.VoucherNo

        arParms(10) = New SqlParameter("@chqNo", SqlDbType.VarChar, 5)
        arParms(10).Value = El.ChequeNo

        arParms(11) = New SqlParameter("@bank", SqlDbType.Int)
        arParms(11).Value = El.Bank


        arParms(12) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(12).Value = El.Branch

        arParms(13) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(13).Value = El.Remarks


        arParms(14) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("BranchCode")

        arParms(15) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("EmpCode")

        arParms(16) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("UserCode")

        arParms(17) = New SqlParameter("@id", SqlDbType.Int)
        arParms(17).Value = El.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePaymentMade", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
  
    Shared Function Delete(ByVal id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim SE As New Supplier
        Dim rowsAffected As Integer = 0


        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeletePaymentMade", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Getsupplierdetails(ByVal EL As Mfg_ElPaymentMade) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@Supp_Id", SqlDbType.Int)
        arParms(2).Value = EL.supplier
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlSupplierdetailsAutoFill", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetInvoicedetails(ByVal EL As Mfg_ElPaymentMade) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@CompanyId", SqlDbType.Int)
        arParms(2).Value = EL.supplier
        arParms(3) = New SqlParameter("@Invoice", SqlDbType.Int)
        arParms(3).Value = EL.InvoiceNo
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlInvoiceDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function amtpaid(ByVal EL As Mfg_ElPaymentMade) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@Supp_Id", SqlDbType.Int)
        arParms(2).Value = EL.supplier

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_PaymentmadeAmtpaid", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function amtpaidInvoice(ByVal EL As Mfg_ElPaymentMade) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@Supp_Id", SqlDbType.Int)
        arParms(2).Value = EL.supplier
        arParms(3) = New SqlParameter("@Invoice", SqlDbType.Int)
        arParms(3).Value = EL.InvoiceNo

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_PaymentmadeAmtpaidInvoice", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function



    'Shared Function GetDuplicateType(ByVal El As Mfg_ElPaymentMade) As Data.DataTable
    '    Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

    '    Dim rowsAffected As Integer = 0
    '    Dim arParms() As SqlParameter = New SqlParameter(4) {}

    '    Dim ds As New DataSet

    '    arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    arParms(0).Value = HttpContext.Current.Session("BranchCode")

    '    arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    arParms(1).Value = HttpContext.Current.Session("Office")

    '    arParms(2) = New SqlParameter("@id", SqlDbType.Int)
    '    arParms(2).Value = El.id
    '    arParms(3) = New SqlParameter("@batch", SqlDbType.VarChar, 50)
    '    arParms(3).Value = El.Batch

    '    arParms(4) = New SqlParameter("@Product", SqlDbType.Int)
    '    arParms(4).Value = El.Productid
    '    Try

    '        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_DuplicateBatchDetails", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    Shared Function GetPayments(ByVal SupplierId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@SupplierId", SqlDbType.Int)
        para(2).Value = SupplierId
        para(3) = New SqlParameter("@StartDate ", SqlDbType.DateTime)
        para(3).Value = StartDate
        para(4) = New SqlParameter("@EndDate ", SqlDbType.DateTime)
        para(4).Value = EndDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Rptpayments", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
