Imports Microsoft.VisualBasic

Public Class AdmissionCriteriaEL
    Private _Criteria, _CriteriaValue As String
    Private _id As Integer

    Public Property Criteria() As String
        Get
            Return _Criteria
        End Get
        Set(ByVal value As String)
            _Criteria = value

        End Set
    End Property
    Public Property CriteriaValue() As String
        Get
            Return _CriteriaValue
        End Get
        Set(ByVal value As String)
            _CriteriaValue = value

        End Set
    End Property
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value

        End Set
    End Property
End Class
