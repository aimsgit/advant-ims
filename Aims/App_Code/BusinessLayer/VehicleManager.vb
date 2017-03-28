Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data



Public Class VehicleManager
    Dim VDB As  New VehicleDB

    'Public Function GetVehicleDetailsRpt(ByVal Inst As Int64, ByVal Brch As Int64, ByVal rb As Integer) As Data.DataTable
    '    Dim dt As DataTable = VehicleDB.GetVehicleDetailsReport(Inst, Brch, rb)
    '    Return dt
    'End Function
    'Public Function GetVehicleDetails(ByVal Inst As Int64, ByVal Brch As Int64, ByVal vehicleid As Integer, ByVal RB As Integer) As Data.DataTable
    '    Dim dt As DataTable = VehicleDB.GetVehicleDetails(Inst, Brch, vehicleid, RB)
    '    Return dt
    'End Function
    'commented by abhishek garg
    'Public Function GetOwnVehicleDetails(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
    '    Dim dt As DataTable = VehicleDB.GetOwnVehicleDetails(Inst, Brch)
    '    Return dt
    'End Function
    'Public Function GetContractVehicleDetails(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
    '    Dim dt As DataTable = VehicleDB.GetContractVehicleDetails(Inst, Brch)
    '    Return dt
    'End Function
    '---------------------

    'Public Function GetVehicle() As List(Of VehicleDetails)
    '    Dim vehicle As New List(Of VehicleDetails)
    '    Dim ds As DataSet = VehicleDB.GetVehicle
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        vehicle.Add(New VehicleDetails(row("VehicleID"), row("Institute"), row("Branch"), row("VehicleRegistrationnNo"), row("YearRegistrationnNo "), row("VehicleType"), row("VehicleMake"), row("MakeYear"), row("Model"), row("EngineNumber"), row("Price"), row("NoOfSeats"), row("FuelType"), row("InsuranceExpiry"), row("RenewalOfPermit"), row("OwnerShipStatus"), row("ContractorName"), row("ContactNo"), row("Address"), row("StartDate"), row("EndDate")))
    '    Next
    '    Return vehicle
    'End Function

    Public Function GetVehicle(ByVal v As VehicleDetails) As Data.DataTable
        Return VehicleDB.GetVehicle(v)
    End Function
    Public Function InsertRecord(ByVal v As VehicleDetails) As Integer
        If v.NoOfSeats = Nothing Then
            v.NoOfSeats = 0
        End If
        If v.Price = Nothing Then
            v.Price = 0.0
        End If

        If v.FuelType = Nothing Then
            v.FuelType = ""
        End If

        If v.Address = Nothing Then
            v.Address = ""
        End If
        Return VehicleDB.Insert(v)
    End Function
    Public Function UpdateRecord(ByVal v As VehicleDetails) As Integer
        Return VehicleDB.Update(v)
    End Function
    Public Function ChangeFlag(ByVal v As VehicleDetails) As Integer
        Return VehicleDB.ChangeFlag(v)
    End Function

    Public Function DuplicateEntry(ByVal v As VehicleDetails) As DataTable

        Return VDB.VehicleDuplicateEntry(v)
    End Function

End Class
