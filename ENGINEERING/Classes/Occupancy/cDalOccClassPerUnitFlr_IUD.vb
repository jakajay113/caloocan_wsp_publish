Imports System.Data.SqlClient

Public Class cDalOccClassPerUnitFlr_IUD
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
    Private Shared _mNoOfFlr_Comm As String
    Private Shared _mNoOfFlr_Ind As String
    Private Shared _mNoOfFlr_Res As String
    Private Shared _mNoOfFlr_Spcl As String
    Private Shared _mNoOfUnits_Comm As String
    Private Shared _mNoOfUnits_Ind As String
    Private Shared _mNoOfUnits_Res As String
    Private Shared _mNoOfUnits_Spcl As String
    Private Shared _mOcc_Code As String
    Private Shared _mOcc_Desc As String
    Private Shared _mPermitType As String

#End Region
#Region "Property Field"

    Public Shared Property _pAppNo() As String
        Get
            Return _mAppNo
        End Get
        Set(value As String)
            _mAppNo = value
        End Set
    End Property

    Public Shared Property _pNoOfFlr_Comm() As String
        Get
            Return _mNoOfFlr_Comm
        End Get
        Set(value As String)
            _mNoOfFlr_Comm = value
        End Set
    End Property

    Public Shared Property _pNoOfFlr_Ind() As String
        Get
            Return _mNoOfFlr_Ind
        End Get
        Set(value As String)
            _mNoOfFlr_Ind = value
        End Set
    End Property

    Public Shared Property _pNoOfFlr_Res() As String
        Get
            Return _mNoOfFlr_Res
        End Get
        Set(value As String)
            _mNoOfFlr_Res = value
        End Set
    End Property

    Public Shared Property _pNoOfFlr_Spcl() As String
        Get
            Return _mNoOfFlr_Spcl
        End Get
        Set(value As String)
            _mNoOfFlr_Spcl = value
        End Set
    End Property

    Public Shared Property _pNoOfUnits_Comm() As String
        Get
            Return _mNoOfUnits_Comm
        End Get
        Set(value As String)
            _mNoOfUnits_Comm = value
        End Set
    End Property

    Public Shared Property _pNoOfUnits_Ind() As String
        Get
            Return _mNoOfUnits_Ind
        End Get
        Set(value As String)
            _mNoOfUnits_Ind = value
        End Set
    End Property

    Public Shared Property _pNoOfUnits_Res() As String
        Get
            Return _mNoOfUnits_Res
        End Get
        Set(value As String)
            _mNoOfUnits_Res = value
        End Set
    End Property

    Public Shared Property _pNoOfUnits_Spcl() As String
        Get
            Return _mNoOfUnits_Spcl
        End Get
        Set(value As String)
            _mNoOfUnits_Spcl = value
        End Set
    End Property

    Public Shared Property _pOcc_Code() As String
        Get
            Return _mOcc_Code
        End Get
        Set(value As String)
            _mOcc_Code = value
        End Set
    End Property

    Public Shared Property _pOcc_Desc() As String
        Get
            Return _mOcc_Desc
        End Get
        Set(value As String)
            _mOcc_Desc = value
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


#End Region

#Region "Routine Data"

    Public Shared Sub _pAdd()
        Try
            _mAdd = True
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
                _nStrSql = "EXEC [sp_OccClassPerUnitFlr_IUD] " & _
                "@Action = 'INSERT' " & _
                ",@AppNo = N'" & _mAppNo & "'" & _
                ",@NoOfFlr_Comm = N'" & _mNoOfFlr_Comm & "'" & _
                ",@NoOfFlr_Ind = N'" & _mNoOfFlr_Ind & "'" & _
                ",@NoOfFlr_Res = N'" & _mNoOfFlr_Res & "'" & _
                ",@NoOfFlr_Spcl = N'" & _mNoOfFlr_Spcl & "'" & _
                ",@NoOfUnits_Comm = N'" & _mNoOfUnits_Comm & "'" & _
                ",@NoOfUnits_Ind = N'" & _mNoOfUnits_Ind & "'" & _
                ",@NoOfUnits_Res = N'" & _mNoOfUnits_Res & "'" & _
                ",@NoOfUnits_Spcl = N'" & _mNoOfUnits_Spcl & "'" & _
                ",@Occ_Code = N'" & _mOcc_Code & "'" & _
                ",@Occ_Desc = N'" & _mOcc_Desc & "'" & _
                ",@PermitType = N'" & _mPermitType & "'" & _
                ",@Successful = @Successful output " & _
                ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_OccClassPerUnitFlr_IUD] " & _
                "@Action = 'UPDATE' " & _
                ",@SelectCond = N'" & _nSelectCond & "'" & _
                ",@AppNo = N'" & _mAppNo & "'" & _
                ",@NoOfFlr_Comm = N'" & _mNoOfFlr_Comm & "'" & _
                ",@NoOfFlr_Ind = N'" & _mNoOfFlr_Ind & "'" & _
                ",@NoOfFlr_Res = N'" & _mNoOfFlr_Res & "'" & _
                ",@NoOfFlr_Spcl = N'" & _mNoOfFlr_Spcl & "'" & _
                ",@NoOfUnits_Comm = N'" & _mNoOfUnits_Comm & "'" & _
                ",@NoOfUnits_Ind = N'" & _mNoOfUnits_Ind & "'" & _
                ",@NoOfUnits_Res = N'" & _mNoOfUnits_Res & "'" & _
                ",@NoOfUnits_Spcl = N'" & _mNoOfUnits_Spcl & "'" & _
                ",@Occ_Code = N'" & _mOcc_Code & "'" & _
                ",@Occ_Desc = N'" & _mOcc_Desc & "'" & _
                ",@PermitType = N'" & _mPermitType & "'" & _
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

    Public Shared Sub _pDelete(ByRef _nSuccessful As Boolean, ByVal _nCondition As String, Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "EXEC [sp_OccClassPerUnitFlr_IUD] " & _
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
