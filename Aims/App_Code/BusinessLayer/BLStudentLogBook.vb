Imports Microsoft.VisualBasic

Public Class BLStudentLogBook
    'Code Written By : Niraj on 15 june 2013
    Dim DL As New DLStudentLogBook
    Public Function GetLecturercombo() As Data.DataTable
        Return DLStudentLogBook.GetLecturercombo()
    End Function
    Public Function InsertRecord(ByVal EN As ELStudentLogBook) As Integer
        Return DLStudentLogBook.Insert(EN)
    End Function
    Public Function UpdateRecord(ByVal EN As ELStudentLogBook) As Integer
        Return DLStudentLogBook.Update(EN)
    End Function
    Public Function Display(ByVal EN As ELStudentLogBook) As Data.DataTable
        Return DLStudentLogBook.DisplayGridValue(EN)
    End Function
    Public Function ChangeFlag(ByVal EN As ELStudentLogBook) As Integer
        Return DLStudentLogBook.ChangeFlag(EN)
    End Function
    Public Function InsertRecordEmp(ByVal EN As ELEmployeeLogBook) As Integer
        Return DLStudentLogBook.InsertEmployeeLog(EN)
    End Function
    Public Function UpdateRecordEmp(ByVal EN As ELEmployeeLogBook) As Integer
        Return DLStudentLogBook.UpdateEmployeeLog(EN)
    End Function
    Public Function DisplayEmp(ByVal EN As ELEmployeeLogBook) As Data.DataTable
        Return DLStudentLogBook.DisplayEmployeeGridValue(EN)
    End Function
    Public Function ChangeFlagEmp(ByVal EN As ELEmployeeLogBook) As Integer
        Return DLStudentLogBook.ChangeFlagEmpLog(EN)
    End Function
    
End Class
