Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLCompanyRegister
    Shared Function InsertCompanyRegister(ByVal el As ELCompanyRegister) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(17) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 150)
        arParms(3).Value = el.CompanyRegName
        arParms(4) = New SqlParameter("@CompanyCode", SqlDbType.VarChar, 50)
        arParms(4).Value = el.CompanyRegCode
        arParms(5) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        arParms(5).Value = el.CompanyRegAddress
        arParms(6) = New SqlParameter("@Location", SqlDbType.VarChar, 50)
        arParms(6).Value = el.CompanyRegLocation
        If el.CompanyRegPostalCode = 0 Then
            arParms(7) = New SqlParameter("@PostalCode", SqlDbType.VarChar, 50)
            arParms(7).Value = System.DBNull.Value
        Else
            arParms(7) = New SqlParameter("@PostalCode", SqlDbType.VarChar, 50)
            arParms(7).Value = el.CompanyRegPostalCode
        End If


        arParms(8) = New SqlParameter("@District", SqlDbType.VarChar, 50)
        arParms(8).Value = el.CompanyRegDistrict
        arParms(9) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(9).Value = el.CompanyRegState
        arParms(10) = New SqlParameter("@Website", SqlDbType.VarChar, 150)
        arParms(10).Value = el.CompanyRegDwebDetails
        arParms(11) = New SqlParameter("@CompanyActivites", SqlDbType.VarChar, 50)
        arParms(11).Value = el.CompanyRegActivites
        If el.CompanyRegNoOfEmployee = 0 Then
            arParms(12) = New SqlParameter("@NoOfEmployee", SqlDbType.Int)
            arParms(12).Value = System.DBNull.Value
        Else
            arParms(12) = New SqlParameter("@NoOfEmployee", SqlDbType.Int)
            arParms(12).Value = el.CompanyRegNoOfEmployee
        End If
        If el.CompanyRegNoOfFresher = 0 Then
            arParms(13) = New SqlParameter("@NoOfFresher", SqlDbType.Int)
            arParms(13).Value = System.DBNull.Value
        Else
            arParms(13) = New SqlParameter("@NoOfFresher", SqlDbType.Int)
            arParms(13).Value = el.CompanyRegNoOfFresher
        End If

        arParms(14) = New SqlParameter("@CEONmae", SqlDbType.VarChar, 150)
        arParms(14).Value = el.CompanyRegCeoName
        arParms(15) = New SqlParameter("@CEOEmail", SqlDbType.VarChar, 50)
        arParms(15).Value = el.CompanyRegCeoEmail
        arParms(16) = New SqlParameter("@CEOLandLine", SqlDbType.VarChar, 50)
        arParms(16).Value = el.CompanyRegCeoLandline
        arParms(17) = New SqlParameter("@CEOMobile", SqlDbType.VarChar, 50)
        arParms(17).Value = el.CompanyRegCeoMobile

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertRegisterComapny", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetCompanyRegister(ByVal el As ELCompanyRegister) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.Id
        arParms(3) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 50)
        arParms(3).Value = el.CompanyRegName
        arParms(4) = New SqlParameter("@CompanyCode", SqlDbType.VarChar, 50)
        arParms(4).Value = el.CompanyRegCode
        arParms(5) = New SqlParameter("@Location", SqlDbType.VarChar, 50)
        arParms(5).Value = el.CompanyRegLocation
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCompanyRegister", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function UpdateCompanyRegister(ByVal el As ELCompanyRegister) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(18) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 150)
        arParms(3).Value = el.CompanyRegName
        arParms(4) = New SqlParameter("@CompanyCode", SqlDbType.VarChar, 50)
        arParms(4).Value = el.CompanyRegCode
        arParms(5) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        arParms(5).Value = el.CompanyRegAddress
        arParms(6) = New SqlParameter("@Location", SqlDbType.VarChar, 50)
        arParms(6).Value = el.CompanyRegLocation
        If el.CompanyRegPostalCode = 0 Then
            arParms(7) = New SqlParameter("@PostalCode", SqlDbType.VarChar, 50)
            arParms(7).Value = System.DBNull.Value
        Else
            arParms(7) = New SqlParameter("@PostalCode", SqlDbType.VarChar, 50)
            arParms(7).Value = el.CompanyRegPostalCode
        End If
       
       
        arParms(8) = New SqlParameter("@District", SqlDbType.VarChar, 50)
        arParms(8).Value = el.CompanyRegDistrict
        arParms(9) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(9).Value = el.CompanyRegState
        arParms(10) = New SqlParameter("@Website", SqlDbType.VarChar, 150)
        arParms(10).Value = el.CompanyRegDwebDetails
        arParms(11) = New SqlParameter("@CompanyActivites", SqlDbType.VarChar, 50)
        arParms(11).Value = el.CompanyRegActivites
        If el.CompanyRegNoOfEmployee = 0 Then
            arParms(12) = New SqlParameter("@NoOfEmployee", SqlDbType.Int)
            arParms(12).Value = System.DBNull.Value
        Else
            arParms(12) = New SqlParameter("@NoOfEmployee", SqlDbType.Int)
            arParms(12).Value = el.CompanyRegNoOfEmployee
        End If
        If el.CompanyRegNoOfFresher = 0 Then
            arParms(13) = New SqlParameter("@NoOfFresher", SqlDbType.Int)
            arParms(13).Value = System.DBNull.Value
        Else
            arParms(13) = New SqlParameter("@NoOfFresher", SqlDbType.Int)
            arParms(13).Value = el.CompanyRegNoOfFresher
        End If
       
        arParms(14) = New SqlParameter("@CEONmae", SqlDbType.VarChar, 150)
        arParms(14).Value = el.CompanyRegCeoName
        arParms(15) = New SqlParameter("@CEOEmail", SqlDbType.VarChar, 50)
        arParms(15).Value = el.CompanyRegCeoEmail
        arParms(16) = New SqlParameter("@CEOLandLine", SqlDbType.VarChar, 50)
        arParms(16).Value = el.CompanyRegCeoLandline
        arParms(17) = New SqlParameter("@CEOMobile", SqlDbType.VarChar, 50)
        arParms(17).Value = el.CompanyRegCeoMobile
        arParms(18) = New SqlParameter("@id", SqlDbType.Int)
        arParms(18).Value = el.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateCompanyRegister", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlagCompanyRegister(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteRegisterCompany", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckDuplicateCompanyRegister(ByVal EL As ELCompanyRegister) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@CompanyCode", SqlDbType.VarChar, 50)
        para(1).Value = EL.CompanyRegCode
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.Id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_DuplicateCompanyRegister", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetMKDcompanyName() As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}

        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetCompanyCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function InsertKDM(ByVal el As ELCompanyRegister) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 150)
        arParms(3).Value = el.MKDCompanyName
        arParms(4) = New SqlParameter("@Name", SqlDbType.VarChar, 50)
        arParms(4).Value = el.MKDName
        arParms(5) = New SqlParameter("@Designation", SqlDbType.VarChar, 50)
        arParms(5).Value = el.KDMDesignation
        arParms(6) = New SqlParameter("@LandLine", SqlDbType.VarChar, 50)
        arParms(6).Value = el.KDMLandLine
        arParms(7) = New SqlParameter("@Mobile", SqlDbType.VarChar, 50)
        arParms(7).Value = el.KDMMobile
        arParms(8) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(8).Value = el.KDMEmail
       
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertKDM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetKDM(ByVal el As ELCompanyRegister) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.Id
    
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetKeyDecisionMaker", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function UpdateKDM(ByVal el As ELCompanyRegister) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 150)
        arParms(3).Value = el.MKDCompanyName
        arParms(4) = New SqlParameter("@Name", SqlDbType.VarChar, 50)
        arParms(4).Value = el.MKDName
        arParms(5) = New SqlParameter("@Designation", SqlDbType.VarChar, 50)
        arParms(5).Value = el.KDMDesignation
        arParms(6) = New SqlParameter("@LandLine", SqlDbType.VarChar, 50)
        arParms(6).Value = el.KDMLandLine
        arParms(7) = New SqlParameter("@Mobile", SqlDbType.VarChar, 50)
        arParms(7).Value = el.KDMMobile
        arParms(8) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(8).Value = el.KDMEmail
        arParms(9) = New SqlParameter("@id", SqlDbType.Int)
        arParms(9).Value = el.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateKDM", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlagKDM(ByVal EL As ELCompanyRegister) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.Id1
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeletekeydecisionMaker", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckKDM(ByVal EL As ELCompanyRegister) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 50)
        para(1).Value = EL.MKDCompanyName
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.Id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_DuplicateKeyDecisionMaker", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function InsertSalaryStructure(ByVal el As ELCompanyRegister) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(13) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 150)
        arParms(3).Value = el.CompanySName
        arParms(4) = New SqlParameter("@Gross", SqlDbType.Money)
        arParms(4).Value = el.CompanySGross
        If el.CompanySCTC = 0 Then
            arParms(5) = New SqlParameter("@CTC", SqlDbType.Money)
            arParms(5).Value = System.DBNull.Value
        Else
            arParms(5) = New SqlParameter("@CTC", SqlDbType.Money)
            arParms(5).Value = el.CompanySCTC
        End If
        
        arParms(6) = New SqlParameter("@Medical", SqlDbType.VarChar, 2)
        arParms(6).Value = el.SalaryStrMedical
        arParms(7) = New SqlParameter("@Insurance", SqlDbType.VarChar, 2)
        arParms(7).Value = el.SalaryStrMInsurance
        arParms(8) = New SqlParameter("@PF", SqlDbType.VarChar, 2)
        arParms(8).Value = el.SalaryStrMPF
        arParms(9) = New SqlParameter("@LTA", SqlDbType.VarChar, 2)
        arParms(9).Value = el.SalaryStrLTA
        arParms(10) = New SqlParameter("@SFood", SqlDbType.VarChar, 2)
        arParms(10).Value = el.SalaryStrSFood
        arParms(11) = New SqlParameter("@Transport", SqlDbType.VarChar, 2)
        arParms(11).Value = el.SalaryStrMTransport
        arParms(12) = New SqlParameter("@Assistance", SqlDbType.VarChar, 2)
        arParms(12).Value = el.SalaryStrAssistance
        arParms(13) = New SqlParameter("@Accommodation", SqlDbType.VarChar, 2)
        arParms(13).Value = el.SalaryStrAccommodation

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertSalaryStructure", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetSalaryStructure(ByVal el As ELCompanyRegister) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = el.Id

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSalaryStructure", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function UpdateSalaryStructure(ByVal el As ELCompanyRegister) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(14) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 150)
        arParms(3).Value = el.CompanySName
        arParms(4) = New SqlParameter("@Gross", SqlDbType.Money)
        arParms(4).Value = el.CompanySGross
        If el.CompanySCTC = 0 Then
            arParms(5) = New SqlParameter("@CTC", SqlDbType.Money)
            arParms(5).Value = System.DBNull.Value
        Else
            arParms(5) = New SqlParameter("@CTC", SqlDbType.Money)
            arParms(5).Value = el.CompanySCTC
        End If

        arParms(6) = New SqlParameter("@Medical", SqlDbType.VarChar, 2)
        arParms(6).Value = el.SalaryStrMedical
        arParms(7) = New SqlParameter("@Insurance", SqlDbType.VarChar, 2)
        arParms(7).Value = el.SalaryStrMInsurance
        arParms(8) = New SqlParameter("@PF", SqlDbType.VarChar, 2)
        arParms(8).Value = el.SalaryStrMPF
        arParms(9) = New SqlParameter("@LTA", SqlDbType.VarChar, 2)
        arParms(9).Value = el.SalaryStrLTA
        arParms(10) = New SqlParameter("@SFood", SqlDbType.VarChar, 2)
        arParms(10).Value = el.SalaryStrSFood
        arParms(11) = New SqlParameter("@Transport", SqlDbType.VarChar, 2)
        arParms(11).Value = el.SalaryStrMTransport
        arParms(12) = New SqlParameter("@Assistance", SqlDbType.VarChar, 2)
        arParms(12).Value = el.SalaryStrAssistance
        arParms(13) = New SqlParameter("@Accommodation", SqlDbType.VarChar, 2)
        arParms(13).Value = el.SalaryStrAccommodation

        arParms(14) = New SqlParameter("@id", SqlDbType.Int)
        arParms(14).Value = el.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateSalaryStructure", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlagSalaryStructure(ByVal EL As ELCompanyRegister) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.Id1
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteSalaryStructure", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckDuplicateSalaryStructure(ByVal EL As ELCompanyRegister) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 50)
        para(1).Value = EL.CompanySName
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.Id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "proc_DuplicateSalaryStructure", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
