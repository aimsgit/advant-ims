Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLTravelEnquiry
    Shared Function AddTravelEnquiry(ByVal EL As ELTravelEnquiry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(25) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@TripType", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.Triptype


        arParms(2) = New SqlParameter("@Enquiry_Date", SqlDbType.DateTime)
        arParms(2).Value = EL.Enquiry_Date

        arParms(3) = New SqlParameter("@Enquiry_No", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.Enquiry_No

        arParms(4) = New SqlParameter("@Passenger_Name", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.Passenger_Name

        arParms(5) = New SqlParameter("@Referral", SqlDbType.VarChar, 50)
        arParms(5).Value = EL.Referral

        arParms(6) = New SqlParameter("@No_Of_Adults", SqlDbType.Int)
        arParms(6).Value = EL.No_Of_Adults

        arParms(7) = New SqlParameter("@No_Of_children", SqlDbType.Int)
        arParms(7).Value = EL.No_Of_Children

        arParms(8) = New SqlParameter("@Infants", SqlDbType.Int)
        arParms(8).Value = EL.No_Of_Infants


        arParms(9) = New SqlParameter("@Leaving_From", SqlDbType.VarChar, 50)
        arParms(9).Value = EL.Leavingfrom

        arParms(10) = New SqlParameter("@departure_Date", SqlDbType.DateTime)
        arParms(10).Value = EL.Departure_Date

        arParms(11) = New SqlParameter("@GoingTo", SqlDbType.VarChar, 50)
        arParms(11).Value = EL.Goingto

        If EL.Return_Date = "1/1/3000" Then
            arParms(12) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            arParms(12).Value = DBNull.Value
        Else
            arParms(12) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            arParms(12).Value = EL.Return_Date

        End If
        arParms(13) = New SqlParameter("@Purpose", SqlDbType.VarChar, 100)
        arParms(13).Value = EL.Purpose

        arParms(14) = New SqlParameter("@TravelClass", SqlDbType.VarChar, 50)
        arParms(14).Value = EL.Travelclass

        arParms(15) = New SqlParameter("@Accomodation_Type", SqlDbType.VarChar, 50)
        arParms(15).Value = EL.Accomodation_Type

        arParms(16) = New SqlParameter("@Contact_Number", SqlDbType.VarChar, 50)
        arParms(16).Value = EL.Contact_Number

        arParms(17) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        arParms(17).Value = EL.Address

        arParms(18) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(18).Value = EL.Email

        arParms(19) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(19).Value = EL.Remarks

        arParms(20) = New SqlParameter("@quote", SqlDbType.VarChar, 2)
        arParms(20).Value = EL.Quote

        arParms(21) = New SqlParameter("@Follow_Up", SqlDbType.VarChar, 2)
        arParms(21).Value = EL.Follow_Up

        arParms(22) = New SqlParameter("@Closed", SqlDbType.VarChar, 2)
        arParms(22).Value = EL.Closed

        arParms(23) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(23).Value = HttpContext.Current.Session("EmpCode")

        arParms(24) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(24).Value = HttpContext.Current.Session("UserCode")

        arParms(25) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(25).Value = HttpContext.Current.Session("Office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertTravelEnquiry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateTravelEnquiry(ByVal EL As ELTravelEnquiry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(25) {}

        arParms(0) = New SqlParameter("@TripType", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Triptype

        arParms(1) = New SqlParameter("@Enquiry_Date", SqlDbType.DateTime)
        arParms(1).Value = EL.Enquiry_Date

        arParms(2) = New SqlParameter("@Enquiry_No", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.Enquiry_No

        arParms(3) = New SqlParameter("@Passenger_Name", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.Passenger_Name

        arParms(4) = New SqlParameter("@Referral", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.Referral

        arParms(5) = New SqlParameter("@No_Of_Adults", SqlDbType.Int)
        arParms(5).Value = EL.No_Of_Adults

        arParms(6) = New SqlParameter("@No_Of_children", SqlDbType.Int)
        arParms(6).Value = EL.No_Of_Children


        arParms(7) = New SqlParameter("@Infants", SqlDbType.Int)
        arParms(7).Value = EL.No_Of_Infants

        arParms(8) = New SqlParameter("@Leaving_From", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.Leavingfrom

        If EL.Departure_Date = "1/1/3000" Then
            arParms(9) = New SqlParameter("@departure_Date", SqlDbType.DateTime)
            arParms(9).Value = System.DBNull.Value
        Else
            arParms(9) = New SqlParameter("@departure_Date", SqlDbType.DateTime)
            arParms(9).Value = EL.Departure_Date
        End If

        arParms(10) = New SqlParameter("@GoingTo", SqlDbType.VarChar, 50)
        arParms(10).Value = EL.Goingto

        If EL.Return_Date = "1/1/3000" Then
            arParms(11) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            arParms(11).Value = System.DBNull.Value
        Else
            arParms(11) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            arParms(11).Value = EL.Return_Date
        End If
        arParms(12) = New SqlParameter("@TravelClass", SqlDbType.VarChar, 50)
        arParms(12).Value = EL.Travelclass

        arParms(13) = New SqlParameter("@Purpose", SqlDbType.VarChar, 100)
        arParms(13).Value = EL.Purpose

        arParms(14) = New SqlParameter("@Accomodation_Type", SqlDbType.VarChar, 50)
        arParms(14).Value = EL.Accomodation_Type

        arParms(15) = New SqlParameter("@Contact_Number", SqlDbType.VarChar, 50)
        arParms(15).Value = EL.Contact_Number

        arParms(16) = New SqlParameter("@Address", SqlDbType.VarChar, 250)
        arParms(16).Value = EL.Address

        arParms(17) = New SqlParameter("@Email", SqlDbType.VarChar, 50)
        arParms(17).Value = EL.Email

        arParms(18) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(18).Value = EL.Remarks

        arParms(19) = New SqlParameter("@quote", SqlDbType.VarChar, 2)
        arParms(19).Value = EL.Quote

        arParms(20) = New SqlParameter("@Follow_Up", SqlDbType.VarChar, 2)
        arParms(20).Value = EL.Follow_Up

        arParms(21) = New SqlParameter("@Closed", SqlDbType.VarChar, 2)
        arParms(21).Value = EL.Closed

        arParms(22) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(22).Value = HttpContext.Current.Session("BranchCode")

        arParms(23) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(23).Value = HttpContext.Current.Session("EmpCode")

        arParms(24) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(24).Value = HttpContext.Current.Session("UserCode")

        arParms(25) = New SqlParameter("@id", SqlDbType.Int)
        arParms(25).Value = EL.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateTravelEnquiry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DeleteTravelEnquiry(ByVal EL As ELTravelEnquiry) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteTravelEnquiry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ViewTravelEnquiry(ByVal EL As ELTravelEnquiry) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(1).Value = EL.Id

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@Enquiry_Date", SqlDbType.DateTime)
        arParms(3).Value = EL.Enquiry_Date

        arParms(4) = New SqlParameter("@Enquiry_No", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.Enquiry_No

        arParms(5) = New SqlParameter("@Passenger_Name", SqlDbType.VarChar, 50)
        arParms(5).Value = EL.Passenger_Name

        arParms(6) = New SqlParameter("@bordingPoint", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.Leavingfrom


        arParms(7) = New SqlParameter("@Destination", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Goingto

        arParms(8) = New SqlParameter("@contact_NO", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.Contact_Number

        arParms(9) = New SqlParameter("@email", SqlDbType.VarChar, 50)
        arParms(9).Value = EL.Email


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetTravelEnquiry", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Shared Function CheckDuplicate(ByVal EL As ELTravelEnquiry) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(1).Value = EL.Id


        arParms(2) = New SqlParameter("@Enquiry_No", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.Enquiry_No
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_DuplicateTravelEnquiry", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function PrintTravelEnquiry(ByVal Ref_ID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Ref_ID", SqlDbType.Int)
        arParms(1).Value = Ref_ID


        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_TravelEnquiry", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

End Class