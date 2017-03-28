Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Public Class Course
    Private _Course_ID As Long
    Public Property Course_ID() As Long
        Get
            Return _Course_ID
        End Get
        Set(ByVal value As Long)
            _Course_ID = value
        End Set
    End Property
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    'Private _departmentid As Long
    'Public Property DepartmentId() As Long
    '    Get
    '        Return _departmentid
    '    End Get
    '    Set(ByVal value As Long)
    '        _departmentid = value
    '    End Set
    'End Property
    Private _CourseType As String
    Public Property CourseType() As String
        Get
            Return _CourseType
        End Get
        Set(ByVal value As String)
            _CourseType = value
        End Set
    End Property
    Private _deleteflag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Private _seatno As Integer
    Public Property seatNo() As Integer
        Get
            Return _seatno
        End Get
        Set(ByVal value As Integer)
            _seatno = value
        End Set
    End Property
    Public Sub New(ByVal Course_ID As Long, ByVal name As String, ByVal code As String, ByVal CourseType As Integer, ByVal seatNo As Integer)
        _Course_ID = Course_ID
        _name = name
        _code = code
        '_departmentid = departmentid
        _CourseType = CourseType
        _seatno = seatNo
    End Sub
    Public Sub New()
    End Sub
    Private _Stream As Integer
    Public Property Stream() As Integer
        Get
            Return _Stream
        End Get
        Set(ByVal value As Integer)
            _Stream = value
        End Set
    End Property

End Class
