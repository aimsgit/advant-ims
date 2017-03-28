Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class QualificationDB
    Shared Function GetQualification(ByVal sid As Integer, ByVal id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@stdid", SqlDbType.Int)
        arParms(0).Value = sid
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = id
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetQualicDetails]", arParms)

        Return ds.Tables(0)


    End Function
    Shared Function GetDuplicateQualification(ByVal q As Qualification) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        para(1).Value = q.Std_code
        para(2) = New SqlParameter("@Examination", SqlDbType.NVarChar, 50)
        para(2).Value = q.Name
        para(3) = New SqlParameter("@Board", SqlDbType.NVarChar, 100)
        para(3).Value = q.Board_Univ
        para(4) = New SqlParameter("@Year", SqlDbType.Int)
        para(4).Value = q.YearofPassing
        para(5) = New SqlParameter("@Marks", SqlDbType.Float)
        para(5).Value = q.Marks
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateQualificationDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    ''Shared Function GetDuplicateExperience(ByVal e As Experience) As Data.DataTable
    ''    Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    ''    Dim ds As New DataSet
    ''    Dim para() As SqlParameter = New SqlParameter(4) {}
    ''    para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    ''    para(0).Value = HttpContext.Current.Session("BranchCode")
    ''    para(1) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
    ''    para(1).Value = e.Std_code
    ''    para(2) = New SqlParameter("@OrgName", SqlDbType.VarChar, 50)
    ''    para(2).Value = e.Name
    ''    para(3) = New SqlParameter("@Job", SqlDbType.VarChar, 100)
    ''    para(3).Value = e.Natureofjob
    ''    para(4) = New SqlParameter("@NoOfYears", SqlDbType.Int)
    ''    para(4).Value = e.NoOfYears

    ''    Try
    ''        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateExperienceDetails", para)
    ''    Catch ex As Exception
    ''        MsgBox(ex.ToString)
    ''    End Try
    ''    Return ds.Tables(0)
    ''End Function
    ''Shared Function GetDuplicateCertificate(ByVal c As CertificateReceived) As Data.DataTable
    ''    Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    ''    Dim ds As New DataSet
    ''    Dim para() As SqlParameter = New SqlParameter(2) {}
    ''    para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    ''    para(0).Value = HttpContext.Current.Session("BranchCode")
    ''    para(1) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
    ''    para(1).Value = c.Std_code
    ''    para(2) = New SqlParameter("@CertificateName", SqlDbType.VarChar, 50)
    ''    para(2).Value = c.Name

    ''    Try
    ''        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateCertificateDetails", para)
    ''    Catch ex As Exception
    ''        MsgBox(ex.ToString)
    ''    End Try
    ''    Return ds.Tables(0)
    ''End Function
    Shared Function Insert(ByVal q As Qualification) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
      
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(19) {}

        arParms(0) = New SqlParameter("@qualification_ID", SqlDbType.Int)
        arParms(0).Value = q.Qualification_ID

        arParms(1) = New SqlParameter("@code", SqlDbType.NVarChar, q.Std_code.Length)
        arParms(1).Value = q.Std_code

        arParms(2) = New SqlParameter("@name", SqlDbType.NVarChar, q.Name.Length)
        arParms(2).Value = q.Name

        arParms(3) = New SqlParameter("@BOU", SqlDbType.NVarChar, q.Board_Univ.Length)
        arParms(3).Value = q.Board_Univ

        arParms(4) = New SqlParameter("@marks", SqlDbType.Float)
        arParms(4).Value = q.Marks

        arParms(5) = New SqlParameter("@YOP", SqlDbType.Int)
        arParms(5).Value = q.YearofPassing

        arParms(6) = New SqlParameter("@subcertificate", SqlDbType.NVarChar, q.Subcertificate.Length)
        arParms(6).Value = q.Subcertificate
        If q.TotalMarks = 0 Then
            arParms(7) = New SqlParameter("@TotMarks", SqlDbType.Float)
            arParms(7).Value = System.DBNull.Value
        Else
            arParms(7) = New SqlParameter("@TotMarks", SqlDbType.Float)
            arParms(7).Value = q.TotalMarks
        End If
        arParms(8) = New SqlParameter("@Subject1", SqlDbType.VarChar, 100)
        arParms(8).Value = q.Subject1

        arParms(9) = New SqlParameter("@Subject2", SqlDbType.VarChar, 100)
        arParms(9).Value = q.Subject2

        arParms(10) = New SqlParameter("@Subject3", SqlDbType.VarChar, 100)
        arParms(10).Value = q.Subject3


        arParms(11) = New SqlParameter("@Rank", SqlDbType.VarChar, 50)
        arParms(11).Value = q.Rank

        arParms(12) = New SqlParameter("@Medium", SqlDbType.VarChar, 50)
        arParms(12).Value = q.Medium

        arParms(13) = New SqlParameter("@AdminDistrict", SqlDbType.VarChar, 250)
        arParms(13).Value = q.AdminDistrict

        arParms(14) = New SqlParameter("@Zindex", SqlDbType.VarChar, 50)
        arParms(14).Value = q.Zindex

        arParms(15) = New SqlParameter("@UserCode", SqlDbType.Char, 50)
        arParms(15).Value = HttpContext.Current.Session("UserCode")

        arParms(16) = New SqlParameter("@EmpCode", SqlDbType.Char, 50)
        arParms(16).Value = HttpContext.Current.Session("EmpCode")

        arParms(17) = New SqlParameter("@BranchCode", SqlDbType.Char, 50)
        arParms(17).Value = HttpContext.Current.Session("BranchCode")
        arParms(18) = New SqlParameter("@Stream", SqlDbType.VarChar, 50)
        arParms(18).Value = q.Stream

        arParms(19) = New SqlParameter("@Attempt", SqlDbType.Int)
        arParms(19).Value = q.Attempt



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveQualificDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected

    End Function
   
    Shared Function ChangeFlag(ByVal Qualification_ID As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@qualification_ID", SqlDbType.Int, 10)
        arParms(0).Value = Qualification_ID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.Char, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DelQualicDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    'CERTIFICATE RECEIVED FUNCTIONS
    Shared Function Save(ByVal c As CertificateReceived) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@qualification_ID", SqlDbType.Int)
        arParms(0).Value = c.Qualification_ID

        arParms(1) = New SqlParameter("@code", SqlDbType.Int)
        arParms(1).Value = c.Std_code

        arParms(2) = New SqlParameter("@name", SqlDbType.NVarChar, c.Name.Length)
        arParms(2).Value = c.Name

        arParms(3) = New SqlParameter("@remarks", SqlDbType.NVarChar, c.Remarks.Length)
        arParms(3).Value = c.Remarks

        arParms(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveCertiRecvDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetCertificate(ByVal scode As Integer, ByVal id As Integer) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@std_code", SqlDbType.Int)
        arParms(0).Value = scode
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = id
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetCertiDetails]", arParms)

        Return ds.Tables(0)
    End Function
    Shared Function DeleteCertificate(ByVal Qualification_ID As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@qualification_ID", SqlDbType.Int)
        arParms(0).Value = Qualification_ID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DelCertiDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    'CERTIFICATE ISSUED FUNCTIONS ( FOR LATERAL ENTRY)
    Shared Function SaveCertiIssued(ByVal ci As CertificateIssuedLateral) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@qualification_ID", SqlDbType.Int)
        arParms(0).Value = ci.Qualification_ID

        arParms(1) = New SqlParameter("@code", SqlDbType.NVarChar, ci.Std_code.Length)
        arParms(1).Value = ci.Std_code

        arParms(2) = New SqlParameter("@name", SqlDbType.NVarChar, ci.Name.Length)
        arParms(2).Value = ci.Name

        arParms(3) = New SqlParameter("@BOU", SqlDbType.NVarChar, ci.Board_Univ.Length)
        arParms(3).Value = ci.Board_Univ

        arParms(4) = New SqlParameter("@marks", SqlDbType.Float)
        arParms(4).Value = ci.Marks

        arParms(5) = New SqlParameter("@YOP", SqlDbType.Int)
        arParms(5).Value = ci.YearofPassing

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveCertiIssuedLateral", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetYear(ByVal date1 As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@Date1", SqlDbType.VarChar, 20)
        arParms(0).Value = date1
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CurrentYear]", arParms)

        Return ds.Tables(0)
    End Function

    
End Class
