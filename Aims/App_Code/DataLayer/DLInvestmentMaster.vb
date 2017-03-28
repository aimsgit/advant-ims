Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLInvestmentMaster
    Shared Function GetSponsor() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Endo_ddlSponser", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function Insert(ByVal El As ELInvestmentMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(17) {}

        arParms(0) = New SqlParameter("@Sponsor_ID", SqlDbType.Int)
        arParms(0).Value = El.Sponsor_ID

        arParms(1) = New SqlParameter("@InvestmentAmount", SqlDbType.Money)
        arParms(1).Value = El.InvestmentAmount

        arParms(2) = New SqlParameter("@Currency", SqlDbType.NVarChar, 150)
        arParms(2).Value = El.Currency


        arParms(3) = New SqlParameter("@InvestmentType", SqlDbType.NVarChar, 50)
        arParms(3).Value = El.InvestmentType

        arParms(4) = New SqlParameter("@InvestmentSTDT", SqlDbType.DateTime)
        arParms(4).Value = El.InvestmentSTDT

        If El.InvestmentMaturityDate = "01/01/9000" Then
            arParms(5) = New SqlParameter("@InvestmentMaturityDate", SqlDbType.DateTime)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@InvestmentMaturityDate", SqlDbType.DateTime)
            arParms(5).Value = El.InvestmentMaturityDate
        End If

        arParms(6) = New SqlParameter("@BankID", SqlDbType.Int)
        arParms(6).Value = El.BankID

        arParms(7) = New SqlParameter("@ModeofPayment", SqlDbType.NVarChar, 50)
        arParms(7).Value = El.Paymentmethodid

        arParms(8) = New SqlParameter("@Rateofinterest", SqlDbType.Float)
        arParms(8).Value = El.Rateofinterest

        arParms(9) = New SqlParameter("@InterestAmt", SqlDbType.Money)
        arParms(9).Value = El.InterestAmt

        arParms(10) = New SqlParameter("@AdminCost", SqlDbType.Money)
        arParms(10).Value = El.AdminCost

        arParms(11) = New SqlParameter("@AdminAmt", SqlDbType.Money)
        arParms(11).Value = El.AdminAmt

        arParms(12) = New SqlParameter("@BalanceAmt", SqlDbType.Money)
        arParms(12).Value = El.BalanceAmt

        arParms(13) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
        arParms(13).Value = El.Remarks

        arParms(14) = New SqlParameter("@Empcode", SqlDbType.NVarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("EmpCode")

        arParms(15) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("UserCode")

        arParms(16) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("BranchCode")
        arParms(17) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertInvestment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal El As ELInvestmentMaster) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(17) {}

        arParms(0) = New SqlParameter("@Sponsor_ID", SqlDbType.Int)
        arParms(0).Value = El.Sponsor_ID

        arParms(1) = New SqlParameter("@InvestmentAmount", SqlDbType.Money)
        arParms(1).Value = El.InvestmentAmount

        arParms(2) = New SqlParameter("@Currency", SqlDbType.NVarChar, 150)
        arParms(2).Value = El.Currency


        arParms(3) = New SqlParameter("@InvestmentType", SqlDbType.NVarChar, 50)
        arParms(3).Value = El.InvestmentType

        arParms(4) = New SqlParameter("@InvestmentSTDT", SqlDbType.DateTime)
        arParms(4).Value = El.InvestmentSTDT

        If El.InvestmentMaturityDate = "01/01/9000" Then
            arParms(5) = New SqlParameter("@InvestmentMaturityDate", SqlDbType.DateTime)
            arParms(5).Value = DBNull.Value
        Else
            arParms(5) = New SqlParameter("@InvestmentMaturityDate", SqlDbType.DateTime)
            arParms(5).Value = El.InvestmentMaturityDate
        End If

        arParms(6) = New SqlParameter("@BankID", SqlDbType.Int)
        arParms(6).Value = El.BankID

        arParms(7) = New SqlParameter("@ModeofPayment", SqlDbType.NVarChar, 50)
        arParms(7).Value = El.Paymentmethodid

        arParms(8) = New SqlParameter("@Rateofinterest", SqlDbType.Float)
        arParms(8).Value = El.Rateofinterest

        arParms(9) = New SqlParameter("@InterestAmt", SqlDbType.Money)
        arParms(9).Value = El.InterestAmt

        arParms(10) = New SqlParameter("@AdminCost", SqlDbType.Money)
        arParms(10).Value = El.AdminCost

        arParms(11) = New SqlParameter("@AdminAmt", SqlDbType.Money)
        arParms(11).Value = El.AdminAmt

        arParms(12) = New SqlParameter("@BalanceAmt", SqlDbType.Money)
        arParms(12).Value = El.BalanceAmt

        arParms(13) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
        arParms(13).Value = El.Remarks

        arParms(14) = New SqlParameter("@Empcode", SqlDbType.NVarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("EmpCode")

        arParms(15) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("UserCode")

        arParms(16) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("BranchCode")

        arParms(17) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(17).Value = El.ID


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateInvestment", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayGridValue(ByVal El As ELInvestmentMaster) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.ID

        arParms(3) = New SqlParameter("@Sponsor_ID", SqlDbType.Int)
        arParms(3).Value = El.Sponsor_ID
      

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInvestment", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function GetInvestment() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Endo_ddlInvestmentType", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetROI() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Endo_ddlRateOfInterest", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
