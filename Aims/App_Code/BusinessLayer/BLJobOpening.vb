Imports Microsoft.VisualBasic

Public Class BLJobOpening
    Dim DL As New DLJobOpening
    Public Function GetJobOpening(ByVal el As ELJobOpening) As System.Data.DataTable

        Return DLJobOpening.GetJobOpening(el)

    End Function
    Public Function InsertJobOpening(ByVal el As ELJobOpening) As Integer

        Return DLJobOpening.InsertJobOpening(el)
    End Function
    Public Function UpdateJobOpening(ByVal el As ELJobOpening) As Integer
        Return DLJobOpening.UpdateJobOpening(el)
    End Function
    Public Function ChangeFlagJobOpening(ByVal el As ELJobOpening) As Integer

        Return DLJobOpening.ChangeFlagJobOpening(el.Id)
    End Function
    'Public Function CheckDuplicateJobOpening(ByVal EL As ELJobOpening) As DataTable
    '    Return DL.CheckDuplicateCompanyRegister(EL)
    'End Function
End Class
