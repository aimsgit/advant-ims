Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class LetterPadManager

    Shared Function GetLetterPad(ByVal LetterPad As LetterPad) As Data.DataTable
        Return LetterPadDB.GetLetterPad(LetterPad)
    End Function
    Public Function InsertRecord(ByVal lp As LetterPad) As Integer
        Return LetterPadDB.Insert(lp)
    End Function
    Public Function UpdateRecord(ByVal lp As LetterPad) As Integer
        Return LetterPadDB.Update(lp)
    End Function
    Public Function ChangeFlag(ByVal Ref_ID As Int32) As Integer
        Return LetterPadDB.ChangeFlag(Ref_ID)

    End Function
    Public Function GetReport(ByVal Ref_ID As Integer) As Data.DataTable
        Return LetterPadDB.GetReport(Ref_ID)
    End Function
    Public Function CheckDuplicate(ByVal lp As LetterPad) As Data.DataTable
        Return LetterPadDB.CheckDuplicate(lp)
    End Function
End Class
