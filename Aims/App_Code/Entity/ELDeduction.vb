Imports Microsoft.VisualBasic

Public Class ELDeduction
    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _deleteFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteFlag
        End Get
        Set(ByVal value As Int16)
            _deleteFlag = value
        End Set
    End Property
    Private _Empid As Integer
    Public Property Empid() As Integer
        Get
            Return _Empid
        End Get
        Set(ByVal value As Integer)
            _Empid = value
        End Set
    End Property
    Private _Amount As Double
    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
        End Set
    End Property
    Private _DedType As String
    Public Property DedType() As String
        Get
            Return _DedType
        End Get
        Set(ByVal value As String)
            _DedType = value
        End Set
    End Property
    Private _Upto As Date
    Public Property Upto() As Date
        Get
            Return _Upto
        End Get
        Set(ByVal value As Date)
            _Upto = value
        End Set
    End Property
    Private _Dedid As Integer
    Public Property Dedid() As Integer
        Get
            Return _Dedid
        End Get
        Set(ByVal value As Integer)
            _Dedid = value
        End Set
    End Property
    Private _ValidFrom As Date
    Public Property ValidFrom() As Date
        Get
            Return _ValidFrom
        End Get
        Set(ByVal value As Date)
            _ValidFrom = value
        End Set
    End Property
    Private _Month As String
    Public Property Month() As String
        Get
            Return _Month
        End Get
        Set(ByVal value As String)
            _Month = value
        End Set
    End Property
    Private _Year As String
    Public Property Year() As String
        Get
            Return _Year
        End Get
        Set(ByVal value As String)
            _Year = value
        End Set
    End Property
End Class
