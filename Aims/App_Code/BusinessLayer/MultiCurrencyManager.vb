Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
Imports System.Collections.Generic
Imports System.Data

Public Class MultiCurrencyManager
    'Public Shared Function GetMulticurrencyById(ByVal id As Long) As List(Of MultiCurrency)
    '    Dim mcurrencyname As New List(Of MultiCurrency)
    '    Dim ds As DataSet = MultiCurrencyDB.GetMultiCurrency(id)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        mcurrencyname.Add(New MultiCurrency(row("Currency_Code"), row("Currency_Name"), row("Buy_Conversion_Rate")))
    '    Next
    '    Return mcurrencyname
    'End Function
    'Public Function GetMulticurrency() As List(Of MultiCurrency)
    '    Dim mcurrencyname As New List(Of MultiCurrency)
    '    Dim ds As DataSet = MultiCurrencyDB.GetMultiCurrency(0)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        mcurrencyname.Add(New MultiCurrency(row("Currency_Code"), row("Currency_Name"), row("Buy_Conversion_Rate")))
    '    Next
    '    Return mcurrencyname
    'End Function
    Public Function GetMulticurrency() As DataSet
        Return MultiCurrencyDB.GetMultiCurrency()
    End Function
    Public Function GetMulticurrencyRate(ByVal id As Long) As MultiCurrency
        Dim mcurrencyname As New MultiCurrency
        Dim ds As DataSet = MultiCurrencyDB.GetMultiCurrencyRate(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            mcurrencyname = New MultiCurrency(row("Currency_Code"), row("Currency_Name"), row("Buy_Conversion_Rate"))
        Next
        Return mcurrencyname
    End Function
End Class
