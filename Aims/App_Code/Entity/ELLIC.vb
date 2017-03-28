Imports Microsoft.VisualBasic

Public Class ELLIC
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _DeptId As Integer
    Public Property DeptId() As Integer
        Get
            Return _DeptId
        End Get
        Set(ByVal value As Integer)
            _DeptId = value
        End Set
    End Property
    Private _Lab_Name As String
    Public Property Lab_Name() As String
        Get
            Return _Lab_Name
        End Get
        Set(ByVal value As String)
            _Lab_Name = value
        End Set
    End Property
    Private _Carpet_Area As Double
    Public Property Carpet_Area() As Double
        Get
            Return _Carpet_Area
        End Get
        Set(ByVal value As Double)
            _Carpet_Area = value
        End Set
    End Property
    Private _Equipment_Avail As String
    Public Property Equipment_Avail() As String
        Get
            Return _Equipment_Avail
        End Get
        Set(ByVal value As String)
            _Equipment_Avail = value
        End Set
    End Property
    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
End Class