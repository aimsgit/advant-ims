Imports Microsoft.VisualBasic

Public Class UserRequestB
    Shared Function Insert(ByVal EL As UserRequestE) As Integer

        Return UserRequestD.Insert(EL)
    End Function
    Shared Function Update(ByVal EL As UserRequestE) As Integer

        Return UserRequestD.Update(EL)
    End Function
    Shared Function Delete(ByVal ID As Long) As Integer

        Return UserRequestD.Delete(ID)
    End Function
    Shared Function GetData(ByVal EL As UserRequestE) As DataTable

        Return UserRequestD.GetData(EL)
    End Function
    Shared Function GetData(ByVal UserID As String) As DataTable

        Return UserRequestD.GetData(UserID)
    End Function
    Shared Function GetData(ByVal ID As Integer) As DataTable

        Return UserRequestD.GetData(ID)
    End Function
    Shared Function GetData() As DataTable

        Return UserRequestD.GetData()
    End Function
End Class
