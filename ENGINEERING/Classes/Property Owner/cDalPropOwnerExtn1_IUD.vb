Imports System.Data.SqlClient

Public Class cDalPropOwnerExtn1_IUD

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
    Private Shared _mEdit As Boolean
    Private Shared _mAppNo As String
    Private Shared _mDateEncoded As String
    Private Shared _mEncoderID As String
    Private Shared _mIDCode As String
    Private Shared _mLotNo As String
    Private Shared _mPIN As String
    Private Shared _mPropKind As String
    Private Shared _mTDN As String
    Private Shared _mTCTNo As String
    Private Shared _mBlkNo As String
    Private Shared _mStreet As String
    Private Shared _mBarangay As String
    Private Shared _mStrtCode As String
    Private Shared _mBrgyCode As String

#End Region
#Region "Property Field"



    Public Shared Property _pBrgyCode() As String
        Get
            Return _mBrgyCode
        End Get
        Set(value As String)
            _mBrgyCode = value
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

    Public Shared Property _pStreet() As String
        Get
            Return _mStreet
        End Get
        Set(value As String)
            _mStreet = value
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

    Public Shared Property _pTCTNo() As String
        Get
            Return _mTCTNo
        End Get
        Set(value As String)
            _mTCTNo = value
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

    Public Shared Property _pAppNo() As String
        Get
            Return _mAppNo
        End Get
        Set(value As String)
            _mAppNo = value
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

    Public Shared Property _pTDN() As String
        Get
            Return _mTDN
        End Get
        Set(value As String)
            _mTDN = value
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



    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0) 'Modified 04/30/2019-Villena
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select " & _nColumns & " from PropOwnerExtn1" & _nCondition

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
    Public Shared Sub _Hist_Save(IDCode As String)
        Try

            Dim _nStrSql As String
            _nStrSql = "insert into hist_propownerextn1 select * from propownerextn1 where idcode = '" & IDCode & "'"
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
                _nStrSql = "EXEC [sp_PropOwnerExtn1_IUD] " & _
                "@Action = 'INSERT' " & _
                ",@AppNo = N'" & _mAppNo & "'" & _
                ",@Barangay = N'" & _mBarangay & "'" & _
                ",@BlkNo = N'" & _mBlkNo & "'" & _
                ",@DateEncoded = N'" & _mDateEncoded & "'" & _
                ",@EncoderID = N'" & _mEncoderID & "'" & _
                ",@IDCode = N'" & _mIDCode & "'" & _
                ",@LotNo = N'" & _mLotNo & "'" & _
                ",@PIN = N'" & _mPIN & "'" & _
                ",@PropKind = N'" & _mPropKind & "'" & _
                ",@Street = N'" & _mStreet & "'" & _
                ",@TCTNo = N'" & _mTCTNo & "'" & _
                ",@StrtCode = N'" & _mStrtCode & "'" & _
                ",@BrgyCode = N'" & _mBrgyCode & "'" & _
                ",@TDN = N'" & _mTDN & "'" & _
                ",@Successful = @Successful output " & _
                ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_PropOwnerExtn1_IUD] " & _
                "@Action = 'UPDATE' " & _
                ",@SelectCond = N'" & _nSelectCond & "'" & _
                ",@Barangay = N'" & _mBarangay & "'" & _
                ",@BlkNo = N'" & _mBlkNo & "'" & _
                ",@DateEncoded = N'" & _mDateEncoded & "'" & _
                ",@EncoderID = N'" & _mEncoderID & "'" & _
                ",@IDCode = N'" & _mIDCode & "'" & _
                ",@LotNo = N'" & _mLotNo & "'" & _
                ",@PIN = N'" & _mPIN & "'" & _
                ",@PropKind = N'" & _mPropKind & "'" & _
                ",@Street = N'" & _mStreet & "'" & _
                ",@TCTNo = N'" & _mTCTNo & "'" & _
                ",@StrtCode = N'" & _mStrtCode & "'" & _
                ",@BrgyCode = N'" & _mBrgyCode & "'" & _
                ",@TDN = N'" & _mTDN & "'" & _
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
            _nStrSql = "EXEC [sp_PropOwnerExtn1_IUD] " & _
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
