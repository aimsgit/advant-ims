Imports Microsoft.VisualBasic

Public Class BLEligiblityPromotion
    Dim DL As New DLEligiblityPromotion
    Shared Function getduplicate(ByVal EL As ELEligiblityPromotion) As DataTable
        Return DLEligiblityPromotion.getduplicate(EL)
    End Function
    Shared Function generate(ByVal EL As ELEligiblityPromotion) As Integer
        Return DLEligiblityPromotion.generate(EL)
    End Function

    Public Function InsertStudent(ByVal EL As ELEligiblityPromotion) As Integer
        Return DL.InsertStudent(EL)
    End Function
    Shared Function GetData(ByVal EL As ELEligiblityPromotion) As DataTable
        Return DLEligiblityPromotion.GetData(EL)
    End Function
    Public Function GetResult(ByVal EL As ELEligiblityPromotion) As DataTable
        Return DL.GetResult(EL)
    End Function

    Public Function UndoStudent(ByVal EL As ELEligiblityPromotion) As Integer
        Return DL.UndoStudent(EL)
    End Function
End Class
