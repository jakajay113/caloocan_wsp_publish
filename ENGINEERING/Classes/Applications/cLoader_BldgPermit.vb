Public Class cLoader_BldgPermit
    Private Shared _mEMS_AcctNo As String = Nothing
    Private Shared _mEMS_SubAcctNo As String = Nothing
    Private Shared _mPermitType As String = Nothing
    Private Shared _mIDCode As String = Nothing
    Private Shared _mPropOwnerIDCode As String = Nothing
    Private Shared _mProfessionalIDCode As String = Nothing
    Private Shared _mAppNo As String = Nothing
    Private Shared _mApplicantType As String = Nothing
    Private Shared _mDateEncoded As Date
    Private Shared _mIsLoaded As Boolean

    Private Shared _mStrtCode As String = Nothing
    Private Shared _mStrtDesc As String = Nothing
    Private Shared _mBrgyCode As String = Nothing
    Private Shared _mBrgyDesc As String = Nothing
    Private Shared _mMuniCityCode As String = Nothing
    Private Shared _mMuniCityDesc As String = Nothing
    Private Shared _mProvCode As String = Nothing
    Private Shared _mProvDesc As String = Nothing
    Private Shared _mRegionCode As String = Nothing
    Private Shared _mRegionDesc As String = Nothing

    Private Shared _mGetSelectedApplTypeIndex As Integer ''Added 20200717 MCE
    Private Shared _mModified As String ''Added 20200717 MCE
    'FOR RPTAS
#Region "Variable Field"

    Private Shared _mRPTAS_BARANGAY As String
    Private Shared _mRPTAS_BCODE As String
    Private Shared _mRPTAS_BLOCK_NO As String
    Private Shared _mRPTAS_CAD_LOT_NO As String
    Private Shared _mRPTAS_CITY As String
    Private Shared _mRPTAS_CITYCODE As String
    Private Shared _mRPTAS_DIST_NO As String
    Private Shared _mRPTAS_DISTRICT As String
    Private Shared _mRPTAS_EAST As String
    Private Shared _mRPTAS_IMP_NO As String
    Private Shared _mRPTAS_kind As String
    Private Shared _mRPTAS_LOCATION As String
    Private Shared _mRPTAS_LOTE_NO As String
    Private Shared _mRPTAS_NORTH As String
    Private Shared _mRPTAS_OWNER_NO As String
    Private Shared _mRPTAS_OWNERNAME As String
    Private Shared _mRPTAS_PARCEL_NO As String
    Private Shared _mRPTAS_PIN As String
    Private Shared _mRPTAS_PROVCODE As String
    Private Shared _mRPTAS_PROVINCE As String
    Private Shared _mRPTAS_REGION As String
    Private Shared _mRPTAS_SEC_NO As String
    Private Shared _mRPTAS_SOUTH As String
    Private Shared _mRPTAS_STREET As String
    Private Shared _mRPTAS_STREETCODE As String
    Private Shared _mRPTAS_SURVEYNO As String
    Private Shared _mRPTAS_TCT_DATE As String
    Private Shared _mRPTAS_TCTNO As String
    Private Shared _mRPTAS_TDN As String
    Private Shared _mRPTAS_WEST As String

    Private Shared _mApp_BrgyCode As String
    Private Shared _mApp_MuniCityCode As String
    Private Shared _mApp_ProvCode As String

#End Region

    Public Shared Property _pModified As String
        Get
            Return _mModified
        End Get
        Set(value As String)
            _mModified = value
        End Set
    End Property


    Public Shared Property _pEMS_AcctNo As String
        Get
            Return _mEMS_AcctNo
        End Get
        Set(value As String)
            _mEMS_AcctNo = value
        End Set
    End Property



    Public Shared Property _pGetSelectedApplTypeIndex As Integer
        Get
            Return _mGetSelectedApplTypeIndex
        End Get
        Set(value As Integer)
            _mGetSelectedApplTypeIndex = value
        End Set
    End Property

    Public Shared Property _pEMS_SubAcctNo As String
        Get
            Return _mEMS_SubAcctNo
        End Get
        Set(value As String)
            _mEMS_SubAcctNo = value
        End Set
    End Property

    Public Shared Property _pPermitType() As String
        Get
            Return _mPermitType
        End Get
        Set(value As String)
            _mPermitType = value
        End Set
    End Property

    Public Shared Property _pIDCode() As String
        Get
            Return _mIDCode
        End Get
        Set(value As String)
            _mIDCode = value
        End Set
    End Property

    Public Shared Property _pProfessionalIDCode() As String
        Get
            Return _mProfessionalIDCode
        End Get
        Set(value As String)
            _mProfessionalIDCode = value
        End Set
    End Property

    Public Shared Property _pPropOwnerIDCode() As String
        Get
            Return _mPropOwnerIDCode
        End Get
        Set(value As String)
            _mPropOwnerIDCode = value
        End Set
    End Property

    Public Shared Property _pAppNo() As String
        Get
            Return _mAppNo
        End Get
        Set(value As String)
            _mAppNo = value
        End Set
    End Property

    Public Shared Property _pApplicantType() As String
        Get
            Return _mApplicantType
        End Get
        Set(value As String)
            _mApplicantType = value
        End Set
    End Property

    Public Shared Property _pDateEncoded() As String
        Get
            Return _mDateEncoded
        End Get
        Set(value As String)
            _mDateEncoded = value
        End Set
    End Property

    Public Shared Property _pIsLoaded As Boolean
        Get
            Return _mIsLoaded
        End Get
        Set(value As Boolean)
            _mIsLoaded = value
        End Set
    End Property


    Public Shared Property _pApp_BrgyCode() As String
        Get
            Return _mApp_BrgyCode
        End Get
        Set(value As String)
            _mApp_BrgyCode = value
        End Set
    End Property

    Public Shared Property _pApp_MuniCityCode() As String
        Get
            Return _mApp_MuniCityCode
        End Get
        Set(value As String)
            _mApp_MuniCityCode = value
        End Set
    End Property

    Public Shared Property _pApp_ProvCode() As String
        Get
            Return _mApp_ProvCode
        End Get
        Set(value As String)
            _mApp_ProvCode = value
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

    Public Shared Property _pRegionCode() As String
        Get
            Return _mRegionCode
        End Get
        Set(value As String)
            _mRegionCode = value
        End Set
    End Property

    Public Shared Property _pRegionDesc() As String
        Get
            Return _mRegionDesc
        End Get
        Set(value As String)
            _mRegionDesc = value
        End Set
    End Property


End Class
