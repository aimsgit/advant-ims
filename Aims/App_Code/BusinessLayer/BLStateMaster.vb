Imports Microsoft.VisualBasic

Public Class BLStateMaster
    Dim d1 As New DLStateMaster
    Public Function InsertRecord(ByVal i As ELStateMaster) As Integer
        Return d1.Insert(i)
    End Function
    Public Function UpdateRecord(ByVal i As ELStateMaster) As Integer
        Return d1.Update(i)
    End Function


    Public Function CheckDuplicate(ByVal s As ELStateMaster) As System.Data.DataTable
        Return d1.CheckDuplicate(s)
    End Function
    Public Function GetState(ByVal s As ELStateMaster) As System.Data.DataTable
        Return d1.GetState(s)
    End Function
End Class
