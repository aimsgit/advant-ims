Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLPaymentReceived

    Shared Function GetBuyer() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlBuyer", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBuyerPaymentRecv() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlBuyerPaymentRecv", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetInvoiceNo(ByVal Party_Id As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@buyer", SqlDbType.Int)
        arParms(2).Value = Party_Id

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlInvoiceNopaymentrec", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Getbuyerdetails(ByVal EL As Mfg_ElPaymentMade) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@Party_Id", SqlDbType.Int)
        arParms(2).Value = EL.supplier
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlBuyerAutoFill", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetPaymentReceived", arParms)


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_PaymentrecAmtpaid", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Public Shared Function Insert(ByVal El As Mfg_ElPaymentMade, ByVal PR As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(17) {}

        arParms(0) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(0).Value = El.currency

        arParms(1) = New SqlParameter("@ExchangeRate", SqlDbType.Int)
        arParms(1).Value = El.ExchangeRate


        arParms(2) = New SqlParameter("@Buyer", SqlDbType.Int)
        arParms(2).Value = El.supplier


        arParms(3) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        arParms(3).Value = El.entrydate



        arParms(4) = New SqlParameter("@Address", SqlDbType.VarChar, 50)
        arParms(4).Value = El.Address




        arParms(5) = New SqlParameter("@AmtRec", SqlDbType.Money)
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

        arParms(17) = New SqlParameter("@PR", SqlDbType.VarChar, 10)
        arParms(17).Value = PR

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertPaymentReceive", arParms)
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


        arParms(2) = New SqlParameter("@Buyer", SqlDbType.Int)
        arParms(2).Value = El.supplier


        arParms(3) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
        arParms(3).Value = El.entrydate



        arParms(4) = New SqlParameter("@Address", SqlDbType.VarChar, 50)
        arParms(4).Value = El.Address




        arParms(5) = New SqlParameter("@AmtRec", SqlDbType.Money)
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
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdatePaymentReceived", arParms)
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
End Class
