Imports Microsoft.VisualBasic

Public Class BLExchangeRateTable
    Public Function Insert(ByVal EL As ELExchangeRateTable) As Integer
        Return DLExchangeRateTable.Insert(EL)
    End Function
    Public Function GetData(ByVal EL As ELExchangeRateTable) As Data.DataTable
        Return DLExchangeRateTable.GetData(EL)
    End Function
    Public Function Update(ByVal EL As ELExchangeRateTable) As Integer
        Return DLExchangeRateTable.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELExchangeRateTable) As Integer
        Return DLExchangeRateTable.ChangeFlag(EL)
    End Function
    Public Function GetDuplicate(ByVal EL As ELExchangeRateTable) As DataTable
        Return DLExchangeRateTable.GetDuplicateType(EL)
    End Function
End Class
