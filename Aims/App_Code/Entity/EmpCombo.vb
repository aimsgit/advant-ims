Imports Microsoft.VisualBasic

Public Class EmpCombo
    Private _emp_Id As Integer
    Public Property Emp_Id() As Integer
        Get
            Return _emp_Id
        End Get
        Set(ByVal value As Integer)
            _emp_Id = value
        End Set
    End Property
    Private _emp_Name As String
    Public Property Emp_Name() As String
        Get
            Return _emp_Name
        End Get
        Set(ByVal value As String)
            _emp_Name = value
        End Set
    End Property
    Public Sub New(ByVal emp_Name As String, ByVal emp_ID As Integer)
        _emp_Name = emp_Name
        _emp_Id = emp_ID
    End Sub

End Class
