Imports Microsoft.VisualBasic

Public Class BHostelMaster11

    Dim dh As New DHostelMaster11
    Public Function GetHostelMaster(ByVal el As EHostelMaster11) As System.Data.DataTable

        Return DHostelMaster11.getHostelMaster(el)

    End Function
    Public Function InsertRecord(ByVal el As EHostelMaster11) As Integer

        Return DHostelMaster11.Insert(el)
    End Function
    Public Function UpdateRecord(ByVal el As EHostelMaster11) As Integer
        Return DHostelMaster11.Update(el)
    End Function
    Public Function ChangeFlag(ByVal el As EHostelMaster11) As Integer

        Return DHostelMaster11.ChangeFlag(el.Id)
    End Function
    Public Function CheckDuplicate(ByVal EL As EHostelMaster11) As DataTable
        Return dh.CheckDuplicate(EL)

    End Function

End Class
