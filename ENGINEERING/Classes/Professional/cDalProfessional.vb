#Region "Imports"

Imports System.Data.SqlClient

#End Region


Public Class cDalProfessional

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
#End Region

#Region "Variable Field"

    Private Shared _mAddress As String
    Private Shared _mAddress1 As String
    Private Shared _mAddress2 As String
    Private Shared _mAddress3 As String
    Private Shared _mAddress4 As String
    Private Shared _mAddress5 As String
    Private Shared _mDateEncoded As String
    Private Shared _mEncoderID As String
    Private Shared _mIA_POA_Date_Issued As String
    Private Shared _mIA_POA_No As String
    Private Shared _mIA_POA_ORNumber As String
    Private Shared _mIDCode As String
    Private Shared _mFName As String
    Private Shared _mLName As String
    Private Shared _mMName As String
    Private Shared _mFullName As String
    Private Shared _mMobileNo As String
    Private Shared _mTelNo As String
    Private Shared _mTINNo As String
    Private Shared _mPCAB_License_No As String
    Private Shared _mPCAB_Validity As String
    Private Shared _mPRC_DateIssued As String
    Private Shared _mPRC_Place_Issued As String
    Private Shared _mPRC_Validity As String
    Private Shared _mPRCNo As String
    Private Shared _mProf_Title As String
    Private Shared _mPTR_Date_Issued As String
    Private Shared _mPTR_Place_Issued As String
    Private Shared _mPTRNo As String


#End Region
#Region "Property Field"

    Public Shared Property _pAddress() As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
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

    Public Shared Property _pFName() As String
        Get
            Return _mFName
        End Get
        Set(value As String)
            _mFName = value
        End Set
    End Property

    Public Shared Property _pIA_POA_Date_Issued() As String
        Get
            Return _mIA_POA_Date_Issued
        End Get
        Set(value As String)
            _mIA_POA_Date_Issued = value
        End Set
    End Property

    Public Shared Property _pIA_POA_No() As String
        Get
            Return _mIA_POA_No
        End Get
        Set(value As String)
            _mIA_POA_No = value
        End Set
    End Property

    Public Shared Property _pIA_POA_ORNumber() As String
        Get
            Return _mIA_POA_ORNumber
        End Get
        Set(value As String)
            _mIA_POA_ORNumber = value
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

    Public Shared Property _pFullName() As String
        Get
            Return _mFullName
        End Get
        Set(value As String)
            _mFullName = value
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


    Public Shared Property _pMobileNo() As String
        Get
            Return _mMobileNo
        End Get
        Set(value As String)
            _mMobileNo = value
        End Set
    End Property

    Public Shared Property _pPCAB_License_No() As String
        Get
            Return _mPCAB_License_No
        End Get
        Set(value As String)
            _mPCAB_License_No = value
        End Set
    End Property

    Public Shared Property _pPCAB_Validity() As String
        Get
            Return _mPCAB_Validity
        End Get
        Set(value As String)
            _mPCAB_Validity = value
        End Set
    End Property

    Public Shared Property _pPRC_DateIssued() As String
        Get
            Return _mPRC_DateIssued
        End Get
        Set(value As String)
            _mPRC_DateIssued = value
        End Set
    End Property

    Public Shared Property _pPRC_Place_Issued() As String
        Get
            Return _mPRC_Place_Issued
        End Get
        Set(value As String)
            _mPRC_Place_Issued = value
        End Set
    End Property

    Public Shared Property _pPRC_Validity() As String
        Get
            Return _mPRC_Validity
        End Get
        Set(value As String)
            _mPRC_Validity = value
        End Set
    End Property

    Public Shared Property _pPRCNo() As String
        Get
            Return _mPRCNo
        End Get
        Set(value As String)
            _mPRCNo = value
        End Set
    End Property

    Public Shared Property _pProf_Title() As String
        Get
            Return _mProf_Title
        End Get
        Set(value As String)
            _mProf_Title = value
        End Set
    End Property

    Public Shared Property _pPTR_Date_Issued() As String
        Get
            Return _mPTR_Date_Issued
        End Get
        Set(value As String)
            _mPTR_Date_Issued = value
        End Set
    End Property

    Public Shared Property _pPTR_Place_Issued() As String
        Get
            Return _mPTR_Place_Issued
        End Get
        Set(value As String)
            _mPTR_Place_Issued = value
        End Set
    End Property

    Public Shared Property _pPTRNo() As String
        Get
            Return _mPTRNo
        End Get
        Set(value As String)
            _mPTRNo = value
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

    Public Shared Property _pTINNo() As String
        Get
            Return _mTINNo
        End Get
        Set(value As String)
            _mTINNo = value
        End Set
    End Property
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

            _nCondition = "Where " & _nColumns & " = '" & _nCond & "'"
            If _nCond = Nothing Then _nCondition = ""


            '----------------------------------    
            _nQuery = "Select * from vw_ProfessionalInfo " & _nCondition

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

    Public Shared Function _FnGetEngProfIDNo(ByVal _nFullName As String) As String
        _FnGetEngProfIDNo = Nothing
        Try
            Dim _nErrMsg As String = ""
            'Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            '_nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "SELECT IDNo FROM vw_EngProf " & _
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
                        _FnGetEngProfIDNo = _nSqlDr.Item("IDNo").ToString
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

    Public Shared Sub _pSubSelectProfessional(ByVal _nBool As Boolean, Optional _nCondition As String = Nothing) '------------Data bind only barangay combobox 20190218
        Dim _mStrSql As String = ""
        Try
            Select Case _nBool
                Case True

                    _mStrSql = "Select LName, FName, MName, Address1, Address2, Address3, Address4, Address5, TINNo, IDCode from Professional " & _nCondition

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

            _nStrSql = "EXEC [sp_Professional_IUD] " & _
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
                        _mFName = _nSqlDr.Item("FName").ToString
                        _mLName = _nSqlDr.Item("LName").ToString
                        _mMName = _nSqlDr.Item("MName").ToString
                        _mIDCode = _nSqlDr.Item("IDCode").ToString
                        _mMobileNo = _nSqlDr.Item("MobileNo").ToString
                        _mTelNo = _nSqlDr.Item("TelNo").ToString
                        _mTINNo = _nSqlDr.Item("TINNo").ToString
                        _mPRCNo = _nSqlDr.Item("PRCNo").ToString
                        _mPRC_Validity = _nSqlDr.Item("PRC_Validity").ToString
                        _mPRC_DateIssued = _nSqlDr.Item("PRC_DateIssued").ToString
                        _mPRC_Place_Issued = _nSqlDr.Item("PRC_Place_Issued").ToString
                        _mPTRNo = _nSqlDr.Item("PTRNo").ToString
                        _mPTR_Date_Issued = _nSqlDr.Item("PTR_Date_Issued").ToString
                        _mPTR_Place_Issued = _nSqlDr.Item("PTR_Place_Issued").ToString
                        _mIA_POA_No = _nSqlDr.Item("IA_POA_No").ToString
                        _mIA_POA_ORNumber = _nSqlDr.Item("IA_POA_ORNumber").ToString
                        _mIA_POA_Date_Issued = _nSqlDr.Item("IA_POA_Date_Issued").ToString
                        _mProf_Title = _nSqlDr.Item("Prof_Title").ToString
                        _mPCAB_License_No = _nSqlDr.Item("PCAB_License_No").ToString
                        _mPCAB_Validity = _nSqlDr.Item("PCAB_Validity").ToString
                        _mDateEncoded = _nSqlDr.Item("DateEncoded").ToString
                        _mEncoderID = _nSqlDr.Item("EncoderID").ToString
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
