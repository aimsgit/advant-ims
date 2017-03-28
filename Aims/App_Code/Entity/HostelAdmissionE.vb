Imports Microsoft.VisualBasic

Public Class HostelAdmissionE

    Private _Temp As Integer
    Public Property Temp() As Integer
        Get
            Return _Temp
        End Get
        Set(ByVal value As Integer)
            _Temp = value
        End Set
    End Property
    Private _HostelBranchcode As String
    Public Property HostelBranchcode() As String
        Get
            Return _HostelBranchcode
        End Get
        Set(ByVal value As String)
            _HostelBranchcode = value
        End Set
    End Property
    Private _RoomNo2 As String
    Public Property Room_No2() As String
        Get
            Return _RoomNo2
        End Get
        Set(ByVal value As String)
            _RoomNo2 = value
        End Set
    End Property
    Private _HDID As Integer

    Public Property HDID() As Integer
        Get
            Return _HDID
        End Get
        Set(ByVal value As Integer)
            _HDID = value
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
    Private _SeatNo As Integer
    Public Property SeatNo() As Integer
        Get
            Return _SeatNo
        End Get
        Set(ByVal value As Integer)
            _SeatNo = value
        End Set
    End Property
    Private A_Year1 As Integer
    Public Property AYear1() As Integer
        Get
            Return A_Year1
        End Get
        Set(ByVal value As Integer)
            A_Year1 = value
        End Set
    End Property

    Private CourseId1 As Integer
    Public Property CId1() As Integer
        Get
            Return CourseId1
        End Get
        Set(ByVal value As Integer)
            CourseId1 = value
        End Set
    End Property

    Private BatchId1 As Integer
    Public Property BId1() As Integer
        Get
            Return BatchId1
        End Get
        Set(ByVal value As Integer)
            BatchId1 = value
        End Set
    End Property


    Private _admissiondate1 As Date
    Public Property AdmissionDate1() As Date
        Get
            Return _admissiondate1
        End Get
        Set(ByVal value As Date)
            _admissiondate1 = value
        End Set
    End Property
    Private _DOL As Date
    Public Property DOL() As Date
        Get
            Return _DOL
        End Get
        Set(ByVal value As Date)
            _DOL = value
        End Set
    End Property

    Private _Hid As Integer
    Public Property Hid() As Integer
        Get
            Return _Hid
        End Get
        Set(ByVal value As Integer)
            _Hid = value
        End Set
    End Property
    Private _Hostelid As Integer
    Public Property Hostelid() As Integer
        Get
            Return _Hostelid
        End Get
        Set(ByVal value As Integer)
            _Hostelid = value
        End Set
    End Property



    Private _studId1 As Integer
    Public Property StudId1() As Integer
        Get
            Return _studId1
        End Get
        Set(ByVal value As Integer)
            _studId1 = value
        End Set
    End Property

    Private _studId2 As Integer
    Public Property StudId2() As Integer
        Get
            Return _studId2
        End Get
        Set(ByVal value As Integer)
            _studId2 = value
        End Set
    End Property
    Private _studId3 As Integer
    Public Property StudId3() As Integer
        Get
            Return _studId3
        End Get
        Set(ByVal value As Integer)
            _studId3 = value
        End Set
    End Property
    Private _studId4 As Integer
    Public Property StudId4() As Integer
        Get
            Return _studId4
        End Get
        Set(ByVal value As Integer)
            _studId4 = value
        End Set
    End Property
    Private _studName As String
    Public Property StudName() As String
        Get
            Return _studName
        End Get
        Set(ByVal value As String)
            _studName = value
        End Set
    End Property
    Private _roomNo As String
    Public Property RoomNo() As String
        Get
            Return _roomNo
        End Get
        Set(ByVal value As String)
            _roomNo = value
        End Set
    End Property
    Private _studAdd1 As String
    Public Property StudAdd1() As String
        Get
            Return _studAdd1
        End Get
        Set(ByVal value As String)
            _studAdd1 = value
        End Set
    End Property

    Private _studAdd2 As String
    Public Property StudAdd2() As String
        Get
            Return _studAdd2
        End Get
        Set(ByVal value As String)
            _studAdd2 = value
        End Set
    End Property
    Private _studAdd3 As String
    Public Property StudAdd3() As String
        Get
            Return _studAdd3
        End Get
        Set(ByVal value As String)
            _studAdd3 = value
        End Set
    End Property
    Private _studAdd4 As String
    Public Property StudAdd4() As String
        Get
            Return _studAdd4
        End Get
        Set(ByVal value As String)
            _studAdd4 = value
        End Set
    End Property
    Private _bloodgroup1 As String
    Public Property BloodGroup1() As String
        Get
            Return _bloodgroup1
        End Get
        Set(ByVal value As String)
            _bloodgroup1 = value
        End Set
    End Property
    Private _bloodgroup2 As String
    Public Property BloodGroup2() As String
        Get
            Return _bloodgroup2
        End Get
        Set(ByVal value As String)
            _bloodgroup2 = value
        End Set
    End Property
    Private _bloodgroup3 As String
    Public Property BloodGroup3() As String
        Get
            Return _bloodgroup3
        End Get
        Set(ByVal value As String)
            _bloodgroup3 = value
        End Set
    End Property
    Private _bloodgroup4 As String
    Public Property BloodGroup4() As String
        Get
            Return _bloodgroup4
        End Get
        Set(ByVal value As String)
            _bloodgroup4 = value
        End Set
    End Property
    Private _Ayear As String
    Public Property Ayear() As String
        Get
            Return _Ayear
        End Get
        Set(ByVal value As String)
            _Ayear = value
        End Set
    End Property
    Private _Crs As String
    Public Property Crs() As String
        Get
            Return _Crs
        End Get
        Set(ByVal value As String)
            _Crs = value
        End Set
    End Property
    Private _Btch As String
    Public Property Btch() As String
        Get
            Return _Btch
        End Get
        Set(ByVal value As String)
            _Btch = value
        End Set
    End Property
    Private _LGname1 As String
    Public Property LGName1() As String
        Get
            Return _LGname1
        End Get
        Set(ByVal value As String)
            _LGname1 = value
        End Set
    End Property
    Private _LGname2 As String
    Public Property LGName2() As String
        Get
            Return _LGname2
        End Get
        Set(ByVal value As String)
            _LGname2 = value
        End Set
    End Property
    Private _LGname3 As String
    Public Property LGName3() As String
        Get
            Return _LGname3
        End Get
        Set(ByVal value As String)
            _LGname3 = value
        End Set
    End Property
    Private _LGname4 As String
    Public Property LGName4() As String
        Get
            Return _LGname4
        End Get
        Set(ByVal value As String)
            _LGname4 = value
        End Set
    End Property
    Private _LGaddr1 As String
    Public Property LGAddress1() As String
        Get
            Return _LGaddr1
        End Get
        Set(ByVal value As String)
            _LGaddr1 = value
        End Set
    End Property
    Private _LGaddr2 As String
    Public Property LGAddress2() As String
        Get
            Return _LGaddr2
        End Get
        Set(ByVal value As String)
            _LGaddr2 = value
        End Set
    End Property
    Private _LGaddr3 As String
    Public Property LGAddress3() As String
        Get
            Return _LGaddr3
        End Get
        Set(ByVal value As String)
            _LGaddr3 = value
        End Set
    End Property
    Private _LGaddr4 As String
    Public Property LGAddress4() As String
        Get
            Return _LGaddr4
        End Get
        Set(ByVal value As String)
            _LGaddr4 = value
        End Set
    End Property
    Private _LGemail1 As String
    Public Property LGEmail1() As String
        Get
            Return _LGemail1
        End Get
        Set(ByVal value As String)
            _LGemail1 = value
        End Set
    End Property
    Private _LGemail2 As String
    Public Property LGEmail2() As String
        Get
            Return _LGemail2
        End Get
        Set(ByVal value As String)
            _LGemail2 = value
        End Set
    End Property
    Private _LGemail3 As String
    Public Property LGEmail3() As String
        Get
            Return _LGemail3
        End Get
        Set(ByVal value As String)
            _LGemail3 = value
        End Set
    End Property
    Private _LGemail4 As String
    Public Property LGEmail4() As String
        Get
            Return _LGemail4
        End Get
        Set(ByVal value As String)
            _LGemail4 = value
        End Set
    End Property

    Private _LGcontactno1 As String
    Public Property LGContactNumber1() As String
        Get
            Return _LGcontactno1
        End Get
        Set(ByVal value As String)
            _LGcontactno1 = value
        End Set
    End Property
    Private _LGcontactno2 As String
    Public Property LGContactNumber2() As String
        Get
            Return _LGcontactno2
        End Get
        Set(ByVal value As String)
            _LGcontactno2 = value
        End Set
    End Property
    Private _LGcontactno3 As String
    Public Property LGContactNumber3() As String
        Get
            Return _LGcontactno3
        End Get
        Set(ByVal value As String)
            _LGcontactno3 = value
        End Set
    End Property
    Private _LGcontactno4 As String
    Public Property LGContactNumber4() As String
        Get
            Return _LGcontactno4
        End Get
        Set(ByVal value As String)
            _LGcontactno4 = value
        End Set
    End Property
    Private _hosnameid As Integer
    Public Property HosNameID() As Integer
        Get
            Return _hosnameid
        End Get
        Set(ByVal value As Integer)
            _hosnameid = value
        End Set
    End Property
    Private _roomtypeid As Integer
    Public Property RoomTypeID() As Integer
        Get
            Return _roomtypeid
        End Get
        Set(ByVal value As Integer)
            _roomtypeid = value
        End Set
    End Property
    Private _hosregno As String
    Public Property HosRegNo() As String
        Get
            Return _hosregno
        End Get
        Set(ByVal value As String)
            _hosregno = value
        End Set
    End Property
End Class

