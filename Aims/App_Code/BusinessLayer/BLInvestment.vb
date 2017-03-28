Imports Microsoft.VisualBasic

Public Class BLInvestment

    Public Function InsertRecord(ByVal c As ELInvestment) As Integer
        Return InvestmentDB.Insert(c)
    End Function

    Public Function EmpAutofill(ByVal Ent As ELInvestment) As Data.DataTable
        Return InvestmentDB.EmpAutofill(Ent)
    End Function
    Public Function displayrecord(ByVal c As ELInvestment)as Data.DataTable
        Dim dt As DataTable
        dt = InvestmentDB.displayrecord(c)
        Return dt
    End Function
    Public Function deleleinvestment(ByVal s As ELInvestment) As Integer
        Dim rowsaffected As Integer = InvestmentDB.deleleinvestment(s)
    End Function
End Class
