Imports Microsoft.VisualBasic

Public Class BLSemesterResultTable
    Dim DL As New DLSemesterResultTable
    Public Function InsertSemesterTable(ByVal EL As ELSemesterResultTable) As Integer
        Return DLSemesterResultTable.InsertSemesterTable(EL)
    End Function
    Public Function ViewSemesterTable(ByVal EL As ELSemesterResultTable) As Data.DataTable
        Return DLSemesterResultTable.ViewSemesterTable(EL)
    End Function
    Public Function CheckLockMarks(ByVal m As ELSemesterResultTable) As DataSet
        Return DLSemesterResultTable.CheckLockMarks(m)
    End Function
    Public Function LockStdMarks(ByVal m As ELSemesterResultTable) As Integer
        Return DLSemesterResultTable.LockStdMarks(m)
    End Function
    Public Function UNLockStdMarks(ByVal m As ELSemesterResultTable) As Integer
        Return DLSemesterResultTable.UNLockStdMarks(m)
    End Function
End Class
