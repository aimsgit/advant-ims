Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BLMonthlySalary

    'Commented by Nethra during Build 13-Apr-2012

    'Public Function GetMonthlySalary() As List(Of EntMonthlySalary)
    '    Dim MonthlySalary As New List(Of EntMonthlySalary)
    '    Dim ds As DataSet = DataMonthlySalary.GetMonthlySalary(0)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        MonthlySalary.Add(New EntMonthlySalary(row("MS_ID"), row("EMP_id"), row("PaymentDate"), row("ENtryDate"), row("BasicPay"), row("SpecialAllowance"), row("HRA"), row("Medical"), row("TransportAllowance"), row("OtherAllowance"), row("Incentives"), row("MiscellaneousPay"), row("TaxDeduction"), row("ITTaxDeduction"), row("AdvStlDeduction"), row("OtherDeduction"), row("GrossSalary"), row("NetSalary"), row("LOPay"), row("OtherPay"), row("Del_Flag")))
    '    Next
    '    Return MonthlySalary
    'End Function
    'Public Function GetMonthlySalary(ByVal id As Long) As List(Of EntMonthlySalary)
    '    Dim MonthlySalary As New List(Of EntMonthlySalary)
    '    Dim ds As DataSet = DataMonthlySalary.GetMonthlySalary(id)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        MonthlySalary.Add(New EntMonthlySalary(row("MS_ID"), row("EMP_id"), row("PaymentDate"), row("ENtryDate"), row("BasicPay"), row("SpecialAllowance"), row("HRA"), row("Medical"), row("TransportAllowance"), row("OtherAllowance"), row("Incentives"), row("MiscellaneousPay"), row("TaxDeduction"), row("ITTaxDeduction"), row("AdvStlDeduction"), row("OtherDeduction"), row("GrossSalary"), row("NetSalary"), row("LOPay"), row("OtherPay"), row("Del_Flag")))
    '    Next
    '    Return MonthlySalary
    'End Function
    'Public Function GetMonthlySalaryByMSId(ByVal id As Long) As EntMonthlySalary
    '    Dim MonthlySalary As EntMonthlySalary
    '    Dim ds As DataSet = DataMonthlySalary.GetMonthlySalary(id)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    MonthlySalary = New EntMonthlySalary(row("MS_ID"), row("EMP_id"), row("PaymentDate"), row("ENtryDate"), row("BasicPay"), row("SpecialAllowance"), row("HRA"), row("Medical"), row("TransportAllowance"), row("OtherAllowance"), row("Incentives"), row("MiscellaneousPay"), row("TaxDeduction"), row("ITTaxDeduction"), row("AdvStlDeduction"), row("OtherDeduction"), row("GrossSalary"), row("NetSalary"), row("LOPay"), row("OtherPay"), row("Del_Flag"))
    '    Return MonthlySalary
    'End Function
    'Public Function InsertRecord(ByVal i As EntMonthlySalary)
    '    i.GrossSalary = i.BasicPay + i.HRA + i.Medical + i.MiscellaneousPay + i.Incentives + i.TransportAllowance + i.OtherAllowance + i.SpecialAllowance
    '    i.NetSalary = i.GrossSalary - (i.TaxDeduction + i.ITTaxDeduction + i.AdvStlDeduction + i.OtherDeduction + i.LOPay)
    '    Return DataMonthlySalary.Insert(i)
    'End Function
    'Public Function UpdateRecord(ByVal i As EntMonthlySalary) As Integer
    '    i.GrossSalary = i.BasicPay + i.HRA + i.Medical + i.MiscellaneousPay + i.Incentives + i.TransportAllowance + i.OtherAllowance + i.SpecialAllowance
    '    i.NetSalary = i.GrossSalary - (i.TaxDeduction + i.ITTaxDeduction + i.AdvStlDeduction + i.OtherDeduction + i.LOPay)
    '    Return DataMonthlySalary.Update(i)
    'End Function
    'Public Function ChangeFlag(ByVal i As EntMonthlySalary) As Integer
    '    Return DataMonthlySalary.ChangeFlag(i.MSid)
    'End Function
End Class
