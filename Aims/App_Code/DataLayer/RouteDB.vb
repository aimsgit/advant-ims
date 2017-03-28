Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class RouteDB
  
    Shared Function Insert(ByVal R As RouteMaster) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(12) {}

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@RouteNo", SqlDbType.Char, R.RouteNumber.Length)
        arParms(3).Value = R.RouteNumber


        arParms(4) = New SqlParameter("@RouteName", SqlDbType.Char, R.RouteName.Length)
        arParms(4).Value = R.RouteName

        arParms(5) = New SqlParameter("@Arrival_Time", SqlDbType.DateTime)
        arParms(5).Value = R.ArrivalTime

        arParms(6) = New SqlParameter("@Departure_Time", SqlDbType.DateTime)
        arParms(6).Value = R.DepartureTime

        arParms(7) = New SqlParameter("@VehicleIDAuto", SqlDbType.Int)
        arParms(7).Value = R.VehicleID

        arParms(8) = New SqlParameter("@DriverIDAuto", SqlDbType.Int, R.DriverID)
        arParms(8).Value = R.DriverID

        arParms(9) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(9).Value = R.Remarks

        arParms(10) = New SqlParameter("@PickUpPoint", SqlDbType.VarChar)
        arParms(10).Value = R.PickUpPoints

        arParms(11) = New SqlParameter("@RouteID", SqlDbType.Int)
        arParms(11).Value = R.RouteID

        arParms(12) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveRouteMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetAllDriverDetails() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")


        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDriverNameDDL", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function Update(ByVal R As RouteMaster) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@RouteNo", SqlDbType.Char, R.RouteNumber.Length)
        arParms(3).Value = R.RouteNumber


        arParms(4) = New SqlParameter("@RouteName", SqlDbType.Char, R.RouteName.Length)
        arParms(4).Value = R.RouteName

        arParms(5) = New SqlParameter("@Arrival_Time", SqlDbType.DateTime)
        arParms(5).Value = R.ArrivalTime

        arParms(6) = New SqlParameter("@Departure_Time", SqlDbType.DateTime)
        arParms(6).Value = R.DepartureTime

        arParms(7) = New SqlParameter("@VehicleIDAuto", SqlDbType.Int)
        arParms(7).Value = R.VehicleID

        arParms(8) = New SqlParameter("@DriverIDAuto", SqlDbType.Int, R.DriverID)
        arParms(8).Value = R.DriverID

        arParms(9) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(9).Value = R.Remarks

        arParms(10) = New SqlParameter("@PickUpPoint", SqlDbType.VarChar)
        arParms(10).Value = R.PickUpPoints

        arParms(11) = New SqlParameter("@RouteID", SqlDbType.Int)
        arParms(11).Value = R.RouteID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateRouteMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@RouteID", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteRouteMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

   
    Shared Function GetRouteDetails(ByVal RouteMaster As RouteMaster) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@RouteID", SqlDbType.Int)
        arParms(2).Value = RouteMaster.RouteID

        arParms(3) = New SqlParameter("@RouteNo", SqlDbType.VarChar, 50)
        arParms(3).Value = RouteMaster.RouteNumber

        arParms(4) = New SqlParameter("@VehicleNo", SqlDbType.VarChar, 50)
        arParms(4).Value = RouteMaster.VehicleID

        arParms(5) = New SqlParameter("@DriverName", SqlDbType.VarChar, 50)
        arParms(5).Value = RouteMaster.DriverID

        arParms(6) = New SqlParameter("@PickupPoints", SqlDbType.VarChar, 50)
        arParms(6).Value = RouteMaster.PickUpPoints

        Dim ds As New DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetRouteMasterDetails", arParms)
        Return ds.Tables(0)
    End Function
    ' Shared Function GetVehicleDetails(ByVal Inst As String, ByVal Brch As String) As Data.DataTable
    Shared Function GetVehicleDetails() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")


        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetVehicleNameDDL", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetRouteRpt() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")


        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_RouteMasterDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function CheckDuplicate(ByVal s As RouteMaster) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = s.RouteID

        para(1) = New SqlParameter("@VehicleIDAuto", SqlDbType.Int)
        para(1).Value = s.VehicleID

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")

        para(3) = New SqlParameter("@RouteNumber", SqlDbType.VarChar, 50)
        para(3).Value = s.RouteNumber

        para(4) = New SqlParameter("@deparature", SqlDbType.DateTime)
        para(4).Value = s.DepartureTime
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateRouteMaster", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
End Class
