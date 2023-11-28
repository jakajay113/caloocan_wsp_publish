#Region "Imports"
Imports System.Data.SqlClient
#End Region

Public Class CDalApplicationMaster_IUD

#Region "Public Variable"

    ''------------------------------------------------------------Used in Multiple Permit Application Form
    Public Shared _mFirstMultiselectFrm As Boolean = False

    'Public Shared _pScopeofWork As DataGridView = Nothing
    'Public Shared _pCharOccupancy As DataGridView = Nothing
    'Public Shared _pUseTypeOccupancy As DataGridView = Nothing
    'Public Shared _pPermitFixtures As DataGridView = Nothing
    'Public Shared _pConfromance As DataGridView = Nothing
    'Public Shared _pNature As DataGridView = Nothing
    'Public Shared _pInstalled As DataGridView = Nothing
    'Public Shared _pReqDoc As DataGridView = Nothing
    'Public Shared _pFencingType As DataGridView = Nothing
    'Public Shared _pFixtureIstalled As DataGridView = Nothing
    'Public Shared _pWaterSupply As DataGridView = Nothing
    'Public Shared _pSysDisposal As DataGridView = Nothing
    'Public Shared _pDrainageSys As DataGridView = Nothing
    'Public Shared _pAccessory As DataGridView = Nothing
    'Public Shared _pFixtures As DataGridView = Nothing
    'Public Shared _pWiringType As DataGridView = Nothing
    ''---------------------------------------------------ComboBox
    Public Shared _pGetSelectedApplTypeIndex As Integer = 0
    Public Shared _pGetSelectedOwnershipTypeIndex As Integer = 0
    Public Shared _pGetSelectedUseCharOccupancyIndex As Integer = 0
    Public Shared _pGetSelectedUseTypeOccupancyIndex As Integer = 0
    Public Shared _pGetSelectedDivIndex As Integer = 0
    Public Shared _pGetSelectedOccuClassIndex As Integer = 0
    Public Shared _pGetSelectedDisplayIndex As Integer = 0
    Public Shared _pGetSelectedSignBoardCatIndex As Integer = 0

    Public Shared _pHasWaterSupply As Boolean = False
    Public Shared _pHasSysDisposal As Boolean = False
    Public Shared _pHasDrainageSys As Boolean = False
    Public Shared _pHasBldgPermitChecklist As Boolean = False
    ''-----------------------------------------------------------------
#End Region

#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String
    Private Shared _mQuery As String = Nothing

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
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property

#End Region

#Region "Variable Field"

    Private Shared _mAdd As Boolean
    Private Shared _mForYear As String
    Private Shared _mAppDate As String
    Private Shared _mAppDateSigned As String
    Private Shared _mAppNo As String
    Private Shared _mSubAppNo As String
    Private Shared _mAreaNo As String
    Private Shared _mBldg_ConsentDate As String
    Private Shared _mBldg_IDCode As String
    Private Shared _mBldg_PermitNo As String
    Private Shared _mBlkNo As String
    Private Shared _mBrgyCode As String
    Private Shared _mProvCode As String
    Private Shared _mMuniCode As String
    Private Shared _mCellNo As String
    Private Shared _mEMS_AcctNo As String
    Private Shared _mEMS_SubAcctNo As String
    Private Shared _mFName As String
    Private Shared _mIDCode As String
    Private Shared _mInspSup_Code As String
    Private Shared _mLName As String
    Private Shared _mLot_ConsentDate As String
    Private Shared _mLot_IDCode As String
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
    Private Shared _mSW_Billing As Boolean
    Private Shared _mSW_Scope As String
    Private Shared _mSW_UseCode As String
    Private Shared _mTCTNo As String
    Private Shared _mTDN As String
    Private Shared _mTellNo As String
    Private Shared _mTIN As String
    Private Shared _mZipCode As String
    Private Shared _mRegCode As String

    Private Shared _mCheckbox As Boolean


#End Region
#Region "Property Field"

    Public Shared Property _pAppDate() As String
        Get
            Return _mAppDate
        End Get
        Set(value As String)
            _mAppDate = value
        End Set
    End Property

    Public Shared Property _pCheckbox() As Boolean
        Get
            Return _mCheckbox
        End Get
        Set(value As Boolean)
            _mCheckbox = value
        End Set
    End Property

    Public Shared Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(value As String)
            _mForYear = value
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
    Public Shared Property _pProvCode() As String
        Get
            Return _mProvCode
        End Get
        Set(value As String)
            _mProvCode = value
        End Set
    End Property

    Public Shared Property _pMuniCode() As String
        Get
            Return _mMuniCode
        End Get
        Set(value As String)
            _mMuniCode = value
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
    Public Shared Property _pSubAppNo() As String
        Get
            Return _mSubAppNo
        End Get
        Set(value As String)
            _mSubAppNo = value
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

    Public Shared Property _pBldg_ConsentDate() As String
        Get
            Return _mBldg_ConsentDate
        End Get
        Set(value As String)
            _mBldg_ConsentDate = value
        End Set
    End Property

    Public Shared Property _pBldg_IDCode() As String
        Get
            Return _mBldg_IDCode
        End Get
        Set(value As String)
            _mBldg_IDCode = value
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

    Public Shared Property _pLot_IDCode() As String
        Get
            Return _mLot_IDCode
        End Get
        Set(value As String)
            _mLot_IDCode = value
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

    Public Shared Property _pSW_Billing() As Boolean
        Get
            Return _mSW_Billing
        End Get
        Set(value As Boolean)
            _mSW_Billing = value
        End Set
    End Property

    Public Shared Property _pSW_Scope() As String
        Get
            Return _mSW_Scope
        End Get
        Set(value As String)
            _mSW_Scope = value
        End Set
    End Property

    Public Shared Property _pSW_UseCode() As String
        Get
            Return _mSW_UseCode
        End Get
        Set(value As String)
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

    Public Shared Sub _pLoad(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)

        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            If _nCondition = "" Then
                _nCondition = " WHERE AppNo not like '%VIO-%' and AppNo not like '%CERT-%'"
            Else
                _nCondition += " AND AppNo not like '%VIO-%' and AppNo not like '%CERT-%'"
            End If
            '----------------------------------    
            _nQuery = "Select * from vw_ApplicationMaster " & _nCondition

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)
            _nRecCount = _mDataTable.Rows.Count
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)

        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select * from ApplicationMaster " & _nCondition

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)
            _nRecCount = _mDataTable.Rows.Count
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL

            _mNoOfStorey = IIf(_mNoOfStorey = "", 0, _mNoOfStorey)
            _mNoOfUnits = IIf(_mNoOfUnits = "", 0, _mNoOfUnits)
            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                _nStrSql = "EXEC [sp_ApplicationMaster_IUD] " & _
                            "@Action = 'INSERT' " & _
                            ",@AppDate = N'" & _mAppDate & "'" & _
                            ",@AppDateSigned = N'" & _mAppDateSigned & "'" & _
                            ",@AppNo = N'" & _mAppNo & "'" & _
                            ",@AreaNo = N'" & _mAreaNo & "'" & _
                            ",@Bldg_IDCode = N'" & _mBldg_IDCode & "'" & _
                            ",@Bldg_ConsentDate = N'" & _mBldg_ConsentDate & "'" & _
                            ",@Bldg_PermitNo = N'" & _mBldg_PermitNo & "'" & _
                            ",@BlkNo = N'" & _mBlkNo & "'" & _
                            ",@BrgyCode = N'" & _mBrgyCode & "'" & _
                            ",@CellNo = N'" & _mCellNo & "'" & _
                            ",@EMS_AcctNo = N'" & _mEMS_AcctNo & "'" & _
                            ",@EMS_SubAcctNo = N'" & _mEMS_SubAcctNo & "'" & _
                            ",@FName = N'" & _mFName & "'" & _
                            ",@IDCode = N'" & _mIDCode & "'" & _
                            ",@InspSup_Code = N'" & _mInspSup_Code & "'" & _
                            ",@LName = N'" & _mLName & "'" & _
                            ",@Lot_ConsentDate = N'" & _mLot_ConsentDate & "'" & _
                            ",@Lot_IDCode = N'" & _mLot_IDCode & "'" & _
                            ",@LotNo = N'" & _mLotNo & "'" & _
                            ",@MName = N'" & _mMName & "'" & _
                            ",@MuniCityCode = N'" & _mMuniCityCode & "'" & _
                            ",@NoOfStorey = N'" & _mNoOfStorey & "'" & _
                            ",@NoOfUnits = N'" & _mNoOfUnits & "'" & _
                            ",@OAPCode = N'" & _mOAPCode & "'" & _
                            ",@OwnCode = N'" & _mOwnCode & "'" & _
                            ",@Owner_Address = N'" & _mOwner_Address & "'" & _
                            ",@PermitType = N'" & _mPermitType & "'" & _
                            ",@PIN = N'" & _mPIN & "'" & _
                            ",@StrtCode = N'" & _mStrtCode & "'" & _
                            ",@SW_Approved = N'" & _mSW_Approved & "'" & _
                            ",@SW_Assess = N'" & _mSW_Assess & "'" & _
                            ",@SW_Compl = N'" & _mSW_Compl & "'" & _
                            ",@SW_Scope = N'" & _mSW_Scope & "'" & _
                            ",@SW_UseCode = N'" & _mSW_UseCode & "'" & _
                            ",@SW_Paid = N'" & _mSW_Paid & "'" & _
                            ",@SW_Billing = N'" & _mSW_Billing & "'" & _
                            ",@TCTNo = N'" & _mTCTNo & "'" & _
                            ",@TDN = N'" & _mTDN & "'" & _
                            ",@TellNo = N'" & _mTellNo & "'" & _
                            ",@TIN = N'" & _mTIN & "'" & _
                            ",@ZipCode = N'" & _mZipCode & "'" & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_ApplicationMaster_IUD] " & _
                            "@Action = 'UPDATE' " & _
                            ",@SelectCond = N'" & _nSelectCond & "'" & _
                            ",@AppDate = N'" & _mAppDate & "'" & _
                            ",@AppDateSigned = N'" & _mAppDateSigned & "'" & _
                            ",@AppNo = N'" & _mAppNo & "'" & _
                            ",@AreaNo = N'" & _mAreaNo & "'" & _
                            ",@Bldg_IDCode = N'" & _mBldg_IDCode & "'" & _
                            ",@Bldg_ConsentDate = N'" & _mBldg_ConsentDate & "'" & _
                            ",@Bldg_PermitNo = N'" & _mBldg_PermitNo & "'" & _
                            ",@BlkNo = N'" & _mBlkNo & "'" & _
                            ",@BrgyCode = N'" & _mBrgyCode & "'" & _
                            ",@CellNo = N'" & _mCellNo & "'" & _
                            ",@EMS_AcctNo = N'" & _mEMS_AcctNo & "'" & _
                            ",@EMS_SubAcctNo = N'" & _mEMS_SubAcctNo & "'" & _
                            ",@FName = N'" & _mFName & "'" & _
                            ",@IDCode = N'" & _mIDCode & "'" & _
                            ",@InspSup_Code = N'" & _mInspSup_Code & "'" & _
                            ",@LName = N'" & _mLName & "'" & _
                            ",@Lot_ConsentDate = N'" & _mLot_ConsentDate & "'" & _
                            ",@Lot_IDCode = N'" & _mLot_IDCode & "'" & _
                            ",@LotNo = N'" & _mLotNo & "'" & _
                            ",@MName = N'" & _mMName & "'" & _
                            ",@MuniCityCode = N'" & _mMuniCityCode & "'" & _
                            ",@NoOfStorey = N'" & _mNoOfStorey & "'" & _
                            ",@NoOfUnits = N'" & _mNoOfUnits & "'" & _
                            ",@OAPCode = N'" & _mOAPCode & "'" & _
                            ",@OwnCode = N'" & _mOwnCode & "'" & _
                            ",@Owner_Address = N'" & _mOwner_Address & "'" & _
                            ",@PermitType = N'" & _mPermitType & "'" & _
                            ",@PIN = N'" & _mPIN & "'" & _
                            ",@StrtCode = N'" & _mStrtCode & "'" & _
                            ",@SW_Approved = N'" & _mSW_Approved & "'" & _
                            ",@SW_Assess = N'" & _mSW_Assess & "'" & _
                            ",@SW_Compl = N'" & _mSW_Compl & "'" & _
                            ",@SW_Scope = N'" & _mSW_Scope & "'" & _
                            ",@SW_UseCode = N'" & _mSW_UseCode & "'" & _
                            ",@SW_Paid = N'" & _mSW_Paid & "'" & _
                            ",@SW_Billing = N'" & _mSW_Billing & "'" & _
                            ",@TCTNo = N'" & _mTCTNo & "'" & _
                            ",@TDN = N'" & _mTDN & "'" & _
                            ",@TellNo = N'" & _mTellNo & "'" & _
                            ",@TIN = N'" & _mTIN & "'" & _
                            ",@ZipCode = N'" & _mZipCode & "'" & _
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
                        '_mCode = _nSqlDr.Item(0).ToString
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
            _nStrSql = "EXEC [sp_ApplicationMaster_IUD] " & _
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

#End Region

    '    Public Shared Sub _pSubMultipleApplicationFrm(
    'ByVal _nToolStrip As ToolStripMenuItem, ByVal _nDt As DataTable) ''--------------------------Added 20200114 MCE / UPDATE 20200117 MCE
    '        'Dim _nTsButton As ToolStripMenuItem = Nothing
    '        Dim _nRecCnt As Integer = 0
    '        Dim _nCount As Integer = 0
    '        Dim _nPermitDesc As String = ""
    '        _mPermitType = ""
    '        Try
    '            '---------- ---------- ---------- ----------


    '            For _nDtCnt As Integer = 0 To _nDt.Rows.Count - 1


    '_nNewPermit:

    '                If CDalMain._pOpenFrm = False Then Exit Sub

    '                If _nCount = (_nToolStrip.DropDown.Items.Count) Then _nCount = 0

    '                If _nDt.Rows(_nDtCnt).Item(0) = True Then

    '                    If (_nDt.Rows(_nDtCnt).Item("PermitType").ToString <> _nToolStrip.DropDown.Items(_nCount).Tag) Then _nCount += 1 : GoTo _nNewPermit

    '                    _mPermitType = _nDt.Rows(_nDtCnt).Item("PermitType").ToString
    '                    _nPermitDesc = LCase(_nDt.Rows(_nDtCnt).Item("Description").ToString)


    '                    Dim s As String = _nPermitDesc
    '                    Dim ProperConsName As String = StrConv(s, VbStrConv.ProperCase)


    '                    If CDalApplicationMaster_IUD._mFirstMultiselectFrm = True Then
    '                        MsgBox("This will be proceed to " & "Application Form of " & ProperConsName & "...", vbOKOnly, "Information")
    '                        _nToolStrip.DropDown.Items(_nCount).PerformClick()

    '                    Else

    '                        _nToolStrip.DropDown.Items(_nCount).PerformClick()
    '                        CDalApplicationMaster_IUD._mFirstMultiselectFrm = True
    '                    End If

    '                End If
    '                _nCount += 1
    '                _nRecCnt += 1

    '            Next
    '            If CDalMain._pOpenFrm = False Then Exit Sub
    '            If (_nDt.Rows.Count) = _nRecCnt Then
    '                MsgBox("Applications Saved!", vbOKOnly, "Information")
    '            End If



    '        Catch ex As Exception

    '        End Try
    '    End Sub

    Public Shared Function _mCheckCompliance()
        _mCheckCompliance = False
        Dim _nQtySubmitted As Integer = 0
        Dim _nNonQtySubmitted As Integer = 0
        Dim _nCompliantCnt As Integer = 0
        Dim _nCompleteCnt As Integer = 0
        Dim _nNonCompliant As Integer = 0
        Dim _nRecCnt As Integer = 0
        '_nRecCnt = CDalReqDocExtn_IUD._pDataTable.Rows.Count
        ''  Dim _DatagridviewRow As New DataGridViewRow
        Try

            Dim _nSqlCmd As New SqlCommand("Select isnull(Compliant,0) Compliant, isnull(Qty_Submitted,0) Qty_Submitted from vw_SubmReqmt Where AppNo='" & CDalApplicationMaster_IUD._pAppNo & "'", _mSqlCon)
            Dim _nSqlRdr As SqlDataReader = _nSqlCmd.ExecuteReader

            If _nSqlRdr.HasRows Then


                While _nSqlRdr.Read
                    If _nSqlRdr.Item("Compliant") <> 0 Then
                        If _nSqlRdr.Item("Compliant") = 1 And _nSqlRdr.Item("Qty_Submitted") <> 0 Then
                            _mCheckCompliance = True
                        Else
                            _nSqlCmd.Dispose()
                            _nSqlRdr.Dispose()
                            Return False
                        End If
                    ElseIf _nSqlRdr.Item("Compliant") = 0 And _nSqlRdr.Item("Qty_Submitted") <> 0 Then
                        _nSqlCmd.Dispose()
                        _nSqlRdr.Dispose()
                        Return True
                    Else
                        _mCheckCompliance = False
                    End If
                End While



            End If

            _nSqlCmd.Dispose()
            _nSqlRdr.Dispose()

            Return _mCheckCompliance
        Catch ex As Exception

        End Try
    End Function

    Public Shared Function _mCheckAssessApproved(ByVal _nAppno As String)
        _mCheckAssessApproved = False

        Dim _nSqlCmd As New SqlCommand("Select SW_Approved from ApplicationMaster Where Appno='" & _nAppno & "'", _mSqlCon)
        Dim _nSqlRd As SqlDataReader = _nSqlCmd.ExecuteReader
        If _nSqlRd.HasRows Then
            _nSqlRd.Read()
            _mCheckAssessApproved = _nSqlRd.Item("SW_Approved")
        End If
        _nSqlCmd.Dispose()
        _nSqlRd.Dispose()

    End Function
    Public Shared Sub _mSaveCheckAssessmentApproved(ByVal _nSW_Approved As Boolean, ByVal _nAppNo As String)
        Try
            Dim _nSqlCmd As SqlCommand = New SqlCommand("Update ApplicationMaster Set SW_Approved=" & _
                          IIf(_nSW_Approved, 1, 0) & " Where AppNo='" & _nAppNo & "'", _mSqlCon)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class
