Imports Microsoft.VisualBasic

Public Class EL_BuyerMaster
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _fname As String
    Public Property Fname() As String
        Get
            Return _fname
        End Get
        Set(ByVal value As String)
            _fname = value
        End Set
    End Property
    Private _lname As String
    Public Property Lname() As String
        Get
            Return _lname
        End Get
        Set(ByVal value As String)
            _lname = value
        End Set
    End Property
    Private _code As String
    Public Property BuyerCode() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    Private _Photo As String
    Public Property Photo() As String
        Get
            Return _Photo
        End Get
        Set(ByVal value As String)
            _Photo = value
        End Set
    End Property
    Private _Tin As String
    Public Property Tin() As String
        Get
            Return _Tin
        End Get
        Set(ByVal value As String)
            _Tin = value
        End Set
    End Property
    Private _CST_NO As String
    Public Property CST_NO() As String
        Get
            Return _CST_NO
        End Get
        Set(ByVal value As String)
            _CST_NO = value
        End Set
    End Property
    Private _PAN_NO As String
    Public Property PAN_NO() As String
        Get
            Return _PAN_NO
        End Get
        Set(ByVal value As String)
            _PAN_NO = value
        End Set
    End Property
    Private _Contact_Number1 As String
    Public Property Contact_Number1() As String
        Get
            Return _Contact_Number1
        End Get
        Set(ByVal value As String)
            _Contact_Number1 = value
        End Set
    End Property
    Private _Contact_Number2 As String
    Public Property Contact_Number2() As String
        Get
            Return _Contact_Number2
        End Get
        Set(ByVal value As String)
            _Contact_Number2 = value
        End Set
    End Property
    Private _Email1 As String
    Public Property Email1() As String
        Get
            Return _Email1
        End Get

        Set(ByVal value As String)
            _Email1 = value
        End Set
    End Property
    Private _Email2 As String
    Public Property Email2() As String
        Get
            Return _Email2
        End Get
        Set(ByVal value As String)
            _Email2 = value
        End Set
    End Property
    Private _Fax_No As String
    Public Property Fax_NO() As String
        Get
            Return _Fax_No
        End Get
        Set(ByVal value As String)
            _Fax_No = value
        End Set
    End Property
    Private _Contact_Person As String
    Public Property Contact_Person() As String
        Get
            Return _Contact_Person
        End Get
        Set(ByVal value As String)
            _Contact_Person = value
        End Set
    End Property
    Private _Introducer As String
    Public Property Introducer() As String
        Get
            Return _Introducer
        End Get
        Set(ByVal value As String)
            _Introducer = value
        End Set
    End Property
    Private _Off_Address As String
    Public Property Off_Address() As String
        Get
            Return _Off_Address
        End Get
        Set(ByVal value As String)
            _Off_Address = value
        End Set
    End Property
    Private _Res_Address As String
    Public Property Res_Address() As String
        Get
            Return _Res_Address
        End Get
        Set(ByVal value As String)
            _Res_Address = value
        End Set
    End Property
    Private _Off_City As String
    Public Property Off_City() As String
        Get
            Return _Off_City
        End Get
        Set(ByVal value As String)
            _Off_City = value
        End Set
    End Property
    Private _Res_City As String
    Public Property Res_City() As String
        Get
            Return _Res_City
        End Get
        Set(ByVal value As String)
            _Res_City = value
        End Set
    End Property
    Private _Off_District As String
    Public Property Off_District() As String
        Get
            Return _Off_District
        End Get
        Set(ByVal value As String)
            _Off_District = value
        End Set
    End Property
    Private _Res_District As String
    Public Property Res_District() As String
        Get
            Return _Res_District
        End Get
        Set(ByVal value As String)
            _Res_District = value
        End Set
    End Property
    Private _Off_State As String
    Public Property Off_State() As Integer
        Get
            Return _Off_State
        End Get
        Set(ByVal value As Integer)
            _Off_State = value
        End Set
    End Property
    Private _Res_State As String
    Public Property Res_State() As Integer
        Get
            Return _Res_State
        End Get
        Set(ByVal value As Integer)
            _Res_State = value
        End Set
    End Property
    Private _Off_Country As String
    Public Property Off_Country() As String
        Get
            Return _Off_Country
        End Get
        Set(ByVal value As String)
            _Off_Country = value
        End Set
    End Property
    Private _Res_Country As String
    Public Property Res_Country() As Integer
        Get
            Return _Res_Country
        End Get
        Set(ByVal value As Integer)
            _Res_Country = value
        End Set
    End Property
    Private _Bank_Name As String
    Public Property Bank_Name() As String
        Get
            Return _Bank_Name
        End Get
        Set(ByVal value As String)
            _Bank_Name = value
        End Set
    End Property
    Private _Account_Number As String
    Public Property Account_Number() As String
        Get
            Return _Account_Number
        End Get
        Set(ByVal value As String)
            _Account_Number = value
        End Set
    End Property
    Private _Bank_Branch As String
    Public Property Bank_Branch() As String
        Get
            Return _Bank_Branch
        End Get
        Set(ByVal value As String)
            _Bank_Branch = value
        End Set
    End Property
    Private _Type_Of_Account As String
    Public Property Type_Of_Account() As String
        Get
            Return _Type_Of_Account
        End Get
        Set(ByVal value As String)
            _Type_Of_Account = value
        End Set
    End Property
    Private _IFSC_Code As String
    Public Property IFSC_Code() As String
        Get
            Return _IFSC_Code
        End Get
        Set(ByVal value As String)
            _IFSC_Code = value
        End Set
    End Property
End Class
