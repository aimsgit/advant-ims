Imports Microsoft.VisualBasic

Public Class BLHouseMaster
    Dim DAL As New DLHouseMaster
    Public Function Insert(ByVal s As HouseMaster) As Int16
        Return DAL.Insert(s)
    End Function
    Public Function CheckDuplicate(ByVal s As HouseMaster) As System.Data.DataTable
        Return DAL.CheckDuplicate(s)
    End Function
    Public Function Update(ByVal S As HouseMaster) As Integer
        Return DAL.Update(S)
    End Function
    Public Function getGVHouseMaster(ByVal id As HouseMaster) As Data.DataTable
        Return DAL.getGVHouseMaster(id)
    End Function
    Public Function DeleteGVHouseMaster(ByVal s As HouseMaster) As Integer
        Dim rowsaffected As Integer = DAL.DeleteGVHouseMaster(s)
    End Function
    'Code for get Company Master Report By Nitin 08/05/2012
    Public Function RptHouseMaster(ByVal insID As Int64, ByVal brnID As Int64) As Data.DataTable
        Return DLHouseMaster.RptHouseMaster(insID, brnID)
    End Function
End Class
