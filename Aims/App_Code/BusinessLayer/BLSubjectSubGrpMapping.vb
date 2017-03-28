Imports Microsoft.VisualBasic

Public Class BLSubjectSubGrpMapping
    Dim DL As New DLSubjectSubGrpMapping
    Shared Function generate(ByVal EL As ELSubjectSubGrpMapping) As Integer

        Return DLSubjectSubGrpMapping.generate(EL)
    End Function
    Shared Function getduplicate(ByVal EL As ELSubjectSubGrpMapping) As DataTable

        Return DLSubjectSubGrpMapping.getduplicate(EL)
    End Function

    Shared Function clear(ByVal EL As ELSubjectSubGrpMapping) As Integer

        Return DLSubjectSubGrpMapping.clear(EL)
    End Function
    Shared Function GetData(ByVal EL As ELSubjectSubGrpMapping) As DataTable

        Return DLSubjectSubGrpMapping.GetData(EL)
    End Function
    Shared Function Update(ByVal EL As ELSubjectSubGrpMapping, ByVal ID As String) As Integer

        Return DLSubjectSubGrpMapping.Update(EL, ID)
    End Function
    Shared Function Lock(ByVal EL As ELSubjectSubGrpMapping) As Integer

        Return DLSubjectSubGrpMapping.Lock(EL)
    End Function
    Shared Function CheckLock(ByVal EL As ELSubjectSubGrpMapping) As DataTable

        Return DLSubjectSubGrpMapping.CheckLock(EL)
    End Function
End Class
