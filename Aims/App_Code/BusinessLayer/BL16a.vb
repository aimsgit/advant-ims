Imports Microsoft.VisualBasic
Public Class BL16a
    Dim DAL As New DA16a
    Dim prop As New E16a

    Public Function GetDataByEmp(ByVal id As Int32, ByVal duration As String) As Data.DataTable
        Return DAL.showgrid(id, duration)
    End Function
    Public Function GetDataByEmp1(ByVal id As Int32, ByVal duration As String, ByVal insID As Int64, ByVal brnID As Int64) As Data.DataTable
        Return DAL.showgrid(id, duration, insID, brnID)
    End Function
    Public Function GetEmp() As Data.DataTable
        Return DAL.GetEmployee()
    End Function
    Public Sub delete(ByVal FormID As Int64)
        'DAL.delete(FormID)
    End Sub
    Public Function showgrid() As Data.DataTable
        Return DAL.showgrid()
    End Function
    Public Function Update16a(ByVal id As Int32, ByVal EmpID As Int32, ByVal FormID As Int32, ByVal NatureOfPayment As String, ByVal Duration As String, ByVal TaxableAmt As Int32, ByVal DeductionDate As DateTime, ByVal TDS As Double, ByVal Surcharges As Double, ByVal EducationCess As Double, ByVal TaxAmt As Double, ByVal PaymentDtls As String, ByVal BSRCode As String, ByVal PaymentDate As DateTime, ByVal PayIdentificationNo As Int32, ByVal period As String) As Int64
        Return DAL.Update16a(id, EmpID, FormID, NatureOfPayment, Duration, TaxableAmt, DeductionDate, TDS, Surcharges, EducationCess, TaxAmt, PaymentDtls, BSRCode, PaymentDate, PayIdentificationNo, period)
        '     <asp:Parameter Name="EmpID" Type="Int32" />
        '        <asp:Parameter Name="FormID" Type="Int32" />
        '        <asp:Parameter Name="NatureOfPayment" Type="String" />
        '        <asp:Parameter Name="Duration" Type="String" />
        '        <asp:Parameter Name="TaxableAmt" Type="Int32" />
        '        <asp:Parameter Name="DeductionDate" Type="DateTime" />
        '        <asp:Parameter Name="TDS" Type="Double" />
        '        <asp:Parameter Name="Surcharges" Type="Double" />
        '        <asp:Parameter Name="EducationCess" Type="Double" />
        '        <asp:Parameter Name="TaxAmt" Type="Double" />
        '        <asp:Parameter Name="PaymentDtls" Type="String" />
        '        <asp:Parameter Name="BSRCode" Type="String" />
        '        <asp:Parameter Name="PaymentDate" Type="DateTime" />
        '        <asp:Parameter Name="PayIdentificationNo" Type="Int32" />
    End Function
    Public Function Del16a(ByVal ID As Int32) As Int16
        Return DAL.Del16A(ID)
    End Function
End Class
