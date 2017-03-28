Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class RouteManager
    Public Function GetRouteRpt() As Data.DataTable
        Dim dt As DataTable = RouteDB.GetRouteRpt()
        Return dt
    End Function
    Public Function GetRouteDetails(ByVal RouteMaster As RouteMaster) As Data.DataTable
        Dim dt As DataTable = RouteDB.GetRouteDetails(RouteMaster)
        Return dt
    End Function
    Public Function InsertRecord(ByVal R As RouteMaster) As Integer
        If R.Remarks = Nothing Then
            R.Remarks = ""
        End If
        Return RouteDB.Insert(R)
    End Function
    Public Function UpdateRecord(ByVal R As RouteMaster) As Integer
        If R.Remarks = Nothing Then
            R.Remarks = ""
        End If
        Return RouteDB.Update(R)
    End Function
    '  Public Function GetVehicleDetails(ByVal Inst As String, ByVal Brch As String) As Data.DataTable
    Public Function GetVehicleDetails() As Data.DataTable
        Dim dt As DataTable = RouteDB.GetVehicleDetails()
        Return dt
    End Function
    Public Function ChangeFlag(ByVal Id As Long) As Integer
        Return RouteDB.ChangeFlag(Id)
    End Function
    Public Function GetDriverDetail_Report() As Data.DataTable
        Return RouteDB.GetAllDriverDetails()
    End Function
    Public Function CheckDuplicate(ByVal s As RouteMaster) As System.Data.DataTable
        Return RouteDB.CheckDuplicate(s)
    End Function
End Class
