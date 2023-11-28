
Namespace gc_Notify
    Public Class Head
        Public Property [function] As String
        Public Property clientId As String
        Public Property version As String
        Public Property reqTime As DateTime
        Public Property reqMsgId As String
    End Class

    Public Class OrderAmount
        Public Property currency As String
        Public Property value As String
    End Class

    Public Class Body
        Public Property acquirementId As String
        Public Property orderAmount As OrderAmount
        Public Property merchantId As String
        Public Property merchantTransId As String
        Public Property finishedTime As DateTime
        Public Property createdTime As DateTime
        Public Property acquirementStatus As String
        Public Property extendInfo As String
        Public Property transactionId As String
    End Class

    Public Class Request
        Public Property head As Head
        Public Property body As Body
    End Class

    Public Class RootObject
        Public Property request As Request
        Public Property signature As String
    End Class



End Namespace

Namespace gc_Response
    Public Class Head
        Public Property version As String
        Public Property [function] As String
        Public Property clientId As String
        Public Property reqMsgId As String
        Public Property respTime As DateTime
    End Class

    Public Class ResultInfo
        Public Property resultStatus As String
        Public Property resultCodeId As String
        Public Property resultCode As String
        Public Property resultMsg As String
    End Class

    Public Class Body
        Public Property resultInfo As ResultInfo
    End Class

    Public Class Response
        Public Property head As Head
        Public Property body As Body
    End Class

    Public Class RootObject
        Public Property response As Response
        Public Property signature As String
    End Class

End Namespace

