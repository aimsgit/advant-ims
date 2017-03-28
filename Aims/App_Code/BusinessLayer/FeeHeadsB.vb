Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class FeeHeadsB
    Dim FDB As New FeeHeadsDB
    Public Function GetFeeHeads(ByVal id As Long) As List(Of FeeHeads)
        Dim feeheads As New List(Of FeeHeads)
        Dim ds As DataSet = FeeHeadsDB.GetFeeHeads(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            feeheads.Add(New FeeHeads(row("Fee_Head_ID"), row("Fee_HeadType")))
        Next
        Return feeheads
    End Function
    Public Function GetFeeHeads() As List(Of FeeHeads)
        Dim feeheads As New List(Of FeeHeads)
        Dim ds As DataSet = FeeHeadsDB.GetFeeHeads(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            feeheads.Add(New FeeHeads(row("Fee_Head_ID"), row("Fee_HeadType")))
        Next
        Return feeheads
    End Function

    Public Function InsertRecord(ByVal f As FeeHeads) As Integer
        Return FeeHeadsDB.Insert(f)
    End Function

    Public Function UpdateRecord(ByVal f As FeeHeads) As Integer
        Return FeeHeadsDB.Update(f)
    End Function
    Public Function ChangeFlag(ByVal f As FeeHeads) As Integer
        Return FeeHeadsDB.ChangeFlag(f)
    End Function
    Public Function GetFullFeeHeads() As List(Of FeeHeads)
        Dim feeheads As New List(Of FeeHeads)
        Dim ds As DataSet = FeeHeadsDB.GetFeeHeads(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            feeheads.Add(New FeeHeads(row("Fee_Head_ID"), row("Fee_HeadType")))
        Next
        Return feeheads
    End Function
    Public Function GetReportData(ByVal f As FeeHeads) As DataTable
        Return FeeHeadsDB.GetReportData(f)
    End Function
    Public Function GetsElfDetails() As Data.DataTable
        Return selfdetailsDB.GetDeatils(0).Tables(0)
    End Function
    'duplicate code written by manish 08-02-2012
    'used for not take duplicate data
    Public Function GetDuplicateFeeheadType(ByVal f As FeeHeads) As DataTable
        Return FDB.GetDuplicateFeeHeadType(f)
    End Function
End Class
