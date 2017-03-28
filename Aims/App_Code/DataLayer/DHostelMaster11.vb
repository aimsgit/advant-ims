Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DHostelMaster11
    Shared Function GetHostelMaster(ByVal el As EHostelMaster11) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = el.Id
        arParms(3) = New SqlParameter("@HostelName", SqlDbType.VarChar, 50)
        arParms(3).Value = el.HostelName
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_GetHostelMaster", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function Insert(ByVal el As EHostelMaster11) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        'arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(3) = New SqlParameter("@Hostel_Code", SqlDbType.VarChar, 50)
        arParms(3).Value = el.HostelCode
        arParms(4) = New SqlParameter("@Hostel_Name", SqlDbType.VarChar, 50)
        arParms(4).Value = el.HostelName
        arParms(5) = New SqlParameter("@Hostel_Type", SqlDbType.VarChar, 50)
        arParms(5).Value = el.HostelType
        arParms(6) = New SqlParameter("@Hostel_Warden", SqlDbType.VarChar, 50)
        arParms(6).Value = el.Warden
        arParms(7) = New SqlParameter("@HouseKeeping", SqlDbType.VarChar, 50)
        arParms(7).Value = el.HouseKeeping
        arParms(8) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(8).Value = el.Remarks
        arParms(9) = New SqlParameter("@Hostel_Address", SqlDbType.VarChar, 250)
        arParms(9).Value = el.HostelAddress
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Hostel_InsertHostelMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    'Public Function CheckDuplicate(ByVal el As EHolidayMaster) As Data.DataTable
    '    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(2) {}
    '    'Dim para() As SqlParameter = New SqlParameter(1) {}
    '    arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    arParms(0).Value = HttpContext.Current.Session("BranchCode")
    '    arParms(1) = New SqlParameter("@HolidayDate", SqlDbType.DateTime)
    '    arParms(1).Value = el.Date1
    '    arParms(2) = New SqlParameter("@id", SqlDbType.Int)
    '    arParms(2).Value = el.Id
    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateHolidayMaster", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)

    'End Function


    Shared Function Update(ByVal el As EHostelMaster11) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        'arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(3) = New SqlParameter("@Hostel_ID", SqlDbType.Int)
        arParms(3).Value = el.Id
        arParms(4) = New SqlParameter("@Hostel_Code", SqlDbType.VarChar, 50)
        arParms(4).Value = el.HostelCode
        arParms(5) = New SqlParameter("@Hostel_Name", SqlDbType.VarChar, 50)
        arParms(5).Value = el.HostelName
        arParms(6) = New SqlParameter("@Hostel_Type", SqlDbType.VarChar, 50)
        arParms(6).Value = el.HostelType
        arParms(7) = New SqlParameter("@Hostel_Warden", SqlDbType.VarChar, 50)
        arParms(7).Value = el.Warden
        arParms(8) = New SqlParameter("@HouseKeeping", SqlDbType.VarChar, 50)
        arParms(8).Value = el.HouseKeeping
        arParms(9) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(9).Value = el.Remarks
        arParms(10) = New SqlParameter("@Hostel_Address", SqlDbType.VarChar, 250)
        arParms(10).Value = el.HostelAddress

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Hostel_UpDateHostelMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Hostel_ID", SqlDbType.Int)
        arParms(0).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Hostel_DeleteHostelMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function


    Public Function CheckDuplicate(ByVal EL As EHostelMaster11) As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@HostelCode", SqlDbType.VarChar, 50)
        para(1).Value = EL.HostelCode
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.Id
       
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "H_DuplicateHostelMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
