Public Class cLoader_DivisionSetup
#Region "Variable Field"

    Private Shared _mCode As String
    Private Shared _mDesc1 As String
    Private Shared _mDesc2 As String

#End Region

#Region "Property Field"

    Public Shared Property _pCode() As String
        Get
            Return _mCode
        End Get
        Set(value As String)
            _mCode = value
        End Set
    End Property

    Public Shared Property _pDesc1() As String
        Get
            Return _mDesc1
        End Get
        Set(value As String)
            _mDesc1 = value
        End Set
    End Property

    Public Shared Property _pDesc2() As String
        Get
            Return _mDesc2
        End Get
        Set(value As String)
            _mDesc2 = value
        End Set
    End Property

#End Region
End Class
