Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class EmployeeManager
    Public Function InsertRecord(ByVal E As Employee) As Integer
        Return EmployeeDB.Insert(E)
    End Function
    Public Function UpdateRecord(ByVal E As Employee) As Integer
        Return EmployeeDB.Insert(E)
    End Function
    Public Function DeleteRecord(ByVal E As Employee) As Integer
        ' Dim Status As Boolean
        ' Status = globalcnn.Del_Validation(E.Emp_Id, "EmployeeMaster")
        'If Status = True Then
        'Exit Function
        ' End If
        Return EmployeeDB.Delete(E.Emp_Id)
    End Function
    Public Function Getbranch() As DataSet
        Return EmployeeDB.Getbranch()
    End Function
    Public Function GetempnameByempId(ByVal employeeid As Long) As Employee
        Dim ds As DataSet = EmployeeDB.GVDetails(employeeid)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        Dim employee As Employee = New Employee(row("Emp_Name"), row("Emp_code"), row("Category"), row("Employment_Type"), row("DOB"), row("DOJ"), row("DOL"), row("Designation"), row("Branch_ID"), row("Institute_ID"), row("Dept_ID"), row("Salary"), row("AccountNo"), row("Bank_ID"), row("Emp_Address"), row("Emp_City"), row("Zip"), row("State"), row("Country"), row("Contact_No1"), row("Contact_No2"), row("Email"), row("Emp_Id"), row("Photos"), row("ITCategory"), row("District"), row("UniqueCode"), row("TransferTo"))
        Return employee
    End Function
    Public Function GetEmpDt() As List(Of Employee)
        Try
            Dim emp As New List(Of Employee)
            Dim ds As DataSet = EmployeeDB.GVDetails(0)
            Dim row As DataRow
            For Each row In ds.Tables(0).Rows
                emp.Add(New Employee(row("Emp_Name"), row("Emp_code"), row("Category"), row("Employment_Type"), row("DOB"), row("DOJ"), row("DOL"), row("Designation"), row("Branch_ID"), row("Institute_ID"), row("Dept_ID"), row("Salary"), row("AccountNo"), row("Bank_ID"), row("Emp_Address"), row("Emp_City"), row("Zip"), row("State"), row("Country"), row("Contact_No1"), row("Contact_No2"), row("Email"), row("Emp_Id"), row("Photos"), row("ITCategory"), row("District"), row("UniqueCode"), row("TransferTo")))
                ''MsgBox(row("Emp_Name") + "," + row("Emp_code") + "," + row("Category") + "," + row("Employment_Type") + "," + row("DOB") + "," + row("DOJ") + "," + row("DOL") + "," + row("Designation") + "," + row("Branch_ID") + "," + row("Institute_ID") + "," + row("Dept_ID") + "," + row("Salary") + "," + row("AccountNo") + "," + row("Bank_ID") + "," + row("Emp_Address") + "," + row("Emp_City") + "," + row("Zip") + "," + row("State") + "," + row("Country") + "," + row("Contact_No1") + "," + row("Contact_No2") + "," + row("Email") + "," + row("Emp_Id") + "," + row("Photos") + "," + row("ITCategory") + "," + row("District") + "," + row("UniqueCode") + "," + row("TransferTo"))
            Next
            Return emp
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Nothing
    End Function
    Public Function GetEmpDt(ByVal id As Integer) As List(Of Employee)
        Dim emp As New List(Of Employee)
        Dim ds As DataSet = EmployeeDB.GVDetails(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            emp.Add(New Employee(row("Emp_Name"), row("Emp_code"), row("Category"), row("Employment_Type"), row("DOB"), row("DOJ"), row("DOL"), row("Designation"), row("Branch_ID"), row("Institute_ID"), row("Dept_ID"), row("Salary"), row("AccountNo"), row("Bank_ID"), row("Emp_Address"), row("Emp_City"), row("Zip"), row("State"), row("Country"), row("Contact_No1"), row("Contact_No2"), row("Email"), row("Emp_Id"), row("Photos"), row("ITCategory"), row("District"), row("UniqueCode"), row("TransferTo")))
        Next
        Return emp
    End Function
    Public Function GetEmpEditDetails(ByVal EEid As Integer) As List(Of Employee)
        Dim empEdit As New List(Of Employee)
        Dim ds As DataSet = EmployeeDB.GVDetails(EEid)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            empEdit.Add(New Employee(row("Emp_Name"), row("Emp_code"), row("Category"), row("Employment_Type"), row("DOB"), row("DOJ"), row("DOL"), row("Designation"), row("Branch_ID"), row("Institute_ID"), row("Dept_ID"), row("Salary"), row("AccountNo"), row("Bank_ID"), row("Emp_Address"), row("Emp_City"), row("Zip"), row("State"), row("Country"), row("Contact_No1"), row("Contact_No2"), row("Email"), row("Emp_Id"), row("Photos"), row("ITCategory"), row("District"), row("UniqueCode"), row("TransferTo")))
        Next
        Return empEdit
    End Function
    Public Function GetEmpID(ByVal id As Integer) As EmpCombo
        Dim em As EmpCombo
        Dim ds As DataSet = EmployeeDB.GVDetails(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        em = New EmpCombo(row("Emp_Name"), row("Emp_Id"))
        Return em
    End Function
    Public Function GetEmpCombo() As List(Of EmpCombo)
        Dim emp As New List(Of EmpCombo)
        Dim ds As DataSet = EmployeeDB.GVCombo()
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            emp.Add(New EmpCombo(row("Emp_Name"), row("Emp_Id")))
        Next
        Return emp
    End Function
    'Public Function GetEmpComboUser(ByVal id As Long, ByVal Iid As Long, ByVal Bid As Long) As List(Of EmpCombo)
    '    Dim emp As New List(Of EmpCombo)
    '    Dim ds As DataSet = EmployeeDB.GVComboUser(id, Iid, Bid)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        emp.Add(New EmpCombo(row("Emp_Name"), row("Emp_Id")))
    '    Next
    '    Return emp
    'End Function
    'Public Function GetEmpComboUser(ByVal id As Long) As List(Of EmpCombo)
    '    Dim emp As New List(Of EmpCombo)
    '    Dim ds As DataSet = EmployeeDB.GVComboUser(id)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        emp.Add(New EmpCombo(row("Emp_Name"), row("Emp_Id")))
    '    Next
    '    Return emp
    'End Function 
    Public Function GetEmpComboUserInsBr(ByVal Iid As Long, ByVal Bid As Long) As List(Of Employee)
        Dim emp As New List(Of Employee)
        Dim ds As DataSet = EmployeeDB.GVComboUserIB(Iid, Bid)
        Dim row As DataRow
        Dim dt As DateTime = Today
        For Each row In ds.Tables(0).Rows
            If IsDBNull(row("DOL")) Then
                dt = row("DOL")
            End If
            emp.Add(New Employee(row("Emp_Name"), row("Emp_code"), row("Category"), row("Employment_Type"), row("DOB"), row("DOJ"), dt, row("Designation"), row("Branch_ID"), row("Institute_ID"), row("Dept_ID"), row("Salary"), row("AccountNo"), row("Bank_ID"), row("Emp_Address"), row("Emp_City"), row("Zip"), row("State"), row("Country"), row("Contact_No1"), row("Contact_No2"), row("Email"), row("Emp_Id"), row("Photos"), row("ITCategory"), row("District"), row("UniqueCode"), row("TransferTo")))
        Next
        Return emp
    End Function
    Public Function GetCategory(ByVal dept As Integer) As Data.DataTable
        Dim DAL As New EmployeeDB
        Return DAL.GetCategory(dept)
    End Function
    Public Function GetEmpIdByYCode(ByVal code As String, ByVal inst As Long, ByVal brch As Long) As Data.DataTable
        Return EmployeeDB.GetEmpID(code, inst, brch)
    End Function
    Public Function GetEmpComboDB(ByVal id As Int32) As List(Of DayBookPartyName)
        Dim em As New List(Of DayBookPartyName)
        Dim ds As DataSet = EmployeeDB.GetEmpComboDayBook(0)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        For Each row In ds.Tables(0).Rows
            em.Add(New DayBookPartyName(row("Name"), row("Id")))
        Next
        Return em
    End Function
    Public Function GetEmpComboDBID(ByVal id As Int32) As DayBookPartyName
        Try
            Dim em As DayBookPartyName
            Dim ds As DataSet = EmployeeDB.GetEmpComboDayBook(id)
            Dim row As DataRow = ds.Tables(0).Rows(0)
            em = New DayBookPartyName(row("Name"), row("Id"))
            Return em
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function RptGVDetails(ByVal inst As Int64, ByVal brch As Int64) As Data.DataTable
        Return EmployeeDB.RptGVDetails(inst, brch)
    End Function
    Public Function UpdateTransferTo(ByVal E As Employee) As Integer
        Return EmployeeDB.UpdateTransferTo(E)
    End Function
    Public Function GetEmpidDetails(ByVal empId As Integer, ByVal inst As Int64, ByVal brch As Int64) As Data.DataTable
        Return EmployeeDB.GetEmpidDetails(empId, inst, brch)
    End Function
    Public Function GetCategoryDetails(ByVal dept As Integer, ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
        Return EmployeeDB.GetCategoryDetails(dept, Inst, Brch)
    End Function
End Class
