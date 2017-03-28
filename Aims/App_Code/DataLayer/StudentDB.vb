Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Partial Public Class StudentDB
    Dim hit As Int16
    Dim hit1 As Int16
    Dim admissionNo As String
    Public Sub New()
    End Sub
    Public Shared Function GetDatStd(ByVal prefixText As String, ByVal crs As Int64, ByVal btch As Int64, ByVal Office As String, ByVal BranchCode As String) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@StdCode", SqlDbType.VarChar, 100)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Ins", SqlDbType.Int)
        arParms(1).Value = Office

        arParms(2) = New SqlParameter("@Brn", SqlDbType.Int)
        arParms(2).Value = BranchCode

        arParms(3) = New SqlParameter("@Crs", SqlDbType.Int)
        arParms(3).Value = crs

        arParms(4) = New SqlParameter("@btch", SqlDbType.Int)
        arParms(4).Value = btch

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetStudentExt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Code By JinaPriya - 9/3/2015 [Autofill studentcode on selecting StudentName]
    Public Shared Function GetDataStudent(ByVal prefixText As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, 50)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStdName", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'Code By JinaPriya - 9/3/2015 [Autofill StudentName on selecting studentcode]
    Public Shared Function GetDataStudentID(ByVal prefixText As String, ByVal CourseId As Integer, ByVal BatchId As Integer) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, 50)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(3).Value = CourseId

        arParms(4) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(4).Value = BatchId


        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStdEnquiryCode", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Public Shared Function GetDatStd1(ByVal prefixText As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@StdCode", SqlDbType.VarChar, 100)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetStudentExt1", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetDatStd2(ByVal prefixText As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, 50)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStdDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetDatStd3(ByVal prefixText As String, ByVal Branchcode As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, 50)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = Branchcode
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStdDetails3", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function



    Shared Function GetHouseName() As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}


        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_HouseNameDDL", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetDtaCourse() As System.Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}


        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCourseExt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Shared Function GetDatStdName(ByVal prefixText As String) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        arParms(0) = New SqlParameter("@StdName", SqlDbType.VarChar, 10)
        arParms(0).Value = prefixText
        arParms(1) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetStdNameExt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function Insert(ByVal s As Student) As Integer
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

            Dim rowsAffected As Integer = 0

            Dim arParms() As SqlParameter = New SqlParameter(103) {}

            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(0).Value = "0"

            arParms(1) = New SqlParameter("@name", SqlDbType.NVarChar, 100)
            arParms(1).Value = s.Name
            If s.Code = "" Then
                arParms(2) = New SqlParameter("@code", SqlDbType.NVarChar, 50)
                arParms(2).Value = ""
            Else
                arParms(2) = New SqlParameter("@code", SqlDbType.NVarChar, 50)
                arParms(2).Value = s.Code
            End If


            arParms(3) = New SqlParameter("@dob", SqlDbType.DateTime)
            arParms(3).Value = s.DateOfBirth

            arParms(4) = New SqlParameter("@fname", SqlDbType.NVarChar, 100)
            arParms(4).Value = s.FatherName

            arParms(5) = New SqlParameter("@foccupation", SqlDbType.NVarChar, 100)
            arParms(5).Value = s.FatherOccupation

            arParms(6) = New SqlParameter("@income", SqlDbType.Money)
            arParms(6).Value = s.AnnualIncome

            arParms(7) = New SqlParameter("@paddr", SqlDbType.NVarChar, 250)
            arParms(7).Value = s.PermanentAddress

            arParms(8) = New SqlParameter("@taddr", SqlDbType.NVarChar, 250)
            arParms(8).Value = s.TemporaryAddress

            arParms(9) = New SqlParameter("@contactno", SqlDbType.NVarChar, 50)
            arParms(9).Value = s.ContactNumber

            arParms(10) = New SqlParameter("@sex", SqlDbType.NVarChar, 50)
            arParms(10).Value = s.Sex

            arParms(11) = New SqlParameter("@category", SqlDbType.NVarChar, 50)
            arParms(11).Value = s.Category

            arParms(12) = New SqlParameter("@courseid", SqlDbType.Int)
            arParms(12).Value = s.CourseId

            arParms(13) = New SqlParameter("@A_year", SqlDbType.Int)
            arParms(13).Value = s.A_year
            arParms(14) = New SqlParameter("@feecollected", SqlDbType.NVarChar, 2)
            arParms(14).Value = s.Feecollected

            arParms(15) = New SqlParameter("@sponsorid", SqlDbType.Int)
            arParms(15).Value = s.SponsorId

            arParms(16) = New SqlParameter("@admindate", SqlDbType.DateTime)
            arParms(16).Value = s.AdmissionDate

            arParms(17) = New SqlParameter("@batchNo", SqlDbType.Int)
            arParms(17).Value = s.BatchNo

            arParms(18) = New SqlParameter("@caste", SqlDbType.NVarChar, 50)
            arParms(18).Value = s.Caste

            If s.Photo = Nothing Then
                arParms(19) = New SqlParameter("@photo", SqlDbType.NVarChar, 50)
                arParms(19).Value = ""
            Else
                arParms(19) = New SqlParameter("@photo", SqlDbType.NVarChar, 50)
                arParms(19).Value = s.Photo
            End If


            If s.SLNo = 0 Then
                arParms(20) = New SqlParameter("@std_SlNo", SqlDbType.Int)
                arParms(20).Value = 0
            Else
                arParms(20) = New SqlParameter("@std_SlNo", SqlDbType.Int)
                arParms(20).Value = s.SLNo
            End If

            arParms(21) = New SqlParameter("@prospno", SqlDbType.NVarChar, 50)
            arParms(21).Value = s.ProspectusNo

            arParms(22) = New SqlParameter("@age", SqlDbType.Int)
            arParms(22).Value = s.Age

            arParms(23) = New SqlParameter("@title", SqlDbType.NVarChar, 50)
            arParms(23).Value = s.Title

            arParms(24) = New SqlParameter("@email", SqlDbType.NVarChar, 50)
            arParms(24).Value = s.Email

            arParms(25) = New SqlParameter("@ddno", SqlDbType.NVarChar, 50)
            arParms(25).Value = s.DDNo

            arParms(26) = New SqlParameter("@receiptno", SqlDbType.NVarChar, 50)
            arParms(26).Value = s.ReceiptNo

            arParms(27) = New SqlParameter("@district", SqlDbType.NVarChar, 50)
            arParms(27).Value = s.District

            arParms(28) = New SqlParameter("@admissiontype", SqlDbType.NVarChar, 50)
            arParms(28).Value = s.AdmissionType

            If s.FromBranch = "1/1/3000" Then
                arParms(29) = New SqlParameter("@FRROExpDate", SqlDbType.NVarChar)
                arParms(29).Value = DBNull.Value
            Else
                arParms(29) = New SqlParameter("@FRROExpDate", SqlDbType.DateTime)
                arParms(29).Value = s.FromBranch
            End If

            arParms(30) = New SqlParameter("@city", SqlDbType.NVarChar, 50)
            arParms(30).Value = s.City

            arParms(31) = New SqlParameter("@pincode", SqlDbType.VarChar, 50)
            arParms(31).Value = s.PinCode

            arParms(32) = New SqlParameter("@state", SqlDbType.Int)
            arParms(32).Value = s.State

            arParms(33) = New SqlParameter("@Country", SqlDbType.NVarChar, 50)
            arParms(33).Value = s.Country

            arParms(34) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(34).Value = HttpContext.Current.Session("BranchCode")

            arParms(35) = New SqlParameter("@ApplicationNo", SqlDbType.NVarChar, 50)
            arParms(35).Value = s.ApplicationNo

            arParms(36) = New SqlParameter("@Session", SqlDbType.NVarChar, 50)
            arParms(36).Value = s.Session

            arParms(37) = New SqlParameter("@eno", SqlDbType.Int)
            arParms(37).Value = s.Eno

            arParms(38) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            arParms(38).Value = HttpContext.Current.Session("EmpCode")

            arParms(39) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            arParms(39).Value = HttpContext.Current.Session("UserCode")

            arParms(40) = New SqlParameter("@HouseId ", SqlDbType.Int)
            arParms(40).Value = s.HouseId
            If s.LeavingDate = "1/1/3000" Then
                arParms(41) = New SqlParameter("@LeavingDate", SqlDbType.VarChar)
                arParms(41).Value = DBNull.Value
            Else
                arParms(41) = New SqlParameter("@LeavingDate", SqlDbType.DateTime)
                arParms(41).Value = s.LeavingDate
            End If

            arParms(42) = New SqlParameter("@StudentEmail", SqlDbType.VarChar, 100)
            arParms(42).Value = s.StdEmail

            arParms(43) = New SqlParameter("@StudentContact", SqlDbType.VarChar, 100)
            arParms(43).Value = s.StdContact

            arParms(44) = New SqlParameter("@FatherEmail", SqlDbType.VarChar, 100)
            arParms(44).Value = s.FatherEmail

            arParms(45) = New SqlParameter("@FatherContact", SqlDbType.VarChar, 100)
            arParms(45).Value = s.FatherContact

            arParms(46) = New SqlParameter("@MotherName", SqlDbType.NVarChar, 100)
            arParms(46).Value = s.MotherName

            arParms(47) = New SqlParameter("@Hostel", SqlDbType.VarChar, 2)
            arParms(47).Value = s.Hostel

            arParms(48) = New SqlParameter("@Transport", SqlDbType.VarChar, 2)
            arParms(48).Value = s.Transport

            arParms(49) = New SqlParameter("@PlaceofIssue", SqlDbType.NVarChar, 100)
            arParms(49).Value = s.Passportissue

            arParms(50) = New SqlParameter("@NameInPassport", SqlDbType.NVarChar, 100)
            arParms(50).Value = s.PassportName

            arParms(51) = New SqlParameter("@PassportNo", SqlDbType.VarChar, 50)
            arParms(51).Value = s.PassportNo
            If s.PassportExpirydate = "1/1/3000" Then
                arParms(52) = New SqlParameter("@PassportExpiryDate", SqlDbType.VarChar)
                arParms(52).Value = DBNull.Value
            Else
                arParms(52) = New SqlParameter("@PassportExpiryDate", SqlDbType.DateTime)
                arParms(52).Value = s.PassportExpirydate
            End If
            arParms(53) = New SqlParameter("@NicNo", SqlDbType.VarChar, 50)
            arParms(53).Value = s.NicNo
            arParms(54) = New SqlParameter("@FullName", SqlDbType.NVarChar, 200)
            arParms(54).Value = s.Fullname
            If s.PassportIssueDate = "1/1/3000" Then
                arParms(55) = New SqlParameter("@PassportIssueDate", SqlDbType.VarChar)
                arParms(55).Value = DBNull.Value
            Else
                arParms(55) = New SqlParameter("@PassportIssueDate", SqlDbType.DateTime)
                arParms(55).Value = s.PassportIssueDate
            End If
            If s.VisaIssueDate = "1/1/3000" Then
                arParms(56) = New SqlParameter("@VisaIssueDate", SqlDbType.VarChar)
                arParms(56).Value = DBNull.Value
            Else
                arParms(56) = New SqlParameter("@VisaIssueDate", SqlDbType.DateTime)
                arParms(56).Value = s.VisaIssueDate
            End If
            If s.VisaExpDate = "1/1/3000" Then
                arParms(57) = New SqlParameter("@VisaExpiryDate", SqlDbType.VarChar)
                arParms(57).Value = DBNull.Value
            Else
                arParms(57) = New SqlParameter("@VisaExpiryDate", SqlDbType.DateTime)
                arParms(57).Value = s.VisaExpDate
            End If
            arParms(58) = New SqlParameter("@VisaNo", SqlDbType.VarChar, 200)
            arParms(58).Value = s.VisaNo

            arParms(59) = New SqlParameter("@TCNo", SqlDbType.VarChar, 100)
            arParms(59).Value = s.TCNo

            arParms(60) = New SqlParameter("@MotherTongue", SqlDbType.NVarChar, 100)
            arParms(60).Value = s.MotherTongue

            arParms(61) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
            arParms(61).Value = s.Remarks

            arParms(62) = New SqlParameter("@MentorId", SqlDbType.Int)
            arParms(62).Value = s.MentorId

            arParms(63) = New SqlParameter("@ChkDOB", SqlDbType.VarChar, 2)
            arParms(63).Value = s.DOBCertificate

            arParms(64) = New SqlParameter("@ChkIC", SqlDbType.VarChar, 2)
            arParms(64).Value = s.IC

            arParms(65) = New SqlParameter("@ChkMigrationCertificate", SqlDbType.VarChar, 2)
            arParms(65).Value = s.MigrationCertificate

            arParms(66) = New SqlParameter("@ChkTenth", SqlDbType.VarChar, 2)
            arParms(66).Value = s.TEN

            arParms(67) = New SqlParameter("@Chktwelve", SqlDbType.VarChar, 2)
            arParms(67).Value = s.twelve

            arParms(68) = New SqlParameter("@ChkBachelorDegree", SqlDbType.VarChar, 2)
            arParms(68).Value = s.BD

            arParms(69) = New SqlParameter("@ChkMasterDegree", SqlDbType.VarChar, 2)
            arParms(69).Value = s.MasterDegree

            arParms(70) = New SqlParameter("@ChkTC", SqlDbType.VarChar, 2)
            arParms(70).Value = s.TC

            arParms(71) = New SqlParameter("@FatherHomeContact", SqlDbType.VarChar, 50)
            arParms(71).Value = s.FatherHomeContact

            arParms(72) = New SqlParameter("@MontherHomeContact", SqlDbType.VarChar, 50)
            arParms(72).Value = s.MontherHomeContact

            arParms(73) = New SqlParameter("@FatherBizOffice", SqlDbType.VarChar, 50)
            arParms(73).Value = s.FatherBizOffice

            arParms(74) = New SqlParameter("@MotherBizOffice", SqlDbType.VarChar, 50)
            arParms(74).Value = s.MotherBizOffice

            arParms(75) = New SqlParameter("@FatherQualification", SqlDbType.NVarChar, 50)
            arParms(75).Value = s.FatherQualification

            arParms(76) = New SqlParameter("@MotherQualification", SqlDbType.NVarChar, 50)
            arParms(76).Value = s.MotherQualification

            arParms(77) = New SqlParameter("@Religion", SqlDbType.NVarChar, 250)
            arParms(77).Value = s.Religion

            arParms(78) = New SqlParameter("@MotherOccupation", SqlDbType.NVarChar, 100)
            arParms(78).Value = s.MotherOccupation

            arParms(79) = New SqlParameter("@SecondUSN", SqlDbType.NVarChar, 100)
            arParms(79).Value = s.SecondUSN

            arParms(80) = New SqlParameter("@MotherMail", SqlDbType.VarChar, 2)
            arParms(80).Value = s.MotherMail

            arParms(81) = New SqlParameter("@FatherMail", SqlDbType.VarChar, 2)
            arParms(81).Value = s.FatherMail

            arParms(82) = New SqlParameter("@MotherSMS", SqlDbType.VarChar, 2)
            arParms(82).Value = s.MotherSMS

            arParms(83) = New SqlParameter("@FatherSMS", SqlDbType.VarChar, 2)
            arParms(83).Value = s.FatherSMS

            arParms(84) = New SqlParameter("@indexNo", SqlDbType.VarChar, 50)
            arParms(84).Value = s.indexNo

            arParms(85) = New SqlParameter("@CourseBranch", SqlDbType.VarChar, 50)
            arParms(85).Value = s.coursebranchcode

            arParms(86) = New SqlParameter("@Ethncity", SqlDbType.VarChar, 50)
            arParms(86).Value = s.ethnicity

            arParms(87) = New SqlParameter("@AllocCat", SqlDbType.Int)
            arParms(87).Value = s.Alcategory

            arParms(88) = New SqlParameter("@BirthPlace", SqlDbType.VarChar, 250)
            arParms(88).Value = s.BirthPlace

            arParms(89) = New SqlParameter("@AddresPeriod", SqlDbType.VarChar, 50)
            arParms(89).Value = s.TemporaryAddressP

            arParms(90) = New SqlParameter("@ChkLOS", SqlDbType.VarChar, 2)
            arParms(90).Value = s.LOS

            arParms(91) = New SqlParameter("@ChkAOR", SqlDbType.VarChar, 2)
            arParms(91).Value = s.AOR

            arParms(92) = New SqlParameter("@ChkAOU", SqlDbType.VarChar, 2)
            arParms(92).Value = s.AOU

            arParms(93) = New SqlParameter("@ChkCPhoto", SqlDbType.VarChar, 2)
            arParms(93).Value = s.CPhoto
            arParms(94) = New SqlParameter("@MName", SqlDbType.VarChar, 250)
            arParms(94).Value = s.MName

            arParms(95) = New SqlParameter("@LName", SqlDbType.VarChar, 250)
            arParms(95).Value = s.LastName

            arParms(96) = New SqlParameter("@Citizen", SqlDbType.VarChar, 50)
            arParms(96).Value = s.Citizenship

            arParms(97) = New SqlParameter("@GDName", SqlDbType.VarChar, 50)
            arParms(97).Value = s.GDName
            arParms(98) = New SqlParameter("@GDContactNo", SqlDbType.VarChar, 50)
            arParms(98).Value = s.GDContactNo
            arParms(99) = New SqlParameter("@GDEmail", SqlDbType.VarChar, 50)
            arParms(99).Value = s.GDEmailID
            arParms(100) = New SqlParameter("@GDOccupation", SqlDbType.VarChar, 50)
            arParms(100).Value = s.GDOccupation

            arParms(101) = New SqlParameter("@GDRelation", SqlDbType.VarChar, 50)
            arParms(101).Value = s.GuardianRelate

            arParms(102) = New SqlParameter("@SLC", SqlDbType.VarChar, 2)
            arParms(102).Value = s.SLC

            arParms(103) = New SqlParameter("@distance", SqlDbType.Float)
            arParms(103).Value = s.Distance



            Try
                rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_SaveStudentDetails", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function update(ByVal s As Student) As Integer
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

            Dim rowsAffected As Integer = 0

            Dim arParms() As SqlParameter = New SqlParameter(102) {}

            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(0).Value = s.Id

            arParms(1) = New SqlParameter("@name", SqlDbType.NVarChar, 100)
            arParms(1).Value = s.Name
            If s.Code = "" Then
                arParms(2) = New SqlParameter("@code", SqlDbType.NVarChar, 50)
                arParms(2).Value = ""
            Else
                arParms(2) = New SqlParameter("@code", SqlDbType.NVarChar, 50)
                arParms(2).Value = s.Code
            End If

            arParms(3) = New SqlParameter("@dob", SqlDbType.DateTime)
            arParms(3).Value = s.DateOfBirth

            arParms(4) = New SqlParameter("@fname", SqlDbType.NVarChar, 100)
            arParms(4).Value = s.FatherName

            arParms(5) = New SqlParameter("@foccupation", SqlDbType.NVarChar, 100)
            arParms(5).Value = s.FatherOccupation

            arParms(6) = New SqlParameter("@income", SqlDbType.Money)
            arParms(6).Value = s.AnnualIncome

            arParms(7) = New SqlParameter("@paddr", SqlDbType.NVarChar, 250)
            arParms(7).Value = s.PermanentAddress

            arParms(8) = New SqlParameter("@taddr", SqlDbType.NVarChar, 250)
            arParms(8).Value = s.TemporaryAddress

            arParms(9) = New SqlParameter("@contactno", SqlDbType.VarChar, 50)
            arParms(9).Value = s.ContactNumber

            arParms(10) = New SqlParameter("@sex", SqlDbType.NVarChar, 50)
            arParms(10).Value = s.Sex

            arParms(11) = New SqlParameter("@category", SqlDbType.NVarChar, 50)
            arParms(11).Value = s.Category

            arParms(12) = New SqlParameter("@courseid", SqlDbType.Int)
            arParms(12).Value = s.CourseId

            arParms(13) = New SqlParameter("@A_year", SqlDbType.Int)
            arParms(13).Value = s.A_year
            arParms(14) = New SqlParameter("@feecollected", SqlDbType.VarChar, 2)
            arParms(14).Value = s.Feecollected

            arParms(15) = New SqlParameter("@sponsorid", SqlDbType.Int)
            arParms(15).Value = s.SponsorId

            arParms(16) = New SqlParameter("@admindate", SqlDbType.DateTime)
            arParms(16).Value = s.AdmissionDate

            arParms(17) = New SqlParameter("@batchNo", SqlDbType.Int)
            arParms(17).Value = s.BatchNo

            arParms(18) = New SqlParameter("@caste", SqlDbType.NVarChar, 50)
            arParms(18).Value = s.Caste

            arParms(19) = New SqlParameter("@photo", SqlDbType.NVarChar, 50)
            arParms(19).Value = s.Photo

            If s.SLNo = 0 Then
                arParms(20) = New SqlParameter("@std_SlNo", SqlDbType.Int)
                arParms(20).Value = 0
            Else
                arParms(20) = New SqlParameter("@std_SlNo", SqlDbType.Int)
                arParms(20).Value = s.SLNo
            End If

            arParms(21) = New SqlParameter("@prospno", SqlDbType.VarChar, 50)
            arParms(21).Value = s.ProspectusNo

            arParms(22) = New SqlParameter("@age", SqlDbType.Int)
            arParms(22).Value = s.Age

            arParms(23) = New SqlParameter("@title", SqlDbType.NVarChar, 50)
            arParms(23).Value = s.Title

            arParms(24) = New SqlParameter("@email", SqlDbType.VarChar, 50)
            arParms(24).Value = s.Email

            arParms(25) = New SqlParameter("@ddno", SqlDbType.VarChar, 50)
            arParms(25).Value = s.DDNo

            arParms(26) = New SqlParameter("@receiptno", SqlDbType.NVarChar, 50)
            arParms(26).Value = s.ReceiptNo

            arParms(27) = New SqlParameter("@district", SqlDbType.NVarChar, 50)
            arParms(27).Value = s.District

            arParms(28) = New SqlParameter("@admissiontype", SqlDbType.NVarChar, 50)
            arParms(28).Value = s.AdmissionType

            If s.FromBranch = "1/1/3000" Then
                arParms(29) = New SqlParameter("@FRROExpDate", SqlDbType.VarChar)
                arParms(29).Value = DBNull.Value
            Else
                arParms(29) = New SqlParameter("@FRROExpDate", SqlDbType.DateTime)
                arParms(29).Value = s.FromBranch
            End If

            arParms(30) = New SqlParameter("@city", SqlDbType.NVarChar, 50)
            arParms(30).Value = s.City

            arParms(31) = New SqlParameter("@pincode", SqlDbType.VarChar, 50)
            arParms(31).Value = s.PinCode

            arParms(32) = New SqlParameter("@state", SqlDbType.Int)
            arParms(32).Value = s.State

            arParms(33) = New SqlParameter("@Country", SqlDbType.NVarChar, 50)
            arParms(33).Value = s.Country

            arParms(34) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(34).Value = HttpContext.Current.Session("BranchCode")

            arParms(35) = New SqlParameter("@ApplicationNo", SqlDbType.NVarChar, 50)
            arParms(35).Value = s.ApplicationNo

            arParms(36) = New SqlParameter("@Session", SqlDbType.NVarChar, 50)
            arParms(36).Value = s.Session

            arParms(37) = New SqlParameter("@eno", SqlDbType.Int)
            arParms(37).Value = s.Eno

            arParms(38) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            arParms(38).Value = HttpContext.Current.Session("EmpCode")

            arParms(39) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            arParms(39).Value = HttpContext.Current.Session("UserCode")

            arParms(40) = New SqlParameter("@HouseId ", SqlDbType.Int)
            arParms(40).Value = s.HouseId
            If s.LeavingDate = "1/1/3000" Then
                arParms(41) = New SqlParameter("@LeavingDate", SqlDbType.VarChar)
                arParms(41).Value = DBNull.Value
            Else
                arParms(41) = New SqlParameter("@LeavingDate", SqlDbType.DateTime)
                arParms(41).Value = s.LeavingDate
            End If

            arParms(42) = New SqlParameter("@StudentEmail", SqlDbType.VarChar, 100)
            arParms(42).Value = s.StdEmail

            arParms(43) = New SqlParameter("@StudentContact", SqlDbType.VarChar, 100)
            arParms(43).Value = s.StdContact

            arParms(44) = New SqlParameter("@FatherEmail", SqlDbType.VarChar, 100)
            arParms(44).Value = s.FatherEmail

            arParms(45) = New SqlParameter("@FatherContact", SqlDbType.VarChar, 100)
            arParms(45).Value = s.FatherContact

            arParms(46) = New SqlParameter("@MotherName", SqlDbType.NVarChar, 100)
            arParms(46).Value = s.MotherName

            arParms(47) = New SqlParameter("@Hostel", SqlDbType.VarChar, 2)
            arParms(47).Value = s.Hostel

            arParms(48) = New SqlParameter("@Transport", SqlDbType.VarChar, 2)
            arParms(48).Value = s.Transport

            arParms(49) = New SqlParameter("@PlaceofIssue", SqlDbType.NVarChar, 100)
            arParms(49).Value = s.Passportissue

            arParms(50) = New SqlParameter("@NameInPassport", SqlDbType.NVarChar, 100)
            arParms(50).Value = s.PassportName

            arParms(51) = New SqlParameter("@PassportNo", SqlDbType.VarChar, 50)
            arParms(51).Value = s.PassportNo

            If s.PassportExpirydate = "1/1/3000" Then
                arParms(52) = New SqlParameter("@PassportExpiryDate", SqlDbType.VarChar)
                arParms(52).Value = DBNull.Value
            Else
                arParms(52) = New SqlParameter("@PassportExpiryDate", SqlDbType.DateTime)
                arParms(52).Value = s.PassportExpirydate
            End If
            arParms(53) = New SqlParameter("@NicNo", SqlDbType.VarChar, 50)
            arParms(53).Value = s.NicNo
            arParms(54) = New SqlParameter("@FullName", SqlDbType.NVarChar, 200)
            arParms(54).Value = s.Fullname
            If s.PassportIssueDate = "1/1/3000" Then
                arParms(55) = New SqlParameter("@PassportIssueDate", SqlDbType.VarChar)
                arParms(55).Value = DBNull.Value
            Else
                arParms(55) = New SqlParameter("@PassportIssueDate", SqlDbType.DateTime)
                arParms(55).Value = s.PassportIssueDate
            End If
            If s.VisaIssueDate = "1/1/3000" Then
                arParms(56) = New SqlParameter("@VisaIssueDate", SqlDbType.VarChar)
                arParms(56).Value = DBNull.Value
            Else
                arParms(56) = New SqlParameter("@VisaIssueDate", SqlDbType.DateTime)
                arParms(56).Value = s.VisaIssueDate
            End If
            If s.VisaExpDate = "1/1/3000" Then
                arParms(57) = New SqlParameter("@VisaExpiryDate", SqlDbType.VarChar)
                arParms(57).Value = DBNull.Value
            Else
                arParms(57) = New SqlParameter("@VisaExpiryDate", SqlDbType.DateTime)
                arParms(57).Value = s.VisaExpDate
            End If
            arParms(58) = New SqlParameter("@VisaNo", SqlDbType.VarChar, 200)
            arParms(58).Value = s.VisaNo

            arParms(59) = New SqlParameter("@TCNo", SqlDbType.VarChar, 50)
            arParms(59).Value = s.TCNo

            arParms(60) = New SqlParameter("@MotherTongue", SqlDbType.NVarChar, 100)
            arParms(60).Value = s.MotherTongue

            arParms(61) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
            arParms(61).Value = s.Remarks


            arParms(62) = New SqlParameter("@MentorId", SqlDbType.Int)
            arParms(62).Value = s.MentorId

            arParms(63) = New SqlParameter("@ChkDOB", SqlDbType.VarChar, 2)
            arParms(63).Value = s.DOBCertificate

            arParms(64) = New SqlParameter("@ChkIC", SqlDbType.VarChar, 2)
            arParms(64).Value = s.IC

            arParms(65) = New SqlParameter("@ChkMigrationCertificate", SqlDbType.VarChar, 2)
            arParms(65).Value = s.MigrationCertificate

            arParms(66) = New SqlParameter("@ChkTenth", SqlDbType.VarChar, 2)
            arParms(66).Value = s.TEN

            arParms(67) = New SqlParameter("@Chktwelve", SqlDbType.VarChar, 2)
            arParms(67).Value = s.twelve

            arParms(68) = New SqlParameter("@ChkBachelorDegree", SqlDbType.VarChar, 2)
            arParms(68).Value = s.BD

            arParms(69) = New SqlParameter("@ChkMasterDegree", SqlDbType.VarChar, 2)
            arParms(69).Value = s.MasterDegree

            arParms(70) = New SqlParameter("@ChkTC", SqlDbType.VarChar, 2)
            arParms(70).Value = s.TC

            arParms(71) = New SqlParameter("@FatherHomeContact", SqlDbType.VarChar, 50)
            arParms(71).Value = s.FatherHomeContact

            arParms(72) = New SqlParameter("@MontherHomeContact", SqlDbType.VarChar, 50)
            arParms(72).Value = s.MontherHomeContact

            arParms(73) = New SqlParameter("@FatherBizOffice", SqlDbType.VarChar, 50)
            arParms(73).Value = s.FatherBizOffice

            arParms(74) = New SqlParameter("@MotherBizOffice", SqlDbType.VarChar, 50)
            arParms(74).Value = s.MotherBizOffice

            arParms(75) = New SqlParameter("@FatherQualification", SqlDbType.NVarChar, 50)
            arParms(75).Value = s.FatherQualification

            arParms(76) = New SqlParameter("@MotherQualification", SqlDbType.NVarChar, 50)
            arParms(76).Value = s.MotherQualification

            arParms(77) = New SqlParameter("@Religion", SqlDbType.NVarChar, 250)
            arParms(77).Value = s.Religion

            arParms(78) = New SqlParameter("@MotherOccupation", SqlDbType.NVarChar, 50)
            arParms(78).Value = s.MotherOccupation

            arParms(79) = New SqlParameter("@SecondUSN", SqlDbType.VarChar, 100)
            arParms(79).Value = s.SecondUSN

            arParms(80) = New SqlParameter("@MotherMail", SqlDbType.VarChar, 2)
            arParms(80).Value = s.MotherMail

            arParms(81) = New SqlParameter("@FatherMail", SqlDbType.VarChar, 2)
            arParms(81).Value = s.FatherMail

            arParms(82) = New SqlParameter("@MotherSMS", SqlDbType.VarChar, 2)
            arParms(82).Value = s.MotherSMS

            arParms(83) = New SqlParameter("@FatherSMS", SqlDbType.VarChar, 2)
            arParms(83).Value = s.FatherSMS

            arParms(84) = New SqlParameter("@CBranchName", SqlDbType.VarChar, 50)
            arParms(84).Value = s.coursebranchcode

            arParms(85) = New SqlParameter("@AllocCat", SqlDbType.Int)
            arParms(85).Value = s.Alcategory

            arParms(86) = New SqlParameter("@BirthPlace", SqlDbType.VarChar, 250)
            arParms(86).Value = s.BirthPlace

            arParms(87) = New SqlParameter("@AddresPeriod", SqlDbType.VarChar, 50)
            arParms(87).Value = s.TemporaryAddressP

            arParms(88) = New SqlParameter("@ChkLOS", SqlDbType.VarChar, 2)
            arParms(88).Value = s.LOS

            arParms(89) = New SqlParameter("@ChkAOR", SqlDbType.VarChar, 2)
            arParms(89).Value = s.AOR

            arParms(90) = New SqlParameter("@ChkAOU", SqlDbType.VarChar, 2)
            arParms(90).Value = s.AOU

            arParms(91) = New SqlParameter("@ChkCPhoto", SqlDbType.VarChar, 2)
            arParms(91).Value = s.CPhoto

            arParms(92) = New SqlParameter("@MName", SqlDbType.VarChar, 250)
            arParms(92).Value = s.MName

            arParms(93) = New SqlParameter("@LName", SqlDbType.VarChar, 250)
            arParms(93).Value = s.LastName

            arParms(94) = New SqlParameter("@Citizen", SqlDbType.VarChar, 50)
            arParms(94).Value = s.Citizenship

            arParms(95) = New SqlParameter("@GDName", SqlDbType.VarChar, 50)
            arParms(95).Value = s.GDName
            arParms(96) = New SqlParameter("@GDContactNo", SqlDbType.VarChar, 50)
            arParms(96).Value = s.GDContactNo
            arParms(97) = New SqlParameter("@GDEmail", SqlDbType.VarChar, 50)
            arParms(97).Value = s.GDEmailID
            arParms(98) = New SqlParameter("@GDOccupation", SqlDbType.VarChar, 50)
            arParms(98).Value = s.GDOccupation
            arParms(99) = New SqlParameter("@Ethncity", SqlDbType.VarChar, 50)
            arParms(99).Value = s.ethnicity

            arParms(100) = New SqlParameter("@GDRelation", SqlDbType.VarChar, 50)
            arParms(100).Value = s.GuardianRelate

            arParms(101) = New SqlParameter("@SLC", SqlDbType.VarChar, 2)
            arParms(101).Value = s.SLC



            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateStudentMaster", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        Catch ex As Exception
            MsgBox(ex.ToString)


        End Try
    End Function
    Shared Function update123(ByVal s As Student) As Integer
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

            Dim rowsAffected As Integer = 0

            Dim arParms() As SqlParameter = New SqlParameter(91) {}

            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(0).Value = s.Id

            arParms(1) = New SqlParameter("@name", SqlDbType.NVarChar, 100)
            arParms(1).Value = s.Name
            If s.Code = "" Then
                arParms(2) = New SqlParameter("@code", SqlDbType.NVarChar, 50)
                arParms(2).Value = ""
            Else
                arParms(2) = New SqlParameter("@code", SqlDbType.NVarChar, 50)
                arParms(2).Value = s.Code
            End If

            arParms(3) = New SqlParameter("@dob", SqlDbType.DateTime)
            arParms(3).Value = s.DateOfBirth

            arParms(4) = New SqlParameter("@fname", SqlDbType.NVarChar, 100)
            arParms(4).Value = s.FatherName

            arParms(5) = New SqlParameter("@foccupation", SqlDbType.NVarChar, 100)
            arParms(5).Value = s.FatherOccupation

            arParms(6) = New SqlParameter("@income", SqlDbType.Money)
            arParms(6).Value = s.AnnualIncome

            arParms(7) = New SqlParameter("@paddr", SqlDbType.NVarChar, 250)
            arParms(7).Value = s.PermanentAddress

            arParms(8) = New SqlParameter("@taddr", SqlDbType.NVarChar, 250)
            arParms(8).Value = s.TemporaryAddress

            arParms(9) = New SqlParameter("@contactno", SqlDbType.VarChar, 50)
            arParms(9).Value = s.ContactNumber

            arParms(10) = New SqlParameter("@sex", SqlDbType.NVarChar, 50)
            arParms(10).Value = s.Sex

            arParms(11) = New SqlParameter("@category", SqlDbType.NVarChar, 50)
            arParms(11).Value = s.Category

            arParms(12) = New SqlParameter("@courseid", SqlDbType.Int)
            arParms(12).Value = s.CourseId

            arParms(13) = New SqlParameter("@A_year", SqlDbType.Int)
            arParms(13).Value = s.A_year
            arParms(14) = New SqlParameter("@feecollected", SqlDbType.VarChar, 2)
            arParms(14).Value = s.Feecollected

            arParms(15) = New SqlParameter("@sponsorid", SqlDbType.Int)
            arParms(15).Value = s.SponsorId

            arParms(16) = New SqlParameter("@admindate", SqlDbType.DateTime)
            arParms(16).Value = s.AdmissionDate

            arParms(17) = New SqlParameter("@batchNo", SqlDbType.Int)
            arParms(17).Value = s.BatchNo

            arParms(18) = New SqlParameter("@caste", SqlDbType.NVarChar, 50)
            arParms(18).Value = s.Caste

            arParms(19) = New SqlParameter("@photo", SqlDbType.NVarChar, 250)
            arParms(19).Value = s.Photo

            If s.SLNo = 0 Then
                arParms(20) = New SqlParameter("@std_SlNo", SqlDbType.Int)
                arParms(20).Value = 0
            Else
                arParms(20) = New SqlParameter("@std_SlNo", SqlDbType.Int)
                arParms(20).Value = s.SLNo
            End If

            arParms(21) = New SqlParameter("@prospno", SqlDbType.VarChar, 50)
            arParms(21).Value = s.ProspectusNo

            arParms(22) = New SqlParameter("@age", SqlDbType.Int)
            arParms(22).Value = s.Age

            arParms(23) = New SqlParameter("@title", SqlDbType.NVarChar, 50)
            arParms(23).Value = s.Title

            arParms(24) = New SqlParameter("@email", SqlDbType.VarChar, 50)
            arParms(24).Value = s.Email

            arParms(25) = New SqlParameter("@ddno", SqlDbType.VarChar, 50)
            arParms(25).Value = s.DDNo

            arParms(26) = New SqlParameter("@receiptno", SqlDbType.NVarChar, 50)
            arParms(26).Value = s.ReceiptNo

            arParms(27) = New SqlParameter("@district", SqlDbType.NVarChar, 50)
            arParms(27).Value = s.District

            arParms(28) = New SqlParameter("@admissiontype", SqlDbType.NVarChar, 50)
            arParms(28).Value = s.AdmissionType

            If s.FromBranch = "1/1/3000" Then
                arParms(29) = New SqlParameter("@FRROExpDate", SqlDbType.VarChar)
                arParms(29).Value = DBNull.Value
            Else
                arParms(29) = New SqlParameter("@FRROExpDate", SqlDbType.DateTime)
                arParms(29).Value = s.FromBranch
            End If

            arParms(30) = New SqlParameter("@city", SqlDbType.NVarChar, 50)
            arParms(30).Value = s.City

            arParms(31) = New SqlParameter("@pincode", SqlDbType.VarChar, 50)
            arParms(31).Value = s.PinCode

            arParms(32) = New SqlParameter("@state", SqlDbType.Int)
            arParms(32).Value = s.State

            arParms(33) = New SqlParameter("@Country", SqlDbType.NVarChar, 50)
            arParms(33).Value = s.Country

            arParms(34) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(34).Value = HttpContext.Current.Session("BranchCode")

            arParms(35) = New SqlParameter("@ApplicationNo", SqlDbType.NVarChar, 50)
            arParms(35).Value = s.ApplicationNo

            arParms(36) = New SqlParameter("@Session", SqlDbType.NVarChar, 50)
            arParms(36).Value = s.Session

            arParms(37) = New SqlParameter("@eno", SqlDbType.Int)
            arParms(37).Value = s.Eno

            'arParms(38) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            'arParms(38).Value = HttpContext.Current.Session("EmpCode")

            'arParms(39) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            'arParms(39).Value = HttpContext.Current.Session("UserCode")

            arParms(38) = New SqlParameter("@HouseId ", SqlDbType.Int)
            arParms(38).Value = s.HouseId
            If s.LeavingDate = "1/1/3000" Then
                arParms(39) = New SqlParameter("@LeavingDate", SqlDbType.VarChar)
                arParms(39).Value = DBNull.Value
            Else
                arParms(40) = New SqlParameter("@LeavingDate", SqlDbType.DateTime)
                arParms(40).Value = s.LeavingDate
            End If

            arParms(41) = New SqlParameter("@StudentEmail", SqlDbType.VarChar, 100)
            arParms(41).Value = s.StdEmail

            arParms(42) = New SqlParameter("@StudentContact", SqlDbType.VarChar, 100)
            arParms(42).Value = s.StdContact

            arParms(43) = New SqlParameter("@FatherEmail", SqlDbType.VarChar, 100)
            arParms(43).Value = s.FatherEmail

            arParms(44) = New SqlParameter("@FatherContact", SqlDbType.VarChar, 100)
            arParms(44).Value = s.FatherContact

            arParms(45) = New SqlParameter("@MotherName", SqlDbType.NVarChar, 100)
            arParms(45).Value = s.MotherName

            arParms(46) = New SqlParameter("@Hostel", SqlDbType.VarChar, 2)
            arParms(46).Value = s.Hostel

            arParms(47) = New SqlParameter("@Transport", SqlDbType.VarChar, 2)
            arParms(47).Value = s.Transport

            arParms(48) = New SqlParameter("@PlaceofIssue", SqlDbType.NVarChar, 100)
            arParms(48).Value = s.Passportissue

            arParms(49) = New SqlParameter("@NameInPassport", SqlDbType.NVarChar, 100)
            arParms(49).Value = s.PassportName

            arParms(50) = New SqlParameter("@PassportNo", SqlDbType.VarChar, 50)
            arParms(50).Value = s.PassportNo

            If s.PassportExpirydate = "1/1/3000" Then
                arParms(51) = New SqlParameter("@PassportExpiryDate", SqlDbType.VarChar)
                arParms(51).Value = DBNull.Value
            Else
                arParms(51) = New SqlParameter("@PassportExpiryDate", SqlDbType.DateTime)
                arParms(51).Value = s.PassportExpirydate
            End If
            arParms(52) = New SqlParameter("@NicNo", SqlDbType.VarChar, 50)
            arParms(52).Value = s.NicNo
            arParms(53) = New SqlParameter("@FullName", SqlDbType.NVarChar, 200)
            arParms(53).Value = s.Fullname
            If s.PassportIssueDate = "1/1/3000" Then
                arParms(54) = New SqlParameter("@PassportIssueDate", SqlDbType.VarChar)
                arParms(54).Value = DBNull.Value
            Else
                arParms(54) = New SqlParameter("@PassportIssueDate", SqlDbType.DateTime)
                arParms(54).Value = s.PassportIssueDate
            End If
            If s.VisaIssueDate = "1/1/3000" Then
                arParms(55) = New SqlParameter("@VisaIssueDate", SqlDbType.VarChar)
                arParms(55).Value = DBNull.Value
            Else
                arParms(56) = New SqlParameter("@VisaIssueDate", SqlDbType.DateTime)
                arParms(56).Value = s.VisaIssueDate
            End If
            If s.VisaExpDate = "1/1/3000" Then
                arParms(57) = New SqlParameter("@VisaExpiryDate", SqlDbType.VarChar)
                arParms(57).Value = DBNull.Value
            Else
                arParms(57) = New SqlParameter("@VisaExpiryDate", SqlDbType.DateTime)
                arParms(57).Value = s.VisaExpDate
            End If
            arParms(58) = New SqlParameter("@VisaNo", SqlDbType.VarChar, 200)
            arParms(58).Value = s.VisaNo

            arParms(59) = New SqlParameter("@TCNo", SqlDbType.VarChar, 50)
            arParms(59).Value = s.TCNo

            arParms(60) = New SqlParameter("@MotherTongue", SqlDbType.NVarChar, 100)
            arParms(60).Value = s.MotherTongue

            arParms(61) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
            arParms(61).Value = s.Remarks


            arParms(62) = New SqlParameter("@MentorId", SqlDbType.Int)
            arParms(62).Value = s.MentorId

            arParms(63) = New SqlParameter("@ChkDOB", SqlDbType.VarChar, 2)
            arParms(63).Value = s.DOBCertificate

            arParms(64) = New SqlParameter("@ChkIC", SqlDbType.VarChar, 2)
            arParms(64).Value = s.IC

            arParms(65) = New SqlParameter("@ChkMigrationCertificate", SqlDbType.VarChar, 2)
            arParms(65).Value = s.MigrationCertificate

            arParms(66) = New SqlParameter("@ChkTenth", SqlDbType.VarChar, 2)
            arParms(66).Value = s.TEN

            arParms(67) = New SqlParameter("@Chktwelve", SqlDbType.VarChar, 2)
            arParms(67).Value = s.twelve

            arParms(68) = New SqlParameter("@ChkBachelorDegree", SqlDbType.VarChar, 2)
            arParms(68).Value = s.BD

            arParms(69) = New SqlParameter("@ChkMasterDegree", SqlDbType.VarChar, 2)
            arParms(69).Value = s.MasterDegree

            arParms(70) = New SqlParameter("@ChkTC", SqlDbType.VarChar, 2)
            arParms(70).Value = s.TC

            arParms(71) = New SqlParameter("@FatherHomeContact", SqlDbType.VarChar, 50)
            arParms(71).Value = s.FatherHomeContact

            arParms(72) = New SqlParameter("@MontherHomeContact", SqlDbType.VarChar, 50)
            arParms(72).Value = s.MontherHomeContact

            arParms(73) = New SqlParameter("@FatherBizOffice", SqlDbType.VarChar, 50)
            arParms(73).Value = s.FatherBizOffice

            arParms(74) = New SqlParameter("@MotherBizOffice", SqlDbType.VarChar, 50)
            arParms(74).Value = s.MotherBizOffice

            arParms(75) = New SqlParameter("@FatherQualification", SqlDbType.NVarChar, 50)
            arParms(75).Value = s.FatherQualification

            arParms(76) = New SqlParameter("@MotherQualification", SqlDbType.NVarChar, 50)
            arParms(76).Value = s.MotherQualification

            arParms(77) = New SqlParameter("@Religion", SqlDbType.NVarChar, 250)
            arParms(77).Value = s.Religion

            arParms(78) = New SqlParameter("@MotherOccupation", SqlDbType.NVarChar, 50)
            arParms(78).Value = s.MotherOccupation

            arParms(79) = New SqlParameter("@SecondUSN", SqlDbType.VarChar, 100)
            arParms(79).Value = s.SecondUSN

            arParms(80) = New SqlParameter("@MotherMail", SqlDbType.VarChar, 2)
            arParms(80).Value = s.MotherMail

            arParms(81) = New SqlParameter("@FatherMail", SqlDbType.VarChar, 2)
            arParms(81).Value = s.FatherMail

            arParms(82) = New SqlParameter("@MotherSMS", SqlDbType.VarChar, 2)
            arParms(82).Value = s.MotherSMS

            arParms(83) = New SqlParameter("@FatherSMS", SqlDbType.VarChar, 2)
            arParms(83).Value = s.FatherSMS


            arParms(84) = New SqlParameter("@CBranchName", SqlDbType.VarChar, 50)
            arParms(84).Value = s.coursebranchcode

            arParms(85) = New SqlParameter("@AllocCat", SqlDbType.Int)
            arParms(85).Value = s.Alcategory

            arParms(86) = New SqlParameter("@BirthPlace", SqlDbType.VarChar, 250)
            arParms(86).Value = s.BirthPlace

            arParms(87) = New SqlParameter("@AddresPeriod", SqlDbType.VarChar, 50)
            arParms(87).Value = s.TemporaryAddressP

            arParms(88) = New SqlParameter("@ChkLOS", SqlDbType.VarChar, 2)
            arParms(88).Value = s.LOS

            arParms(89) = New SqlParameter("@ChkAOR", SqlDbType.VarChar, 2)
            arParms(89).Value = s.AOR

            arParms(90) = New SqlParameter("@ChkAOU", SqlDbType.VarChar, 2)
            arParms(90).Value = s.AOU

            arParms(91) = New SqlParameter("@ChkCPhoto", SqlDbType.VarChar, 2)
            arParms(91).Value = s.CPhoto

            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateStudentMaster", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        Catch ex As Exception
            MsgBox(ex.ToString)


        End Try
    End Function

    Shared Function getidStdcode(ByVal std_code As String) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@STDCode", SqlDbType.VarChar, 50)
            arParms(0).Value = std_code

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_getstdid", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function getTotalseats(ByVal a As Long) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@Batch", SqlDbType.Int)
            arParms(0).Value = a

            'arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            'arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetNoOfSeats", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetStudents(ByVal id As Long, ByVal s As Student) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(14) {}

            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(0).Value = id

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")

            arParms(3) = New SqlParameter("@ApplicationNo", SqlDbType.VarChar, 50)
            arParms(3).Value = s.ApplicationNo

            arParms(4) = New SqlParameter("@admindate", SqlDbType.Date)
            arParms(4).Value = s.AdmissionDate

            arParms(5) = New SqlParameter("@name", SqlDbType.VarChar, 100)
            arParms(5).Value = s.Name

            arParms(6) = New SqlParameter("@code", SqlDbType.VarChar, 50)
            arParms(6).Value = s.Code

            arParms(7) = New SqlParameter("@courseid", SqlDbType.Int)
            arParms(7).Value = s.CourseId

            arParms(8) = New SqlParameter("@A_year", SqlDbType.Int)
            arParms(8).Value = s.A_year

            arParms(9) = New SqlParameter("@batchNo", SqlDbType.Int)
            arParms(9).Value = s.BatchNo

            arParms(10) = New SqlParameter("@dob", SqlDbType.Date)
            arParms(10).Value = s.DateOfBirth

            arParms(11) = New SqlParameter("@HouseId ", SqlDbType.Int)
            arParms(11).Value = s.HouseId

            arParms(12) = New SqlParameter("@category", SqlDbType.VarChar, 50)
            arParms(12).Value = s.Category

            arParms(13) = New SqlParameter("@NicNo", SqlDbType.VarChar, 50)
            arParms(13).Value = s.NicNo

            arParms(14) = New SqlParameter("@MentorId", SqlDbType.Int)
            arParms(14).Value = s.MentorId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDetails", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetStudents4(ByVal id As Long, ByVal s As Student) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(15) {}

            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(0).Value = id

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")

            arParms(3) = New SqlParameter("@ApplicationNo", SqlDbType.VarChar, 50)
            arParms(3).Value = s.ApplicationNo

            arParms(4) = New SqlParameter("@admindate", SqlDbType.Date)
            arParms(4).Value = s.AdmissionDate

            arParms(5) = New SqlParameter("@name", SqlDbType.VarChar, 100)
            arParms(5).Value = s.Name

            arParms(6) = New SqlParameter("@code", SqlDbType.VarChar, 50)
            arParms(6).Value = s.Code

            arParms(7) = New SqlParameter("@courseid", SqlDbType.Int)
            arParms(7).Value = s.CourseId

            arParms(8) = New SqlParameter("@A_year", SqlDbType.Int)
            arParms(8).Value = s.A_year

            arParms(9) = New SqlParameter("@batchNo", SqlDbType.Int)
            arParms(9).Value = s.BatchNo

            arParms(10) = New SqlParameter("@dob", SqlDbType.Date)
            arParms(10).Value = s.DateOfBirth

            arParms(11) = New SqlParameter("@HouseId ", SqlDbType.Int)
            arParms(11).Value = s.HouseId

            arParms(12) = New SqlParameter("@category", SqlDbType.VarChar, 50)
            arParms(12).Value = s.Category

            arParms(13) = New SqlParameter("@NicNo", SqlDbType.VarChar, 50)
            arParms(13).Value = s.NicNo

            arParms(14) = New SqlParameter("@MentorId", SqlDbType.Int)
            arParms(14).Value = s.MentorId

            arParms(15) = New SqlParameter("@CBranchName", SqlDbType.VarChar, 50)
            arParms(15).Value = s.coursebranchcode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDetails4", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetStudentsOthers(ByVal id As Long, ByVal s As Student) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(0).Value = id

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")


            arParms(3) = New SqlParameter("@CBranchName", SqlDbType.VarChar, 50)
            arParms(3).Value = s.coursebranchcode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDetailsOtheres", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Shared Function studentForParentStd(ByVal s As Student) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@StdId", SqlDbType.VarChar, 50)
            arParms(0).Value = s.Code

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetStudentDetailsPareentStd]", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function getAddRecords(ByVal id As String) As System.Data.DataTable

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
            arParms(0).Value = id

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAddStudentDetails", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetBWStudents(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(0).Value = branchID

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = instID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID

            arParms(3) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(3).Value = batchID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBWStdDetails", arParms)

            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function Delete(ByVal Id As Integer) As Integer
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim rowsAffected As Integer = 0

            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int, 10)
            arParms(0).Value = Id
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DelStudentDetails", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Return rowsAffected
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Shared Function GetStdID(ByVal code As String, ByVal batch As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@code", SqlDbType.Char)
        arParms(0).Value = code

        arParms(1) = New SqlParameter("@batch", SqlDbType.Int)
        arParms(1).Value = batch

        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdId", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetStudentComboDayBook(ByVal id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        If id = 0 Then

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdDetailsComboDB")
        Else
            arParms(0) = New SqlParameter("@StdId", SqlDbType.Int, 10)
            arParms(0).Value = id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdDetailsComboDBbyId", arParms)
        End If
        Return ds
    End Function
    'data to fill fee collection form based on code
    Shared Function GetStudentDetls(ByVal code As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Code", SqlDbType.Char)
        arParms(0).Value = code
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDetlsByCode", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function RPT_GetBWStudents(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(0).Value = branchID

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = instID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID

            arParms(3) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(3).Value = batchID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RPT_GetBWStdDetails", arParms)

            Return ds

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function RPT_GetDistrictWiseDtls(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(0).Value = instID

            arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(1).Value = branchID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID

            arParms(3) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(3).Value = batchID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_RPT_GetAllStdDetails]", arParms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function RPT_GetStudentMarks(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(0).Value = branchID

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = instID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID

            arParms(3) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(3).Value = batchID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_RPT_GtdStudentMarks]", arParms)

            Return ds

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function RPT_GetCorswiseStdList(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(0).Value = branchID

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = instID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RPT_GetCorswiseStdList", arParms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function RPT_GetStudentDetails(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(0).Value = branchID

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = instID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID


            arParms(3) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(3).Value = batchID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_RPT_StudentDetails]", arParms)
            Return ds

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function RPT_GetFinalResult(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(0).Value = branchID

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = instID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID


            arParms(3) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(3).Value = batchID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_RPT_EnrollmentReg]", arParms)
            Return ds

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function RPT_GetStudentwiseDetails(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16, ByVal stdid As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(4) {}

            arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(0).Value = branchID

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = instID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID

            arParms(3) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(3).Value = batchID

            arParms(4) = New SqlParameter("@stdid", SqlDbType.Int)
            arParms(4).Value = stdid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RPT_StudentwiseDetails", arParms)
            Return ds

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function InsertCoursePlanner(ByVal Crse As Int16, ByVal BtchTo As String) As Integer
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@courseid", SqlDbType.Int)
            arParms(0).Value = Crse

            arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
            arParms(1).Value = HttpContext.Current.Session("BranchID")

            arParms(2) = New SqlParameter("@instituteid", SqlDbType.Int)
            arParms(2).Value = HttpContext.Current.Session("InstituteID")

            arParms(3) = New SqlParameter("@batchNo", SqlDbType.VarChar)
            arParms(3).Value = BtchTo

            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertCoursePlanner", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Return rowsAffected

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCoursePlannerID(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batch As String) As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(0).Value = instID

            arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(1).Value = branchID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID

            arParms(3) = New SqlParameter("@Batch_No", SqlDbType.VarChar)
            arParms(3).Value = batch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCoursePlannerID", arParms)
            Return ds.Tables(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function GetStudentsForRollOver(ByVal instID As Int16, ByVal branchID As Int16, ByVal corsID As Int16, ByVal batchID As Int16) As System.Data.DataSet
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Branch_ID", SqlDbType.Int)
            arParms(0).Value = branchID

            arParms(1) = New SqlParameter("@Institute_ID", SqlDbType.Int)
            arParms(1).Value = instID

            arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
            arParms(2).Value = corsID

            arParms(3) = New SqlParameter("@CoursePlannerID", SqlDbType.Int)
            arParms(3).Value = batchID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdForRollOver", arParms)

            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetIndStudDetailsRpt(ByVal BrId As String, ByVal AId As Integer, ByVal CId As Integer, ByVal BId As Integer, ByVal country As String, ByVal SId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@BranchId", SqlDbType.VarChar, 50)
        arParms(0).Value = BrId

        arParms(1) = New SqlParameter("@AId", SqlDbType.Int)
        arParms(1).Value = AId

        arParms(2) = New SqlParameter("@CId", SqlDbType.Int)
        arParms(2).Value = CId

        arParms(3) = New SqlParameter("@BId", SqlDbType.Int)
        arParms(3).Value = BId

        arParms(4) = New SqlParameter("@country", SqlDbType.VarChar, 50)
        arParms(4).Value = country

        arParms(5) = New SqlParameter("@student", SqlDbType.Int)
        arParms(5).Value = SId

        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_IndStudDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Shared Function GetIndStudDetailsforBonafideCertiRpt(ByVal BrId As String, ByVal AId As Integer, ByVal CId As Integer, ByVal BId As Integer, ByVal country As String, ByVal SId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchId", SqlDbType.VarChar, 50)
        arParms(0).Value = BrId

        arParms(1) = New SqlParameter("@AId", SqlDbType.Int)
        arParms(1).Value = AId

        arParms(2) = New SqlParameter("@CId", SqlDbType.Int)
        arParms(2).Value = CId

        arParms(3) = New SqlParameter("@BId", SqlDbType.Int)
        arParms(3).Value = BId

        arParms(4) = New SqlParameter("@country", SqlDbType.VarChar, 50)
        arParms(4).Value = country

        arParms(5) = New SqlParameter("@student", SqlDbType.Int)
        arParms(5).Value = SId

        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_FRROBonafideCerti", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Shared Function GetIndStudDetailsforTransferCertiRpt(ByVal BrId As String, ByVal AId As Integer, ByVal CId As Integer, ByVal BId As Integer, ByVal country As String, ByVal SId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchId", SqlDbType.VarChar, 50)
        arParms(0).Value = BrId

        arParms(1) = New SqlParameter("@AId", SqlDbType.Int)
        arParms(1).Value = AId

        arParms(2) = New SqlParameter("@CId", SqlDbType.Int)
        arParms(2).Value = CId

        arParms(3) = New SqlParameter("@BId", SqlDbType.Int)
        arParms(3).Value = BId

        arParms(4) = New SqlParameter("@country", SqlDbType.Int)
        arParms(4).Value = country

        arParms(5) = New SqlParameter("@student", SqlDbType.Int)
        arParms(5).Value = SId

        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_TransferCertificate", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Shared Function GetIndStudDetailsforStudyCertiRpt(ByVal BrId As String, ByVal AId As Integer, ByVal CId As Integer, ByVal BId As Integer, ByVal country As String, ByVal SId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchId", SqlDbType.VarChar, 50)
        arParms(0).Value = BrId

        arParms(1) = New SqlParameter("@AId", SqlDbType.Int)
        arParms(1).Value = AId

        arParms(2) = New SqlParameter("@CId", SqlDbType.Int)
        arParms(2).Value = CId

        arParms(3) = New SqlParameter("@BId", SqlDbType.Int)
        arParms(3).Value = BId

        arParms(4) = New SqlParameter("@country", SqlDbType.Int)
        arParms(4).Value = country

        arParms(5) = New SqlParameter("@student", SqlDbType.Int)
        arParms(5).Value = SId

        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_StudyCertificate", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetMentorName(ByVal MentorId As Integer) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@MentorId", SqlDbType.Int)
        arParms(0).Value = MentorId

        'The below condition was given to handle if the user logs in and go to the admission Register and logs out without performing any operation, it will take to error page
        If HttpContext.Current.Session("UserName") <> "" Then
            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Else
            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = "I"

            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = "000000000000"
        End If

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ddlMentorName", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetMentorCode(ByVal MentorId As Integer) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@MentorId", SqlDbType.Int)
        arParms(0).Value = MentorId

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "ddlMentorCode", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Shared Function GetStdRegCode() As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}


        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[New_SelectStdRegNo]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetProductName(ByVal prefixText As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, 50)
        arParms(0).Value = prefixText

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@ProductNameAutocomplete", SqlDbType.Int)
        arParms(3).Value = HttpContext.Current.Session("ProductNameAutocomplete")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetProductName", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function CountryCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCountryStudent", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function CountryCombo1() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCountryStudent1", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function EthnicCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEtinicityDDL", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function CasteCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCasteDDL", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetDistricEmpMaster(ByVal countryId As Integer, ByVal StateId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@countryId", SqlDbType.Int)
            arParms(0).Value = countryId

            arParms(1) = New SqlParameter("@StateId", SqlDbType.Int)
            arParms(1).Value = StateId
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetDistricstdMaster", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStateEmpMaster(ByVal countryId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@countryId", SqlDbType.Int)
            arParms(0).Value = countryId
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStateStdMaster", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStateEmpMaster1(ByVal countryId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@countryId", SqlDbType.Int)
            arParms(0).Value = countryId
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStateStdMaster1", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
Namespace GlobalDataSetTableAdapters
    Partial Public Class StudentMasterRollOverTableAdapter
        Private _transaction As SqlTransaction
        Private Property Transaction() As SqlClient.SqlTransaction
            Get
                Return Me._transaction
            End Get
            Set(ByVal Value As SqlTransaction)
                Me._transaction = Value
            End Set
        End Property
    End Class


End Namespace