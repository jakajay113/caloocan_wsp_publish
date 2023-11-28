

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalSOSRPTAS

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

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


    Private _mOrigTDN As String
    Private _mTDN As String
    Private _mORNO As String
    Private _mStatus As String
    Private _mEmail As String
    Private _mFieldsWhere As String
    Private _mLocServer As String
    Private _mLocDB As String
    Private _mstrdt As String
#End Region

#Region "Properties Field"
    Public Property _pstrdt() As String
        Get
            Return _mstrdt
        End Get
        Set(ByVal value As String)
            _mstrdt = value
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
    Public Property _pLocDB() As String
        Get
            Return _mLocDB
        End Get
        Set(ByVal value As String)
            _mLocDB = value
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

    Public Property _pOrigTDN() As String
        Get
            Return _mOrigTDN
        End Get
        Set(ByVal value As String)
            _mOrigTDN = value
        End Set
    End Property

    Public Property _pTDN() As String
        Get
            Return _mTDN
        End Get
        Set(ByVal value As String)
            _mTDN = value
        End Set
    End Property
    Public Property _pORNO() As String
        Get
            Return _mORNO
        End Get
        Set(ByVal value As String)
            _mORNO = value
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
    Public Property _pEmail() As String
        Get
            Return _mEmail
        End Get
        Set(ByVal value As String)
            _mEmail = value
        End Set
    End Property
#End Region

#Region "Routine Command"

    Public Sub _pSubSelectAddress()
        'Try
        '    '----------------------------------
        '    'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------    
        '    _nQuery = _
        '       "SELECT " & _
        '       "* " & _
        '       "FROM [PDSAddress] " & _
        '        " "

        '    '----------------------------------    
        '    If Not String.IsNullOrWhiteSpace(_mIDNo) Then

        '        _nWhere = "WHERE [IDNo] = @_mIDNo "

        '    Else
        '        _nWhere = Nothing
        '    End If

        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere


        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

        '    End With

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubInsert()
        'Try
        '    '----------------------------------
        '    If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub


        '    '----------------------------------
        '    Dim _nQuery As String = Nothing

        '    '----------------------------------
        '    _nQuery = _
        '     "INSERT INTO " & _
        '     "[PDSAddress] " & _
        '     "(" & _
        '        IIf(String.IsNullOrWhiteSpace(_mIDNo), "", " [IDNo]") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress1), "", ", [Address1]") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", [Address2]") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", [Address3]") & _
        '        IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", [ZipCode]") & _
        '        IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", [TelNo]") & _
        '            IIf((_mDefault) = Nothing, "", ", [Default]") & _
        '     ") " & _
        '     "VALUES " & _
        '     "(" & _
        '        IIf(String.IsNullOrWhiteSpace(_mIDNo), "", " @_mIDNo") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress1), "", ", @_mAddress1") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", @_mAddress2") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", @_mAddress3") & _
        '        IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", @_mZipCode") & _
        '        IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", @_mTelNo") & _
        '            IIf((_mDefault) = Nothing, "", ", @_mDefault") & _
        '     ") "

        '    '----------------------------------
        '    _mQuery = _nQuery

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

        '        If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
        '        If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
        '        If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)

        '        If Not String.IsNullOrWhiteSpace(_mZipCode) Then .AddWithValue("@_mZipCode", _mZipCode)
        '        If Not String.IsNullOrWhiteSpace(_mTelNo) Then .AddWithValue("@_mTelNo", _mTelNo)

        '        If Not (_mDefault) = Nothing Then .AddWithValue("@_mDefault", _mDefault)

        '    End With

        '    _mSqlCommand.ExecuteNonQuery()



        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubUpdate()
        'Try
        '    '----------------------------------
        '    'Check Required Fields...
        '    If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress2) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress3) Then Exit Sub

        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------
        '    _nQuery = _
        '        "UPDATE " & _
        '        "[PDSAddress] " & _
        '        "SET " & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress1), "", " [Address1] = @_mAddress1") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", [Address2] = @_mAddress2") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", [Address3] = @_mAddress3") & _
        '                IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", [ZipCode] = @_mZipCode") & _
        '                IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", [TelNo] = @_mTelNo") & _
        '            IIf((_mDefault) = Nothing, "", ", [Default] = @_mDefault") & _
        '        " "

        '    '----------------------------------

        '    If Not String.IsNullOrWhiteSpace(_mIDNo) Then

        '        _nWhere = "WHERE [IDNo] = @_mIDNo "
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress1) Then _nWhere += "AND [Address1] = @_mOrigAddress1 "
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress2) Then _nWhere += "AND [Address2] = @_mOrigAddress2 "
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress3) Then _nWhere += "AND [Address3] = @_mOrigAddress3 "

        '    Else
        '        _nWhere = Nothing

        '    End If



        '    '----------------------------------
        '    'Prevent Bulk Update.
        '    If _nWhere = Nothing Then
        '        Exit Sub
        '    End If

        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)
        '        If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
        '        If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
        '        If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)
        '        If Not String.IsNullOrWhiteSpace(_mZipCode) Then .AddWithValue("@_mZipCode", _mZipCode)
        '        If Not String.IsNullOrWhiteSpace(_mTelNo) Then .AddWithValue("@_mTelNo", _mTelNo)
        '        If Not String.IsNullOrWhiteSpace(_mDefault) Then .AddWithValue("@_mDefault", _mDefault)

        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress1) Then .AddWithValue("@_mOrigAddress1", _mOrigAddress1)
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress2) Then .AddWithValue("@_mOrigAddress2", _mOrigAddress2)
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress3) Then .AddWithValue("@_mOrigAddress3", _mOrigAddress3)
        '        If Not String.IsNullOrWhiteSpace(_mOrigZipCode) Then .AddWithValue("@_mOrigZipCode", _mOrigZipCode)
        '        If Not String.IsNullOrWhiteSpace(_mOrigTelNo) Then .AddWithValue("@_mOrigTelNo", _mOrigTelNo)
        '        'If Not String.IsNullOrWhiteSpace(_mOrigName) Then .AddWithValue("@_mOrigName", _mOrigName)

        '    End With


        '    _mSqlCommand.ExecuteNonQuery()

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubDelete()
        'Try
        '    '----------------------------------
        '    If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress2) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress3) Then Exit Sub

        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------
        '    _nQuery = _
        '        "DELETE FROM " & _
        '        "[PDSAddress] " & _
        '        " "

        '    '----------------------------------
        '    If Not String.IsNullOrWhiteSpace(_mIDNo) Then

        '        _nWhere = "WHERE [IDNo] = @_mIDNo "
        '        If Not String.IsNullOrWhiteSpace(_mAddress1) Then _nWhere += "AND [Address1] = @_mAddress1 "
        '        If Not String.IsNullOrWhiteSpace(_mAddress2) Then _nWhere += "AND [Address2] = @_mAddress2 "
        '        If Not String.IsNullOrWhiteSpace(_mAddress3) Then _nWhere += "AND [Address3] = @_mAddress3 "

        '    Else
        '        _nWhere = Nothing
        '    End If

        '    '----------------------------------
        '    'Prevent Bulk Deletion.
        '    If _nWhere = Nothing Then
        '        Exit Sub
        '    End If

        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

        '        If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
        '        If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
        '        If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)

        '    End With

        '    _mSqlCommand.ExecuteNonQuery()

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubGetServerDate()

        'Try
        '    '----------------------------------
        '    'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------    

        '    ''  SELECT convert(nvarchar(8),getdate(),112) +  replace(convert(nvarchar(15),getdate(),114),':','') AS ServerDateTime
        '    _nQuery = _
        '                     "SELECT " & _
        '       " convert(nvarchar(8),getdate(),112) +  replace(convert(nvarchar(15),getdate(),114),':','') AS ServerDateTime " & _
        '       " "
        '    '----------------------------------    


        '    '_nWhere = "WHERE [IDNo] = @_mIDNo "
        '    '_nWhere += "OR [IDNoRegistered] = @_mIDNoRegistered "
        '    'If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then
        '    '    _nWhere += "AND [BusinessAccountNumber] = @BusinessAccountNumber "
        '    'End If



        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters


        '        '.AddWithValue("@_mIDNo", IIf(String.IsNullOrWhiteSpace(_mIDNo), "", _mIDNo))
        '        '.AddWithValue("@_mIDNoRegistered", IIf(String.IsNullOrWhiteSpace(_mIDNoRegistered), "", _mIDNoRegistered))


        '    End With

        '    '----------------------------------
        'Catch ex As Exception

        'End Try

    End Sub


    Public Sub _pValidateTdn()
        Dim _nQuery As String = Nothing
        Dim _nWhere As String = Nothing

        '----------------------------------    
        _nQuery = ""

        _nQuery = " EXEC [SP_VALIDATETDN] @TDN = '" & _mTDN & "' ,@ORNO = '" & _mORNO & "' ,@EMAIL = '" & Replace(_mEmail, ".", "") & "',@RP_SERVERDB='" & _mLocServer & "',@RP_LOCALDB='" & _pLocDB & "',@EMAIL2 = '" & _mEmail & "' ,@STATUS = @STATUS output "
        '_nQuery = " EXEC [SP_VALIDATETDN] @TDN = '" & _mTDN & "' ,@ORNO = '" & _mORNO & "' ,@EMAIL = '" & _mEmail & "',@RP_SERVERDB='" & _mLocServer & "',@RP_LOCALDB='" & _pLocDB & "' ,@STATUS = @STATUS output "



        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)



        _mSqlCommand.Parameters.Add("@STATUS", SqlDbType.NVarChar, 50)
        _mSqlCommand.Parameters("@STATUS").Direction = ParameterDirection.Output
        'Execute and Read the content

        Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            _nSqlDr.Read()
            If _nSqlDr.HasRows Then
                'Getting Record using reader
                Do While _nSqlDr.Read
                    _mTDN = _nSqlDr.Item(0).ToString
                Loop
            End If

        End Using
        'Get values of parameter output


        _mStatus = _mSqlCommand.Parameters("@STATUS").Value

        _mSqlCommand.Dispose()

    End Sub
    Public Sub _pSubSelect()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '                 "SELECT " & _
            '   " * " & _
            '   "FROM [rptdetail] where email='" & _mEmail & "' " & _
            '   " "

            'rhogiel20200706
            _nQuery = _
                             "SELECT " & _
               " * " & _
               "FROM [rptdetail] where email='" & _mEmail & "' " & _
               "AND VERIFIED = '1'" & _
               " "
            '----------------------------------    


            '_nWhere = "WHERE [IDNo] = @_mIDNo "
            '_nWhere += "OR [IDNoRegistered] = @_mIDNoRegistered "
            'If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then
            '    _nWhere += "AND [BusinessAccountNumber] = @BusinessAccountNumber "
            'End If



            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            _mstrdt = ""

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(1).ToString & ":" & "true;"
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectPending()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                              "select * from OnlinePaymentRefno where ACCTNO in(select assessno from " & _mLocDB & ".dbo.Assess_FrmNewBilling_b where tdn in (" & _mTDN & ")) and replace(EMAILADDR,'.','') ='" & _mEmail & "' and isnull(PostedDate,'1900/01/01') = '1900/01/01' and StatusID='SUCCESS' "


            '     "select * from OnlinePaymentRefno where ACCTNO = '" & _mTDN & "' and replace(EMAILADDR,'.','') ='" & _mEmail & "' and [Status] = 'Pending' " & _
            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubfilter()

        'Try
        '    '----------------------------------
        '    'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

        '    '   If _mTDN = "" Then Exit Sub
        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------    
        '    _nQuery = _
        '            "SELECT  " & _
        '            "R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
        '            "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
        '            "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE  " & _
        '            "FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO  " & _
        '            "WHERE (R.REGION+R.PROV+R.CITY in (select REGION+PROV+CODE from city)) " & _
        '            " and R.TDN in (select TDN from tdnperemail where EMAILADDRESS='" & _mEmail & "') " & _
        '            "union " & _
        '            "SELECT  R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
        '            "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
        '            "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE  " & _
        '            "FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO  " & _
        '            "where R.region+R.PROV+R.CITY+R.tdn in  " & _
        '            "(select region+PROV+CITY+reference_tdn " & _
        '            "from PROPERTY_OTHERLAND_REF where region+PROV+CITY+tdn  in  " & _
        '            "(SELECT  R.region+R.PROV+R.CITY+R.TDN   FROM  RPTMAST R  " & _
        '            "WHERE (R.REGION+R.PROV+R.CITY in (select REGION+PROV+CODE from city)) )) " & _
        '            " and R.TDN in (select TDN from tdnperemail where EMAILADDRESS='" & _mEmail & "') " & _
        '            " order by R.PIN " & _
        '            ""





        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)



        '    End With

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub


    Public Sub _pSubGetSpecificRecord_getid()
        'Try
        '    '----------------------------------
        '    _pSubGetServerDate()

        '    Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

        '        '----------------------------------
        '        'Indexes
        '        With _nSqlDataReader
        '            Dim _ServerDateTime As Integer = .GetOrdinal("ServerDateTime")

        '            '----------------------------------
        '            Dim _nClassReturnTypes As New ClassReturnTypes
        '            With _nClassReturnTypes

        '                If _nSqlDataReader.HasRows Then
        '                    Do While _nSqlDataReader.Read

        '                        _mctr_no = ._pReturnString(_nSqlDataReader(_ServerDateTime))


        '                    Loop
        '                Else
        '                    _mctr_no = 1
        '                End If



        '            End With
        '        End With

        '        _nSqlDataReader.Close()
        '    End Using

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
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
               "exec [SP_GETMULTIPLE] '" & _mTDN & "','" & _mEmail & "'"

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
#End Region

End Class
