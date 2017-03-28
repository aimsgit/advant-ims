Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Public Class loanmasterDA
    Dim dt As New DataTable
    Dim query As String
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Dim cmd As OleDbCommand
    Public Function getRecords(ByVal id As loanmasterE) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        ds.Clear()
        Try
            Dim arParms() As SqlParameter = New SqlParameter(6) {}
            arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
            arParms(0).Value = id.Loanid

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("Office")

            arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 30)
            arParms(3).Value = id.Empname

            arParms(4) = New SqlParameter("@LoanNo", SqlDbType.VarChar, 30)
            arParms(4).Value = id.Loanidcode

            arParms(5) = New SqlParameter("@LoanType", SqlDbType.VarChar, 200)
            arParms(5).Value = id.Loantype

            arParms(6) = New SqlParameter("@AmountType", SqlDbType.NVarChar, 2)
            arParms(6).Value = id.AmountType

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanRecord", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetDuplicateLoanMaster(ByVal EL As loanmasterE) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}

        para(0) = New SqlParameter("@EmpId", SqlDbType.Int)
        para(0).Value = EL.Empid

        para(1) = New SqlParameter("@LoanNum", SqlDbType.VarChar, 50)
        para(1).Value = EL.Loanidcode

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")

        para(3) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("office")

        para(4) = New SqlParameter("@AmountType", SqlDbType.NVarChar, 2)
        para(4).Value = EL.AmountType
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateLoanMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function update(ByVal Prop As loanmasterE) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(26) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = Prop.Loanid

        arParms(1) = New SqlParameter("@LoanIDCode", SqlDbType.VarChar, 250)
        arParms(1).Value = Prop.Loanidcode

        arParms(2) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(2).Value = Prop.Empname

        arParms(3) = New SqlParameter("@LoanType", SqlDbType.VarChar, 250)
        arParms(3).Value = Prop.Loantype

        arParms(4) = New SqlParameter("@LoanDate", SqlDbType.DateTime)
        arParms(4).Value = Prop.Loandate

        arParms(5) = New SqlParameter("@LoanAmt", SqlDbType.Money)
        arParms(5).Value = Prop.Loanamount

        arParms(6) = New SqlParameter("@InterestRate", SqlDbType.Real)
        arParms(6).Value = Prop.Interestrate

        If Prop.Chequedate = CDate("1/1/1900") Then
            arParms(7) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(7).Value = DBNull.Value
        Else
            arParms(7) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(7).Value = Prop.Chequedate
        End If


        arParms(8) = New SqlParameter("@MonthlyDed", SqlDbType.Money)
        arParms(8).Value = Prop.monthlyded

        arParms(9) = New SqlParameter("@BalanceLoan", SqlDbType.Money)
        arParms(9).Value = Prop.Balanceloan

        arParms(10) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(10).Value = Prop.Startdate

        arParms(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("BranchCode")

        arParms(12) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("UserCode")

        arParms(13) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("EmpCode")

        arParms(14) = New SqlParameter("@ChequeNoAndBank", SqlDbType.VarChar, 50)
        arParms(14).Value = Prop.ChqNo

        arParms(15) = New SqlParameter("@Bank", SqlDbType.Int)
        arParms(15).Value = Prop.bank

        arParms(16) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(16).Value = Prop.branch

        arParms(17) = New SqlParameter("@CurrentMonthlyDed", SqlDbType.Money)
        arParms(17).Value = Prop.CurrentMonthDedu

        arParms(18) = New SqlParameter("@OpeningBal", SqlDbType.Money)
        arParms(18).Value = Prop.OpeningBalance

        arParms(19) = New SqlParameter("@Installment", SqlDbType.Int)
        arParms(19).Value = Prop.TotalInstallment

        arParms(20) = New SqlParameter("@InstallmentCollected", SqlDbType.Int)
        arParms(20).Value = Prop.InstallmentCollected

        arParms(21) = New SqlParameter("@AmountType", SqlDbType.NVarChar, 2)
        arParms(21).Value = Prop.AmountType

        arParms(22) = New SqlParameter("@PaymentMethod", SqlDbType.NVarChar, 100)
        arParms(22).Value = Prop.PaymentMethod

        arParms(23) = New SqlParameter("@GuaranteedBy1", SqlDbType.VarChar, 50)
        arParms(23).Value = Prop.GuaranteedBy1

        arParms(24) = New SqlParameter("@GuaranteedBy2", SqlDbType.VarChar, 50)
        arParms(24).Value = Prop.GuaranteedBy2

        arParms(25) = New SqlParameter("@Remarks", SqlDbType.VarChar, 150)
        arParms(25).Value = Prop.Remarks

        arParms(26) = New SqlParameter("@Recovered", SqlDbType.VarChar, 2)
        arParms(26).Value = Prop.Recovered


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UPDATELoanRecord", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected


    End Function
    Public Sub delete(ByVal LoanId As Int64)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@loanid", SqlDbType.Int)
        arParms.Value = LoanId
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteRecords", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function insertRecord(ByVal Prop As loanmasterE) As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(25) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@LoanIDCode", SqlDbType.VarChar, 50)
        arParms(0).Value = Prop.Loanidcode

        arParms(1) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(1).Value = Prop.Empname

        arParms(2) = New SqlParameter("@LoanType", SqlDbType.VarChar, 250)
        arParms(2).Value = Prop.Loantype

        arParms(3) = New SqlParameter("@LoanDate", SqlDbType.DateTime)
        arParms(3).Value = Prop.Loandate

        arParms(4) = New SqlParameter("@LoanAmt", SqlDbType.Money)
        arParms(4).Value = Prop.Loanamount

        arParms(5) = New SqlParameter("@InterestRate", SqlDbType.Real)
        arParms(5).Value = Prop.Interestrate

        If Prop.Chequedate = CDate("1/1/1900") Then
            arParms(6) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(6).Value = DBNull.Value
        Else
            arParms(6) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
            arParms(6).Value = Prop.Chequedate
        End If

        arParms(7) = New SqlParameter("@MonthlyDed", SqlDbType.Money)
        arParms(7).Value = Prop.monthlyded

        arParms(8) = New SqlParameter("@BalanceLoan", SqlDbType.Money)
        arParms(8).Value = Prop.Balanceloan

        arParms(9) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(9).Value = Prop.Startdate

        arParms(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("BranchCode")

        arParms(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("UserCode")

        arParms(12) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("EmpCode")

        arParms(13) = New SqlParameter("@ChequeNoAndBank", SqlDbType.VarChar, 50)
        arParms(13).Value = Prop.ChqNo

        arParms(14) = New SqlParameter("@Bank", SqlDbType.Int)
        arParms(14).Value = Prop.bank

        arParms(15) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(15).Value = Prop.branch

        arParms(16) = New SqlParameter("@CurrentMonthlyDed", SqlDbType.Money)
        arParms(16).Value = Prop.CurrentMonthDedu

        arParms(17) = New SqlParameter("@OpeningBal", SqlDbType.Money)
        arParms(17).Value = Prop.OpeningBalance

        arParms(18) = New SqlParameter("@Installment", SqlDbType.Int)
        arParms(18).Value = Prop.TotalInstallment

        arParms(19) = New SqlParameter("@InstallmentCollected", SqlDbType.Int)
        arParms(19).Value = Prop.InstallmentCollected

        arParms(20) = New SqlParameter("@AmountType", SqlDbType.NVarChar, 2)
        arParms(20).Value = Prop.AmountType

        arParms(21) = New SqlParameter("@PaymentMethod", SqlDbType.NVarChar, 100)
        arParms(21).Value = Prop.PaymentMethod

        arParms(22) = New SqlParameter("@GuaranteedBy1", SqlDbType.VarChar, 50)
        arParms(22).Value = Prop.GuaranteedBy1

        arParms(23) = New SqlParameter("@GuaranteedBy2", SqlDbType.VarChar, 50)
        arParms(23).Value = Prop.GuaranteedBy2

        arParms(24) = New SqlParameter("@Remarks", SqlDbType.VarChar, 150)
        arParms(24).Value = Prop.Remarks

        arParms(25) = New SqlParameter("@Recovered", SqlDbType.VarChar, 2)
        arParms(25).Value = Prop.Recovered

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertLoanRecord", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetLoanTypeDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanTypeLookupDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpNameDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanEmpNameDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetPaymentMethod() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPaymentMethod", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class

