Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class DataPayroll
    Shared Function GetPayroll(ByVal el As EntPayroll) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(4) {}
            arParms(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Branchcode")
            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")
            arParms(2) = New SqlParameter("@id", SqlDbType.Int)
            arParms(2).Value = el.iMS_id
            arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            arParms(3).Value = el.Empcode
            arParms(4) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
            arParms(4).Value = el.EmpName

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPayrollMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Shared Function CheckDuplicate(ByVal s As EntPayroll) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@EmpId", SqlDbType.Int)
        para(0).Value = s.EMPid

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = s.iMS_id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetDuplicatePayroll", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Shared Function GetPayrollrpt(ByVal insId As Int64, ByVal brnId As Int64, ByVal empId As Int64) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@institute", SqlDbType.Int)
            arParms(0).Value = insId
            arParms(1) = New SqlParameter("@branch", SqlDbType.Int)
            arParms(1).Value = brnId
            arParms(2) = New SqlParameter("@Empid", SqlDbType.Int)
            arParms(2).Value = empId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetPayrollRpt", arParms)
        Catch e As Exception
        End Try
        Return ds
    End Function
    Shared Function InsertLoan(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@LoanCode", SqlDbType.VarChar, 50)
        arParms(0).Value = Prop.LoanCode

        arParms(1) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(1).Value = Prop.Month

        arParms(2) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(2).Value = Prop.Year

        arParms(3) = New SqlParameter("@Emp_Id", SqlDbType.Int)
        arParms(3).Value = Prop.EMPid

        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(5).Value = HttpContext.Current.Session("Office")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@LoanAmt", SqlDbType.Money)
        arParms(8).Value = Prop.LoanAmt

       
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePayrollMasterLoan", arParms)
        Catch e As Exception
        End Try
        Return rowsAffected
    End Function
    Shared Function Insert(ByVal i As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(47) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@DearnessAllw", SqlDbType.Money, 50)
        arParms(0).Value = i.DearnessAllowance

        arParms(1) = New SqlParameter("@EMPID", SqlDbType.Int, 50)
        arParms(1).Value = i.EMPid

        arParms(2) = New SqlParameter("@SalaryRevDate", SqlDbType.DateTime, 100)
        arParms(2).Value = i.SRDate

        arParms(3) = New SqlParameter("@BasicPay", SqlDbType.Money, 50)
        arParms(3).Value = i.BasicPay

        arParms(4) = New SqlParameter("@SpecialAllowance", SqlDbType.Money, 50)
        arParms(4).Value = i.SpecialAllowance

        arParms(5) = New SqlParameter("@HRA", SqlDbType.Money, 50)
        arParms(5).Value = i.HRA

        arParms(6) = New SqlParameter("@Medical", SqlDbType.Money, 50)
        arParms(6).Value = i.Medical

        arParms(7) = New SqlParameter("@TransportAllowance", SqlDbType.Money, 50)
        arParms(7).Value = i.TransportAllowance

        arParms(8) = New SqlParameter("@FixedIncentives", SqlDbType.Money, 50)
        arParms(8).Value = i.FixedIncentive

        arParms(9) = New SqlParameter("@MiscAllw1", SqlDbType.Money, 50)
        arParms(9).Value = i.MA1

        arParms(10) = New SqlParameter("@MiscAllw2", SqlDbType.Money, 50)
        arParms(10).Value = i.MA2

        arParms(11) = New SqlParameter("@MiscAllw3", SqlDbType.Money, 50)
        arParms(11).Value = i.MA3

        arParms(12) = New SqlParameter("@MiscAllw4", SqlDbType.Money, 50)
        arParms(12).Value = i.MA4

        arParms(13) = New SqlParameter("@MiscAllw5", SqlDbType.Money, 50)
        arParms(13).Value = i.MA5

        arParms(14) = New SqlParameter("@MiscAllw6", SqlDbType.Money, 50)
        arParms(14).Value = i.MA6

        arParms(15) = New SqlParameter("@OverTime", SqlDbType.Money, 50)
        arParms(15).Value = i.OverTime

        arParms(16) = New SqlParameter("@Honorary", SqlDbType.Money, 50)
        arParms(16).Value = i.Honorary

        arParms(17) = New SqlParameter("@CityCompAllw", SqlDbType.Money, 50)
        arParms(17).Value = i.CityCompAllw

        arParms(18) = New SqlParameter("@PFDed", SqlDbType.Money, 50)
        arParms(18).Value = i.PF

        arParms(19) = New SqlParameter("@ProfTaxDed", SqlDbType.Money, 50)
        arParms(19).Value = i.ProfTaxDeduction

        arParms(20) = New SqlParameter("@MiscDed1", SqlDbType.Money, 50)
        arParms(20).Value = i.MD1

        arParms(21) = New SqlParameter("@MiscDed2", SqlDbType.Money, 50)
        arParms(21).Value = i.MD2

        arParms(22) = New SqlParameter("@MiscDed3", SqlDbType.Money, 50)
        arParms(22).Value = i.MD3

        arParms(23) = New SqlParameter("@MiscDed4", SqlDbType.Money, 50)
        arParms(23).Value = i.MD4

        arParms(24) = New SqlParameter("@MiscDed5", SqlDbType.Money, 50)
        arParms(24).Value = i.MD5

        arParms(25) = New SqlParameter("@MiscDed6", SqlDbType.Money, 50)
        arParms(25).Value = i.MD6

        arParms(26) = New SqlParameter("@MiscDed7", SqlDbType.Money, 50)
        arParms(26).Value = i.MD7

        arParms(27) = New SqlParameter("@MiscDed8", SqlDbType.Money, 50)
        arParms(27).Value = i.MD8

        arParms(28) = New SqlParameter("@MiscDed9", SqlDbType.Money, 50)
        arParms(28).Value = i.MD9

        arParms(29) = New SqlParameter("@MiscDed10", SqlDbType.Money, 50)
        arParms(29).Value = i.MD10

        arParms(30) = New SqlParameter("@MiscDed11", SqlDbType.Money, 50)
        arParms(30).Value = i.MD11

        arParms(31) = New SqlParameter("@MiscDed12", SqlDbType.Money, 50)
        arParms(31).Value = i.MD12

        arParms(32) = New SqlParameter("@MiscDed13", SqlDbType.Money, 50)
        arParms(32).Value = i.MD13

        arParms(33) = New SqlParameter("@MiscDed14", SqlDbType.Money, 50)
        arParms(33).Value = i.MD14

        arParms(34) = New SqlParameter("@MiscDed15", SqlDbType.Money, 50)
        arParms(34).Value = i.MD15

        arParms(35) = New SqlParameter("@FestAdvance", SqlDbType.Money, 50)
        arParms(35).Value = i.FestAdvantce

        arParms(36) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(36).Value = HttpContext.Current.Session("UserCode")

        arParms(37) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(37).Value = HttpContext.Current.Session("EmpCode")

        arParms(38) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(38).Value = HttpContext.Current.Session("BranchCode")

        arParms(39) = New SqlParameter("@VPF", SqlDbType.Money, 50)
        arParms(39).Value = i.VPF

        arParms(40) = New SqlParameter("@PaymentId", SqlDbType.Int)
        arParms(40).Value = i.PaymentId

        arParms(41) = New SqlParameter("@PFAcct", SqlDbType.VarChar, 50)
        arParms(41).Value = i.PFAcct

        arParms(42) = New SqlParameter("@Stlmnt", SqlDbType.VarChar, 2)
        arParms(42).Value = i.Settlement

        arParms(43) = New SqlParameter("@MiscAllw7", SqlDbType.Money, 50)
        arParms(43).Value = i.MA7

        arParms(44) = New SqlParameter("@MiscAllw8", SqlDbType.Money, 50)
        arParms(44).Value = i.MA8

        arParms(45) = New SqlParameter("@MiscAllw9", SqlDbType.Money, 50)
        arParms(45).Value = i.MA9

        arParms(46) = New SqlParameter("@MiscDed16", SqlDbType.Money, 50)
        arParms(46).Value = i.MD16

        arParms(47) = New SqlParameter("@Pensionable", SqlDbType.VarChar, 2)
        arParms(47).Value = i.Pensionable
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertPayrollMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function Update(ByVal i As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(48) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@DearnessAllw", SqlDbType.Money, 50)
        arParms(0).Value = i.DearnessAllowance

        arParms(1) = New SqlParameter("@EMPID", SqlDbType.Int, 50)
        arParms(1).Value = i.EMPid

        arParms(2) = New SqlParameter("@SalaryRevDate", SqlDbType.DateTime, 100)
        arParms(2).Value = i.SRDate

        arParms(3) = New SqlParameter("@BasicPay", SqlDbType.Money, 50)
        arParms(3).Value = i.BasicPay

        arParms(4) = New SqlParameter("@SpecialAllowance", SqlDbType.Money, 50)
        arParms(4).Value = i.SpecialAllowance

        arParms(5) = New SqlParameter("@HRA", SqlDbType.Money, 50)
        arParms(5).Value = i.HRA

        arParms(6) = New SqlParameter("@Medical", SqlDbType.Money, 50)
        arParms(6).Value = i.Medical

        arParms(7) = New SqlParameter("@TransportAllowance", SqlDbType.Money, 50)
        arParms(7).Value = i.TransportAllowance

        arParms(8) = New SqlParameter("@FixedIncentives", SqlDbType.Money, 50)
        arParms(8).Value = i.FixedIncentive

        arParms(9) = New SqlParameter("@MiscAllw1", SqlDbType.Money, 50)
        arParms(9).Value = i.MA1

        arParms(10) = New SqlParameter("@MiscAllw2", SqlDbType.Money, 50)
        arParms(10).Value = i.MA2

        arParms(11) = New SqlParameter("@MiscAllw3", SqlDbType.Money, 50)
        arParms(11).Value = i.MA3

        arParms(12) = New SqlParameter("@MiscAllw4", SqlDbType.Money, 50)
        arParms(12).Value = i.MA4

        arParms(13) = New SqlParameter("@MiscAllw5", SqlDbType.Money, 50)
        arParms(13).Value = i.MA5

        arParms(14) = New SqlParameter("@MiscAllw6", SqlDbType.Money, 50)
        arParms(14).Value = i.MA6

        arParms(15) = New SqlParameter("@CityCompAllw", SqlDbType.Money, 50)
        arParms(15).Value = i.CityCompAllw

        arParms(16) = New SqlParameter("@OverTime", SqlDbType.Money, 50)
        arParms(16).Value = i.OverTime

        arParms(17) = New SqlParameter("@Honorary", SqlDbType.Money, 50)
        arParms(17).Value = i.Honorary

        arParms(18) = New SqlParameter("@PFDed", SqlDbType.Money, 50)
        arParms(18).Value = i.PF

        arParms(19) = New SqlParameter("@ProfTaxDed", SqlDbType.Money, 50)
        arParms(19).Value = i.ProfTaxDeduction

        arParms(20) = New SqlParameter("@MiscDed1", SqlDbType.Money, 50)
        arParms(20).Value = i.MD1

        arParms(21) = New SqlParameter("@MiscDed2", SqlDbType.Money, 50)
        arParms(21).Value = i.MD2

        arParms(22) = New SqlParameter("@MiscDed3", SqlDbType.Money, 50)
        arParms(22).Value = i.MD3

        arParms(23) = New SqlParameter("@MiscDed4", SqlDbType.Money, 50)
        arParms(23).Value = i.MD4

        arParms(24) = New SqlParameter("@MiscDed5", SqlDbType.Money, 50)
        arParms(24).Value = i.MD5

        arParms(25) = New SqlParameter("@MiscDed6", SqlDbType.Money, 50)
        arParms(25).Value = i.MD6

        arParms(26) = New SqlParameter("@MiscDed7", SqlDbType.Money, 50)
        arParms(26).Value = i.MD7

        arParms(27) = New SqlParameter("@MiscDed8", SqlDbType.Money, 50)
        arParms(27).Value = i.MD8

        arParms(28) = New SqlParameter("@MiscDed9", SqlDbType.Money, 50)
        arParms(28).Value = i.MD9

        arParms(29) = New SqlParameter("@MiscDed10", SqlDbType.Money, 50)
        arParms(29).Value = i.MD10

        arParms(30) = New SqlParameter("@MiscDed11", SqlDbType.Money, 50)
        arParms(30).Value = i.MD11

        arParms(31) = New SqlParameter("@MiscDed12", SqlDbType.Money, 50)
        arParms(31).Value = i.MD12

        arParms(32) = New SqlParameter("@MiscDed13", SqlDbType.Money, 50)
        arParms(32).Value = i.MD13

        arParms(33) = New SqlParameter("@MiscDed14", SqlDbType.Money, 50)
        arParms(33).Value = i.MD14

        arParms(34) = New SqlParameter("@MiscDed15", SqlDbType.Money, 50)
        arParms(34).Value = i.MD15

        arParms(35) = New SqlParameter("@FestAdvance", SqlDbType.Money, 50)
        arParms(35).Value = i.FestAdvantce

        arParms(36) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(36).Value = HttpContext.Current.Session("UserCode")

        arParms(37) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(37).Value = HttpContext.Current.Session("EmpCode")

        arParms(38) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(38).Value = HttpContext.Current.Session("BranchCode")

        arParms(39) = New SqlParameter("@id", SqlDbType.Int)
        arParms(39).Value = i.iMS_id


        arParms(40) = New SqlParameter("@VPF", SqlDbType.Money, 50)
        arParms(40).Value = i.VPF

        arParms(41) = New SqlParameter("@PaymentId", SqlDbType.Int)
        arParms(41).Value = i.PaymentId

        arParms(42) = New SqlParameter("@PFAcct", SqlDbType.VarChar, 50)
        arParms(42).Value = i.PFAcct

        arParms(43) = New SqlParameter("@Stlmnt", SqlDbType.VarChar, 2)
        arParms(43).Value = i.Settlement

        arParms(44) = New SqlParameter("@MiscAllw7", SqlDbType.Money, 50)
        arParms(44).Value = i.MA7

        arParms(45) = New SqlParameter("@MiscAllw8", SqlDbType.Money, 50)
        arParms(45).Value = i.MA8

        arParms(46) = New SqlParameter("@MiscAllw9", SqlDbType.Money, 50)
        arParms(46).Value = i.MA9

        arParms(47) = New SqlParameter("@MiscDed16", SqlDbType.Money, 50)
        arParms(47).Value = i.MD16

        arParms(48) = New SqlParameter("@Pensionable", SqlDbType.VarChar, 2)
        arParms(48).Value = i.Pensionable


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePayrollMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Public Function Rpt(ByVal Mon As Int16, ByVal Yea As Int64, ByVal EmpId As Int64, ByVal id As Int16) As Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim rowsAffected As Integer = 0
    '    Dim querystring As String = ""
    '    Dim ds As DataSet
    '    Try
    '        If id = 0 Then
    '            If EmpId = 0 Then

    '                querystring = "Select * From rptSalarySlip Where MonthNo=" & Mon & "and Year=" & Yea & " and Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID") & ""
    '            Else
    '                querystring = "Select * From rptSalarySlip Where EMP_ID=" & EmpId & " and MonthNo=" & Mon & "and Year=" & Yea & " and Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID") & ""
    '            End If
    '        ElseIf id = 1 Then
    '            querystring = "Select * From  rptSalarySlipEmployeeWise Where EMP_ID=" & EmpId & " and Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID") & ""
    '        ElseIf id = 2 Then
    '            querystring = "Select * From  rptSalarySlipMonthWise Where Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID") & ""
    '        End If

    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, querystring)
    '    Catch e As Exception
    '        ds = New DataSet
    '    End Try
    '    Return ds.Tables(0)
    'End Function   
    Public Function Rpt(ByVal Inst As Int64, ByVal Brch As Int64, ByVal Mon As Int16, ByVal Yea As Int64, ByVal EmpId As Int64, ByVal id As Int16) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Try
        If id = 0 Then
            Dim arParms() As SqlParameter = New SqlParameter(4) {}
            arParms(0) = New SqlParameter("@inst", SqlDbType.Int)
            arParms(0).Value = Inst
            arParms(1) = New SqlParameter("@bran", SqlDbType.Int)
            arParms(1).Value = Brch
            arParms(2) = New SqlParameter("@Mon", SqlDbType.Int)
            arParms(2).Value = Mon
            arParms(3) = New SqlParameter("@Yea", SqlDbType.Int)
            arParms(3).Value = Yea
            arParms(4) = New SqlParameter("@Empid", SqlDbType.Int)
            arParms(4).Value = EmpId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptSalarySlip", arParms)
        ElseIf id = 1 Then
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@inst", SqlDbType.Int)
            arParms(0).Value = Inst
            arParms(1) = New SqlParameter("@bran", SqlDbType.Int)
            arParms(1).Value = Brch
            arParms(2) = New SqlParameter("@Empid", SqlDbType.Int)
            arParms(2).Value = EmpId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptSalarySlipEmployeeWise", arParms)
        ElseIf id = 2 Then
            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@inst", SqlDbType.Int)
            arParms(0).Value = Inst
            arParms(1) = New SqlParameter("@bran", SqlDbType.Int)
            arParms(1).Value = Brch
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptSalarySlipMonthWise", arParms)
        End If
        'Catch e As Exception
        'ds = New DataSet
        ' End Try
        Return ds.Tables(0)
    End Function
    Shared Function ChangeFlag(ByVal Id As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@PMID", SqlDbType.Int, 50)
        arParms.Value = Id.iMS_id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ChangePayrollMasterFlag", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
