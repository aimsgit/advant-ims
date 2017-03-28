Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class VehicleMaintenanceB
    Public Function GetVehicleMaintainRpt(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
        Dim dt As DataTable = VehicleMaintenanceDB.GetVehicleMaintainRpt(Inst, Brch)
        Return dt
    End Function

    Public Function InsertRecord(ByVal v As VehicleMaintenanceEn) As Integer
        Return VehicleMaintenanceDB.Insert(v)
    End Function
    Public Function vechileduplicate(ByVal v As VehicleMaintenanceEn) As Data.DataTable
        Return VehicleMaintenanceDB.vechileduplicate(v)
    End Function

    Public Function UpdateVehicleDet(ByVal v As VehicleMaintenanceEn) As Integer
        Return VehicleMaintenanceDB.Update(v)
    End Function

    Public Function UpdateVehicleDet1(ByVal v As VehicleMaintenanceEn) As Integer
        Return VehicleMaintenanceDB.Update1(v)
    End Function

    Public Function DispGrid(ByVal v As VehicleMaintenanceEn) As Data.DataTable
        Return VehicleMaintenanceDB.DispVehicleDB(v)
    End Function

    Public Function DispFullGrid(ByVal Inst As Integer, ByVal Branch As Integer) As Data.DataTable
        Return VehicleMaintenanceDB.DispAllVehicleDB(Inst, Branch)
    End Function

    Public Function DelVehicleMaintenance(ByVal v As VehicleMaintenanceEn) As Integer
        Return VehicleMaintenanceDB.DeleteVehicleDB(v)
    End Function

End Class
