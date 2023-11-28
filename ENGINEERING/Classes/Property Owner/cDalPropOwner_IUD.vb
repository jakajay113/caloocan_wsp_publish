Imports System.Data.SqlClient

Public Class cDalPropOwner_IUD

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
    Private Shared _mIDCode As String
    Private Shared _mLName As String
    Private Shared _mMName As String
    Private Shared _mProp_SW As String
    Private Shared _mPropKind As String
    Private Shared _mTDN As String
    Private Shared _mPIN As String
    Private Shared _mCTCNo As String
    Private Shared _mCTC_ISS_Date As String
    Private Shared _mCTC_Plc_ISS As String
    Private Shared _mAddress As String
    Private Shared _mFullName As String
    Private Shared _mZIPCode As String
    Private Shared _mTIN As String
    Private Shared _mTelNo As String

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

    Public Shared Property _pProp_SW() As String
        Get
            Return _mProp_SW
        End Get
        Set(value As String)
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

    Public Shared Property _pTIN() As String
        Get
            Return _mTIN
        End Get
        Set(value As String)
            _mTIN = value
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

    Public Shared Property _pPIN() As String
        Get
            Return _mPIN
        End Get
        Set(value As String)
            _mPIN = value
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

    Public Shared Property _pAddress() As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
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
    Public Shared Property _pZIPCode() As String
        Get
            Return _mZIPCode
        End Get
        Set(value As String)
            _mZIPCode = value
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

    Public Shared Sub _Hist_Save(IDCode As String)
        Try
            Dim _nStrSql As String
            _nStrSql = "insert into hist_propowner select * from propowner where idcode = '" & IDCode & "'"
            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)
            _mSqlCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

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
                _nStrSql = "EXEC [sp_PropOwner_IUD] " & _
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
                            ",@IDCode = N'" & _mIDCode & "'" & _
                            ",@LName = N'" & _mLName & "'" & _
                            ",@MName = N'" & _mMName & "'" & _
                            ",@Prop_SW = N'" & _mProp_SW & "'" & _
                            ",@ZIPCode = N'" & _mZIPCode & "'" & _
                            ",@TIN = N'" & _mTIN & "'" & _
                            ",@TelNo = N'" & _mTelNo & "'" & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_PropOwner_IUD] " & _
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
                            ",@IDCode = N'" & _mIDCode & "'" & _
                            ",@LName = N'" & _mLName & "'" & _
                            ",@MName = N'" & _mMName & "'" & _
                            ",@Prop_SW = N'" & _mProp_SW & "'" & _
                            ",@ZIPCode = N'" & _mZIPCode & "'" & _
                            ",@TIN = N'" & _mTIN & "'" & _
                            ",@TelNo = N'" & _mTelNo & "'" & _
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
            _nStrSql = "EXEC [sp_PropOwner_IUD] " & _
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


    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0) 'Modified 04/30/2019-Villena
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select " & _nColumns & " from [vw_PropertyOwnerInfo]" & _nCondition

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)
            _mSqlCmd.Dispose()
            _nSqlDataAdapter.Dispose()

            '----------------------------------
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
            _nStrSql = "EXEC [sp_PropOwner_IUD] " & _
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
                        _mProp_SW = _nSqlDr.Item("Prop_SW").ToString
                        _mencoderID = _nSqlDr.Item("encoderID").ToString
                        _mFName = _nSqlDr.Item("FName").ToString
                        _mIDCode = _nSqlDr.Item("IDCode").ToString
                        _mDateEncoded = _nSqlDr.Item("DateEncoded").ToString
                        _mLName = _nSqlDr.Item("LName").ToString
                        _mMName = _nSqlDr.Item("MName").ToString
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
