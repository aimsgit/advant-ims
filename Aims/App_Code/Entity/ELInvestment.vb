Imports Microsoft.VisualBasic

Public Class ELInvestment
    Private _EmpID As String
    Public Property EmpID() As String
        Get
            Return _EmpID
        End Get
        Set(ByVal value As String)
            _EmpID = value
        End Set
    End Property
    
    Private _ID_ID As Int32
    Public Property ID_ID() As Int32
        Get
            Return _ID_ID
        End Get
        Set(ByVal value As Int32)
            _ID_ID = value
        End Set
    End Property
    Private _EmpIDAuto As Int32
    Public Property EmpIDAuto() As Int32
        Get
            Return _EmpIDAuto
        End Get
        Set(ByVal value As Int32)
            _EmpIDAuto = value
        End Set
    End Property
    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Private _EmpName As String
    Public Property EmpName() As String
        Get
            Return _EmpName
        End Get
        Set(ByVal value As String)
            _EmpName = value
        End Set
    End Property
    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property


    Private _PanNo As String
    Public Property PanNo() As String
        Get
            Return _PanNo
        End Get
        Set(ByVal value As String)
            _PanNo = value
        End Set
    End Property

    Private _DOJ As Date
    Public Property DOJ() As Date
        Get
            Return _DOJ
        End Get
        Set(ByVal value As Date)
            _DOJ = value
        End Set
    End Property
    Private _BankNo As String
    Public Property BankNo() As String
        Get
            Return _BankNo
        End Get
        Set(ByVal value As String)
            _BankNo = value
        End Set
    End Property
    Private _CellNo As String
    Public Property CellNo() As String
        Get
            Return _CellNo
        End Get
        Set(ByVal value As String)
            _CellNo = value
        End Set
    End Property

    Private _AccountNo As String
    Public Property AccountNo() As String
        Get
            Return _AccountNo
        End Get
        Set(ByVal value As String)
            _AccountNo = value
        End Set
    End Property

    Private _LICPremium As Double
    Public Property LICPremium() As Double
        Get
            Return _LICPremium
        End Get
        Set(ByVal value As Double)
            _LICPremium = value
        End Set
    End Property
    Private _PPF As Double
    Public Property PPF() As Double
        Get
            Return _PPF
        End Get
        Set(ByVal value As Double)
            _PPF = value
        End Set
    End Property
    Private _NSC As Double
    Public Property NSC() As Double
        Get
            Return _NSC
        End Get
        Set(ByVal value As Double)
            _NSC = value
        End Set
    End Property
    Private _IntOnNSC As Double
    Public Property IntOnNSC() As Double
        Get
            Return _IntOnNSC
        End Get
        Set(ByVal value As Double)
            _IntOnNSC = value
        End Set
    End Property
    Private _ULIP As Double
    Public Property ULIP() As Double
        Get
            Return _ULIP
        End Get
        Set(ByVal value As Double)
            _ULIP = value
        End Set
    End Property
    Private _ELSS As Double
    Public Property ELSS() As Double
        Get
            Return _ELSS
        End Get
        Set(ByVal value As Double)
            _ELSS = value
        End Set
    End Property
    Private _NotdMutualFund As Double
    Public Property NotdMutualFund() As Double
        Get
            Return _NotdMutualFund
        End Get
        Set(ByVal value As Double)
            _NotdMutualFund = value
        End Set
    End Property
    Private _PrincipalHL As Double
    Public Property PrincipalHL() As Double
        Get
            Return _PrincipalHL
        End Get
        Set(ByVal value As Double)
            _PrincipalHL = value
        End Set
    End Property
    Private _ChildEduFee As Double
    Public Property ChildEduFee() As Double
        Get
            Return _ChildEduFee
        End Get
        Set(ByVal value As Double)
            _ChildEduFee = value
        End Set
    End Property
    Private _FixedDeposit As Double
    Public Property FixedDeposit() As Double
        Get
            Return _FixedDeposit
        End Get
        Set(ByVal value As Double)
            _FixedDeposit = value
        End Set
    End Property
    Private _AnnuityPlan As Double
    Public Property AnnuityPlan() As Double
        Get
            Return _AnnuityPlan
        End Get
        Set(ByVal value As Double)
            _AnnuityPlan = value
        End Set
    End Property
    Private _SalSavScheme As Double
    Public Property SalSavScheme() As Double
        Get
            Return _SalSavScheme
        End Get
        Set(ByVal value As Double)
            _SalSavScheme = value
        End Set
    End Property
    Private _Others As Double
    Public Property Others() As Double
        Get
            Return _Others
        End Get
        Set(ByVal value As Double)
            _Others = value
        End Set
    End Property
    Private _Sec80CCC As Double
    Public Property Sec80CCC() As Double
        Get
            Return _Sec80CCC
        End Get
        Set(ByVal value As Double)
            _Sec80CCC = value
        End Set
    End Property
    Private _Sec80D As Double
    Public Property Sec80D() As Double
        Get
            Return _Sec80D
        End Get
        Set(ByVal value As Double)
            _Sec80D = value
        End Set
    End Property
    Private _Sec80DD As Double
    Public Property Sec80DD() As Double
        Get
            Return _Sec80DD
        End Get
        Set(ByVal value As Double)
            _Sec80DD = value
        End Set
    End Property
    Private _Sec80E As Double
    Public Property Sec80E() As Double
        Get
            Return _Sec80E
        End Get
        Set(ByVal value As Double)
            _Sec80E = value
        End Set
    End Property
    Private _Sec80U As Double
    Public Property Sec80U() As Double
        Get
            Return _Sec80U
        End Get
        Set(ByVal value As Double)
            _Sec80U = value
        End Set
    End Property
    Private _Sec80G As Double
    Public Property Sec80G() As Double
        Get
            Return _Sec80G
        End Get
        Set(ByVal value As Double)
            _Sec80G = value
        End Set
    End Property
    Private _Rent As Double
    Public Property Rent() As Double
        Get
            Return _Rent
        End Get
        Set(ByVal value As Double)
            _Rent = value
        End Set
    End Property
    Private _PropertyLocation As String
    Public Property PropertyLocation() As String
        Get
            Return _PropertyLocation
        End Get
        Set(ByVal value As String)
            _PropertyLocation = value
        End Set
    End Property

    Private _InterestOnHL As Double
    Public Property InterestOnHL() As Double
        Get
            Return _InterestOnHL
        End Get
        Set(ByVal value As Double)
            _InterestOnHL = value
        End Set
    End Property
    Private _LTA As Double
    Public Property LTA() As Double
        Get
            Return _LTA
        End Get
        Set(ByVal value As Double)
            _LTA = value
        End Set
    End Property
    Private _MedicalReimbursement As Double
    Public Property MedicalReimbursement() As Double
        Get
            Return _MedicalReimbursement
        End Get
        Set(ByVal value As Double)
            _MedicalReimbursement = value
        End Set
    End Property
    Private _InternetExp As Double
    Public Property InternetExp() As Double
        Get
            Return _InternetExp
        End Get
        Set(ByVal value As Double)
            _InternetExp = value
        End Set
    End Property
    Private _TelephoneExp As Double
    Public Property TelephoneExp() As Double
        Get
            Return _TelephoneExp
        End Get
        Set(ByVal value As Double)
            _TelephoneExp = value
        End Set
    End Property
    Private _FuelReimbursement As Double
    Public Property FuelReimbursement() As Double
        Get
            Return _FuelReimbursement
        End Get
        Set(ByVal value As Double)
            _FuelReimbursement = value
        End Set
    End Property


    Private _Dependent1 As String
    Public Property Dependent1() As String
        Get
            Return _Dependent1
        End Get
        Set(ByVal value As String)
            _Dependent1 = value
        End Set
    End Property

    Private _DepRelation1 As String
    Public Property DepRelation1() As String
        Get
            Return _DepRelation1
        End Get
        Set(ByVal value As String)
            _DepRelation1 = value
        End Set
    End Property

    Private _Dependent2 As String
    Public Property Dependent2() As String
        Get
            Return _Dependent2
        End Get
        Set(ByVal value As String)
            _Dependent2 = value
        End Set
    End Property

    Private _DepRelation2 As String
    Public Property DepRelation2() As String
        Get
            Return _DepRelation2
        End Get
        Set(ByVal value As String)
            _DepRelation2 = value
        End Set
    End Property

    Private _Dependent3 As String
    Public Property Dependent3() As String
        Get
            Return _Dependent3
        End Get
        Set(ByVal value As String)
            _Dependent3 = value
        End Set
    End Property

    Private _DepRelation3 As String
    Public Property DepRelation3() As String
        Get
            Return _DepRelation3
        End Get
        Set(ByVal value As String)
            _DepRelation3 = value
        End Set
    End Property

    Private _Dependent4 As String
    Public Property Dependent4() As String
        Get
            Return _Dependent4
        End Get
        Set(ByVal value As String)
            _Dependent4 = value
        End Set
    End Property

    Private _DepRelation4 As String
    Public Property DepRelation4() As String
        Get
            Return _DepRelation4
        End Get
        Set(ByVal value As String)
            _DepRelation4 = value
        End Set
    End Property

    Private _Dependent5 As String
    Public Property Dependent5() As String
        Get
            Return _Dependent5
        End Get
        Set(ByVal value As String)
            _Dependent5 = value
        End Set
    End Property

    Private _DepRelation5 As String
    Public Property DepRelation5() As String
        Get
            Return _DepRelation5
        End Get
        Set(ByVal value As String)
            _DepRelation5 = value
        End Set
    End Property

    Private _Dependent6 As String
    Public Property Dependent6() As String
        Get
            Return _Dependent6
        End Get
        Set(ByVal value As String)
            _Dependent6 = value
        End Set
    End Property

    Private _DepRelation6 As String
    Public Property DepRelation6() As String
        Get
            Return _DepRelation6
        End Get
        Set(ByVal value As String)
            _DepRelation6 = value
        End Set
    End Property

    Private _Dependent7 As String
    Public Property Dependent7() As String
        Get
            Return _Dependent7
        End Get
        Set(ByVal value As String)
            _Dependent7 = value
        End Set
    End Property

    Private _DepRelation7 As String
    Public Property DepRelation7() As String
        Get
            Return _DepRelation7
        End Get
        Set(ByVal value As String)
            _DepRelation7 = value
        End Set
    End Property

    Private _Agree As String
    Public Property Agree() As String
        Get
            Return _Agree
        End Get
        Set(ByVal value As String)
            _Agree = value
        End Set
    End Property

End Class
