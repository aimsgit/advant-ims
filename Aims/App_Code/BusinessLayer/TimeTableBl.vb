Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class TimeTableBl
    Dim Dl As New TimeTableDl

    Public Function InsertRecord(ByVal EL As TimeTableEL) As Integer
        Return Dl.insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As TimeTableEL) As Integer
        Return TimeTableDl.Update(EL)
    End Function
    Public Function DeleteRecord(ByVal id As Integer) As Integer
        Return Dl.Delete(id)
    End Function
    Public Function GetData(ByVal EL As TimeTableEL) As DataTable
        Return Dl.GetData(EL)
    End Function

    Public Function GetDuplicatedata(ByVal EL As TimeTableEL) As DataTable
        Return TimeTableDl.GetDuplicatedata(EL)
    End Function

    Public Function ViewRecord(ByVal El As TimeTableEL) As DataTable
        Return Dl.ViewRecord(El)
    End Function
    Public Function ViewRecord1(ByVal El As TimeTableEL) As DataTable
        Return Dl.ViewRecord1(El)
    End Function

    Public Function ViewHolidayRecord(ByVal El As TimeTableEL) As DataTable
        Return Dl.ViewHolidayRecord(El)
    End Function

End Class
