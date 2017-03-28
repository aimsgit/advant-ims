Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BankManager
    Dim bankdb As New BankDB
    Public Function GetBank() As List(Of Bank)
        Dim bank As New List(Of Bank)
        Dim ds As DataSet = BankDB.GetBank(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            bank.Add(New Bank(row("Bank_ID"), row("Bank_Name"), row("Bank_Address"), row("Remarks")))
        Next
        Return bank
    End Function
    Public Function GetBank(ByVal id As Long) As List(Of Bank)
        Dim bank As New List(Of Bank)
        Dim ds As DataSet = BankDB.GetBank(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            bank.Add(New Bank(row("Bank_ID"), row("Bank_Name"), row("Bank_Address"), row("Remarks")))
        Next
        Return bank
    End Function
    Public Function GetBankByBankId(ByVal id As Long) As Bank
        Dim Bank As Bank
        Dim ds As DataSet = BankDB.GetBank(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        Bank = New Bank(row("Bank_ID"), row("Bank_Name"), row("Bank_Address"), row("Remarks"))
        Return Bank
    End Function
    Public Function InsertRecord(ByVal B As Bank)
        If B.Address = Nothing Then
            B.Address = ""
        End If
        If B.Remarks = Nothing Then
            B.Remarks = ""
        End If
        Return BankDB.Insert(B)
    End Function
    Public Function UpdateRecord(ByVal B As Bank)
        If B.Address = Nothing Then
            B.Address = ""
        End If
        If B.Remarks = Nothing Then
            B.Remarks = ""
        End If
        Return BankDB.Update(B)
    End Function
    Public Function ChangeFlag(ByVal B As Integer) As Integer
        Dim rowsaffected As Integer
        rowsaffected = BankDB.ChangeFlag(B)
        Return rowsaffected
    End Function
    Public Function GetBankComboDB(ByVal id As Int32) As List(Of DayBookPartyName)
        Dim em As New List(Of DayBookPartyName)
        Dim ds As DataSet = BankDB.GetBankComboDayBook(0)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        For Each row In ds.Tables(0).Rows
            em.Add(New DayBookPartyName(row("Name"), row("Id")))
        Next
        Return em
    End Function
    Public Function GetBankComboDBID(ByVal id As Int32) As DayBookPartyName
        Dim em As DayBookPartyName
        Dim ds As DataSet = BankDB.GetBankComboDayBook(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        em = New DayBookPartyName(row("Name"), row("Id"))
        Return em
    End Function
    Public Function RptBank(ByVal inst As Int64, ByVal brn As Int64) As Data.DataTable
        Return BankDB.RptBank(inst, brn)
    End Function
    Public Function getBankDetails(ByVal Inst As Bank) As DataTable
        Return BankDB.getBankDetails(Inst)
    End Function
    Public Function GetBankDetailsDuplicate(ByVal EL As Bank) As DataTable
        Return bankdb.GetBankDetailsDuplicate(EL)
    End Function
End Class
