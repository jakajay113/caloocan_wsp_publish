Imports System.Data.SqlClient

Public Class cDalOccupancyUseExt_IUD
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String
    Private Shared _mQuery As String = ""


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
    Private Shared _mEst_Cost As String
    Private Shared _mExpComDate As String
    Private Shared _mFlrArea As String
    Private Shared _mNo_Floor As String
    Private Shared _mNo_Units As String
    Private Shared _mOcc_Class As String
    Private Shared _mOcc_Code As String
    Private Shared _mPermitType As String
    Private Shared _mPreparedBy As String
    Private Shared _mPropConstDate As String
    Private Shared _mTot_FlrArea As String

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

    Public Shared Property _pEst_Cost() As String
        Get
            Return _mEst_Cost
        End Get
        Set(value As String)
            _mEst_Cost = value
        End Set
    End Property

    Public Shared Property _pExpComDate() As String
        Get
            Return _mExpComDate
        End Get
        Set(value As String)
            _mExpComDate = value
        End Set
    End Property

    Public Shared Property _pFlrArea() As String
        Get
            Return _mFlrArea
        End Get
        Set(value As String)
            _mFlrArea = value
        End Set
    End Property

    Public Shared Property _pNo_Floor() As String
        Get
            Return _mNo_Floor
        End Get
        Set(value As String)
            _mNo_Floor = value
        End Set
    End Property

    Public Shared Property _pNo_Units() As String
        Get
            Return _mNo_Units
        End Get
        Set(value As String)
            _mNo_Units = value
        End Set
    End Property

    Public Shared Property _pOcc_Class() As String
        Get
            Return _mOcc_Class
        End Get
        Set(value As String)
            _mOcc_Class = value
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

    Public Shared Property _pPermitType() As String
        Get
            Return _mPermitType
        End Get
        Set(value As String)
            _mPermitType = value
        End Set
    End Property

    Public Shared Property _pPreparedBy() As String
        Get
            Return _mPreparedBy
        End Get
        Set(value As String)
            _mPreparedBy = value
        End Set
    End Property


    Public Shared Property _pPropConstDate() As String
        Get
            Return _mPropConstDate
        End Get
        Set(value As String)
            _mPropConstDate = value
        End Set
    End Property

    Public Shared Property _pTot_FlrArea() As String
        Get
            Return _mTot_FlrArea
        End Get
        Set(value As String)
            _mTot_FlrArea = value
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

    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select " & _nColumns & " from OccupancyUseExt " & _nCondition

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
                _nStrSql = "EXEC [sp_OccupancyUseExt_IUD] " & _
                "@Action = 'INSERT' " & _
                ",@AppNo = N'" & _mAppNo & "'" & _
                ",@Est_Cost = N'" & _mEst_Cost & "'" & _
                ",@ExpComDate = N'" & _mExpComDate & "'" & _
                ",@FlrArea = N'" & _mFlrArea & "'" & _
                ",@No_Floor = N'" & _mNo_Floor & "'" & _
                ",@No_Units = N'" & _mNo_Units & "'" & _
                ",@Occ_Class = N'" & _mOcc_Class & "'" & _
                ",@Occ_Code = N'" & _mOcc_Code & "'" & _
                ",@PermitType = N'" & _mPermitType & "'" & _
                ",@PreparedBy = N'" & _mPreparedBy & "'" & _
                ",@PropConstDate = N'" & _mPropConstDate & "'" & _
                ",@Tot_FlrArea = N'" & _mTot_FlrArea & "'" & _
                ",@Successful = @Successful output " & _
                ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_OccupancyUseExt_IUD] " & _
                "@Action = 'UPDATE' " & _
                ",@SelectCond = N'" & _nSelectCond & "'" & _
                ",@AppNo = N'" & _mAppNo & "'" & _
                ",@Est_Cost = N'" & _mEst_Cost & "'" & _
                ",@ExpComDate = N'" & _mExpComDate & "'" & _
                ",@FlrArea = N'" & _mFlrArea & "'" & _
                ",@No_Floor = N'" & _mNo_Floor & "'" & _
                ",@No_Units = N'" & _mNo_Units & "'" & _
                ",@Occ_Class = N'" & _mOcc_Class & "'" & _
                ",@Occ_Code = N'" & _mOcc_Code & "'" & _
                ",@PermitType = N'" & _mPermitType & "'" & _
                ",@PreparedBy = N'" & _mPreparedBy & "'" & _
                ",@PropConstDate = N'" & _mPropConstDate & "'" & _
                ",@Tot_FlrArea = N'" & _mTot_FlrArea & "'" & _
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
            _nStrSql = "EXEC [sp_OccupancyUseExt_IUD] " & _
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
