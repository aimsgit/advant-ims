Imports Microsoft.VisualBasic

Public Class IncomeTaxE

    Private _itdescription As String
    Private _category As String
    Private _lowerlimit As Int64
    Private _itid As Int64
    Private _upperlimit As Int64
    Private _stddeduction As String
    Private _itpercent As Int64
    Private _financialyear As String
    Private _del_flag As Boolean
    Public Property IT_id() As Int64
        Get
            Return _itid
        End Get
        Set(ByVal value As Int64)
            _itid = value
        End Set
    End Property
    Public Property ITDescription() As String
        Get
            Return _itdescription
        End Get
        Set(ByVal value As String)
            _itdescription = value
        End Set
    End Property
    Public Property Lowerlimit() As Int64
        Get
            Return _lowerlimit
        End Get
        Set(ByVal value As Int64)
            _lowerlimit = value
        End Set
    End Property
    Public Property Upperlimit() As Int64
        Get
            Return _upperlimit
        End Get
        Set(ByVal value As Int64)
            _upperlimit = value
        End Set
    End Property
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property
    Public Property Stddeduction() As String
        Get
            Return _stddeduction
        End Get
        Set(ByVal value As String)
            _stddeduction = value
        End Set
    End Property
    Public Property ITPercent() As Int64
        Get
            Return _itpercent
        End Get
        Set(ByVal value As Int64)
            _itpercent = value
        End Set
    End Property
    Public Property Financialyear() As String
        Get
            Return _financialyear
        End Get
        Set(ByVal value As String)
            _financialyear = value
        End Set
    End Property
    Public Property Del_flag() As String
        Get
            Return _del_flag
        End Get
        Set(ByVal value As String)
            _del_flag = value
        End Set
    End Property
End Class

