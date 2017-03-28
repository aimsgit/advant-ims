Imports Microsoft.VisualBasic

Public Class FeedBackFormBL
    Public Function InsertFeedBack(ByVal FDBack As FeedBackForm) As Integer
        Return FeedBackFormDL.InsertFeedBack(FDBack)
    End Function
    Public Function GetFeedBackGV(ByVal FDBack As FeedBackForm) As Data.DataTable
        Return FeedBackFormDL.GetFeedBackGV(FDBack)
    End Function
    Public Function FeedBackParamsGridView(ByVal FDBack As FeedBackForm) As Data.DataTable
        Return FeedBackFormDL.FeedBackParamsGridView(FDBack)
    End Function
    Public Function FeedbackMaxMin(ByVal FDBack As FeedBackForm) As Data.DataTable
        Return FeedBackFormDL.FeedbackMaxMin(FDBack)
    End Function
End Class
