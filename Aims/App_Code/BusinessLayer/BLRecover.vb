Imports Microsoft.VisualBasic

Public Class BLRecover
    Dim DAL As New RecoverDB
    Public Function RecoverTimeTable(ByVal ID As Int64) As Int16
        Return DAL.RecoverTimeTable(ID)
    End Function
    Public Function TimeTableGridFill() As Data.DataTable
        Return DAL.TimeTableGridFill
    End Function
End Class
