Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class OtherPartyB
    Dim opdb As New OtherpartyDB

    Public Function GetDetails(ByVal op As OtherParty) As System.Data.DataTable
        Return OtherpartyDB.GetDeatils(op)
    End Function
    Public Function Insert(ByVal op As OtherParty) As Integer
        Return OtherpartyDB.Insert(op)
    End Function
    Public Function UpdateRecord(ByVal op As OtherParty) As Integer
        Return OtherpartyDB.Update(op)
    End Function
    Public Function ChangeFlag(ByVal op As OtherParty) As Integer
        Return OtherpartyDB.ChangeFlag(op)
    End Function
    Public Function GetOtherComboDB(ByVal id As Int32) As List(Of DayBookPartyName)
        Dim em As New List(Of DayBookPartyName)
        Dim ds As DataSet = OtherpartyDB.GetOtherComboDayBook(0)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        For Each row In ds.Tables(0).Rows
            em.Add(New DayBookPartyName(row("Name"), row("Id")))
        Next
        Return em
    End Function
    Public Function GetOtherComboDBID(ByVal id As Int32) As DayBookPartyName
        Dim em As DayBookPartyName
        Dim ds As DataSet = OtherpartyDB.GetOtherComboDayBook(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        em = New DayBookPartyName(row("Name"), row("Id"))
        Return em
    End Function
    Public Function GetReport(ByVal insID As Int64, ByVal brnID As Int64) As Data.DataTable
        Return OtherpartyDB.GetReport()
    End Function
    Public Function GetDuplicateParty(ByVal op As OtherParty) As DataTable
        Return opdb.GetDuplicateotherparty(op)
    End Function
End Class
