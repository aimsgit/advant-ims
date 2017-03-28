Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
'Author Shailesh Kumar Singh
'Date 25-05-2012

Public Class InvestmentDB
    Shared Function Insert(ByVal EL As ELInvestment) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Count As Int32

        Dim arParms() As SqlParameter = New SqlParameter(51) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("EmpID")

        arParms(2) = New SqlParameter("@PanNo", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.PanNo

        arParms(3) = New SqlParameter("@DOJ", SqlDbType.DateTime)
        arParms(3).Value = EL.DOJ

        arParms(4) = New SqlParameter("@CellNo", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.CellNo

        arParms(5) = New SqlParameter("@MailId", SqlDbType.VarChar, 50)
        arParms(5).Value = EL.Email

        arParms(6) = New SqlParameter("@AccountNo", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.AccountNo

        arParms(7) = New SqlParameter("@LICPremium", SqlDbType.Money, 50)
        arParms(7).Value = EL.LICPremium

        arParms(8) = New SqlParameter("@PPF", SqlDbType.Money, 50)
        arParms(8).Value = EL.PPF

        arParms(9) = New SqlParameter("@NSC", SqlDbType.Money, 50)
        arParms(9).Value = EL.NSC

        arParms(10) = New SqlParameter("@IntOnNSC", SqlDbType.Money, 50)
        arParms(10).Value = EL.IntOnNSC

        arParms(11) = New SqlParameter("@ULIP", SqlDbType.Money, 50)
        arParms(11).Value = EL.ULIP

        arParms(12) = New SqlParameter("@ELSS", SqlDbType.Money, 50)
        arParms(12).Value = EL.ELSS

        arParms(13) = New SqlParameter("@NotdMutualFund", SqlDbType.Money, 50)
        arParms(13).Value = EL.NotdMutualFund

        arParms(14) = New SqlParameter("@PrincipalHL", SqlDbType.Money, 50)
        arParms(14).Value = EL.PrincipalHL

        arParms(15) = New SqlParameter("@ChildEduFee", SqlDbType.Money, 50)
        arParms(15).Value = EL.ChildEduFee

        arParms(16) = New SqlParameter("@FixedDeposit", SqlDbType.Money, 50)
        arParms(16).Value = EL.FixedDeposit

        arParms(17) = New SqlParameter("@AnnuityPlan", SqlDbType.Money, 50)
        arParms(17).Value = EL.AnnuityPlan

        arParms(18) = New SqlParameter("@SalSavScheme", SqlDbType.Money, 50)
        arParms(18).Value = EL.SalSavScheme

        arParms(19) = New SqlParameter("@Others", SqlDbType.Money, 50)
        arParms(19).Value = EL.Others

        arParms(20) = New SqlParameter("@Sec80CCC", SqlDbType.Money, 50)
        arParms(20).Value = EL.Sec80CCC

        arParms(21) = New SqlParameter("@Sec80D", SqlDbType.Money, 50)
        arParms(21).Value = EL.Sec80D

        arParms(22) = New SqlParameter("@Sec80DD", SqlDbType.Money, 50)
        arParms(22).Value = EL.Sec80DD

        arParms(23) = New SqlParameter("@Sec80E", SqlDbType.Money, 50)
        arParms(23).Value = EL.Sec80E

        arParms(24) = New SqlParameter("@Sec80U", SqlDbType.Money, 50)
        arParms(24).Value = EL.Sec80U

        arParms(25) = New SqlParameter("@Sec80G", SqlDbType.Money, 50)
        arParms(25).Value = EL.Sec80G

        arParms(26) = New SqlParameter("@Rent", SqlDbType.Money, 50)
        arParms(26).Value = EL.Rent

        arParms(27) = New SqlParameter("@PropertyLocation", SqlDbType.VarChar, 250)
        arParms(27).Value = EL.PropertyLocation

        arParms(28) = New SqlParameter("@InterestOnHL", SqlDbType.Money, 50)
        arParms(28).Value = EL.InterestOnHL

        arParms(29) = New SqlParameter("@LTA", SqlDbType.Money, 50)
        arParms(29).Value = EL.LTA

        arParms(30) = New SqlParameter("@MedicalReimbursement", SqlDbType.Money, 50)
        arParms(30).Value = EL.MedicalReimbursement

        arParms(31) = New SqlParameter("@InternetExp", SqlDbType.Money, 50)
        arParms(31).Value = EL.InternetExp

        arParms(32) = New SqlParameter("@TelephoneExp", SqlDbType.Money, 50)
        arParms(32).Value = EL.TelephoneExp

        arParms(33) = New SqlParameter("@FuelReimbursement", SqlDbType.Money, 50)
        arParms(33).Value = EL.FuelReimbursement

        arParms(34) = New SqlParameter("@Dependent1", SqlDbType.VarChar, 50)
        arParms(34).Value = EL.Dependent1

        arParms(35) = New SqlParameter("@DepRelation1", SqlDbType.VarChar, 50)
        arParms(35).Value = EL.DepRelation1

        arParms(36) = New SqlParameter("@Dependent2", SqlDbType.VarChar, 50)
        arParms(36).Value = EL.Dependent2

        arParms(37) = New SqlParameter("@DepRelation2", SqlDbType.VarChar, 50)
        arParms(37).Value = EL.DepRelation2

        arParms(38) = New SqlParameter("@Dependent3", SqlDbType.VarChar, 50)
        arParms(38).Value = EL.Dependent3

        arParms(39) = New SqlParameter("@DepRelation3", SqlDbType.VarChar, 50)
        arParms(39).Value = EL.DepRelation3

        arParms(40) = New SqlParameter("@Dependent4", SqlDbType.VarChar, 50)
        arParms(40).Value = EL.Dependent4

        arParms(41) = New SqlParameter("@DepRelation4", SqlDbType.VarChar, 50)
        arParms(41).Value = EL.DepRelation4

        arParms(42) = New SqlParameter("@Dependent5", SqlDbType.VarChar, 50)
        arParms(42).Value = EL.Dependent5

        arParms(43) = New SqlParameter("@DepRelation5", SqlDbType.VarChar, 50)
        arParms(43).Value = EL.DepRelation5

        arParms(44) = New SqlParameter("@Dependent6", SqlDbType.VarChar, 50)
        arParms(44).Value = EL.Dependent6

        arParms(45) = New SqlParameter("@DepRelation6", SqlDbType.VarChar, 50)
        arParms(45).Value = EL.DepRelation6

        arParms(46) = New SqlParameter("@Dependent7", SqlDbType.VarChar, 50)
        arParms(46).Value = EL.Dependent7

        arParms(47) = New SqlParameter("@DepRelation7", SqlDbType.VarChar, 50)
        arParms(47).Value = EL.DepRelation7

        arParms(48) = New SqlParameter("@Agree", SqlDbType.VarChar, 2)
        arParms(48).Value = EL.Agree

        arParms(49) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(49).Value = HttpContext.Current.Session("UserCode")

        arParms(50) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(50).Value = HttpContext.Current.Session("EmpCode")
        arParms(51) = New SqlParameter("@II_ID", SqlDbType.Int)
        arParms(51).Value = EL.ID_ID

        Try
            Count = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveInvestmentForm", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return Count
    End Function
    Shared Function EmpAutofill(ByVal Ent As ELInvestment) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        If HttpContext.Current.Session("EmpID") = "" Then
            arParms(0) = New SqlParameter("@EmpID", SqlDbType.Int)
            arParms(0).Value = 0
        Else
            arParms(0) = New SqlParameter("@EmpID", SqlDbType.Int)
            arParms(0).Value = HttpContext.Current.Session("EmpID")
        End If
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        arParms(3) = New SqlParameter("@SFinancialYear", SqlDbType.DateTime)
        arParms(3).Value = HttpContext.Current.Session("FinStartDate")
        arParms(4) = New SqlParameter("@EFinancialYear", SqlDbType.DateTime)
        arParms(4).Value = HttpContext.Current.Session("FinEndDate")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getInvestmentForm", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function displayrecord(ByVal s As ELInvestment) As DataTable
        'Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim ds As New DataSet
        'Dim arParms() As SqlParameter = New SqlParameter(2) {}

        'arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'arParms(0).Value = HttpContext.Current.Session("Office")

        'arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("BranchCode")
        'arParms(2) = New SqlParameter("@II_ID", SqlDbType.Int)
        'arParms(2).Value = s.EmpIDAuto
        'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getInvestmentForm", arParms)
        'Return ds.Tables(0)
    End Function
    Shared Function deleleinvestment(ByVal s As ELInvestment) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@II_ID", SqlDbType.Int)
        arParms.Value = s.EmpIDAuto
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteInvestmentForm", arParms)
        Return rowsaffected
    End Function
End Class
