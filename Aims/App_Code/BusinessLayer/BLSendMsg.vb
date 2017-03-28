Imports Microsoft.VisualBasic

Public Class BLSendMsg
    Dim DL As New DLSendMsg
    Public Function Getdata(ByVal s As String, ByVal FrmDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Return DL.GetData(s, FrmDate, ToDate)
    End Function
    Public Function Approve(ByVal CMID As Integer) As Integer
        Return DL.Approve(CMID)
    End Function
    Public Function Reject(ByVal CMID As Integer) As Integer
        Return DL.Reject(CMID)
    End Function
    Public Function GetCommunication(ByVal CMID As Integer) As DataTable
        Return DL.GetCommunication(CMID)
    End Function
    Public Function InsertIntoOutbox(ByVal Prefix As String, ByVal ToPhone As String, ByVal Message As String, ByVal SentDate As DateTime) As Integer
        Return DL.InsertIntoOutbox(Prefix, ToPhone, Message, SentDate)
    End Function
    Public Function DeleteRecord(ByVal id As Integer) As Integer
        Return DL.DeleteRecord(id)
    End Function
    Public Function UpdateRecord(ByVal id As Integer, ByVal msg As String, ByVal remarks As String)
        Return DL.UpdateRecord(id, msg, remarks)
    End Function
End Class
