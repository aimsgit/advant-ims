Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BLPayroll
    Public Function GetPayrollrpt(ByVal insId As Int64, ByVal brnId As Int64, ByVal empId As Int64) As DataTable
        Dim ds As DataSet = DataPayroll.GetPayrollrpt(insId, brnId, empId)
        Return ds.Tables(0)
    End Function
    Public Function GetPayroll(ByVal id As EntPayroll) As Data.DataTable
        Dim ds As DataTable = DataPayroll.GetPayroll(id)
        Return ds
    End Function
    Public Function InsertRecord(ByVal i As EntPayroll) As Integer
        Return DataPayroll.Insert(i)
    End Function
    Public Function InsertLoan(ByVal i As EntPayroll) As Integer
        Return DataPayroll.InsertLoan(i)
    End Function
    Public Function UpdateRecord(ByVal i As EntPayroll) As Integer
        Return DataPayroll.Update(i)
    End Function
    Public Function ChangeFlag(ByVal i As EntPayroll) As Integer
        Return DataPayroll.ChangeFlag(i)
    End Function
    Public Function CheckDuplicate(ByVal i As EntPayroll) As System.Data.DataTable
        Return DataPayroll.CheckDuplicate(i)
    End Function
    Public Function URL(ByVal Str As String) As String
        Dim Str1 As String = StrReverse(Str)
        Dim i As Int16 = InStr(Str1, "/")
        Return StrReverse(Left(Str1, i - 1))
    End Function
    Public Function GenerateSalary(ByVal Prop As EntPayroll) As Integer
        Return DataMonthlySalary.GenerateSalary(Prop)
    End Function
    Public Function GenerateSalary1(ByVal Prop As EntPayroll) As Integer
        Return DataMonthlySalary.GenerateSalary1(Prop)
    End Function
    Public Function RptSalSlip2(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptSalSlip2(EL)
    End Function
    Public Function GetLoanDetails(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.GetLoanDetails(EL)
    End Function
    Public Function RptSalSlip3(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptSalSlip3(EL)
    End Function
    Public Function RptSalSlip4(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptSalSlip4(EL)
    End Function
    Public Function RptSalSlip(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptSalSlip(EL)
    End Function
    Public Function GetAmount(ByVal EL As ELPayrollRulesEngine) As Data.DataTable
        Return DataMonthlySalary.GetAmount(EL)
    End Function
    Public Function GetGrossNet(ByVal EL As ELPayrollRulesEngine) As Data.DataTable
        Return DataMonthlySalary.GetGrossNet(EL)
    End Function
    Public Function GetPayrollRules(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.GetPayrollRules(EL)
    End Function
    Public Function RptSalSlip1(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptSalSlip1(EL)
    End Function
    Public Function SelectPF(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.SelectPF(EL)
    End Function
    Public Function RptMySalSlip(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptMySalSlip(EL)
    End Function
    Public Function RptMySalSlipRegister(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptMySalSlipRegister(EL)
    End Function
    Public Function RptMySalSlipNew(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptMySalSlipNew(EL)
    End Function
    Public Function RptMySalSlipNew1(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptMySalSlipNew1(EL)
    End Function
    Public Function RptMySalSlipNew2(ByVal EL As EntPayroll) As Data.DataTable
        Return DataMonthlySalary.RptMySalSlipNew2(EL)
    End Function
    Public Function DeleteSalary(ByVal prop As EntPayroll) As Integer
        Return DataMonthlySalary.DeleteSalary(prop)
    End Function
    Public Function DeleteSalary1(ByVal prop As EntPayroll) As Integer
        Return DataMonthlySalary.DeleteSalary1(prop)
    End Function
    Public Function LockSalary(ByVal Prop As EntPayroll) As Integer
        Return DataMonthlySalary.LockSalary(Prop)
    End Function
    Public Function LockStatus(ByVal Prop As EntPayroll) As String
        Return DataMonthlySalary.LockStatus(Prop)
    End Function
    Public Function LockSalary1(ByVal Prop As EntPayroll) As Integer
        Return DataMonthlySalary.LockSalary1(Prop)
    End Function
    Public Function LockStatus1(ByVal Prop As EntPayroll) As String
        Return DataMonthlySalary.LockStatus1(Prop)
    End Function
    Public Function updateloan(ByVal Prop As EntPayroll) As Integer
        Return DataMonthlySalary.updateloan(Prop)
    End Function
    Public Function updateloan1(ByVal Prop As EntPayroll) As Integer
        Return DataMonthlySalary.updateloan1(Prop)
    End Function

    'Commented by Nethra during Build 13-Apr-2012

    'Public Function GetMonthly_Details() As Data.DataTable
    '    Dim DAL As New DataMonthlySalary
    '    Return DAL.GetMonthly_Details()
    'End Function
    'Public Sub Delete()
    '    Dim DAL As New DataMonthlySalary
    '    DAL.Delete()
    'End Sub

    'Public Function GetDetails(ByVal Prop As EntPayroll) As Data.DataTable
    '    Dim DAL As New DataMonthlySalary
    '    Return DAL.GetMonthlySalary(Prop)
    'End Function
    Public Function UpdatePF(ByVal Id As Double, ByVal PF As Double, ByVal Netsalary As Double) As Int16
        Return DataMonthlySalary.UpdatePF(Id, PF, Netsalary)
    End Function
    'Public Function CheckSalary(ByVal Prop As EntPayroll) As Boolean
    '    Dim DAL As New DataMonthlySalary
    '    Return DAL.ChkGenSal(Prop)
    'End Function
    'Public Function GetInstBrch(ByVal E_ID As Int64) As Data.DataTable
    '    Return DataMonthlySalary.GetInstBrch(E_ID)
    'End Function
End Class
'<System.ComponentModel.DataObject()> _
'Public Class Update_Mont_Payroll_Details
'    Private _mont_Payroll_Det As GlobalDataSetTableAdapters.Month_Details_PayrollTableAdapter = Nothing
'    Protected ReadOnly Property Adapter() As GlobalDataSetTableAdapters.Month_Details_PayrollTableAdapter
'        Get
'            If _mont_Payroll_Det Is Nothing Then
'                _mont_Payroll_Det = New GlobalDataSetTableAdapters.Month_Details_PayrollTableAdapter
'            End If
'            Return _mont_Payroll_Det
'        End Get
'    End Property

'    ' Public Function UpdateWithTransaction(ByVal monthDetailsPayroll As GlobalDataSet.Month_Details_PayrollDataTable) As Integer
'    '     Return Me.Adapter.UpdateWithTransaction(monthDetailsPayroll)
'    ' End Function

'    ' Public Function UpdateProductsWithTransaction(ByVal monthDetailsPayroll As GlobalDataSet.Month_Details_PayrollDataTable) As Int32
'    '     monthDetailsPayroll.AcceptChanges()

'    '     For Each row As GlobalDataSet.Month_Details_PayrollRow In monthDetailsPayroll.Rows
'    '         row.SetModified()
'    '     Next

'    '     Me.UpdateWithTransaction(monthDetailsPayroll)
'    ' End Function

'    ' <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
'    'Public Function GetProducts() As GlobalDataSet.Month_Details_PayrollDataTable
'    '     Return Adapter.GetData
'    ' End Function

'    ' <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
'    'Public Function GetDataBy(ByVal ID As Integer) As GlobalDataSet.Month_Details_PayrollDataTable
'    '     Return Adapter.GetDataBy(ID)
'    ' End Function
'End Class
