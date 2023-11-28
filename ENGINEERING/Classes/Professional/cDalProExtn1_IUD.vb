Imports System.Data.SqlClient

Public Class cDalProExtn1_IUD

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
    Private Shared _mDateApplied As String
    Private Shared _mDateEncoded As String
    Private Shared _mEncoderID As String
    Private Shared _mIAPO_ORNo As String
    Private Shared _mIAPOA_Date_ISS As String
    Private Shared _mIAPOANo As String
    Private Shared _mIDCode As String
    Private Shared _mPCab_Validity As String
    Private Shared _mPCabLicNo As String
    Private Shared _mPRC_Date_ISS As String
    Private Shared _mPRC_Place_Issued As String
    Private Shared _mPRCNo As String
    Private Shared _mPTR_Date_ISS As String
    Private Shared _mPTR_PLc_ISS As String
    Private Shared _mPTRNo As String

    Private Shared _mHAdd As Boolean '--------------------- ARCHIE20200122
    Private Shared _mHDateApplied As String
    Private Shared _mHDateEncoded As String
    Private Shared _mHEncoderID As String
    Private Shared _mHIAPO_ORNo As String
    Private Shared _mHIAPOA_Date_ISS As String
    Private Shared _mHIAPOANo As String
    Private Shared _mHIDCode As String
    Private Shared _mHPCab_Validity As String
    Private Shared _mHPCabLicNo As String
    Private Shared _mHPRC_Date_ISS As String
    Private Shared _mHPRC_Place_Issued As String
    Private Shared _mHPRCNo As String
    Private Shared _mHPTR_Date_ISS As String
    Private Shared _mHPTR_PLc_ISS As String
    Private Shared _mHPTRNo As String

#End Region
#Region "Property Field"

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

    Public Shared Property _pIAPO_ORNo() As String
        Get
            Return _mIAPO_ORNo
        End Get
        Set(value As String)
            _mIAPO_ORNo = value
        End Set
    End Property

    Public Shared Property _pIAPOA_Date_ISS() As String
        Get
            Return _mIAPOA_Date_ISS
        End Get
        Set(value As String)
            _mIAPOA_Date_ISS = value
        End Set
    End Property

    Public Shared Property _pIAPOANo() As String
        Get
            Return _mIAPOANo
        End Get
        Set(value As String)
            _mIAPOANo = value
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

    Public Shared Property _pPCab_Validity() As String
        Get
            Return _mPCab_Validity
        End Get
        Set(value As String)
            _mPCab_Validity = value
        End Set
    End Property

    Public Shared Property _pPCabLicNo() As String
        Get
            Return _mPCabLicNo
        End Get
        Set(value As String)
            _mPCabLicNo = value
        End Set
    End Property

    Public Shared Property _pPRC_Date_ISS() As String
        Get
            Return _mPRC_Date_ISS
        End Get
        Set(value As String)
            _mPRC_Date_ISS = value
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

    Public Shared Property _pPRCNo() As String
        Get
            Return _mPRCNo
        End Get
        Set(value As String)
            _mPRCNo = value
        End Set
    End Property

    Public Shared Property _pPTR_Date_ISS() As String
        Get
            Return _mPTR_Date_ISS
        End Get
        Set(value As String)
            _mPTR_Date_ISS = value
        End Set
    End Property

    Public Shared Property _pPTR_PLc_ISS() As String
        Get
            Return _mPTR_PLc_ISS
        End Get
        Set(value As String)
            _mPTR_PLc_ISS = value
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


    Public Shared Property _pHDateApplied() As String  '----------------- ARCHIE20200120
        Get
            Return _mHDateApplied
        End Get
        Set(value As String)
            _mHDateApplied = value
        End Set
    End Property

    Public Shared Property _pHDateEncoded() As String
        Get
            Return _mHDateEncoded
        End Get
        Set(value As String)
            _mHDateEncoded = value
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

    Public Shared Property _pHIAPO_ORNo() As String
        Get
            Return _mHIAPO_ORNo
        End Get
        Set(value As String)
            _mHIAPO_ORNo = value
        End Set
    End Property

    Public Shared Property _pHIAPOA_Date_ISS() As String
        Get
            Return _mHIAPOA_Date_ISS
        End Get
        Set(value As String)
            _mHIAPOA_Date_ISS = value
        End Set
    End Property

    Public Shared Property _pHIAPOANo() As String
        Get
            Return _mHIAPOANo
        End Get
        Set(value As String)
            _mHIAPOANo = value
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

    Public Shared Property _pHPCab_Validity() As String
        Get
            Return _mHPCab_Validity
        End Get
        Set(value As String)
            _mHPCab_Validity = value
        End Set
    End Property

    Public Shared Property _pHPCabLicNo() As String
        Get
            Return _mHPCabLicNo
        End Get
        Set(value As String)
            _mHPCabLicNo = value
        End Set
    End Property

    Public Shared Property _pHPRC_Date_ISS() As String
        Get
            Return _mHPRC_Date_ISS
        End Get
        Set(value As String)
            _mHPRC_Date_ISS = value
        End Set
    End Property

    Public Shared Property _pHPRC_Place_Issued() As String
        Get
            Return _mHPRC_Place_Issued
        End Get
        Set(value As String)
            _mHPRC_Place_Issued = value
        End Set
    End Property

    Public Shared Property _pHPRCNo() As String
        Get
            Return _mHPRCNo
        End Get
        Set(value As String)
            _mHPRCNo = value
        End Set
    End Property

    Public Shared Property _pHPTR_Date_ISS() As String
        Get
            Return _mHPTR_Date_ISS
        End Get
        Set(value As String)
            _mHPTR_Date_ISS = value
        End Set
    End Property

    Public Shared Property _pHPTR_PLc_ISS() As String
        Get
            Return _mHPTR_PLc_ISS
        End Get
        Set(value As String)
            _mHPTR_PLc_ISS = value
        End Set
    End Property

    Public Shared Property _pHPTRNo() As String
        Get
            Return _mHPTRNo
        End Get
        Set(value As String)
            _mHPTRNo = value
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
            _nStrSql = "insert into hist_proextn1 select * from proextn1 where idcode = '" & IDCode & "'"
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
                _nStrSql = "EXEC [sp_ProExtn1_IUD] " & _
               "@Action = 'INSERT' " & _
               ",@DateApplied = N'" & _mDateApplied & "'" & _
               ",@DateEncoded = N'" & _mDateEncoded & "'" & _
               ",@EncoderID = N'" & _mEncoderID & "'" & _
               ",@IAPO_ORNo = N'" & _mIAPO_ORNo & "'" & _
               ",@IAPOA_Date_ISS = N'" & _mIAPOA_Date_ISS & "'" & _
               ",@IAPOANo = N'" & _mIAPOANo & "'" & _
               ",@IDCode = N'" & _mIDCode & "'" & _
               ",@PCab_Validity = N'" & _mPCab_Validity & "'" & _
               ",@PCabLicNo = N'" & _mPCabLicNo & "'" & _
               ",@PRC_Date_ISS = N'" & _mPRC_Date_ISS & "'" & _
               ",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
               ",@PRCNo = N'" & _mPRCNo & "'" & _
               ",@PTR_Date_ISS = N'" & _mPTR_Date_ISS & "'" & _
               ",@PTR_PLc_ISS = N'" & _mPTR_PLc_ISS & "'" & _
               ",@PTRNo = N'" & _mPTRNo & "'" & _
               ",@Successful = @Successful output " & _
               ",@ErrMsg = @ErrMsg output  "

                '_nStrSql = "EXEC [sp_ProExtn1_IUD] " & _
                '"@Action = 'INSERT' " & _
                '",@DateApplied = N'" & _mDateApplied & "'" & _
                '",@DateEncoded = N'" & _mDateEncoded & "'" & _
                '",@EncoderID = N'" & _mEncoderID & "'" & _
                '",@IAPO_ORNo = N'" & _mIAPO_ORNo & "'" & _
                '",@IAPOA_Date_ISS = N'" & _mIAPOA_Date_ISS & "'" & _
                '",@IAPOANo = N'" & _mIAPOANo & "'" & _
                '",@IDCode = N'" & _mIDCode & "'" & _
                '",@PCab_Validity = N'" & _mPCab_Validity & "'" & _
                '",@PCabLicNo = N'" & _mPCabLicNo & "'" & _
                '",@PRC_Date_ISS = N'" & _mPRC_Date_ISS & "'" & _
                '",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
                '",@PRCNo = N'" & _mPRCNo & "'" & _
                '",@PTR_Date_ISS = N'" & _mPTR_Date_ISS & "'" & _
                '",@PTR_PLc_ISS = N'" & _mPTR_PLc_ISS & "'" & _
                '",@PTRNo = N'" & _mPTRNo & "'" & _
                '",@Successful = @Successful output " & _
                '",@ErrMsg = @ErrMsg output  "

            Else
                _nStrSql = "EXEC [sp_ProExtn1_IUD] " & _
              "@Action = 'UPDATE' " & _
              ",@SelectCond = N'" & _nSelectCond & "'" & _
              ",@DateApplied = N'" & _mDateApplied & "'" & _
               ",@DateEncoded = N'" & _mDateEncoded & "'" & _
               ",@EncoderID = N'" & _mEncoderID & "'" & _
               ",@IAPO_ORNo = N'" & _mIAPO_ORNo & "'" & _
               ",@IAPOA_Date_ISS = N'" & _mIAPOA_Date_ISS & "'" & _
               ",@IAPOANo = N'" & _mIAPOANo & "'" & _
               ",@IDCode = N'" & _mIDCode & "'" & _
               ",@PCab_Validity = N'" & _mPCab_Validity & "'" & _
               ",@PCabLicNo = N'" & _mPCabLicNo & "'" & _
               ",@PRC_Date_ISS = N'" & _mPRC_Date_ISS & "'" & _
               ",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
               ",@PRCNo = N'" & _mPRCNo & "'" & _
               ",@PTR_Date_ISS = N'" & _mPTR_Date_ISS & "'" & _
               ",@PTR_PLc_ISS = N'" & _mPTR_PLc_ISS & "'" & _
               ",@PTRNo = N'" & _mPTRNo & "'" & _
          ",@Successful = @Successful output " & _
          ",@ErrMsg = @ErrMsg output  "

                '    _nStrSql = "EXEC [sp_ProExtn1_IUD] " & _
                '    "@Action = 'UPDATE' " & _
                '    ",@SelectCond = N'" & _nSelectCond & "'" & _
                '    ",@DateApplied = N'" & _mDateApplied & "'" & _
                '    ",@DateEncoded = N'" & _mDateEncoded & "'" & _
                '    ",@EncoderID = N'" & _mEncoderID & "'" & _
                '    ",@IAPO_ORNo = N'" & _mIAPO_ORNo & "'" & _
                '    ",@IAPOA_Date_ISS = N'" & _mIAPOA_Date_ISS & "'" & _
                '    ",@IAPOANo = N'" & _mIAPOANo & "'" & _
                '    ",@IDCode = N'" & _mIDCode & "'" & _
                '    ",@PCab_Validity = N'" & _mPCab_Validity & "'" & _
                '    ",@PCabLicNo = N'" & _mPCabLicNo & "'" & _
                '    ",@PRC_Date_ISS = N'" & _mPRC_Date_ISS & "'" & _
                '    ",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
                '    ",@PRCNo = N'" & _mPRCNo & "'" & _
                '    ",@PTR_Date_ISS = N'" & _mPTR_Date_ISS & "'" & _
                '    ",@PTR_PLc_ISS = N'" & _mPTR_PLc_ISS & "'" & _
                '    ",@PTRNo = N'" & _mPTRNo & "'" & _
                '",@Successful = @Successful output " & _
                '",@ErrMsg = @ErrMsg output  "

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

    Public Shared Sub _pHSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            'If _mAdd Then
            _nStrSql = "EXEC [sp_HIST_ProExtn1_IUD] " & _
           "@Action = 'INSERT' " & _
           ",@DateApplied = N'" & _mHDateApplied & "'" & _
           ",@DateEncoded = N'" & _mHDateEncoded & "'" & _
           ",@EncoderID = N'" & _mHEncoderID & "'" & _
           ",@IAPO_ORNo = N'" & _mHIAPO_ORNo & "'" & _
           ",@IAPOA_Date_ISS = N'" & _mHIAPOA_Date_ISS & "'" & _
           ",@IAPOANo = N'" & _mHIAPOANo & "'" & _
           ",@IDCode = N'" & _mHIDCode & "'" & _
           ",@PCab_Validity = N'" & _mHPCab_Validity & "'" & _
           ",@PCabLicNo = N'" & _mHPCabLicNo & "'" & _
           ",@PRC_Date_ISS = N'" & _mHPRC_Date_ISS & "'" & _
           ",@PRC_Place_Issued = N'" & _mHPRC_Place_Issued & "'" & _
           ",@PRCNo = N'" & _mHPRCNo & "'" & _
           ",@PTR_Date_ISS = N'" & _mHPTR_Date_ISS & "'" & _
           ",@PTR_PLc_ISS = N'" & _mHPTR_PLc_ISS & "'" & _
           ",@PTRNo = N'" & _mHPTRNo & "'" & _
           ",@Successful = @Successful output " & _
           ",@ErrMsg = @ErrMsg output  "

            '_nStrSql = "EXEC [sp_ProExtn1_IUD] " & _
            '"@Action = 'INSERT' " & _
            '",@DateApplied = N'" & _mDateApplied & "'" & _
            '",@DateEncoded = N'" & _mDateEncoded & "'" & _
            '",@EncoderID = N'" & _mEncoderID & "'" & _
            '",@IAPO_ORNo = N'" & _mIAPO_ORNo & "'" & _
            '",@IAPOA_Date_ISS = N'" & _mIAPOA_Date_ISS & "'" & _
            '",@IAPOANo = N'" & _mIAPOANo & "'" & _
            '",@IDCode = N'" & _mIDCode & "'" & _
            '",@PCab_Validity = N'" & _mPCab_Validity & "'" & _
            '",@PCabLicNo = N'" & _mPCabLicNo & "'" & _
            '",@PRC_Date_ISS = N'" & _mPRC_Date_ISS & "'" & _
            '",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
            '",@PRCNo = N'" & _mPRCNo & "'" & _
            '",@PTR_Date_ISS = N'" & _mPTR_Date_ISS & "'" & _
            '",@PTR_PLc_ISS = N'" & _mPTR_PLc_ISS & "'" & _
            '",@PTRNo = N'" & _mPTRNo & "'" & _
            '",@Successful = @Successful output " & _
            '",@ErrMsg = @ErrMsg output  "

            'Else
            '      _nStrSql = "EXEC [sp_ProExtn1_IUD] " & _
            '    "@Action = 'UPDATE' " & _
            '    ",@SelectCond = N'" & _nSelectCond & "'" & _
            '    ",@DateApplied = N'" & _mDateApplied & "'" & _
            '     ",@DateEncoded = N'" & _mDateEncoded & "'" & _
            '     ",@EncoderID = N'" & _mEncoderID & "'" & _
            '     ",@IAPO_ORNo = N'" & _mIAPO_ORNo & "'" & _
            '     ",@IAPOA_Date_ISS = N'" & _mIAPOA_Date_ISS & "'" & _
            '     ",@IAPOANo = N'" & _mIAPOANo & "'" & _
            '     ",@IDCode = N'" & _mIDCode & "'" & _
            '     ",@PCab_Validity = N'" & _mPCab_Validity & "'" & _
            '     ",@PCabLicNo = N'" & _mPCabLicNo & "'" & _
            '     ",@PRC_Date_ISS = N'" & _mPRC_Date_ISS & "'" & _
            '     ",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
            '     ",@PRCNo = N'" & _mPRCNo & "'" & _
            '     ",@PTR_Date_ISS = N'" & _mPTR_Date_ISS & "'" & _
            '     ",@PTR_PLc_ISS = N'" & _mPTR_PLc_ISS & "'" & _
            '     ",@PTRNo = N'" & _mPTRNo & "'" & _
            '",@Successful = @Successful output " & _
            '",@ErrMsg = @ErrMsg output  "

            '    _nStrSql = "EXEC [sp_ProExtn1_IUD] " & _
            '    "@Action = 'UPDATE' " & _
            '    ",@SelectCond = N'" & _nSelectCond & "'" & _
            '    ",@DateApplied = N'" & _mDateApplied & "'" & _
            '    ",@DateEncoded = N'" & _mDateEncoded & "'" & _
            '    ",@EncoderID = N'" & _mEncoderID & "'" & _
            '    ",@IAPO_ORNo = N'" & _mIAPO_ORNo & "'" & _
            '    ",@IAPOA_Date_ISS = N'" & _mIAPOA_Date_ISS & "'" & _
            '    ",@IAPOANo = N'" & _mIAPOANo & "'" & _
            '    ",@IDCode = N'" & _mIDCode & "'" & _
            '    ",@PCab_Validity = N'" & _mPCab_Validity & "'" & _
            '    ",@PCabLicNo = N'" & _mPCabLicNo & "'" & _
            '    ",@PRC_Date_ISS = N'" & _mPRC_Date_ISS & "'" & _
            '    ",@PRC_Place_Issued = N'" & _mPRC_Place_Issued & "'" & _
            '    ",@PRCNo = N'" & _mPRCNo & "'" & _
            '    ",@PTR_Date_ISS = N'" & _mPTR_Date_ISS & "'" & _
            '    ",@PTR_PLc_ISS = N'" & _mPTR_PLc_ISS & "'" & _
            '    ",@PTRNo = N'" & _mPTRNo & "'" & _
            '",@Successful = @Successful output " & _
            '",@ErrMsg = @ErrMsg output  "

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
            _nStrSql = "EXEC [sp_ProExtn1_IUD] " & _
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
