Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Public Class SponsorManager
    Dim SponsorDB As New SponsorDB
    'Public Function GetSponsor(ByVal id As Long) As List(Of Sponsor)
    '    Dim sponsor As New List(Of Sponsor)
    '    Dim ds As DataSet = SponsorDB.GetSponsor(id)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        sponsor.Add(New Sponsor(row("Sponsor_ID"), row("SponsorName"), row("SponsorAddress"), row("ContactNumber"), row("Email"), row("Remarks")))
    '    Next
    '    Return sponsor
    'End Function
    'Public Function GetSponsorBySponsorId(ByVal id As Long) As Sponsor
    '    Dim sponsor As Sponsor
    '    Dim ds As DataSet = SponsorDB.GetSponsor(id)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    sponsor = New Sponsor(row("Sponsor_ID"), row("SponsorName"), row("SponsorAddress"), row("ContactNumber"), row("Email"), row("Remarks"))
    '    Return sponsor
    'End Function
    Public Function InsertRecord(ByVal s As Sponsor) As Integer
        Return SponsorDB.Insert(s)
    End Function
    Public Function UpdateRecord(ByVal s As Sponsor) As Integer
        Return SponsorDB.Update(s)
    End Function
    Public Function CheckDuplicate(ByVal s As Sponsor) As Data.DataTable
        Return SponsorDB.CheckDuplicate(s)
    End Function
    Public Function ChangeFlag(ByVal id As Integer) As Integer
        Return SponsorDB.ChangeFlag(id)
    End Function
    Public Function SponsorCombo() As Data.DataTable
        Return SponsorDB.SponsorCombo()
    End Function

    Public Function GetSponsorCombo() As Data.DataTable
        Return SponsorDB.GetSponsorCombo()
    End Function
    Public Function SponsorName(ByVal id As Integer) As String
        Return SponsorDB.SponsorName(id)
    End Function
    Public Function GetReport(ByVal Office As String, ByVal BranchCode As String) As Data.DataTable
        Return SponsorDB.GetReport(Office, BranchCode)
    End Function
End Class
