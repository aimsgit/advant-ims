Imports Microsoft.VisualBasic
Imports System

Public Class ZoneB
    Public Function FillHO() As DataSet
        Dim ds As DataSet
        If HttpContext.Current.Session("Admin") = 1 Then
            ds = ZoneDB.FillHo(0)
        Else
            ds = ZoneDB.FillHo(HttpContext.Current.Session("sesHOID"))
        End If
        Return ds
    End Function
    Public Function Insert(ByVal id As Int64, ByVal name As String) As Int16
        Return ZoneDB.Insert(id, name)
    End Function
    Public Function getZoneDetails(ByVal id As Int64) As DataSet
        Return ZoneDB.GetZoneDetails(id)
    End Function
    Public Function Update(ByVal id As Int64, ByVal name As String) As Int16
        Return ZoneDB.Update(id, name)
    End Function
    Public Function Delete(ByVal Id As Int64) As Int16
        Return ZoneDB.Delete(Id)
    End Function
End Class
