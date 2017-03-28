Imports Microsoft.VisualBasic

Public Class ELCadreMgmt
    Private _id As Long
    Public Property Id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set

    End Property
    Private _ChkID As String
    Public Property ChkID() As String
        Get
            Return _ChkID
        End Get
        Set(ByVal value As String)
            _ChkID = value
        End Set
    End Property
    Private _University As String
    Public Property University() As String
        Get
            Return _University
        End Get
        Set(ByVal value As String)
            _University = value
        End Set
    End Property

    Private _Program As Integer
    Public Property Program() As Integer
        Get
            Return _Program
        End Get
        Set(ByVal value As Integer)
            _Program = value
        End Set
    End Property
    Private _Project As Integer
    Public Property Project() As Integer
        Get
            Return _Project
        End Get
        Set(ByVal value As Integer)
            _Project = value
        End Set
    End Property
    Private _Department As String
    Public Property Department() As String
        Get
            Return _Department
        End Get
        Set(ByVal value As String)
            _Department = value
        End Set
    End Property
    Private _SalaryCode As String
    Public Property SalaryCode() As String
        Get
            Return _SalaryCode
        End Get
        Set(ByVal value As String)
            _SalaryCode = value
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
    Private _Designation As Integer
    Public Property Designation() As Integer
        Get
            Return _Designation
        End Get
        Set(ByVal value As Integer)
            _Designation = value
        End Set
    End Property
    Private _ApprovedNo As String
    Public Property ApprovedNo() As String
        Get
            Return _ApprovedNo
        End Get
        Set(ByVal value As String)
            _ApprovedNo = value
        End Set
    End Property
    Private _RequiredNo As String
    Public Property RequiredNo() As String
        Get
            Return _RequiredNo
        End Get
        Set(ByVal value As String)
            _RequiredNo = value
        End Set
    End Property
    Private _ApprovedYear As String
    Public Property ApprovedYear() As String
        Get
            Return _ApprovedYear
        End Get
        Set(ByVal value As String)
            _ApprovedYear = value
        End Set
    End Property
    Private _RequiredYear As String
    Public Property RequiredYear() As String
        Get
            Return _RequiredYear
        End Get
        Set(ByVal value As String)
            _RequiredYear = value
        End Set
    End Property
End Class
