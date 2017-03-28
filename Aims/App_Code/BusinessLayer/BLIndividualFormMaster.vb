Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class BLIndividualFormMaster
    Public Function GetIndividualFormMaster(ByVal Indi As IndividualFormMaster) As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Retrieving the data
        Return DLIndividualFormMaster.GetIndividualFormMasterDetails(Indi)
    End Function
    Public Function GetENPLOYEEDetails(ByVal Indi As IndividualFormMaster) As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Retrieving the data
        Return DLIndividualFormMaster.GetENPLOYEEDetails(Indi)
    End Function
    Public Function GetENPLOYEEDetails2(ByVal Indi As IndividualFormMaster) As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Retrieving the data
        Return DLIndividualFormMaster.GetENPLOYEEDetails2(Indi)
    End Function
    Public Function GetENPLOYEECategory(ByVal Indi As IndividualFormMaster) As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Retrieving the data
        Return DLIndividualFormMaster.GetEmployeeCategry(Indi)
    End Function
    Public Function InsertRecord(ByVal Ind As IndividualFormMaster) As Integer
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into table
        Return DLIndividualFormMaster.Insert(Ind)
    End Function
    Public Function UpdateRecord(ByVal Ind As IndividualFormMaster) As Integer
        '24-11-2010 Kusum.C.Akki. Function for Updating the data into table'
        Return DLIndividualFormMaster.Update(Ind)
    End Function
    Public Function UpdateRecordDetails(ByVal Ind As IndividualFormMaster) As Integer
        '24-11-2010 Kusum.C.Akki. Function for Updating the data into table'
        Return DLIndividualFormMaster.UpdateDetails(Ind)
    End Function
    Public Function Delete(ByVal id As Long) As Integer
        '24-11-2010 Kusum.C.Akki. Function for Deleting the data
        Return DLIndividualFormMaster.Delete(id)
    End Function
    'Public Function GetDistrictDDL() As Data.DataSet
    '    '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
    '    Dim district As New List(Of IndividualFormMaster)
    '    Dim ds As DataSet = DLIndividualFormMaster.GetDistrict()
    '    Return ds
    'End Function
    Public Function GetDeptTypeDDL() As Data.DataSet
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        'Dim depttype As New List(Of IndividualFormMaster)
        Dim ds As DataSet = DLIndividualFormMaster.GetDeptType()
        Return ds
    End Function
    Public Function GetDeptNameDDL(ByVal DNDDL As String) As Data.DataSet
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        'Dim deptname As New List(Of IndividualFormMaster)
        Dim ds As DataSet = DLIndividualFormMaster.GetDeptName(DNDDL)
        Return ds
    End Function
    Public Function GetGrade() As Data.DataSet
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        'Dim deptname As New List(Of IndividualFormMaster)
        Dim ds As DataSet = DLIndividualFormMaster.GetGrade()
        Return ds
    End Function
    Public Function GetDesignation() As Data.DataSet
        Dim ds As DataSet = DLIndividualFormMaster.DDLDesigCombo()
        Return ds
    End Function
    Public Function GetDesignationOnBranch(ByVal BranchCode As String) As Data.DataSet
        Dim ds As DataSet = DLIndividualFormMaster.DDLDesigComboOnBranch(BranchCode)
        Return ds
    End Function
    Public Function Getdesigddl(ByVal indmaster As IndividualFormMaster) As DataTable
        Return DLIndividualFormMaster.Getddldesig(indmaster)
    End Function
    Public Function Getdeptcombo(ByVal BranchTypeCode As String) As DataTable
        Return DLIndividualFormMaster.Getdeptcombo(BranchTypeCode)
    End Function
    Public Function Getdeptcombo2() As DataTable
        Return DLIndividualFormMaster.GetBranchNameC()
    End Function
    
    Public Function GetBranchCobo() As DataTable
        Return DLIndividualFormMaster.GetBranchCobo()
    End Function
    Public Function CheckDuplicate(ByVal indmaster As IndividualFormMaster) As DataTable
        Return DLIndividualFormMaster.CheckDuplicate(indmaster)
    End Function
    Public Function GetddlDept() As DataTable
        Return DLIndividualFormMaster.Getddldept()
    End Function

End Class
