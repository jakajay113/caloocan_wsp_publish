Imports System.Data.SqlClient

Public Class cDalSubEmployeeSetup_IUD

#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Private Shared _mQuery As String = ""

#End Region

#Region "Variables"
    Private Shared _mAdd As Boolean = False

#End Region

#Region "Variable Field"
    'Private Shared _mCode As String
    'Private Shared _mDescription As String
    'Private Shared _mAcronym As String
    Private Shared _mCode As String
    Private Shared _mDesc1 As String
    Private Shared _mDesc2 As String

    Private Shared _mDeptCode As String
    Private Shared _mDivCode As String
    Private Shared _mSectCode As String
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

#Region "Property Field"
    Public Shared Property _pCode() As String
        Get
            Return _mCode
        End Get
        Set(value As String)
            _mCode = value
        End Set
    End Property
    Public Shared Property _pDesc1() As String
        Get
            Return _mDesc1
        End Get
        Set(value As String)
            _mDesc1 = value
        End Set
    End Property

    Public Shared Property _pDesc2() As String
        Get
            Return _mDesc2
        End Get
        Set(value As String)
            _mDesc2 = value
        End Set
    End Property

    Public Shared Property _pDeptCode() As String
        Get
            Return _mDeptCode
        End Get
        Set(value As String)
            _mDeptCode = value
        End Set
    End Property

    Public Shared Property _pDivCode() As String
        Get
            Return _mDivCode
        End Get
        Set(value As String)
            _mDivCode = value
        End Set
    End Property

    Public Shared Property _pSectCode() As String
        Get
            Return _mSectCode
        End Get
        Set(value As String)
            _mSectCode = value
        End Set
    End Property

#End Region

#Region "Routine"
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
            _nQuery = "Select " & _nColumns & " from " & cDalEmployees._pTableName & " " & _nCondition

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

    Public Shared Sub _pSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "")
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String = ""
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                If cDalEmployees._pTableName = "Emp_Department" Then
                    _nStrSql = _
                    "EXEC [sp_" & cDalEmployees._pTableName & "_IUD] " & _
                                "@Action = 'INSERT' " & _
                                ",@Code = N'" & _mCode & "'" & _
                                ",@Desc1 = N'" & _mDesc1 & "'" & _
                                ",@Desc2 = N'" & _mDesc2 & "'" & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  "
                ElseIf cDalEmployees._pTableName = "Emp_Division" Then
                    _nStrSql = _
                    "EXEC [sp_" & cDalEmployees._pTableName & "_IUD] " & _
                                "@Action = 'INSERT' " & _
                                ",@Code = N'" & _mCode & "'" & _
                                ",@Desc1 = N'" & _mDesc1 & "'" & _
                                ",@Desc2 = N'" & _mDesc2 & "'" & _
                                ",@DeptCode = N'" & _mDeptCode & "'" & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  "
                ElseIf cDalEmployees._pTableName = "Emp_Section" Then
                    _nStrSql = _
                    "EXEC [sp_" & cDalEmployees._pTableName & "_IUD] " & _
                                "@Action = 'INSERT' " & _
                                ",@Code = N'" & _mCode & "'" & _
                                ",@Desc1 = N'" & _mDesc1 & "'" & _
                                ",@Desc2 = N'" & _mDesc2 & "'" & _
                                ",@DeptCode = N'" & _mDeptCode & "'" & _
                                ",@DivCode = N'" & _mDivCode & "'" & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  "
                ElseIf cDalEmployees._pTableName = "Emp_Title" Then
                    _nStrSql = _
                    "EXEC [sp_" & cDalEmployees._pTableName & "_IUD] " & _
                                "@Action = 'INSERT' " & _
                                ",@Code = N'" & _mCode & "'" & _
                                ",@Desc1 = N'" & _mDesc1 & "'" & _
                                ",@Desc2 = N'" & _mDesc2 & "'" & _
                                ",@DeptCode = N'" & _mDeptCode & "'" & _
                                ",@DivCode = N'" & _mDivCode & "'" & _
                                ",@SectCode = N'" & _mSectCode & "'" & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  "
                End If

            Else
                _nStrSql = _
                    "EXEC [sp_" & cDalEmployees._pTableName & "_IUD] " & _
                                "@Action = 'UPDATE' " & _
                                ",@SelectCond = N'" & _nSelectCond & "'" & _
                                ",@Code = N'" & _mCode & "'" & _
                                ",@Desc1 = N'" & _mDesc1 & "'" & _
                                ",@Desc2 = N'" & _mDesc2 & "'" & _
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
                        '_mUniqueId = _nSqlDr.Item(0).ToString
                        '_mTeacherId = _nSqlDr.Item("teacherid").ToString
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

    Public Shared Sub _pDelete(ByRef _nSuccessful As Boolean, ByVal _nCondition As String)
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "EXEC [sp_" & cDalEmployees._pTableName & "_IUD] " & _
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
