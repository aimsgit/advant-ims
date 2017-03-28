Imports Microsoft.VisualBasic
Public Class MaterialIndentEL
    Private _mino As String
    Private _id, _wo_id, _custmr, _itemdesc, _quantity, _Mi_id, _party_id, _id1 As Integer
    Private _midate As DateTime
    Public Property mino() As String
        Get
            Return _mino
        End Get
        Set(ByVal value As String)
            _mino = value

        End Set
    End Property
    Public Property wo_id() As Integer
        Get
            Return _wo_id
        End Get
        Set(ByVal value As Integer)
            _wo_id = value

        End Set
    End Property
    Public Property custmr() As Integer
        Get
            Return _custmr
        End Get
        Set(ByVal value As Integer)
            _custmr = value

        End Set
    End Property
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value

        End Set
    End Property
    Public Property id1() As Integer
        Get
            Return _id1
        End Get
        Set(ByVal value As Integer)
            _id1 = value

        End Set
    End Property
    Public Property midate() As DateTime
        Get
            Return _midate
        End Get
        Set(ByVal value As DateTime)
            _midate = value

        End Set
    End Property
    Public Property itemdesc() As Integer
        Get
            Return _itemdesc
        End Get
        Set(ByVal value As Integer)
            _itemdesc = value

        End Set
    End Property
    Public Property quantity() As Integer
        Get
            Return _quantity
        End Get
        Set(ByVal value As Integer)
            _quantity = value

        End Set
    End Property
    Public Property Mi_id() As Integer
        Get
            Return _Mi_id
        End Get
        Set(ByVal value As Integer)
            _Mi_id = value

        End Set
    End Property
    Public Property party_id() As Integer
        Get
            Return _party_id
        End Get
        Set(ByVal value As Integer)
            _party_id = value
        End Set
    End Property
End Class
