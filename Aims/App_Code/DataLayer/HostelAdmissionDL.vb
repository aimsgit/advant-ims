Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class HostelAdmissionDL
    Shared Function UpdateRecord(ByVal f As HostelAdmissionE) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(19) {}

        If f.AdmissionDate1 = "12:00:00 AM" Then
            arParms(0) = New SqlParameter("@admissiondate", SqlDbType.DateTime)
            arParms(0).Value = DBNull.Value
        Else
            arParms(0) = New SqlParameter("@admissiondate", SqlDbType.DateTime)
            arParms(0).Value = f.AdmissionDate1
        End If
        
        If f.StudId1 <> 0 Then
            arParms(1) = New SqlParameter("@studId", SqlDbType.Int)
            arParms(1).Value = f.StudId1
        ElseIf f.StudId2 <> 0 Then
            arParms(1) = New SqlParameter("@studId", SqlDbType.Int)
            arParms(1).Value = f.StudId2
        ElseIf f.StudId3 <> 0 Then
            arParms(1) = New SqlParameter("@studId", SqlDbType.Int)
            arParms(1).Value = f.StudId3
        ElseIf f.StudId4 <> 0 Then
            arParms(1) = New SqlParameter("@studId", SqlDbType.Int)
            arParms(1).Value = f.StudId4
        End If


        arParms(2) = New SqlParameter("@A_Id", SqlDbType.Int)
        arParms(2).Value = f.AYear1


        arParms(3) = New SqlParameter("@C_Id", SqlDbType.Int)
        arParms(3).Value = f.CId1


        arParms(4) = New SqlParameter("@B_Id", SqlDbType.Int)
        arParms(4).Value = f.BId1


        If f.BloodGroup1 = Nothing Then
            arParms(5) = New SqlParameter("@Bloodgroup", SqlDbType.VarChar, 3)
            arParms(5).Value = System.DBNull.Value
        Else
            arParms(5) = New SqlParameter("@Bloodgroup", SqlDbType.VarChar, 3)
            arParms(5).Value = f.BloodGroup1
        End If


        If f.StudAdd1 = Nothing Then
            arParms(6) = New SqlParameter("@stdAdd", SqlDbType.VarChar, 250)
            arParms(6).Value = System.DBNull.Value
        Else
            arParms(6) = New SqlParameter("@stdAdd", SqlDbType.VarChar, 250)
            arParms(6).Value = f.StudAdd1
        End If


        If f.LGName1 = Nothing Then
            arParms(7) = New SqlParameter("@lgName", SqlDbType.VarChar, 50)
            arParms(7).Value = System.DBNull.Value
        Else
            arParms(7) = New SqlParameter("@lgName", SqlDbType.VarChar, 50)
            arParms(7).Value = f.LGName1
        End If


        If f.LGEmail1 = Nothing Then
            arParms(8) = New SqlParameter("@lgEmail", SqlDbType.VarChar, 50)
            arParms(8).Value = System.DBNull.Value
        Else
            arParms(8) = New SqlParameter("@lgEmail", SqlDbType.VarChar, 50)
            arParms(8).Value = f.LGEmail1
        End If



        If f.LGAddress1 = Nothing Then
            arParms(9) = New SqlParameter("@lgAddr", SqlDbType.VarChar, 250)
            arParms(9).Value = System.DBNull.Value
        Else
            arParms(9) = New SqlParameter("@lgAddr", SqlDbType.VarChar, 250)
            arParms(9).Value = f.LGAddress1
        End If

        If f.LGContactNumber1 = Nothing Then
            arParms(10) = New SqlParameter("@lgContNo", SqlDbType.VarChar, 50)
            arParms(10).Value = System.DBNull.Value
        Else
            arParms(10) = New SqlParameter("@lgContNo", SqlDbType.VarChar, 50)
            arParms(10).Value = f.LGContactNumber1
        End If



        arParms(11) = New SqlParameter("@hostel_Id", SqlDbType.Int)
        arParms(11).Value = f.Hid

        arParms(12) = New SqlParameter("@roomType_Id", SqlDbType.Int)
        arParms(12).Value = f.RoomTypeID


        arParms(13) = New SqlParameter("@hostel_RegNo", SqlDbType.VarChar, 50)
        arParms(13).Value = f.HosRegNo

        arParms(14) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("EmpCode")

        arParms(15) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("UserCode")

        arParms(16) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("BranchCode")

        arParms(17) = New SqlParameter("@temp", SqlDbType.Int)
        arParms(17).Value = f.Temp

        arParms(18) = New SqlParameter("@hostelBranchcode", SqlDbType.VarChar, 50)
        arParms(18).Value = f.HostelBranchcode

        arParms(19) = New SqlParameter("@roomNo", SqlDbType.VarChar, 50)
        arParms(19).Value = f.Room_No2


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Hostel_InsertAdmissionDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

        Return rowsAffected
    End Function
    Public Function GetHosNameCombo(ByVal BranchCode As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}

        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = BranchCode
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_GetHostelNameCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetHosNameCombo1(ByVal BranchCode As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}

        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = BranchCode
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_GetHostelNameCombo1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetRoomDetails(ByVal RId As Integer, ByVal HId As Integer) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(3) {}


        param(0) = New SqlParameter("@RID", SqlDbType.Int)
        param(0).Value = RId
        param(1) = New SqlParameter("@HID", SqlDbType.Int)
        param(1).Value = HId
        param(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Office")
        param(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        param(3).Value = HttpContext.Current.Session("BranchCode")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_SelectRoomDetails", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetRoomTypeCombo(ByVal Hid As Integer, ByVal Branchcode As String) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@HID", SqlDbType.Int)
        param(0).Value = Hid
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = Branchcode
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_GetRoomTypeCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function CheckDuplicate(ByVal f As HostelAdmissionE) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        If f.StudId1 <> 0 Then
            arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(1).Value = f.StudId1
        ElseIf f.StudId2 <> 0 Then
            arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(1).Value = f.StudId2
        ElseIf f.StudId3 <> 0 Then
            arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(1).Value = f.StudId3
        ElseIf f.StudId4 <> 0 Then
            arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
            arParms(1).Value = f.StudId4
        End If


        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = f.id



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_DuplicateAdmissionDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Select the seat number.")

        End Try
    End Function
    'Shared Function ViewRecord(ByVal El As HostelAdmissionE) As Data.DataTable
    '    Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim para() As SqlParameter = New SqlParameter(2) {}

    '    para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
    '    para(0).Value = HttpContext.Current.Session("BranchCode")

    '    para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    para(1).Value = HttpContext.Current.Session("Office")

    '    para(2) = New SqlParameter("@HostelId", SqlDbType.Int)
    '    para(2).Value = El.HosNameID


    '    Try
    '        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Hostel_ViewHostelAdmission", para)
    '        Return ds.Tables(0)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Function

    Shared Function DeleteRecord(ByVal id As Integer, ByVal Studid As Integer) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Hostel_ID", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@StudId", SqlDbType.Int)
        arParms(1).Value = Studid

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Hostel_DeleteHostelAdmissionDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function VacateRecord(ByVal id As Integer, ByVal Studid As Integer, ByVal DOL As Date) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Hostel_ID", SqlDbType.Int)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@StudId", SqlDbType.Int)
        arParms(1).Value = Studid

        arParms(2) = New SqlParameter("@DOL", SqlDbType.Date)
        arParms(2).Value = DOL

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Hostel_VacateAdmissionDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function GetRecords(ByVal RId As Integer, ByVal Id As Integer, ByVal HId As Integer) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}


        param(0) = New SqlParameter("@RID", SqlDbType.Int)
        param(0).Value = RId

        param(1) = New SqlParameter("@Id", SqlDbType.Int)
        param(1).Value = Id

        param(2) = New SqlParameter("@HID", SqlDbType.Int)
        param(2).Value = HId

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        param(4).Value = HttpContext.Current.Session("BranchCode")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_ViewAdmissionDetails", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function UpdateRecord1(ByVal f As HostelAdmissionE) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(18) {}


        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = f.id

        If f.AdmissionDate1 = "12:00:00 AM" Then
            arParms(1) = New SqlParameter("@admissiondate", SqlDbType.DateTime)
            arParms(1).Value = DBNull.Value
        Else
            arParms(1) = New SqlParameter("@admissiondate", SqlDbType.DateTime)
            arParms(1).Value = f.AdmissionDate1
        End If


        arParms(2) = New SqlParameter("@studId", SqlDbType.Int)
        arParms(2).Value = f.StudId1
       

        arParms(3) = New SqlParameter("@A_Id", SqlDbType.Int)
        arParms(3).Value = f.AYear1


        arParms(4) = New SqlParameter("@C_Id", SqlDbType.Int)
        arParms(4).Value = f.CId1


        arParms(5) = New SqlParameter("@B_Id", SqlDbType.Int)
        arParms(5).Value = f.BId1


        If f.BloodGroup1 = Nothing Then
            arParms(6) = New SqlParameter("@Bloodgroup", SqlDbType.VarChar, 3)
            arParms(6).Value = System.DBNull.Value
        Else
            arParms(6) = New SqlParameter("@Bloodgroup", SqlDbType.VarChar, 3)
            arParms(6).Value = f.BloodGroup1
        End If


        If f.StudAdd1 = Nothing Then
            arParms(7) = New SqlParameter("@stdAdd", SqlDbType.VarChar, 250)
            arParms(7).Value = System.DBNull.Value
        Else
            arParms(7) = New SqlParameter("@stdAdd", SqlDbType.VarChar, 250)
            arParms(7).Value = f.StudAdd1
        End If


        If f.LGName1 = Nothing Then
            arParms(8) = New SqlParameter("@lgName", SqlDbType.VarChar, 50)
            arParms(8).Value = System.DBNull.Value
        Else
            arParms(8) = New SqlParameter("@lgName", SqlDbType.VarChar, 50)
            arParms(8).Value = f.LGName1
        End If


        If f.LGEmail1 = Nothing Then
            arParms(9) = New SqlParameter("@lgEmail", SqlDbType.VarChar, 50)
            arParms(9).Value = System.DBNull.Value
        Else
            arParms(9) = New SqlParameter("@lgEmail", SqlDbType.VarChar, 50)
            arParms(9).Value = f.LGEmail1
        End If



        If f.LGAddress1 = Nothing Then
            arParms(10) = New SqlParameter("@lgAddr", SqlDbType.VarChar, 250)
            arParms(10).Value = System.DBNull.Value
        Else
            arParms(10) = New SqlParameter("@lgAddr", SqlDbType.VarChar, 250)
            arParms(10).Value = f.LGAddress1
        End If

        If f.LGContactNumber1 = Nothing Then
            arParms(11) = New SqlParameter("@lgContNo", SqlDbType.VarChar, 50)
            arParms(11).Value = System.DBNull.Value
        Else
            arParms(11) = New SqlParameter("@lgContNo", SqlDbType.VarChar, 50)
            arParms(11).Value = f.LGContactNumber1
        End If



        arParms(12) = New SqlParameter("@hostel_Id", SqlDbType.Int)
        arParms(12).Value = f.Hid

        arParms(13) = New SqlParameter("@roomType_Id", SqlDbType.Int)
        arParms(13).Value = f.RoomTypeID


        arParms(14) = New SqlParameter("@hostel_RegNo", SqlDbType.VarChar, 50)
        arParms(14).Value = f.HosRegNo

        arParms(15) = New SqlParameter("@empCode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("EmpCode")

        arParms(16) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("UserCode")

        arParms(17) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("BranchCode")


        arParms(18) = New SqlParameter("@Hostelbranch", SqlDbType.VarChar, 50)
        arParms(18).Value = f.HostelBranchcode

       
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateAdmissionDetail", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function CheckDuplicate1(ByVal f As HostelAdmissionE) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}


        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        'If f.StudId1 <> 0 Then
        '    arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
        '    arParms(1).Value = f.StudId1
        'ElseIf f.StudId2 <> 0 Then
        '    arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
        '    arParms(1).Value = f.StudId2
        'ElseIf f.StudId3 <> 0 Then
        '    arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
        '    arParms(1).Value = f.StudId1
        'ElseIf f.StudId4 <> 0 Then
        '    arParms(1) = New SqlParameter("@StdId", SqlDbType.Int)
        '    arParms(1).Value = f.StudId4
        'End If


        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = f.id

        arParms(2) = New SqlParameter("@HostelId", SqlDbType.Int)
        arParms(2).Value = f.Hostelid

        arParms(3) = New SqlParameter("@HostelRegNo", SqlDbType.VarChar, 100)
        arParms(3).Value = f.HosRegNo



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Hostel_DuplicateAdmissionRegNo", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetSelectBranch() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@AccessLevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_Proc_BranchAccessLevel", arParms)
        Return ds.Tables(0)
    End Function
End Class
