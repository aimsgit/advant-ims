Imports Microsoft.VisualBasic

Public Class LateralEntry
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property
    Private _stdcode As String
    Public Property StdCode() As String
        Get
            Return _stdcode
        End Get
        Set(ByVal value As String)
            _stdcode = value
        End Set
    End Property

    Private _admissionyear As String
    Public Property AdmissionYear() As String
        Get
            Return _admissionyear
        End Get
        Set(ByVal value As String)
            _admissionyear = value
        End Set
    End Property
    Private _feepaid As Long
    Public Property FeePaid() As Long
        Get
            Return _feepaid
        End Get
        Set(ByVal value As Long)
            _feepaid = value
        End Set
    End Property
    Private _attendedexam As String
    Public Property AttendedExam() As String
        Get
            Return _attendedexam
        End Get
        Set(ByVal value As String)
            _attendedexam = value
        End Set
    End Property
    Public Sub New(ByVal id As Long, ByVal stdcode As String, ByVal admissionyear As String, ByVal feepaid As Long, ByVal attendedexam As String)
        _id = id
        _stdcode = stdcode
        _admissionyear = admissionyear
        _feepaid = feepaid
        _attendedexam = attendedexam
    End Sub
    Public Sub New()
    End Sub
    Private _deleteflag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
End Class
