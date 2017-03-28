Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLBranchDB
    
    Public Shared Function FillHo() As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetFullHO", arParms)

        Return ds
    End Function
    Public Shared Function FillBranchType() As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter() {}

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranchType", arParms)

        Return ds
    End Function
    Shared Function GetRptBrnId(ByVal code As String, ByVal HO As String) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        Try

            arParms(0) = New SqlParameter("@rptbrnTyId", SqlDbType.Char, code.Length)
            arParms(0).Value = code

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@HO", SqlDbType.VarChar, HO.Length)
            arParms(2).Value = HO
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetReportBranch", arParms)
            Return ds

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetDistrict() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllDistrict")
        Return ds
    End Function
    Shared Function GetBranch(ByVal branchid As Long, ByVal code As String) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchID", SqlDbType.VarChar, 50)
        Parms(0).Value = branchid

        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Parms(2).Value = HttpContext.Current.Session("Office")

        Parms(3) = New SqlParameter("@ddlBranchCode", SqlDbType.VarChar, 50)
        Parms(3).Value = code

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SP_GetAllBranch", Parms)
        Return ds
    End Function
    Shared Function GetBrType(ByVal code As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBrType", New System.Data.SqlClient.SqlParameter("@code", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "BranchTypeCode", DataRowVersion.Current, code))
        Return ds.Tables(0)
    End Function
    Shared Function GetBrTypeCode(ByVal code As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@code", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBrTypeCode", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetAllEmpExt(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllEmpExt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    
    Shared Function Insert(ByVal b As Branch) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(36) {}

        arParms(0) = New SqlParameter("@Name", SqlDbType.Char, b.Name.Length)
        arParms(0).Value = b.Name

        arParms(1) = New SqlParameter("@SsbCode", SqlDbType.Char, b.SSBCode.Length)
        arParms(1).Value = b.SSBCode

        arParms(2) = New SqlParameter("@Address", SqlDbType.Char, b.Address.Length)
        arParms(2).Value = b.Address

        arParms(3) = New SqlParameter("@ContactNo", SqlDbType.Char, b.ContactNo.Length)
        arParms(3).Value = b.ContactNo

        arParms(4) = New SqlParameter("@District", SqlDbType.Char, 50)
        arParms(4).Value = "" 'b.District

        arParms(5) = New SqlParameter("@HOCode", SqlDbType.Char, b.HOCode.Length)
        arParms(5).Value = b.HOCode

        arParms(6) = New SqlParameter("@BrnType", SqlDbType.Char, b.BrnType.Length)
        arParms(6).Value = b.BrnType

        arParms(7) = New SqlParameter("@RptBrn", SqlDbType.Char, b.RptBrn.Length)
        arParms(7).Value = b.RptBrn

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.Char)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@EmpCode", SqlDbType.Char)
        arParms(9).Value = HttpContext.Current.Session("EmpCode")

        If b.ContactPerson <> Nothing Then
            arParms(10) = New SqlParameter("@person", SqlDbType.Char, b.ContactPerson.Length)
            arParms(10).Value = b.ContactPerson
        Else
            arParms(10) = New SqlParameter("@person", SqlDbType.Char)
            arParms(10).Value = 0
        End If

        arParms(11) = New SqlParameter("@branch_code", SqlDbType.Char)
        arParms(11).Value = HttpContext.Current.Session("BranchCode")

        arParms(12) = New SqlParameter("@Designation", SqlDbType.Char, b.Designation.Length)
        arParms(12).Value = b.Designation

        arParms(13) = New SqlParameter("@BreakTime", SqlDbType.Int)
        arParms(13).Value = b.BreakTime

        arParms(14) = New SqlParameter("@FromEmailID", SqlDbType.VarChar)
        arParms(14).Value = b.FromEmailID

        arParms(15) = New SqlParameter("@FromPassword", SqlDbType.VarChar)
        arParms(15).Value = b.FromPassword

        arParms(16) = New SqlParameter("@SMTPHost", SqlDbType.VarChar)
        arParms(16).Value = b.SMTPHost

        arParms(17) = New SqlParameter("@Account", SqlDbType.VarChar)
        arParms(17).Value = b.AccountNo

        arParms(18) = New SqlParameter("@SMSService", SqlDbType.VarChar, 2)
        arParms(18).Value = b.SMSService

        arParms(19) = New SqlParameter("@EmailService", SqlDbType.VarChar, 2)
        arParms(19).Value = b.EmailService

        arParms(20) = New SqlParameter("@AffiliatedTo", SqlDbType.VarChar, 200)
        arParms(20).Value = b.AffiliatedTo

        arParms(21) = New SqlParameter("@ApprovedBy", SqlDbType.VarChar, 300)
        arParms(21).Value = b.ApprovedBy

        arParms(22) = New SqlParameter("@Accredited", SqlDbType.VarChar, 100)
        arParms(22).Value = b.Accredited

        arParms(23) = New SqlParameter("@BranchRegistationNo", SqlDbType.VarChar, 50)
        arParms(23).Value = b.BranchRegistationNo

        arParms(24) = New SqlParameter("@Website", SqlDbType.VarChar, 150)
        arParms(24).Value = b.Website

        arParms(25) = New SqlParameter("@ContactEmailID", SqlDbType.VarChar, 150)
        arParms(25).Value = b.EmailID

        arParms(26) = New SqlParameter("@Logo", SqlDbType.VarChar, 150)
        arParms(26).Value = IIf(b.Logo = "~\Images\imageupload.gif", System.DBNull.Value, b.Logo)

        arParms(27) = New SqlParameter("@TagLine", SqlDbType.VarChar, b.TagLine.Length)
        arParms(27).Value = b.TagLine

        arParms(28) = New SqlParameter("@IncludeInsName", SqlDbType.VarChar, b.IncludeInsName.Length)
        arParms(28).Value = b.IncludeInsName

        arParms(29) = New SqlParameter("@SPassword", SqlDbType.VarChar, b.SPassword.Length)
        arParms(29).Value = b.SPassword

        arParms(30) = New SqlParameter("@Status", SqlDbType.VarChar, b.Status.Length)
        arParms(30).Value = b.Status

        arParms(31) = New SqlParameter("@TeacherSubjectMapping", SqlDbType.VarChar, b.ChkTeacherSubject.Length)
        arParms(31).Value = b.ChkTeacherSubject

        arParms(32) = New SqlParameter("@Biometric", SqlDbType.VarChar, 200)
        arParms(32).Value = b.Biometric

        If b.CreationDate = "1900-01-01" Then
            arParms(33) = New SqlParameter("@CreationDate", SqlDbType.DateTime)
            arParms(33).Value = DBNull.Value
        Else
            arParms(33) = New SqlParameter("@CreationDate", SqlDbType.DateTime)
            arParms(33).Value = b.CreationDate
        End If
        arParms(34) = New SqlParameter("@PfAcct", SqlDbType.VarChar, 50)
        arParms(34).Value = b.PFAcct

        arParms(35) = New SqlParameter("@BankId", SqlDbType.Int)
        arParms(35).Value = b.BankId

        arParms(36) = New SqlParameter("@BranchImg", SqlDbType.VarChar, 150)
        arParms(36).Value = IIf(b.BranchImg = "~/Images/Schoolmgmt.jpg", System.DBNull.Value, b.BranchImg)

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveBranchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal b As Branch) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer

        Dim arParms() As SqlParameter = New SqlParameter(33) {}

        arParms(0) = New SqlParameter("@Name", SqlDbType.VarChar, b.Name.Length)
        arParms(0).Value = b.Name

        arParms(1) = New SqlParameter("@Address", SqlDbType.VarChar, b.Address.Length)
        arParms(1).Value = b.Address

        arParms(2) = New SqlParameter("@ContactNo", SqlDbType.VarChar, b.ContactNo.Length)
        arParms(2).Value = b.ContactNo

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        If b.ContactPerson <> Nothing Then
            arParms(5) = New SqlParameter("@person", SqlDbType.VarChar, b.ContactPerson.Length)
            arParms(5).Value = b.ContactPerson
        Else
            arParms(5) = New SqlParameter("@person", SqlDbType.VarChar, b.ContactPerson.Length)
            arParms(5).Value = 0
        End If

        arParms(6) = New SqlParameter("@branch_code", SqlDbType.VarChar)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@AccountNo", SqlDbType.VarChar, b.AccountNo.Length)
        arParms(7).Value = b.AccountNo

        If b.BankCode <> Nothing Then
            arParms(8) = New SqlParameter("@BankCode", SqlDbType.VarChar, b.BankCode.Length)
            arParms(8).Value = b.BankCode
        Else
            arParms(8) = New SqlParameter("@BankCode", SqlDbType.VarChar)
            arParms(8).Value = ""
        End If

        arParms(9) = New SqlParameter("@id", SqlDbType.Int)
        arParms(9).Value = b.Id

        arParms(10) = New SqlParameter("@designation", SqlDbType.VarChar, b.Designation.Length)
        arParms(10).Value = b.Designation

        arParms(11) = New SqlParameter("@BreakTime", SqlDbType.Int)
        arParms(11).Value = b.BreakTime

        arParms(12) = New SqlParameter("@FromEmailID", SqlDbType.VarChar, b.FromEmailID.Length)
        arParms(12).Value = b.FromEmailID

        arParms(13) = New SqlParameter("@FromPassword", SqlDbType.VarChar, b.FromPassword.Length)
        arParms(13).Value = b.FromPassword

        arParms(14) = New SqlParameter("@SMTPHost", SqlDbType.VarChar, b.SMTPHost.Length)
        arParms(14).Value = b.SMTPHost

        arParms(15) = New SqlParameter("@SMSService", SqlDbType.VarChar, 2)
        arParms(15).Value = b.SMSService

        arParms(16) = New SqlParameter("@EmailService", SqlDbType.VarChar, 2)
        arParms(16).Value = b.EmailService

        arParms(17) = New SqlParameter("@AffiliatedTo", SqlDbType.VarChar, 200)
        arParms(17).Value = b.AffiliatedTo

        arParms(18) = New SqlParameter("@ApprovedBy", SqlDbType.VarChar, 300)
        arParms(18).Value = b.ApprovedBy

        arParms(19) = New SqlParameter("@Accredited", SqlDbType.VarChar, 100)
        arParms(19).Value = b.Accredited

        arParms(20) = New SqlParameter("@BranchRegistationNo", SqlDbType.VarChar, 50)
        arParms(20).Value = b.BranchRegistationNo

        arParms(21) = New SqlParameter("@Website", SqlDbType.VarChar, 150)
        arParms(21).Value = b.Website

        arParms(22) = New SqlParameter("@ContactEmailID", SqlDbType.VarChar, 150)
        arParms(22).Value = b.EmailID

        arParms(23) = New SqlParameter("@Logo", SqlDbType.VarChar, 150)
        arParms(23).Value = IIf(b.Logo = "~\Images\imageupload.gif", System.DBNull.Value, b.Logo)

        arParms(24) = New SqlParameter("@TagLine", SqlDbType.VarChar, b.TagLine.Length)
        arParms(24).Value = b.TagLine

        arParms(25) = New SqlParameter("@IncludeInsName", SqlDbType.VarChar, b.IncludeInsName.Length)
        arParms(25).Value = b.IncludeInsName

        arParms(26) = New SqlParameter("@SPassword", SqlDbType.VarChar, b.SPassword.Length)
        arParms(26).Value = b.SPassword

        arParms(27) = New SqlParameter("@Status", SqlDbType.VarChar, b.Status.Length)
        arParms(27).Value = b.Status

        arParms(28) = New SqlParameter("@TeacherSubjectMapping", SqlDbType.VarChar, b.ChkTeacherSubject.Length)
        arParms(28).Value = b.ChkTeacherSubject

        arParms(29) = New SqlParameter("@Biometric", SqlDbType.VarChar, 200)
        arParms(29).Value = b.Biometric

        If b.CreationDate = "1900-01-01" Then
            arParms(30) = New SqlParameter("@CreationDate", SqlDbType.DateTime)
            arParms(30).Value = DBNull.Value
        Else
            arParms(30) = New SqlParameter("@CreationDate", SqlDbType.DateTime)
            arParms(30).Value = b.CreationDate
        End If

        arParms(31) = New SqlParameter("@PfAcct", SqlDbType.VarChar, 50)
        arParms(31).Value = b.PFAcct

        arParms(32) = New SqlParameter("@BankId", SqlDbType.Int)
        arParms(32).Value = b.BankId

        arParms(33) = New SqlParameter("@BranchImg", SqlDbType.VarChar, 150)
        arParms(33).Value = IIf(b.BranchImg = "~/Images/Schoolmgmt.jpg", System.DBNull.Value, b.BranchImg)

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateBranchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@branchid", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteBranchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetBankNameExt(ByVal prefixText As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        arParms(0) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        arParms(0).Value = prefixText

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AgentNameExt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBranchCombo() As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.Char)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_BranchCombo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmployee(ByVal b As Branch) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        arParms(0) = New SqlParameter("@designation", SqlDbType.VarChar, b.Designation.Length)
        arParms(0).Value = b.Designation


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpOnDesig", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBranchSearch(ByVal EL As Branch) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(14) {}

        arParms(0) = New SqlParameter("@branch", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")

        If EL.HOCode <> "Select" Then
            arParms(2) = New SqlClient.SqlParameter("@HOCode", SqlDbType.VarChar, 50)
            arParms(2).Value = EL.HOCode
        Else
            arParms(2) = New SqlClient.SqlParameter("@HOCode", SqlDbType.VarChar, 50)
            arParms(2).Value = "*"
        End If

        If EL.BrnType <> "Select" Then
            arParms(3) = New SqlClient.SqlParameter("@BrnType", SqlDbType.VarChar, 50)
            arParms(3).Value = EL.BrnType
        Else
            arParms(3) = New SqlClient.SqlParameter("@BrnType", SqlDbType.VarChar, 50)
            arParms(3).Value = "*"
        End If

        If EL.RptBrn <> "Select" Then
            arParms(4) = New SqlClient.SqlParameter("@RptBrn", SqlDbType.VarChar, 50)
            arParms(4).Value = EL.RptBrn
        Else
            arParms(4) = New SqlClient.SqlParameter("@RptBrn", SqlDbType.VarChar, 50)
            arParms(4).Value = "*"
        End If

        If EL.Name <> Nothing Then
            arParms(5) = New SqlClient.SqlParameter("@Name", SqlDbType.VarChar, 50)
            arParms(5).Value = EL.Name
        Else
            arParms(5) = New SqlClient.SqlParameter("@Name", SqlDbType.VarChar, 50)
            arParms(5).Value = "*"
        End If

        If EL.SSBCode <> Nothing Then
            arParms(6) = New SqlClient.SqlParameter("@SSBCode", SqlDbType.VarChar, 50)
            arParms(6).Value = EL.SSBCode
        Else
            arParms(6) = New SqlClient.SqlParameter("@SSBCode", SqlDbType.VarChar, 50)
            arParms(6).Value = "*"
        End If

        If EL.Address <> Nothing Then
            arParms(7) = New SqlClient.SqlParameter("@Address", SqlDbType.VarChar, 50)
            arParms(7).Value = EL.Address
        Else
            arParms(7) = New SqlClient.SqlParameter("@Address", SqlDbType.VarChar, 50)
            arParms(7).Value = "*"
        End If

        If EL.District <> "Select" Then
            arParms(8) = New SqlClient.SqlParameter("@District", SqlDbType.VarChar, 50)
            arParms(8).Value = EL.District
        Else
            arParms(8) = New SqlClient.SqlParameter("@District", SqlDbType.VarChar, 50)
            arParms(8).Value = "*"
        End If

        If EL.ContactNo <> Nothing Then
            arParms(9) = New SqlClient.SqlParameter("@ContactNo", SqlDbType.VarChar, 50)
            arParms(9).Value = EL.ContactNo
        Else
            arParms(9) = New SqlClient.SqlParameter("@ContactNo", SqlDbType.VarChar, 50)
            arParms(9).Value = "*"
        End If

        If EL.Designation <> "Select" Then
            arParms(10) = New SqlClient.SqlParameter("@Designation", SqlDbType.VarChar, 50)
            arParms(10).Value = EL.Designation
        Else
            arParms(10) = New SqlClient.SqlParameter("@Designation", SqlDbType.VarChar, 50)
            arParms(10).Value = "*"
        End If

        If EL.ContactPerson <> "Select" Then
            arParms(11) = New SqlClient.SqlParameter("@ContactPerson", SqlDbType.VarChar, 50)
            arParms(11).Value = EL.ContactPerson
        Else
            arParms(11) = New SqlClient.SqlParameter("@ContactPerson", SqlDbType.VarChar, 50)
            arParms(11).Value = "*"
        End If

        If EL.AccountNo <> Nothing Then
            arParms(12) = New SqlClient.SqlParameter("@AccountNo", SqlDbType.VarChar, 50)
            arParms(12).Value = EL.AccountNo
        Else
            arParms(12) = New SqlClient.SqlParameter("@AccountNo", SqlDbType.VarChar, 50)
            arParms(12).Value = "*"
        End If

        If EL.BankCode <> Nothing Then
            arParms(13) = New SqlClient.SqlParameter("@BankCode", SqlDbType.VarChar, 50)
            arParms(13).Value = EL.BankCode
        Else
            arParms(13) = New SqlClient.SqlParameter("@BankCode", SqlDbType.VarChar, 50)
            arParms(13).Value = "*"
        End If

        If EL.BankBranch <> Nothing Then
            arParms(14) = New SqlClient.SqlParameter("@BankBranch", SqlDbType.VarChar, 50)
            arParms(14).Value = EL.BankBranch
        Else
            arParms(14) = New SqlClient.SqlParameter("@BankBranch", SqlDbType.VarChar, 50)
            arParms(14).Value = "*"
        End If

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SearchBranch", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetExpiryDate(ByVal HOCode As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, HOCode.Length)
        arParms(0).Value = HOCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetInsExpiryDate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
