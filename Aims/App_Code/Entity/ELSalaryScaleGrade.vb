Imports Microsoft.VisualBasic

Public Class ELSalaryScaleGrade
    Private _Grade, _ScaleRange As String
    Public Property Grade() As String
        Get
            Return _Grade
        End Get
        Set(ByVal value As String)
            _Grade = value
        End Set
    End Property
    Public Property ScaleRange() As String
        Get
            Return _ScaleRange
        End Get
        Set(ByVal value As String)
            _ScaleRange = value
        End Set
    End Property
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _MaxScale As String
    Public Property MaxScale() As String
        Get
            Return _MaxScale
        End Get
        Set(ByVal value As String)
            _MaxScale = value
        End Set
    End Property
    Private _MinScale As String
    Public Property MinScale() As String
        Get
            Return _MinScale
        End Get
        Set(ByVal value As String)
            _MinScale = value
        End Set
    End Property
    Private _Inc1 As String
    Public Property Inc1() As String
        Get
            Return _Inc1
        End Get
        Set(ByVal value As String)
            _Inc1 = value
        End Set
    End Property
    Private _Inc2 As String
    Public Property Inc2() As String
        Get
            Return _Inc2
        End Get
        Set(ByVal value As String)
            _Inc2 = value
        End Set
    End Property
    Private _Inc3 As String
    Public Property Inc3() As String
        Get
            Return _Inc3
        End Get
        Set(ByVal value As String)
            _Inc3 = value
        End Set
    End Property
    Private _Step1 As Integer
    Public Property Step1() As Integer
        Get
            Return _Step1
        End Get
        Set(ByVal value As Integer)
            _Step1 = value
        End Set
    End Property
    Private _Step2 As Integer
    Public Property Step2() As Integer
        Get
            Return _Step2
        End Get
        Set(ByVal value As Integer)
            _Step2 = value
        End Set
    End Property
    Private _Step3 As Integer
    Public Property Step3() As Integer
        Get
            Return _Step3
        End Get
        Set(ByVal value As Integer)
            _Step3 = value
        End Set
    End Property
    Private _SalaryBand As String
    Public Property SalaryBand() As String
        Get
            Return _SalaryBand
        End Get
        Set(ByVal value As String)
            _SalaryBand = value
        End Set
    End Property
    Private _EmpType As String
    Public Property EmpType() As String
        Get
            Return _EmpType
        End Get
        Set(ByVal value As String)
            _EmpType = value
        End Set
    End Property
End Class
