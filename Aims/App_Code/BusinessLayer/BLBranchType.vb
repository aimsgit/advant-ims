Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BLBranchType
    Public Function GetBranchType() As List(Of BranchType)
        Dim BranchType As New List(Of BranchType)
        Dim ds As DataSet = DLBranchType.GetBranchType(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            BranchType.Add(New BranchType(row("BranchType_ID"), row("BranchTypeName")))
        Next
        Return BranchType
    End Function
    Public Function GetBranchType(ByVal id As Long) As List(Of BranchType)
        Dim BranchType As New List(Of BranchType)
        Dim ds As DataSet = DLBranchType.GetBranchType(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            BranchType.Add(New BranchType(row("BranchType_ID"), row("BranchTypeName")))
        Next
        Return BranchType
    End Function
    Public Function GetBranchTypeByTypeId(ByVal id As Long) As BranchType
        Dim BranchType As BranchType
        Dim ds As DataSet = DLBranchType.GetBranchType(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        BranchType = New BranchType(row("BranchType_ID"), row("BranchTypeName"))
        Return BranchType
    End Function
    Public Function InsertRecord(ByVal i As BranchType) As Integer
        'If i.City = Nothing Then
        '    i.City = ""
        'End If
        'If i.State = Nothing Then
        '    i.State = ""
        'End If
        'If i.Country = Nothing Then
        '    i.Country = ""
        'End If
        Return DLBranchType.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As BranchType) As Integer
        'If i.City = Nothing Then
        '    i.City = ""
        'End If
        'If i.State = Nothing Then
        '    i.State = ""
        'End If
        'If i.Country = Nothing Then
        '    i.Country = ""
        'End If
        Return DLBranchType.Update(i)
    End Function
    'Public Function ChangeFlag(ByVal i As BranchType) As Integer
    '    Dim Status As Boolean
    '    'Status = globalcnn.Del_Validation(i.Id, "Institute")
    '    If (Status) = True Then
    '        Exit Function
    '    End If
    '    Return DLBranchType.ChangeFlag(i.Id)
    'End Function

    Public Function GetComboUser(ByVal code As String) As List(Of BranchTypeCombo)
        Dim Inst As New List(Of BranchTypeCombo)
        Dim ds As DataSet = DLBranchType.GVComboUser(code)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New BranchTypeCombo(row("BranchTypeCode"), row("BranchTypeName")))
        Next
        Return Inst
    End Function
    Public Function FillAllTypes() As List(Of BranchTypeCombo)
        Dim Inst As New List(Of BranchTypeCombo)
        Dim ds As DataSet = DLBranchType.FillAllBranchTypes
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New BranchTypeCombo(row("BranchType_ID"), row("BranchTypeName")))
        Next
        Return Inst
    End Function
    Public Function FillTypesByUID(ByVal UserID As Long) As List(Of BranchTypeCombo)
        Dim Inst As New List(Of BranchTypeCombo)
        Dim ds As DataSet = DLBranchType.FillBranchTypesByUID(UserID)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New BranchTypeCombo(row("BranchType_ID"), row("BranchTypeName")))
        Next
        Return Inst
    End Function
    Public Function FillZoneCmboDtls(ByVal id As Int64) As List(Of BranchTypeCombo)
        Dim Inst As New List(Of BranchTypeCombo)
        Dim ds As DataSet = DLBranchType.FillZoneCombo(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New BranchTypeCombo(row("ZoneID"), row("ZoneName")))
        Next
        Return Inst
    End Function
    Public Function FillZoneCmboDtls() As List(Of BranchTypeCombo)
        Dim Inst As New List(Of BranchTypeCombo)
        Dim ds As DataSet = DLBranchType.FillZoneCombo(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New BranchTypeCombo(row("ZoneID"), row("ZoneName")))
        Next
        Return Inst
    End Function
    Public Function FillROCmboDtls(ByVal Hoid As Long, ByVal id As Long) As List(Of BranchTypeCombo)
        Dim Inst As New List(Of BranchTypeCombo)
        Dim ds As DataSet = DLBranchType.FillROCombo(Hoid, id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New BranchTypeCombo(row("RO_ID"), row("RO_Name")))
        Next
        Return Inst
    End Function
End Class
