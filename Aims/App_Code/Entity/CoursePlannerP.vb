Imports Microsoft.VisualBasic
Namespace CourcePlanner
    Public Class CoursePlannerP
        Private _ID As Int64
        Public Property ID() As Int64
            Get
                Return _ID
            End Get
            Set(ByVal value As Int64)
                _ID = value
            End Set
        End Property
        Private _InsId As Int32
        Public Property Insid() As Int32
            Get
                Return _InsId
            End Get
            Set(ByVal value As Int32)
                _InsId = value
            End Set
        End Property
        Private _BranchId As Int32
        Public Property BranchId() As Int32
            Get
                Return _BranchId
            End Get
            Set(ByVal value As Int32)
                _BranchId = value
            End Set
        End Property
        Private _CourseId As Int32
        Public Property CourseId() As Int32
            Get
                Return _CourseId
            End Get
            Set(ByVal value As Int32)
                _CourseId = value
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
        Private _C_Duration As String
        Public Property CourseDuration() As String
            Get
                Return _C_Duration
            End Get
            Set(ByVal value As String)
                _C_Duration = value
            End Set
        End Property
        Private _DurationRemarks As String
        Public Property DurationRemarks() As String
            Get
                Return _DurationRemarks
            End Get
            Set(ByVal value As String)
                _DurationRemarks = value
            End Set
        End Property
        Private _DateCommencement As Date
        Public Property DateCommencement() As Date
            Get
                Return _DateCommencement
            End Get
            Set(ByVal value As Date)
                _DateCommencement = value
            End Set
        End Property
        Private _DateCompletion As Date
        Public Property DateCompletion() As Date
            Get
                Return _DateCompletion
            End Get
            Set(ByVal value As Date)
                _DateCompletion = value
            End Set
        End Property
        Private _FinalExamDate As Date
        Public Property FinalExamDate() As Date
            Get
                Return _FinalExamDate
            End Get
            Set(ByVal value As Date)
                _FinalExamDate = value
            End Set
        End Property
        Private _ResultOn As Date
        Public Property ResultOn() As Date
            Get
                Return _ResultOn
            End Get
            Set(ByVal value As Date)
                _ResultOn = value
            End Set
        End Property
        Private _NoDays As Int32
        Public Property NoDays() As Int32
            Get
                Return _NoDays
            End Get
            Set(ByVal value As Int32)
                _NoDays = value
            End Set
        End Property
        Private _NoHoliDays As Int32
        Public Property NoHolidays() As Int32
            Get
                Return _NoHoliDays
            End Get
            Set(ByVal value As Int32)
                _NoHoliDays = value
            End Set
        End Property
        Private _NoWorkingDays As Int32
        Public Property NoWorkingDays() As Int32
            Get
                Return _NoWorkingDays
            End Get
            Set(ByVal value As Int32)
                _NoWorkingDays = value
            End Set
        End Property
        Private _SessionPerDay As Int16
        Public Property SessionPerDay() As Int16
            Get
                Return _SessionPerDay
            End Get
            Set(ByVal value As Int16)
                _SessionPerDay = value
            End Set
        End Property
        Private _ExamDays As Int16
        Public Property ExamDays() As Int16
            Get
                Return _ExamDays
            End Get
            Set(ByVal value As Int16)
                _ExamDays = value
            End Set
        End Property
        Private _SessionAllotment As String
        Public Property SessionAllotment() As String
            Get
                Return _SessionAllotment
            End Get
            Set(ByVal value As String)
                _SessionAllotment = value
            End Set
        End Property
        Private _coordinator As String
        Public Property Coordinator() As String
            Get
                Return _coordinator
            End Get
            Set(ByVal value As String)
                _coordinator = value
            End Set
        End Property
        Private _name As String
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Sub New(ByVal ID As Int64, ByVal Name As String)
            _ID = ID
            _name = Name
        End Sub
        Public Sub New(ByVal Name As String)
            _name = Name
        End Sub
        Public Sub New()
        End Sub
    End Class
End Namespace
