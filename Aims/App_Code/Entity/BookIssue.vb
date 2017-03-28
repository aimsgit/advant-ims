Imports Microsoft.VisualBasic

Public Class BookIssue
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _empid As Integer
    Public Property Empid() As Integer
        Get
            Return _empid
        End Get
        Set(ByVal value As Integer)
            _empid = value
        End Set
    End Property
    Private _empcode As String
    Public Property EmpCode() As String
        Get
            Return _empcode
        End Get
        Set(ByVal value As String)
            _empcode = value
        End Set
    End Property
    Private _empname As String
    Public Property EmpName() As String
        Get
            Return _empname
        End Get
        Set(ByVal value As String)
            _empname = value
        End Set
    End Property
    Private _bookid As Integer
    Public Property Bookid() As Integer
        Get
            Return _bookid
        End Get
        Set(ByVal value As Integer)
            _bookid = value
        End Set
    End Property
    Private _bookcode As String
    Public Property BookCode() As String
        Get
            Return _bookcode
        End Get
        Set(ByVal value As String)
            _bookcode = value
        End Set
    End Property
    Private _bookname As String
    Public Property BookName() As String
        Get
            Return _bookname
        End Get
        Set(ByVal value As String)
            _bookname = value
        End Set
    End Property
    Private _stdid As Integer
    Public Property Stdid() As Integer
        Get
            Return _stdid
        End Get
        Set(ByVal value As Integer)
            _stdid = value
        End Set
    End Property
    Private _stdcode As String
    Public Property StdCode() As String
        Get
            Return _stdcode
        End Get
        Set(ByVal value As String)
            _stdcode = value
        End Set
    End Property
    Private _stdname As String
    Public Property StdName() As String
        Get
            Return _stdname
        End Get
        Set(ByVal value As String)
            _stdname = value
        End Set
    End Property
    Private _issuedate As Date
    Public Property Issuedate() As Date
        Get
            Return _issuedate
        End Get
        Set(ByVal value As Date)
            _issuedate = value
        End Set
    End Property
    Private _returndate As Date
    Public Property Returndate() As Date
        Get
            Return _returndate
        End Get
        Set(ByVal value As Date)
            _returndate = value
        End Set
    End Property
    Private _StdEmp As String
    Public Property Std_Emp() As String
        Get
            Return _StdEmp
        End Get
        Set(ByVal value As String)
            _StdEmp = value
        End Set
    End Property
    Private _std As Int16

    Public Sub New(ByVal id As Integer, ByVal empid As Integer, ByVal bookid As Integer, ByVal stdid As Integer, ByVal issuedate As Date, ByVal returndate As Date, ByVal std As Int16, ByVal emp As Int16, ByVal institute As Integer, ByVal branch As Integer)
        _id = id
        _empid = empid
        _empcode = EmpCode
        _empname = EmpName
        _bookid = bookid
        _bookcode = BookCode
        _bookname = BookName
        _stdid = stdid
        _stdcode = StdCode
        _stdname = StdName
        _issuedate = issuedate
        _returndate = returndate
        _StdEmp = Std_Emp
    End Sub
    Public Sub New()
    End Sub
    Private _delflag As Int16
    Public Property Delflag() As Int16
        Get
            Return _delflag
        End Get
        Set(ByVal value As Int16)
            _delflag = value
        End Set
    End Property
    Private _Dept As Int16
    Public Property Dept() As Int16
        Get
            Return _Dept
        End Get
        Set(ByVal value As Int16)
            _Dept = value
        End Set
    End Property
    Private _Branch As String
    Public Property Branch() As String
        Get
            Return _Branch
        End Get
        Set(ByVal value As String)
            _Branch = value
        End Set
    End Property
End Class
