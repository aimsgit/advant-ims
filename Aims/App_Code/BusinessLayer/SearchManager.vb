Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Public Class SearchManager
    Public Function GetInstitute() As List(Of Institute)
        Dim institute As New List(Of Institute)
        Dim ds As DataSet = InstituteDB.GetInstitute(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            'institute.Add(New Institute(row("Institute_ID"), row("InstituteName"), row("Branch_ID"), row("InstituteAdress")))
        Next
        Return institute
    End Function
    Public Function GetInstituteByInstituteId(ByVal id As Long) As Institute
        Dim institute As Institute
        Dim ds As DataSet = InstituteDB.GetInstitute(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        'institute = New Institute(row("Institute_ID"), row("InstituteName"), row("Branch_ID"), row("InstituteAdress"))
        Return institute
    End Function
    Public Function GetInstituteByBranchId(ByVal id As Long) As List(Of Institute)
        Dim institute As New List(Of Institute)
        Dim ds As DataSet = InstituteDB.GetInstitute(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            'institute.Add(New Institute(row("Institute_ID"), row("InstituteName"), row("Branch_ID"), row("InstituteAdress")))
        Next
        Return institute
    End Function
End Class
