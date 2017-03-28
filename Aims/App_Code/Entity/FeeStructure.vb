Imports Microsoft.VisualBasic
Imports System

Public Class FeeStructure
    Sub New()

    End Sub
    Sub New(ByVal PaymentMethodID As Int64, ByVal Payment_Method As String)
        Me._methodId = PaymentMethodID
        Me._method = Payment_Method
    End Sub
    Sub New(ByVal _institute_ID As Long, ByVal _baranch_ID As Long, ByVal _fee_Structure_ID As Int64, ByVal _course_Planner_ID As Int64, ByVal _semester_ID As Int16, ByVal _fee_Head_ID As Integer, ByVal _amount As Double, ByVal _due_Date As Date, ByVal _remarks As String, ByVal Sponsor As Int64, ByVal Discount As Int64)
        Me._institute_ID = _institute_ID
        Me._baranch_ID = _baranch_ID
        Me._fee_Structure_ID = _fee_Structure_ID
        Me._course_Planner_ID = _course_Planner_ID
        Me._semester_ID = _semester_ID
        Me._fee_Head_ID = _fee_Head_ID
        Me._amount = _amount
        Me._due_Date = _due_Date
        Me._remarks = _remarks
        _Sponsor = Sponsor
        _Discount = Discount
    End Sub
    Sub New(ByVal _institute_ID As Long, ByVal _baranch_ID As Long, ByVal _fee_Structure_ID As Int64, ByVal _course_Id As Long, ByVal _course_Planner_ID As Int64, ByVal _semester_ID As Int16, ByVal _fee_Head_ID As Integer, ByVal _amount As Double, ByVal _due_Date As Date, ByVal _remarks As String, ByVal Sponsor As Int64, ByVal Discount As Int64)
        'Sub New(ByVal _institute_ID As Long, ByVal _baranch_ID As Long, ByVal _fee_Structure_ID As Int64, ByVal _course_Id As Long, ByVal _course_Name As String, ByVal _course_Planner_ID As Int64, ByVal _batch_No As String, ByVal _semester_ID As Int16, ByVal _semster_Name As String, ByVal _fee_Head_ID As Integer, ByVal _feeHead_Name As String, ByVal _amount As Double, ByVal _due_Date As Date, ByVal _remarks As String)
        Me._institute_ID = _institute_ID
        Me._baranch_ID = _baranch_ID
        Me._fee_Structure_ID = _fee_Structure_ID
        Me._course_Id = _course_Id
        'Me._course_Name = _course_Name
        Me._course_Planner_ID = _course_Planner_ID
        'Me._batch_No = _batch_No
        Me._semester_ID = _semester_ID
        'Me._semster_Name = _semster_Name
        Me._fee_Head_ID = _fee_Head_ID
        'Me._feeHead_Name = _feeHead_Name
        Me._amount = _amount
        Me._due_Date = _due_Date
        Me._remarks = _remarks
        _Sponsor = Sponsor
        _Discount = Discount
    End Sub
    Sub New(ByVal _institute_ID As Long, ByVal _baranch_ID As Long, ByVal _fee_Structure_ID As Int64, ByVal _course_Id As Long, ByVal _course_Name As String, ByVal _course_Planner_ID As Int64, ByVal _batch_No As String, ByVal _semester_ID As Int16, ByVal _semster_Name As String, ByVal _fee_Head_ID As Integer, ByVal _feeHead_Name As String, ByVal _amount As Double, ByVal _due_Date As Date, ByVal _remarks As String, ByVal Sponsor As Int64, ByVal Discount As Int64)
        Me._institute_ID = _institute_ID
        Me._baranch_ID = _baranch_ID
        Me._fee_Structure_ID = _fee_Structure_ID
        Me._course_Id = _course_Id
        Me._course_Name = _course_Name
        Me._course_Planner_ID = _course_Planner_ID
        Me._batch_No = _batch_No
        Me._semester_ID = _semester_ID
        Me._semster_Name = _semster_Name
        Me._fee_Head_ID = _fee_Head_ID
        Me._feeHead_Name = _feeHead_Name
        Me._amount = _amount
        Me._due_Date = _due_Date
        Me._remarks = _remarks
        _Sponsor = Sponsor
        _Discount = Discount
    End Sub
    Private _Sponsor As Int64
    Public Property Sponsor() As Int64
        Get
            Return _Sponsor
        End Get
        Set(ByVal value As Int64)
            _Sponsor = value
        End Set
    End Property
    Private _Discount As Int64
    Public Property Discount() As Int64
        Get
            Return _Discount
        End Get
        Set(ByVal value As Int64)
            _Discount = value
        End Set
    End Property
    Private _id As Int64
    Public Property ID() As Int64
        Get
            Return _id
        End Get
        Set(ByVal value As Int64)
            _id = value
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
    Private _method As String
    Public Property Payment_Method() As String
        Get
            Return _method
        End Get
        Set(ByVal value As String)
            _method = value
        End Set
    End Property
    Private _methodId As String
    Public Property PaymentMethodID() As String
        Get
            Return _methodId
        End Get
        Set(ByVal value As String)
            _methodId = value
        End Set
    End Property
    Private _institute_ID As Long
    Public Property Institute_ID() As Long
        Get
            Return _institute_ID
        End Get
        Set(ByVal value As Long)
            _institute_ID = value
        End Set
    End Property

    Private _baranch_ID As Long
    Public Property Baranch_ID() As Long
        Get
            Return _baranch_ID
        End Get
        Set(ByVal value As Long)
            _baranch_ID = value
        End Set
    End Property

    Private _fee_Structure_ID As Int64
    Public Property Fee_Structure_ID() As Int64
        Get
            Return _fee_Structure_ID
        End Get
        Set(ByVal value As Int64)
            _fee_Structure_ID = value
        End Set
    End Property

    Private _course_Planner_ID As Int64
    Public Property Course_Planner_ID() As Int64
        Get
            Return _course_Planner_ID
        End Get
        Set(ByVal value As Int64)
            _course_Planner_ID = value
        End Set
    End Property

    Private _semester_ID As Int16
    Public Property Semester_ID() As Int16
        Get
            Return _semester_ID
        End Get
        Set(ByVal value As Int16)
            _semester_ID = value
        End Set
    End Property

    Private _fee_Head_ID As Integer
    Public Property Fee_Head_ID() As Integer
        Get
            Return _fee_Head_ID
        End Get
        Set(ByVal value As Integer)
            _fee_Head_ID = value
        End Set
    End Property

    Private _amount As Double
    Public Property Amount() As Integer
        Get
            Return _amount
        End Get
        Set(ByVal value As Integer)
            _amount = value
        End Set
    End Property

    Private _due_Date As Date
    Public Property Due_date() As Date
        Get
            Return _due_Date
        End Get
        Set(ByVal value As Date)
            _due_Date = value
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

    Private _del_Flag As Int16
    Public Property Del_Falg() As Int16
        Get
            Return _del_Flag
        End Get
        Set(ByVal value As Int16)
            _del_Flag = value
        End Set
    End Property

    Private _feeHead_Name As String
    Public Property Fee_Head_Name() As String
        Get
            Return _feeHead_Name
        End Get
        Set(ByVal value As String)
            _feeHead_Name = value
        End Set
    End Property

    Private _semster_Name As String
    Public Property Semster_Name() As String
        Get
            Return _semster_Name
        End Get
        Set(ByVal value As String)
            _semster_Name = value
        End Set
    End Property

    Private _batch_No As String
    Public Property Batch_No() As String
        Get
            Return _batch_No
        End Get
        Set(ByVal value As String)
            _batch_No = value
        End Set
    End Property

    Private _course_Name As String
    Public Property Coure_Name() As String
        Get
            Return _course_Name
        End Get
        Set(ByVal value As String)
            _course_Name = value
        End Set
    End Property

    Private _course_Id As Long
    Public Property Course_ID() As Long
        Get
            Return _course_Id
        End Get
        Set(ByVal value As Long)
            _course_Id = value
        End Set
    End Property
    Private _Category As Long
    Public Property Category() As Long
        Get
            Return _Category
        End Get
        Set(ByVal value As Long)
            _Category = value
        End Set
    End Property

End Class
