Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class MachineMaintenenceBL
    'Dim DAL As New MachineMaintenanceDB
    Public Function GetMachineMaintenence() As List(Of MachineMaintenence)
        Dim MachineMaintenence As New List(Of MachineMaintenence)
        Dim ds As DataSet = MachineMaintenanceDB.GetMachineMaintenence(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            MachineMaintenence.Add(New MachineMaintenence(row("Maintain_ID"), row("Entry_Date"), row("Machine_Make"), row("Machine_Model"), row("Machine_No"), row("MachineType"), row("MaintenanceType"), row("Cleaned_Date"), row("Due_Date"), row("Time_Stopped"), row("Part_Changed"), row("Time_Run"), row("Operation"), row("Operator_Name"), row("Needle"), row("Parts"), row("Remarks"), row("Course_ID"), row("Batch_No"), row("Institute_ID"), row("Branch_ID")))
        Next
        Return MachineMaintenence
    End Function
    Public Function GetMachineMaintenence(ByVal maintainid As Long) As List(Of MachineMaintenence)
        Dim MachineMaintenence As New List(Of MachineMaintenence)
        Dim ds As DataSet = MachineMaintenanceDB.GetMachineMaintenence(maintainid)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            MachineMaintenence.Add(New MachineMaintenence(row("Maintain_ID"), row("Entry_Date"), row("Machine_Make"), row("Machine_Model"), row("Machine_No"), row("MachineType"), row("MaintenanceType"), row("Cleaned_Date"), row("Due_Date"), row("Time_Stopped"), row("Part_Changed"), row("Time_Run"), row("Operation"), row("Operator_Name"), row("Needle"), row("Parts"), row("Remarks"), row("Course_ID"), row("Batch_No"), row("Institute_ID"), row("Branch_ID")))
        Next
        Return MachineMaintenence
    End Function
    Public Function GetMachineMaintenenceById(ByVal maintainid As Long) As MachineMaintenence
        Dim MachineMaintenence As MachineMaintenence
        Dim ds As DataSet = MachineMaintenanceDB.GetMachineMaintenence(maintainid)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        MachineMaintenence = New MachineMaintenence(row("Maintain_ID"), row("Entry_Date"), row("Machine_Make"), row("Machine_Model"), row("Machine_No"), row("MachineType"), row("MaintenanceType"), row("Cleaned_Date"), row("Due_Date"), row("Time_Stopped"), row("Part_Changed"), row("Time_Run"), row("Operation"), row("Operator_Name"), row("Needle"), row("Parts"), row("Remarks"), row("Course_ID"), row("Batch_No"), row("Institute_ID"), row("Branch_ID"))
        Return MachineMaintenence
    End Function
    Public Function Insert(ByVal mm As MachineMaintenence) As Integer
        If mm.BatchNo = Nothing Then
            mm.BatchNo = ""
        ElseIf mm.Operation = Nothing Then
            mm.Operation = ""
        ElseIf mm.OperationName = Nothing Then
            mm.OperationName = ""
        ElseIf mm.PartChanged = Nothing Then
            mm.PartChanged = ""
        ElseIf mm.Parts = Nothing Then
            mm.Parts = ""
        ElseIf mm.Remarks = Nothing Then
            mm.Remarks = ""
        ElseIf mm.TimeRun = Nothing Then
            mm.TimeRun = ""
        ElseIf mm.TimeStopped = Nothing Then
            mm.TimeStopped = ""
        ElseIf mm.Needle = Nothing Then
            mm.Needle = ""
        ElseIf mm.CourseId = Nothing Then
            mm.CourseId = ""
        End If
        Return MachineMaintenanceDB.Insert(mm)
    End Function
    Public Function ChangeFlag(ByVal maintainid As Long) As Integer
        Return MachineMaintenanceDB.ChangeFlag(maintainid)
    End Function
    Public Function GetMachinMaintenenceByIBMf(ByVal mfr As Int64) As Data.DataTable
        Return MachineMaintenanceDB.GetMachinMaintenenceByIBMf(mfr)
    End Function
    Public Function GetMachinMaintnceByIBMfMt(ByVal mct As Int64, ByVal mfr As Int64) As Data.DataTable
        Return MachineMaintenanceDB.GetMachinMaintnceByIBMfMt(mct, mfr)
    End Function
    Public Function GetMaintnceManufByIB() As Data.DataTable
        Return MachineMaintenanceDB.GetMaintnceManufByIB()
    End Function
    Public Function MachineMaintenenceGridFill(ByVal mnt As Int64, ByVal id As Integer) As Data.DataTable
        Return MachineMaintenanceDB.MachineMaintenenceGridFill(mnt, id)
    End Function
    'Public Function GetMachineMaintenence(ByVal Prop As Long) As Data.DataSet
    '    Return DAL.GetMachineMaintenence(Prop)
    'End Function
    'Public Function Insert(ByVal Prop As MachineMaintenence)
    '    Return DAL.Insert(Prop)
    'End Function
    'Public Function ChangeFlag(ByVal maintainid As Long)
    '    Return DAL.ChangeFlag(maintainid)
    'End Function
End Class
