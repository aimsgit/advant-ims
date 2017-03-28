Imports Microsoft.VisualBasic

Public Class DepreiciationRate
    Private _Depreciation_ID As Integer
    Public Property Depreciation_ID() As Integer
        Get
            Return _Depreciation_ID
        End Get
        Set(ByVal value As Integer)
            _Depreciation_ID = value
        End Set
    End Property
    Private _CommodityName As String
    Public Property CommodityName() As String
        Get
            Return _CommodityName
        End Get
        Set(ByVal value As String)
            _CommodityName = value
        End Set
    End Property
    Private _CommodityRate As Double
    Public Property CommodityRate() As Double
        Get
            Return _CommodityRate
        End Get
        Set(ByVal value As Double)
            _CommodityRate = value
        End Set
    End Property
    Private _Comodity_CompanyRates As Double
    Public Property Comodity_CompanyRates() As Double
        Get
            Return _Comodity_CompanyRates
        End Get
        Set(ByVal value As Double)
            _Comodity_CompanyRates = value
        End Set
    End Property
End Class
