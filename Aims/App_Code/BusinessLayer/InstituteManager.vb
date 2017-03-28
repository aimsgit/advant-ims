Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class InstituteManager
    Public Function GetInstitute() As List(Of Institute)
        Dim institute As New List(Of Institute)
        Dim ds As DataSet = InstituteDB.GetInstitute(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            institute.Add(New Institute(row("Institute_ID"), row("InstituteName"), row("InstituteAdress"), row("InstituteCode"), row("City"), row("State"), row("Country"), row("ContactNo"), row("ContactPerson")))
        Next
        Return institute
    End Function
    Public Function GetInstitute(ByVal id As Long) As List(Of Institute)
        Dim institute As New List(Of Institute)
        Dim ds As DataSet = InstituteDB.GetInstitute(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            institute.Add(New Institute(row("Institute_ID"), row("InstituteName"), row("InstituteAdress"), row("InstituteCode"), row("City"), row("State"), row("Country"), row("ContactNo"), row("ContactPerson")))
        Next
        Return institute
    End Function
    Public Function GetInstituteByInstituteId(ByVal id As Long) As Institute
        Dim institute As Institute
        Dim ds As DataSet = InstituteDB.GetInstitute(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        institute = New Institute(row("Institute_ID"), row("InstituteName"), row("InstituteAdress"), row("InstituteCode"), row("City"), row("State"), row("Country"), row("ContactNo"), row("ContactPerson"))
        Return institute
    End Function
    Public Function InsertRecord(ByVal i As Institute) As Integer
        If i.City = Nothing Then
            i.City = ""
        End If
        If i.State = Nothing Then
            i.State = ""
        End If
        If i.Country = Nothing Then
            i.Country = ""
        End If
        Return InstituteDB.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As Institute) As Integer
        If i.City = Nothing Then
            i.City = ""
        End If
        If i.State = Nothing Then
            i.State = ""
        End If
        If i.Country = Nothing Then
            i.Country = ""
        End If
        Return InstituteDB.Update(i)
    End Function
    Public Function ChangeFlag(ByVal i As Institute) As Integer
        Dim Status As Boolean
        Status = globalcnn.Del_Validation(i.Id, "Institute")
        If (Status) = True Then
            Exit Function
        End If
        Return InstituteDB.ChangeFlag(i.Id)
    End Function

    Public Function GetComboUser(ByVal id As Long) As List(Of InstCombo)
        Dim Inst As New List(Of InstCombo)
        Dim ds As DataSet = InstituteDB.GVComboUser(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New InstCombo(row("Institute_ID"), row("InstituteName")))
        Next
        Return Inst
    End Function
    Public Function FillAllTypes() As List(Of InstCombo)
        Dim Inst As New List(Of InstCombo)
        Dim ds As DataSet = InstituteDB.FillAllBranchTypes
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New InstCombo(row("Institute_ID"), row("InstituteName")))
        Next
        Return Inst
    End Function
    Public Function FillTypesByUID(ByVal UserID As Long) As List(Of InstCombo)
        Dim Inst As New List(Of InstCombo)
        Dim ds As DataSet = InstituteDB.FillBranchTypesByUID(UserID)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New InstCombo(row("Institute_ID"), row("InstituteName")))
        Next
        Return Inst
    End Function
    Public Function FillZoneCmboDtls(ByVal id As Int64) As List(Of InstCombo)
        Dim Inst As New List(Of InstCombo)
        Dim ds As DataSet = InstituteDB.FillZoneCombo(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New InstCombo(row("ZoneID"), row("ZoneName")))
        Next
        Return Inst
    End Function
    Public Function FillZoneCmboDtls() As List(Of InstCombo)
        Dim Inst As New List(Of InstCombo)
        Dim ds As DataSet = InstituteDB.FillZoneCombo(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New InstCombo(row("ZoneID"), row("ZoneName")))
        Next
        Return Inst
    End Function
    Public Function FillROCmboDtls(ByVal Hoid As Long, ByVal id As Long) As List(Of InstCombo)
        Dim Inst As New List(Of InstCombo)
        Dim ds As DataSet = InstituteDB.FillROCombo(Hoid, id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Inst.Add(New InstCombo(row("RO_ID"), row("RO_Name")))
        Next
        Return Inst
    End Function
End Class
