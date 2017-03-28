Imports Microsoft.VisualBasic

Public Class BLDoubleEntry
    Dim DL As New DLDoubleEntry
    Public Function InsertRecord(ByVal EL As ELDoubleEntry) As Integer
        Return DLDoubleEntry.Insert(EL)
    End Function
    Public Function InsertRecord1(ByVal EL As ELDoubleEntry) As Integer
        Return DLDoubleEntry.Insert1(EL)
    End Function
    Public Function UpdateRecord(ByVal EL As ELDoubleEntry) As Integer
        Return DLDoubleEntry.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELDoubleEntry) As Integer
        Return DLDoubleEntry.ChangeFlag(EL)
    End Function
    Public Function GetGridData(ByVal Id As Integer) As DataTable
        Return DLDoubleEntry.GetGridData(Id)
    End Function
    Public Function GetGridData1(ByVal Id As Integer) As DataTable
        Return DLDoubleEntry.GetGridData1(Id)
    End Function
    Public Function GetNo() As DataTable
        Return DLDoubleEntry.GetNo()
    End Function

    Public Function GetDuplicateYear(ByVal EL As String, ByVal id As Integer) As DataTable
        Return DL.GetDuplicateAcademicYear(EL, id)
    End Function
End Class
