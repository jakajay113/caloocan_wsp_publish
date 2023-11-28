Public Class cLoader_Location

    Private Shared _mTrgLocation As String = Nothing
#Region "Variable Field"

    Private Shared _mBrgyCode As String
    Private Shared _mBrgyDesc As String
    Private Shared _mDistCode As String
    Private Shared _mDistDesc As String
    Private Shared _mLocIDNo As String
    Private Shared _mMuniCityCode As String
    Private Shared _mMuniCityDesc As String
    Private Shared _mProvCode As String
    Private Shared _mProvDesc As String
    Private Shared _mRegCode As String
    Private Shared _mRegDesc As String
    Private Shared _mStrtCode As String
    Private Shared _mStrtDesc As String
    Private Shared _mZipCode As String
    Private Shared _mIsSelected As Boolean
    Private Shared _mLocationConstruction As Boolean
#End Region

    Public Shared Property _pTrgLocation As String
        Get
            Return _mTrgLocation
        End Get
        Set(value As String)
            _mTrgLocation = value
        End Set
    End Property


#Region "Property Field"

    Public Shared Property _pBrgyCode() As String
        Get
            Return _mBrgyCode
        End Get
        Set(value As String)
            _mBrgyCode = value
        End Set
    End Property

    Public Shared Property _pBrgyDesc() As String
        Get
            Return _mBrgyDesc
        End Get
        Set(value As String)
            _mBrgyDesc = value
        End Set
    End Property

    Public Shared Property _pDistCode() As String
        Get
            Return _mDistCode
        End Get
        Set(value As String)
            _mDistCode = value
        End Set
    End Property

    Public Shared Property _pDistDesc() As String
        Get
            Return _mDistDesc
        End Get
        Set(value As String)
            _mDistDesc = value
        End Set
    End Property

    Public Shared Property _pLocIDNo() As String
        Get
            Return _mLocIDNo
        End Get
        Set(value As String)
            _mLocIDNo = value
        End Set
    End Property

    Public Shared Property _pMuniCityCode() As String
        Get
            Return _mMuniCityCode
        End Get
        Set(value As String)
            _mMuniCityCode = value
        End Set
    End Property

    Public Shared Property _pMuniCityDesc() As String
        Get
            Return _mMuniCityDesc
        End Get
        Set(value As String)
            _mMuniCityDesc = value
        End Set
    End Property

    Public Shared Property _pProvCode() As String
        Get
            Return _mProvCode
        End Get
        Set(value As String)
            _mProvCode = value
        End Set
    End Property

    Public Shared Property _pProvDesc() As String
        Get
            Return _mProvDesc
        End Get
        Set(value As String)
            _mProvDesc = value
        End Set
    End Property

    Public Shared Property _pRegCode() As String
        Get
            Return _mRegCode
        End Get
        Set(value As String)
            _mRegCode = value
        End Set
    End Property

    Public Shared Property _pRegDesc() As String
        Get
            Return _mRegDesc
        End Get
        Set(value As String)
            _mRegDesc = value
        End Set
    End Property

    Public Shared Property _pStrtCode() As String
        Get
            Return _mStrtCode
        End Get
        Set(value As String)
            _mStrtCode = value
        End Set
    End Property

    Public Shared Property _pStrtDesc() As String
        Get
            Return _mStrtDesc
        End Get
        Set(value As String)
            _mStrtDesc = value
        End Set
    End Property

    Public Shared Property _pZipCode() As String
        Get
            Return _mZipCode
        End Get
        Set(value As String)
            _mZipCode = value
        End Set
    End Property

    Public Shared Property _pIsSelected() As Boolean
        Get
            Return _mIsSelected
        End Get
        Set(value As Boolean)
            _mIsSelected = value
        End Set
    End Property

    Public Shared Property _pLocationConstruction() As Boolean
        Get
            Return _mLocationConstruction
        End Get
        Set(value As Boolean)
            _mLocationConstruction = value
        End Set
    End Property
#End Region
End Class
