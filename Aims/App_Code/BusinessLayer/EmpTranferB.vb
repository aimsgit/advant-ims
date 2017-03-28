Imports Microsoft.VisualBasic

Public Class EmpTranferB

    Public Function finalExamRpt(ByVal Desig As Integer, ByVal SalGrade As String, ByVal doj As Integer, ByVal fromdate As Date, ByVal todate As Date, ByVal DeptId As Integer, ByVal SortBy As Integer) As DataTable
        Return EmpTransD.finalExamRpt(Desig, SalGrade, doj, fromdate, todate, DeptId, SortBy)
    End Function
    Public Function finalEmpRptAICTE(ByVal Id As String, ByVal Desig As Integer, ByVal SalGrade As Integer, ByVal DeptId As Integer, ByVal SortBy As Integer) As DataTable
        Return EmpTransD.finalEmpRptAICTE(Id, Desig, SalGrade, DeptId, SortBy)
    End Function
    Public Function finalDynEmpRptAICTE() As System.Data.DataTable
        Return EmpTransD.finalDynEmpRptAICTE()
    End Function

    'Public Function Branch() As DataTable
    '    Return EmpDetailsD.Branch()
    'End Function

    Public Function Designation() As DataTable
        Return EmpTransD.Designation()
    End Function

    Public Function GetEmp(ByVal prefix As String) As DataTable
        'Dim dataSet As New DataSet
        'dataSet = EmpTransD.GetEmp(prefix)
        Return EmpTransD.GetEmp(prefix)
    End Function
    Public Function GetEmpDetails() As DataTable
        'Dim dataSet As New DataSet
        'dataSet = EmpTransD.GetEmp(prefix)
        Return EmpTransD.GetEmpDetails()
    End Function
    Public Function GetEmpDetails(ByVal I As Integer) As DataTable
        'Dim dataSet As New DataSet
        'dataSet = EmpTransD.GetEmp(prefix)
        Return EmpTransD.GetEmpDetails(I)
    End Function
    Public Function InsertRecord(ByVal i As EmpTransE) As Integer
        Return EmpTransD.insert(i)
    End Function

    Public Function GetBranchTypecombo() As Data.DataTable
        Return EmpTransD.GetBranchTypecombo()
    End Function

    Public Function GetBranchTypecombo1() As Data.DataTable
        Return EmpTransD.GetBranchTypecombo1()
    End Function

End Class
