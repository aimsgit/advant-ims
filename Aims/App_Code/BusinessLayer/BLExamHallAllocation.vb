Imports Microsoft.VisualBasic

Public Class BLExamHallAllocation
    Dim DL As New DLExamhallAllocation
    Public Function InsertRecord(ByVal EN As ELExamHallAllocation) As Integer
        Return DLExamhallAllocation.Insert(EN)
    End Function
    Public Function UpdateRecord(ByVal EN As ELExamHallAllocation) As Integer
        Return DLExamhallAllocation.Update(EN)
    End Function
    Public Function Display(ByVal EN As ELExamHallAllocation) As Data.DataTable
        Return DLExamhallAllocation.DisplayGridValue(EN)
    End Function
    Public Function ChangeFlag(ByVal EN As ELExamHallAllocation) As Integer
        Return DLExamhallAllocation.ChangeFlag(EN)
    End Function

    Public Function CheckDuplicate(ByVal EN As ELExamHallAllocation) As Data.DataTable
        Return DLExamhallAllocation.CheckDuplicate(EN)
    End Function

    Public Function ChangeFlagMap(ByVal EN As ELExamHallAllocation) As Integer
        Return DLExamhallAllocation.ChangeFlagReg(EN)
    End Function
End Class
