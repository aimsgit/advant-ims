Imports Microsoft.VisualBasic

Public Class BLMultilingual
    Dim DL As New DLMultilingual
    Public Function InsertRecord(ByVal EN As ELMultilingual) As Integer
        Return DLMultilingual.Insert(EN)
    End Function
    Public Function UpdateRecord(ByVal EN As ELMultilingual) As Integer
        Return DLMultilingual.Update(EN)
    End Function
    Public Function Display(ByVal EN As ELMultilingual) As Data.DataTable
        Return DLMultilingual.DisplayGridValue(EN)
    End Function
    Public Function ChangeFlag(ByVal EN As ELMultilingual) As Integer
        Return DLMultilingual.ChangeFlag(EN)
    End Function
    '' For Branch Specific Label
    Public Function InsertLabelRecord(ByVal EN As ELMultilingual) As Integer
        Return DLMultilingual.InsertLabel(EN)
    End Function
    Public Function UpdateLabelRecord(ByVal EN As ELMultilingual) As Integer
        Return DLMultilingual.UpdateLabel(EN)
    End Function
    Public Function DisplayLabel(ByVal EN As ELMultilingual) As Data.DataTable
        Return DLMultilingual.DisplayLabelGrid(EN)
    End Function
    Public Function ChangeLabelFlag(ByVal EN As ELMultilingual) As Integer
        Return DLMultilingual.ChangeLabelFlag(EN)
    End Function
End Class
