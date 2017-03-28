Imports Microsoft.VisualBasic

Public Class CompanyManagerB
    Dim DAL As New CompanyDB1
    Public Function InsertRecord(ByVal EL As CompanyDetails) As Integer
        Return CompanyDB1.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As CompanyDetails) As Integer
        Return CompanyDB1.Update(EL)
    End Function

    Public Function ChangeFlag(ByVal id As Int64) As Integer
        Return DAL.Delete(id)
    End Function

    Public Function GetRecords(ByVal id As Integer) As Data.DataTable
        Return DAL.Getrecords(id)
    End Function

    Public Function GetDuplicateCertificateMaster(ByVal EL As CompanyDetails) As DataTable
        Return DAL.GetDuplicateCertificateMaster(EL)
    End Function

End Class
