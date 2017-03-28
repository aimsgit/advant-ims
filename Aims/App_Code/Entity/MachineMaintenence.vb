Imports Microsoft.VisualBasic

Public Class MachineMaintenence
    Private _maintainid As Long
    Public Property MaintainId() As Long
        Get
            Return _maintainid
        End Get
        Set(ByVal value As Long)
            _maintainid = value
        End Set
    End Property
    Private _entrydate As Date
    Public Property EntryDate() As Date
        Get
            Return _entrydate
        End Get
        Set(ByVal value As Date)
            _entrydate = value
        End Set
    End Property
    Private _machinemake As Integer
    Public Property MachineMake() As Integer
        Get
            Return _machinemake
        End Get
        Set(ByVal value As Integer)
            _machinemake = value
        End Set
    End Property
    Private _machinemodel As String
    Public Property MachineModel() As String
        Get
            Return _machinemodel
        End Get
        Set(ByVal value As String)
            _machinemodel = value
        End Set
    End Property
    Private _machineno As String
    Public Property MachineNo() As String
        Get
            Return _machineno
        End Get
        Set(ByVal value As String)
            _machineno = value
        End Set
    End Property
    Private _machinetype As Integer
    Public Property MachineType() As Integer
        Get
            Return _machinetype
        End Get
        Set(ByVal value As Integer)
            _machinetype = value
        End Set
    End Property
    Private _Maintenencetype As Integer
    Public Property MaintenenceType() As Integer
        Get
            Return _Maintenencetype
        End Get
        Set(ByVal value As Integer)
            _Maintenencetype = value
        End Set
    End Property
    Private _cleaneddate As Date
    Public Property CleanedDate() As Date
        Get
            Return _cleaneddate
        End Get
        Set(ByVal value As Date)
            _cleaneddate = value
        End Set
    End Property
    Private _duedate As Date
    Public Property DueDate() As Date
        Get
            Return _duedate
        End Get
        Set(ByVal value As Date)
            _duedate = value
        End Set
    End Property
    Private _timestopped As String
    Public Property TimeStopped() As String
        Get
            Return _timestopped
        End Get
        Set(ByVal value As String)
            _timestopped = value
        End Set
    End Property
    Private _partchanged As String
    Public Property PartChanged() As String
        Get
            Return _partchanged
        End Get
        Set(ByVal value As String)
            _partchanged = value
        End Set
    End Property
    Private _timerun As String
    Public Property TimeRun() As String
        Get
            Return _timerun
        End Get
        Set(ByVal value As String)
            _timerun = value
        End Set
    End Property
    Private _operation As String
    Public Property Operation() As String
        Get
            Return _operation
        End Get
        Set(ByVal value As String)
            _operation = value
        End Set
    End Property
    Private _operationname As String
    Public Property OperationName() As String
        Get
            Return _operationname
        End Get
        Set(ByVal value As String)
            _operationname = value
        End Set
    End Property
    Private _needle As String
    Public Property Needle() As String
        Get
            Return _needle
        End Get
        Set(ByVal value As String)
            _needle = value
        End Set
    End Property
    Private _parts As String
    Public Property Parts() As String
        Get
            Return _parts
        End Get
        Set(ByVal value As String)
            _parts = value
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
    Private _batchno As String
    Public Property BatchNo() As String
        Get
            Return _batchno
        End Get
        Set(ByVal value As String)
            _batchno = value
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
    Private _instituteid As Integer
    Public Property InstituteId() As Integer
        Get
            Return _instituteid
        End Get
        Set(ByVal value As Integer)
            _instituteid = value
        End Set
    End Property
    Private _branchid As Integer
    Public Property BranchId() As Integer
        Get
            Return _branchid
        End Get
        Set(ByVal value As Integer)
            _branchid = value
        End Set
    End Property
    Private _deleteflag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _deleteflag
        End Get
        Set(ByVal value As Int16)
            _deleteflag = value
        End Set
    End Property
    Public Sub New(ByVal maintainid As Long, ByVal entrydate As Date, ByVal machinemake As Integer, ByVal machinemodel As String, ByVal machineno As String, ByVal machinetype As Integer, ByVal maintenencetype As Integer, ByVal cleaneddate As Date, ByVal duedate As Date, ByVal timestopped As String, ByVal partchanged As String, ByVal timerun As String, ByVal operation As String, ByVal operationname As String, ByVal needle As String, ByVal parts As String, ByVal courseid As Integer, ByVal batchno As String, ByVal remarks As String, ByVal instituteid As Integer, ByVal branchid As Integer)
        _maintainid = maintainid
        _entrydate = entrydate
        _machinemake = machinemake
        _machinemodel = machinemodel
        _machineno = machineno
        _machinetype = machinetype
        _Maintenencetype = maintenencetype
        _cleaneddate = cleaneddate
        _duedate = duedate
        _timestopped = timestopped
        _partchanged = partchanged
        _timerun = timerun
        _operation = operation
        _operationname = operationname
        _needle = needle
        _parts = parts
        _courseid = courseid
        _batchno = batchno
        _remarks = remarks
        _instituteid = instituteid
        _branchid = branchid
    End Sub

    Public Sub New()

    End Sub
End Class
