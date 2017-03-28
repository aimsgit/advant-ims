Imports Microsoft.VisualBasic

Public Class ELAppraisalform
    Private _Empid, _AppraisalType As Integer
    Public Property AppraisalType() As Integer
        Get
            Return _AppraisalType
        End Get
        Set(ByVal value As Integer)
            _AppraisalType = value
        End Set
    End Property
    Public Property Empid() As Integer
        Get
            Return _Empid
        End Get
        Set(ByVal value As Integer)
            _Empid = value
        End Set
    End Property
    Private _S_score As Integer
    Public Property S_score() As Integer
        Get
            Return _S_score
        End Get
        Set(ByVal value As Integer)
            _S_score = value
        End Set
    End Property
    Private _M_score As Integer
    Public Property M_score() As Integer
        Get
            Return _M_score
        End Get
        Set(ByVal value As Integer)
            _M_score = value
        End Set
    End Property
    Private _R_score As Integer
    Public Property R_score() As Integer
        Get
            Return _R_score
        End Get
        Set(ByVal value As Integer)
            _R_score = value
        End Set
    End Property
    Private _F_score As Integer
    Public Property F_score() As Integer
        Get
            Return _F_score
        End Get
        Set(ByVal value As Integer)
            _F_score = value
        End Set
    End Property
    Private _P_Id As Integer
    Public Property P_Id() As Integer
        Get
            Return _P_Id
        End Get
        Set(ByVal value As Integer)
            _P_Id = value
        End Set
    End Property
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _APID As Integer
    Public Property APID() As Integer
        Get
            Return _APID
        End Get
        Set(ByVal value As Integer)
            _APID = value
        End Set
    End Property

End Class