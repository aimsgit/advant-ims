Imports Microsoft.VisualBasic

Public Class BLfrmDataBackupCenterWise
    Dim DL As New DLfrmDataBackupCenterWise
    Public Function insertBranch() As DataTable
        Return DL.insertBranch()
    End Function

    Public Function GetGridData(ByVal el As ELfrmDataBackupCenterWise) As DataTable
        Return DL.GetGridData(el)
    End Function
End Class
