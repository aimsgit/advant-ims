Imports Microsoft.VisualBasic

Public Class BLSourceOfInfo
    Dim DL As New DLSourceOfInfo
    Public Function InsertRecord(ByVal EL As ELSourceOfInfo) As Integer
        Return DLSourceOfInfo.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As ELSourceOfInfo) As Integer
        Return DLSourceOfInfo.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELSourceOfInfo) As Integer
        Return DLSourceOfInfo.ChangeFlag(EL)
    End Function
    Public Function GetData(ByVal EL As ELSourceOfInfo) As Data.DataTable
        Return DLSourceOfInfo.GetData(EL)
    End Function
    Public Function GetDuplicatedata(ByVal EL As ELSourceOfInfo) As DataTable
        Return DL.GetDuplicatedata(EL)
    End Function
End Class
