Imports Microsoft.VisualBasic

Public Class BLFacutlyDevelopment
    Dim DL As New DLFacutlyDevelopment
    Public Function InsertRecord(ByVal EN As ELFacutlyDevelopment) As Integer
        Return DLFacutlyDevelopment.Insert(EN)
    End Function
    Public Function UpdateRecord(ByVal EN As ELFacutlyDevelopment) As Integer
        Return DLFacutlyDevelopment.Update(EN)
    End Function
    Public Function Display(ByVal EN As ELFacutlyDevelopment) As Data.DataTable
        Return DLFacutlyDevelopment.DisplayGridValue(EN)
    End Function
    Public Function ChangeFlag(ByVal EN As ELFacutlyDevelopment) As Integer
        Return DLFacutlyDevelopment.ChangeFlag(EN)
    End Function
    'Public Function CheckDuplicate(ByVal EN As ELFacutlyDevelopment) As Data.DataTable
    '    Return DLFacutlyDevelopment.Duplicate(EN)
    'End Function

End Class
