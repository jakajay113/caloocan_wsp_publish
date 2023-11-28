Public Class cLoader_LotOwner
    Private Shared _mEMS_AcctNo As String = Nothing
    Private Shared _mEMS_SubAcctNo As String = Nothing
    Private Shared _mPermitType As String = Nothing
    Private Shared _mIDCode As String = Nothing
    Private Shared _mAppNo As String = Nothing
    Private Shared _mApplicantType As String = Nothing
    Private Shared _mDateEncoded As Date
    Private Shared _mIsLoaded As Boolean
    Private Shared _mIsSelect As Boolean
    Private Shared _mTrapName As Boolean
    Private Shared _mTrgName As String
    Private Shared _mLastName As String
    Private Shared _mFirstName As String
    Private Shared _mMiddleName As String
    Private Shared _mAddress1 As String
    Private Shared _mAddress2 As String
    Private Shared _mAddress3 As String
    Private Shared _mAddress4 As String
    Private Shared _mAddress5 As String
    Private Shared _mTelNo As String
    Private Shared _mTIN As String
    Private Shared _mFullName As String
    Private Shared _mAddress As String
    'Private Shared _mAppNo As String
    Private Shared _mBarangay As String
    Private Shared _mBlkNo As String
    'Private Shared _mDateEncoded As String
    Private Shared _mEncoderID As String
    'Private Shared _mIDCode As String
    Private Shared _mLotNo As String
    Private Shared _mPIN As String
    Private Shared _mPropKind As String
    Private Shared _mStreet As String
    Private Shared _mCityMuni As String
    Private Shared _mTCTNo As String
    Private Shared _mTDN As String
    Private Shared _mCTCNo As String
    Private Shared _mCTC_ISS_Date As String
    Private Shared _mCTC_Plc_ISS As String
    Private Shared _mApp_ProvCode As String
    Private Shared _mApp_MuniCityCode As String
    Private Shared _mApp_BrgyCode As String
    Private Shared _mApp_StrtCode As String
    Private Shared _mZIPCode As String
    Private Shared _mTempIDCode As String = Nothing

    Public Shared Property _pTempIDCode As String
        Get
            Return _mTempIDCode
        End Get
        Set(value As String)
            _mTempIDCode = value
        End Set
    End Property

    Public Shared Property _pZIPCode As String
        Get
            Return _mZIPCode
        End Get
        Set(value As String)
            _mZIPCode = value
        End Set
    End Property


    Public Shared Property _pTrapName As String
        Get
            Return _mTrapName
        End Get
        Set(value As String)
            _mTrapName = value
        End Set
    End Property

    Public Shared Property _pLastName As String
        Get
            Return _mLastName
        End Get
        Set(value As String)
            _mLastName = value
        End Set
    End Property

    Public Shared Property _pFirstName As String
        Get
            Return _mFirstName
        End Get
        Set(value As String)
            _mFirstName = value
        End Set
    End Property

    Public Shared Property _pMiddleName As String
        Get
            Return _mMiddleName
        End Get
        Set(value As String)
            _mMiddleName = value
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

    Public Shared Property _pApplicantType() As String
        Get
            Return _mApplicantType
        End Get
        Set(value As String)
            _mApplicantType = value
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

    Public Shared Property _pIfSelect As Boolean
        Get
            Return _mIsSelect
        End Get
        Set(value As Boolean)
            _mIsSelect = value
        End Set
    End Property

    Public Shared Property _pTrgName As String
        Get
            Return _mTrgName
        End Get
        Set(value As String)
            _mTrgName = value
        End Set
    End Property

    Public Shared Property _pAddress1 As String
        Get
            Return _mAddress1
        End Get
        Set(value As String)
            _mAddress1 = value
        End Set
    End Property

    Public Shared Property _pAddress2 As String
        Get
            Return _mAddress2
        End Get
        Set(value As String)
            _mAddress2 = value
        End Set
    End Property

    Public Shared Property _pAddress3 As String
        Get
            Return _mAddress3
        End Get
        Set(value As String)
            _mAddress3 = value
        End Set
    End Property

    Public Shared Property _pAddress4 As String
        Get
            Return _mAddress4
        End Get
        Set(value As String)
            _mAddress4 = value
        End Set
    End Property

    Public Shared Property _pAddress5 As String
        Get
            Return _mAddress5
        End Get
        Set(value As String)
            _mAddress5 = value
        End Set
    End Property

    Public Shared Property _pTIN As String
        Get
            Return _mTIN
        End Get
        Set(value As String)
            _mTIN = value
        End Set
    End Property

    Public Shared Property _pTelNo As String
        Get
            Return _mTelNo
        End Get
        Set(value As String)
            _mTelNo = value
        End Set
    End Property

    Public Shared Property _pFullName As String
        Get
            Return _mFullName
        End Get
        Set(value As String)
            _mFullName = value
        End Set
    End Property

    Public Shared Property _pAddress As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
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

    Public Shared Property _pBarangay() As String
        Get
            Return _mBarangay
        End Get
        Set(value As String)
            _mBarangay = value
        End Set
    End Property

    Public Shared Property _pBlkNo() As String
        Get
            Return _mBlkNo
        End Get
        Set(value As String)
            _mBlkNo = value
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

    Public Shared Property _pEncoderID() As String
        Get
            Return _mEncoderID
        End Get
        Set(value As String)
            _mEncoderID = value
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

    Public Shared Property _pLotNo() As String
        Get
            Return _mLotNo
        End Get
        Set(value As String)
            _mLotNo = value
        End Set
    End Property

    Public Shared Property _pPIN() As String
        Get
            Return _mPIN
        End Get
        Set(value As String)
            _mPIN = value
        End Set
    End Property

    Public Shared Property _pPropKind() As String
        Get
            Return _mPropKind
        End Get
        Set(value As String)
            _mPropKind = value
        End Set
    End Property

    Private Shared _mPropSelected As String

    Public Shared Property _pPropSelected() As String
        Get
            Return _mPropSelected
        End Get
        Set(value As String)
            _mPropSelected = value
        End Set
    End Property

    Public Shared Property _pStreet() As String
        Get
            Return _mStreet
        End Get
        Set(value As String)
            _mStreet = value
        End Set
    End Property

    Public Shared Property _pCityMuni() As String
        Get
            Return _mCityMuni
        End Get
        Set(value As String)
            _mCityMuni = value
        End Set
    End Property

    Public Shared Property _pTCTNo() As String
        Get
            Return _mTCTNo
        End Get
        Set(value As String)
            _mTCTNo = value
        End Set
    End Property

    Public Shared Property _pTDN() As String
        Get
            Return _mTDN
        End Get
        Set(value As String)
            _mTDN = value
        End Set
    End Property

    Public Shared Property _pCTCNo() As String
        Get
            Return _mCTCNo
        End Get
        Set(value As String)
            _mCTCNo = value
        End Set
    End Property

    Public Shared Property _pCTC_ISS_Date() As String
        Get
            Return _mCTC_ISS_Date
        End Get
        Set(value As String)
            _mCTC_ISS_Date = value
        End Set
    End Property

    Public Shared Property _pCTC_Plc_ISS() As String
        Get
            Return _mCTC_Plc_ISS
        End Get
        Set(value As String)
            _mCTC_Plc_ISS = value
        End Set
    End Property

    Public Shared Property _pApp_ProvCode As String
        Get
            Return _mApp_ProvCode
        End Get
        Set(value As String)
            _mApp_ProvCode = value
        End Set
    End Property
    Public Shared Property _pApp_MuniCityCode As String
        Get
            Return _mApp_MuniCityCode
        End Get
        Set(value As String)
            _mApp_MuniCityCode = value
        End Set
    End Property
    Public Shared Property _pApp_BrgyCode As String
        Get
            Return _mApp_BrgyCode
        End Get
        Set(value As String)
            _mApp_BrgyCode = value
        End Set
    End Property

    Public Shared Property _pApp_StrtCode As String
        Get
            Return _mApp_StrtCode
        End Get
        Set(value As String)
            _mApp_StrtCode = value
        End Set
    End Property

End Class
