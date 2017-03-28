Imports Microsoft.VisualBasic

Public Class PerformanceCycleEL
    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _deleteFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteFlag
        End Get
        Set(ByVal value As Int16)
            _deleteFlag = value
        End Set
    End Property
    Private _Startdate As DateTime
    Public Property Startdate() As DateTime
        Get
            Return _Startdate
        End Get
        Set(ByVal value As DateTime)
            _Startdate = value
        End Set
    End Property
    Private _Enddate As DateTime
    Public Property Enddate() As DateTime
        Get
            Return _Enddate
        End Get
        Set(ByVal value As DateTime)
            _Enddate = value
        End Set
    End Property
    Private _CurrentApp As String
    Public Property CurrentAppraisal() As String
        Get
            Return _CurrentApp
        End Get
        Set(ByVal value As String)
            _CurrentApp = value
        End Set
    End Property
    Private _PerfCycle As String
    Public Property PerfCycle() As String
        Get
            Return _PerfCycle
        End Get
        Set(ByVal value As String)
            _PerfCycle = value
        End Set
    End Property
End Class
