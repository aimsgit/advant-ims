Imports Microsoft.VisualBasic

Public Class BLEndowment
    Dim DL As New DLEndowment
    Public Function InsertRecord(ByVal EN As ELEndowment) As Integer
        Return DLEndowment.Insert(EN)
    End Function
    Public Function UpdateRecord(ByVal EN As ELEndowment) As Integer
        Return DLEndowment.Update(EN)
    End Function
    Public Function Display(ByVal EN As ELEndowment) As Data.DataTable
        Return DLEndowment.DisplayGridValue(EN)
    End Function
    Public Function CheckDuplicate(ByVal EN As ELEndowment) As Data.DataTable
        Return DL.Duplicate(EN)
    End Function

End Class
