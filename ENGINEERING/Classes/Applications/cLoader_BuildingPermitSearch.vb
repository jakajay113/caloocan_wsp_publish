Public Class cLoader_BuildingPermitSearch
#Region "Variable Field"

    Private Shared _mAppDate As String
    Private Shared _mAppDateSigned As String
    Private Shared _mAppNo As String
    Private Shared _mAreaNo As String
    Private Shared _mBlkNo As String
    Private Shared _mBrgyCode As String
    Private Shared _mBldg_PermitNo As String
    Private Shared _mCellNo As String
    Private Shared _mEMS_AcctNo As String
    Private Shared _mEMS_SubAcctNo As String
    Private Shared _mFName As String
    Private Shared _mIDCode As String
    Private Shared _mInspSup_Code As String
    Private Shared _mLName As String
    Private Shared _mLot_ConsentDate As String
    Private Shared _mLot_IDNo As String
    Private Shared _mLotNo As String
    Private Shared _mMName As String
    Private Shared _mMuniCityCode As String
    Private Shared _mNoOfStorey As String
    Private Shared _mNoOfUnits As String
    Private Shared _mOAPCode As String
    Private Shared _mOwnCode As String
    Private Shared _mOwner_Address As String
    Private Shared _mPermitType As String
    Private Shared _mPIN As String
    Private Shared _mStrtCode As String
    Private Shared _mSW_Approved As Boolean
    Private Shared _mSW_Assess As Boolean
    Private Shared _mSW_Compl As Boolean
    Private Shared _mSW_Paid As Boolean
    Private Shared _mSW_Scope As Boolean
    Private Shared _mSW_UseCode As Boolean
    Private Shared _mTCTNo As String
    Private Shared _mTDN As String
    Private Shared _mTellNo As String
    Private Shared _mTIN As String
    Private Shared _mZipCode As String
    Private Shared _mLOFullName As String
    Private Shared _mLOAddress As String
    Private Shared _mLOCTCNo As String
    Private Shared _mLOCTCDateIss As String
    Private Shared _mLOCTCPlaceIss As String
    Private Shared _mBOFullName As String
    Private Shared _mBOAddress As String
    Private Shared _mBOCTCNo As String
    Private Shared _mBOCTCDateIss As String
    Private Shared _mBOCTCPlaceIss As String
    Private Shared _mClose As Boolean
    Private Shared _mPropKind As String
    Private Shared _mBldg_IDNo As String
    Private Shared _mBldg_ConsentDate As String
    Private Shared _mOccupancyCode As String

    Private Shared _mDateEncoded As String
    Private Shared _mEncoderID As String
    Private Shared _mDateApplied As String
    Private Shared _mBldgPermitNo As Boolean
    Private Shared _mPermitNo As String

    Private Shared _mEst_Cost As String '---------------- Archie20191227
    Private Shared _mExpComDate As String
    Private Shared _mFlrArea As String
    Private Shared _mNo_Floor As String
    Private Shared _mPropConstDate As String
    Private Shared _mTot_FlrArea As String
    Private Shared _mOcc_Class As String

#End Region
#Region "Property Field"

    Public Shared Property _pOcc_Class() As String '---------------- Archie20191227
        Get
            Return _mOcc_Class
        End Get
        Set(value As String)
            _mOcc_Class = value
        End Set
    End Property

    Public Shared Property _pTot_FlrArea() As String '---------------- Archie20191227
        Get
            Return _mTot_FlrArea
        End Get
        Set(value As String)
            _mTot_FlrArea = value
        End Set
    End Property

    Public Shared Property _pPropConstDate() As String '---------------- Archie20191227
        Get
            Return _mPropConstDate
        End Get
        Set(value As String)
            _mPropConstDate = value
        End Set
    End Property

    Public Shared Property _pNo_Floor() As String '---------------- Archie20191227
        Get
            Return _mNo_Floor
        End Get
        Set(value As String)
            _mNo_Floor = value
        End Set
    End Property

    Public Shared Property _pFlrArea() As String '---------------- Archie20191227
        Get
            Return _mFlrArea
        End Get
        Set(value As String)
            _mFlrArea = value
        End Set
    End Property

    Public Shared Property _pExpComDate() As String '---------------- Archie20191227
        Get
            Return _mExpComDate
        End Get
        Set(value As String)
            _mExpComDate = value
        End Set
    End Property
    Public Shared Property _pEst_Cost() As String '---------------- Archie20191227
        Get
            Return _mEst_Cost
        End Get
        Set(value As String)
            _mEst_Cost = value
        End Set
    End Property

    Public Shared Property _pPermitNo() As String
        Get
            Return _mPermitNo
        End Get
        Set(value As String)
            _mPermitNo = value
        End Set
    End Property

    Public Shared Property _pBldgPermitNo() As Boolean
        Get
            Return _mBldgPermitNo
        End Get
        Set(value As Boolean)
            _mBldgPermitNo = value
        End Set
    End Property

    Public Shared Property _pBldg_PermitNo() As String
        Get
            Return _mBldg_PermitNo
        End Get
        Set(value As String)
            _mBldg_PermitNo = value
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

    Public Shared Property _pDateApplied() As String
        Get
            Return _mDateApplied
        End Get
        Set(value As String)
            _mDateApplied = value
        End Set
    End Property

    Public Shared Property _pBldg_ConsentDate() As String
        Get
            Return _mBldg_ConsentDate
        End Get
        Set(value As String)
            _mBldg_ConsentDate = value
        End Set
    End Property

    Public Shared Property _pBldg_IDNo() As String
        Get
            Return _mBldg_IDNo
        End Get
        Set(value As String)
            _mBldg_IDNo = value
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

    Public Shared Property _pClose() As Boolean
        Get
            Return _mClose
        End Get
        Set(value As Boolean)
            _mClose = value
        End Set
    End Property

    Public Shared Property _pBOCTCPlaceIss() As String
        Get
            Return _mBOCTCPlaceIss
        End Get
        Set(value As String)
            _mBOCTCPlaceIss = value
        End Set
    End Property

    Public Shared Property _pBOCTCDateIss() As String
        Get
            Return _mBOCTCDateIss
        End Get
        Set(value As String)
            _mBOCTCDateIss = value
        End Set
    End Property

    Public Shared Property _pBOCTCNo() As String
        Get
            Return _mBOCTCNo
        End Get
        Set(value As String)
            _mBOCTCNo = value
        End Set
    End Property

    Public Shared Property _pBOAddress() As String
        Get
            Return _mBOAddress
        End Get
        Set(value As String)
            _mBOAddress = value
        End Set
    End Property

    Public Shared Property _pBOFullName() As String
        Get
            Return _mBOFullName
        End Get
        Set(value As String)
            _mBOFullName = value
        End Set
    End Property

    Public Shared Property _pLOCTCPlaceIss() As String
        Get
            Return _mLOCTCPlaceIss
        End Get
        Set(value As String)
            _mLOCTCPlaceIss = value
        End Set
    End Property

    Public Shared Property _pLOCTCDateIss() As String
        Get
            Return _mLOCTCDateIss
        End Get
        Set(value As String)
            _mLOCTCDateIss = value
        End Set
    End Property

    Public Shared Property _pLOCTCNo() As String
        Get
            Return _mLOCTCNo
        End Get
        Set(value As String)
            _mLOCTCNo = value
        End Set
    End Property

    Public Shared Property _pLOAddress() As String
        Get
            Return _mLOAddress
        End Get
        Set(value As String)
            _mLOAddress = value
        End Set
    End Property

    Public Shared Property _pLOFullName() As String
        Get
            Return _mLOFullName
        End Get
        Set(value As String)
            _mLOFullName = value
        End Set
    End Property

    Public Shared Property _pAppDate() As String
        Get
            Return _mAppDate
        End Get
        Set(value As String)
            _mAppDate = value
        End Set
    End Property

    Public Shared Property _pAppDateSigned() As String
        Get
            Return _mAppDateSigned
        End Get
        Set(value As String)
            _mAppDateSigned = value
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

    Public Shared Property _pAreaNo() As String
        Get
            Return _mAreaNo
        End Get
        Set(value As String)
            _mAreaNo = value
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

    Public Shared Property _pBrgyCode() As String
        Get
            Return _mBrgyCode
        End Get
        Set(value As String)
            _mBrgyCode = value
        End Set
    End Property

    Public Shared Property _pCellNo() As String
        Get
            Return _mCellNo
        End Get
        Set(value As String)
            _mCellNo = value
        End Set
    End Property

    Public Shared Property _pEMS_AcctNo() As String
        Get
            Return _mEMS_AcctNo
        End Get
        Set(value As String)
            _mEMS_AcctNo = value
        End Set
    End Property

    Public Shared Property _pEMS_SubAcctNo() As String
        Get
            Return _mEMS_SubAcctNo
        End Get
        Set(value As String)
            _mEMS_SubAcctNo = value
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

    Public Shared Property _pIDCode() As String
        Get
            Return _mIDCode
        End Get
        Set(value As String)
            _mIDCode = value
        End Set
    End Property

    Public Shared Property _pInspSup_Code() As String
        Get
            Return _mInspSup_Code
        End Get
        Set(value As String)
            _mInspSup_Code = value
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

    Public Shared Property _pLot_ConsentDate() As String
        Get
            Return _mLot_ConsentDate
        End Get
        Set(value As String)
            _mLot_ConsentDate = value
        End Set
    End Property

    Public Shared Property _pLot_IDNo() As String
        Get
            Return _mLot_IDNo
        End Get
        Set(value As String)
            _mLot_IDNo = value
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

    Public Shared Property _pMName() As String
        Get
            Return _mMName
        End Get
        Set(value As String)
            _mMName = value
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

    Public Shared Property _pNoOfStorey() As String
        Get
            Return _mNoOfStorey
        End Get
        Set(value As String)
            _mNoOfStorey = value
        End Set
    End Property

    Public Shared Property _pNoOfUnits() As String
        Get
            Return _mNoOfUnits
        End Get
        Set(value As String)
            _mNoOfUnits = value
        End Set
    End Property

    Public Shared Property _pOAPCode() As String
        Get
            Return _mOAPCode
        End Get
        Set(value As String)
            _mOAPCode = value
        End Set
    End Property

    Public Shared Property _pOwnCode() As String
        Get
            Return _mOwnCode
        End Get
        Set(value As String)
            _mOwnCode = value
        End Set
    End Property

    Public Shared Property _pOwner_Address() As String
        Get
            Return _mOwner_Address
        End Get
        Set(value As String)
            _mOwner_Address = value
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

    Public Shared Property _pPIN() As String
        Get
            Return _mPIN
        End Get
        Set(value As String)
            _mPIN = value
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

    Public Shared Property _pSW_Approved() As Boolean
        Get
            Return _mSW_Approved
        End Get
        Set(value As Boolean)
            _mSW_Approved = value
        End Set
    End Property

    Public Shared Property _pSW_Assess() As Boolean
        Get
            Return _mSW_Assess
        End Get
        Set(value As Boolean)
            _mSW_Assess = value
        End Set
    End Property

    Public Shared Property _pSW_Compl() As Boolean
        Get
            Return _mSW_Compl
        End Get
        Set(value As Boolean)
            _mSW_Compl = value
        End Set
    End Property

    Public Shared Property _pSW_Paid() As Boolean
        Get
            Return _mSW_Paid
        End Get
        Set(value As Boolean)
            _mSW_Paid = value
        End Set
    End Property

    Public Shared Property _pSW_Scope() As Boolean
        Get
            Return _mSW_Scope
        End Get
        Set(value As Boolean)
            _mSW_Scope = value
        End Set
    End Property

    Public Shared Property _pSW_UseCode() As Boolean
        Get
            Return _mSW_UseCode
        End Get
        Set(value As Boolean)
            _mSW_UseCode = value
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

    Public Shared Property _pZipCode() As String
        Get
            Return _mZipCode
        End Get
        Set(value As String)
            _mZipCode = value
        End Set
    End Property

    Public Shared Property _pOccupancyCode() As String
        Get
            Return _mOccupancyCode
        End Get
        Set(value As String)
            _mOccupancyCode = value
        End Set
    End Property


#End Region
End Class
