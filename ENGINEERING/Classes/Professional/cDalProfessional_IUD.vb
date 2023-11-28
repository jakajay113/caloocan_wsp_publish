Imports System.Data.SqlClient

Public Class cDalProfessional_IUD

#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String


#End Region

#Region "Property Object"
    Public Shared ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                Return _mDataTable
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public Shared Property _pSqlCon() As SqlConnection
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
#End Region

#Region "Variable Field"

    Private Shared _mAdd As Boolean
    Private Shared _mAddress1 As String
    Private Shared _mAddress2 As String
    Private Shared _mAddress3 As String
    Private Shared _mAddress4 As String
    Private Shared _mAddress5 As String
    Private Shared _mDateEncoded As String
    Private Shared _mEncoderID As String
    Private Shared _mFName As String
    Private Shared _mIA_POA_Date_Issued As String
    Private Shared _mIA_POA_No As String
    Private Shared _mIA_POA_ORNumber As String
    Private Shared _mIDCode As String
    Private Shared _mLName As String
    Private Shared _mMName As String
    Private Shared _mMobileNo As String
    Private Shared _mPCAB_License_No As String
    Private Shared _mPCAB_Validity As String
    Private Shared _mPRC_DateIssued As String
    Private Shared _mPRC_Place_Issued As String
    Private Shared _mPRC_Validity As String
    Private Shared _mPRCNo As String
    Private Shared _mProf_Title As String
    Private Shared _mPTR_Date_Issued As String
    Private Shared _mPTR_Place_Issued As String
    Private Shared _mPTRNo As String
    Private Shared _mTelNo As String
    Private Shared _mTINNo As String
    Private Shared _mFullName As String
    Private Shared _mAddress As String
    Private Shared _mPTR_Place_ISS As String
    Private Shared _mZIPCode As String

    Private Shared _mHAdd As Boolean '-------------Archie 20200121 --- H as history
    Private Shared _mHAddress1 As String
    Private Shared _mHAddress2 As String
    Private Shared _mHAddress3 As String
    Private Shared _mHAddress4 As String
    Private Shared _mHAddress5 As String
    Private Shared _mHDateEncoded As String
    Private Shared _mHEncoderID As String
    Private Shared _mHFName As String
    Private Shared _mHIA_POA_Date_Issued As String
    Private Shared _mHIA_POA_No As String
    Private Shared _mHIA_POA_ORNumber As String
    Private Shared _mHIDCode As String
    Private Shared _mHLName As String
    Private Shared _mHMName As String
    Private Shared _mHMobileNo As String
    Private Shared _mHPCAB_License_No As String
    Private Shared _mHPCAB_Validity As String
    Private Shared _mHPRC_DateIssued As String
    Private Shared _mHPRC_Place_Issued As String
    Private Shared _mHPRC_Validity As String
    Private Shared _mHPRCNo As String
    Private Shared _mHProf_Title As String
    Private Shared _mHPTR_Date_Issued As String
    Private Shared _mHPTR_Place_Issued As String
    Private Shared _mHPTRNo As String
    Private Shared _mHTelNo As String
    Private Shared _mHTINNo As String
    Private Shared _mHFullName As String
    Private Shared _mHAddress As String
    Private Shared _mHPTR_Place_ISS As String
    Private Shared _mHZIPCode As String

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

    Public Shared Property _pFName() As String
        Get
            Return _mFName
        End Get
        Set(value As String)
            _mFName = value
        End Set
    End Property

    Public Shared Property _pIA_POA_Date_Issued() As String
        Get
            Return _mIA_POA_Date_Issued
        End Get
        Set(value As String)
            _mIA_POA_Date_Issued = value
        End Set
    End Property

    Public Shared Property _pIA_POA_No() As String
        Get
            Return _mIA_POA_No
        End Get
        Set(value As String)
            _mIA_POA_No = value
        End Set
    End Property

    Public Shared Property _pIA_POA_ORNumber() As String
        Get
            Return _mIA_POA_ORNumber
        End Get
        Set(value As String)
            _mIA_POA_ORNumber = value
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

    Public Shared Property _pPCAB_License_No() As String
        Get
            Return _mPCAB_License_No
        End Get
        Set(value As String)
            _mPCAB_License_No = value
        End Set
    End Property

    Public Shared Property _pPCAB_Validity() As String
        Get
            Return _mPCAB_Validity
        End Get
        Set(value As String)
            _mPCAB_Validity = value
        End Set
    End Property

    Public Shared Property _pPRC_DateIssued() As String
        Get
            Return _mPRC_DateIssued
        End Get
        Set(value As String)
            _mPRC_DateIssued = value
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

    Public Shared Property _pPRC_Validity() As String
        Get
            Return _mPRC_Validity
        End Get
        Set(value As String)
            _mPRC_Validity = value
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

    Public Shared Property _pPTR_Date_Issued() As String
        Get
            Return _mPTR_Date_Issued
        End Get
        Set(value As String)
            _mPTR_Date_Issued = value
        End Set
    End Property

    Public Shared Property _pPTR_Place_Issued() As String
        Get
            Return _mPTR_Place_Issued
        End Get
        Set(value As String)
            _mPTR_Place_Issued = value
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

    Public Shared Property _pFullName() As String
        Get
            Return _mFullName
        End Get
        Set(value As String)
            _mFullName = value
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

    Public Shared Property _pPTR_Place_ISS() As String
        Get
            Return _mPTR_Place_ISS
        End Get
        Set(value As String)
            _mPTR_Place_ISS = value
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

    Public Shared Property _pHAddress1() As String
        Get
            Return _mHAddress1
        End Get
        Set(value As String)
            _mHAddress1 = value
        End Set
    End Property

    Public Shared Property _pHAddress2() As String
        Get
            Return _mHAddress2
        End Get
        Set(value As String)
            _mHAddress2 = value
        End Set
    End Property

    Public Shared Property _pHAddress3() As String
        Get
            Return _mHAddress3
        End Get
        Set(value As String)
            _mHAddress3 = value
        End Set
    End Property

    Public Shared Property _pHAddress4() As String
        Get
            Return _mHAddress4
        End Get
        Set(value As String)
            _mHAddress4 = value
        End Set
    End Property

    Public Shared Property _pHAddress5() As String
        Get
            Return _mHAddress5
        End Get
        Set(value As String)
            _mHAddress5 = value
        End Set
    End Property

    Public Shared Property _pHDateEncoded() As String
        Get
            Return _mHDateEncoded
        End Get
        Set(value As String)
            _mHDateEncoded = value
        End Set
    End Property

    Public Shared Property _pHEncoderID() As String
        Get
            Return _mHEncoderID
        End Get
        Set(value As String)
            _mHEncoderID = value
        End Set
    End Property

    Public Shared Property _pHFName() As String
        Get
            Return _mHFName
        End Get
        Set(value As String)
            _mHFName = value
        End Set
    End Property

    Public Shared Property _pHIA_POA_Date_Issued() As String
        Get
            Return _mHIA_POA_Date_Issued
        End Get
        Set(value As String)
            _mHIA_POA_Date_Issued = value
        End Set
    End Property

    Public Shared Property _pHIA_POA_No() As String
        Get
            Return _mHIA_POA_No
        End Get
        Set(value As String)
            _mHIA_POA_No = value
        End Set
    End Property

    Public Shared Property _pHIA_POA_ORNumber() As String
        Get
            Return _mHIA_POA_ORNumber
        End Get
        Set(value As String)
            _mHIA_POA_ORNumber = value
        End Set
    End Property

    Public Shared Property _pHIDCode() As String
        Get
            Return _mHIDCode
        End Get
        Set(value As String)
            _mHIDCode = value
        End Set
    End Property

    Public Shared Property _pHLName() As String
        Get
            Return _mHLName
        End Get
        Set(value As String)
            _mHLName = value
        End Set
    End Property

    Public Shared Property _pHMName() As String
        Get
            Return _mHMName
        End Get
        Set(value As String)
            _mHMName = value
        End Set
    End Property

    Public Shared Property _pHMobileNo() As String
        Get
            Return _mHMobileNo
        End Get
        Set(value As String)
            _mHMobileNo = value
        End Set
    End Property

    Public Shared Property _pHPCAB_License_No() As String
        Get
            Return _mHPCAB_License_No
        End Get
        Set(value As String)
            _mHPCAB_License_No = value
        End Set
    End Property

    Public Shared Property _pHPCAB_Validity() As String
        Get
            Return _mHPCAB_Validity
        End Get
        Set(value As String)
            _mHPCAB_Validity = value
        End Set
    End Property

    Public Shared Property _pHPRC_DateIssued() As String
        Get
            Return _mHPRC_DateIssued
        End Get
        Set(value As String)
            _mHPRC_DateIssued = value
        End Set
    End Property

    Public Shared Property _pHPRC_Place_Issued() As String
        Get
            Return _mHPRC_Place_Issued
        End Get
        Set(value As String)
            _mHPRC_Place_Issued = value
        End Set
    End Property

    Public Shared Property _pHPRC_Validity() As String
        Get
            Return _mHPRC_Validity
        End Get
        Set(value As String)
            _mHPRC_Validity = value
        End Set
    End Property

    Public Shared Property _pHPRCNo() As String
        Get
            Return _mHPRCNo
        End Get
        Set(value As String)
            _mHPRCNo = value
        End Set
    End Property

    Public Shared Property _pHProf_Title() As String
        Get
            Return _mHProf_Title
        End Get
        Set(value As String)
            _mHProf_Title = value
        End Set
    End Property

    Public Shared Property _pHPTR_Date_Issued() As String
        Get
            Return _mHPTR_Date_Issued
        End Get
        Set(value As String)
            _mHPTR_Date_Issued = value
        End Set
    End Property

    Public Shared Property _pHPTR_Place_Issued() As String
        Get
            Return _mHPTR_Place_Issued
        End Get
        Set(value As String)
            _mHPTR_Place_Issued = value
        End Set
    End Property

    Public Shared Property _pHPTRNo() As String
        Get
            Return _mHPTRNo
        End Get
        Set(value As String)
            _mHPTRNo = value
        End Set
    End Property

    Public Shared Property _pHTelNo() As String
        Get
            Return _mHTelNo
        End Get
        Set(value As String)
            _mHTelNo = value
        End Set
    End Property

    Public Shared Property _pHTINNo() As String
        Get
            Return _mHTINNo
        End Get
        Set(value As String)
            _mHTINNo = value
        End Set
    End Property

    Public Shared Property _pHFullName() As String
        Get
            Return _mHFullName
        End Get
        Set(value As String)
            _mHFullName = value
        End Set
    End Property

    Public Shared Property _pHAddress() As String
        Get
            Return _mHAddress
        End Get
        Set(value As String)
            _mHAddress = value
        End Set
    End Property

    Public Shared Property _pHPTR_Place_ISS() As String
        Get
            Return _mHPTR_Place_ISS
        End Get
        Set(value As String)
            _mHPTR_Place_ISS = value
        End Set
    End Property
    Public Shared Property _pHZIPCode() As String
        Get
            Return _mHZIPCode
        End Get
        Set(value As String)
            _mHZIPCode = value
        End Set
    End Property
#End Region

#Region "Routine Data"

    Public Shared Sub _pAdd()
        Try
            _mAdd = True
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub _pEdit()
        Try
            _mAdd = False
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pLoad(ByRef _nSuccessful As Boolean, _
                                Optional _nSortField As String = "", _
                                Optional _nSortDesc As Boolean = False, _
                                Optional _nCondition As String = "")
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "EXEC [sp_Professional_IUD] " & _
                                "@Action = N'SELECT'" & _
                                ",@SelectCond = N'" & _nSelectCond & "'" & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  "

            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then

                    _mDataTable.Clear() 'clear datatable content
                    _mDataTable.Columns.Clear() 'clear datatable columns

                    'Loading Record from datareader to datatable
                    _mDataTable.Load(_nSqlDr)
                End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()

        Catch ex As Exception
            _nSuccessful = False
        End Try
    End Sub

    Public Shared Sub _pSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                _nStrSql = "EXEC [sp_Professional_IUD] " & _
                "@Action = 'INSERT' " & _
                ",@No = N'" & _mNo & "'" & _
                ",@LotNo = N'" & _mLotNo & "'" & _
                ",@BlkNo = N'" & _mBlkNo & "'" & _
                ",@PhaseZone = N'" & _mPhaseZone & "'" & _
                ",@SubdVillage = N'" & _mSubdVillage & "'" & _
                ",@Region = N'" & _mRegion & "'" & _
                ",@Address1 = N'" & _mAddress1 & "'" & _
                ",@Address2 = N'" & _mAddress2 & "'" & _
                ",@Address3 = N'" & _mAddress3 & "'" & _
                ",@Address4 = N'" & _mAddress4 & "'" & _
                ",@Address5 = N'" & _mAddress5 & "'" & _
                ",@DateEncoded = N'" & _mDateEncoded & "'" & _
                ",@EncoderID = N'" & _mEncoderID & "'" & _
                ",@FName = N'" & _mFName & "'" & _
                ",@IA_POA_Date_Issued = N'" & _mIA_POA_Date_Issued & "'" & _
                ",@IA_POA_No = N'" & _mIA_POA_No & "'" & _
                ",@IA_POA_ORNumber = N'" & _mIA_POA_ORNumber & "'" & _
                ",@IDCode = N'" & _mIDCode & "'" & _
                ",@LName = N'" & _mLName & "'" & _
                ",@MName = N'" & _mMName & "'" & _
                ",@MobileNo = N'" & _mMobileNo & "'" & _
                ",@PCAB_License_No = N'" & _mPCAB_License_No & "'" & _
                ",@PCAB_Validity = N'" & _mPCAB_Validity & "'" & _
                ",@PRC_DateIssued = N'" & _mPRC_DateIssued & "'" & _
                ",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
                ",@PRC_Validity = N'" & _mPRC_Validity & "'" & _
                ",@PRCNo = N'" & _mPRCNo & "'" & _
                ",@Prof_Title = N'" & _mProf_Title & "'" & _
                ",@PTR_Date_Issued = N'" & _mPTR_Date_Issued & "'" & _
                ",@PTR_Place_Issued = N'" & _mPTR_Place_Issued & "'" & _
                ",@PTRNo = N'" & _mPTRNo & "'" & _
                ",@TelNo = N'" & _mTelNo & "'" & _
                ",@TINNo = N'" & _mTINNo & "'" & _
                ",@ZIPCode = N'" & _mZIPCode & "'" & _
                ",@Successful = @Successful output " & _
                ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_Professional_IUD] " & _
                "@Action = 'UPDATE' " & _
                ",@SelectCond = N'" & _nSelectCond & "'" & _
                ",@No = N'" & _mNo & "'" & _
                ",@LotNo = N'" & _mLotNo & "'" & _
                ",@BlkNo = N'" & _mBlkNo & "'" & _
                ",@PhaseZone = N'" & _mPhaseZone & "'" & _
                ",@SubdVillage = N'" & _mSubdVillage & "'" & _
                ",@Region = N'" & _mRegion & "'" & _
                ",@Address1 = N'" & _mAddress1 & "'" & _
                ",@Address2 = N'" & _mAddress2 & "'" & _
                ",@Address3 = N'" & _mAddress3 & "'" & _
                ",@Address4 = N'" & _mAddress4 & "'" & _
                ",@Address5 = N'" & _mAddress5 & "'" & _
                ",@DateEncoded = N'" & _mDateEncoded & "'" & _
                ",@EncoderID = N'" & _mEncoderID & "'" & _
                ",@FName = N'" & _mFName & "'" & _
                ",@IA_POA_Date_Issued = N'" & _mIA_POA_Date_Issued & "'" & _
                ",@IA_POA_No = N'" & _mIA_POA_No & "'" & _
                ",@IA_POA_ORNumber = N'" & _mIA_POA_ORNumber & "'" & _
                ",@LName = N'" & _mLName & "'" & _
                ",@MName = N'" & _mMName & "'" & _
                ",@MobileNo = N'" & _mMobileNo & "'" & _
                ",@PCAB_License_No = N'" & _mPCAB_License_No & "'" & _
                ",@PCAB_Validity = N'" & _mPCAB_Validity & "'" & _
                ",@PRC_DateIssued = N'" & _mPRC_DateIssued & "'" & _
                ",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
                ",@PRC_Validity = N'" & _mPRC_Validity & "'" & _
                ",@PRCNo = N'" & _mPRCNo & "'" & _
                ",@Prof_Title = N'" & _mProf_Title & "'" & _
                ",@PTR_Date_Issued = N'" & _mPTR_Date_Issued & "'" & _
                ",@PTR_Place_Issued = N'" & _mPTR_Place_Issued & "'" & _
                ",@PTRNo = N'" & _mPTRNo & "'" & _
                ",@TelNo = N'" & _mTelNo & "'" & _
                ",@TINNo = N'" & _mTINNo & "'" & _
                ",@ZIPCode = N'" & _mZIPCode & "'" & _
            ",@Successful = @Successful output " & _
            ",@ErrMsg = @ErrMsg output  "
            End If
            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content
            Using _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()
            _mAdd = False
        Catch ex As Exception
            _nSuccessful = False
        End Try
    End Sub
    Public Shared Sub _pHSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            'If _mAdd Then
            _nStrSql = "EXEC [sp_HIST_Professional_IUD] " & _
            "@Action = 'INSERT' " & _
            ",@Address1 = N'" & _mHAddress1 & "'" & _
            ",@Address2 = N'" & _mHAddress2 & "'" & _
            ",@Address3 = N'" & _mHAddress3 & "'" & _
            ",@Address4 = N'" & _mHAddress4 & "'" & _
            ",@Address5 = N'" & _mHAddress5 & "'" & _
            ",@DateEncoded = N'" & _mHDateEncoded & "'" & _
            ",@EncoderID = N'" & _mEncoderID & "'" & _
            ",@FName = N'" & _mHFName & "'" & _
            ",@IA_POA_Date_Issued = N'" & _mHIA_POA_Date_Issued & "'" & _
            ",@IA_POA_No = N'" & _mHIA_POA_No & "'" & _
            ",@IA_POA_ORNumber = N'" & _mHIA_POA_ORNumber & "'" & _
            ",@IDCode = N'" & _mHIDCode & "'" & _
            ",@LName = N'" & _mHLName & "'" & _
            ",@MName = N'" & _mHMName & "'" & _
            ",@MobileNo = N'" & _mHMobileNo & "'" & _
            ",@PCAB_License_No = N'" & _mHPCAB_License_No & "'" & _
            ",@PCAB_Validity = N'" & _mHPCAB_Validity & "'" & _
            ",@PRC_DateIssued = N'" & _mHPRC_DateIssued & "'" & _
            ",@PRC_Place_Issued = N'" & _mHPRC_Place_Issued & "'" & _
            ",@PRC_Validity = N'" & _mHPRC_Validity & "'" & _
            ",@PRCNo = N'" & _mHPRCNo & "'" & _
            ",@Prof_Title = N'" & _mHProf_Title & "'" & _
            ",@PTR_Date_Issued = N'" & _mHPTR_Date_Issued & "'" & _
            ",@PTR_Place_Issued = N'" & _mHPTR_Place_Issued & "'" & _
            ",@PTRNo = N'" & _mHPTRNo & "'" & _
            ",@TelNo = N'" & _mHTelNo & "'" & _
            ",@TINNo = N'" & _mHTINNo & "'" & _
            ",@ZIPCode = N'" & _mHZIPCode & "'" & _
            ",@Successful = @Successful output " & _
            ",@ErrMsg = @ErrMsg output  "

            'Else

            '    _nStrSql = "EXEC [sp_Professional_IUD] " & _
            '    "@Action = 'UPDATE' " & _
            '    ",@SelectCond = N'" & _nSelectCond & "'" & _
            '    ",@Address1 = N'" & _mAddress1 & "'" & _
            '    ",@Address2 = N'" & _mAddress2 & "'" & _
            '    ",@Address3 = N'" & _mAddress3 & "'" & _
            '    ",@Address4 = N'" & _mAddress4 & "'" & _
            '    ",@Address5 = N'" & _mAddress5 & "'" & _
            '    ",@DateEncoded = N'" & _mDateEncoded & "'" & _
            '    ",@EncoderID = N'" & _mEncoderID & "'" & _
            '    ",@FName = N'" & _mFName & "'" & _
            '    ",@IA_POA_Date_Issued = N'" & _mIA_POA_Date_Issued & "'" & _
            '    ",@IA_POA_No = N'" & _mIA_POA_No & "'" & _
            '    ",@IA_POA_ORNumber = N'" & _mIA_POA_ORNumber & "'" & _
            '    ",@LName = N'" & _mLName & "'" & _
            '    ",@MName = N'" & _mMName & "'" & _
            '    ",@MobileNo = N'" & _mMobileNo & "'" & _
            '    ",@PCAB_License_No = N'" & _mPCAB_License_No & "'" & _
            '    ",@PCAB_Validity = N'" & _mPCAB_Validity & "'" & _
            '    ",@PRC_DateIssued = N'" & _mPRC_DateIssued & "'" & _
            '    ",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
            '    ",@PRC_Validity = N'" & _mPRC_Validity & "'" & _
            '    ",@PRCNo = N'" & _mPRCNo & "'" & _
            '    ",@Prof_Title = N'" & _mProf_Title & "'" & _
            '    ",@PTR_Date_Issued = N'" & _mPTR_Date_Issued & "'" & _
            '    ",@PTR_Place_Issued = N'" & _mPTR_Place_Issued & "'" & _
            '    ",@PTRNo = N'" & _mPTRNo & "'" & _
            '    ",@TelNo = N'" & _mTelNo & "'" & _
            '    ",@TINNo = N'" & _mTINNo & "'" & _
            '    ",@ZIPCode = N'" & _mZIPCode & "'" & _
            '",@Successful = @Successful output " & _
            '",@ErrMsg = @ErrMsg output  "
            'End If
            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content
            Using _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()
            _mAdd = False
        Catch ex As Exception
            _nSuccessful = False
        End Try
    End Sub

    Public Shared Sub _pDelete(ByRef _nSuccessful As Boolean, ByVal _nCondition As String, Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "EXEC [sp_Professional_IUD] " & _
                            "@Action = 'DELETE' " & _
                            ",@SelectCond = N'" & _nSelectCond & "'" & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "

            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute the Stored proc
            _mSqlCmd.ExecuteNonQuery()

            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()
            _mAdd = False
        Catch ex As Exception
            _nSuccessful = False
        End Try
    End Sub

    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _mQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select " & _nColumns & " from vw_ProfessionalInfo " & _nCondition

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _mDataTable.Columns.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)


            'If _mDataTable.Rows.Count > 0 Then

            '    If IsDBNull(_mDataTable.Rows(0).Item("IDCode")) Then
            '        _mIDCode = ""
            '    Else
            '        _mIDCode = _mDataTable.Rows(0).Item("IDCode")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("FName")) Then
            '        _mFName = ""
            '    Else
            '        _mFName = _mDataTable.Rows(0).Item("FName")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("MName")) Then
            '        _mMName = ""
            '    Else
            '        _mMName = _mDataTable.Rows(0).Item("MName")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("LName")) Then
            '        _mLName = ""
            '    Else
            '        _mLName = _mDataTable.Rows(0).Item("LName")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("TINno")) Then
            '        _mTINNo = ""
            '    Else
            '        _mTINNo = _mDataTable.Rows(0).Item("TINno")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("Address1")) Then
            '        _mAddress1 = ""
            '    Else
            '        _mAddress1 = _mDataTable.Rows(0).Item("Address1")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("Address2")) Then
            '        _mAddress2 = ""
            '    Else
            '        _mAddress2 = _mDataTable.Rows(0).Item("Address2")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("Address3")) Then
            '        _mAddress3 = ""
            '    Else
            '        _mAddress3 = _mDataTable.Rows(0).Item("Address3")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("Address4")) Then
            '        _mAddress4 = ""
            '    Else
            '        _mAddress4 = _mDataTable.Rows(0).Item("Address4")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("Address5")) Then
            '        _mAddress5 = ""
            '    Else
            '        _mAddress5 = _mDataTable.Rows(0).Item("Address5")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("Address")) Then
            '        _mAddress = ""
            '    Else
            '        _mAddress = _mDataTable.Rows(0).Item("Address")
            '    End If
            '    If IsDBNull(_mDataTable.Rows(0).Item("FullName")) Then
            '        _mFullName = ""
            '    Else
            '        _mFullName = _mDataTable.Rows(0).Item("FullName")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("TelNo")) Then
            '        _mTelNo = ""
            '    Else
            '        _mTelNo = _mDataTable.Rows(0).Item("TelNo")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("IAPOA_Date_Iss")) Then
            '        _mIA_POA_Date_Issued = ""
            '    Else
            '        _mIA_POA_Date_Issued = _mDataTable.Rows(0).Item("IAPOA_Date_Iss")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("IAPOANo")) Then
            '        _mIA_POA_No = ""
            '    Else
            '        _mIA_POA_No = _mDataTable.Rows(0).Item("IAPOANo")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("IAPO_ORNo")) Then
            '        _mIA_POA_ORNumber = ""
            '    Else
            '        _mIA_POA_ORNumber = _mDataTable.Rows(0).Item("IAPO_ORNo")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("PCABLicNo")) Then
            '        _mPCAB_License_No = ""
            '    Else
            '        _mPCAB_License_No = _mDataTable.Rows(0).Item("PCABLicNo")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("PCAB_Validity")) Then
            '        _mPCAB_Validity = ""
            '    Else
            '        _mPCAB_Validity = _mDataTable.Rows(0).Item("PCAB_Validity")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("PRC_Date_Iss")) Then
            '        _mPRC_DateIssued = ""
            '    Else
            '        _mPRC_DateIssued = _mDataTable.Rows(0).Item("PRC_Date_Iss")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("PRC_Place_Issued")) Then
            '        _mPRC_Place_Issued = ""
            '    Else
            '        _mPRC_Place_Issued = _mDataTable.Rows(0).Item("PRC_Place_Issued")
            '    End If

            '    'If IsDBNull(_mDataTable.Rows(0).Item("PRC_Validity")) Then
            '    '    _mPRC_Validity = ""
            '    'Else
            '    '    _mPRC_Validity = _mDataTable.Rows(0).Item("PRC_Validity")
            '    'End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("PRCNo")) Then
            '        _mPRCNo = ""
            '    Else
            '        _mPRCNo = _mDataTable.Rows(0).Item("PRCNo")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("Prof_Title")) Then
            '        _mProf_Title = ""
            '    Else
            '        _mProf_Title = _mDataTable.Rows(0).Item("Prof_Title")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("PTR_Date_Iss")) Then
            '        _mPTR_Date_Issued = ""
            '    Else
            '        _mPTR_Date_Issued = _mDataTable.Rows(0).Item("PTR_Date_Iss")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("PTR_Plc_Iss")) Then
            '        _mPTR_Place_Issued = ""
            '    Else
            '        _mPTR_Place_Issued = _mDataTable.Rows(0).Item("PTR_Plc_Iss")
            '    End If

            '    If IsDBNull(_mDataTable.Rows(0).Item("PTRNo")) Then
            '        _mPTRNo = ""
            '    Else
            '        _mPTRNo = _mDataTable.Rows(0).Item("PTRNo")
            '    End If
            'End If




            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region


End Class
