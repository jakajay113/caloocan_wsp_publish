Imports System.Data.SqlClient

Public Class cDalSubmRequirementsDoc_IUD
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String
    'Private Shared _mMainToolstrip As New ToolStripMenuItem
    'Public Shared _mToolstrip As New ToolStripMenuItem

    'Public Shared _mMgridView As New DataGridView
    'Public Shared _mSubgridView As New DataGridView
#End Region

    'Public Shared Sub _pMainToolstrip()
    '    Try
    '        _mMainToolstrip = _mToolstrip
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Public Shared Sub _pGridview()
    '    Try
    '        _mMgridView = _mSubgridView
    '    Catch ex As Exception

    '    End Try
    'End Sub

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
    Private Shared _mPermitType As String
    Private Shared _mPermittypeDesc As String
    Private Shared _mAppNo As String
    Private Shared _mDate_Submitted As String
    Private Shared _mReceived_by As String
    Private Shared _mSubmitted_by As String
    Private Shared _mContactNo As String
    Private Shared _mBldgReqCode As String
    Private Shared _mBldgReqDesc As String
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

    Public Shared Property _pPermitType() As String
        Get
            Return _mPermitType
        End Get
        Set(value As String)
            _mPermitType = value
        End Set
    End Property
    '

    Public Shared Property _pPermittypeDesc() As String
        Get
            Return _mPermittypeDesc
        End Get
        Set(value As String)
            _mPermittypeDesc = value
        End Set
    End Property




    Public Shared Property _pDate_Submitted() As String
        Get
            Return _mDate_Submitted
        End Get
        Set(value As String)
            _mDate_Submitted = value
        End Set
    End Property

    Public Shared Property _pReceived_by() As String
        Get
            Return _mReceived_by
        End Get
        Set(value As String)
            _mReceived_by = value
        End Set
    End Property

    Public Shared Property _pSubmitted_by() As String
        Get
            Return _mSubmitted_by
        End Get
        Set(value As String)
            _mSubmitted_by = value
        End Set
    End Property

    Public Shared Property _pContactNo() As String
        Get
            Return _mContactNo
        End Get
        Set(value As String)
            _mContactNo = value
        End Set
    End Property

    Public Shared Property _pBldgReqCode() As String
        Get
            Return _mBldgReqCode
        End Get
        Set(value As String)
            _mBldgReqCode = value
        End Set
    End Property

    Public Shared Property _pBldgReqDesc() As String
        Get
            Return _mBldgReqDesc
        End Get
        Set(value As String)
            _mBldgReqDesc = value
        End Set
    End Property


#Region "Routine Data"

    Public Shared Sub _pAdd()
        Try
            _mAdd = True
        Catch ex As Exception

        End Try
    End Sub

#Region "Routine"

    ''----------------------Modify 20190502
    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select  " & _nColumns & " from SubmReqmt " & _nCondition

            '----------------------------------
            _mSqlCmd = New SqlCommand(_nQuery, _mSqlCon)

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
#End Region



    Public Shared Sub _pSave(ByRef _nSuccessful As Boolean, ByVal _nAppNo As String, ByVal _nDate_Submitted As String, ByVal _nSubmitted_by As String, _
                            ByVal _nReceived_by As String, ByVal _nPermitType As String, ByVal _nContactNo As String, _
                            Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing
                             )
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                _nStrSql = "EXEC [sp_SubmReqmt_IUD] " & _
                "@Action = 'INSERT' " & _
                 ",@AppNo = N'" & _nAppNo & "'" & _
                ",@Date_Submitted = N'" & _nDate_Submitted & "'" & _
                 ",@Submitted_by = N'" & _nSubmitted_by & "'" & _
                ",@Received_by = N'" & _nReceived_by & "'" & _
                ",@PermitType = N'" & _nPermitType & "'" & _
                 ",@ContactNo = N'" & _nContactNo & "'" & _
                ",@Successful = @Successful output " & _
                ",@ErrMsg = @ErrMsg output  "
                '         ",@BldgReqCode = N'" & _mBldgReqCode & "'" & _
                '",@BldgReqDesc = N'" & _mBldgReqDesc & "'" & _
            Else

                _nStrSql = "EXEC [sp_SubmReqmt_IUD] " & _
                "@Action = 'UPDATE' " & _
                ",@SelectCond = N'" & _nSelectCond & "'" & _
               ",@AppNo = N'" & _nAppNo & "'" & _
                ",@Date_Submitted = N'" & _nDate_Submitted & "'" & _
                 ",@Submitted_by = N'" & _nSubmitted_by & "'" & _
                ",@Received_by = N'" & _nReceived_by & "'" & _
                ",@PermitType = N'" & _nPermitType & "'" & _
                 ",@ContactNo = N'" & _nContactNo & "'" & _
                ",@Successful = @Successful output " & _
                ",@ErrMsg = @ErrMsg output  "
                '       ",@BldgReqCode = N'" & _mBldgReqCode & "'" & _
                '",@BldgReqDesc = N'" & _mBldgReqDesc & "'" & _
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
            _nStrSql = "EXEC [sp_SubmReqmt_IUD] " & _
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


#End Region

End Class
