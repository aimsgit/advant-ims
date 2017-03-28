Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLIndividualFormMaster
    Shared Function GetDeptName(ByVal DNDDL As String) As System.Data.DataSet
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        'arParms(0) = New SqlParameter("@branch", SqlDbType.varchar,50)
        'arParms(0).Value = BranchCode
        arParms(0) = New SqlParameter("@BranchTypeCode", SqlDbType.VarChar, 50)
        arParms(0).Value = DNDDL
        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDeptNameDL", arParms)

        Return ds
    End Function
    Public Shared Function GetENPLOYEEDetails(ByVal individual As IndividualFormMaster) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim Para() As SqlParameter = New SqlParameter(2) {}

            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Emp_Id", SqlDbType.Int)
            Para(1).Value = individual.Emp_Id
            'Para(1).Value = HttpContext.Current.Session("Emp_Id")

            Para(2) = New SqlParameter("@office", SqlDbType.VarChar, 2)
            Para(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetEMPDetailsNew]", Para)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetENPLOYEEDetails2(ByVal individual As IndividualFormMaster) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim Para() As SqlParameter = New SqlParameter(2) {}

            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Emp_Id", SqlDbType.Int)
            Para(1).Value = individual.Emp_Id
            'Para(1).Value = HttpContext.Current.Session("Emp_Id")

            Para(2) = New SqlParameter("@office", SqlDbType.VarChar, 2)
            Para(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetEMPDetailsNew2]", Para)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Public Shared Function GetEmployeeCategry(ByVal individual As IndividualFormMaster) As Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim Para() As SqlParameter = New SqlParameter(2) {}

            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@SalaryGradId", SqlDbType.Int)
            Para(1).Value = individual.SalaryGrade
            'Para(1).Value = HttpContext.Current.Session("Emp_Id")

            Para(2) = New SqlParameter("@office", SqlDbType.VarChar, 2)
            Para(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetEmployeeType]", Para)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetGrade() As System.Data.DataSet
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSalaryGrade", arParms)

        Return ds
    End Function
    Shared Function GetDeptType() As System.Data.DataSet
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@Role", SqlDbType.VarChar, HttpContext.Current.Session("UserRole").ToString.Length)
        arParms(2).Value = HttpContext.Current.Session("UserRole")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDeptTypeDDL", arParms)

        Return ds
    End Function
    'Shared Function GetDistrict() As System.Data.DataSet
    '    '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet

    '    Dim arParms() As SqlParameter = New SqlParameter(1) {}
    '    arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    arParms(0).Value = HttpContext.Current.Session("BranchCode")
    '    arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
    '    arParms(1).Value = HttpContext.Current.Session("Office")
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDistrictDDL", arParms)

    '    Return ds
    'End Function
    Shared Function GetBrOffName(ByVal prefixText As String, ByVal BrType As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@BrType", SqlDbType.VarChar, BrType.Length)
        arParms(1).Value = BrType

        arParms(2) = New SqlClient.SqlParameter("@branch", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@office", SqlDbType.VarChar)
        arParms(3).Value = HttpContext.Current.Session("Office")

        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBrName_distnameExt", arParms)
            Dim dt As New DataTable()
            dt = ds.Tables(0)
            Return dt
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetIndividualFormMasterDetails(ByVal individual As IndividualFormMaster) As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(22) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")

        Para(1) = New SqlParameter("@Emp_Id", SqlDbType.Int)
        Para(1).Value = individual.Emp_Id
        'Para(1).Value = HttpContext.Current.Session("Emp_Id")

        Para(2) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Para(2).Value = HttpContext.Current.Session("Office")

        Para(3) = New SqlParameter("@designation", SqlDbType.VarChar, 50)
        Para(3).Value = individual.Designation

        Para(4) = New SqlParameter("@Role", SqlDbType.VarChar, HttpContext.Current.Session("UserRole").ToString.Length)
        Para(4).Value = HttpContext.Current.Session("UserRole")

        Para(5) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        Para(5).Value = individual.Emp_Name

        Para(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Para(6).Value = individual.EmpCode

        'Para(7) = New SqlParameter("@BranchType", SqlDbType.VarChar, 50)
        'Para(7).Value = individual.BranchTypeCode

        Para(7) = New SqlParameter("@EmploymentType", SqlDbType.VarChar, 50)
        Para(7).Value = individual.EmploymentType

        Para(8) = New SqlParameter("@EmpCategory", SqlDbType.VarChar, 50)
        Para(8).Value = individual.EmpCategory

        Para(9) = New SqlParameter("@DOB", SqlDbType.DateTime)
        Para(9).Value = individual.DOB

        Para(10) = New SqlParameter("@DOJ", SqlDbType.DateTime)
        Para(10).Value = individual.DOJ

        Para(11) = New SqlParameter("@Dept", SqlDbType.VarChar, 50)
        Para(11).Value = individual.DeptID

        Para(12) = New SqlParameter("@ContactNo", SqlDbType.VarChar, 100)
        Para(12).Value = individual.ContactNo

        Para(13) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        Para(13).Value = individual.Email

        Para(14) = New SqlParameter("@Qualification", SqlDbType.VarChar, 250)
        Para(14).Value = individual.Qualification

        Para(15) = New SqlParameter("@Sex", SqlDbType.VarChar, 50)
        Para(15).Value = individual.Sex

        Para(16) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        Para(16).Value = individual.Country

        Para(17) = New SqlParameter("@DOL", SqlDbType.DateTime)
        Para(17).Value = individual.DOL

        Para(18) = New SqlParameter("@PassportNo", SqlDbType.VarChar, 30)
        Para(18).Value = individual.PassportNo

        Para(19) = New SqlParameter("@NICNo", SqlDbType.VarChar, 30)
        Para(19).Value = individual.NICNO

        Para(20) = New SqlParameter("@LandlineNo", SqlDbType.VarChar, 100)
        Para(20).Value = individual.LandlineNo
        Para(21) = New SqlParameter("@DOR", SqlDbType.DateTime)
        Para(21).Value = individual.DOR
        Para(22) = New SqlParameter("@DOA", SqlDbType.DateTime)
        Para(22).Value = individual.DOA
        'Para(23) = New SqlParameter(" @Remark", SqlDbType.VarChar, 30)
        'Para(23).Value = individual.Remark

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetIndividualDetails", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function Insert(ByVal individ As IndividualFormMaster) As Integer
        '06-03-2012 Nitin. Function for Inserting the data into table
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(86) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Emp_Name", SqlDbType.NVarChar, individ.Emp_Name.Length())
        para(1).Value = individ.Emp_Name

        para(2) = New SqlParameter("@Emp_Address", SqlDbType.NVarChar, individ.Emp_Address.Length())
        para(2).Value = individ.Emp_Address

        para(3) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        para(3).Value = individ.Country

        para(4) = New SqlParameter("@ContactNo", SqlDbType.NVarChar, individ.ContactNo.Length())
        para(4).Value = individ.ContactNo

        If individ.DOB = "1/1/2999" Then
            para(5) = New SqlParameter("@DOB", SqlDbType.VarChar)
            para(5).Value = System.DBNull.Value
        Else
            para(5) = New SqlParameter("@DOB", SqlDbType.DateTime)
            para(5).Value = individ.DOB
        End If

        para(6) = New SqlParameter("@Email", SqlDbType.Char, individ.Email.Length())
        para(6).Value = individ.Email
        If individ.DOJ = "1/1/3000" Then
            para(7) = New SqlParameter("@DOJ", SqlDbType.VarChar)
            para(7).Value = DBNull.Value
        Else
            para(7) = New SqlParameter("@DOJ", SqlDbType.DateTime)
            para(7).Value = individ.DOJ
        End If


        If individ.DOL = "1/1/3100" Then
            para(8) = New SqlParameter("@DOL", SqlDbType.VarChar)
            para(8).Value = DBNull.Value
        Else
            para(8) = New SqlParameter("@DOL", SqlDbType.DateTime)
            para(8).Value = individ.DOL
        End If

        'para(8) = New SqlParameter("@DOL", SqlDbType.DateTime)
        'para(8).Value = individ.DOL

        para(9) = New SqlParameter("@Designation", SqlDbType.Char, individ.Designation.Length())
        para(9).Value = individ.Designation

        para(10) = New SqlParameter("@Branch_Code", SqlDbType.VarChar, individ.Branch_Code.Length())
        para(10).Value = individ.Branch_Code

        para(11) = New SqlParameter("@Salary", SqlDbType.Money)
        para(11).Value = individ.Salary

        para(12) = New SqlParameter("@AccountNo", SqlDbType.NVarChar, individ.AccountNo.Length())
        para(12).Value = individ.AccountNo

        para(13) = New SqlParameter("@AgentTypeCode", SqlDbType.Int)
        para(13).Value = individ.AgentTypeCode

        para(14) = New SqlParameter("@Photos", SqlDbType.VarChar, individ.Photos.Length())
        para(14).Value = individ.Photos

        para(15) = New SqlParameter("@Emp_Code", SqlDbType.NVarChar, individ.Emp_Code.Length())
        para(15).Value = individ.Emp_Code

        'para(16) = New SqlParameter("@BranchTypeCode", SqlDbType.VarChar, individ.BranchTypeCode.Length())
        'para(16).Value = individ.BranchTypeCode

        para(16) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        para(16).Value = HttpContext.Current.Session("EmpCode")

        para(17) = New SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
        para(17).Value = HttpContext.Current.Session("UserCode")

        para(18) = New SqlParameter("@Delegate", SqlDbType.NVarChar, individ.Delegate1.Length())
        para(18).Value = individ.Delegate1

        para(19) = New SqlParameter("@Delegated", SqlDbType.VarChar, 2)
        para(19).Value = individ.Delegated

        para(20) = New SqlParameter("@Service", SqlDbType.NVarChar, individ.ServicePeriod.Length())
        para(20).Value = individ.ServicePeriod

        para(21) = New SqlParameter("@Sex", SqlDbType.NVarChar, individ.Sex.Length())
        para(21).Value = individ.Sex

        para(22) = New SqlParameter("@Emp_Type", SqlDbType.NVarChar, individ.EmploymentType.Length())
        para(22).Value = individ.EmploymentType

        para(23) = New SqlParameter("@HRAEmpCode", SqlDbType.NVarChar, individ.HRAEmpCode.Length())
        para(23).Value = individ.HRAEmpCode

        para(24) = New SqlParameter("@FMEmpCode", SqlDbType.NVarChar, individ.FMEmpCode.Length())
        para(24).Value = individ.FMEmpCode

        para(25) = New SqlParameter("@RMEmpCode", SqlDbType.NVarChar, individ.RMEmpCode.Length())
        para(25).Value = individ.RMEmpCode

        para(26) = New SqlParameter("@PanNo", SqlDbType.VarChar, 50)
        para(26).Value = individ.PANNO

        para(27) = New SqlParameter("@Qualification", SqlDbType.NVarChar, 250)
        para(27).Value = individ.Qualification

        para(28) = New SqlParameter("@EmpCategory", SqlDbType.VarChar, 50)
        para(28).Value = individ.EmpCategory

        para(29) = New SqlParameter("@EmpType", SqlDbType.NVarChar, 50)
        para(29).Value = individ.EmpType

        para(30) = New SqlParameter("@DeptId", SqlDbType.Int)
        para(30).Value = individ.dpt_Id

        para(31) = New SqlParameter("@NICNO", SqlDbType.NVarChar, individ.NICNO.Length())
        para(31).Value = individ.NICNO

        para(32) = New SqlParameter("@Corres_Address", SqlDbType.NVarChar, individ.Corres_Address.Length)
        para(32).Value = individ.Corres_Address

        para(33) = New SqlParameter("@Hostel", SqlDbType.NVarChar, individ.Hostel.Length)
        para(33).Value = individ.Hostel

        para(34) = New SqlParameter("@Transport", SqlDbType.NVarChar, individ.Transport.Length())
        para(34).Value = individ.Transport

        para(35) = New SqlParameter("@FatherName", SqlDbType.NVarChar, individ.FatherName.Length)
        para(35).Value = individ.FatherName

        para(36) = New SqlParameter("@SpouseName", SqlDbType.NVarChar, individ.SpouseName.Length())
        para(36).Value = individ.SpouseName

        para(37) = New SqlParameter("@NameInPassport", SqlDbType.NVarChar, individ.NameInPassport.Length())
        para(37).Value = individ.NameInPassport

        para(38) = New SqlParameter("@PlaceofIssue", SqlDbType.NVarChar, individ.PlaceofIssue.Length())
        para(38).Value = individ.PlaceofIssue

        para(39) = New SqlParameter("@PassportNo", SqlDbType.NVarChar, individ.PassportNo.Length())
        para(39).Value = individ.PassportNo

        If individ.PassportExpiryDate = "1/1/3000" Then
            para(40) = New SqlParameter("@PassportExpiryDate", SqlDbType.VarChar)
            para(40).Value = System.DBNull.Value
        Else
            para(40) = New SqlParameter("@PassportExpiryDate", SqlDbType.DateTime)
            para(40).Value = individ.PassportExpiryDate
        End If

        If individ.PassportIssueDate = "1/1/3000" Then
            para(41) = New SqlParameter("@PassportIssueDate", SqlDbType.VarChar)
            para(41).Value = System.DBNull.Value
        Else
            para(41) = New SqlParameter("@PassportIssueDate", SqlDbType.DateTime)
            para(41).Value = individ.PassportIssueDate
        End If

        If individ.VisaIssueDate = "1/1/3000" Then
            para(42) = New SqlParameter("@VisaIssueDate", SqlDbType.VarChar)
            para(42).Value = DBNull.Value
        Else
            para(42) = New SqlParameter("@VisaIssueDate", SqlDbType.DateTime)
            para(42).Value = individ.VisaIssueDate
        End If

        If individ.VisaExpiryDate = "1/1/3000" Then
            para(43) = New SqlParameter("@VisaExpiryDate", SqlDbType.VarChar)
            para(43).Value = DBNull.Value
        Else
            para(43) = New SqlParameter("@VisaExpiryDate", SqlDbType.DateTime)
            para(43).Value = individ.VisaExpiryDate
        End If

        para(44) = New SqlParameter("@VisaNo", SqlDbType.VarChar, 50)
        para(44).Value = individ.VisaNo

        If individ.FRROExpDate = "1/1/3000" Then
            para(45) = New SqlParameter("@FRROExpDate", SqlDbType.VarChar)
            para(45).Value = DBNull.Value
        Else
            para(45) = New SqlParameter("@FRROExpDate", SqlDbType.DateTime)
            para(45).Value = individ.FRROExpDate
        End If

        para(46) = New SqlParameter("@MotherName", SqlDbType.NVarChar, 100)
        para(46).Value = individ.MotherName

        para(47) = New SqlParameter("@PFNo", SqlDbType.NVarChar, 50)
        para(47).Value = individ.PFNo

        para(48) = New SqlParameter("@ESINo", SqlDbType.NVarChar, 50)
        para(48).Value = individ.ESINo

        para(49) = New SqlParameter("@VDA", SqlDbType.NVarChar, 50)
        para(49).Value = individ.VDA

        para(50) = New SqlParameter("@Grade", SqlDbType.Int)
        para(50).Value = individ.SalaryGrade

        para(51) = New SqlParameter("@LandlineNo", SqlDbType.VarChar, 50)
        para(51).Value = individ.LandlineNo

        para(52) = New SqlParameter("@Nationality", SqlDbType.NVarChar, 50)
        para(52).Value = individ.Nationality

        para(53) = New SqlParameter("@Religion", SqlDbType.NVarChar, 50)
        para(53).Value = individ.Religion

        para(54) = New SqlParameter("@Ethnicity", SqlDbType.NVarChar, 50)
        para(54).Value = individ.Ethnicity

        para(55) = New SqlParameter("@CivilStates", SqlDbType.NVarChar, 50)
        para(55).Value = individ.CivilStates
        If individ.DOR = "1/1/3100" Then
            para(56) = New SqlParameter("@DOR", SqlDbType.VarChar)
            para(56).Value = DBNull.Value
        Else
            para(56) = New SqlParameter("@DOR", SqlDbType.DateTime)
            para(56).Value = individ.DOR
        End If
        If individ.DOA = "1/1/3100" Then
            para(57) = New SqlParameter("@DOA", SqlDbType.DateTime)
            para(57).Value = DBNull.Value
        Else
            para(57) = New SqlParameter("@DOA", SqlDbType.DateTime)
            para(57).Value = individ.DOA
        End If
        para(58) = New SqlParameter("@Othername", SqlDbType.VarChar, 50)
        para(58).Value = individ.OtherName

        para(59) = New SqlParameter("@Initial", SqlDbType.VarChar, 50)
        para(59).Value = individ.Initial

        para(60) = New SqlParameter("@PersonalFileNo", SqlDbType.VarChar, 50)
        para(60).Value = individ.PersonalFileNo

        If individ.DOP = "1/1/3000" Then
            para(61) = New SqlParameter("@DateOfPromotion", SqlDbType.DateTime)
            para(61).Value = DBNull.Value
        Else
            para(61) = New SqlParameter("@DateOfPromotion", SqlDbType.DateTime)
            para(61).Value = individ.DOP
        End If

        para(62) = New SqlParameter("@Nominee", SqlDbType.VarChar, 50)
        para(62).Value = individ.Nominee

        para(63) = New SqlParameter("@Race", SqlDbType.VarChar, 50)
        para(63).Value = individ.Race

        para(64) = New SqlParameter("@ETF", SqlDbType.VarChar, 50)
        para(64).Value = individ.ETF

        para(65) = New SqlParameter("@Distric", SqlDbType.VarChar, 50)
        para(65).Value = individ.Distric

        para(66) = New SqlParameter("@City", SqlDbType.VarChar, 50)
        para(66).Value = individ.City

        para(67) = New SqlParameter("@Pincode", SqlDbType.VarChar, 50)
        para(67).Value = individ.PinCode

        para(68) = New SqlParameter("@Statename", SqlDbType.Int)
        para(68).Value = individ.StateName

        para(69) = New SqlParameter("@Title", SqlDbType.VarChar, 50)
        para(69).Value = individ.Title

        para(70) = New SqlParameter("@Gratuity", SqlDbType.VarChar, 50)
        para(70).Value = individ.Gratuity

        para(71) = New SqlParameter("@Pension", SqlDbType.VarChar, 2)
        para(71).Value = individ.Pension

        para(72) = New SqlParameter("@Promotion", SqlDbType.VarChar, 2)
        para(72).Value = individ.Promotion

        para(73) = New SqlParameter("@Increment", SqlDbType.VarChar, 2)
        para(73).Value = individ.Increment

        para(74) = New SqlParameter("@Uniform", SqlDbType.VarChar, 2)
        para(74).Value = individ.Uniform

        para(75) = New SqlParameter("@Resignation", SqlDbType.VarChar, 2)
        para(75).Value = individ.Resignation

        para(76) = New SqlParameter("@ModeOfpayment", SqlDbType.Int)
        para(76).Value = individ.ModeOfpayement

        If individ.SalaryRevDate = "01/01/9100" Then
            para(77) = New SqlParameter("@SalaryRevDate", SqlDbType.DateTime)
            para(77).Value = DBNull.Value
        Else
            para(77) = New SqlParameter("@SalaryRevDate", SqlDbType.DateTime)
            para(77).Value = individ.SalaryRevDate
        End If

        para(78) = New SqlParameter("@PFACCNO", SqlDbType.VarChar, 50)
        para(78).Value = individ.PFACCNO


        para(79) = New SqlParameter("@Settelment", SqlDbType.VarChar, 2)
        para(79).Value = individ.Settelement

        para(80) = New SqlParameter("@Pensionable", SqlDbType.VarChar, 2)
        para(80).Value = individ.Pensionable


        para(81) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        para(81).Value = HttpContext.Current.Session("Office")

        para(82) = New SqlParameter("@MiddleName", SqlDbType.VarChar, 50)
        para(82).Value = individ.MiddleName

        para(83) = New SqlParameter("@StopSalary", SqlDbType.VarChar, 2)
        para(83).Value = individ.StopSalary

        If individ.StopSalaryDate = "1/1/2999" Then
            para(84) = New SqlParameter("@StopSalaryDate", SqlDbType.DateTime)
            para(84).Value = DBNull.Value
        Else
            para(84) = New SqlParameter("@StopSalaryDate", SqlDbType.DateTime)
            para(84).Value = individ.StopSalaryDate
        End If

        para(85) = New SqlParameter("@StopSalaryReason", SqlDbType.VarChar, 50)
        para(85).Value = individ.StopSalaryReason

        para(86) = New SqlParameter("@Remark", SqlDbType.VarChar, 50)
        para(86).Value = individ.Remark
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveIndividualFormMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal ind As IndividualFormMaster) As Integer
        '24-11-2010 Kusum.C.Akki. Function for Updating the data into table'
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(86) {}

        para(0) = New SqlParameter("@Emp_Id", SqlDbType.Int)
        para(0).Value = ind.Emp_Id

        para(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@Emp_Name", SqlDbType.NVarChar, 100)
        para(2).Value = ind.Emp_Name

        para(3) = New SqlParameter("@Emp_Address", SqlDbType.NVarChar, 100)
        para(3).Value = ind.Emp_Address

        para(4) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        para(4).Value = ind.Country

        para(5) = New SqlParameter("@ContactNo", SqlDbType.NVarChar, 100)
        para(5).Value = ind.ContactNo

        para(6) = New SqlParameter("@DOB", SqlDbType.DateTime)
        para(6).Value = ind.DOB

        para(7) = New SqlParameter("@Email", SqlDbType.NVarChar, 100)
        para(7).Value = ind.Email

        If ind.DOJ = "1/1/3000" Then
            para(8) = New SqlParameter("@DOJ", SqlDbType.VarChar)
            para(8).Value = DBNull.Value
        Else
            para(8) = New SqlParameter("@DOJ", SqlDbType.DateTime)
            para(8).Value = ind.DOJ
        End If


        If ind.DOL = "1/1/3100" Then
            para(9) = New SqlParameter("@DOL", SqlDbType.VarChar)
            para(9).Value = DBNull.Value
        Else
            para(9) = New SqlParameter("@DOL", SqlDbType.DateTime)
            para(9).Value = ind.DOL
        End If

        para(10) = New SqlParameter("@Designation", SqlDbType.Char, ind.Designation.Length)
        para(10).Value = ind.Designation

        para(11) = New SqlParameter("@Branch_Code", SqlDbType.NVarChar, 50)
        para(11).Value = ind.Branch_Code

        para(12) = New SqlParameter("@Salary", SqlDbType.Money)
        para(12).Value = ind.Salary

        para(13) = New SqlParameter("@AccountNo", SqlDbType.NVarChar, 50)
        para(13).Value = ind.AccountNo

        para(14) = New SqlParameter("@AgentTypeCode", SqlDbType.Int)
        para(14).Value = ind.AgentTypeCode

        para(15) = New SqlParameter("@Photos", SqlDbType.NVarChar, 255)
        para(15).Value = ind.Photos

        para(16) = New SqlParameter("@Emp_Code", SqlDbType.NVarChar, 50)
        para(16).Value = ind.Emp_Code

        'para(17) = New SqlParameter("@BranchTypeCode", SqlDbType.NVarChar, 50)
        'para(17).Value = ind.BranchTypeCode

        para(17) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        para(17).Value = HttpContext.Current.Session("EmpCode")

        para(18) = New SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
        para(18).Value = HttpContext.Current.Session("UserCode")

        para(19) = New SqlParameter("@Delegate", SqlDbType.NVarChar, ind.Delegate1.Length)
        para(19).Value = ind.Delegate1

        para(20) = New SqlParameter("@Delegated", SqlDbType.NVarChar, 2)
        para(20).Value = ind.Delegated

        para(21) = New SqlParameter("@Service", SqlDbType.NVarChar, 20)
        para(21).Value = ind.ServicePeriod

        para(22) = New SqlParameter("@Sex", SqlDbType.NVarChar, 20)
        para(22).Value = ind.Sex

        para(23) = New SqlParameter("@Emp_Type", SqlDbType.NVarChar, ind.EmploymentType.Length)
        para(23).Value = ind.EmploymentType

        para(24) = New SqlParameter("@HRAEmpCode", SqlDbType.NVarChar, ind.HRAEmpCode.Length)
        para(24).Value = ind.HRAEmpCode

        para(25) = New SqlParameter("@FMEmpCode", SqlDbType.NVarChar, ind.FMEmpCode.Length)
        para(25).Value = ind.FMEmpCode

        para(26) = New SqlParameter("@RMEmpCode", SqlDbType.NVarChar, ind.RMEmpCode.Length)
        para(26).Value = ind.RMEmpCode

        para(27) = New SqlParameter("@PanNo", SqlDbType.NVarChar, 50)
        para(27).Value = ind.PANNO

        para(28) = New SqlParameter("@Qualification", SqlDbType.NVarChar, 250)
        para(28).Value = ind.Qualification

        para(29) = New SqlParameter("@EmpCategory", SqlDbType.VarChar, 50)
        para(29).Value = ind.EmpCategory

        para(30) = New SqlParameter("@EmpType", SqlDbType.NVarChar, 50)
        para(30).Value = ind.EmpType

        para(31) = New SqlParameter("@NICNO", SqlDbType.NVarChar, ind.NICNO.Length())
        para(31).Value = ind.NICNO

        para(32) = New SqlParameter("@Corres_Address", SqlDbType.NVarChar, ind.Corres_Address.Length)
        para(32).Value = ind.Corres_Address

        para(33) = New SqlParameter("@Hostel", SqlDbType.NVarChar, ind.Hostel.Length)
        para(33).Value = ind.Hostel

        para(34) = New SqlParameter("@Transport", SqlDbType.NVarChar, ind.Transport.Length())
        para(34).Value = ind.Transport

        para(35) = New SqlParameter("@FatherName", SqlDbType.NVarChar, ind.FatherName.Length)
        para(35).Value = ind.FatherName

        para(36) = New SqlParameter("@SpouseName", SqlDbType.NVarChar, ind.SpouseName.Length())
        para(36).Value = ind.SpouseName

        para(37) = New SqlParameter("@NameInPassport", SqlDbType.NVarChar, ind.NameInPassport.Length())
        para(37).Value = ind.NameInPassport

        para(38) = New SqlParameter("@PlaceofIssue", SqlDbType.NVarChar, ind.PlaceofIssue.Length())
        para(38).Value = ind.PlaceofIssue

        para(39) = New SqlParameter("@PassportNo", SqlDbType.NVarChar, ind.PassportNo.Length())
        para(39).Value = ind.PassportNo

        If ind.PassportExpiryDate = "1/1/3000" Then
            para(40) = New SqlParameter("@PassportExpiryDate", SqlDbType.VarChar)
            para(40).Value = System.DBNull.Value
        Else
            para(40) = New SqlParameter("@PassportExpiryDate", SqlDbType.DateTime)
            para(40).Value = ind.PassportExpiryDate
        End If

        If ind.PassportIssueDate = "1/1/3000" Then
            para(41) = New SqlParameter("@PassportIssueDate", SqlDbType.VarChar)
            para(41).Value = System.DBNull.Value
        Else
            para(41) = New SqlParameter("@PassportIssueDate", SqlDbType.DateTime)
            para(41).Value = ind.PassportIssueDate
        End If

        If ind.VisaIssueDate = "1/1/3000" Then
            para(42) = New SqlParameter("@VisaIssueDate", SqlDbType.VarChar)
            para(42).Value = DBNull.Value
        Else
            para(42) = New SqlParameter("@VisaIssueDate", SqlDbType.DateTime)
            para(42).Value = ind.VisaIssueDate
        End If

        If ind.VisaExpiryDate = "1/1/3000" Then
            para(43) = New SqlParameter("@VisaExpiryDate", SqlDbType.VarChar)
            para(43).Value = DBNull.Value
        Else
            para(43) = New SqlParameter("@VisaExpiryDate", SqlDbType.DateTime)
            para(43).Value = ind.VisaExpiryDate
        End If

        para(44) = New SqlParameter("@VisaNo", SqlDbType.NVarChar, 50)
        para(44).Value = ind.VisaNo

        If ind.FRROExpDate = "1/1/3000" Then
            para(45) = New SqlParameter("@FRROExpDate", SqlDbType.NVarChar)
            para(45).Value = DBNull.Value
        Else
            para(45) = New SqlParameter("@FRROExpDate", SqlDbType.DateTime)
            para(45).Value = ind.FRROExpDate
        End If

        para(46) = New SqlParameter("@DeptId", SqlDbType.Int)
        para(46).Value = ind.dpt_Id

        para(47) = New SqlParameter("@MotherName", SqlDbType.NVarChar, 100)
        para(47).Value = ind.MotherName

        para(48) = New SqlParameter("@PFNo", SqlDbType.NVarChar, 50)
        para(48).Value = ind.PFNo

        para(49) = New SqlParameter("@ESINo", SqlDbType.NVarChar, 50)
        para(49).Value = ind.ESINo

        para(50) = New SqlParameter("@VDA", SqlDbType.NVarChar, 50)
        para(50).Value = ind.VDA

        para(51) = New SqlParameter("@Grade", SqlDbType.Int)
        para(51).Value = ind.SalaryGrade

        para(52) = New SqlParameter("@LandlineNo", SqlDbType.VarChar, 50)
        para(52).Value = ind.LandlineNo

        para(53) = New SqlParameter("@Religion", SqlDbType.NVarChar, 50)
        para(53).Value = ind.Religion

        para(54) = New SqlParameter("@Ethnicity", SqlDbType.NVarChar, 50)
        para(54).Value = ind.Ethnicity

        para(55) = New SqlParameter("@CivilStates", SqlDbType.NVarChar, 50)
        para(55).Value = ind.CivilStates

        para(56) = New SqlParameter("@Nationality", SqlDbType.NVarChar, 50)
        para(56).Value = ind.Nationality
        If ind.DOR = "1/1/3100" Then
            para(57) = New SqlParameter("@DOR", SqlDbType.VarChar)
            para(57).Value = DBNull.Value
        Else
            para(57) = New SqlParameter("@DOR", SqlDbType.DateTime)
            para(57).Value = ind.DOR
        End If
        If ind.DOA = "1/1/3100" Then
            para(58) = New SqlParameter("@DOA", SqlDbType.DateTime)
            para(58).Value = DBNull.Value
        Else
            para(58) = New SqlParameter("@DOA", SqlDbType.DateTime)
            para(58).Value = ind.DOA
        End If
        para(59) = New SqlParameter("@Othername", SqlDbType.VarChar, 50)
        para(59).Value = ind.OtherName

        para(60) = New SqlParameter("@Initial", SqlDbType.VarChar, 50)
        para(60).Value = ind.Initial

        para(61) = New SqlParameter("@PersonalFileNo", SqlDbType.VarChar, 50)
        para(61).Value = ind.PersonalFileNo

        If ind.DOP = "1/1/3000" Then
            para(62) = New SqlParameter("@DateOfPromotion", SqlDbType.DateTime)
            para(62).Value = DBNull.Value
        Else
            para(62) = New SqlParameter("@DateOfPromotion", SqlDbType.DateTime)
            para(62).Value = ind.DOP
        End If

        para(63) = New SqlParameter("@Nominee", SqlDbType.VarChar, 50)
        para(63).Value = ind.Nominee

        para(64) = New SqlParameter("@Race", SqlDbType.VarChar, 50)
        para(64).Value = ind.Race

        para(65) = New SqlParameter("@ETF", SqlDbType.VarChar, 50)
        para(65).Value = ind.ETF

        para(66) = New SqlParameter("@Distric", SqlDbType.VarChar, 50)
        para(66).Value = ind.Distric

        para(67) = New SqlParameter("@City", SqlDbType.VarChar, 50)
        para(67).Value = ind.City

        para(68) = New SqlParameter("@Pincode", SqlDbType.VarChar, 50)
        para(68).Value = ind.PinCode

        para(69) = New SqlParameter("@Statename", SqlDbType.Int)
        para(69).Value = ind.StateName

        para(70) = New SqlParameter("@Gratuity", SqlDbType.VarChar, 50)
        para(70).Value = ind.Gratuity

        para(71) = New SqlParameter("@Pension", SqlDbType.VarChar, 2)
        para(71).Value = ind.Pension

        para(72) = New SqlParameter("@Promotion", SqlDbType.VarChar, 2)
        para(72).Value = ind.Promotion

        para(73) = New SqlParameter("@Increment", SqlDbType.VarChar, 2)
        para(73).Value = ind.Increment

        para(74) = New SqlParameter("@Uniform", SqlDbType.VarChar, 2)
        para(74).Value = ind.Uniform

        para(75) = New SqlParameter("@Resignation", SqlDbType.VarChar, 2)
        para(75).Value = ind.Resignation

        para(76) = New SqlParameter("@Title", SqlDbType.VarChar, 50)
        para(76).Value = ind.Title

        para(77) = New SqlParameter("@ModeOfpayment", SqlDbType.Int)
        para(77).Value = ind.ModeOfpayement

        If ind.SalaryRevDate = "01/01/9100" Then
            para(78) = New SqlParameter("@SalaryRevDate", SqlDbType.DateTime)
            para(78).Value = DBNull.Value
        Else
            para(78) = New SqlParameter("@SalaryRevDate", SqlDbType.DateTime)
            para(78).Value = ind.SalaryRevDate
        End If

        para(79) = New SqlParameter("@PFACCNO", SqlDbType.VarChar, 50)
        para(79).Value = ind.PFACCNO


        para(80) = New SqlParameter("@Settelment", SqlDbType.VarChar, 2)
        para(80).Value = ind.Settelement

        para(81) = New SqlParameter("@Pensionable", SqlDbType.VarChar, 2)
        para(81).Value = ind.Pensionable

        para(82) = New SqlParameter("@MiddleName", SqlDbType.VarChar, 50)
        para(82).Value = ind.MiddleName

        para(83) = New SqlParameter("@StopSalary", SqlDbType.VarChar, 2)
        para(83).Value = ind.StopSalary

        para(84) = New SqlParameter("@StopSalaryDate", SqlDbType.DateTime)
        para(84).Value = ind.StopSalaryDate

        para(85) = New SqlParameter("@StopSalaryReason", SqlDbType.VarChar, 50)
        para(85).Value = ind.StopSalaryReason

        para(86) = New SqlParameter("@Remark", SqlDbType.VarChar, 50)
        para(86).Value = ind.Remark

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_UpdateIndividualFormMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CountryCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCountryEMPExp", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function UpdateDetails(ByVal ind As IndividualFormMaster) As Integer
        '24-11-2010 Kusum.C.Akki. Function for Updating the data into table'
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(86) {}

        para(0) = New SqlParameter("@Emp_Id", SqlDbType.Int)
        para(0).Value = ind.Emp_Id

        para(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@Emp_Name", SqlDbType.NVarChar, 100)
        para(2).Value = ind.Emp_Name

        para(3) = New SqlParameter("@Emp_Address", SqlDbType.NVarChar, 100)
        para(3).Value = ind.Emp_Address

        para(4) = New SqlParameter("@Country", SqlDbType.VarChar, 50)
        para(4).Value = ind.Country

        para(5) = New SqlParameter("@ContactNo", SqlDbType.NVarChar, 100)
        para(5).Value = ind.ContactNo

        para(6) = New SqlParameter("@DOB", SqlDbType.DateTime)
        para(6).Value = ind.DOB

        para(7) = New SqlParameter("@Email", SqlDbType.NVarChar, 100)
        para(7).Value = ind.Email

        If ind.DOJ = "1/1/3000" Then
            para(8) = New SqlParameter("@DOJ", SqlDbType.VarChar)
            para(8).Value = DBNull.Value
        Else
            para(8) = New SqlParameter("@DOJ", SqlDbType.DateTime)
            para(8).Value = ind.DOJ
        End If


        If ind.DOL = "1/1/3100" Then
            para(9) = New SqlParameter("@DOL", SqlDbType.VarChar)
            para(9).Value = DBNull.Value
        Else
            para(9) = New SqlParameter("@DOL", SqlDbType.DateTime)
            para(9).Value = ind.DOL
        End If

        para(10) = New SqlParameter("@Designation", SqlDbType.Char, ind.Designation.Length)
        para(10).Value = ind.Designation

        para(11) = New SqlParameter("@Branch_Code", SqlDbType.NVarChar, 50)
        para(11).Value = ind.Branch_Code

        para(12) = New SqlParameter("@Salary", SqlDbType.Money)
        para(12).Value = ind.Salary

        para(13) = New SqlParameter("@AccountNo", SqlDbType.NVarChar, 50)
        para(13).Value = ind.AccountNo

        para(14) = New SqlParameter("@AgentTypeCode", SqlDbType.Int)
        para(14).Value = ind.AgentTypeCode

        para(15) = New SqlParameter("@Photos", SqlDbType.NVarChar, 255)
        para(15).Value = ind.Photos

        para(16) = New SqlParameter("@Emp_Code", SqlDbType.NVarChar, 50)
        para(16).Value = ind.Emp_Code

        'para(17) = New SqlParameter("@BranchTypeCode", SqlDbType.NVarChar, 50)
        'para(17).Value = ind.BranchTypeCode

        para(17) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        para(17).Value = HttpContext.Current.Session("EmpCode")

        para(18) = New SqlParameter("@UserCode", SqlDbType.NVarChar, 50)
        para(18).Value = HttpContext.Current.Session("UserCode")

        para(19) = New SqlParameter("@Delegate", SqlDbType.NVarChar, ind.Delegate1.Length)
        para(19).Value = ind.Delegate1

        para(20) = New SqlParameter("@Delegated", SqlDbType.NVarChar, 2)
        para(20).Value = ind.Delegated

        para(21) = New SqlParameter("@Service", SqlDbType.NVarChar, 20)
        para(21).Value = ind.ServicePeriod

        para(22) = New SqlParameter("@Sex", SqlDbType.NVarChar, 20)
        para(22).Value = ind.Sex

        para(23) = New SqlParameter("@Emp_Type", SqlDbType.NVarChar, ind.EmploymentType.Length)
        para(23).Value = ind.EmploymentType

        para(24) = New SqlParameter("@HRAEmpCode", SqlDbType.NVarChar, ind.HRAEmpCode.Length)
        para(24).Value = ind.HRAEmpCode

        para(25) = New SqlParameter("@FMEmpCode", SqlDbType.NVarChar, ind.FMEmpCode.Length)
        para(25).Value = ind.FMEmpCode

        para(26) = New SqlParameter("@RMEmpCode", SqlDbType.NVarChar, ind.RMEmpCode.Length)
        para(26).Value = ind.RMEmpCode

        para(27) = New SqlParameter("@PanNo", SqlDbType.NVarChar, 50)
        para(27).Value = ind.PANNO

        para(28) = New SqlParameter("@Qualification", SqlDbType.NVarChar, 250)
        para(28).Value = ind.Qualification

        para(29) = New SqlParameter("@EmpCategory", SqlDbType.VarChar, 50)
        para(29).Value = ind.EmpCategory

        para(30) = New SqlParameter("@EmpType", SqlDbType.NVarChar, 50)
        para(30).Value = ind.EmpType

        para(31) = New SqlParameter("@NICNO", SqlDbType.NVarChar, ind.NICNO.Length())
        para(31).Value = ind.NICNO

        para(32) = New SqlParameter("@Corres_Address", SqlDbType.NVarChar, ind.Corres_Address.Length)
        para(32).Value = ind.Corres_Address

        para(33) = New SqlParameter("@Hostel", SqlDbType.NVarChar, ind.Hostel.Length)
        para(33).Value = ind.Hostel

        para(34) = New SqlParameter("@Transport", SqlDbType.NVarChar, ind.Transport.Length())
        para(34).Value = ind.Transport

        para(35) = New SqlParameter("@FatherName", SqlDbType.NVarChar, ind.FatherName.Length)
        para(35).Value = ind.FatherName

        para(36) = New SqlParameter("@SpouseName", SqlDbType.NVarChar, ind.SpouseName.Length())
        para(36).Value = ind.SpouseName

        para(37) = New SqlParameter("@NameInPassport", SqlDbType.NVarChar, ind.NameInPassport.Length())
        para(37).Value = ind.NameInPassport

        para(38) = New SqlParameter("@PlaceofIssue", SqlDbType.NVarChar, ind.PlaceofIssue.Length())
        para(38).Value = ind.PlaceofIssue

        para(39) = New SqlParameter("@PassportNo", SqlDbType.NVarChar, ind.PassportNo.Length())
        para(39).Value = ind.PassportNo

        If ind.PassportExpiryDate = "1/1/3000" Then
            para(40) = New SqlParameter("@PassportExpiryDate", SqlDbType.VarChar)
            para(40).Value = System.DBNull.Value
        Else
            para(40) = New SqlParameter("@PassportExpiryDate", SqlDbType.DateTime)
            para(40).Value = ind.PassportExpiryDate
        End If

        If ind.PassportIssueDate = "1/1/3000" Then
            para(41) = New SqlParameter("@PassportIssueDate", SqlDbType.VarChar)
            para(41).Value = System.DBNull.Value
        Else
            para(41) = New SqlParameter("@PassportIssueDate", SqlDbType.DateTime)
            para(41).Value = ind.PassportIssueDate
        End If

        If ind.VisaIssueDate = "1/1/3000" Then
            para(42) = New SqlParameter("@VisaIssueDate", SqlDbType.VarChar)
            para(42).Value = DBNull.Value
        Else
            para(42) = New SqlParameter("@VisaIssueDate", SqlDbType.DateTime)
            para(42).Value = ind.VisaIssueDate
        End If

        If ind.VisaExpiryDate = "1/1/3000" Then
            para(43) = New SqlParameter("@VisaExpiryDate", SqlDbType.VarChar)
            para(43).Value = DBNull.Value
        Else
            para(43) = New SqlParameter("@VisaExpiryDate", SqlDbType.DateTime)
            para(43).Value = ind.VisaExpiryDate
        End If

        para(44) = New SqlParameter("@VisaNo", SqlDbType.NVarChar, 50)
        para(44).Value = ind.VisaNo

        If ind.FRROExpDate = "1/1/3000" Then
            para(45) = New SqlParameter("@FRROExpDate", SqlDbType.NVarChar)
            para(45).Value = DBNull.Value
        Else
            para(45) = New SqlParameter("@FRROExpDate", SqlDbType.DateTime)
            para(45).Value = ind.FRROExpDate
        End If

        para(46) = New SqlParameter("@DeptId", SqlDbType.Int)
        para(46).Value = ind.dpt_Id

        para(47) = New SqlParameter("@MotherName", SqlDbType.NVarChar, 100)
        para(47).Value = ind.MotherName

        para(48) = New SqlParameter("@PFNo", SqlDbType.NVarChar, 50)
        para(48).Value = ind.PFNo

        para(49) = New SqlParameter("@ESINo", SqlDbType.NVarChar, 50)
        para(49).Value = ind.ESINo

        para(50) = New SqlParameter("@VDA", SqlDbType.NVarChar, 50)
        para(50).Value = ind.VDA

        para(51) = New SqlParameter("@Grade", SqlDbType.Int)
        para(51).Value = ind.SalaryGrade

        para(52) = New SqlParameter("@LandlineNo", SqlDbType.VarChar, 50)
        para(52).Value = ind.LandlineNo

        para(53) = New SqlParameter("@Religion", SqlDbType.NVarChar, 50)
        para(53).Value = ind.Religion

        para(54) = New SqlParameter("@Ethnicity", SqlDbType.NVarChar, 50)
        para(54).Value = ind.Ethnicity

        para(55) = New SqlParameter("@CivilStates", SqlDbType.NVarChar, 50)
        para(55).Value = ind.CivilStates

        para(56) = New SqlParameter("@Nationality", SqlDbType.NVarChar, 50)
        para(56).Value = ind.Nationality
        If ind.DOR = "1/1/3100" Then
            para(57) = New SqlParameter("@DOR", SqlDbType.VarChar)
            para(57).Value = DBNull.Value
        Else
            para(57) = New SqlParameter("@DOR", SqlDbType.DateTime)
            para(57).Value = ind.DOR
        End If
        If ind.DOA = "1/1/3100" Then
            para(58) = New SqlParameter("@DOA", SqlDbType.DateTime)
            para(58).Value = DBNull.Value
        Else
            para(58) = New SqlParameter("@DOA", SqlDbType.DateTime)
            para(58).Value = ind.DOA
        End If
        para(59) = New SqlParameter("@Othername", SqlDbType.VarChar, 50)
        para(59).Value = ind.OtherName

        para(60) = New SqlParameter("@Initial", SqlDbType.VarChar, 50)
        para(60).Value = ind.Initial

        para(61) = New SqlParameter("@PersonalFileNo", SqlDbType.VarChar, 50)
        para(61).Value = ind.PersonalFileNo

        para(62) = New SqlParameter("@DateOfPromotion", SqlDbType.DateTime)
        para(62).Value = ind.DOP

        para(63) = New SqlParameter("@Nominee", SqlDbType.VarChar, 50)
        para(63).Value = ind.Nominee

        para(64) = New SqlParameter("@Race", SqlDbType.VarChar, 50)
        para(64).Value = ind.Race

        para(65) = New SqlParameter("@ETF", SqlDbType.VarChar, 50)
        para(65).Value = ind.ETF

        para(66) = New SqlParameter("@Distric", SqlDbType.VarChar, 50)
        para(66).Value = ind.Distric

        para(67) = New SqlParameter("@City", SqlDbType.VarChar, 50)
        para(67).Value = ind.City

        para(68) = New SqlParameter("@Pincode", SqlDbType.VarChar, 50)
        para(68).Value = ind.PinCode

        para(69) = New SqlParameter("@Statename", SqlDbType.Int)
        para(69).Value = ind.StateName

        para(70) = New SqlParameter("@Gratuity", SqlDbType.VarChar, 50)
        para(70).Value = ind.Gratuity

        para(71) = New SqlParameter("@Pension", SqlDbType.VarChar, 2)
        para(71).Value = ind.Pension

        para(72) = New SqlParameter("@Promotion", SqlDbType.VarChar, 2)
        para(72).Value = ind.Promotion

        para(73) = New SqlParameter("@Increment", SqlDbType.VarChar, 2)
        para(73).Value = ind.Increment

        para(74) = New SqlParameter("@Uniform", SqlDbType.VarChar, 2)
        para(74).Value = ind.Uniform

        para(75) = New SqlParameter("@Resignation", SqlDbType.VarChar, 2)
        para(75).Value = ind.Resignation

        para(76) = New SqlParameter("@Title", SqlDbType.VarChar, 50)
        para(76).Value = ind.Title

        para(77) = New SqlParameter("@ModeOfpayment", SqlDbType.Int)
        para(77).Value = ind.ModeOfpayement

        para(78) = New SqlParameter("@SalaryRevDate", SqlDbType.DateTime)
        para(78).Value = ind.SalaryRevDate

        para(79) = New SqlParameter("@PFACCNO", SqlDbType.VarChar, 50)
        para(79).Value = ind.PFACCNO


        para(80) = New SqlParameter("@Settelment", SqlDbType.VarChar, 2)
        para(80).Value = ind.Settelement

        para(81) = New SqlParameter("@Pensionable", SqlDbType.VarChar, 2)
        para(81).Value = ind.Pensionable

        para(82) = New SqlParameter("@MiddleName", SqlDbType.VarChar, 50)
        para(82).Value = ind.MiddleName

        para(83) = New SqlParameter("@StopSalary", SqlDbType.VarChar, 2)
        para(83).Value = ind.StopSalary

        para(84) = New SqlParameter("@StopSalaryDate", SqlDbType.DateTime)
        para(84).Value = ind.StopSalaryDate

        para(85) = New SqlParameter("@StopSalaryReason", SqlDbType.VarChar, 50)
        para(85).Value = ind.StopSalaryReason

        para(86) = New SqlParameter("@Remark", SqlDbType.VarChar, 50)
        para(86).Value = ind.Remark

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_UpdateIndividualFormMasterDetails2", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Delete(ByVal Emp_Id As Integer) As Integer
        '24-11-2010 Kusum.C.Akki. Function for Deleting the data
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@Emp_Id", SqlDbType.NVarChar, 50)
        para(0).Value = Emp_Id

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "Proc_DeleteIndividualFormMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetAllEmpHRAExt(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllEmpHRAExt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAllEmpFMExt(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllEmpFMExt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAllEmpRMExt(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllEmpRMExt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetAllDelegate(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllDelegate", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function DDLDesigCombo() As System.Data.DataSet
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDesigDDL", arParms)

        Return ds
    End Function
    Shared Function DDLDesigComboOnBranch(ByVal BranchCode As String) As System.Data.DataSet
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, BranchCode.ToString.Length)
        arParms(0).Value = BranchCode

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDesigDDLOnBranch", arParms)

        Return ds
    End Function
    Shared Function Getddldesig(ByVal indmaster As IndividualFormMaster) As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")

        Para(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDesigDDlOnRB", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function Getdeptcombo(ByVal BranchTypeCode As String) As DataTable
        'Nitin. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Para() As SqlParameter = New SqlParameter(3) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")
        Para(2) = New SqlParameter("@BranchTypeCode", SqlDbType.VarChar, 50)
        Para(2).Value = BranchTypeCode
        Para(3) = New SqlParameter("@Role", SqlDbType.VarChar, HttpContext.Current.Session("UserRole").ToString.Length)
        Para(3).Value = HttpContext.Current.Session("UserRole")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBrName_distnameExt", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetBranchNameC() As DataTable
        'Nitin. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")
        Para(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        Para(2).Value = HttpContext.Current.Session("AccessLevel")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBrName_distnameExtEMP", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Function


    Shared Function GetBranchCobo() As DataTable
        'Nitin. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sp_GetBranchByUID", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    ' Search facility in Individual Details
    Public Function GetSearchDetails(ByVal indmaster As IndividualFormMaster) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        arParms(0) = New SqlParameter("@branch", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        arParms(2).Value = indmaster.EmploymentType

        If indmaster.Emp_Name <> Nothing Then
            arParms(3) = New SqlParameter("@EmpName", SqlDbType.VarChar, 100)
            arParms(3).Value = indmaster.Emp_Name
        Else
            arParms(3) = New SqlParameter("@EmpName", SqlDbType.VarChar, 100)
            arParms(3).Value = "*"
        End If

        If indmaster.EmpCode <> Nothing Then
            arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            arParms(4).Value = indmaster.EmpCode
        Else
            arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            arParms(4).Value = "*"
        End If

        If indmaster.NICNO <> Nothing Then
            arParms(5) = New SqlParameter("@NICNo", SqlDbType.VarChar, 50)
            arParms(5).Value = indmaster.NICNO
        Else
            arParms(5) = New SqlParameter("@NICNo", SqlDbType.VarChar, 50)
            arParms(5).Value = "*"
        End If

        If indmaster.Sex <> "Select" Then
            arParms(6) = New SqlParameter("@Sex", SqlDbType.VarChar, 50)
            arParms(6).Value = indmaster.Sex
        Else
            arParms(6) = New SqlParameter("@Sex", SqlDbType.VarChar, 50)
            arParms(6).Value = "*"
        End If

        If indmaster.Designation <> "Select" Then
            arParms(7) = New SqlParameter("@Desig", SqlDbType.VarChar, 50)
            arParms(7).Value = indmaster.Designation
        Else
            arParms(7) = New SqlParameter("@Desig", SqlDbType.VarChar, 50)
            arParms(7).Value = "*"
        End If

        If indmaster.BranchTypeCode <> "Select" Then
            arParms(8) = New SqlParameter("@BrchType", SqlDbType.VarChar, 50)
            arParms(8).Value = indmaster.BranchTypeCode
        Else
            arParms(8) = New SqlParameter("@BrchType", SqlDbType.VarChar, 50)
            arParms(8).Value = "*"
        End If

        If indmaster.Branch_Code <> Nothing Then
            arParms(9) = New SqlParameter("@brchCode", SqlDbType.VarChar, 50)
            arParms(9).Value = indmaster.Branch_Code
        Else
            arParms(9) = New SqlParameter("@brchCode", SqlDbType.VarChar, 50)
            arParms(9).Value = "*"
        End If

        If indmaster.Emp_Address <> Nothing Then
            arParms(10) = New SqlParameter("@address", SqlDbType.VarChar, 250)
            arParms(10).Value = indmaster.Emp_Address
        Else
            arParms(10) = New SqlParameter("@address", SqlDbType.VarChar, 250)
            arParms(10).Value = "*"
        End If

        If indmaster.DOB <> Nothing Then
            arParms(11) = New SqlParameter("@Dob", SqlDbType.DateTime)
            arParms(11).Value = indmaster.DOB
        Else
            arParms(11) = New SqlParameter("@Dob", SqlDbType.DateTime)
            arParms(11).Value = "01-Jan-1900"
        End If

        If indmaster.DOJ <> Nothing Then
            arParms(12) = New SqlParameter("@Doj", SqlDbType.DateTime)
            arParms(12).Value = indmaster.DOJ
        Else
            arParms(12) = New SqlParameter("@Doj", SqlDbType.DateTime)
            arParms(12).Value = "01-Jan-1900"
        End If

        If indmaster.AccountNo <> Nothing Then
            arParms(13) = New SqlParameter("@Acctno", SqlDbType.VarChar, 50)
            arParms(13).Value = indmaster.AccountNo
        Else
            arParms(13) = New SqlParameter("@Acctno", SqlDbType.VarChar, 50)
            arParms(13).Value = "*"
        End If

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SearchIndividualDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetBranchOfficeName(ByVal prefixText As String, ByVal BrType As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@BrType", SqlDbType.VarChar, BrType.Length)
        arParms(1).Value = BrType

        arParms(2) = New SqlClient.SqlParameter("@branch", SqlDbType.VarChar)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@office", SqlDbType.VarChar)
        arParms(3).Value = HttpContext.Current.Session("Office")

        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranchNameExt", arParms)
            Dim dt As New DataTable()
            dt = ds.Tables(0)
            Return dt
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function CheckDuplicate(ByVal indmaster As IndividualFormMaster) As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Emp_Code", SqlDbType.NVarChar)
        arParms(0).Value = indmaster.Emp_Code
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.NVarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EmployeeDuplicate", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Getddldept() As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")

        Para(1) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DeptCombo", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
End Class

