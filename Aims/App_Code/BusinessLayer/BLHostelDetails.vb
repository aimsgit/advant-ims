Imports Microsoft.VisualBasic

Public Class BLHostelDetails
    Dim DL As New DLHostelDetails
    Public Function GetHostelDetails(ByVal el As ELHostelDetails) As System.Data.DataTable

        Return DLHostelDetails.GetGridData(el)

    End Function
    Public Function NoOfOccupants(ByVal el As ELHostelDetails) As System.Data.DataTable

        Return DLHostelDetails.NoOfOccupants(el)

    End Function
    Public Function GetHostelName(ByVal el As ELHostelDetails) As System.Data.DataTable

        Return DLHostelDetails.GethostelName(el)

    End Function
    Public Function Insert(ByVal el As ELHostelDetails) As Integer

        Return DLHostelDetails.Insert(el)
    End Function
    Public Function Update(ByVal el As ELHostelDetails) As Integer
        Return DLHostelDetails.Update(el)
    End Function
    Public Function ChangeFlag(ByVal el As ELHostelDetails) As Integer

        Return DLHostelDetails.ChangeFlag(el)
    End Function
    Public Function CheckDuplicate(ByVal EL As ELHostelDetails) As DataTable
        Return DL.CheckDuplicate(EL)

    End Function

End Class
