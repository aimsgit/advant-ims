Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Web.Caching
Public Class busErrorMessage
    Shared dataSet As New DataSet

    Public Function GetErrMessage(ByVal I As Integer) As String
        If EntityErrorMessage.counterJ = 0 Then
            dataSet = ErrorMessage.GetErrMsg()
            EntityErrorMessage.counterJ = 1
            Return dataSet.Tables(0).Rows(I - 1)("Msg_Name").ToString
        Else
            Return dataSet.Tables(0).Rows(I - 1)("Msg_Name").ToString
        End If
    End Function
End Class
