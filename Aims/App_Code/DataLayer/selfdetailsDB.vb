Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class selfdetailsDB
    Shared Function GetDeatils(ByVal id As Long) As System.Data.DataSet
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If id = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetSelfDetails")
        Else
            Dim arParms As SqlParameter = New SqlParameter("@MyCo_Id", SqlDbType.Int, 10)
            arParms.Value = id
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetSelfDetailsIDWise", arParms)
        End If
        Return ds
    End Function

    Shared Function GetSelfDetailsByUID() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms As SqlParameter = New SqlParameter()

        arParms = New SqlParameter("@NewHoID", SqlDbType.VarChar, 20)
        arParms.Value = Trim(HttpContext.Current.Session("BranchCode"))

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSelfDetailByUIDNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetTenantModuleList(ByVal InstituteCode As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@InstituteCode", SqlDbType.VarChar, InstituteCode.Length)
        arParms(0).Value = InstituteCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetParentNameList", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDeatilsByBranch(ByVal HO As String, ByVal registrationNo As String, ByVal email As String, ByVal website As String) As System.Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchID", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@HO", SqlDbType.VarChar, 500)
        arParms(1).Value = HO
        'IIf(HO = "", HO, HttpContext.Current.Session("BranchCode"))
        arParms(2) = New SqlParameter("@RegistrationNo", SqlDbType.VarChar, 500)
        arParms(2).Value = registrationNo

        arParms(3) = New SqlParameter("@Email", SqlDbType.VarChar, 500)
        arParms(3).Value = email

        arParms(4) = New SqlParameter("@Website", SqlDbType.VarChar, 500)
        arParms(4).Value = website

        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetSelfDtlsByBranchID", arParms)

        Return ds.Tables(0)
    End Function
    Shared Function GetDeatilsByHOID(ByVal Id As Int64) As System.Data.DataSet
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter = New SqlParameter()

        arParms = New SqlParameter("@HoID", SqlDbType.Int)
        arParms.Value = Id

        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "PROC_GETINSTITUTEBYID", arParms)

        Return ds
    End Function
    Shared Function RPT_GetDeatilsByBranch(ByVal UserDetailsCode As String) As System.Data.DataSet
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        'arParms(0) = New SqlParameter("@UserDetailsCode", SqlDbType.Char)
        'arParms(0).Value = UserDetailsCode

        arParms(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_RPT_GetSelfDetailByUID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function Update(ByVal s As SelfDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(17) {}

        arParms(0) = New SqlParameter("@MyCo_Name", SqlDbType.Char, s.Name.Length)
        arParms(0).Value = s.Name

        arParms(1) = New SqlParameter("@Company_Address", SqlDbType.Char, s.Address.Length)
        arParms(1).Value = s.Address

        arParms(2) = New SqlParameter("@registration", SqlDbType.Char, s.Registration.Length)
        arParms(2).Value = s.Registration

        arParms(3) = New SqlParameter("@City", SqlDbType.Char, s.City.Length)
        arParms(3).Value = s.City

        arParms(4) = New SqlParameter("@State", SqlDbType.VarChar, 100)
        arParms(4).Value = s.State

        arParms(5) = New SqlParameter("@Postal_Code", SqlDbType.Char, s.Code.Length)
        arParms(5).Value = s.Code

        arParms(6) = New SqlParameter("@Country", SqlDbType.Char, s.Country.Length)
        arParms(6).Value = s.Country

        arParms(7) = New SqlParameter("@Contact_Person", SqlDbType.Char, s.Contactperson.Length)
        arParms(7).Value = s.Contactperson

        arParms(8) = New SqlParameter("@Contact_Number1", SqlDbType.Char, s.Contactno1.Length)
        arParms(8).Value = s.Contactno1

        arParms(9) = New SqlParameter("@Contact_Number2", SqlDbType.Char, s.Contactno2.Length)
        arParms(9).Value = s.Contactno2

        arParms(10) = New SqlParameter("@Fax_Number", SqlDbType.Char, s.Fax.Length)
        arParms(10).Value = s.Fax

        arParms(11) = New SqlParameter("@Email", SqlDbType.Char, s.Email.Length)
        arParms(11).Value = s.Email

        arParms(12) = New SqlParameter("@Website", SqlDbType.Char, s.Website.Length)
        arParms(12).Value = s.Website

        arParms(13) = New SqlParameter("@empcode", SqlDbType.VarChar)
        arParms(13).Value = HttpContext.Current.Session("EmpCode")

        arParms(14) = New SqlParameter("@usercode", SqlDbType.VarChar)
        arParms(14).Value = HttpContext.Current.Session("UserCode")

        arParms(15) = New SqlParameter("@MyCo_Id", SqlDbType.BigInt)
        arParms(15).Value = s.CoId

        arParms(16) = New SqlParameter("@logo", SqlDbType.VarChar, 250)
        arParms(16).Value = s.Logo

        arParms(17) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateSelfDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateAdvant(ByVal s As SelfDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(25) {}

        arParms(0) = New SqlParameter("@MyCo_Name", SqlDbType.Char, s.Name.Length)
        arParms(0).Value = s.Name

        arParms(1) = New SqlParameter("@Company_Address", SqlDbType.Char, s.Address.Length)
        arParms(1).Value = s.Address

        arParms(2) = New SqlParameter("@registration", SqlDbType.Char, s.Registration.Length)
        arParms(2).Value = s.Registration

        arParms(3) = New SqlParameter("@City", SqlDbType.Char, s.City.Length)
        arParms(3).Value = s.City

        arParms(4) = New SqlParameter("@State", SqlDbType.VarChar, 100)
        arParms(4).Value = s.State

        arParms(5) = New SqlParameter("@Postal_Code", SqlDbType.Char, s.Code.Length)
        arParms(5).Value = s.Code

        arParms(6) = New SqlParameter("@Country", SqlDbType.Char, s.Country.Length)
        arParms(6).Value = s.Country

        arParms(7) = New SqlParameter("@Contact_Person", SqlDbType.Char, s.Contactperson.Length)
        arParms(7).Value = s.Contactperson

        arParms(8) = New SqlParameter("@Contact_Number1", SqlDbType.Char, s.Contactno1.Length)
        arParms(8).Value = s.Contactno1

        arParms(9) = New SqlParameter("@Contact_Number2", SqlDbType.Char, s.Contactno2.Length)
        arParms(9).Value = s.Contactno2

        arParms(10) = New SqlParameter("@Fax_Number", SqlDbType.Char, s.Fax.Length)
        arParms(10).Value = s.Fax

        arParms(11) = New SqlParameter("@Email", SqlDbType.Char, s.Email.Length)
        arParms(11).Value = s.Email

        arParms(12) = New SqlParameter("@Website", SqlDbType.Char, s.Website.Length)
        arParms(12).Value = s.Website

        arParms(13) = New SqlParameter("@empcode", SqlDbType.VarChar)
        arParms(13).Value = HttpContext.Current.Session("EmpCode")

        arParms(14) = New SqlParameter("@usercode", SqlDbType.VarChar)
        arParms(14).Value = HttpContext.Current.Session("UserCode")

        arParms(15) = New SqlParameter("@MyCo_Id", SqlDbType.BigInt)
        arParms(15).Value = s.CoId

        arParms(16) = New SqlParameter("@logo", SqlDbType.VarChar, 250)
        arParms(16).Value = s.Logo

        arParms(17) = New SqlParameter("@AdminName", SqlDbType.VarChar, 50)
        arParms(17).Value = s.AdminName

        arParms(18) = New SqlParameter("@AdminPassword", SqlDbType.VarChar, 250)
        arParms(18).Value = s.AdminPassword

        arParms(19) = New SqlParameter("@ExpiryDate", SqlDbType.DateTime)
        arParms(19).Value = s.PasswordExpiryDate

        arParms(20) = New SqlParameter("@Status", SqlDbType.VarChar, 3)
        arParms(20).Value = s.Status

        arParms(21) = New SqlParameter("@ImgDefault", SqlDbType.VarChar, s.logoDefault.Length)
        arParms(21).Value = s.logoDefault

        arParms(22) = New SqlParameter("@ImgHeader", SqlDbType.VarChar, s.logoHeader.Length)
        arParms(22).Value = s.logoHeader

        arParms(23) = New SqlParameter("@HeaderTextColor", SqlDbType.VarChar, s.HeaderColor.Length)
        arParms(23).Value = s.HeaderColor

        arParms(24) = New SqlParameter("@Prefix", SqlDbType.VarChar, s.Prefix.Length)
        arParms(24).Value = s.Prefix

        If s.CreationDate = "1900-01-01" Then
            arParms(25) = New SqlParameter("@CreationDate", SqlDbType.DateTime)
            arParms(25).Value = DBNull.Value
        Else
            arParms(25) = New SqlParameter("@CreationDate", SqlDbType.DateTime)
            arParms(25).Value = s.CreationDate
        End If

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateSelfDetailsAdvant", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Insert(ByVal s As SelfDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(27) {}

        arParms(0) = New SqlParameter("@MyCo_Name", SqlDbType.Char, s.Name.Length)
        arParms(0).Value = s.Name

        arParms(1) = New SqlParameter("@Company_Address", SqlDbType.Char, s.Address.Length)
        arParms(1).Value = s.Address

        arParms(2) = New SqlParameter("@registration", SqlDbType.Char, s.Registration.Length)
        arParms(2).Value = s.Registration

        arParms(3) = New SqlParameter("@City", SqlDbType.Char, s.City.Length)
        arParms(3).Value = s.City

        arParms(4) = New SqlParameter("@State", SqlDbType.VarChar, 100)
        arParms(4).Value = s.State

        arParms(5) = New SqlParameter("@Postal_Code", SqlDbType.Char, s.Code.Length)
        arParms(5).Value = s.Code

        arParms(6) = New SqlParameter("@Country", SqlDbType.Char, s.Country.Length)
        arParms(6).Value = s.Country

        arParms(7) = New SqlParameter("@Contact_Person", SqlDbType.Char, s.Contactperson.Length)
        arParms(7).Value = s.Contactperson

        arParms(8) = New SqlParameter("@Contact_Number1", SqlDbType.Char, s.Contactno1.Length)
        arParms(8).Value = s.Contactno1

        arParms(9) = New SqlParameter("@Contact_Number2", SqlDbType.Char, s.Contactno2.Length)
        arParms(9).Value = s.Contactno2

        arParms(10) = New SqlParameter("@Fax_Number", SqlDbType.Char, s.Fax.Length)
        arParms(10).Value = s.Fax

        arParms(11) = New SqlParameter("@Email", SqlDbType.Char, s.Email.Length)
        arParms(11).Value = s.Email

        arParms(12) = New SqlParameter("@Website", SqlDbType.Char, s.Website.Length)
        arParms(12).Value = s.Website

        arParms(13) = New SqlParameter("@HOflag", SqlDbType.Bit)
        arParms(13).Value = s.HoFlag

        arParms(14) = New SqlParameter("@empcode", SqlDbType.VarChar)
        arParms(14).Value = HttpContext.Current.Session("EmpCode")

        arParms(15) = New SqlParameter("@usercode", SqlDbType.VarChar)
        arParms(15).Value = HttpContext.Current.Session("UserCode")

        arParms(16) = New SqlParameter("@COid", SqlDbType.BigInt)
        arParms(16).Direction = ParameterDirection.Output

        arParms(17) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("BranchCode")

        arParms(18) = New SqlParameter("@Logopath", SqlDbType.VarChar, s.Logo.Length)
        arParms(18).Value = s.Logo

        arParms(19) = New SqlParameter("@AdminName", SqlDbType.VarChar, s.AdminName.Length)
        arParms(19).Value = s.AdminName

        arParms(20) = New SqlParameter("@AdminPassword", SqlDbType.VarChar, s.AdminPassword.Length)
        arParms(20).Value = s.AdminPassword

        arParms(21) = New SqlParameter("@ExpiryDate", SqlDbType.DateTime)
        arParms(21).Value = s.PasswordExpiryDate

        arParms(22) = New SqlParameter("@Status", SqlDbType.VarChar, s.Status.Length)
        arParms(22).Value = s.Status

        arParms(23) = New SqlParameter("@ImgDefault", SqlDbType.VarChar, s.logoDefault.Length)
        arParms(23).Value = s.logoDefault

        arParms(24) = New SqlParameter("@ImgHeader", SqlDbType.VarChar, s.logoHeader.Length)
        arParms(24).Value = s.logoHeader

        arParms(25) = New SqlParameter("@HeaderTextColor", SqlDbType.VarChar, s.HeaderColor.Length)
        arParms(25).Value = s.HeaderColor

        arParms(26) = New SqlParameter("@Prefix", SqlDbType.VarChar, s.Prefix.Length)
        arParms(26).Value = s.Prefix

        If s.CreationDate = "1900-01-01" Then
            arParms(27) = New SqlParameter("@CreationDate", SqlDbType.DateTime)
            arParms(27).Value = DBNull.Value
        Else
            arParms(27) = New SqlParameter("@CreationDate", SqlDbType.DateTime)
            arParms(27).Value = s.CreationDate
        End If
        

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveSelfDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function PhotoPathUpdate(ByVal i As Int64, ByVal path As String) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@MyCo_ID", SqlDbType.Int)
        arParms(0).Value = i

        arParms(1) = New SqlParameter("@Path", SqlDbType.Char, 255)
        arParms(1).Value = path

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SavephotoPath", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CheckDupli(ByVal rnd As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Name", SqlDbType.VarChar, 50)
        arParms(0).Value = rnd
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckSelfDetailsDuplicate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function CheckPrefixDupli(ByVal Prefix As String, ByVal id As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Prefix", SqlDbType.VarChar, 50)
        arParms(0).Value = Prefix

        arParms(1) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(1).Value = id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckSelfDetailsPrefixDupli", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateTenantRoles(ByVal Names As String, ByVal InstID As String, ByVal id1 As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Names", SqlDbType.VarChar, Names.Length)
        arParms(0).Value = Names

        arParms(1) = New SqlParameter("@InstID", SqlDbType.VarChar, InstID.Length)
        arParms(1).Value = InstID

        arParms(2) = New SqlParameter("@id1", SqlDbType.VarChar, id1.Length)
        arParms(2).Value = id1


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateRenantRoles", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DeleteJunkData() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter() {}
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DeleteAllJunkData", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteInstData(ByVal InstCode As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@InstCode", SqlDbType.VarChar, InstCode.Length)
        arParms(0).Value = InstCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DeleteAllInstData", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Kusum 02-02-2013
    Shared Function DeleteBranchData(ByVal InstCode As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, InstCode.Length)
        arParms(0).Value = InstCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_DeleteAllBranchData]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Code for get Company Master Report By Nitin 07/05/2012
    Shared Function RptClientMasterDetails() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptClientMasterDetails", arParms)
        Return ds.Tables(0)
    End Function
End Class
