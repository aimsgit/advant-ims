Imports Microsoft.VisualBasic
Namespace EntNoDue
    Public Class EntNoDue
        Private _dueid As Long
        Public Property DueId() As Long
            Get
                Return _dueid
            End Get
            Set(ByVal value As Long)
                _dueid = value
            End Set
        End Property
        Private _institute As Int32
        Public Property Institute() As Int32
            Get
                Return _institute
            End Get
            Set(ByVal value As Int32)
                _institute = value
            End Set
        End Property
        Private _branch As Int32
        Public Property Branch() As Int32
            Get
                Return _branch
            End Get
            Set(ByVal value As Int32)
                _branch = value
            End Set
        End Property
        Private _course As Int32
        Public Property Course() As Int32
            Get
                Return _course
            End Get
            Set(ByVal value As Int32)
                _course = value
            End Set
        End Property
        Private _batchno As String
        Public Property BatchNo() As String
            Get
                Return _batchno
            End Get
            Set(ByVal value As String)
                _batchno = value
            End Set
        End Property
        Private _deptid As Int32
        Public Property DeptId() As Int32
            Get
                Return _deptid
            End Get
            Set(ByVal value As Int32)
                _deptid = value
            End Set
        End Property
        Private _stdid As Int32
        Public Property StdId() As Int32
            Get
                Return _stdid
            End Get
            Set(ByVal value As Int32)
                _stdid = value
            End Set
        End Property
        Private _performance As String
        Public Property Performance() As String
            Get
                Return _performance
            End Get
            Set(ByVal value As String)
                _performance = value
            End Set
        End Property
        Private _remarks As String
        Public Property Remarks() As String
            Get
                Return _remarks
            End Get
            Set(ByVal value As String)
                _remarks = value
            End Set
        End Property
        Public Sub New()
        End Sub
        Public Sub New(ByVal dueid As Long, ByVal institute As Int32, ByVal branch As Int32, ByVal course As Int32, ByVal batchno As String, ByVal deptid As Int32, ByVal stdid As Int32, ByVal performance As String, ByVal remarks As String)
            _dueid = dueid
            _institute = institute
            _branch = branch
            _course = course
            _batchno = batchno
            _deptid = deptid
            _stdid = stdid
            _performance = performance
            _remarks = remarks
        End Sub
        Private _deleteflag As Int16
        Public Property DeleteFlag() As Int16
            Get
                Return _deleteflag
            End Get
            Set(ByVal value As Int16)
                _deleteflag = value
            End Set
        End Property
    End Class
End Namespace