Imports Microsoft.VisualBasic

Public Class BLQuestionBank
    Dim dl As New DLQuestionBank
    Public Function getQuestionBank(ByVal el As ELQuestionBank) As System.Data.DataTable
        Return DLQuestionBank.getQuestionBank(el)
    End Function
    Public Function InsertRecord(ByVal el As ELQuestionBank) As Integer

        Return DLQuestionBank.Insert(el)
    End Function

    Public Function UpdateRecord(ByVal el As ELQuestionBank) As Integer
        Return DLQuestionBank.Update(el)
    End Function
    Public Function ChangeFlag(ByVal el As ELQuestionBank) As Integer

        Return DLQuestionBank.ChangeFlag(el.Id)
    End Function
    Public Function CheckDuplicate(ByVal el As ELQuestionBank) As System.Data.DataTable
        Return dl.CheckDuplicate(el)
    End Function
    Public Function PostQuestion(ByVal EL As ELQuestionBank) As Integer
        Return dl.PostQuestion(EL)
    End Function
End Class
