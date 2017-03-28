Imports Microsoft.VisualBasic

Public Class BLTransportationMfg
    Dim DAL As New DLTransportationMfg
    Public Function InsertRecord(ByVal EL As ELTransportaionMfg) As Integer
        Return DAL.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As ELTransportaionMfg) As Integer
        Return DAL.Update(EL)
    End Function

    Public Function ChangeFlag(ByVal id As Int64) As Integer
        Return DAL.Delete(id)
    End Function

    Public Function getRecords(ByVal EL As ELTransportaionMfg) As Data.DataTable
        Return DAL.Getrecords(EL)
    End Function

    Public Function GetDuplicateCertificateMaster(ByVal EL As ELTransportaionMfg) As DataTable
        Return DAL.GetDuplicateCertificateMaster(EL)
    End Function
End Class
