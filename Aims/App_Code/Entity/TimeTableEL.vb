Imports Microsoft.VisualBasic

Public Class TimeTableEL
    Private _id As Int64
    Public Property Id() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
        End Set
    End Property
    Private _hmid As Int64
    Public Property HMId() As Int64
        Get
            Return _hmid
        End Get
        Set(ByVal value As Int64)
            _hmid = value
        End Set
    End Property
    Private _courseid As Integer
    Public Property CourseId() As Integer
        Get
            Return _courseid
        End Get
        Set(ByVal value As Integer)
            _courseid = value
        End Set
    End Property
    Private _batchid As Integer
    Public Property BatchId() As Integer
        Get
            Return _batchid
        End Get
        Set(ByVal value As Integer)
            _batchid = value
        End Set
    End Property
    Private _semid As Integer
    Public Property SemId() As Integer
        Get
            Return _semid
        End Get
        Set(ByVal value As Integer)
            _semid = value
        End Set
    End Property
    Private _teacherId As Integer
    Public Property TeacherId() As Integer
        Get
            Return _teacherId
        End Get
        Set(ByVal value As Integer)
            _teacherId = value
        End Set
    End Property
    Private _subId As Integer
    Public Property SubjectId() As Integer
        Get
            Return _subId
        End Get
        Set(ByVal value As Integer)
            _subId = value
        End Set
    End Property
    Private _period As String
    Public Property Period() As String
        Get
            Return _period
        End Get
        Set(ByVal value As String)
            _period = value
        End Set
    End Property
    Private _day1Sub As Integer
    Public Property Day1Sub() As Integer
        Get
            Return _day1Sub
        End Get
        Set(ByVal value As Integer)
            _day1Sub = value
        End Set
    End Property

    Private _day2Sub As Integer
    Public Property Day2Sub() As Integer
        Get
            Return _day2Sub
        End Get
        Set(ByVal value As Integer)
            _day2Sub = value
        End Set
    End Property
    Private _day3Sub As Integer
    Public Property Day3Sub() As Integer
        Get
            Return _day3Sub
        End Get
        Set(ByVal value As Integer)
            _day3Sub = value
        End Set
    End Property
    Private _day4Sub As Integer
    Public Property Day4Sub() As Integer
        Get
            Return _day4Sub
        End Get
        Set(ByVal value As Integer)
            _day4Sub = value
        End Set
    End Property
    Private _day5Sub As Integer
    Public Property Day5Sub() As Integer
        Get
            Return _day5Sub
        End Get
        Set(ByVal value As Integer)
            _day5Sub = value
        End Set
    End Property
    Private _day6Sub As Integer
    Public Property Day6Sub() As Integer
        Get
            Return _day6Sub
        End Get
        Set(ByVal value As Integer)
            _day6Sub = value
        End Set
    End Property
    Private _day7Sub As Integer
    Public Property Day7Sub() As Integer
        Get
            Return _day7Sub
        End Get
        Set(ByVal value As Integer)
            _day7Sub = value
        End Set
    End Property
    Private _day1Teacher As Integer
    Public Property Day1Teacher() As Integer
        Get
            Return _day1Teacher
        End Get
        Set(ByVal value As Integer)
            _day1Teacher = value
        End Set
    End Property
    Private _day2Teacher As Integer
    Public Property Day2Teacher() As Integer
        Get
            Return _day2Teacher
        End Get
        Set(ByVal value As Integer)
            _day2Teacher = value
        End Set
    End Property
    Private _day3Teacher As Integer
    Public Property Day3Teacher() As Integer
        Get
            Return _day3Teacher
        End Get
        Set(ByVal value As Integer)
            _day3Teacher = value
        End Set
    End Property
    Private _day4Teacher As Integer
    Public Property Day4Teacher() As Integer
        Get
            Return _day4Teacher
        End Get
        Set(ByVal value As Integer)
            _day4Teacher = value
        End Set
    End Property
    Private _day5Teacher As Integer
    Public Property Day5Teacher() As Integer
        Get
            Return _day5Teacher
        End Get
        Set(ByVal value As Integer)
            _day5Teacher = value
        End Set
    End Property
    Private _day6Teacher As Integer
    Public Property Day6Teacher() As Integer
        Get
            Return _day6Teacher
        End Get
        Set(ByVal value As Integer)
            _day6Teacher = value
        End Set
    End Property
    Private _day7Teacher As Integer
    Public Property Day7Teacher() As Integer
        Get
            Return _day7Teacher
        End Get
        Set(ByVal value As Integer)
            _day7Teacher = value
        End Set
    End Property
    Private _day1StartTime As DateTime
    Public Property Day1StartTime() As DateTime
        Get
            Return _day1StartTime
        End Get
        Set(ByVal value As DateTime)
            _day1StartTime = value
        End Set
    End Property
    Private _day2StartTime As DateTime
    Public Property Day2StartTime() As DateTime
        Get
            Return _day2StartTime
        End Get
        Set(ByVal value As DateTime)
            _day2StartTime = value
        End Set
    End Property
    Private _day3StartTime As DateTime
    Public Property Day3StartTime() As DateTime
        Get
            Return _day3StartTime
        End Get
        Set(ByVal value As DateTime)
            _day3StartTime = value
        End Set
    End Property
    Private _day4StartTime As DateTime
    Public Property Day4StartTime() As DateTime
        Get
            Return _day4StartTime
        End Get
        Set(ByVal value As DateTime)
            _day4StartTime = value
        End Set
    End Property
    Private _day5StartTime As DateTime
    Public Property Day5StartTime() As DateTime
        Get
            Return _day5StartTime
        End Get
        Set(ByVal value As DateTime)
            _day5StartTime = value
        End Set
    End Property
    Private _day6StartTime As DateTime
    Public Property Day6StartTime() As DateTime
        Get
            Return _day6StartTime
        End Get
        Set(ByVal value As DateTime)
            _day6StartTime = value
        End Set
    End Property
    Private _day7StartTime As DateTime
    Public Property Day7StartTime() As DateTime
        Get
            Return _day7StartTime
        End Get
        Set(ByVal value As DateTime)
            _day7StartTime = value
        End Set
    End Property

    Private _day1EndTime As DateTime
    Public Property Day1EndTime() As DateTime
        Get
            Return _day1EndTime
        End Get
        Set(ByVal value As DateTime)
            _day1EndTime = value
        End Set
    End Property
    Private _day2EndTime As DateTime
    Public Property Day2EndTime() As DateTime
        Get
            Return _day2EndTime
        End Get
        Set(ByVal value As DateTime)
            _day2EndTime = value
        End Set
    End Property
    Private _day3EndTime As DateTime
    Public Property Day3EndTime() As DateTime
        Get
            Return _day3EndTime
        End Get
        Set(ByVal value As DateTime)
            _day3EndTime = value
        End Set
    End Property
    Private _day4EndTime As DateTime
    Public Property Day4EndTime() As DateTime
        Get
            Return _day4EndTime
        End Get
        Set(ByVal value As DateTime)
            _day4EndTime = value
        End Set
    End Property
    Private _day5EndTime As DateTime
    Public Property Day5EndTime() As DateTime
        Get
            Return _day5EndTime
        End Get
        Set(ByVal value As DateTime)
            _day5EndTime = value
        End Set
    End Property
    Private _day6EndTime As DateTime
    Public Property Day6EndTime() As DateTime
        Get
            Return _day6EndTime
        End Get
        Set(ByVal value As DateTime)
            _day6EndTime = value
        End Set
    End Property
    Private _day7EndTime As DateTime
    Public Property Day7EndTime() As DateTime
        Get
            Return _day7EndTime
        End Get
        Set(ByVal value As DateTime)
            _day7EndTime = value
        End Set
    End Property

    Private _RId1 As Integer
    Public Property RId1() As Integer
        Get
            Return _RId1
        End Get
        Set(ByVal value As Integer)
            _RId1 = value
        End Set
    End Property
    Private _RId2 As Integer
    Public Property RId2() As Integer
        Get
            Return _RId2
        End Get
        Set(ByVal value As Integer)
            _RId2 = value
        End Set
    End Property
    Private _RId3 As Integer
    Public Property RId3() As Integer
        Get
            Return _RId3
        End Get
        Set(ByVal value As Integer)
            _RId3 = value
        End Set
    End Property
    Private _RId4 As Integer
    Public Property RId4() As Integer
        Get
            Return _RId4
        End Get
        Set(ByVal value As Integer)
            _RId4 = value
        End Set
    End Property
    Private _RId5 As Integer
    Public Property RId5() As Integer
        Get
            Return _RId5
        End Get
        Set(ByVal value As Integer)
            _RId5 = value
        End Set
    End Property
    Private _RId6 As Integer
    Public Property RId6() As Integer
        Get
            Return _RId6
        End Get
        Set(ByVal value As Integer)
            _RId6 = value
        End Set
    End Property
    Private _RId7 As Integer
    Public Property RId7() As Integer
        Get
            Return _RId7
        End Get
        Set(ByVal value As Integer)
            _RId7 = value
        End Set
    End Property
    Private _Remarks1 As String
    Public Property Remarks1() As String
        Get
            Return _Remarks1
        End Get
        Set(ByVal value As String)
            _Remarks1 = value
        End Set
    End Property
    Private _Remarks2 As String
    Public Property Remarks2() As String
        Get
            Return _Remarks2
        End Get
        Set(ByVal value As String)
            _Remarks2 = value
        End Set
    End Property
    Private _Remarks3 As String
    Public Property Remarks3() As String
        Get
            Return _Remarks3
        End Get
        Set(ByVal value As String)
            _Remarks3 = value
        End Set
    End Property
    Private _Remarks4 As String
    Public Property Remarks4() As String
        Get
            Return _Remarks4
        End Get
        Set(ByVal value As String)
            _Remarks4 = value
        End Set
    End Property
    Private _Remarks5 As String
    Public Property Remarks5() As String
        Get
            Return _Remarks5
        End Get
        Set(ByVal value As String)
            _Remarks5 = value
        End Set
    End Property
    Private _Remarks6 As String
    Public Property Remarks6() As String
        Get
            Return _Remarks6
        End Get
        Set(ByVal value As String)
            _Remarks6 = value
        End Set
    End Property
    Private _Remarks7 As String
    Public Property Remarks7() As String
        Get
            Return _Remarks7
        End Get
        Set(ByVal value As String)
            _Remarks7 = value
        End Set
    End Property
    Private _WeekNo As String
    Public Property WeekNo() As Integer
        Get
            Return _WeekNo
        End Get
        Set(ByVal value As Integer)
            _WeekNo = value
        End Set
    End Property
End Class
