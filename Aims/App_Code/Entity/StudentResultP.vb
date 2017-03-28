Imports Microsoft.VisualBasic
Namespace StudentResult
    <Serializable()> Public Class StudentResultP
        Private _userid As Integer
        Public Property UserId() As String
            Get
                Return _userid
            End Get
            Set(ByVal value As String)
                _userid = CInt(value)
            End Set
        End Property
        Private _Courseid As Integer
        Public Property CourseId() As String
            Get
                Return _Courseid
            End Get
            Set(ByVal value As String)
                _Courseid = CInt(value)
            End Set
        End Property
        Private _BatchNo As String
        Public Property BatchNo() As String
            Get
                Return _BatchNo
            End Get
            Set(ByVal value As String)
                _BatchNo = value
            End Set
        End Property
        Private _Subjectid As Integer
        Public Property Subjectid() As String
            Get
                Return _Subjectid
            End Get
            Set(ByVal value As String)
                _Subjectid = CInt(value)
            End Set
        End Property
        Private _AssessmentId As Integer
        Public Property AssessmentId() As String
            Get
                Return _AssessmentId
            End Get
            Set(ByVal value As String)
                _AssessmentId = CInt(value)
            End Set
        End Property
        Private _ClassType As String
        Public Property ClassType() As String
            Get
                Return _ClassType
            End Get
            Set(ByVal value As String)
                _ClassType = CInt(value)
            End Set
        End Property
        Private _SemesterId As Integer
        Public Property SemesterId() As String
            Get
                Return _SemesterId
            End Get
            Set(ByVal value As String)
                _SemesterId = CInt(value)
            End Set
        End Property
        Private _InstituteId As Integer

        Public Property InstituteId() As String
            Get
                Return _InstituteId
            End Get
            Set(ByVal value As String)
                _InstituteId = CInt(value)
            End Set
        End Property

        Private _BranchId As String
        Public Property BranchId() As String
            Get
                Return _BranchId
            End Get
            Set(ByVal value As String)
                _BranchId = CInt(value)
            End Set
        End Property

        Private _marks As Single
        Public Property marks() As Single
            Get
                Return _marks
            End Get
            Set(ByVal value As Single)
                _marks = value
            End Set
        End Property

        Private _maxmarks As Integer
        Public Property Maxmarks() As Integer
            Get
                Return _maxmarks
            End Get
            Set(ByVal value As Integer)
                _maxmarks = value
            End Set
        End Property

        Private _minmarks As Integer
        Public Property Minmarks() As Integer
            Get
                Return _minmarks
            End Get
            Set(ByVal value As Integer)
                _minmarks = value
            End Set
        End Property

        Private _skill As Integer
        Public Property Skill() As Integer
            Get
                Return _skill
            End Get
            Set(ByVal value As Integer)
                _skill = value
            End Set
        End Property
        Private _stdCode As Int64
        Public Property StdCode() As Int64
            Get
                Return _stdCode
            End Get
            Set(ByVal value As Int64)
                _stdCode = value
            End Set
        End Property
        Private _AYear As Int64
        Public Property AYear() As Int64
            Get
                Return _AYear
            End Get
            Set(ByVal value As Int64)
                _AYear = value
            End Set
        End Property

        Private _ResultId As Int64
        Public Property ReusltId() As Int64
            Get
                Return _ResultId
            End Get
            Set(ByVal value As Int64)
                _ResultId = value
            End Set
        End Property
        Private _Arrears As Boolean
        Public Property Arrears() As Boolean
            Get
                'Return _Arrears
            End Get
            Set(ByVal value As Boolean)
                _Arrears = value
            End Set
        End Property
    End Class
End Namespace
