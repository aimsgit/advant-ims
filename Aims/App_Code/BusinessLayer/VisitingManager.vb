Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class VisitingManager
    
    Public Function GetVisiting(ByVal v As Visiting) As Data.DataTable
        Return VisitingDB.DispGrid(v)
    End Function
    Public Function InsertRecord(ByVal v As Visiting) As Integer
        Return VisitingDB.Insert(v)
    End Function
    Public Function UpdateRecord(ByVal v As Visiting) As Integer
        Return VisitingDB.Update(v)
    End Function
    Public Function ChangeFlag(ByVal v As Visiting) As Integer
        Return VisitingDB.ChangeFlag(v)
    End Function
   
End Class
