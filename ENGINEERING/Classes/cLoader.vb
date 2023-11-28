Imports System.Data.SqlClient

Public Class cLoader
    Private Shared _mSqlCon_TOIMS As New SqlConnection 'added by abby 20190806
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCon_RPTAS As New SqlConnection

    Private Shared _mIDCode As String = Nothing
    Private Shared _mLastName As String = Nothing
    Private Shared _mFirstName As String = Nothing
    Private Shared _mMiddleName As String = Nothing
    Private Shared _mTrapName As Boolean = False
    Private Shared _mIfSelect As Boolean = False
    Private Shared _mTrgName As String = Nothing
    'FOR APPLICANT
    Private Shared _mAddress1 As String = Nothing
    Private Shared _mAddress2 As String = Nothing
    Private Shared _mAddress3 As String = Nothing
    Private Shared _mAddress4 As String = Nothing
    Private Shared _mAddress5 As String = Nothing
    Private Shared _mApplCode As String = Nothing
    Private Shared _mTIN As String = Nothing
    Private Shared _mTellNo As String = Nothing
    Private Shared _mFullName As String = Nothing
    Private Shared _mAddress As String = Nothing
    Private Shared _mCTCNo As String = Nothing
    Private Shared _mCTC_ISS_Date As String = Nothing
    Private Shared _mCTC_Plc_ISS As String = Nothing
    'FOR PROFESSIONAL
    Private Shared _mIAPO_ORNo As String
    Private Shared _mIAPOA_Date_ISS As String
    Private Shared _mIAPOANo As String
    Private Shared _mMobileNo As String
    Private Shared _mPCab_Validity As String
    Private Shared _mPCabLicNo As String
    Private Shared _mPRC_Date_ISS As String
    Private Shared _mPRC_Place_Issued As String
    Private Shared _mPRCNo As String
    Private Shared _mProf_Title As String
    Private Shared _mPTR_Date_ISS As String
    Private Shared _mPTR_PLc_ISS As String
    Private Shared _mPTRNo As String
    Private Shared _mTelNo As String
    Private Shared _mTINNo As String
    'FOR PROPERTY OWNER
    Private Shared _mLotNo As String
    Private Shared _mPIN As String
    Private Shared _mProp_SW As Boolean
    Private Shared _mPropKind As String
    Private Shared _mTDN As String
    'For lookup filteration
    Private Shared _mMuniCityCode As String
    Private Shared _mMuniCityDesc As String
    Private Shared _mProvCode As String
    Private Shared _mProvDesc As String
    Private Shared _mRegCode As String
    Private Shared _mRegDesc As String

#Region "Property Data"
    Public Shared Property _gSqlCon() As SqlConnection
        Get
            Try
                Return _mSqlCon
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property

    Public Shared Property _gSqlCon_RPTAS() As SqlConnection
        Get
            Try
                Return _mSqlCon_RPTAS
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlCon_RPTAS = value
        End Set
    End Property

    Public Shared Property _gSqlCon_TOIMS() As SqlConnection
        Get
            Try
                Return _mSqlCon_TOIMS
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlCon_TOIMS = value
        End Set
    End Property
#End Region


    Public Shared Property _pIDCode() As String
        Get
            Return _mIDCode
        End Get
        Set(value As String)
            _mIDCode = value
        End Set
    End Property

    Public Shared Property _pLastName() As String
        Get
            Return _mLastName
        End Get
        Set(value As String)
            _mLastName = value
        End Set
    End Property

    Public Shared Property _pFirstName() As String
        Get
            Return _mFirstName
        End Get
        Set(value As String)
            _mFirstName = value
        End Set
    End Property

    Public Shared Property _pMiddleName() As String
        Get
            Return _mMiddleName
        End Get
        Set(value As String)
            _mMiddleName = value
        End Set
    End Property

    Public Shared Property _pTrapName() As Boolean
        Get
            Return _mTrapName
        End Get
        Set(value As Boolean)
            _mTrapName = value
        End Set
    End Property

    Public Shared Property _pIfSelect() As Boolean
        Get
            Return _mIfSelect
        End Get
        Set(value As Boolean)
            _mIfSelect = value
        End Set
    End Property

    Public Shared Property _pTrgName() As String
        Get
            Return _mTrgName
        End Get
        Set(value As String)
            _mTrgName = value
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


#Region "Property Field"

    Public Shared Property _pAddress() As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
        End Set
    End Property

    Public Shared Property _pAddress1() As String
        Get
            Return _mAddress1
        End Get
        Set(value As String)
            _mAddress1 = value
        End Set
    End Property

    Public Shared Property _pAddress2() As String
        Get
            Return _mAddress2
        End Get
        Set(value As String)
            _mAddress2 = value
        End Set
    End Property

    Public Shared Property _pAddress3() As String
        Get
            Return _mAddress3
        End Get
        Set(value As String)
            _mAddress3 = value
        End Set
    End Property

    Public Shared Property _pAddress4() As String
        Get
            Return _mAddress4
        End Get
        Set(value As String)
            _mAddress4 = value
        End Set
    End Property

    Public Shared Property _pAddress5() As String
        Get
            Return _mAddress5
        End Get
        Set(value As String)
            _mAddress5 = value
        End Set
    End Property

    Public Shared Property _pApplCode() As String
        Get
            Return _mApplCode
        End Get
        Set(value As String)
            _mApplCode = value
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

    Public Shared Property _pCTCNo() As String
        Get
            Return _mCTCNo
        End Get
        Set(value As String)
            _mCTCNo = value
        End Set
    End Property

    Public Shared Property _pFullName() As String
        Get
            Return _mFullName
        End Get
        Set(value As String)
            _mFullName = value
        End Set
    End Property

    Public Shared Property _pTellNo() As String
        Get
            Return _mTellNo
        End Get
        Set(value As String)
            _mTellNo = value
        End Set
    End Property

    Public Shared Property _pTIN() As String
        Get
            Return _mTIN
        End Get
        Set(value As String)
            _mTIN = value
        End Set
    End Property


#End Region

#Region "Property Field"

    Public Shared Property _pIAPO_ORNo() As String
        Get
            Return _mIAPO_ORNo
        End Get
        Set(value As String)
            _mIAPO_ORNo = value
        End Set
    End Property

    Public Shared Property _pIAPOA_Date_ISS() As String
        Get
            Return _mIAPOA_Date_ISS
        End Get
        Set(value As String)
            _mIAPOA_Date_ISS = value
        End Set
    End Property

    Public Shared Property _pIAPOANo() As String
        Get
            Return _mIAPOANo
        End Get
        Set(value As String)
            _mIAPOANo = value
        End Set
    End Property

    Public Shared Property _pMobileNo() As String
        Get
            Return _mMobileNo
        End Get
        Set(value As String)
            _mMobileNo = value
        End Set
    End Property

    Public Shared Property _pPCab_Validity() As String
        Get
            Return _mPCab_Validity
        End Get
        Set(value As String)
            _mPCab_Validity = value
        End Set
    End Property

    Public Shared Property _pPCabLicNo() As String
        Get
            Return _mPCabLicNo
        End Get
        Set(value As String)
            _mPCabLicNo = value
        End Set
    End Property

    Public Shared Property _pPRC_Date_ISS() As String
        Get
            Return _mPRC_Date_ISS
        End Get
        Set(value As String)
            _mPRC_Date_ISS = value
        End Set
    End Property

    Public Shared Property _pPRC_Place_Issued() As String
        Get
            Return _mPRC_Place_Issued
        End Get
        Set(value As String)
            _mPRC_Place_Issued = value
        End Set
    End Property

    Public Shared Property _pPRCNo() As String
        Get
            Return _mPRCNo
        End Get
        Set(value As String)
            _mPRCNo = value
        End Set
    End Property

    Public Shared Property _pProf_Title() As String
        Get
            Return _mProf_Title
        End Get
        Set(value As String)
            _mProf_Title = value
        End Set
    End Property

    Public Shared Property _pPTR_Date_ISS() As String
        Get
            Return _mPTR_Date_ISS
        End Get
        Set(value As String)
            _mPTR_Date_ISS = value
        End Set
    End Property

    Public Shared Property _pPTR_PLc_ISS() As String
        Get
            Return _mPTR_PLc_ISS
        End Get
        Set(value As String)
            _mPTR_PLc_ISS = value
        End Set
    End Property

    Public Shared Property _pPTRNo() As String
        Get
            Return _mPTRNo
        End Get
        Set(value As String)
            _mPTRNo = value
        End Set
    End Property

    Public Shared Property _pTelNo() As String
        Get
            Return _mTelNo
        End Get
        Set(value As String)
            _mTelNo = value
        End Set
    End Property

    Public Shared Property _pTINNo() As String
        Get
            Return _mTINNo
        End Get
        Set(value As String)
            _mTINNo = value
        End Set
    End Property

#End Region

    '===== PROFESSIONAL

#Region "Property Field"

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

    Public Shared Property _pProp_SW() As Boolean
        Get
            Return _mProp_SW
        End Get
        Set(value As Boolean)
            _mProp_SW = value
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

    Public Shared Property _pTDN() As String
        Get
            Return _mTDN
        End Get
        Set(value As String)
            _mTDN = value
        End Set
    End Property


#End Region

End Class