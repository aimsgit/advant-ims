Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System
'Namespace BookReturnB
Public Class BookReturnB
    'Public Function InsertRecord(ByVal ELBookREturn As BookReturnP) As Integer
    '    Return BookReturnD.Ins - ert(ELBookREturn)
    'End Function
    Public Function GetBookReturn(ByVal ELBookREturn As BookReturnP) As Data.DataTable
        Return BookReturnD.GetBookReturn(ELBookREturn)
    End Function
    Public Function UpdateRecord(ByVal ELBookREturn As BookReturnP) As Integer
        Return BookReturnD.Update(ELBookREturn)
    End Function
    'Public Function ChangeFlag(ByVal ELBookREturn As BookReturnP) As Integer
    '    Return BookReturnD.ChangeFlag(ELBookREturn.id)
    'End Function
    'Public Function CheckDuplicate(ByVal ELBookREturn As BookReturnP) As Data.DataTable
    '    Return BookReturnD.CheckDuplicate(ELBookREturn)
    'End Function
    Public Function GetBookCodecombo(ByVal ELBookREturn As BookReturnP) As Data.DataTable
        Return BookReturnD.GetBookCodecombo(ELBookREturn)
    End Function
    Public Function GetBookName(ByVal ELBookREturn As BookReturnP) As Data.DataTable
        Return BookReturnD.GetBookName(ELBookREturn)
    End Function
End Class
