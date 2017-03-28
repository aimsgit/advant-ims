Imports Microsoft.VisualBasic

Public Class BLEarnDed
    Public Function InsertRecord(ByVal EN As ELEarnDed) As Integer
        Return DLEarnDed.Insert(EN)
    End Function
    Public Function GetGridData(ByVal EL As ELEarnDed) As DataTable
        Return DLEarnDed.GetGridData(EL)
    End Function
    Public Function ChangeFlag(ByVal EN As ELEarnDed) As Integer
        Return DLEarnDed.ChangeFlag(EN)
    End Function
    Public Function UpdateRecord(ByVal EL As ELEarnDed) As Integer
        Return DLEarnDed.Update(EL)
    End Function

End Class
