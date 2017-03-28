Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BHolidayMaster
    Dim dh As New DHolidayMaster
    Public Function GetHolidayMaster(ByVal el As EHolidayMaster) As System.Data.DataTable

        Return DHolidayMaster.getHolidayMaster(el)

    End Function
    Public Function InsertRecord(ByVal el As EHolidayMaster) As Integer

        Return DHolidayMaster.Insert(el)
    End Function
    Public Function UpdateRecord(ByVal el As EHolidayMaster) As Integer
        Return DHolidayMaster.Update(el)
    End Function
    Public Function ChangeFlag(ByVal el As EHolidayMaster) As Integer
        
        Return DHolidayMaster.ChangeFlag(el.Id)
    End Function
    Public Function CheckDuplicate(ByVal el As EHolidayMaster) As System.Data.DataTable
        Return dh.CheckDuplicate(el)
    End Function

End Class
