Imports Microsoft.VisualBasic

Public Class ServiceRequestB


    Shared Function Insert(ByVal EL As ServiceRequestE) As Integer

        Return ServiceRequestD.Insert(EL)
    End Function
    '    Shared Function Update(ByVal EL As UserRequestE) As Integer

    '        Return UserRequestD.Update(EL)
    '    End Function
    Shared Function Delete(ByVal ID As Long) As Integer

        Return ServiceRequestD.Delete(ID)
    End Function
    Shared Function GetData(ByVal a As ServiceRequestE) As DataTable

        Return ServiceRequestD.GetData(a)
    End Function
    '    Shared Function GetData(ByVal UserID As String) As DataTable

    '        Return UserRequestD.GetData(UserID)
    '    End Function
    '    Shared Function GetData(ByVal ID As Integer) As DataTable

    '        Return UserRequestD.GetData(ID)
    '    End Function
    '    Shared Function GetData() As DataTable

    '        Return UserRequestD.GetData()
    '    End Function


End Class
