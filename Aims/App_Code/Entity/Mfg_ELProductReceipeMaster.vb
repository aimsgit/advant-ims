Imports Microsoft.VisualBasic

Public Class Mfg_ELProductReceipeMaster
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set

    End Property
    Private _Product As Integer
    Public Property Product() As Integer
        Get
            Return _Product
        End Get
        Set(ByVal value As Integer)
            _Product = value
        End Set
    End Property
    Private _RMPart As Integer
    Public Property RMPart() As Integer
        Get
            Return _RMPart
        End Get
        Set(ByVal value As Integer)
            _RMPart = value
        End Set
    End Property
    Private _Unit As Integer
    Public Property Unit() As Integer
        Get
            Return _Unit
        End Get
        Set(ByVal value As Integer)
            _Unit = value
        End Set
    End Property
    Private _CF As Double
    Public Property CF() As Double
        Get
            Return _CF
        End Get
        Set(ByVal value As Double)
            _CF = value
        End Set
    End Property
    Private _Quantity As Double
    Public Property Quantity() As Double
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Double)
            _Quantity = value
        End Set
    End Property
    Private _Sequence As Double
    Public Property Sequence() As Double
        Get
            Return _Sequence
        End Get
        Set(ByVal value As Double)
            _Sequence = value
        End Set
    End Property
    Private _Wastage As Double
    Public Property Wastage() As Double
        Get
            Return _Wastage
        End Get
        Set(ByVal value As Double)
            _Wastage = value
        End Set
    End Property
End Class
