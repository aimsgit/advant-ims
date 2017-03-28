Imports Microsoft.VisualBasic

Public Class BLPayrollRulesEngine
    Dim DL As New DLPayrollRulesEngine
    Public Function UpdateRecord(ByVal EL As ELPayrollRulesEngine) As Integer
        Return DLPayrollRulesEngine.Update(EL)
    End Function
    Public Function UpdateRecord1(ByVal EL As ELPayrollRulesEngine) As Integer
        Return DLPayrollRulesEngine.Update1(EL)
    End Function
    Public Function clearupdate(ByVal EL As ELPayrollRulesEngine) As Integer
        Return DLPayrollRulesEngine.clearupdate(EL)
    End Function
    Public Function updateNetGross(ByVal EL As ELPayrollRulesEngine) As Integer
        Return DLPayrollRulesEngine.updateNetGross(EL)
    End Function
    Public Function updateNetGross1(ByVal EL As ELPayrollRulesEngine) As Integer
        Return DLPayrollRulesEngine.updateNetGross1(EL)
    End Function
    Public Function SaveFormula(ByVal EL As ELPayrollRulesEngine) As Integer
        Return DLPayrollRulesEngine.SaveFormula(EL)
    End Function
    Public Function UpdateFormula(ByVal EL As ELPayrollRulesEngine) As Integer
        Return DLPayrollRulesEngine.UpdateFormula(EL)
    End Function
    Public Sub delete(ByVal EL As ELPayrollRulesEngine)
        DL.delete(EL)
    End Sub
    Public Function updateMonthPayClear(ByVal EL As ELPayrollRulesEngine) As Integer
        Return DLPayrollRulesEngine.updateMonthPayClear(EL)
    End Function
End Class
