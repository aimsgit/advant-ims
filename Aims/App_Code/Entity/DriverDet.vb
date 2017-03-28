Imports Microsoft.VisualBasic

Public Class DriverDet

    Private _drivername As String
    Public Property DriverName() As String
        Get
            Return _drivername
        End Get
        Set(ByVal value As String)
            _drivername = value
        End Set
    End Property
    Private _address As String
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property
    Private _contactno As String
    Public Property ContactNo() As String
        Get
            Return _contactno
        End Get
        Set(ByVal value As String)
            _contactno = value
        End Set
    End Property
    Private _dob As Date
    Public Property DOB() As Date
        Get
            Return _dob
        End Get
        Set(ByVal value As Date)
            _dob = value
        End Set
    End Property
    Private _doj As Date
    Public Property DOJ() As Date
        Get
            Return _doj
        End Get
        Set(ByVal value As Date)
            _doj = value
        End Set
    End Property
    Private _dlno As String
    Public Property DLNO() As String
        Get
            Return _dlno
        End Get
        Set(ByVal value As String)
            _dlno = value
        End Set
    End Property
    Private _bloodgrp As String
    Public Property BloodGroup() As String
        Get
            Return _bloodgrp
        End Get
        Set(ByVal value As String)
            _bloodgrp = value
        End Set
    End Property
    Private _dlexp As Date
    Public Property DLExpiry() As Date
        Get
            Return _dlexp
        End Get
        Set(ByVal value As Date)
            _dlexp = value
        End Set
    End Property
    Private _institute As Integer
    Public Property Institute() As Integer
        Get
            Return _institute
        End Get
        Set(ByVal value As Integer)
            _institute = value
        End Set
    End Property
    Private _branch As Integer
    Public Property Branch() As Integer
        Get
            Return _branch
        End Get
        Set(ByVal value As Integer)
            _branch = value
        End Set
    End Property
    Private _RTOName As String
    Public Property RTOName() As String
        Get
            Return _RTOName
        End Get
        Set(ByVal value As String)
            _RTOName = value
        End Set
    End Property
    Private _City As String
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            _City = value
        End Set
    End Property
    Private _State As String
    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            _State = value
        End Set
    End Property
    Private _driverid As Integer
    Public Property driverid() As Integer
        Get
            Return _driverid
        End Get
        Set(ByVal value As Integer)
            _driverid = value
        End Set
    End Property
    Private _delflag As Int16
    Public Property Delflag() As Int16
        Get
            Return _delflag
        End Get
        Set(ByVal value As Int16)
            _delflag = value
        End Set
    End Property
    Public Sub New()

    End Sub

End Class
