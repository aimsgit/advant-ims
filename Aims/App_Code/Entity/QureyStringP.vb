Imports Microsoft.VisualBasic

Public Class QureyStringP

    'Public Property insID() As Integer
    '    Get

    '    End Get
    '    Set(ByVal value As Integer)

    '    End Set
    'End Property

    'Public Property brnID() As Integer
    '    Get

    '    End Get
    '    Set(ByVal value As Integer)

    '    End Set
    'End Property

    'Public Property userID() As Integer
    '    Get

    '    End Get
    '    Set(ByVal value As Integer)

    '    End Set
    'End Property
    Private _brnID As Integer
    Private _insID As Integer
    Private _userID As Integer
    Public Property insID() As Integer
        Get
            Return _insID
        End Get
        Set(ByVal value As Integer)
            _insID = value
        End Set
    End Property

    Public Property brnID() As Integer
        Get
            Return _brnID
        End Get
        Set(ByVal value As Integer)
            _brnID = value
        End Set
    End Property

    Public Property userID() As Integer
        Get
            Return _userID
        End Get
        Set(ByVal value As Integer)
            _userID = value
        End Set
    End Property
End Class
