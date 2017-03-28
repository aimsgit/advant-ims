Imports Microsoft.VisualBasic

Public Class Budget
    Public _BudgetID As Integer
    Public Property BudgetID() As Integer
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As Integer)
            _BudgetID = value

        End Set
    End Property

    Public _Project_ID As Int64
    Public Property Project_ID() As Int64
        Get
            Return _Project_ID
        End Get
        Set(ByVal value As Int64)
            _Project_ID = value
        End Set
    End Property

    Public _Project_Estimate As Double
    Public Property Project_Estimate() As Double
        Get
            Return _Project_Estimate
        End Get
        Set(ByVal value As Double)
            _Project_Estimate = value
        End Set
    End Property

    Public _DateOfEstimation As DateTime
    Public Property DateOfEstimation() As DateTime
        Get
            Return _DateOfEstimation
        End Get
        Set(ByVal value As DateTime)
            _DateOfEstimation = value
        End Set
    End Property

    Public _Approved_Budget As Double
    Public Property Approved_Budget() As Double
        Get
            Return _Approved_Budget
        End Get
        Set(ByVal value As Double)
            _Approved_Budget = value
        End Set
    End Property


    Public _DateOfApproval As DateTime
    Public Property DateOfApproval() As DateTime
        Get
            Return _DateOfApproval
        End Get
        Set(ByVal value As DateTime)
            _DateOfApproval = value
        End Set
    End Property

    Public _Revised_Budget As Double
    Public Property Revised_Budget() As Double
        Get
            Return _Revised_Budget
        End Get
        Set(ByVal value As Double)
            _Revised_Budget = value
        End Set
    End Property
    Public _DateRevBudget As Date
    Public Property DateRevBudget() As Date
        Get
            Return _DateRevBudget
        End Get
        Set(ByVal value As Date)
            _DateRevBudget = value
        End Set

    End Property
    Public _Used_Budget As Double
    Public Property Used_Budget() As Double
        Get
            Return _Used_Budget
        End Get
        Set(ByVal value As Double)
            _Used_Budget = value
        End Set
    End Property

    Public _Status_Date As DateTime
    Public Property Status_Date() As DateTime
        Get
            Return _Status_Date
        End Get
        Set(ByVal value As DateTime)
            _Status_Date = value
        End Set
    End Property

    Public _Progress_Percent As Double
    Public Property Progress_Percent() As Double
        Get
            Return _Progress_Percent
        End Get
        Set(ByVal value As Double)
            _Progress_Percent = value
        End Set
    End Property

    Public _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
   
    Public _Year As Int64
    Public Property Year() As Int64
        Get
            Return _Year
        End Get
        Set(ByVal value As Int64)
            _Year = value
        End Set
    End Property
    Public _ProjectName As String
    Public Property ProjectName() As String
        Get
            Return _ProjectName
        End Get
        Set(ByVal value As String)
            _ProjectName = value
        End Set
    End Property
    Public _AmountUsed As Double
    Public Property AmountUsed() As Double
        Get
            Return _AmountUsed
        End Get
        Set(ByVal value As Double)
            _AmountUsed = value
        End Set
    End Property
    Public _AmountUsedPercent As Int64
    Public Property AmountUsedPercent() As Int64
        Get
            Return _AmountUsedPercent
        End Get
        Set(ByVal value As Int64)
            _AmountUsedPercent = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class
