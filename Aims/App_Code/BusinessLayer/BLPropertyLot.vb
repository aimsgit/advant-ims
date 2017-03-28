Imports Microsoft.VisualBasic

Public Class BLPropertyLot
    Public Function InsertRecord(ByVal EL As ELProperty) As Integer
        Return DLPropertyLot.InsertRecord(EL)
    End Function
    Public Function GetRecord(ByVal EL As ELProperty) As DataTable
        Return DLPropertyLot.GetRecord(EL)
    End Function
    Public Function Update(ByVal EL As ELProperty) As Integer
        Return DLPropertyLot.Update(EL)
    End Function
    Public Function Delete(ByVal EL As ELProperty) As Integer
        Return DLPropertyLot.Delete(EL)
    End Function
    Public Function CheckDuplicate(ByVal EL As ELProperty) As DataTable
        Return DLPropertyLot.CheckDuplicate(EL)
    End Function
    Public Function DDlData() As DataTable
        Return DLPropertyLot.DDlData()
    End Function
End Class
