Imports Microsoft.VisualBasic

Public Class DesignationP
    Private _Designation_ID As Long
    Public Property Designation_ID() As Long
        Get
            Return _Designation_ID
        End Get
        Set(ByVal value As Long)
            _Designation_ID = value
        End Set
    End Property
    Private _Designation As String
    Public Property Designation() As String
        Get
            Return _Designation
        End Get
        Set(ByVal value As String)
            _Designation = value
        End Set
    End Property
    Private _SalCodeGrd As String
    Public Property SalCodeGrd() As String
        Get
            Return _SalCodeGrd
        End Get
        Set(ByVal value As String)
            _SalCodeGrd = value
        End Set
    End Property
    Private _CategoryEmptype As String
    Public Property CategoryEtype() As String
        Get
            Return _CategoryEmptype
        End Get
        Set(ByVal value As String)
            _CategoryEmptype = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal Designation_ID As Long, ByVal Designation As String)
        _Designation_ID = Designation_ID
        _Designation = Designation
    End Sub
End Class
