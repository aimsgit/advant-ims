Imports Microsoft.VisualBasic

Public Class Mfg_BLShiftMaster
    Dim DL As New Mfg_DLShiftMaster
    Public Function InsertRecord(ByVal EL As Mfg_ELShiftMaster) As Integer
        Return Mfg_DLShiftMaster.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As Mfg_ELShiftMaster) As Integer
        Return Mfg_DLShiftMaster.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As Mfg_ELShiftMaster) As Integer
        Return Mfg_DLShiftMaster.ChangeFlag(EL)
    End Function

    Public Function GetGridData(ByVal Id As Integer) As DataTable
        Return Mfg_DLShiftMaster.GetGridData(Id)
    End Function

    Public Function GetDuplicateShift(ByVal EL As Mfg_ELShiftMaster) As DataTable
        Return DL.GetDuplicateShift(EL)
    End Function

End Class
