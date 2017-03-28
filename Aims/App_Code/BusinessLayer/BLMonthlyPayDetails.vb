Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BLMonthlyPayDetails
    Dim MD As New DLMonthlyPayDetails
    Public Function generate(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer, ByVal MonthNo As Integer) As Integer
        Return MD.generate(month, year, Dept, MonthNo)
    End Function
    Public Function update(ByVal m As ELMonthlyPayDetails) As Integer
        Return MD.update(m)
    End Function
    Public Function updateLoannDedc(ByVal m As ELMonthlyPayDetails) As Data.DataTable
        Return MD.updateLoannDedc(m)
    End Function
    Public Function ClearMarks(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer) As Integer
        Return DLMonthlyPayDetails.ClearMarks(month, year, Dept)
    End Function
    'Dim a As New feeCollectionDL
    ''Public Function GetStudentCode(ByVal prefixText As String) As Data.DataTable
    ''    'Return feeCollectionDL.GetStudent(prefixText)
    ''End Function
    'Public Function SemesterCombo() As Data.DataTable
    '    Return a.SemesterComboD()
    'End Function
    'Public Function BankCombo() As Data.DataTable
    '    Return a.BankComboD()
    'End Function
    'Public Function PaymentMethodCombo() As Data.DataTable
    '    Return a.PaymentMethodComboD()
    'End Function
    Public Function duplicate(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer, ByVal MonthNo As Integer) As Data.DataTable
        Return MD.duplicate(month, year, Dept, MonthNo)
    End Function
    Public Function getgrid(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer) As Data.DataTable
        Return MD.getgrid(month, year, Dept)
    End Function
    Public Function getgrid1(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer, ByVal EmpId As Integer) As Data.DataTable
        Return MD.getgrid1(month, year, Dept, EmpID)
    End Function
    'Public Function getGrd2(ByVal El As FeeCollectionEl) As Data.DataTable
    '    Return a.getGrd2(El)
    'End Function
    'Public Function InsertRecord(ByVal b As FeeCollectionEl) As Integer
    '    Return a.InsertRecord(b)
    'End Function
    'Public Function UpdateRecord(ByVal El As FeeCollectionEl) As Integer
    '    Return a.UpdateRecord(El)
    'End Function
    'Public Function ChangeFlag(ByVal El As FeeCollectionEl) As Integer
    '    Return feeCollectionDL.ChangeFlag(El)
    'End Function
End Class

