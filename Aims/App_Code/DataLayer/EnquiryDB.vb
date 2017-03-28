Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class EnquiryDB
    Shared Function GetEnquiryDuplicate(ByVal e As Enquiry) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EnquiryNo", SqlDbType.NVarChar, 50)
        arParms(1).Value = e.EnquiryNo

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = e.Id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DuplicateEnquiryDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCriteria() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetCriteria", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    
    Shared Function GetEnquiry(ByVal e As Enquiry) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = e.Id

        arParms(3) = New SqlParameter("@Branch", SqlDbType.VarChar)
        arParms(3).Value = e.Branchid

        'arParms(4) = New SqlParameter("@EnqDate", SqlDbType.VarChar)
        'arParms(4).Value = e.EDate

        arParms(4) = New SqlParameter("@Name", SqlDbType.VarChar)
        arParms(4).Value = e.FName

        arParms(5) = New SqlParameter("@EnqRelated", SqlDbType.VarChar)
        arParms(5).Value = e.ERelates

        arParms(6) = New SqlParameter("@NicNo", SqlDbType.VarChar, 50)
        arParms(6).Value = e.NicNo

        arParms(7) = New SqlParameter("@OnlineEnqId", SqlDbType.Int)
        arParms(7).Value = e.OnlineEnqId

        Dim ds As DataSet
        'If id = 0 Then
        '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Select * From View_GetEnquiryDetails")
        'Else
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEnquiryDetailsByID", arParms)
            'End If
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAddEnquiry(ByVal ID As String) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        arParms(2).Value = ID

        Dim ds As DataSet
        'If id = 0 Then
        '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Select * From View_GetEnquiryDetails")
        'Else
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEnquiryAddedDetailsByID", arParms)
            'End If
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Insert(ByVal e As Enquiry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As New Integer
        Dim arParms() As SqlParameter = New SqlParameter(36) {}

        arParms(0) = New SqlParameter("@edate", SqlDbType.DateTime)
        arParms(0).Value = e.EDate

        arParms(1) = New SqlParameter("@title", SqlDbType.NVarChar, e.Title.Length)
        arParms(1).Value = e.Title

        arParms(2) = New SqlParameter("@name", SqlDbType.NVarChar, e.Name.Length)
        arParms(2).Value = e.Name

        arParms(3) = New SqlParameter("@address", SqlDbType.NVarChar, e.Address.Length)
        arParms(3).Value = e.Address

        arParms(4) = New SqlParameter("@country", SqlDbType.NVarChar, e.Country.Length)
        arParms(4).Value = e.Country

        arParms(5) = New SqlParameter("@phone", SqlDbType.NVarChar, e.Phone.Length)
        arParms(5).Value = e.Phone

        arParms(6) = New SqlParameter("@mobile", SqlDbType.NVarChar, e.Mobile.Length)
        arParms(6).Value = e.Mobile

        arParms(7) = New SqlParameter("@email", SqlDbType.NVarChar, e.Email.Length)
        arParms(7).Value = e.Email

        arParms(8) = New SqlParameter("@qualification", SqlDbType.NVarChar, e.Qualification.Length)
        arParms(8).Value = e.Qualification

        arParms(9) = New SqlParameter("@caste", SqlDbType.NVarChar, e.Caste.Length)
        arParms(9).Value = e.Caste

        arParms(10) = New SqlParameter("@erelates", SqlDbType.NVarChar, e.ERelates.Length)
        arParms(10).Value = e.ERelates

        arParms(11) = New SqlParameter("@coursetype", SqlDbType.Int)
        arParms(11).Value = e.CourseType

        arParms(12) = New SqlParameter("@course", SqlDbType.Int)
        arParms(12).Value = e.Course

        arParms(13) = New SqlParameter("@yenquiry", SqlDbType.NVarChar, e.YEnquiry.Length)
        arParms(13).Value = e.YEnquiry

        arParms(14) = New SqlParameter("@source", SqlDbType.Int)
        arParms(14).Value = e.Source


        arParms(15) = New SqlParameter("@branch", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("BranchCode")

        arParms(16) = New SqlParameter("@prospectus", SqlDbType.Int)
        arParms(16).Value = e.Prospectus

        arParms(17) = New SqlParameter("@fname", SqlDbType.NVarChar, e.FName.Length)
        arParms(17).Value = e.FName

        arParms(18) = New SqlParameter("@foccupation", SqlDbType.NVarChar, e.FOccupation.Length)
        arParms(18).Value = e.FOccupation

        arParms(19) = New SqlParameter("@aincome", SqlDbType.Money)
        arParms(19).Value = e.AIncome

        arParms(20) = New SqlParameter("@enquirer", SqlDbType.NVarChar, e.Enquirer.Length)
        arParms(20).Value = e.Enquirer

        arParms(21) = New SqlParameter("@city", SqlDbType.NVarChar, e.City.Length)
        arParms(21).Value = e.City

        arParms(22) = New SqlParameter("@district", SqlDbType.NVarChar, e.District.Length)
        arParms(22).Value = e.District

        arParms(23) = New SqlParameter("@pincode", SqlDbType.NVarChar, e.PinCode.Length)
        arParms(23).Value = e.PinCode

        arParms(24) = New SqlParameter("@state", SqlDbType.Int)
        arParms(24).Value = e.State

        arParms(25) = New SqlParameter("@Branchid", SqlDbType.VarChar, 15)
        arParms(25).Value = e.Branchid

        arParms(26) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(26).Value = HttpContext.Current.Session("UserCode")

        arParms(27) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(27).Value = HttpContext.Current.Session("EmpCode")

        If e.DOB = "01-01-9100" Then
            arParms(28) = New SqlParameter("@DOB", SqlDbType.VarChar)
            arParms(28).Value = DBNull.Value
        Else
            arParms(28) = New SqlParameter("@DOB", SqlDbType.DateTime)
            arParms(28).Value = e.DOB
        End If

        arParms(29) = New SqlParameter("@Transport", SqlDbType.VarChar, 2)
        arParms(29).Value = e.Transport

        arParms(30) = New SqlParameter("@Hostel", SqlDbType.VarChar, 2)
        arParms(30).Value = e.Hostel

        arParms(31) = New SqlParameter("@EnquiryNo", SqlDbType.NVarChar, 50)
        arParms(31).Value = e.EnquiryNo

        arParms(32) = New SqlParameter("@NicNo", SqlDbType.NVarChar, 50)
        arParms(32).Value = e.NicNo

        If e.NormalOnlineEnq = 0 Then
            arParms(33) = New SqlParameter("@Normal_OnlineEnquiry", SqlDbType.VarChar, 2)
            arParms(33).Value = "O"
        Else
            arParms(33) = New SqlParameter("@Normal_OnlineEnquiry", SqlDbType.VarChar, 2)
            arParms(33).Value = "N"
        End If
        If e.NormalOnlineEnq = 0 Then
            arParms(34) = New SqlParameter("@Enquiry_AutoId", SqlDbType.Int)
            arParms(34).Value = e.OnlineEnqId
        Else
            arParms(34) = New SqlParameter("@Enquiry_AutoId", SqlDbType.Int)
            arParms(34).Value = 0
        End If

        arParms(35) = New SqlParameter("@CategoryId", SqlDbType.NVarChar, 50)
        arParms(35).Value = e.CategoryId

        arParms(36) = New SqlParameter("@marks", SqlDbType.NVarChar, 50)
        arParms(36).Value = e.Marks


        Try
            rowsAffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_SaveEnquiryDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal e As Enquiry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(35) {}

        arParms(0) = New SqlParameter("@edate", SqlDbType.DateTime)
        arParms(0).Value = e.EDate

        arParms(1) = New SqlParameter("@title", SqlDbType.NVarChar, e.Title.Length)
        arParms(1).Value = e.Title

        arParms(2) = New SqlParameter("@name", SqlDbType.NVarChar, e.Name.Length)
        arParms(2).Value = e.Name

        arParms(3) = New SqlParameter("@address", SqlDbType.NVarChar, e.Address.Length)
        arParms(3).Value = e.Address

        arParms(4) = New SqlParameter("@country", SqlDbType.NVarChar, e.Country.Length)
        arParms(4).Value = e.Country

        arParms(5) = New SqlParameter("@phone", SqlDbType.NVarChar, e.Phone.Length)
        arParms(5).Value = e.Phone

        arParms(6) = New SqlParameter("@mobile", SqlDbType.NVarChar, e.Mobile.Length)
        arParms(6).Value = e.Mobile

        arParms(7) = New SqlParameter("@email", SqlDbType.NVarChar, e.Email.Length)
        arParms(7).Value = e.Email

        arParms(8) = New SqlParameter("@qualification", SqlDbType.NVarChar, e.Qualification.Length)
        arParms(8).Value = e.Qualification

        arParms(9) = New SqlParameter("@caste", SqlDbType.NVarChar, e.Caste.Length)
        arParms(9).Value = e.Caste

        arParms(10) = New SqlParameter("@erelates", SqlDbType.NVarChar, e.ERelates.Length)
        arParms(10).Value = e.ERelates

        arParms(11) = New SqlParameter("@coursetype", SqlDbType.Int)
        arParms(11).Value = e.CourseType

        arParms(12) = New SqlParameter("@course", SqlDbType.Int)
        arParms(12).Value = e.Course

        arParms(13) = New SqlParameter("@yenquiry", SqlDbType.NVarChar, e.YEnquiry.Length)
        arParms(13).Value = e.YEnquiry

        arParms(14) = New SqlParameter("@source", SqlDbType.Int)
        arParms(14).Value = e.Source

        arParms(15) = New SqlParameter("@branch", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("BranchCode")

        arParms(16) = New SqlParameter("@prospectus", SqlDbType.Int)
        arParms(16).Value = e.Prospectus

        arParms(17) = New SqlParameter("@fname", SqlDbType.NVarChar, e.FName.Length)
        arParms(17).Value = e.FName

        arParms(18) = New SqlParameter("@foccupation", SqlDbType.NVarChar, e.FOccupation.Length)
        arParms(18).Value = e.FOccupation

        arParms(19) = New SqlParameter("@aincome", SqlDbType.Money)
        arParms(19).Value = e.AIncome

        arParms(20) = New SqlParameter("@enquirer", SqlDbType.NVarChar, e.Enquirer.Length)
        arParms(20).Value = e.Enquirer

        arParms(21) = New SqlParameter("@city", SqlDbType.NVarChar, e.City.Length)
        arParms(21).Value = e.City

        arParms(22) = New SqlParameter("@district", SqlDbType.NVarChar, e.District.Length)
        arParms(22).Value = e.District

        arParms(23) = New SqlParameter("@pincode", SqlDbType.NVarChar, e.PinCode.Length)
        arParms(23).Value = e.PinCode

        arParms(24) = New SqlParameter("@state", SqlDbType.Int)
        arParms(24).Value = e.State

        arParms(25) = New SqlParameter("@BranchId", SqlDbType.VarChar)
        arParms(25).Value = e.Branchid

        arParms(26) = New SqlParameter("@id", SqlDbType.Int)
        arParms(26).Value = e.Id

        arParms(27) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(27).Value = HttpContext.Current.Session("UserCode")

        arParms(28) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(28).Value = HttpContext.Current.Session("EmpCode")
        If e.DOB = "01-01-9100" Then
            arParms(29) = New SqlParameter("@DOB", SqlDbType.VarChar)
            arParms(29).Value = DBNull.Value
        Else
            arParms(29) = New SqlParameter("@DOB", SqlDbType.DateTime)
            arParms(29).Value = e.DOB
        End If

        arParms(30) = New SqlParameter("@Transport", SqlDbType.VarChar, 2)
        arParms(30).Value = e.Transport

        arParms(31) = New SqlParameter("@Hostel", SqlDbType.VarChar, 2)
        arParms(31).Value = e.Hostel

        arParms(32) = New SqlParameter("@EnquiryNo", SqlDbType.NVarChar, 50)
        arParms(32).Value = e.EnquiryNo

        arParms(33) = New SqlParameter("@NicNo", SqlDbType.NVarChar, 50)
        arParms(33).Value = e.NicNo

        arParms(34) = New SqlParameter("@CategoryId", SqlDbType.NVarChar, 50)
        arParms(34).Value = e.CategoryId

        arParms(35) = New SqlParameter("@marks", SqlDbType.NVarChar, 50)
        arParms(35).Value = e.Marks

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateEnquiryDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long, ByVal Branchid As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = Id
        arParms(1) = New SqlParameter("@BranchId", SqlDbType.VarChar)
        arParms(1).Value = Branchid


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteEnquiryDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayGridValue(ByVal Fname As String, ByVal BranchCode As String, ByVal AdmitFlag As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Fname", SqlDbType.VarChar, 50)
        arParms(2).Value = Fname

        arParms(3) = New SqlParameter("@BranchCodeDDL", SqlDbType.VarChar, 50)
        arParms(3).Value = BranchCode

        arParms(4) = New SqlParameter("@AdmitFlag", SqlDbType.VarChar, 2)
        arParms(4).Value = AdmitFlag

        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FillEnquiryGrid", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function EnquiryEditData(ByVal id As Int64) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter() {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id
        'arParms(1) = New SqlParameter("@BranchId", SqlDbType.VarChar)
        'arParms(1).Value = Branchid


        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EnquiryEditData", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function SourceofInfo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")

        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLSourceofInfo", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function DelEnq(ByVal id As Int64, ByVal Branchid As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id
        arParms(1) = New SqlParameter("@BranchId", SqlDbType.VarChar)
        arParms(1).Value = Branchid


        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteEnq", arParms)
        Return rowsAffected
    End Function
    Shared Function GetEnqNo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FillEnqNo", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Details(ByVal enq As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@enq", SqlDbType.Int)
        arParms.Value = enq

        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDetailsByEnqNo", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetState(ByVal StateId As Long) As System.Data.DataSet
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If StateId = 0 Then
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, "Select StateId,StateName From State")
        Else
            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@StateId", SqlDbType.Int)
            arParms(0).Value = StateId

            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStateByID", arParms)
        End If
        Return ds
    End Function
    Shared Function GetState2(ByVal Country As String) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        'arParms(0) = New SqlParameter("@StateId", SqlDbType.Int)
        'arParms(0).Value = StateId
        arParms(0) = New SqlParameter("@country", SqlDbType.VarChar, 50)
        arParms(0).Value = Country

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStateByID1", arParms)

        Return ds.Tables(0)

    End Function
    Shared Function GetStateEmpMaster(ByVal countryId As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            arParms(0) = New SqlParameter("@countryId", SqlDbType.Int)
            arParms(0).Value = countryId
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetStateEmpmMaster", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetTitle() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_DDLTitle")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Getcaste() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim ds As DataSet

            Dim arParms() As SqlParameter = New SqlParameter(0) {}
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_DDLCaste")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetDistricEmpmMaster", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'coded by neha 23-feb-2012 to get the student name
    Shared Function getEnquiryExt(ByVal prefixText As String) As Data.DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try



            Dim arParms() As SqlParameter = New SqlParameter(2) {}


            arParms(0) = New SqlParameter("@FName", SqlDbType.VarChar, prefixText.Length)
            arParms(0).Value = prefixText




            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")



            arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetEquiryExt", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function getCountry() As Data.DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try

            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCountry", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function getDistrict(ByVal e As Enquiry) As Data.DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try

            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDistrict", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Shared Function GetCourse(ByVal Course_Id As Long) As System.Data.DataSet
    '    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    If Course_Id = 0 Then
    '        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, "Select Course_Id,CourseName From View_Course")
    '    Else
    '        Dim arParms() As SqlParameter = New SqlParameter(0) {}
    '        arParms(0) = New SqlParameter("@Course_Id", SqlDbType.Int)
    '        arParms(0).Value = Course_Id
    '        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetCourseByIdd", arParms)
    '    End If
    '    Return ds
    'End Function
    Shared Function getDistrict1(ByVal StateId As Integer) As Data.DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try

            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")
            arParms(2) = New SqlParameter("@state", SqlDbType.Int)
            arParms(2).Value = StateId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDistrict", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCriteriaValue(ByVal Criteria_Name As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        Dim ds As New DataSet
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Criteria_Name", SqlDbType.NVarChar, 50)
        arParms(1).Value = Criteria_Name

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetCriteriaValue", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ddlEnquiryRelatedTo(ByVal Batchid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlEnquiryRelatedTo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class

