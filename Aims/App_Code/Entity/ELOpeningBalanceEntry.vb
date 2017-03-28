Imports Microsoft.VisualBasic

Public Class ELOpeningBalanceEntry
    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property
    Private _Amount As Double
    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
        End Set
    End Property
    Private _Item As String
    Public Property Item() As String
        Get
            Return _Item
        End Get
        Set(ByVal value As String)
            _Item = value
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
    Private _Account_Group As Integer
    Public Property Account_Group() As Integer
        Get
            Return _Account_Group
        End Get
        Set(ByVal value As Integer)
            _Account_Group = value
        End Set
    End Property
    Private _Bank As Integer
    Public Property Bank() As Integer
        Get
            Return _Bank
        End Get
        Set(ByVal value As Integer)
            _Bank = value
        End Set
    End Property
    Private _Account As Integer
    Public Property Account() As Integer
        Get
            Return _Account
        End Get
        Set(ByVal value As Integer)
            _Account = value
        End Set
    End Property
    Private _Account_Treatment As Integer
    Public Property Account_Treatment() As Integer
        Get
            Return _Account_Treatment
        End Get
        Set(ByVal value As Integer)
            _Account_Treatment = value
        End Set
    End Property
    Private _Acct_date As Date
    Public Property Acct_date() As Date
        Get
            Return _Acct_date
        End Get
        Set(ByVal value As Date)
            _Acct_date = value
        End Set
    End Property
End Class
