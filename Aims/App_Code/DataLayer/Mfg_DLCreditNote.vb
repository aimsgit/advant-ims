Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLCreditNote
    Shared Function GetInvoiceNo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetInvoiceNo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDetails(ByVal EL As Mfg_ELCreditNote) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Invoice_Id", SqlDbType.Int)
        arParms(2).Value = EL.Invoiveid

        arParms(3) = New SqlParameter("@InvoiceType", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.InvoiveType


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_PurchaseInvoiceDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal EL As Mfg_ELCreditNote) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(1).Value = EL.Invoiveid

        arParms(2) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(2).Value = EL.Currency

        arParms(3) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        arParms(3).Value = EL.ExchangeRate

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.Remarks

        arParms(5) = New SqlParameter("@SupplierBuyer", SqlDbType.Int)
        arParms(5).Value = EL.Supplier_Buyer

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@InvoiceType", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.InvoiveType

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(9).Value = EL.Amount
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertCreditNote", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As Mfg_ELCreditNote) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@InvoiceId", SqlDbType.Int)
        arParms(1).Value = EL.Invoiveid

        arParms(2) = New SqlParameter("@Currency", SqlDbType.Int)
        arParms(2).Value = EL.Currency

        arParms(3) = New SqlParameter("@ExchangeRate", SqlDbType.Float)
        arParms(3).Value = EL.ExchangeRate

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.Remarks

        arParms(5) = New SqlParameter("@SupplierBuyer", SqlDbType.Int)
        arParms(5).Value = EL.Supplier_Buyer

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@InvoiceType", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.InvoiveType

        arParms(8) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@Amount", SqlDbType.Money)
        arParms(9).Value = EL.Amount

        arParms(10) = New SqlParameter("@id", SqlDbType.Int)
        arParms(10).Value = EL.id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateCreditNote", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetGridData(ByVal EL As Mfg_ELCreditNote) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetCreditNote", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal EL As Mfg_ELCreditNote) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@id", SqlDbType.Int)
        arParms.Value = EL.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteCreditNote", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

End Class
