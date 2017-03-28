Imports Microsoft.VisualBasic

Public Class TimeSheetBL
    Public Function InsertRecord(ByVal TP As TimeSheetEL) As Integer
        Return TimeSheetDL.Insert(TP)
    End Function
    Public Function GetTimeSheet(ByVal TP As TimeSheetEL) As DataTable
        Return TimeSheetDL.GetTimeSheet(TP)
    End Function

    Public Function UpdateRecord(ByVal TP As TimeSheetEL) As Integer
        Return TimeSheetDL.Update(TP)
    End Function
    Public Function ChangeFlag(ByVal TP As TimeSheetEL) As Integer
        Return TimeSheetDL.ChangeFlag(TP)
    End Function
End Class
