Imports System.Data.SqlClient

Public Class cDalApplicant_IUD

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
    Private Shared _mApplCode As String
    Private Shared _mencoderID As String
    Private Shared _mFName As String
    Private Shared _mIDCode As String
    Private Shared _mLastUpdate As String
    Private Shared _mLName As String
    Private Shared _mMName As String
    Private Shared _mTIN As String
    Private Shared _mTellNo As String
    Private Shared _mCTCNo As String
    Private Shared _mCTC_ISS_Date As String
    Private Shared _mCTC_Plc_ISS As String
    Private Shared _mAddress As String
    Private Shared _mFullName As String
    Private Shared _mZIPCode As String

    Private Shared _mHLName As String '-------------- archie20200120--------- H as history
    Private Shared _mHFName As String
    Private Shared _mHMName As String
    Private Shared _mHTIN As String
    Private Shared _mHStrtNo As String
    Private Shared _mHSubdVill As String
    Private Shared _mHBarangayAddress As String
    Private Shared _mHCityMunicipality As String
    Private Shared _mHProvince As String
    Private Shared _mHZipcode As String
    Private Shared _mHTellNo As String
    Private Shared _mHApplicantNo As String
    Private Shared _mHPlaceIssued As String
    Private Shared _mHDateIssued As String
    Private Shared _mHIDCode As String
    Private Shared _mHEncoderID As String

    Private Shared _mQuery As String = ""
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

    Public Shared Property _pHEncoderID() As String
        Get
            Return _mHEncoderID
        End Get
        Set(value As String)
            _mHEncoderID = value
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
    Public Shared Property _pHFName() As String
        Get
            Return _mHFName
        End Get
        Set(value As String)
            _mHFName = value
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
    Public Shared Property _pHTIN() As String
        Get
            Return _mHTIN
        End Get
        Set(value As String)
            _mHTIN = value
        End Set
    End Property
    Public Shared Property _pHStrtNo() As String
        Get
            Return _mHStrtNo
        End Get
        Set(value As String)
            _mHStrtNo = value
        End Set
    End Property
    Public Shared Property _pHSubdVill() As String
        Get
            Return _mHSubdVill
        End Get
        Set(value As String)
            _mHSubdVill = value
        End Set
    End Property
    Public Shared Property _pHBarangayAddress() As String
        Get
            Return _mHBarangayAddress
        End Get
        Set(value As String)
            _mHBarangayAddress = value
        End Set
    End Property
    Public Shared Property _pHCityMunicipality() As String
        Get
            Return _mHCityMunicipality
        End Get
        Set(value As String)
            _mHCityMunicipality = value
        End Set
    End Property
    Public Shared Property _pHProvince() As String
        Get
            Return _mHProvince
        End Get
        Set(value As String)
            _mHProvince = value
        End Set
    End Property
    Public Shared Property _pHZipcode() As String
        Get
            Return _mHZipcode
        End Get
        Set(value As String)
            _mHZipcode = value
        End Set
    End Property
    Public Shared Property _pHTellNo() As String
        Get
            Return _mHTellNo
        End Get
        Set(value As String)
            _mHTellNo = value
        End Set
    End Property
    Public Shared Property _pHApplicantNo() As String
        Get
            Return _mHApplicantNo
        End Get
        Set(value As String)
            _mHApplicantNo = value
        End Set
    End Property
    Public Shared Property _pHPlaceIssued() As String
        Get
            Return _mHPlaceIssued
        End Get
        Set(value As String)
            _mHPlaceIssued = value
        End Set
    End Property
    Public Shared Property _pHDateIssued() As String
        Get
            Return _mHDateIssued
        End Get
        Set(value As String)
            _mHDateIssued = value
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

    Public Shared Property _pencoderID() As String
        Get
            Return _mencoderID
        End Get
        Set(value As String)
            _mencoderID = value
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

    Public Shared Property _pLastUpdate() As String
        Get
            Return _mLastUpdate
        End Get
        Set(value As String)
            _mLastUpdate = value
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

    Public Shared Property _pTIN() As String
        Get
            Return _mTIN
        End Get
        Set(value As String)
            _mTIN = value
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

    Public Shared Property _pZIPCode As String
        Get
            Return _mZIPCode
        End Get
        Set(value As String)
            _mZIPCode = value
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

    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select " & _nColumns & " from vw_ApplicantInfo" & _nCondition

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)

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
            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                _nStrSql = "EXEC [sp_Applicant_IUD] " & _
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
                            ",@ApplCode = N'" & _mApplCode & "'" & _
                            ",@encoderID = N'" & _mencoderID & "'" & _
                            ",@FName = N'" & _mFName & "'" & _
                            ",@IDCode = N'" & _mIDCode & "'" & _
                            ",@LastUpdate = N'" & _mLastUpdate & "'" & _
                            ",@LName = N'" & _mLName & "'" & _
                            ",@MName = N'" & _mMName & "'" & _
                            ",@TIN = N'" & _mTIN & "'" & _
                            ",@TellNo = N'" & _mTellNo & "'" & _
                            ",@ZIPCode = N'" & _mZIPCode & "'" & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_Applicant_IUD] " & _
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
                           ",@ApplCode = N'" & _mApplCode & "'" & _
                           ",@encoderID = N'" & _mencoderID & "'" & _
                           ",@FName = N'" & _mFName & "'" & _
                           ",@LastUpdate = N'" & _mLastUpdate & "'" & _
                           ",@LName = N'" & _mLName & "'" & _
                           ",@MName = N'" & _mMName & "'" & _
                           ",@TIN = N'" & _mTIN & "'" & _
                           ",@TellNo = N'" & _mTellNo & "'" & _
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
    Public Shared Sub _pHSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            '_nSelectCond = Replace(_nCondition, "'", "''")
            'If _mAdd Then
            _nStrSql = "EXEC [sp_HIST_Applicant_IUD] " & _
                        "@Action = 'INSERT' " & _
                        ",@Address1 = N'" & _mHStrtNo & "'" & _
                        ",@Address2 = N'" & _mHSubdVill & "'" & _
                        ",@Address3 = N'" & _mHBarangayAddress & "'" & _
                        ",@Address4 = N'" & _mHCityMunicipality & "'" & _
                        ",@Address5 = N'" & _mHProvince & "'" & _
                        ",@ApplCode = N'" & _mHZipcode & "'" & _
                        ",@encoderID = N'" & _mHEncoderID & "'" & _
                        ",@FName = N'" & _mHFName & "'" & _
                        ",@IDCode = N'" & _mHIDCode & "'" & _
                        ",@LastUpdate = N'" & DateTime.Today.ToString() & "'" & _
                        ",@LName = N'" & _mHLName & "'" & _
                        ",@MName = N'" & _mHMName & "'" & _
                        ",@TIN = N'" & _mHTIN & "'" & _
                        ",@TellNo = N'" & _mHTellNo & "'" & _
                        ",@ZIPCode = N'" & _mHZipcode & "'" & _
                        ",@Successful = @Successful output " & _
                        ",@ErrMsg = @ErrMsg output  "

            'Else

            '_nStrSql = "EXEC [sp_HIST_Applicant_IUD] " & _
            '            "@Action = 'UPDATE' " & _
            '            ",@SelectCond = N'" & _nSelectCond & "'" & _
            '           ",@Address1 = N'" & _mAddress1 & "'" & _
            '           ",@Address2 = N'" & _mAddress2 & "'" & _
            '           ",@Address3 = N'" & _mAddress3 & "'" & _
            '           ",@Address4 = N'" & _mAddress4 & "'" & _
            '           ",@Address5 = N'" & _mAddress5 & "'" & _
            '           ",@ApplCode = N'" & _mApplCode & "'" & _
            '           ",@encoderID = N'" & _mencoderID & "'" & _
            '           ",@FName = N'" & _mFName & "'" & _
            '           ",@LastUpdate = N'" & _mLastUpdate & "'" & _
            '           ",@LName = N'" & _mLName & "'" & _
            '           ",@MName = N'" & _mMName & "'" & _
            '           ",@TIN = N'" & _mTIN & "'" & _
            '           ",@TellNo = N'" & _mTellNo & "'" & _
            '           ",@ZIPCode = N'" & _mZIPCode & "'" & _
            '            ",@Successful = @Successful output " & _
            '           ",@ErrMsg = @ErrMsg output  "
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
            _nStrSql = "EXEC [sp_Applicant_IUD] " & _
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

End Class
