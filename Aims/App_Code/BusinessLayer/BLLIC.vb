Imports Microsoft.VisualBasic

Public Class BLLIC

    Dim DL As New DLLIC
    Public Function InsertRecord(ByVal EN As ELLIC) As Integer
        Return DLLIC.Insert(EN)
    End Function
    Public Function UpdateRecord(ByVal EN As ELLIC) As Integer
        Return DLLIC.Update(EN)
    End Function
    Public Function Display(ByVal EN As ELLIC) As Data.DataTable
        Return DLLIC.DisplayGridValue(EN)
    End Function
    Public Function ChangeFlag(ByVal EN As ELLIC) As Integer
        Return DLLIC.ChangeFlag(EN)
    End Function

End Class