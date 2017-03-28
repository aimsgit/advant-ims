Imports Microsoft.VisualBasic

Public Class State
    Private _StateId As Long
    Public Property StateId() As Long
        Get
            Return _StateId
        End Get
        Set(ByVal value As Long)
            _StateId = value
        End Set
    End Property
    Private _StateName As String
    Public Property StateName() As String
        Get
            Return _StateName
        End Get
        Set(ByVal value As String)
            _StateName = value
        End Set
    End Property
    Public Sub New(ByVal StateId As Long, ByVal StateName As String)
        _StateId = StateId
        _StateName = StateName
    End Sub
  
End Class
