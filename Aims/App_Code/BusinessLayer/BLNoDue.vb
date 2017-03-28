Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports GlobalDataSetTableAdapters

Public Class BLNoDue
    Dim DAL As New DLNoDue
    Public Function InsertRecord(ByVal ND As EntNoDue.EntNoDue) As Integer
        If ND.Remarks = Nothing Then
            ND.Remarks = ""
        End If
        Return DLNoDue.Insert(ND)
    End Function
    Public Function Update(ByVal ND As EntNoDue.EntNoDue) As Int64
        DAL.Update(ND)
    End Function
    Public Function GetData(ByVal batch As String, ByVal cource As Int64) As System.Data.DataTable
        Dim dt As New DataTable
        dt = DAL.GetNoDue(batch, cource)
        Return dt
    End Function
    Public Function delete(ByVal dueid As Integer)
        Dim rowsAffected As Integer
        rowsAffected = DAL.Delete(dueid)
        Return rowsAffected
    End Function
End Class
