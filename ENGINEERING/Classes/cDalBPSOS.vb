
#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region
Public Class cDalBPSOS

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mQuery2 As String = Nothing
    Private _mTempTblBT As String
    Private _mSqlCommand As SqlCommand
    Private _mSqlCommand2 As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader
    Public Shared _nOutput As String
    Public Shared _nBusDesc As String
    Public Shared _nOwner As String
    Public Shared _nEmail As String
    Public Shared _nBusName As String
    Public Shared _nBusAddress As String
    Public Shared _nBusCategory As String
    Public Shared _nBusCategory1 As String
    Public Shared _nPrevGross As Double
    Public Shared _nArea As Double
    Public Shared _nTotalDue As Double
    Public Shared _nBusCode As String
    Public Shared _nLastName As String
    Public Shared _nFirstName As String
    Public Shared _nMidName As String
    Public Shared _nGender As String
    Public Shared _nSuffix As String
    Public Shared _nOwnerAdd As String
    Public Shared _nCommAdd As String
    Public Shared _nCommName As String
    Public Shared _nBrgy As String
    Public Shared _nCommBrgy As String
    Public Shared _nZipCode As String
    Public Shared _nCommZipCode As String
    Public Shared _nCpNo As String
    Public Shared _nTelNo As String
    Public Shared _nEmailNo As String
    Public Shared _nTotalGross As String
    Public Shared _nSTQuery As String
    Public Shared _nCurYear As String
    Public Shared _nCurMonth As String
    Public Shared _nCurDate As String
    Public Shared _mShareAcctNo As String

    ''Public Shared _nTempTbl As String = "temp_" & cSessionUser._pUserID.Replace(".", "")
    ''Public Shared _nTempTblASKHDG As String = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
    ''Public Shared _nTempTblQTY As String = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
    ''Public Shared _nTempTblOPT As String = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

    'Private connetionString As String
    'Private Shared connection As SqlConnection
    'Private Shared sql As String
#End Region

#Region "Properties Data"


    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property
    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------

                _mSqlDataReader = _mSqlCommand.ExecuteReader
                Return _mSqlDataReader

                '----------------------------------
            Catch ex As Exception

                Return Nothing
            End Try
        End Get
    End Property
#End Region

#Region "Variables Field"

    Private _mFieldsWhere As String
    Private _mAcctNo As String
    Private _mORNo As String
    Private _mBusCode As String
    Private _mTaxCode As String
    Private _mEmail As String
    Private _mEmail2 As String
    Private _mLocServer As String
    Private _mLocDB As String
    Private _mStatus As String
    Private _mGross As Double
    Private _mPrevGross As Double
    Private _mArea As Double
    Private _mForYear As String
    Private _mQtr As String
    Private _mDeliver As String
    Private _mPeriod As String
    Private _mRemarks As String
    Private _mGrossDetail As String
    Private _mTempGross As String
    Private _mReferenceNo As String
    Private _mAmountPaid As Double
    Private _mLQP As String
    Private _mDatePaid As String
    Private _mQtrPaid As String
    Private _mMonth As String
    Private _mTempTbl As String
    Private _mASKHDG As String
    Private _mXValue As String
    Private _mXSelected As String
    Private _mSOAno As String
    Private _nTempTbl As String
    Private _nTempTblASKHDG As String
    Private _nTempTblQTY As String
    Private _nTempTblOPT As String
    Private _mToimsServer As String
    Private _mToimsDB As String
    Private _mMOP As String
    '---- Added by Archie 20200915
    Private Shared _mFile1Name As String
    Private Shared _mFile1Type As String
    Private Shared _mFile1Data As Byte()
    Private Shared _mFile2Name As String
    Private Shared _mFile2Type As String
    Private Shared _mFile2Data As Byte()
    Private Shared _mFile3Name As String
    Private Shared _mFile3Type As String
    Private Shared _mFile3Data As Byte()
    Private Shared _mFile4Name As String
    Private Shared _mFile4Type As String
    Private Shared _mFile4Data As Byte()


#End Region

#Region "Properties Field"


    Public Property _pMOP() As String
        Get
            Return _mMOP
        End Get
        Set(ByVal value As String)
            _mMOP = value
        End Set
    End Property

    Public Property _pToimsServer() As String
        Get
            Return _mToimsServer
        End Get
        Set(ByVal value As String)
            _mToimsServer = value
        End Set
    End Property
    Public Property _pEmail2() As String
        Get
            Return _mEmail2
        End Get
        Set(ByVal value As String)
            _mEmail2 = value
        End Set
    End Property
    Public Property _pToimsDB() As String
        Get
            Return _mToimsDB
        End Get
        Set(ByVal value As String)
            _mToimsDB = value
        End Set
    End Property

    Public Property _pnTempTbl() As String
        Get
            Return _nTempTbl
        End Get
        Set(ByVal value As String)
            _nTempTbl = value
        End Set
    End Property

    Public Property _pnTempTblASKHDG() As String
        Get
            Return _nTempTblASKHDG
        End Get
        Set(ByVal value As String)
            _nTempTblASKHDG = value
        End Set
    End Property

    Public Property _pnTempTblQTY() As String
        Get
            Return _nTempTblQTY
        End Get
        Set(ByVal value As String)
            _nTempTblQTY = value
        End Set
    End Property

    Public Property _pnTempTblOPT() As String
        Get
            Return _nTempTblOPT
        End Get
        Set(ByVal value As String)
            _nTempTblOPT = value
        End Set
    End Property

    Public Property _pSOAno() As String
        Get
            Return _mSOAno
        End Get
        Set(ByVal value As String)
            _mSOAno = value
        End Set
    End Property


    Public Property _pXValue() As String
        Get
            Return _mXValue
        End Get
        Set(ByVal value As String)
            _mXValue = value
        End Set
    End Property

    Public Property _pXSelected() As String
        Get
            Return _mXSelected
        End Get
        Set(ByVal value As String)
            _mXSelected = value
        End Set
    End Property


    Public Property _pASKHDG() As String
        Get
            Return _mASKHDG
        End Get
        Set(ByVal value As String)
            _mASKHDG = value
        End Set
    End Property

    Public Property _pTempTbl() As String
        Get
            Return _mTempTbl
        End Get
        Set(ByVal value As String)
            _mTempTbl = value
        End Set
    End Property


    Public Property _pMonth() As String
        Get
            Return _mMonth
        End Get
        Set(ByVal value As String)
            _mMonth = value
        End Set
    End Property

    Public Property _pTaxCode() As String
        Get
            Return _mTaxCode
        End Get
        Set(ByVal value As String)
            _mTaxCode = value
        End Set
    End Property


    Public Property _pQtrPaid() As String
        Get
            Return _mQtrPaid
        End Get
        Set(ByVal value As String)
            _mQtrPaid = value
        End Set
    End Property

    Public Property _pDatePaid() As String
        Get
            Return _mDatePaid
        End Get
        Set(ByVal value As String)
            _mDatePaid = value
        End Set
    End Property

    Public Property _pLQP() As String
        Get
            Return _mLQP
        End Get
        Set(ByVal value As String)
            _mLQP = value
        End Set
    End Property
    Public Property _pAmountPaid() As Double
        Get
            Return _mAmountPaid
        End Get
        Set(ByVal value As Double)
            _mAmountPaid = value
        End Set
    End Property
    Public Property _pFieldsWhere() As String
        Get
            Return _mFieldsWhere
        End Get
        Set(ByVal value As String)
            _mFieldsWhere = value
        End Set
    End Property

    Public Property _pAcctNo() As String
        Get
            Return _mAcctNo
        End Get
        Set(ByVal value As String)
            _mAcctNo = value
        End Set
    End Property

    Public Property _pORNo() As String
        Get
            Return _mORNo
        End Get
        Set(ByVal value As String)
            _mORNo = value
        End Set
    End Property


    Public Property _pQtr() As String
        Get
            Return _mQtr
        End Get
        Set(ByVal value As String)
            _mQtr = value
        End Set
    End Property
    Public Property _pReferenceNo() As String
        Get
            Return _mReferenceNo
        End Get
        Set(ByVal value As String)
            _mReferenceNo = value
        End Set
    End Property
    Public Property _pGrossDetail() As String
        Get
            Return _mGrossDetail
        End Get
        Set(ByVal value As String)
            _mGrossDetail = value
        End Set
    End Property
    Public Property _pTempGross() As String
        Get
            Return _mTempGross
        End Get
        Set(ByVal value As String)
            _mTempGross = value
        End Set
    End Property


    Public Property _pDeliver() As String
        Get
            Return _mDeliver
        End Get
        Set(ByVal value As String)
            _mDeliver = value
        End Set
    End Property

    Public Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(ByVal value As String)
            _mForYear = value
        End Set
    End Property
    Public Property _pPeriod() As String
        Get
            Return _mPeriod
        End Get
        Set(ByVal value As String)
            _mPeriod = value
        End Set
    End Property
    Public Property _pRemarks() As String
        Get
            Return _mRemarks
        End Get
        Set(ByVal value As String)
            _mRemarks = value
        End Set
    End Property

    Public Property _pEmail() As String
        Get
            Return _mEmail
        End Get
        Set(ByVal value As String)
            _mEmail = value
        End Set
    End Property
    Public Property _pLocServer() As String
        Get
            Return _mLocServer
        End Get
        Set(ByVal value As String)
            _mLocServer = value
        End Set
    End Property
    Public Property _pTempTblBT() As String
        Get
            Return _mTempTblBT
        End Get
        Set(ByVal value As String)
            _mTempTblBT = value
        End Set
    End Property

    Public Property _pLocDB() As String
        Get
            Return _mLocDB
        End Get
        Set(ByVal value As String)
            _mLocDB = value
        End Set
    End Property

    Public Property _pStatus() As String
        Get
            Return _mStatus
        End Get
        Set(ByVal value As String)
            _mStatus = value
        End Set
    End Property


    Public Property _pBusCode() As String
        Get
            Return _mBusCode
        End Get
        Set(ByVal value As String)
            _mBusCode = value
        End Set
    End Property

    Public Property _pGross() As Double
        Get
            Return _mGross
        End Get
        Set(ByVal value As Double)
            _mGross = value
        End Set
    End Property

    Public Property _pPrevGross() As Double
        Get
            Return _mPrevGross
        End Get
        Set(ByVal value As Double)
            _mPrevGross = value
        End Set
    End Property
    Public Property _pArea() As Double
        Get
            Return _mArea
        End Get
        Set(ByVal value As Double)
            _mArea = value
        End Set
    End Property
    '----------- Added by Archie 20200916
    Public Shared Property _pFile1Name() As String
        Get
            Return _mFile1Name
        End Get
        Set(value As String)
            _mFile1Name = value
        End Set
    End Property
    Public Shared Property _pFile1Type() As String
        Get
            Return _mFile1Type
        End Get
        Set(value As String)
            _mFile1Type = value
        End Set
    End Property
    Public Shared Property _pFile1Data() As Byte()
        Get
            Return _mFile1Data
        End Get
        Set(value As Byte())
            _mFile1Data = value
        End Set
    End Property

    Public Shared Property _pFile2Name() As String
        Get
            Return _mFile2Name
        End Get
        Set(value As String)
            _mFile2Name = value
        End Set
    End Property
    Public Shared Property _pFile2Type() As String
        Get
            Return _mFile2Type
        End Get
        Set(value As String)
            _mFile2Type = value
        End Set
    End Property
    Public Shared Property _pFile2Data() As Byte()
        Get
            Return _mFile2Data
        End Get
        Set(value As Byte())
            _mFile2Data = value
        End Set
    End Property

    Public Shared Property _pFile3Name() As String
        Get
            Return _mFile3Name
        End Get
        Set(value As String)
            _mFile3Name = value
        End Set
    End Property
    Public Shared Property _pFile3Type() As String
        Get
            Return _mFile3Type
        End Get
        Set(value As String)
            _mFile3Type = value
        End Set
    End Property
    Public Shared Property _pFile3Data() As Byte()
        Get
            Return _mFile3Data
        End Get
        Set(value As Byte())
            _mFile3Data = value
        End Set
    End Property

    Public Shared Property _pFile4Name() As String
        Get
            Return _mFile4Name
        End Get
        Set(value As String)
            _mFile4Name = value
        End Set
    End Property
    Public Shared Property _pFile4Type() As String
        Get
            Return _mFile4Type
        End Get
        Set(value As String)
            _mFile4Type = value
        End Set
    End Property
    Public Shared Property _pFile4Data() As Byte()
        Get
            Return _mFile4Data
        End Get
        Set(value As Byte())
            _mFile4Data = value
        End Set
    End Property
#End Region

    Public Shared Sub ClearAttachedFile()
        _pFile1Name = Nothing
        _pFile1Type = Nothing
        _pFile1Data = Nothing
        _pFile2Name = Nothing
        _pFile2Type = Nothing
        _pFile2Data = Nothing
        _pFile3Name = Nothing
        _pFile3Type = Nothing
        _pFile3Data = Nothing
        _pFile4Name = Nothing
        _pFile4Type = Nothing
        _pFile4Data = Nothing
    End Sub

    ''-----------------------------------------------------------------------May 12,2021 

    Public Sub _pDisplayLogo()


        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = _
              " Select LGU_LOGO from LGU_Profile "


            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            '_mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'With _mSqlCommand.Parameters

            '    If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)

            'End With

            'karlo 20180411
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Public Sub _pSubSelectPrevGross()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            ' ''----------------------------------    
            ''_nQuery = _
            ''   "SELECT  top 1 ACCTNO,GROSSREC,AREA,BUSCODE.DESCRIPTION  as BUSDESC,BUSLINE.BUS_CODE from BUSLINE " & _
            ''    " INNER JOIN BUSCODE " & _
            ''    " ON BUSLINE.BUS_CODE = BUSCODE.BUS_CODE " & _
            ''    " WHERE ACCTNO = '" & _mAcctNo & "' and foryear < '" & Year(Today) & "' " & _
            ''    " order by foryear desc "


            '----------------------------------    
            _nQuery = _
               "SELECT   ACCTNO,SUM(GROSSREC) GROSSREC,SUM(AREA) AREA,dbo.Get_Category_Line_Ledger(ACCTNO,FORYEAR,'2')  as BUSDESC from BUSLINE " & _
                " INNER JOIN BUSCODE " & _
                " ON BUSLINE.BUS_CODE = BUSCODE.BUS_CODE " & _
                " WHERE ACCTNO = '" & _mAcctNo & "' and foryear  = (select top 1 foryear from busline where acctno = '" & _mAcctNo & "' and foryear <  Year(getdate())  order by foryear desc ) " & _
                " GROUP BY ACCTNO,FORYEAR"



            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nPrevGross = CDbl(_nSqlDr.Item("GROSSREC").ToString)
                    _nArea = CDbl(_nSqlDr.Item("AREA").ToString)
                    _nBusDesc = _nSqlDr.Item("BUSDESC").ToString
                    '_nBusCode = _nSqlDr.Item("BUS_CODE").ToString
                    ' Loop
                End If

            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubCheckEnroll()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [sp_GETACCT] '" & _mAcctNo & "','" & _mORNo & "','" & _mLocServer & "','" & _pLocDB & "','" & _mEmail & "','" & _mEmail2 & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubCheckBusline()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKBUSLINE] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "','" & _mTempTbl & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output


            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckAssessment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKPOSTING] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output


            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckSubmit()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKHASSUBMIT] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckhasPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKHASPAYMENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckGarbage()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKGARBAGE] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "','" & _mTempTbl & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubComputeTax()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nNewGross As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT BUSCODE, GROSS FROM [" & _mTempGross & "]"


            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)
            _mDataTable = New DataTable

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    _mDataTable.Load(_nSqlDr)
                    'Getting Record using reader

                    Dim i As Integer
                    For i = 0 To _mDataTable.Rows.Count - 1
                        _nNewGross = CDbl(_mDataTable.Rows(i).Item("GROSS").ToString)

                        _nQuery = _
                            "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mDataTable.Rows(i).Item("BUSCODE").ToString & "','" & _nNewGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "','" & _nTempTblASKHDG & "','" & _nTempTblQTY & "','" & _nTempTblOPT & "','" & _mQtrPaid & "','" & _mDataTable.Rows.Count & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                    Next


                    'Do While _nSqlDr.Read

                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubGetPenalty()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nBusCode As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT DISTINCT BUSCODE FROM [PAYMENT] WHERE ACCTNO = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' AND ISNULL(BUSCODE,'') <> ''  "


            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nBusCode = _nSqlDr.Item("BUSCODE").ToString

                        _nQuery = _
                            "exec [SP_GETPENALTY] '" & _mAcctNo & "','" & _mForYear & "','" & _nBusCode & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mQtrPaid & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetPayFileExtn()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim nRefNo As String
            Dim nORNo As String
            Dim nSRS As String
            Dim nForyear As String
            Dim nAcctNo As String
            '----------------------------------    



            _nQuery = _
                      "SELECT *,year(Date) as Foryear,(Select AcctNo from ledger where referenceno = TransactionNumber) as AcctNo FROM  [" & _mToimsServer & "].[" & _mToimsDB & "].dbo.[tmp_table_or] "


            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)

            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        nRefNo = _nSqlDr.Item("TransactionNumber").ToString
                        nORNo = _nSqlDr.Item("Or_number").ToString
                        nSRS = _nSqlDr.Item("SRS").ToString
                        nForyear = _nSqlDr.Item("Foryear").ToString
                        nAcctNo = _nSqlDr.Item("AcctNo").ToString

                        _nQuery = _
                            "exec [SP_SAVEPAYFILEEXTN] '" & cSessionUser._pUserID.Replace(".", "") & "','" & nAcctNo & "','" & nForyear & "','" & nORNo & "','" & nSRS & "','" & nRefNo & "','" & _mLocServer & "','" & _mLocDB & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlCommand2.CommandTimeout = 0
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    ''Public Sub _pSubGetPayFile()
    ''    Try
    ''        '----------------------------------
    ''        'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

    ''        '----------------------------------
    ''        Dim _nQuery As String = Nothing
    ''        Dim _nWhere As String = Nothing
    ''        Dim nRefNo As String
    ''        Dim nORNo As String
    ''        Dim nSRS As String
    ''        Dim nForyear As String
    ''        Dim nAcctNo As String
    ''        '----------------------------------    



    ''        _nQuery = _
    ''                  "SELECT *,year(Date) as Foryear,(Select AcctNo from [" & _mLocServer & "].[" & _mLocDB & "].dbo.ledger where referenceno = TransactionNumber) as AcctNo FROM  [" & _mToimsServer & "].[" & _mToimsDB & "].dbo.[tmp_table_or] "


    ''        '----------------------------------    
    ''        ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

    ''        ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

    ''        ''Else
    ''        ''    _nWhere = Nothing
    ''        ''End If

    ''        '----------------------------------
    ''        _mQuery = _nQuery


    ''        '----------------------------------
    ''        _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

    ''        'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
    ''        '_mDataTable = New DataTable
    ''        '_nSqlDataAdapter.Fill(_mDataTable)


    ''        Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
    ''            ''  _nSqlDr.Read()
    ''            If _nSqlDr.HasRows Then
    ''                'Getting Record using reader
    ''                Do While _nSqlDr.Read
    ''                    nRefNo = _nSqlDr.Item("TransactionNumber").ToString
    ''                    nORNo = _nSqlDr.Item("Or_number").ToString
    ''                    nSRS = _nSqlDr.Item("SRS").ToString
    ''                    nForyear = _nSqlDr.Item("Foryear").ToString
    ''                    nAcctNo = _nSqlDr.Item("AcctNo").ToString

    ''                    _nQuery = _
    ''                        "exec [SP_SAVEPAYFILE] '','" & nAcctNo & "','" & nForyear & "','" & nORNo & "','" & nSRS & "','" & nRefNo & "','','','','','" & _mLocServer & "','" & _mLocDB & "'"
    ''                    _mQuery = _nQuery
    ''                    _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
    ''                    _mSqlDataReader = _mSqlCommand2.ExecuteReader
    ''                    _mSqlDataReader.Read()
    ''                    _mSqlCommand2.Dispose()

    ''                Loop
    ''            End If

    ''        End Using
    ''        _mSqlCommand.Dispose()


    ''        '----------------------------------
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

    Public Sub _pSubSAVETPGROSS()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nNewGross As String
            Dim _nBUSCODE As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT BUSCODE, GROSS FROM [" & _mTempGross & "]"


            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nNewGross = CDbl(_nSqlDr.Item("GROSS").ToString)
                        _nBUSCODE = _nSqlDr.Item("BUSCODE").ToString

                        _nQuery = _
                            "exec [SP_SAVETAXPAYERGROSS] '" & _mAcctNo & "','" & _nBUSCODE & "','" & _mForYear & "','" & _nNewGross & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSAVEBPLOGROSS()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nNewGross As String
            Dim _nBUSCODE As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT BUSCODE, GROSS FROM [" & _mTempGross & "]"


            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nNewGross = CDbl(_nSqlDr.Item("GROSS").ToString)
                        _nBUSCODE = _nSqlDr.Item("BUSCODE").ToString

                        _nQuery = _
                            "exec [SP_SAVEBPLORGROSS] '" & _mAcctNo & "','" & _nBUSCODE & "','" & _mForYear & "','" & _nNewGross & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubTotalGross()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nNewGross As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT BUSCODE, GROSS FROM [" & _mTempGross & "]"


            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)

            _nTotalGross = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nTotalGross = _nTotalGross + CDbl(_nSqlDr.Item("GROSS").ToString)


                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectEnroll()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT * FROM [BUSDETAIL] WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' AND VERIFIED = '1' " & _
               "AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM BUSDETAIL_TAXPAYER WHERE isnull(ISASSESS,0) ='1' AND FORYEAR = YEAR(GETDATE())) " & _
               "AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE FORYEAR = YEAR(GETDATE()) AND ISNULL(APPRV_TOP_ONLINE,0) = 1 ) " & _
               "AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.PAYFILE WHERE FORYEAR =  YEAR(GETDATE())) "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    ''Public Sub _pSubSelectForPayment()
    ''    Try
    ''        '----------------------------------
    ''        'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

    ''        '----------------------------------
    ''        Dim _nQuery As String = Nothing
    ''        Dim _nWhere As String = Nothing

    ''        '----------------------------------    
    ''        ''_nQuery = _
    ''        ''   "SELECT * FROM [BUSDETAIL] WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' AND VERIFIED = '1'  " & _
    ''        ''   "AND (ACCTNO IN (SELECT DISTINCT ACCTNO FROM BUSDETAIL_TAXPAYER WHERE isnull(ISASSESS,0) ='1' AND FORYEAR = '" & Year(Now) & "') " & _
    ''        ''   " OR ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE FORYEAR = '" & Year(Now) & "' ))"


    ''        _nQuery = _
    ''                 " SELECT BM.ACCTNO, (BM.LAST_NAME + ', ' + ISNULL(BM.FIRST_NAME,'') + ' '+ ISNULL(BM.MIDDLE_NAME,'')) as OWNER,BM.COMMNAME AS BUSNAME, BM.COMMADDR  AS BUSADDRESS " & _
    ''                 " ,STUFF((SELECT ' || ' + BC.[DESCRIPTION]  " & _
    ''                                   " FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.[BUSCODE] BC " & _
    ''                                   " INNER JOIN BUSLINE BL  " & _
    ''                                  "  ON BM.ACCTNO = BL.ACCTNO " & _
    ''                                   " WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND BM.ACCTNO = BL.ACCTNO " & _
    ''                                  "  FOR XML PATH('')), 1, 3, '') AS CATEGORY,'NEW' as STATUS " & _
    ''                         " FROM BUSMAST BM  " & _
    ''                         " INNER JOIN BUSMASTEXTN BMX " & _
    ''                         " ON BM.ACCTNO = BMX.ACCTNO  " & _
    ''                 " where BM.IsForPayment = 1  " & _
    ''                        "  AND BMX.FORYEAR = YEAR(GETDATE()) AND BM.EMAILADDR = '" & cSessionUser._pUserID & "'   " & _
    ''                 "  UNION " & _
    ''                      "    SELECT ACCTNO,OWNER,BUSNAME,BUSADDRESS,CATEGORY,  ISNULL((SELECT DISTINCT CASE WHEN STATCODE ='N' THEN 'NEW' ELSE 'RENEW' END as STATUS FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ACCTNO = [BUSDETAIL].ACCTNO  AND FORYEAR =  YEAR(GETDATE())),'RENEW') as STATUS  FROM [BUSDETAIL]  " & _
    ''                      "    WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' AND VERIFIED = '1'  AND (ACCTNO IN (SELECT DISTINCT ACCTNO FROM  " & _
    ''                 " BUSDETAIL_TAXPAYER " & _
    ''                       "   WHERE isnull(ISASSESS,0) ='1' AND FORYEAR = YEAR(GETDATE()))  OR  " & _
    ''                       "   ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE FORYEAR =  YEAR(GETDATE())))"

    ''        '----------------------------------    


    ''        '----------------------------------
    ''        _mQuery = _nQuery


    ''        '----------------------------------
    ''        _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

    ''        Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
    ''        _mDataTable = New DataTable
    ''        _nSqlDataAdapter.Fill(_mDataTable)

    ''        'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
    ''        'Using _nSqlDr
    ''        '    If _nSqlDr.HasRows Then
    ''        '        'Getting Record using reader
    ''        '        ' Do While _nSqlDr.Read
    ''        '        _mDataTable.Load(_nSqlDr)
    ''        '        '  Loop
    ''        '    End If
    ''        'End Using

    ''        Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
    ''            _nSqlDr.Read()
    ''            If _nSqlDr.HasRows Then
    ''                'Getting Record using reader
    ''                '  Do While _nSqlDr.Read
    ''                _nOwner = _nSqlDr.Item("OWNER").ToString
    ''                _nBusName = _nSqlDr.Item("BUSNAME").ToString
    ''                _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
    ''                _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
    ''                ' Loop
    ''            End If

    ''        End Using





    ''        '----------------------------------
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub
    Public Sub _pSubSelectForPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT * FROM [BUSDETAIL] WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' AND VERIFIED = '1'  " & _
            ''   "AND (ACCTNO IN (SELECT DISTINCT ACCTNO FROM BUSDETAIL_TAXPAYER WHERE isnull(ISASSESS,0) ='1' AND FORYEAR = '" & Year(Now) & "') " & _
            ''   " OR ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE FORYEAR = '" & Year(Now) & "' ))"


            _nQuery = _
                     " SELECT BM.ACCTNO, (BM.LAST_NAME + ', ' + ISNULL(BM.FIRST_NAME,'') + ' '+ ISNULL(BM.MIDDLE_NAME,'')) as OWNER,BM.COMMNAME AS BUSNAME, BM.COMMADDR  AS BUSADDRESS " & _
                     " ,STUFF((SELECT ' || ' + BC.[DESCRIPTION]  " & _
                                       " FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.[BUSCODE] BC " & _
                                       " INNER JOIN BUSLINE BL  " & _
                                      "  ON BM.ACCTNO = BL.ACCTNO " & _
                                       " WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND BM.ACCTNO = BL.ACCTNO " & _
                                      "  FOR XML PATH('')), 1, 3, '') AS CATEGORY,'NEW' as STATUS " & _
                             " FROM BUSMAST BM  " & _
                             " INNER JOIN BUSMASTEXTN BMX " & _
                             " ON BM.ACCTNO = BMX.ACCTNO  " & _
                     " where BM.IsForPayment = 1  " & _
                            "  AND BMX.FORYEAR = YEAR(GETDATE()) AND BM.EMAILADDR = '" & cSessionUser._pUserID & "'   " & _
                     "  UNION " & _
                          "    SELECT ACCTNO,OWNER,BUSNAME,BUSADDRESS,CATEGORY,  'RENEW' as STATUS  FROM [BUSDETAIL]  " & _
                          "    WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' AND VERIFIED = '1'  AND (ACCTNO IN (SELECT DISTINCT ACCTNO FROM  " & _
                     " BUSDETAIL_TAXPAYER " & _
                           "   WHERE isnull(ISASSESS,0) ='1' and FORYEAR =  YEAR(GETDATE()) AND ACCTNO IN (SELECT DISTINCT ACCTNO FROM  BUSDETAIL WHERE EMAIL = '" & cSessionUser._pUserID.Replace(".", "") & "') AND FORYEAR = YEAR(GETDATE()))  OR  " & _
                           "  ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 and FORYEAR =  YEAR(GETDATE()) )  OR  " & _
                           "  ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.PAYFILE WHERE FORYEAR =  YEAR(GETDATE())))"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectSubmitAcct()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '    "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) "
            ' _nQuery = _
            '"SELECT DISTINCT  B.*,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)   group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2 ORDER BY max(BT.DATESUBMIT)  "

            _nQuery = _
            "SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')   group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1 ORDER BY max(BT.DATESUBMIT)  "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectAssessAcct()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) DESC "
            '_nQuery = _
            '       "SELECT DISTINCT  B.*,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS   " & _
            '       " UNION SELECT DISTINCT  B.*,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE  BT.FORYEAR = '" & _mForYear & "'  AND BT.ACCTNO IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS ORDER BY max(BT.DATESUBMIT) DESC "
            '_nQuery = _
            '   "SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2, B.CATEGORY1,BT.ISASSESS   " & _
            '   " UNION SELECT DISTINCT B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE  BT.FORYEAR = '" & _mForYear & "'  AND BT.ACCTNO IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS, B.CATEGORY1 ORDER BY max(BT.DATESUBMIT) DESC "

            _nQuery = _
               "SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2, B.CATEGORY1,BT.ISASSESS   " & _
               " UNION SELECT DISTINCT B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B LEFT OUTER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE B.ACCTNO IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS, B.CATEGORY1 ORDER BY max(BT.DATESUBMIT) DESC "


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectEnrollInfo()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT * FROM [BUSDETAIL] WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' and ACCTNO = '" & _mAcctNo & "' "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetDetail()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT * FROM [BUSDETAIL] WHERE [ACCTNO] = '" & _mAcctNo & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    _nBusCategory1 = _nSqlDr.Item("CATEGORY1").ToString
                    _nEmail = _nSqlDr.Item("EMAIL2").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetDetailNewBusiness()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '   "SELECT * FROM [BUSDETAIL] WHERE [ACCTNO] = '" & _mAcctNo & "'"

            _nQuery = _
         " SELECT BM.ACCTNO, (BM.LAST_NAME + ', ' + ISNULL(BM.FIRST_NAME,'') + ' '+ ISNULL(BM.MIDDLE_NAME,'')) as OWNER,BM.COMMNAME AS BUSNAME, BM.COMMADDR  AS BUSADDRESS " & _
         " ,STUFF((SELECT ' || ' + BC.[DESCRIPTION]  " & _
                           " FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.[BUSCODE] BC " & _
                           " INNER JOIN BUSLINE BL  " & _
                          "  ON BM.ACCTNO = BL.ACCTNO " & _
                           " WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND BM.ACCTNO = BL.ACCTNO " & _
                          "  FOR XML PATH('')), 1, 3, '') AS CATEGORY,'NEW' as STATUS " & _
                 " FROM BUSMAST BM  " & _
                 " INNER JOIN BUSMASTEXTN BMX " & _
                 " ON BM.ACCTNO = BMX.ACCTNO  " & _
         " where BM.IsForPayment = 1  " & _
                "  AND BMX.FORYEAR = YEAR(GETDATE()) AND BM.EMAILADDR = '" & cSessionUser._pUserID & "' AND BM.[ACCTNO] = '" & _mAcctNo & "'   "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubShowBusDetailExtn()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,'' as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "' order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
            _nQuery = _
              "SELECT *,'' as GROSSINPUT FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubShowBusDetailExtn_PAYMENT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,'' as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "' order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
            _nQuery = _
              "SELECT * FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubShowBusDetailExtn3()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,'' as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "' order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
            _nQuery = _
              "SELECT ACCTNO, FORYEAR, BUSCODE, CATEGORY,CATEGORY1, CAPITAL, PREVGROSS, GROSSAMT, AREA, DATESUBMIT, ISASSESS, GROSSNEW  as GROSSINPUT FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubShowBusDetailExtn_TAXPAYER()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,'' as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "' order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
            _nQuery = _
              "SELECT *,'' as GROSSINPUT FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubShowBusDetail_TAXPAYER()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT  ACCTNO, FORYEAR, BUSCODE, CATEGORY,CATEGORY1, CAPITAL, PREVGROSS, GROSSAMT, AREA FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,PREVGROSS desc "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubPaymentGross()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,(SELECT GROSSAMT  FROM PAYMENT WHERE FORYEAR = '" & _mForYear & "' AND ACCTNO = [BUSDETAILEXTN].ACCTNO AND BUSCODE = [BUSDETAILEXTN].BUSCODE AND GROSSAMT <> 0) as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "'  order by foryear desc)  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "

            _nQuery = _
             "SELECT *,(SELECT GROSSAMT  FROM PAYMENT WHERE FORYEAR = '" & _mForYear & "' AND ACCTNO = [BUSDETAIL_TAXPAYER].ACCTNO AND BUSCODE = [BUSDETAIL_TAXPAYER].BUSCODE AND GROSSAMT <> 0) as GROSSINPUT FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubShowBusDetailExtn2()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '   "SELECT *,(SELECT GROSS FROM [" & _mTempGross & "] WHERE BUSCODE = [BUSDETAILEXTN].BUSCODE) as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "'  order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "

            _nQuery = _
               "SELECT *,(SELECT GROSS FROM [" & _mTempGross & "] WHERE BUSCODE = [BUSDETAIL_TAXPAYER].BUSCODE) as GROSSINPUT FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "



            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetInformation()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT * FROM [VW_WEBINFO] WHERE [ACCTNO] = '" & _mAcctNo & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nLastName = _nSqlDr.Item("LAST_NAME").ToString
                    _nFirstName = _nSqlDr.Item("FIRST_NAME").ToString
                    _nMidName = _nSqlDr.Item("MIDDLE_NAME").ToString
                    _nOwnerAdd = _nSqlDr.Item("OWNERADDR").ToString
                    _nBrgy = _nSqlDr.Item("BARANGAY").ToString
                    _nCommAdd = _nSqlDr.Item("COMMADDR").ToString
                    _nCommName = _nSqlDr.Item("COMMNAME").ToString
                    _nCpNo = _nSqlDr.Item("CPNO").ToString
                    _nTelNo = _nSqlDr.Item("CONTTEL").ToString
                    _nEmailNo = _nSqlDr.Item("EMAILADDR").ToString
                    _nGender = _nSqlDr.Item("GENDER").ToString
                    ' Loop
                End If

            End Using




            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetInformationNew()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                       "select ACCTNO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,OWNERADDR, " & _
                        " (SELECT top 1 PRES_GENDER FROM BUSMASTEXTN WHERE ACCTNO = B.ACCTNO order by foryear desc) as GENDER, " & _
                        " (SELECT BRGYDESC FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BRGYCODE WHERE BRGYCODE = B.BRGYCODE and DISTCODE = B.DISTCODE) as BARANGAY, " & _
                        "  COMMADDR, COMMNAME, CPNO, EMAILADDR, CONTTEL " & _
                        " from busmast as B WHERE B.ACCTNO = '" & _mAcctNo & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nLastName = _nSqlDr.Item("LAST_NAME").ToString
                    _nFirstName = _nSqlDr.Item("FIRST_NAME").ToString
                    _nMidName = _nSqlDr.Item("MIDDLE_NAME").ToString
                    _nOwnerAdd = _nSqlDr.Item("OWNERADDR").ToString
                    _nBrgy = _nSqlDr.Item("BARANGAY").ToString
                    _nCommAdd = _nSqlDr.Item("COMMADDR").ToString
                    _nCommName = _nSqlDr.Item("COMMNAME").ToString
                    _nCpNo = _nSqlDr.Item("CPNO").ToString
                    _nTelNo = _nSqlDr.Item("CONTTEL").ToString
                    _nEmailNo = _nSqlDr.Item("EMAILADDR").ToString
                    _nGender = _nSqlDr.Item("GENDER").ToString
                    ' Loop
                End If

            End Using




            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubSelectPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL FROM [PAYMENT] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' " & _
               " UNION " & _
               " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [PAYMENT] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' order by acctno desc,BUSCODE desc,GROSSAMT desc "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using






            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectPaymentPerQtr()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing




            '----------------------------------    
            _nQuery = _
               "exec [SP_GETQTRPAYMENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mQtr & "','" & _mTempTbl & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            _nQuery = _
               "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL  FROM [" & _mTempTbl & "] " & _
               " UNION " & _
               " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' order by acctno desc,BUSCODE desc,GROSSAMT desc "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using






            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetTotalDue()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               " SELECT SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "'" ' AND FORYEAR = '" & _mForYear & "' "


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nTotalDue = 0
                    _nTotalDue = CDbl(_nSqlDr.Item("TOTAL").ToString)

                    ' Loop
                End If

            End Using

            '----------------------------------
        Catch ex As Exception
            _nTotalDue = 0
        End Try
    End Sub

    Public Sub _pSubSelectPaymentInquiry()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               " select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars " & _
                 " from vw_PayfileHistorySummary_Tanay where isnull(Particulars,'') <> '' and acctno = src.acctno  " & _
                 " and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)  " & _
                 " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TOTALAMT,Remarks2 from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'')  " & _
                 " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT as TOTALAMT,(SELECT TOP 1 CASE WHEN STATCODE = 'R' THEN 'Renewal' WHEN STATCODE = 'N' THEN 'New' WHEN STATCODE = 'C' THEN 'Closed' " & _
                " ELSE '' END AS STATCODE  FROM BUSLINE WHERE ACCTNO  = vw_PayfileHistorySummary_Tanay.acctno and foryear = vw_PayfileHistorySummary_Tanay.foryear ) as Remarks2 " & _
                 "  From vw_PayfileHistorySummary_Tanay Where Acctno ='" & _mAcctNo & "'  group by Foryear,PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') , " & _
                " ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  ) as src " & _
                "  UNION " & _
                " select  'TOTAL','','','','','','','','','','','','', SUM(TOTALAMT) as TOTALAMT,''  from ( " & _
                " select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars  from vw_PayfileHistorySummary_Tanay  " & _
                " where isnull(Particulars,'') <> '' and acctno = src.acctno   and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)    " & _
                " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TOTALAMT,Remarks2 from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') " & _
                " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT as TOTALAMT,(SELECT TOP 1 CASE WHEN STATCODE = 'R' THEN 'Renewal' WHEN STATCODE = 'N' THEN 'New' WHEN STATCODE = 'C' THEN 'Closed' " & _
                " ELSE '' END AS STATCODE  FROM BUSLINE WHERE ACCTNO  = vw_PayfileHistorySummary_Tanay.acctno and foryear = vw_PayfileHistorySummary_Tanay.foryear ) as Remarks2    From vw_PayfileHistorySummary_Tanay " & _
                " Where Acctno = '" & _mAcctNo & "'  group by Foryear,PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') ,  ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  )" & _
                " as src ) as x " & _
                " order by ordate desc, orno desc "


            '   '" select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars " & _
            ''  " from vw_PayfileHistorySummary_Tanay where isnull(Particulars,'') <> '' and acctno = src.acctno  " & _
            ''  " and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)  " & _
            ''  " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TOTALAMT from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'')  " & _
            ''  " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT as TOTALAMT " & _
            ''  "  From vw_PayfileHistorySummary_Tanay Where Acctno ='" & _mAcctNo & "'  group by PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') , " & _
            '' " ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  ) as src " & _
            '' "  UNION " & _
            '' " select  'TOTAL','','','','','','','','','','','','', SUM(TOTALAMT) as TOTALAMT  from ( " & _
            '' " select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars  from vw_PayfileHistorySummary_Tanay  " & _
            '' " where isnull(Particulars,'') <> '' and acctno = src.acctno   and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)    " & _
            '' " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TOTALAMT from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') " & _
            '' " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT as TOTALAMT   From vw_PayfileHistorySummary_Tanay " & _
            '' " Where Acctno = '" & _mAcctNo & "'  group by PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') ,  ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  )" & _
            '' " as src ) as x " & _
            '' " order by ordate desc, orno desc "
            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using






            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectPaymentInquiry_Report()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               " select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars " & _
                 " from vw_PayfileHistorySummary_Tanay where isnull(Particulars,'') <> '' and acctno = src.acctno  " & _
                 " and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)  " & _
                 " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TAMT from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'')  " & _
                 " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT  " & _
                 "  From vw_PayfileHistorySummary_Tanay Where Acctno ='" & _mAcctNo & "'  group by PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') , " & _
                " ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  ) as src order by ordate desc, orno desc "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using






            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDelFee() 'Delivery
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_DELIVERYFEE] '" & _mAcctNo & "','" & _mForYear & "','" & _mDeliver & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubPosAssessment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_POSTASSESSMENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mQtr & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mTempGross & "' "

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)

            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubRemoveTempTbl()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "DROP TABLE [" & _mTempTbl & "] "

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubPaymentPosting()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "EXEC [SP_PAYMENTPOSTING]  '" & _mAcctNo & "','" & _mForYear & "','" & _mAmountPaid & "','" & _mLQP & "','" & _mQtr & "','" & _mReferenceNo & "','" & _mTempTbl & "' "

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUPDATELEDGERACCT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "EXEC [SP_UPDATELEDGERACCT]  '" & _mAcctNo & "','" & _mForYear & "','" & _mReferenceNo & "','" & _mLocServer & "','" & _mLocDB & "' "

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubGetBusDetailExtn()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "EXEC [SP_GETBUSDETAILEXTN]  '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "'  "

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetBusDetail_TAXPAYER()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "EXEC [SP_GETBUSDETAILEXTN_TAXPAYER]  '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "'  "

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetGross() 'Get Gross 
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETGROSS] '" & _mGrossDetail & "','" & _mTempGross & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSavePaymentDetail() 'Get Gross 
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_SAVEPAYMENTDETAIL] '" & _mAcctNo & "','" & _mEmail & "','" & _mForYear & "','" & _mReferenceNo & "','" & _mAmountPaid & "','" & _mDatePaid & "','" & _mRemarks & "' "

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKPAYMENT] '" & _mAcctNo & "','" & _mForYear & "',@_mQTRPAY OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mQTRPAY", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mQTRPAY").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mQTRPAY").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCheckNewBusiness()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKNEWBUSINESS] '" & _mAcctNo & "','" & _mForYear & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectPaymentPerQtrPaid()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing




            '----------------------------------    
            _nQuery = _
               "exec [SP_GETQTRPAYMENTPAID] '" & _mAcctNo & "','" & _mForYear & "','" & _mQtr & "','" & _mQtrPaid & "','" & _mTempTbl & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            _nQuery = _
               "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL  FROM [" & _mTempTbl & "] " & _
               " UNION " & _
               " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' order by acctno desc,BUSCODE desc,GROSSAMT desc "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using






            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubCREATE_TEMPASKHDG()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_CREATE_TEMPASKHDG] '" & _mTempTbl & "'"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCREATE_TEMPASKQTY()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_CREATE_TEMPASKQTY] '" & _mTempTbl & "'"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCREATE_TEMPOPTION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_CREATE_TEMPOPTION] '" & _mTempTbl & "'"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubGET_ASKHDG()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
                         "select BUS_CODE, DESCRIPTION, CATEGORY, ISNULL(BCODE,'') BCODE, ISNULL(MCODE,'') MCODE,ISNULL(GCODE,'') GCODE, ISNULL(SCODE,'') SCODE, ISNULL(FCODE,'') FCODE from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSCODE " & _
                         "where BUS_CODE IN (SELECT DISTINCT BUSCODE FROM BUSDETAILEXTN WHERE ACCTNO = '" & _mAcctNo & "' and foryear < '" & _mForYear & "')"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                        _mTaxCode = _nSqlDr.Item("BCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("MCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("GCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("SCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("FCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGET_ASKQTY()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    




            _nQuery = _
                         "select BUS_CODE, DESCRIPTION, CATEGORY, ISNULL(BCODE,'') BCODE, ISNULL(MCODE,'') MCODE,ISNULL(GCODE,'') GCODE, ISNULL(SCODE,'') SCODE, ISNULL(FCODE,'') FCODE from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSCODE " & _
                          "where BUS_CODE IN (SELECT DISTINCT BUSCODE FROM BUSDETAILEXTN WHERE ACCTNO = '" & _mAcctNo & "' and foryear < '" & _mForYear & "')"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                        _mTaxCode = _nSqlDr.Item("BCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("MCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("GCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("SCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("FCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGET_OPTION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
              "select BUS_CODE, DESCRIPTION, CATEGORY, ISNULL(BCODE,'') BCODE, ISNULL(MCODE,'') MCODE,ISNULL(GCODE,'') GCODE, ISNULL(SCODE,'') SCODE, ISNULL(FCODE,'') FCODE from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSCODE " & _
               "where BUS_CODE IN (SELECT DISTINCT BUSCODE FROM BUSDETAILEXTN WHERE ACCTNO = '" & _mAcctNo & "' and foryear < '" & _mForYear & "')"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                        _mTaxCode = _nSqlDr.Item("BCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("MCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("GCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("SCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("FCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGETVALUE_TEMPASKHDG()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_GETVALUE_TEMPASKHDG] '" & _mTempTbl & "','" & _mASKHDG & "','" & _mXValue & "' "


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGETVALUE_TEMPASKOPT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_GETVALUE_TEMPASKOPT] '" & _mTempTbl & "','" & _mASKHDG & "','" & _mTaxCode & "' "


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetSOANo()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETSOANO] '" & _mForYear & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubRemoveTemp()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_REMOVETEMP] '" & _mEmail & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetNewBusiness()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETNEWBUSINESS] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "',@_mStatus1 OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing 
            ''End If

            '----------------------------------
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.Parameters.Add("@_mStatus1", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus1").Direction = ParameterDirection.Output


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '_mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus1").Value
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetGarbage()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETGARBAGE] '" & _mAcctNo & "','" & _mForYear & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAttachFiles()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO BUSDETAIL_ATTACHMENTS" & _
                            "( " & _
                            " ACCTNO " & _
                            " ,FORYEAR " & _
                            " ,FILE1Name " & _
                            " ,FILE1Type " & _
                            IIf(_mFile1Data Is Nothing, "", ",FILE1Data ") & _
                            " ,FILE2Name " & _
                            " ,FILE2Type " & _
                            IIf(_mFile2Data Is Nothing, "", ",FILE2Data ") & _
                            " ,FILE3Name " & _
                            " ,FILE3Type " & _
                            IIf(_mFile3Data Is Nothing, "", ",FILE3Data ") & _
                            " ,FILE4Name " & _
                            " ,FILE4Type " & _
                            IIf(_mFile4Data Is Nothing, "", ",FILE4Data ") & _
                            " ) " & _
                            "VALUES " & _
                            "( '" & _mAcctNo & "'" & _
                            ",'" & _mForYear & "'" & _
                            ",'" & _mFile1Name & "'" & _
                            ",'" & _mFile1Type & "'" & _
                            IIf(_mFile1Data Is Nothing, "", ",@File1Data") & _
                            ",'" & _mFile2Name & "'" & _
                            ",'" & _mFile2Type & "'" & _
                            IIf(_mFile2Data Is Nothing, "", ",@File2Data") & _
                            ",'" & _mFile3Name & "'" & _
                            ",'" & _mFile3Type & "'" & _
                            IIf(_mFile3Data Is Nothing, "", ",@File3Data") & _
                            ",'" & _mFile4Name & "'" & _
                            ",'" & _mFile4Type & "'" & _
                            IIf(_mFile4Data Is Nothing, "", ",@File4Data") & _
                            " )"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                If _mFile1Data IsNot Nothing Then .AddWithValue("@File1Data", _mFile1Data)
                If _mFile2Data IsNot Nothing Then .AddWithValue("@File2Data", _mFile2Data)
                If _mFile3Data IsNot Nothing Then .AddWithValue("@File3Data", _mFile3Data)
                If _mFile4Data IsNot Nothing Then .AddWithValue("@File4Data", _mFile4Data)


                '.AddWithValue("@File2Data", _mFile2Data)
                '.AddWithValue("@File3Data", _mFile3Data)
                '.AddWithValue("@File4Data", _mFile4Data)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDeleteAttachFiles()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "DELETE FROM BUSDETAIL_ATTACHMENTS WHERE ACCTNO = '" & _mAcctNo & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubInsertAttachFiles1()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO BUSDETAIL_ATTACHMENTS_NEW" & _
                            "( " & _
                            " ACCTNO " & _
                            " ,FORYEAR " & _
                            " ,FILE1Name " & _
                            " ,FILE1Type " & _
                            IIf(_mFile1Data Is Nothing, "", ",FILE1Data ") & _
                            " ,FILE2Name " & _
                            " ,FILE2Type " & _
                            IIf(_mFile2Data Is Nothing, "", ",FILE2Data ") & _
                            " ,FILE3Name " & _
                            " ,FILE3Type " & _
                            IIf(_mFile3Data Is Nothing, "", ",FILE3Data ") & _
                            " ,FILE4Name " & _
                            " ,FILE4Type " & _
                            IIf(_mFile4Data Is Nothing, "", ",FILE4Data ") & _
                            " ) " & _
                            "VALUES " & _
                            "( '" & _mAcctNo & "'" & _
                            ",'" & _mForYear & "'" & _
                            ",'" & _mFile1Name & "'" & _
                            ",'" & _mFile1Type & "'" & _
                            IIf(_mFile1Data Is Nothing, "", ",@File1Data") & _
                            ",'" & _mFile2Name & "'" & _
                            ",'" & _mFile2Type & "'" & _
                            IIf(_mFile2Data Is Nothing, "", ",@File2Data") & _
                            ",'" & _mFile3Name & "'" & _
                            ",'" & _mFile3Type & "'" & _
                            IIf(_mFile3Data Is Nothing, "", ",@File3Data") & _
                            ",'" & _mFile4Name & "'" & _
                            ",'" & _mFile4Type & "'" & _
                            IIf(_mFile4Data Is Nothing, "", ",@File4Data") & _
                            " )"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                If _mFile1Data IsNot Nothing Then .AddWithValue("@File1Data", _mFile1Data)
                If _mFile2Data IsNot Nothing Then .AddWithValue("@File2Data", _mFile2Data)
                If _mFile3Data IsNot Nothing Then .AddWithValue("@File3Data", _mFile3Data)
                If _mFile4Data IsNot Nothing Then .AddWithValue("@File4Data", _mFile4Data)


                '.AddWithValue("@File2Data", _mFile2Data)
                '.AddWithValue("@File3Data", _mFile3Data)
                '.AddWithValue("@File4Data", _mFile4Data)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    '----------------------- Added by archie 20200916
    Public Sub _pSubSelect(_nTable As String, _nCondition As String)

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = _nCondition

            _nQuery = _
                             "SELECT " & _
               " * " & _
               "FROM " & _nTable & _
               " "
            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters


                '.AddWithValue("@_mIDNo", IIf(String.IsNullOrWhiteSpace(_mIDNo), "", _mIDNo))
                '.AddWithValue("@_mIDNoRegistered", IIf(String.IsNullOrWhiteSpace(_mIDNoRegistered), "", _mIDNoRegistered))


            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSAVEASKHDG()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_SAVEASKHDG] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSAVEASKOPTION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_SAVEASKOPTION] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubTPEmail()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETEMAIL] '" & _mAcctNo & "',@_mStatus1 OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing 
            ''End If

            '----------------------------------
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.Parameters.Add("@_mStatus1", SqlDbType.NVarChar, 150)
            _mSqlCommand.Parameters("@_mStatus1").Direction = ParameterDirection.Output


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '_mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus1").Value
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSAVEASKQTY()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_SAVEASKQTY] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGETAPPRV_TOP_ONLINE()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETAPPRV_TOP_ONLINE] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "',@_mStatus1 OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing 
            ''End If

            '----------------------------------
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.Parameters.Add("@_mStatus1", SqlDbType.NVarChar, 150)
            _mSqlCommand.Parameters("@_mStatus1").Direction = ParameterDirection.Output


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '_mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus1").Value
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubAPPROVEPAYMENT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_APPROVEPAYMENT] '" & _mAcctNo & "','" & _mForYear & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)

            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCHECKISASSESS()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKISASSESS] '" & _mAcctNo & "','" & _mForYear & "',@_mStatus1 OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing 
            ''End If

            '----------------------------------
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.Parameters.Add("@_mStatus1", SqlDbType.NVarChar, 150)
            _mSqlCommand.Parameters("@_mStatus1").Direction = ParameterDirection.Output


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '_mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus1").Value
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub




    Public Sub _pSubCheckIsOnHold()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKISONHOLD] '" & _mAcctNo & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCheckIsDelinquent()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKISDELINQUENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub




    Public Sub _pSubCHECKDESCRIPTION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKDESCRIPTION] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)

            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()

            '_nQuery = _
            '   "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL  FROM [" & _mTempTbl & "] " & _
            '   " UNION " & _
            '   " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' order by acctno desc,BUSCODE desc,GROSSAMT desc "

            _nQuery = _
               "WITH XTBL AS ( SELECT ACCTNO, FORYEAR,TAXDESC, QTR,  GROSSAMT,AMOUNTDUE AMOUNTDUE, PENDUE PENDUE, DISCOUNT,TOTAL, " & _
               " CASE WHEN ISNULL((SELECT TOP 1 TOPSEQ FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.LABELS WHERE TAXCODE = [" & _mTempTbl & "].TAXCODE),'') = ''  " & _
               " THEN LEFT(TAXCODE,1) ELSE (SELECT TOP 1 TOPSEQ FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.LABELS WHERE TAXCODE = [" & _mTempTbl & "].TAXCODE) END AS SEQ " & _
               " FROM [" & _mTempTbl & "]) " & _
               " SELECT ACCTNO, FORYEAR,TAXDESC, QTR,SUM(GROSSAMT) GROSSAMT,SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL,SEQ FROM XTBL  " & _
               " GROUP BY ACCTNO, FORYEAR,TAXDESC,QTR,SEQ " & _
               " UNION " & _
               " SELECT '' , '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL,'' AS SEQ  FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "'  order by foryear desc,acctno desc,SEQ,GROSSAMT desc "


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDELINQUENT_NYP()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_DELINQUENT_NYP] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDECLINEAPPLICATION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_DECLINEAPPLICATION] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubDECLINEENROLLMENT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_DECLINEENROLLMENT] '" & _mAcctNo & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGETOWNCODE()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETOWNCODE] '" & _mAcctNo & "','" & _mLocServer & "','" & _pLocDB & "',@XOUTPUT OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@XOUTPUT", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@XOUTPUT").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@XOUTPUT").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubInsertAttachFiles(Acctno, Foryear, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType, ReqDesc, Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO BUSDETAIL_ATTACHMENTS_NEW(ACCTNO, FORYEAR, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType, ReqDesc, Office) VALUES(@Acctno,@Foryear,@RefNo,@ModuleID,@AcctID,@SeqID,@FileData,@FileName,@FileType,@ReqDesc,@Office)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Acctno", Acctno)
                .AddWithValue("@Foryear", Foryear)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@ModuleID", ModuleID)
                .AddWithValue("@AcctID", AcctID)
                .AddWithValue("@SeqID", SeqID)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
                .AddWithValue("@ReqDesc", ReqDesc)
                .AddWithValue("@Office", Office)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubUpdateAttachFiles(Acctno, Foryear, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSDETAIL_ATTACHMENTS_NEW SET FileData = @FileData, FileName = @FileName, FileType = @FileType " & _
                      " where ACCTNO = @Acctno and FORYEAR = @Foryear and ModuleID=@ModuleID and AcctID=@AcctID and SeqID=@SeqID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Acctno", Acctno)
                .AddWithValue("@Foryear", Foryear)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@ModuleID", ModuleID)
                .AddWithValue("@AcctID", AcctID)
                .AddWithValue("@SeqID", SeqID)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    ' _mAcctNo
    '_mForYear

    Public Sub _pSubSelectImage(ByVal ACCTNO As String, ByVal FORYEAR As String, ByVal ModuleID As String, ByVal AcctID As String, ByVal SeqID As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [BUSDETAIL_ATTACHMENTS_NEW] "
            _nWhere = " where ACCTNO =  '" & ACCTNO & "' and FORYEAR =  '" & FORYEAR & "' and ModuleID='" & ModuleID & "' and AcctID='" & AcctID & "' and SeqID= '" & SeqID & "'"

            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Exists = True
                Else
                    Exists = False

                End If
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubCheckIsClosed()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKISCLOSED] '" & _mAcctNo & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGETBILLINGTEMP()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                    "exec [SP_GETBILLINGTEMP] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTblBT & "','" & _mTempTbl & "','" & _mMOP & "'"
            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetCurYear()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "Select year(getdate()) as curYear,month(getdate()) as curMonth, getdate() as CurrDate "

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '   Do While _nSqlDr.Read
                    _nCurYear = _nSqlDr.Item(0).ToString
                    _nCurMonth = _nSqlDr.Item(1).ToString
                    _nCurDate = _nSqlDr.Item(2).ToString
                    '  Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    '----------------------------------------------------------- Added by Archie 20201214
    Public Sub _pSearchOnBP(SearchKey, TopCounter)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be in serted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = SearchKey

            '----------------------------------    
            '_nQuery = _
            '    "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) "
            ' _nQuery = _
            '"SELECT DISTINCT  B.*,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)   group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2 ORDER BY max(BT.DATESUBMIT)  "


            _nQuery =
            " SELECT " & _
            TopCounter & _
            " * FROM (" & _
            " SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT " & _
            " FROM BUSDETAIL B " & _
            " INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO " & _
            " WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "') " & _
            " group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY,Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1  ) S " & _
            _nWhere

            '_nQuery = _
            '"SELECT DISTINCT  " & _
            'TopCounter & _
            '" B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT " & _
            '" FROM BUSDETAIL_TAXPAYER " & _
            '" WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT " & _
            '" FROM BUSDETAIL B " & _
            '" INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO " & _
            '" WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')   " & _
            '_nWhere & _
            '" group by MAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1 ORDER BY max(BT.DATESUBMIT)  "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSearchOnBPAssessAcct(SearchKey, TopCounter)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = SearchKey

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) DESC "
            '_nQuery = _
            '       "SELECT DISTINCT  B.*,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS   " & _
            '       " UNION SELECT DISTINCT  B.*,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE  BT.FORYEAR = '" & _mForYear & "'  AND BT.ACCTNO IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS ORDER BY max(BT.DATESUBMIT) DESC "


            _nQuery = " SELECT " & _
                TopCounter & _
                " * FROM ( " & _
                " SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT " & _
                " FROM BUSDETAIL_TAXPAYER " & _
                " WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   " & _
                " FROM BUSDETAIL B " & _
                " INNER JOIN BUSDETAIL_TAXPAYER BT " & _
                " ON B.ACCTNO = BT.ACCTNO " & _
                " WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' " & _
                " group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2, B.CATEGORY1,BT.ISASSESS " & _
                " UNION SELECT DISTINCT B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B LEFT OUTER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE B.ACCTNO IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS, B.CATEGORY1 ) S " & _
                _nWhere



            '_nQuery = _
            '   "SELECT DISTINCT  " & _
            'TopCounter & _
            '"B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  " & _
            '"FROM BUSDETAIL B " & _
            '"INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO " & _
            '"WHERE ISNULL(BT.ISASSESS,0) = 1 " & _
            '"AND BT.FORYEAR = '" & _mForYear & "' " & _
            '_nWhere & _
            '" group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2, B.CATEGORY1,BT.ISASSESS " & _
            '" UNION " & _
            '" SELECT DISTINCT " & _
            ' TopCounter & _
            '" B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  " & _
            '" FROM BUSDETAIL B " & _
            '" INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO " & _
            '" WHERE  BT.FORYEAR = '" & _mForYear & "'  AND BT.ACCTNO IN (SELECT ACCTNO FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 " & _
            '" AND FORYEAR = '" & _mForYear & "')  " & _
            '_nWhere & _
            '" group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS, B.CATEGORY1 ORDER BY max(BT.DATESUBMIT) DESC "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDELINQUENT_NYP_PREVYR()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nPrevYr As String
            _nPrevYr = _mForYear - 1
            '----------------------------------    
            _nQuery = _
               "exec [SP_DELINQUENT_NYP_PREVYR] '" & _mAcctNo & "','" & _nPrevYr & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetDelinquent()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETDELINQUENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "','" & _mTempTbl & "'"


            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectRecordPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing







            _nQuery = _
               "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL  FROM [" & _mTempTbl & "] " & _
               " UNION " & _
               " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "' order by foryear desc,acctno desc,BUSCODE desc,GROSSAMT desc "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetPenalty_PrevYr()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nBusCode As String
            Dim _nPrevYr As String
            _nPrevYr = _mForYear - 1


            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & _mLocServer & "].[" & _mLocDB & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT DISTINCT BUSCODE FROM [PAYMENT] WHERE ACCTNO = '" & _mAcctNo & "' AND FORYEAR = '" & _nPrevYr & "' AND ISNULL(BUSCODE,'') <> ''  "


            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nBusCode = _nSqlDr.Item("BUSCODE").ToString

                        _nQuery = _
                            "exec [SP_GETPENALTY_PREVYR] '" & _mAcctNo & "','" & _nPrevYr & "','" & _nBusCode & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mQtrPaid & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



End Class



