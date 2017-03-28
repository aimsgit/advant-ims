Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class AccountHead
    Private _Account_Code As Long
    Public Property Account_Code() As Long
        Get
            Return _Account_Code
        End Get
        Set(ByVal value As Long)
            _Account_Code = value
        End Set
    End Property
    Private _Head_type As String
    Public Property Head_type() As String
        Get
            Return _Head_type
        End Get
        Set(ByVal value As String)
            _Head_type = value
        End Set
    End Property
    Private _AccHead As String
    Public Property AccHead() As String
        Get
            Return _AccHead
        End Get
        Set(ByVal value As String)
            _AccHead = value
        End Set
    End Property
    Private _UserCod As String
    Public Property UserCod() As String
        Get
            Return _UserCod
        End Get
        Set(ByVal value As String)
            _UserCod = value
        End Set
    End Property
    Private _Acct_One As Int16
    Public Property Acct_One() As Int16
        Get
            Return _Acct_One
        End Get
        Set(ByVal value As Int16)
            _Acct_One = value
        End Set
    End Property
    Private _Acct_two As Int16
    Public Property Acct_two() As Int16
        Get
            Return _Acct_two
        End Get
        Set(ByVal value As Int16)
            _Acct_two = value
        End Set
    End Property
    Private _AGOnevalue As Int32
    Public Property AGOnevalue() As Int32
        Get
            Return _AGOnevalue
        End Get
        Set(ByVal value As Int32)
            _AGOnevalue = value
        End Set
    End Property
    Private _AcctOneValue As Int32
    Public Property AcctOneValue() As Int32
        Get
            Return _AcctOneValue
        End Get
        Set(ByVal value As Int32)
            _AcctOneValue = value
        End Set
    End Property
    Private _AGTwoValue As Int32
    Public Property AGTwoValue() As Int32
        Get
            Return _AGTwoValue
        End Get
        Set(ByVal value As Int32)
            _AGTwoValue = value
        End Set
    End Property
    Private _AcctTwoValue As Int32
    Public Property AcctTwoValue() As Int32
        Get
            Return _AcctTwoValue
        End Get
        Set(ByVal value As Int32)
            _AcctTwoValue = value
        End Set
    End Property
    Private _AOTValue As Int32
    Public Property AOTValue() As Int32
        Get
            Return _AOTValue
        End Get
        Set(ByVal value As Int32)
            _AOTValue = value
        End Set
    End Property
    Private _ATTValue As Int32
    Public Property ATTValue() As Int32
        Get
            Return _ATTValue
        End Get
        Set(ByVal value As Int32)
            _ATTValue = value
        End Set
    End Property
    Private _AccHeadID As Int32
    Public Property AccHeadID() As Int32
        Get
            Return _AccHeadID
        End Get
        Set(ByVal value As Int32)
            _AccHeadID = value
        End Set
    End Property

    Private _User_Defined_Code As String
    Public Property User_Defined_Code() As String
        Get
            Return _User_Defined_Code
        End Get
        Set(ByVal value As String)
            _User_Defined_Code = value
        End Set
    End Property
    Private _Bamount As Double
    Public Property Budget_Amount() As Double

        Get
            Return _Bamount
        End Get
        Set(ByVal value As Double)
            _Bamount = value
        End Set
    End Property
    Public Sub New(ByVal Account_Code As Long, ByVal Head_type As String, ByVal Acct_One As Int16, ByVal Acct_two As Int16)
        _Account_Code = Account_Code
        _Head_type = Head_type
        _Acct_One = Acct_One
        _Acct_two = Acct_two
    End Sub

    Public Sub New(ByVal Account_Code As Long, ByVal Head_type As String, ByVal Acct_One As Int16, ByVal Acct_two As Int16, ByVal User_Defined_Code As String)
        _Account_Code = Account_Code
        _Head_type = Head_type
        _Acct_One = Acct_One
        _Acct_two = Acct_two
        _User_Defined_Code = User_Defined_Code
    End Sub
    Public Sub New()
    End Sub
End Class
