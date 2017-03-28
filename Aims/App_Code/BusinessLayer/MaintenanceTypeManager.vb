Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class MaintenanceTypeManager

    Dim MaintenanceTypeDB As New MaintenanceTypeDB
    Public Function GetMaintenanceType1(ByVal ins As String, ByVal bran As String) As Data.DataSet
        Dim dt As DataSet = MaintenanceTypeDB.GetMaintenanceType1(ins, bran)
        Return dt
    End Function
    Public Function GetMaintenanceType(ByVal id As MaintenanceType) As Data.DataTable
        Return MaintenanceTypeDB.GetMaintenanceType(id)
    End Function
    'Public Function GetMaintenanceType(ByVal id As MaintenanceTypeDB ) As
    '    'Dim maintenancetype As New List(Of MaintenanceType)
    '    'Dim ds As DataSet = MaintenanceTypeDB.GetMaintenanceType(s)
    '    'Dim row As DataRow
    '    'For Each row In ds.Tables(0).Rows
    '    '    maintenancetype.Add(New MaintenanceType(row("M_ID"), row("MaintenanceType"), row("Remarks")))
    '    'Next
    '    'Return maintenancetype
    'End Function

    'Public Function GetMaintenanceType(ByVal ins As String, ByVal bran As String) As Data.DataSet
    '    Dim dt As DataSet = MaintenanceTypeDB.GetMaintenanceType(ins, bran)
    '    Return dt
    'End Function
    'Public Function GetMaintenanceType() As List(Of MaintenanceType)
    '    'Dim maintenancetype As New List(Of MaintenanceType)
    '    'Dim ds As DataSet = MaintenanceTypeDB.GetMaintenanceType(0)
    '    'Dim row As DataRow
    '    'For Each row In ds.Tables(0).Rows
    '    '    maintenancetype.Add(New MaintenanceType(row("M_ID"), row("MaintenanceType"), row("Remarks")))
    '    'Next
    '    'Return maintenancetype
    'End Function
    Public Function GetDuplicateMaintananceType(ByVal m As MaintenanceType) As DataTable

        Return MaintenanceTypeDB.GetDuplicateMaintananceType(m)
    End Function
    Public Function InsertRecord(ByVal m As MaintenanceType) As Integer
        If m.Remarks = Nothing Then
            m.Remarks = ""
        End If
        Return MaintenanceTypeDB.Insert(m)
    End Function
    'Public Function GetDuplicateMaintananceType(ByVal m As MaintenanceType) As Integer
    '    If m.Remarks = Nothing Then
    '        m.Remarks = ""
    '    End If
    '    Return MaintenanceTypeDB.GetDuplicateMaintananceType(m)
    'End Function
    Public Function UpdateRecord(ByVal m As MaintenanceType) As Integer
        If m.Remarks = Nothing Then
            m.Remarks = ""
        End If
        Return MaintenanceTypeDB.Update(m)
    End Function
    Public Function ChangeFlag(ByVal m As MaintenanceType) As Integer
        Return MaintenanceTypeDB.ChangeFlag(m.Id)
    End Function
    Public Function GetMaintenanceTypeCombo() As Data.DataTable
        Return MaintenanceTypeDB.GetMaintenanceTypeCombo().Tables(0)
    End Function
End Class
