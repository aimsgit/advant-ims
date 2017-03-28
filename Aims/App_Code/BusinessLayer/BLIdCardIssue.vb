Imports Microsoft.VisualBasic

Public Class BLIdCardIssue
    Dim DLIdCardIssue As New DLIdCardIssue
    Shared Function InsertIntoIdCardIssue(ByVal IdCardIssue As IDCardIssue) As Integer
        Return DLIdCardIssue.InsertIntoIdCardIssue(IdCardIssue)
    End Function
    Shared Function UpdateIdCardIssue(ByVal IdcardIssue As IDCardIssue) As Integer
        Return DLIdCardIssue.UpdateIdCardIssue(IdcardIssue)
    End Function

    Shared Function GetIdCardIssue(ByVal IdCardIssue As IDCardIssue) As Data.DataTable
        Return DLIdCardIssue.GetIdCardIssue(IdCardIssue)
    End Function

    Shared Function DeleteIdCardIssue(ByVal PK_ID As Integer) As Integer
        Return DLIdCardIssue.DeleteIdCardIssue(PK_ID)
    End Function
    Shared Function AutoFillStdPhoto(ByVal STD_ID As Integer) As Data.DataTable
        Return DLIdCardIssue.AutoFillStdPhoto(STD_ID)
    End Function
    Shared Function AutoFillStdPhoto1(ByVal STD_ID As Integer) As Data.DataTable
        Return DLIdCardIssue.AutoFillStdPhoto1(STD_ID)
    End Function

    Shared Function GetDuplicate(ByVal IdCardIssue As IDCardIssue) As Data.DataTable
        Return DLIdCardIssue.GetDuplicate(IdCardIssue)
    End Function
End Class
