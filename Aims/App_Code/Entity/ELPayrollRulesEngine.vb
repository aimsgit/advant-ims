Imports Microsoft.VisualBasic

Public Class ELPayrollRulesEngine
    Private _Year As Integer
    Public Property Year() As Integer
        Get
            Return _Year
        End Get
        Set(ByVal value As Integer)
            _Year = value
        End Set
    End Property
    Private _Fromula As Integer
    Public Property Fromula() As Integer
        Get
            Return _Fromula
        End Get
        Set(ByVal value As Integer)
            _Fromula = value
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
    Private _MS_id As Long
    Public Property iMS_id() As Long
        Get
            Return _MS_id
        End Get
        Set(ByVal value As Long)
            _MS_id = value
        End Set
    End Property
    Private _Field As String
    Public Property Field() As String
        Get
            Return _Field
        End Get
        Set(ByVal value As String)
            _Field = value
        End Set
    End Property
    Private _Fixed As Integer
    Public Property Fixed() As Integer
        Get
            Return _Fixed
        End Get
        Set(ByVal value As Integer)
            _Fixed = value
        End Set
    End Property
    Private _Fixed1 As Integer
    Public Property Fixed1() As Integer
        Get
            Return _Fixed1
        End Get
        Set(ByVal value As Integer)
            _Fixed1 = value
        End Set
    End Property
    Private _OnNet As Integer
    Public Property OnNet() As Integer
        Get
            Return _OnNet
        End Get
        Set(ByVal value As Integer)
            _OnNet = value
        End Set
    End Property
    Private _OnGross As Integer
    Public Property OnGross() As Integer
        Get
            Return _OnGross
        End Get
        Set(ByVal value As Integer)
            _OnGross = value
        End Set
    End Property
    Private _ItemValue As Integer
    Public Property ItemValue() As Integer
        Get
            Return _ItemValue
        End Get
        Set(ByVal value As Integer)
            _ItemValue = value
        End Set
    End Property
    Private _ItemField As String
    Public Property ItemField() As String
        Get
            Return _ItemField
        End Get
        Set(ByVal value As String)
            _ItemField = value
        End Set
    End Property
    Private _Grade As Integer
    Public Property Grade() As Integer
        Get
            Return _Grade
        End Get
        Set(ByVal value As Integer)
            _Grade = value
        End Set
    End Property
    Private _Criteria As String
    Public Property Criteria() As String
        Get
            Return _Criteria
        End Get
        Set(ByVal value As String)
            _Criteria = value
        End Set
    End Property
    Private _CriteriaField As String
    Public Property CriteriaField() As String
        Get
            Return _CriteriaField
        End Get
        Set(ByVal value As String)
            _CriteriaField = value
        End Set
    End Property
    Private _Criteria1 As String
    Public Property Criteria1() As String
        Get
            Return _Criteria1
        End Get
        Set(ByVal value As String)
            _Criteria1 = value
        End Set
    End Property
    Private _Criteria2 As String
    Public Property Criteria2() As String
        Get
            Return _Criteria2
        End Get
        Set(ByVal value As String)
            _Criteria2 = value
        End Set
    End Property
    Private _CriteriaV1 As Integer
    Public Property CriteriaV1() As Integer
        Get
            Return _CriteriaV1
        End Get
        Set(ByVal value As Integer)
            _CriteriaV1 = value
        End Set
    End Property
    Private _CriteriaV2 As Integer
    Public Property CriteriaV2() As Integer
        Get
            Return _CriteriaV2
        End Get
        Set(ByVal value As Integer)
            _CriteriaV2 = value
        End Set
    End Property
    Private _SelectOption As String
    Public Property SelectOption() As String
        Get
            Return _SelectOption
        End Get
        Set(ByVal value As String)
            _SelectOption = value
        End Set
    End Property
    Private _MonthNo As Integer
    Public Property MonthNo() As Integer
        Get
            Return _MonthNo
        End Get
        Set(ByVal value As Integer)
            _MonthNo = value
        End Set
    End Property


End Class
