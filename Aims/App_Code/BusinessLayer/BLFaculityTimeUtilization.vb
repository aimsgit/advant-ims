Imports Microsoft.VisualBasic

Public Class BLFaculityTimeUtilization
    Dim dill As New DLFaculityTimeUtilize
    Public Function InsertRecord(ByVal i As ELFaculityTimeUtilization) As Integer
        Return dill.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As ELFaculityTimeUtilization) As Integer
        Return dill.Update(i)
    End Function
    Public Function getFaculityTime(ByVal id As ELFaculityTimeUtilization) As Data.DataTable
        Return dill.getFaculityTime(id)
    End Function
    Public Function DeleteFaculityTime(ByVal s As ELFaculityTimeUtilization) As Integer
        Return dill.DeleteFaculityTime(s)
    End Function
    Public Function CheckDuplicate(ByVal s As ELFaculityTimeUtilization) As System.Data.DataTable
        Return dill.CheckDuplicate(s)
    End Function
End Class
