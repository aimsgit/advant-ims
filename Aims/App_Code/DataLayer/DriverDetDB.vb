Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DriverDetDB
    Shared Function InsertDriverDet(ByVal d As DriverDet) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(14) {}

        arParms(0) = New SqlParameter("@DriverName", SqlDbType.NVarChar)
        arParms(0).Value = d.DriverName

        arParms(1) = New SqlParameter("@Address", SqlDbType.NVarChar, 250)
        arParms(1).Value = d.Address

        arParms(2) = New SqlParameter("@ContactNo", SqlDbType.NVarChar)
        arParms(2).Value = d.ContactNo

        arParms(3) = New SqlParameter("@DOB", SqlDbType.DateTime)
        arParms(3).Value = d.DOB

        arParms(4) = New SqlParameter("@DOJ", SqlDbType.DateTime)
        arParms(4).Value = d.DOJ

        arParms(5) = New SqlParameter("@DLNo", SqlDbType.NVarChar)
        arParms(5).Value = d.DLNO

        arParms(6) = New SqlParameter("@BloodGroup", SqlDbType.NVarChar)
        arParms(6).Value = d.BloodGroup

        arParms(7) = New SqlParameter("@DLExpiry", SqlDbType.DateTime)
        arParms(7).Value = d.DLExpiry

        arParms(8) = New SqlParameter("@RTOName", SqlDbType.VarChar, 50)
        arParms(8).Value = d.RTOName

        arParms(9) = New SqlParameter("@City", SqlDbType.VarChar, 50)
        arParms(9).Value = d.City

        arParms(10) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(10).Value = d.State

        arParms(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("BranchCode")

        arParms(12) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("empCode")

        arParms(13) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("UserCode")

        arParms(14) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveDriverDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Shared Function GetDriverDetails(ByVal driverid As DriverDet) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@DriverId", SqlDbType.Int)
        arParms(2).Value = driverid.driverid


        arParms(3) = New SqlParameter("@DriverName", SqlDbType.VarChar, 50)
        arParms(3).Value = driverid.DriverName

        arParms(4) = New SqlParameter("@LicenseNo", SqlDbType.VarChar, 50)
        arParms(4).Value = driverid.DLNO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDriverDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetAllDriverDetails(ByVal inst As Integer, ByVal branch As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@inst", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("")

        arParms(1) = New SqlParameter("@branch", SqlDbType.Int)
        arParms(1).Value = branch

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAllDriverDetails", arParms)
        Return ds.Tables(0)
    End Function


    Shared Function UpdateDriverDB(ByVal d As DriverDet) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(14) {}

        arParms(0) = New SqlParameter("@DriverName", SqlDbType.NVarChar)
        arParms(0).Value = d.DriverName

        arParms(1) = New SqlParameter("@Address", SqlDbType.NVarChar, 250)
        arParms(1).Value = d.Address

        arParms(2) = New SqlParameter("@ContactNo", SqlDbType.NVarChar)
        arParms(2).Value = d.ContactNo

        arParms(3) = New SqlParameter("@DOB", SqlDbType.DateTime)
        arParms(3).Value = d.DOB

        arParms(4) = New SqlParameter("@DOJ", SqlDbType.DateTime)
        arParms(4).Value = d.DOJ

        arParms(5) = New SqlParameter("@DLNo", SqlDbType.NVarChar)
        arParms(5).Value = d.DLNO

        arParms(6) = New SqlParameter("@BloodGroup", SqlDbType.NVarChar)
        arParms(6).Value = d.BloodGroup

        arParms(7) = New SqlParameter("@DLExpiry", SqlDbType.DateTime)
        arParms(7).Value = d.DLExpiry

        arParms(8) = New SqlParameter("@RTOName", SqlDbType.VarChar, 50)
        arParms(8).Value = d.RTOName

        arParms(9) = New SqlParameter("@City", SqlDbType.VarChar, 50)
        arParms(9).Value = d.City

        arParms(10) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(10).Value = d.State

        arParms(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("BranchCode")

        arParms(12) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("empCode")

        arParms(13) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("UserCode")

        arParms(14) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(14).Value = d.driverid


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateDriverDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function
    Shared Function DeleteDriverDetails(ByVal driverid As DriverDet) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}

        param(0) = New SqlParameter("@DriverId", SqlDbType.Int)
        param(0).Value = driverid.driverid

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        Dim ds As Integer
        ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteDriverDetails", param)
        Return ds
    End Function
    Public Function GetDuplicateDriverDetails(ByVal EL As DriverDet) As DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}


        para(0) = New SqlParameter("@DLNo", SqlDbType.VarChar, 50)
        para(0).Value = EL.DLNO
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@id", SqlDbType.Int)
        para(3).Value = EL.driverid

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateDriverDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Method to get Driver details by Nitin 11/05/2012
    Shared Function GetAllDriverDetailsRpt() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "RptDriverDetails", arParms)
        Return ds.Tables(0)
    End Function
End Class
