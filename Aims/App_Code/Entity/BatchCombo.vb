Imports Microsoft.VisualBasic

Public Class BatchCombo
    Private _BatchNo As String
    Public Property BatchNo() As String
        Get
            Return _BatchNo
        End Get
        Set(ByVal value As String)
            _BatchNo = value
        End Set
    End Property


    Private _DelFlag As Int16
    Public Property DeleteFlag() As Int16
        Get
            Return _DelFlag
        End Get
        Set(ByVal value As Int16)
            _DelFlag = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal BatchNo As String)

        _BatchNo = BatchNo

    End Sub
End Class
