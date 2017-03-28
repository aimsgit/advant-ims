Imports Microsoft.VisualBasic

Public Class BLCompanyRegister
    Dim DL As New DLCompanyRegister
    Public Function GetCompanyRegister(ByVal el As ELCompanyRegister) As System.Data.DataTable

        Return DLCompanyRegister.GetCompanyRegister(el)

    End Function
    Public Function InsertCompanyRegister(ByVal el As ELCompanyRegister) As Integer

        Return DLCompanyRegister.InsertCompanyRegister(el)
    End Function
    Public Function UpdateCompanyRegister(ByVal el As ELCompanyRegister) As Integer
        Return DLCompanyRegister.UpdateCompanyRegister(el)
    End Function
    Public Function ChangeFlagCompanyRegister(ByVal el As ELCompanyRegister) As Integer

        Return DLCompanyRegister.ChangeFlagCompanyRegister(el.Id)
    End Function
    Public Function CheckDuplicateCompanyRegister(ByVal EL As ELCompanyRegister) As DataTable
        Return DL.CheckDuplicateCompanyRegister(EL)
    End Function
    Public Function GetKDM(ByVal el As ELCompanyRegister) As System.Data.DataTable

        Return DLCompanyRegister.GetKDM(el)

    End Function
    Public Function InsertKDM(ByVal el As ELCompanyRegister) As Integer

        Return DLCompanyRegister.InsertKDM(el)
    End Function
    Public Function UpdateKDM(ByVal el As ELCompanyRegister) As Integer
        Return DLCompanyRegister.UpdateKDM(el)
    End Function
    Public Function ChangeFlagKDM(ByVal el As ELCompanyRegister) As Integer

        Return DLCompanyRegister.ChangeFlagKDM(el)
    End Function
    Public Function CheckKDM(ByVal EL As ELCompanyRegister) As DataTable
        Return DL.CheckKDM(EL)

    End Function
    Public Function GetSalaryStructure(ByVal el As ELCompanyRegister) As System.Data.DataTable

        Return DLCompanyRegister.GetSalaryStructure(el)

    End Function
    Public Function InsertSalaryStructure(ByVal el As ELCompanyRegister) As Integer

        Return DLCompanyRegister.InsertSalaryStructure(el)
    End Function
    Public Function UpdateSalaryStructure(ByVal el As ELCompanyRegister) As Integer
        Return DLCompanyRegister.UpdateSalaryStructure(el)
    End Function
    Public Function ChangeFlagSalaryStructure(ByVal el As ELCompanyRegister) As Integer

        Return DLCompanyRegister.ChangeFlagSalaryStructure(el)
    End Function
    Public Function CheckDuplicateSalaryStructure(ByVal EL As ELCompanyRegister) As DataTable
        Return DL.CheckDuplicateSalaryStructure(EL)

    End Function
End Class
