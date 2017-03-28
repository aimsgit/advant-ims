Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class RoomTypeB
    Dim tc As New RoomTypeD
    Public Function InsertRecord(ByVal EL As RoomTypeE) As Integer
        Return tc.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As RoomTypeE) As Integer
        Return tc.Update(EL)
    End Function

    Public Function GetRoomType(ByVal EL As RoomTypeE) As Data.DataTable
        Return tc.GetRoomType(EL)
    End Function

    Public Function DeleteRecord(ByVal EL As RoomTypeE) As Integer
        Return tc.Delete(EL)
    End Function
    Public Function CheckDuplicate(ByVal s As RoomTypeE) As System.Data.DataTable
        Return tc.CheckDuplicate(s)
    End Function
End Class

