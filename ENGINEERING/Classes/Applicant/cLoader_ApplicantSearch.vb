Public Class cLoader_ApplicantSearch
    Public Shared _pApplicantPRessF1 As Boolean
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
    Private Shared _mFullname As String
    Private Shared _mAddress As String
    Private Shared _mAddress1 As String
    Private Shared _mAddress2 As String
    Private Shared _mAddress3 As String
    Private Shared _mAddress4 As String
    Private Shared _mAddress5 As String
    Private Shared _mTelNo As String
    Private Shared _mTIN As String
    Private Shared _mZIPCode As String
    Private Shared _mCTCNo As String
    Private Shared _mCTC_Plc_ISS As String
    Private Shared _mCTC_ISS_Date As String
    Private Shared _mTempIDCode As String = Nothing
    Private Shared _Inquiry As Boolean = False

    Public Shared Property _pInquiry As Boolean
        Get
            Return _Inquiry
        End Get
        Set(value As Boolean)
            _Inquiry = value
        End Set
    End Property

    Public Shared Property _pTempIDCode As String
        Get
            Return _mTempIDCode
        End Get
        Set(value As String)
            _mTempIDCode = value
        End Set
    End Property

    Public Shared Property _pCTC_ISS_Date As String
        Get
            Return _mCTC_ISS_Date
        End Get
        Set(value As String)
            _mCTC_ISS_Date = value
        End Set
    End Property

    Public Shared Property _pCTC_Plc_ISS As String
        Get
            Return _mCTC_Plc_ISS
        End Get
        Set(value As String)
            _mCTC_Plc_ISS = value
        End Set
    End Property

    Public Shared Property _pCTCNo As String
        Get
            Return _mCTCNo
        End Get
        Set(value As String)
            _mCTCNo = value
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
    Public Shared Property _pFullName As String
        Get
            Return _mFullname
        End Get
        Set(value As String)
            _mFullname = value
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

    Public Shared Property _pIDCode() As String
        Get
            Return _mIDCode
        End Get
        Set(value As String)
            _mIDCode = value
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

    Public Shared Property _pAddress As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
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

End Class
