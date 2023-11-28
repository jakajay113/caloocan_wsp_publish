#Region "Imports"

Imports System.Data.SqlClient

#End Region


Public Class cDalApplicant

#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String
    Private Shared _mQuery As String = Nothing
    Public Shared _nSelected As Boolean
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
    'Public ReadOnly Property _pQuery() As String
    '    Get
    '        Return _mQuery
    '    End Get
    'End Property

#End Region

#Region "Other Variables"
    ''-----------------------------------------------Added 20190430 MCE
    Private Shared _mIFSelect As Boolean
    Private Shared _mBolTrapName As Boolean
    Private Shared _mStrTrapName As String
    Private Shared _mGetFullName As String
    Private Shared _mColumns As String
    Private Shared _mFormName As String
    Private Shared _mTableName As String
    Private Shared _mTrapName As String
    Private Shared _mCondWhere As String
    Private Shared _mFnGetTriggerName As String
#End Region

#Region "Variables"

    Private Shared _mIDCode As String
    Private Shared _mFName As String
    Private Shared _mMName As String
    Private Shared _mLName As String
    Private Shared _mTIN As String
    Private Shared _mAddress1 As String
    Private Shared _mAddress2 As String
    Private Shared _mAddress3 As String
    Private Shared _mAddress4 As String
    Private Shared _mAddress5 As String
    Private Shared _mTellNo As String
    Private Shared _mApplCode As String
    Private Shared _mCTCNo As String
    Private Shared _mCTC_ISS_Date As String
    Private Shared _mCTC_Plc_ISS As String
    Private Shared _mAddress As String
    Private Shared _mFullName As String
    Private Shared _mLastUpdate As String
    Private Shared _mencoderID As String

#End Region

#Region "public Shared Property"

    Public Shared Property _pQuery() As String
        Get
            Return _mQuery
        End Get
        Set(value As String)
            _mQuery = value
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

    Public Shared Property _pFName() As String
        Get
            Return _mFName
        End Get
        Set(value As String)
            _mFName = value
        End Set
    End Property

    Public Shared Property _pMName As String
        Get
            Return _mMName
        End Get
        Set(value As String)
            _mMName = value
        End Set
    End Property
    Public Shared Property _pLName As String
        Get
            Return _mLName
        End Get
        Set(value As String)
            _mLName = value
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
    Public Shared Property _pTellNo As String
        Get
            Return _mTellNo
        End Get
        Set(value As String)
            _mTellNo = value
        End Set
    End Property
    Public Shared Property _pApplCode As String
        Get
            Return _mApplCode
        End Get
        Set(value As String)
            _mApplCode = value
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
    Public Shared Property _pAddress As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
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

    Public Shared Property _pencoderID() As String
        Get
            Return _mencoderID
        End Get
        Set(value As String)
            _mencoderID = value
        End Set
    End Property

    Public Shared Property _pLastUpdate() As String
        Get
            Return _mLastUpdate
        End Get
        Set(value As String)
            _mLastUpdate = value
        End Set
    End Property
#End Region

#Region "Other Property"
    Public Shared Property _pBolTrapName() As Boolean
        Get
            Return _mBolTrapName
        End Get
        Set(value As Boolean)
            _mBolTrapName = value
        End Set
    End Property

    Public Shared Property _pStrTrapName() As String
        Get
            Return _mStrTrapName
        End Get
        Set(value As String)
            _mStrTrapName = value
        End Set
    End Property


    Public Shared Property _pGetFullName() As String
        Get
            Return _mGetFullName
        End Get
        Set(value As String)
            _mGetFullName = value
        End Set
    End Property

    Public Shared Property _pColumns() As String
        Get
            Return _mColumns
        End Get
        Set(value As String)
            _mColumns = value
        End Set
    End Property

    Public Shared Property _pFormName() As String
        Get
            Return _mFormName
        End Get
        Set(value As String)
            _mFormName = value
        End Set
    End Property


    Public Shared Property _pTableName() As String
        Get
            Return _mTableName
        End Get
        Set(value As String)
            _mTableName = value
        End Set
    End Property


    Public Shared Property _pIFSelect() As Boolean
        Get
            Return _mIFSelect
        End Get
        Set(value As Boolean)
            _mIFSelect = value
        End Set
    End Property


    Public Shared Property _pTrapName() As String
        Get
            Return _mTrapName
        End Get
        Set(value As String)
            _mTrapName = value
        End Set
    End Property


    Public Shared Property _pFnGetTriggerName() As String
        Get
            Return _mFnGetTriggerName
        End Get
        Set(value As String)
            _mFnGetTriggerName = value
        End Set
    End Property

    Public Shared Property _pCondWhere() As String
        Get
            Return _mCondWhere
        End Get
        Set(value As String)
            _mCondWhere = value
        End Set
    End Property

    ''
#End Region


#Region "Routine"


    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCond As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            Dim _nCondition As String
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            If _nSelected = False Then
                _nCondition = "Where " & _nColumns & " = '" & _nCond & "'"
                If _nCond = Nothing Then _nCondition = ""
            Else
                _nCondition = _nCond
            End If
            
            '----------------------------------    
            _nQuery = "Select * from vw_ApplicantInfo " & _nCondition

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
            _mSqlCmd.Dispose()
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function _FnGenerateSubAcctNo(ByVal _nEMS_AcctNo As String) As String
        _FnGenerateSubAcctNo = Nothing
        Try
            Dim _nErrMsg As String = ""
            'Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            '_nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "SELECT TOP(1) EMS_SubAcctNo FROM ApplicationMaster " & _
                         "WHERE EMS_AcctNo = '" & _nEMS_AcctNo & "' " & _
                        "ORDER BY EMS_SubAcctNo DESC "

            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)
            'set paramater Success
            '_mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            '_mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCmd.Parameters.Add("@output", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@output").Direction = ParameterDirection.Output

            'Execute and Read the content
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nStrSql, _mSqlCon) '_gDBCon
            _mDataTable.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nSub_AcctNo As Integer = 0

            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nSub_AcctNo = _nSqlDr.Item("EMS_SubAcctNo").ToString
                        Format(Val(Right(_nSub_AcctNo, 4) + 1), "0000")
                        _FnGenerateSubAcctNo = _nSqlDr.Item("EMS_AcctNo").ToString + "-" + _nSub_AcctNo
                    Loop
                Else
                    _nSub_AcctNo = 1
                    Format(_nSub_AcctNo, "0000")
                    _FnGenerateSubAcctNo = _nEMS_AcctNo + "-" + _nSub_AcctNo.ToString

                End If

            End Using

            'Get values of parameter output
            '_nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            '_nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value
            _mSqlCmd.Dispose()
        Catch ex As Exception

        End Try
    End Function

    Public Shared Function _FnGetEngProfIDNo(ByVal _nFullName As String) As String
        _FnGetEngProfIDNo = Nothing
        Try
            Dim _nErrMsg As String = ""
            'Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            '_nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "SELECT IDNo FROM vw_Applicant_ApplicantExtn " & _
                         "WHERE FullName = '" & _nFullName & "'"

            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)
            'set paramater Success
            '_mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            '_mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCmd.Parameters.Add("@output", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@output").Direction = ParameterDirection.Output

            'Execute and Read the content
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nStrSql, _mSqlCon) '_gDBCon
            _mDataTable.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        ' _mGenID = _nSqlDr.Item("Result").ToString
                        _FnGetEngProfIDNo = _nSqlDr.Item("IDNumber").ToString
                    Loop
                End If
            End Using

            'Get values of parameter output
            '_nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            '_nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value
            _mSqlCmd.Dispose()

        Catch ex As Exception
            _FnGetEngProfIDNo = Nothing
            '_nSuccessful = False
        End Try
        Return _FnGetEngProfIDNo
    End Function

    Public Shared Sub _pSubSelectApplicant(ByVal _nBool As Boolean, Optional _nCondition As String = Nothing) '------------Data bind only barangay combobox 20190218
        Dim _mStrSql As String = ""
        Try
            Select Case _nBool
                Case True

                    _mStrSql = "Select LName, FName, MName, Address1, Address2, Address3, Address4, Address5, TIN, IDCode from Applicant " & _nCondition

                Case False
                    _mStrSql = "Select bc.Code, bc.Description as BrgyDesc ,  " & _
    "(Select  RC.Description  from RegnCode RC Where rc.Code = bc.RegnCode) as RegionDesc," & _
      " (Select PC.Description  from ProvCode PC Where Pc.Code = bc.ProvCode) as ProvDesc, " & _
      "	(Select MC.Description  from MuniCode MC Where Mc.Code = bc.MuniCode) as MuniDesc, " & _
      "	(Select DC.Description  from DistCode DC Where DC.Code = bc.DistCode) as DistDesc " & _
    " from BrgyCode BC " & _nCondition

            End Select

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mStrSql, _mSqlCon) '_gDBCon
            _mDataTable.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)

            _nSqlDataAdapter.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub _pLoad(ByRef _nSuccessful As Boolean, ByVal _nCondition As String)
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "EXEC [sp_Applicant_IUD] " & _
                            "@Action = 'SELECT' " & _
                            ",@SelectCond = N'" & _nSelectCond & "' " & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "


            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)
            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _mAddress1 = _nSqlDr.Item("Address1").ToString
                        _mAddress2 = _nSqlDr.Item("Address2").ToString
                        _mAddress3 = _nSqlDr.Item("Address3").ToString
                        _mAddress4 = _nSqlDr.Item("Address4").ToString
                        _mAddress5 = _nSqlDr.Item("Address5").ToString
                        _mApplCode = _nSqlDr.Item("ApplCode").ToString
                        _mencoderID = _nSqlDr.Item("encoderID").ToString
                        _mFName = _nSqlDr.Item("FName").ToString
                        _mIDCode = _nSqlDr.Item("IDCode").ToString
                        _mLastUpdate = _nSqlDr.Item("LastUpdate").ToString
                        _mLName = _nSqlDr.Item("LName").ToString
                        _mMName = _nSqlDr.Item("MName").ToString
                        _mTellNo = _nSqlDr.Item("TellNo").ToString
                        _mTIN = _nSqlDr.Item("TIN").ToString
                    Loop
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

#End Region



End Class
