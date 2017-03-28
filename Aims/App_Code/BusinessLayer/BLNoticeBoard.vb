Imports Microsoft.VisualBasic

Public Class BLNoticeBoard
    Dim DL As New DLNoticeBoard
    Public Function GetNotice(ByVal el As ELCommunication) As DataTable
        Return DL.GetNotice(el)
    End Function
End Class
