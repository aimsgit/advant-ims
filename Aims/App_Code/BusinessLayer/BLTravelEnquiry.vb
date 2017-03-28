Imports Microsoft.VisualBasic
Public Class BLTravelEnquiry
    Public Function AddTravelEnquiry(ByVal EL As ELTravelEnquiry) As Integer
        Return DLTravelEnquiry.AddTravelEnquiry(EL)
    End Function
    Public Function CheckDuplicate(ByVal EL As ELTravelEnquiry) As Data.DataTable
        Return DLTravelEnquiry.CheckDuplicate(EL)
    End Function
    Public Function ViewTravelEnquiry(ByVal EL As ELTravelEnquiry) As Data.DataTable
        Return DLTravelEnquiry.ViewTravelEnquiry(EL)
    End Function

    Public Function UpdateTravelEnquiry(ByVal EL As ELTravelEnquiry) As Integer
        Return DLTravelEnquiry.UpdateTravelEnquiry(EL)
    End Function
    Public Function DeleteTravelEnquiry(ByVal EL As ELTravelEnquiry) As Integer
        Return DLTravelEnquiry.DeleteTravelEnquiry(EL)
    End Function

End Class