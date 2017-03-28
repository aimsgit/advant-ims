Imports Microsoft.VisualBasic

Public Class Category
    Private _categoryid As Long
    Public Property CategoryId() As Long
        Get
            Return _categoryid
        End Get
        Set(ByVal value As Long)
            _categoryid = value
        End Set
    End Property
    Private _Deptid As Integer
    Public Property DeptId() As Integer
        Get
            Return _Deptid
        End Get
        Set(ByVal value As Integer)
            _Deptid = value
        End Set
    End Property
    Private _categoryname As String
    Public Property CategoryName() As String
        Get
            Return _categoryname
        End Get
        Set(ByVal value As String)
            _categoryname = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal categoryid As Long, ByVal categoryname As String)
        _categoryid = categoryid
        _categoryname = categoryname
    End Sub
End Class
