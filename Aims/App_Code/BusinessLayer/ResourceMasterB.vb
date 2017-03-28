Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class ResourceMasterB
    Dim acy As New ResourceDl
    Public Function InsertRecord(ByVal EL As ElResourceMaster) As Integer
        Return ResourceDl.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As ElResourceMaster) As Integer
        Return ResourceDl.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ElResourceMaster) As Integer
        Return ResourceDl.ChangeFlag(EL)
    End Function
   
    Public Function GetResource(ByVal EL As ElResourceMaster) As DataTable
        Return ResourceDl.GetGridData(EL)
    End Function

    Public Function GetDuplicateResource(ByVal EL As ElResourceMaster) As DataTable
        Return acy.GetDuplicateResource(EL)
    End Function

End Class
