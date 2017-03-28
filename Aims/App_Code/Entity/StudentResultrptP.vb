Imports Microsoft.VisualBasic
Namespace Student_ResultrptP
    Public Class RPT_StudentResult
        Private _ResultID As Long
        Private _ResultDetail_ID As Long
        Private _Marks As Decimal
        Private _Subject_Name As String
        Private _Grade As String
        Private _Emp_Name As String
        Private _BranchName As String
        Private _CourseName as string
        Private _InstituteName As String
        Private _StdName As String
        Private _StdCode As String
        Private _Max_Mark As Decimal
        Private _Min_Mark As Decimal
        Public Property Max_Mark() As Decimal
            Get
                Return _Max_Mark
            End Get
            Set(ByVal value As Decimal)
                _Max_Mark = value
            End Set
        End Property
        Public Property Min_Mark() As Decimal
            Get
                Return _Min_Mark
            End Get
            Set(ByVal value As Decimal)
                _Min_Mark = value
            End Set
        End Property

        Public Property ResultID() As Long
            Get
                Return _ResultID
            End Get
            Set(ByVal value As Long)
                _ResultID = value
            End Set
        End Property
        Public Property ResultDetails_ID() As Long
            Get
                Return _ResultDetail_ID
            End Get
            Set(ByVal value As Long)
                _ResultDetail_ID = value
            End Set
        End Property
        Public Property Marks() As Decimal
            Get
                Return _Marks
            End Get
            Set(ByVal value As Decimal)
                _Marks = value
            End Set
        End Property
        Public Property Subject_Name() As String
            Get
                Return _Subject_Name
            End Get
            Set(ByVal value As String)
                _Subject_Name = value
            End Set
        End Property
        Public Property Grade() As String
            Get
                Return _Grade
            End Get
            Set(ByVal value As String)
                _Grade = value
            End Set
        End Property
        Public Property Emp_Name() As String
            Get
                Return _Emp_Name
            End Get
            Set(ByVal value As String)
                _Emp_Name = value
            End Set
        End Property
        Public Property BranchName() As String
            Get
                Return _BranchName
            End Get
            Set(ByVal value As String)
                _BranchName = value
            End Set
        End Property
        Public Property CourseName() As String
            Get
                Return _CourseName
            End Get
            Set(ByVal value As String)
                _CourseName = value
            End Set
        End Property
        Public Property InstituteName() As String
            Get
                Return _InstituteName
            End Get
            Set(ByVal value As String)
                _InstituteName = value
            End Set
        End Property
        Public Property StdName() As String
            Get
                Return _StdName
            End Get
            Set(ByVal value As String)
                _StdName = value
            End Set
        End Property
        Public Property StdCode() As String
            Get
                Return _StdCode
            End Get
            Set(ByVal value As String)
                _StdCode = value
            End Set
        End Property
    End Class
End Namespace
