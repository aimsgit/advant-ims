Imports Microsoft.VisualBasic

Public Class DriverDetB
    Public Function InsertRecord(ByVal d As DriverDet) As Integer
        Return DriverDetDB.InsertDriverDet(d)
    End Function
    Public Function DispDriverDetails(ByVal driverid As DriverDet) As Data.DataTable
        Return DriverDetDB.GetDriverDetails(driverid)
    End Function
    Public Function UpdateDriverDetails(ByVal d As DriverDet) As Integer
        Return DriverDetDB.UpdateDriverDB(d)
    End Function
    Public Function DelDriverDetails(ByVal driverid As DriverDet) As Integer
        Return DriverDetDB.DeleteDriverDetails(driverid)
    End Function
    Public Function GetDriverDetail_Report(ByVal inst As Integer, ByVal branch As Integer) As Data.DataTable
        Return DriverDetDB.GetAllDriverDetails(inst, branch)
    End Function
    Public Function GetDuplicateDriverDetails(ByVal EL As DriverDet) As DataTable
        Dim db As New DriverDetDB
        Return db.GetDuplicateDriverDetails(EL)
    End Function
End Class
