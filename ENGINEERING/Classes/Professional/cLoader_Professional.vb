Public Class cLoader_Professional

#Region "Variable Field"

    Private Shared _mIsSelected As Boolean
    Private Shared _mAddress As String
    Private Shared _mAddress1 As String
    Private Shared _mAddress2 As String
    Private Shared _mAddress3 As String
    Private Shared _mAddress4 As String
    Private Shared _mAddress5 As String
    Private Shared _mCTC_ISS_Date As String
    Private Shared _mCTC_Plc_ISS As String
    Private Shared _mCTCNo As String
    Private Shared _mFName As String
    Private Shared _mFullName As String
    Private Shared _mIAPO_ORNo As String
    Private Shared _mIAPOA_Date_ISS As String
    Private Shared _mIAPOANo As String
    Private Shared _mIDCode As String
    Private Shared _mLName As String
    Private Shared _mMName As String
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
    Private Shared _mZIPCode As String
    Private Shared _mDateEncoded As String
    Private Shared _mDateApplied As String

    Private Shared _mNo As String
    Private Shared _mLotNo As String
    Private Shared _mBlkNo As String
    Private Shared _mPhaseZone As String
    Private Shared _mRegion As String
    Private Shared _mSubdVillage As String

#End Region

#Region "Property Field"

    Public Shared Property _pSubdVillage() As String
        Get
            Return _mSubdVillage
        End Get
        Set(value As String)
            _mSubdVillage = value
        End Set
    End Property

    Public Shared Property _pRegion() As String
        Get
            Return _mRegion
        End Get
        Set(value As String)
            _mRegion = value
        End Set
    End Property

    Public Shared Property _pPhaseZone() As String
        Get
            Return _mPhaseZone
        End Get
        Set(value As String)
            _mPhaseZone = value
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

    Public Shared Property _pLotNo() As String
        Get
            Return _mLotNo
        End Get
        Set(value As String)
            _mLotNo = value
        End Set
    End Property

    Public Shared Property _pNo() As String
        Get
            Return _mNo
        End Get
        Set(value As String)
            _mNo = value
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

    Public Shared Property _pDateApplied() As String
        Get
            Return _mDateApplied
        End Get
        Set(value As String)
            _mDateApplied = value
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

    Public Shared Property _pZIPCode() As String
        Get
            Return _mZIPCode
        End Get
        Set(value As String)
            _mZIPCode = value
        End Set
    End Property

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

    Public Shared Property _pFName() As String
        Get
            Return _mFName
        End Get
        Set(value As String)
            _mFName = value
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

    Public Shared Property _pIDCode() As String
        Get
            Return _mIDCode
        End Get
        Set(value As String)
            _mIDCode = value
        End Set
    End Property

    Public Shared Property _pLName() As String
        Get
            Return _mLName
        End Get
        Set(value As String)
            _mLName = value
        End Set
    End Property

    Public Shared Property _pMName() As String
        Get
            Return _mMName
        End Get
        Set(value As String)
            _mMName = value
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


End Class
