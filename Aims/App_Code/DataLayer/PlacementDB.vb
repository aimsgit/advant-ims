Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class PlacementDB
    Shared Function GetDetails(ByVal placementid As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        If placementid = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getPlacementDetails")
        Else
            Dim arParms As SqlParameter = New SqlParameter
            arParms = New SqlParameter("@institute", SqlDbType.Int)
            arParms.Value = placementid
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getPlacementDetailsByPlacementID", arParms)
        End If
        Return ds
    End Function
    Shared Function Insert(ByVal p As PlacementDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(12) {}

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        arParms(2) = New SqlParameter("@STD_ID ", SqlDbType.Int)
        arParms(2).Value = p.studCode

        'arParms(3) = New SqlParameter("@code", SqlDbType.Int)
        'arParms(3).Value = p.studCode

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")


        arParms(4) = New SqlParameter("@Date_Of_Placement", SqlDbType.DateTime)
        arParms(4).Value = p.PlacementDate

        arParms(5) = New SqlParameter("@End_Date", SqlDbType.DateTime)
        arParms(5).Value = p.EndDate

        arParms(6) = New SqlParameter("@Training_Placement", SqlDbType.VarChar, 50)
        arParms(6).Value = p.trainingplacement

        arParms(7) = New SqlParameter("@Salary", SqlDbType.Money)
        arParms(7).Value = p.Salary

        arParms(8) = New SqlParameter("@Designation", SqlDbType.VarChar, 50)
        arParms(8).Value = p.Designation

        arParms(9) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(9).Value = p.Remark
   
        arParms(10) = New SqlParameter("@Faculty_Incharge", SqlDbType.VarChar, 50)
        arParms(10).Value = p.Faculty_Incharge

        arParms(11) = New SqlParameter("@Contact_Person", SqlDbType.VarChar, 50)
        arParms(11).Value = p.Contact_Person

        arParms(12) = New SqlParameter("@PCId_Auto", SqlDbType.Int)
        arParms(12).Value = p.CompName


        
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_savePlacementDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal p As PlacementDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        arParms(0) = New SqlParameter("@Placement_ID", SqlDbType.Int)
        arParms(0).Value = p.PlacementId

        arParms(1) = New SqlParameter("@Training_Placement", SqlDbType.VarChar, 50)
        arParms(1).Value = p.trainingplacement

        arParms(2) = New SqlParameter("@STD_ID ", SqlDbType.Int)
        arParms(2).Value = p.studid

        arParms(3) = New SqlParameter("@Date_Of_Placement", SqlDbType.DateTime)
        arParms(3).Value = p.PlacementDate

        'arParms(4) = New SqlParameter("@code", SqlDbType.Int)
        'arParms(4).Value = p.studCode

        arParms(4) = New SqlParameter("@PCId_Auto", SqlDbType.Int)
        arParms(4).Value = p.CompName

        'arParms(5) = New SqlParameter("@Date_Of_Placement", SqlDbType.DateTime)
        'arParms(5).Value = p.PlacementDate

        arParms(5) = New SqlParameter("@End_Date", SqlDbType.DateTime)
        arParms(5).Value = p.EndDate

        arParms(6) = New SqlParameter("@Salary", SqlDbType.Money)
        arParms(6).Value = p.Salary

        arParms(7) = New SqlParameter("@Designation", SqlDbType.VarChar, 50)
        arParms(7).Value = p.Designation

        arParms(8) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(8).Value = p.Remark

        arParms(9) = New SqlParameter("@Faculty_Incharge", SqlDbType.VarChar, 50)
        arParms(9).Value = p.Faculty_Incharge

        arParms(10) = New SqlParameter("@Contact_Person", SqlDbType.VarChar, 50)
        arParms(10).Value = p.Contact_Person

        arParms(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("UserCode")

        arParms(12) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("BranchCode")
        arParms(13) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("EmpCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_updatePlacementDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Try
            Dim arParms As SqlParameter = New SqlParameter
            arParms = New SqlParameter("@Placement_ID", SqlDbType.Int)
            arParms.Value = Id
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_ChangeFlagPlacementDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function GetPlacementdetailsbyradio(ByVal ELL As PlacementDetails) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            'arParms(0) = New SqlParameter("@institute", SqlDbType.Int)
            'arParms(0).Value = p.Institute

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")


            arParms(2) = New SqlParameter("@Placement_ID", SqlDbType.Int)
            arParms(2).Value = ELL.PlacementId
            arParms(3) = New SqlParameter("@Training_Placement", SqlDbType.VarChar, 50)
            arParms(3).Value = ELL.trainingplacement

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetPlacementdetailsbyradio", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetStdnameByCode(ByVal code As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim arParms As SqlParameter = New SqlParameter
            arParms = New SqlParameter("@code", SqlDbType.Int)
            arParms.Value = code
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ChangeFlagPlacementDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Public Function GetCourse(ByVal el As PlacementDetails) As DataTable
    '    Dim ds As New DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Try
    '        Dim arParms() As SqlParameter = New SqlParameter(1) {}

    '        arParms(0) = New SqlParameter("@ddlinstitute", SqlDbType.Int)
    '        arParms(0).Value = el.Institute

    '        arParms(1) = New SqlParameter("@ddlbranch", SqlDbType.Int)
    '        arParms(1).Value = el.Branch

    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getCourse", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    Public Function GetBatch(ByVal el As PlacementDetails) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@institute_ID", SqlDbType.Int)
            arParms(0).Value = el.Institute

            arParms(1) = New SqlParameter("@branch", SqlDbType.Int)
            arParms(1).Value = el.Branch

            'arParms(2) = New SqlParameter("@course_ID", SqlDbType.Int)
            'arParms(2).Value = el.Course

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBatchData", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetInstitute() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getInstituteList")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetBranch(ByVal id As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms.Value = id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getBranchName", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Sub New()

    End Sub
    'Shared Function GetReport(ByVal inst As Int64, ByVal brn As Int64, ByVal crs As Int64, ByVal btch As Int64, ByVal tp As Int64) As Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

    '    Dim arParms() As SqlParameter = New SqlParameter(4) {}
    '    arParms(0) = New SqlParameter("@Ins", SqlDbType.Int, 50)
    '    arParms(0).Value = inst

    '    arParms(1) = New SqlParameter("@Brn", SqlDbType.Int, 50)
    '    arParms(1).Value = brn

    '    arParms(2) = New SqlParameter("@Crs", SqlDbType.Int, 50)
    '    arParms(2).Value = crs

    '    arParms(3) = New SqlParameter("@btch", SqlDbType.Int, 50)
    '    arParms(3).Value = btch

    '    arParms(4) = New SqlParameter("@tp", SqlDbType.Int, 50)
    '    arParms(4).Value = tp
    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptPlacement", arParms)
    '    Return ds.Tables(0)
    'End Function
    Shared Function GetcompanyTypescombo() As Data.DataTable
        'Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim ds As New DataSet

        'Dim Para() As SqlParameter = New SqlParameter(1) {}
        'Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'Para(0).Value = HttpContext.Current.Session("Office")
        'Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'Para(1).Value = HttpContext.Current.Session("BranchCode")
        'Try
        '    ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetCompanyNameDDL", Para)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        'Return ds.Tables(0)
    End Function
    Shared Function GetDtaCourse() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCourse", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function
    'Shared Function GetAcademicCombo() As DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Try
    '        Dim Parms() As SqlParameter = New SqlParameter(1) {}

    '        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '        Parms(0).Value = HttpContext.Current.Session("BranchCode")

    '        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '        Parms(1).Value = HttpContext.Current.Session("Office")
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectAcademicYear", Parms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    Shared Function GetcompanyCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCompanyNameDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function CheckDuplicate(ByVal s As PlacementDetails) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(3) {}
        Para(0) = New SqlParameter("@PCId_Auto", SqlDbType.Int)
        Para(0).Value = s.CompName
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@STD_ID", SqlDbType.Int)
        Para(2).Value = s.studCode
        Para(3) = New SqlParameter("@Training_Placement", SqlDbType.VarChar, 50)
        Para(3).Value = s.trainingplacement

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetDuplicatePlacementDetails", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RptPlacementDetails(ByVal Batch As Integer, ByVal Type As Integer) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@Batch", SqlDbType.Int)
        Para(2).Value = Batch
      
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "New_RptPlacementDetails", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function RptTrainingDetails(ByVal Batch As Integer, ByVal Type As Integer) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@Batch", SqlDbType.Int)
        Para(2).Value = Batch
      

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "New_RptTrainingDetails", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
