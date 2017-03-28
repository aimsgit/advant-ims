Imports Microsoft.VisualBasic

Public Class AssessmentB
    Dim DAL As New AssessmentD
    Public Function InsertRecord(ByVal name As String, ByVal SeqNo As Integer) As Integer
        Return DAL.Insert(name, SeqNo)
    End Function

    Public Function UpdateRecord(ByVal EL As Assessment) As Integer
        Return DAL.Update(EL)
    End Function

    Public Function ChangeFlag(ByVal id As Int64) As Integer
        Return DAL.Delete(id)
    End Function

    Public Function getRecords(ByVal id As Integer) As Data.DataTable
        Return DAL.Getrecords(id)
    End Function

    Public Function GetDuplicateCertificateMaster(ByVal EL As Assessment) As DataTable
        Return DAL.GetDuplicateCertificateMaster(EL)
    End Function

End Class
