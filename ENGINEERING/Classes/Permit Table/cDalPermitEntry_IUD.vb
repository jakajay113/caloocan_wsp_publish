Imports System.Data.SqlClient

Public Class CDalPermitEntry_IUD
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable

#End Region

#Region "Variable Field"
    Private Shared _mAdd As Boolean
    Private Shared _mEMS_AcctNo As String
    Private Shared _mEMS_SubAcctNo As String
    Private Shared _mApplicationNo As String
    Private Shared _mPermit_Type As String
    Private Shared _mPermit_Desc As String
    Private Shared _mOcc_Code As String
    Private Shared _mPermitNo As String
    Private Shared _mPermitDate_Iss As String
    Private Shared _mORNo As String
    Private Shared _mORDate As String
    Private Shared _mAmt_pd As String
    Private Shared _mPermit_Issby As String
    Private Shared _mPermit_Apprby As String
    Private Shared _mPermitDate_Signed As String
    Private Shared _mEncoded_By As String
    Private Shared _mDate_Encoded As String
    Private Shared _mPermitExpired As String
    Private Shared _mQuery As String
    Public Shared _mRptName As String

    Private Shared _mBldgPermitNo As String
    Private Shared _mBldgPermitDateIss As String
    Private Shared _mBldgORNo As String
    Private Shared _mORDateIss As String
    Private Shared _mApplicantOwner As String
    Private Shared _mOccupancyType As String
    Private Shared _mOccupancyDesc As String
    Private Shared _mOccupancyUse As String
    Private Shared _mOccupancyUseDesc As String

    Private Shared _mLocLotNo As String
    Private Shared _mLocTCTNo As String
    Private Shared _mLocStrt_Brgy As String
    Private Shared _mLocMunicipality As String
    Private Shared _mLocBlockNo As String

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



    Public Shared Property _pEMS_AcctNo() As String
        Get
            Return _mEMS_AcctNo
        End Get
        Set(value As String)
            _mEMS_AcctNo = value
        End Set
    End Property

    Public Shared Property _pEMS_SubAcctNo() As String
        Get
            Return _mEMS_SubAcctNo
        End Get
        Set(value As String)
            _mEMS_SubAcctNo = value
        End Set
    End Property


    Public Shared Property _pApplicationNo() As String
        Get
            Return _mApplicationNo
        End Get
        Set(value As String)
            _mApplicationNo = value
        End Set
    End Property

    Public Shared Property _pPermit_Type() As String
        Get
            Return _mPermit_Type
        End Get
        Set(value As String)
            _mPermit_Type = value
        End Set
    End Property

    Public Shared Property _pPermit_Desc() As String
        Get
            Return _mPermit_Desc
        End Get
        Set(value As String)
            _mPermit_Desc = value
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

    Public Shared Property _pPermitNo() As String
        Get
            Return _mPermitNo
        End Get
        Set(value As String)
            _mPermitNo = value
        End Set
    End Property

    Public Shared Property _pPermitDate_Iss() As String
        Get
            Return _mPermitDate_Iss
        End Get
        Set(value As String)
            _mPermitDate_Iss = value
        End Set
    End Property

    Public Shared Property _pORNo() As String
        Get
            Return _mORNo
        End Get
        Set(value As String)
            _mORNo = value
        End Set
    End Property

    Public Shared Property _pORDate() As String
        Get
            Return _mORDate
        End Get
        Set(value As String)
            _mORDate = value
        End Set
    End Property

    Public Shared Property _pAmt_pd() As Decimal
        Get
            Return _mAmt_pd
        End Get
        Set(value As Decimal)
            _mAmt_pd = value
        End Set
    End Property

    Public Shared Property _pPermit_Issby() As String
        Get
            Return _mPermit_Issby
        End Get
        Set(value As String)
            _mPermit_Issby = value
        End Set
    End Property


    Public Shared Property _pPermit_Apprby() As String
        Get
            Return _mPermit_Apprby
        End Get
        Set(value As String)
            _mPermit_Apprby = value
        End Set
    End Property

    Public Shared Property _pPermitDate_Signed() As String
        Get
            Return _mPermitDate_Signed
        End Get
        Set(value As String)
            _mPermitDate_Signed = value
        End Set
    End Property

    Public Shared Property _pEncoded_By() As String
        Get
            Return _mEncoded_By
        End Get
        Set(value As String)
            _mEncoded_By = value
        End Set
    End Property

    Public Shared Property _pDate_Encoded() As String
        Get
            Return _mDate_Encoded
        End Get
        Set(value As String)
            _mDate_Encoded = value
        End Set
    End Property


    Public Shared Property _pQuery() As String
        Get
            Return _mDate_Encoded
        End Get
        Set(value As String)
            _mDate_Encoded = value
        End Set
    End Property

    Public Shared Property _pPermitExpired() As String
        Get
            Return _mPermitExpired
        End Get
        Set(value As String)
            _mPermitExpired = value
        End Set
    End Property

    Public Shared Property _pBldgPermitNo() As String
        Get
            Return _mBldgPermitNo
        End Get
        Set(value As String)
            _mBldgPermitNo = value
        End Set
    End Property

    Public Shared Property _pBldgPermitDateIss() As String
        Get
            Return _mBldgPermitDateIss
        End Get
        Set(value As String)
            _mBldgPermitDateIss = value
        End Set
    End Property

    Public Shared Property _pBldgORNo() As String
        Get
            Return _mBldgORNo
        End Get
        Set(value As String)
            _mBldgORNo = value
        End Set
    End Property

    Public Shared Property _pORDateIss() As String
        Get
            Return _mORDateIss
        End Get
        Set(value As String)
            _mORDateIss = value
        End Set
    End Property

    Public Shared Property _pApplicantOwner() As String
        Get
            Return _mApplicantOwner
        End Get
        Set(value As String)
            _mApplicantOwner = value
        End Set
    End Property

    Public Shared Property _pOccupancyType() As String
        Get
            Return _mOccupancyType
        End Get
        Set(value As String)
            _mOccupancyType = value
        End Set
    End Property

    Public Shared Property _pOccupancyDesc() As String
        Get
            Return _mOccupancyDesc
        End Get
        Set(value As String)
            _mOccupancyDesc = value
        End Set
    End Property

    Public Shared Property _pOccupancyUse() As String
        Get
            Return _mOccupancyUse
        End Get
        Set(value As String)
            _mOccupancyUse = value
        End Set
    End Property

    Public Shared Property _pOccupancyUseDesc() As String
        Get
            Return _mOccupancyUseDesc
        End Get
        Set(value As String)
            _mOccupancyUseDesc = value
        End Set
    End Property

    Public Shared Property _pLocLotNo() As String
        Get
            Return _mLocLotNo
        End Get
        Set(value As String)
            _mLocLotNo = value
        End Set
    End Property

    Public Shared Property _pLocTCTNo() As String
        Get
            Return _mLocTCTNo
        End Get
        Set(value As String)
            _mLocTCTNo = value
        End Set
    End Property

    Public Shared Property _pLocStrt_Brgy() As String
        Get
            Return _mLocStrt_Brgy
        End Get
        Set(value As String)
            _mLocStrt_Brgy = value
        End Set
    End Property

    Public Shared Property _pLocMunicipality() As String
        Get
            Return _mLocMunicipality
        End Get
        Set(value As String)
            _mLocMunicipality = value
        End Set
    End Property
    Public Shared Property _pLocBlockNo() As String
        Get
            Return _mLocBlockNo
        End Get
        Set(value As String)
            _mLocBlockNo = value
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
            _mQuery = "Select  " & _nColumns & " from Permit " & _nCondition

            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            Using sdr As SqlDataReader = _mSqlCmd.ExecuteReader()

                'Load DataReader into the DataTable.
                _mDataTable.Clear()
                _mDataTable.Load(sdr)
                _nRecCount = _mDataTable.Rows.Count
                sdr.Dispose()
                _mSqlCmd.Dispose()
            End Using



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub _pSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String = ""
            Dim _nSelectCond As String = ""
            'Initialize String SQL


            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                _nStrSql = "EXEC [sp_Permit_IUD] " & _
                          "@Action = 'INSERT' " & _
                          ",@EMS_AcctNo = N'" & _mEMS_AcctNo & "'" & _
                          ",@EMS_SubAcctNo = N'" & _mEMS_SubAcctNo & "'" & _
                          ",@ApplicationNo = N'" & _mApplicationNo & "'" & _
                          ",@Bldg_PermitNo = N'" & _mBldgPermitNo & "'" & _
                          ",@Permit_Type = N'" & _mPermit_Type & "'" & _
                          ",@Permit_Desc = N'" & _mPermit_Desc & "'" & _
                          ",@Occ_Code = N'" & _mOcc_Code & "'" & _
                          ",@PermitNo = N'" & _mPermitNo & "'" & _
                          ",@PermitDate_Iss = N'''" & _mPermitDate_Iss & "'''" & _
                          ",@ORNo = N'" & _mORNo & "'" & _
                            ",@ORDate = N'''" & _mORDate & "'''" & _
                          ",@Amt_pd = N'" & _mAmt_pd & "'" & _
                          ",@Permit_Issby = N'" & _mPermit_Issby & "'" & _
                          ",@Permit_Apprby = N'" & _mPermit_Apprby & "'" & _
                          ",@PermitDate_Signed = N'''" & _mPermitDate_Signed & "'''" & _
                          ",@Encoded_By = N'" & _mEncoded_By & "'" & _
                            ",@Date_Encoded = N'''" & _mDate_Encoded & "'''" & _
                                  ",@PermitExpired = N'''" & _mPermitExpired & "'''" & _
                          ",@Successful = @Successful output " & _
                          ",@ErrMsg = @ErrMsg output  "

            Else
                _nStrSql = "EXEC [sp_Permit_IUD] " & _
                           "@Action = 'UPDATE' " & _
                           ",@SelectCond = N'" & _nSelectCond & "'" & _
                            ",@EMS_AcctNo = N'" & _mEMS_AcctNo & "'" & _
                          ",@EMS_SubAcctNo = N'" & _mEMS_SubAcctNo & "'" & _
                          ",@ApplicationNo = N'" & _mApplicationNo & "'" & _
                          ",@Bldg_PermitNo = N'" & _mBldgPermitNo & "'" & _
                          ",@Permit_Type = N'" & _mPermit_Type & "'" & _
                          ",@Permit_Desc = N'" & _mPermit_Desc & "'" & _
                          ",@Occ_Code = N'" & _mOcc_Code & "'" & _
                          ",@PermitNo = N'" & _mPermitNo & "'" & _
                          ",@PermitDate_Iss = N'" & _mPermitDate_Iss & "'" & _
                          ",@ORNo = N'" & _mORNo & "'" & _
                            ",@ORDate = N'" & _mORDate & "'" & _
                          ",@Amt_pd = N'" & _mAmt_pd & "'" & _
                          ",@Permit_Issby = N'" & _mPermit_Issby & "'" & _
                          ",@Permit_Apprby = N'" & _mPermit_Apprby & "'" & _
                          ",@PermitDate_Signed = N'" & _mPermitDate_Signed & "'" & _
                          ",@Encoded_By = N'" & _mEncoded_By & "'" & _
                            ",@Date_Encoded = N'" & _mDate_Encoded & "'" & _
                              ",@PermitExpired = N'" & _mPermitExpired & "'" & _
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
                        '           _mCode = _nSqlDr.Item(0).ToString

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
            _nStrSql = "EXEC [sp_Permit_IUD] " & _
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