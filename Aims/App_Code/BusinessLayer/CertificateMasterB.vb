Imports Microsoft.VisualBasic

Public Class CertificateMasterB
    Dim DAL As New CertificateMasterDB
    Public Function InsertRecord(ByVal Name As String) As Integer
        Return DAL.Insert(Name)
    End Function

    Public Function UpdateRecord(ByVal EL As CertificateMasterP) As Integer
        Return DAL.Update(EL)
    End Function

    Public Function ChangeFlag(ByVal id As Int64) As Integer
        Return DAL.Delete(id)
    End Function

    Public Function getRecords(ByVal id As Integer) As Data.DataTable
        Return DAL.Getrecords(id)
    End Function

    'Public Function GetCertificateDetail(ByVal stdId As Int32, ByVal Batch_No As Int32, ByVal Course_ID As Int32, ByVal Institute_ID As Int32, ByVal Branch_ID As Int32) As DataTable
    '    Return DAL.GetCertificateDetail(stdId, Batch_No, Course_ID, Institute_ID, Branch_ID)
    'End Function
   
    Public Function GetDuplicateCertificateMaster(ByVal EL As CertificateMasterP) As DataTable
        Return DAL.GetDuplicateCertificateMaster(EL)
    End Function

End Class
