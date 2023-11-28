Imports System.Data.SqlClient

Public Class cDalApplicant_Extn_IUD

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
    Private Shared _mAppNo As String
    Private Shared _mDateApplied As String
    Private Shared _mDateEncoded As String
    Private Shared _mEncoderID As String
    Private Shared _mIDCode As String
    Private Shared _mOAPCode As String
    Private Shared _mDateSigned As String

#End Region
#Region "Property Field"

    Public Shared Property _pDateSigned() As String
        Get
            Return _mDateSigned
        End Get
        Set(value As String)
            _mDateSigned = value
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

    Public Shared Property _pOAPCode() As String
        Get
            Return _mOAPCode
        End Get
        Set(value As String)
            _mOAPCode = value
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

    Public Shared Sub _pSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                _nStrSql = "EXEC [sp_Applicant_Extn_IUD] " & _
                            "@Action = 'INSERT' " & _
                            ",@AppNo = N'" & _mAppNo & "'" & _
                            ",@DateApplied = N'" & _mDateApplied & "'" & _
                            ",@DateEncoded = N'" & _mDateEncoded & "'" & _
                            ",@EncoderID = N'" & _mEncoderID & "'" & _
                            ",@IDCode = N'" & _mIDCode & "'" & _
                            ",@OAPCode = N'" & _mOAPCode & "'" & _
                            ",@DateSigned = N'" & _mDateSigned & "'" & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_Applicant_Extn_IUD] " & _
                            "@Action = 'UPDATE' " & _
                            ",@SelectCond = N'" & _nSelectCond & "'" & _
                            ",@AppNo = N'" & _mAppNo & "'" & _
                            ",@DateApplied = N'" & _mDateApplied & "'" & _
                            ",@DateEncoded = N'" & _mDateEncoded & "'" & _
                            ",@EncoderID = N'" & _mEncoderID & "'" & _
                            ",@IDCode = N'" & _mIDCode & "'" & _
                            ",@OAPCode = N'" & _mOAPCode & "'" & _
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
                        '             _mCode = _nSqlDr.Item(0).ToString
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
            _nStrSql = "EXEC [sp_Applicant_Extn_IUD] " & _
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
