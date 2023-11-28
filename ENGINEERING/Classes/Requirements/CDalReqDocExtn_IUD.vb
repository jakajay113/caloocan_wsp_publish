Imports System.Data.SqlClient

Public Class CDalReqDocExtn_IUD
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
    Private Shared _mPermitType As String
    Private Shared _mPermittypeDesc As String
    Private Shared _mAppNo As String
    Private Shared _mDate_Submitted As String
    Private Shared _mReceived_by As String
    Private Shared _mSubmitted_by As String
    Private Shared _mContactNo As String
    Private Shared _mBldgReqCode As String
    Private Shared _mBldgReqDesc As String

    Private Shared _mQty_Submitted As String
    Private Shared _mReq_Code As String
    Private Shared _mQty_Req As String
    Private Shared _mRemarks As String

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

    Public Shared Property _pQty_Submitted As String
        Get
            Return _mQty_Submitted
        End Get
        Set(value As String)
            _mQty_Submitted = value
        End Set
    End Property

    Public Shared Property _pReq_Code As String
        Get
            Return _mReq_Code
        End Get
        Set(value As String)
            _mReq_Code = value
        End Set
    End Property


    Public Shared Property _pQty_Req As String

        Get
            Return _mQty_Req
        End Get
        Set(value As String)
            _mQty_Req = value
        End Set
    End Property

    Public Shared Property _pRemarks As String

        Get
            Return _mRemarks
        End Get
        Set(value As String)
            _mRemarks = value
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
            _nQuery = "Select  " & _nColumns & " from vw_SubmReqmt " & _nCondition

            '----------------------------------
            _mSqlCmd = New SqlCommand(_nQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _mDataTable.Columns.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)



            _nSqlDataAdapter.Dispose()
            _nRecCount = _mDataTable.Rows.Count
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub _pSubSelectReq(ByVal _nBool As Boolean, ByVal _nAppNo As String, ByVal _nPermitType As String, Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            If _nBool = False Then
                _nQuery = "Select  " & _nColumns & ", '' as ReqDesc from [ReqCode] where LinkCode = '" & _nPermitType & "'"
            Else
                _nQuery = "select * from ReqCode RC " & _
                            "left join UploadedReq UR " & _
                            "on RC.Code = ur.ReqCode and appno='" & _nAppNo & "' " & _
                            "where rc.LinkCode = '" & _nPermitType & "'"
            End If


            '----------------------------------
            _mSqlCmd = New SqlCommand(_nQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _mDataTable.Columns.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)



            _nSqlDataAdapter.Dispose()
            _nRecCount = _mDataTable.Rows.Count
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
#End Region



    '[PermitType]
    '   ,[AppNo]
    '   ,[Req_Code]
    '   ,[Qty_Submitted]
    '   ,[Remarks]
    '   ,[Date_Submitted]
    '   ,[Qty_Req]

    Public Shared Sub _pSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                _nStrSql = "EXEC [sp_ReqSub_Extn_IUD] " & _
                "@Action = 'INSERT' " & _
                 ",@Permittype = N'" & _mPermitType & "'" & _
                ",@AppNo = N'" & _mAppNo & "'" & _
                 ",@Req_Code = N'" & _mBldgReqCode & "'" & _
                ",@Qty_Submitted = N'" & _mQty_Req & "'" & _
                 ",@Remarks = N'" & _mRemarks & "'" & _
                 ",@Date_Submitted = N'" & _mDate_Submitted & "'" & _
                ",@Successful = @Successful output " & _
                ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_ReqSub_Extn_IUD] " & _
                "@Action = 'UPDATE' " & _
                ",@SelectCond = N'" & _nSelectCond & "'" & _
                     ",@Permittype = N'" & _mPermitType & "'" & _
                ",@AppNo = N'" & _mAppNo & "'" & _
                 ",@Req_Code = N'" & _mBldgReqCode & "'" & _
                ",@Qty_Req = N'" & _mQty_Req & "'" & _
                 ",@Remarks = N'" & _mRemarks & "'" & _
                 ",@Date_Submitted = N'" & _mDate_Submitted & "'" & _
                    ",@Qty_Submitted = N'" & _mQty_Submitted & "'" & _
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
