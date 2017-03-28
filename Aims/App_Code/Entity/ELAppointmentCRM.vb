Imports Microsoft.VisualBasic

Public Class ELAppointmentCRM
    Private _id As Integer
    Private _LeadId As Integer
    Private _Adate As DateTime
    Private _Atime As DateTime
    Private _AssingedToId As Integer
    Private _Status As String
    Private _Remarks As String
    Private _Leadname As String
    Private _Empname As String
    Private _EstimatedValue As Double
    Private _Probability As Double

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property LeadId() As Integer
        Get
            Return _LeadId
        End Get
        Set(ByVal value As Integer)
            _LeadId = value
        End Set
    End Property
    Public Property Atime() As DateTime
        Get
            Return _Atime
        End Get
        Set(ByVal value As DateTime)
            _Atime = value
        End Set
    End Property
    Public Property Adate() As DateTime
        Get
            Return _Adate
        End Get
        Set(ByVal value As DateTime)
            _Adate = value
        End Set
    End Property
    Public Property AssingedToId() As Integer
        Get
            Return _AssingedToId
        End Get
        Set(ByVal value As Integer)
            _AssingedToId = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Public Property Leadname() As String
        Get
            Return _Leadname
        End Get
        Set(ByVal value As String)
            _Leadname = value
        End Set
    End Property

    Public Property Empname() As String
        Get
            Return _Empname
        End Get
        Set(ByVal value As String)
            _Empname = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Public Property EstimatedValue() As Double
        Get
            Return _EstimatedValue
        End Get
        Set(ByVal value As Double)
            _EstimatedValue = value
        End Set
    End Property

    Public Property Probability() As Double
        Get
            Return _Probability
        End Get
        Set(ByVal value As Double)
            _Probability = value
        End Set
    End Property

End Class
