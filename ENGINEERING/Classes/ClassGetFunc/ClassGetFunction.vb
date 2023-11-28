

Imports System.Data.SqlClient

Public Class ClassGetFunction
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mStrSql As String
    Public Shared _mSelectionComboBox As Boolean
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Private Shared _mQuery As String = Nothing
    Private Shared _mCondReturn As String = ""
#End Region

#Region "Property Object"


    Public Shared Property _pDatatable() As DataTable
        Get
            Try
                Return _mDataTable
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As DataTable)

        End Set
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

#Region "Property Variable"
    Public Shared Property _pCondReturn() As String
        Get
            Try
                Return _mCondReturn
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As String)
            _mCondReturn = value
        End Set
    End Property

#End Region

#Region "Variables"

    Private Shared _mIDCode As String
    Private Shared _mFName As String
    Private Shared _mMName As String
    Private Shared _mLName As String
    Private Shared _mTIN As String
    Private Shared _mAddress1 As String
    Private Shared _mAddress2 As String
    Private Shared _mAddress3 As String
    Private Shared _mAddress4 As String
    Private Shared _mAddress5 As String
    Private Shared _mTellNo As String
    Private Shared _mApplCode As String
    Private Shared _mCTCNo As String
    Private Shared _mCTC_ISS_Date As String
    Private Shared _mCTC_Plc_ISS As String
    Private Shared _mAddress As String
    Private Shared _mFullName As String

#End Region

    'Public Sub _mDatagridSortMode(ByVal _oGv As DataGridView) ''-----------Added 20190924 MCE

    '    For _nCnt = 0 To _oGv.Columns.Count - 1
    '        _oGv.Columns(_nCnt).SortMode = DataGridViewColumnSortMode.NotSortable
    '    Next

    'End Sub

    'Public Shared Function _pAutoIndex(ByVal _nTableName As String, ByVal _nCond As String) As Integer

    '    Dim _nCount As Integer = 0
    '    Dim _nLCnt As Integer = 0
    '    Dim _nC As Integer
    '    Dim _nSubndx As String = ""
    '    Dim _nDatatbl As New DataTable

    '    CDalLoadRecordBrowse._pSubSelect(_nTableName, "ndx", _nCond, 0, )
    '    _nDatatbl = CDalLoadRecordBrowse._pDataTable
    '    CDalLoadRecordBrowse._pDataTable.Dispose()
    '    Try

    '        If _nTableName <> "GrAskHdg" Then
    '            For _nC = 0 To _nDatatbl.Rows.Count - 1
    '                If Not IsDBNull(CStr(_nDatatbl.Rows(_nC).Item("ndx"))) Then
    '                    _nCount = IIf(IsDBNull(CStr(_nDatatbl.Rows(_nC).Item("ndx"))), 0, _nDatatbl.Rows(_nC).Item("ndx"))
    '                    _nLCnt = _nCount

    '                End If
    '            Next


    '        End If
    '        Return _nLCnt + 1
    '    Catch ex As Exception
    '        Return 0
    '    End Try
    'End Function



    ''-----------------------------------------------------------------------------Added 20190603 MCE
    '    Public Function _pRecordExist(Optional _nColumns As String = "*", Optional _nTableName As String = Nothing, Optional _nCondition As String = Nothing, Optional _nTitleName As String = "", Optional _nTitleExtn As String = Nothing) As String
    '        Dim _nCount As Integer = 0
    '        Dim _nName As String = ""
    '        Dim _nFileName As String = ""
    '        Dim _nSubtitleName As String = ""
    '        Dim _nWhereCon As String = ""
    '        Dim _nSubstr As String = ""
    '        If _nColumns = "" Or Nothing Then _nColumns = "*"



    '        _nFileName = CDalUploadImageDocs_IUD._pName

    '        Try

    '_nGetFileName:

    '            _nWhereCon = ""
    '            _nSubstr = ""

    '            _nTitleName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(CDalUploadImageDocs_IUD._pName), System.IO.Path.GetFileNameWithoutExtension(CDalUploadImageDocs_IUD._pName))

    '            _nWhereCon = _nCondition & " And Name='" & _nFileName & "'"

    '            Using cmd As New SqlCommand("Select " & _nColumns & "From " & _nTableName & " " & _nWhereCon, _mSqlCon)
    '                Dim _nSqlDataRd As SqlDataReader = cmd.ExecuteReader

    '                If _nSqlDataRd.HasRows Then
    '                    _nSqlDataRd.Read()
    '                    _nCount += 1
    '                    _nSubstr = "- Copy "
    '                    _nFileName = _nTitleName & _nSubstr & _nCount & _nTitleExtn
    '                    _nSqlDataRd.Dispose()
    '                    cmd.Dispose()
    '                    GoTo _nGetFileName
    '                End If

    '                _nSqlDataRd.Dispose()
    '                cmd.Dispose()
    '                Return _nFileName
    '            End Using

    '        Catch ex As Exception
    '            Return Nothing
    '        End Try

    '    End Function


    'Public Sub _pDataReaderReturnVal(Optional _nColumns As String = "*", Optional _nTableName As String = Nothing, Optional _nCondition As String = Nothing) ''--------Added 20190424 Used incase of needs 

    '    If _nColumns = "" Or Nothing Then _nColumns = "*"
    '    Try

    '        Using cmd As New SqlCommand("Select " & _nColumns & "From " & _nTableName & " " & _nCondition, _mSqlCon)
    '            Dim _nSqlDataRd As SqlDataReader = cmd.ExecuteReader

    '            Select Case _nTableName

    '                Case "Applicant"
    '                    If _nSqlDataRd.Read Then

    '                        CDalRPTASPropertyInfoLink._pOwnerNo = _nSqlDataRd("Owner_No")

    '                    End If
    '            End Select
    '        End Using

    '    Catch ex As Exception

    '    End Try
    'End Sub



    Public Function _pSubSelectQuery(Optional _nCondition As String = "*", Optional _nTableName As String = Nothing, Optional _nWhere As String = Nothing) As DataTable
        Dim SourceDatatable As DataTable
        If _nCondition = Nothing Then _nCondition = "*"
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            ' Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select " & _nCondition & " From " & _nTableName & _nWhere

            _mStrSql = _nQuery


            SourceDatatable = New DataTable

            Dim _nSqlData = New SqlDataAdapter(_nQuery, _mSqlCon)

            SourceDatatable.Rows.Clear()

            _nSqlData.Fill(SourceDatatable)

            _nSqlData.Dispose()

            Return SourceDatatable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    ''---------------------------------------------------------------------------------------------------------Populate field get in the datatable 20190401 modify 20190402

    'Public Sub _pPopulateComboBoxField(ByVal nContainer As Control, ByVal _nDtbl As DataTable)


    '    Dim _nC As Integer
    '    Dim ctrl As Control

    '    Try
    '        For Each ctrl In nContainer.Controls

    '            If TypeOf ctrl Is ComboBox Then
    '                Dim myCtrl As ComboBox
    '                myCtrl = CType(ctrl, ComboBox)

    '                '_nDtbl.Clear()
    '                myCtrl.Items.Clear()
    '                ' myCtrl.Items.Add("None")


    '                If _nDtbl.Columns.Count > 0 Then

    '                    For _nC = 1 To _nDtbl.Columns.Count - 1
    '                        myCtrl.Items.Add(_nDtbl.Columns(_nC).ColumnName)
    '                    Next

    '                    myCtrl.SelectedIndex = 1
    '                    myCtrl.AllowDrop = True
    '                End If

    '            End If
    '        Next
    '    Catch ex As Exception

    '    End Try

    'End Sub
    Public Function _pSourceDatatable(ByVal _nCond As String, ByVal SourceDatatable As DataTable) As DataTable  '----------------------------- 20190214

        SourceDatatable = New DataTable

        _mSqlCmd = New SqlCommand(_nCond, _mSqlCon)

        Using sdr As SqlDataReader = _mSqlCmd.ExecuteReader()

            'Load DataReader into the DataTable.

            SourceDatatable.Clear()
            SourceDatatable.Load(sdr)
            sdr.Dispose()
            _mSqlCmd.Dispose()
        End Using

        Return SourceDatatable


    End Function

    ''---------------------------------------------------------------------------------------------------20190423
    'Public Function _pDataGrid_GetSelectedVal(ByVal _nGv As DataGridView, Optional _nVal As String = "") ''---------------------------------------20190423

    '    Try


    '        Return IIf(IsDBNull(_nGv.SelectedRows(0).Cells(_nVal).Value), "", _nGv.SelectedRows(0).Cells(_nVal).Value)

    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function

    ''---------------------------------------------------------------------------------------------Added ------20190430
    Public Function _pDatatable_GetData(ByVal _nDt As DataTable, Optional _nVal As String = "")

        Try

            Return IIf(IsDBNull(_nDt.Rows(0).Item(_nVal).ToString), "", (_nDt.Rows(0).Item(_nVal).ToString).ToString)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function



    Public Function _pPopulate_Datatable(ByVal SourceDatatable As DataTable, Optional _nCond As String = Nothing) As DataTable ''------------------This is function for Return Datatable 20190220
        Dim _nSqlstr As String
        SourceDatatable = New DataTable

        _nSqlstr = _nCond

        Dim _nSqlData = New SqlDataAdapter(_nCond, _mSqlCon)

        SourceDatatable.Rows.Clear()

        _nSqlData.Fill(SourceDatatable)

        _nSqlData.Dispose()

        Return SourceDatatable

    End Function

    Public Function _mNotInputedSpecialCharacter(ByVal _nInput As String, ByRef _nVal As String, ByVal _nModName As String, ByVal _nSpecialCharAllowed As String) As Boolean ''------------Added 20191008 MCE
        _mNotInputedSpecialCharacter = False

        Dim nchar As New Char
        Dim _nSubstr As String = ""
        For x As Integer = 0 To _nInput.Length - 1
            _nSubstr = _nInput.Substring(x, 1)
            If _nSpecialCharAllowed.Contains(_nSubstr) Then ''Or String.IsNullOrWhiteSpace(_nSubstr)
                _nVal = Replace(_nInput, _nSubstr, "")
                Return True
            End If
        Next
    End Function

End Class


















'Imports System.Data.SqlClient

'Public Class ClassGetFunction
'#Region "Variable Object"
'    Private Shared _mSqlCon As New SqlConnection
'    Private Shared _mStrSql As String
'    Public Shared _mSelectionComboBox As Boolean
'    Private Shared _mSqlCmd As SqlCommand
'    Private Shared _mDataTable As New DataTable
'    Private Shared _mQuery As String = Nothing
'    Private Shared _mCondReturn As String = ""
'#End Region

'#Region "Property Object"


'    Public Shared Property _pDatatable() As DataTable
'        Get
'            Try
'                Return _mDataTable
'            Catch ex As Exception
'                Return Nothing
'            End Try
'        End Get
'        Set(value As DataTable)

'        End Set
'    End Property

'    Public Shared Property _pSqlCon() As SqlConnection
'        Get
'            Try
'                Return _mSqlCon
'            Catch ex As Exception
'                Return Nothing
'            End Try
'        End Get
'        Set(value As SqlConnection)
'            _mSqlCon = value
'        End Set
'    End Property
'#End Region

'#Region "Property Variable"
'    Public Shared Property _pCondReturn() As String
'        Get
'            Try
'                Return _mCondReturn
'            Catch ex As Exception
'                Return Nothing
'            End Try
'        End Get
'        Set(value As String)
'            _mCondReturn = value
'        End Set
'    End Property

'#End Region

'#Region "Variables"

'    Private Shared _mIDCode As String
'    Private Shared _mFName As String
'    Private Shared _mMName As String
'    Private Shared _mLName As String
'    Private Shared _mTIN As String
'    Private Shared _mAddress1 As String
'    Private Shared _mAddress2 As String
'    Private Shared _mAddress3 As String
'    Private Shared _mAddress4 As String
'    Private Shared _mAddress5 As String
'    Private Shared _mTellNo As String
'    Private Shared _mApplCode As String
'    Private Shared _mCTCNo As String
'    Private Shared _mCTC_ISS_Date As String
'    Private Shared _mCTC_Plc_ISS As String
'    Private Shared _mAddress As String
'    Private Shared _mFullName As String

'#End Region


'    Public Function _pRecordExist(Optional _nColumns As String = "*", Optional _nTableName As String = Nothing, Optional _nCondition As String = Nothing) As Boolean

'        If _nColumns = "" Or Nothing Then _nColumns = "*"
'        Try

'            Using cmd As New SqlCommand("Select " & _nColumns & "From " & _nTableName & " " & _nCondition, _mSqlCon)
'                Dim _nSqlDataRd As SqlDataReader = cmd.ExecuteReader

'                If _nSqlDataRd.Read Then
'                    Return True
'                End If
'                Return False
'            End Using

'        Catch ex As Exception
'            Return False
'        End Try
'    End Function


'    Public Sub _pDataReaderReturnVal(Optional _nColumns As String = "*", Optional _nTableName As String = Nothing, Optional _nCondition As String = Nothing) ''--------Added 20190424 Used incase of needs 

'        If _nColumns = "" Or Nothing Then _nColumns = "*"
'        Try

'            Using cmd As New SqlCommand("Select " & _nColumns & "From " & _nTableName & " " & _nCondition, _mSqlCon)
'                Dim _nSqlDataRd As SqlDataReader = cmd.ExecuteReader

'                Select Case _nTableName

'                    Case "Applicant"
'                        If _nSqlDataRd.Read Then

'                            CDalRPTASPropertyInfoLink._pOwnerNo = _nSqlDataRd("Owner_No")

'                        End If
'                End Select
'            End Using

'        Catch ex As Exception

'        End Try
'    End Sub



'    Public Function _pSubSelectQuery(Optional _nCondition As String = "*", Optional _nTableName As String = Nothing, Optional _nWhere As String = Nothing) As DataTable
'        Dim SourceDatatable As DataTable
'        If _nCondition = Nothing Then _nCondition = "*"
'        Try
'            '----------------------------------
'            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

'            '----------------------------------
'            Dim _nQuery As String = Nothing
'            ' Dim _nWhere As String = Nothing

'            '----------------------------------    
'            _nQuery = "Select " & _nCondition & " From " & _nTableName & _nWhere

'            _mStrSql = _nQuery


'            SourceDatatable = New DataTable

'            Dim _nSqlData = New SqlDataAdapter(_nQuery, _mSqlCon)

'            SourceDatatable.Rows.Clear()

'            _nSqlData.Fill(SourceDatatable)

'            _nSqlData.Dispose()

'            Return SourceDatatable

'        Catch ex As Exception
'            Return Nothing
'        End Try
'    End Function

'    Public Function _pReturnQuery(ByVal _nCond As String, ByVal _nSelectName As String)  '----------------------------- 20190214

'        Select Case _nSelectName

'            Case "OwnershipType"
'                _mStrSql = "Select Desc1,Desc2 from OwnershipType" & _nCond

'            Case "ScopeCode"
'                _mStrSql = "Select ROW_NUMBER() over (order by  desc1) as RowNum, " & _
'                "desc1,desc2 from ScopeCode where LinkCode= 'B-01'" & _nCond

'            Case "StreetCode"
'                _mStrSql = "Select Code,Description from vw_Street" & _nCond

'            Case "BrgyCode"
'                _mStrSql = "Select BrgyCode,BrgyDesc from vw_Barangay" & _nCond

'            Case "BldgOwner_LotOwner"
'                _mStrSql = "Select * from vw_PropOwner" & _nCond

'            Case "Professional"
'                _mStrSql = "Select * from vw_Professional" & _nCond

'            Case "Applicant"
'                _mStrSql = "Select * from vw_Applicant_ApplicantExtn" & _nCond
'            Case "ApplicantType"

'                _mStrSql = "Select * from ApplicantType" & _nCond

'            Case "OccupancyUse"
'                _mStrSql = "Select * from OccupancyUse" & _nCond

'            Case "Muni_Strt"
'                _mStrSql = "Select StrtCode,StrtDesc,MuniCityCode,MuniCityDesc from vw_LocationSetup" & _nCond

'            Case "ProvinceCode"
'                _mStrSql = "Select * from ProvinceCode" & _nCond

'            Case "ApplicationInfo"
'                _mStrSql = "Select IDcode,FullName,Address,Tin,TellNo,FName,MName,LName,Address1,Address2,Address3,Address4,Address5 from vw_ApplicantInfo" & _nCond

'        End Select

'        'SourceDatatable = New DataTable

'        'Dim _nSqlData = New SqlDataAdapter(_mStrSql, _mDbCon)

'        'SourceDatatable.Rows.Clear()

'        '_nSqlData.Fill(SourceDatatable)

'        '_nSqlData.Dispose()

'        Return _mStrSql


'    End Function

'    ''---------------------------------------------------------------------------------------------------------Populate field get in the datatable 20190401 modify 20190402

'    Public Sub _pPopulateComboBoxField(ByVal nContainer As Control, ByVal _nDtbl As DataTable)


'        Dim _nC As Integer
'        Dim ctrl As Control

'        Try
'            For Each ctrl In nContainer.Controls

'                If TypeOf ctrl Is ComboBox Then
'                    Dim myCtrl As ComboBox
'                    myCtrl = CType(ctrl, ComboBox)

'                    _nDtbl.Clear()
'                    myCtrl.Items.Clear()
'                    ' myCtrl.Items.Add("None")


'                    If _nDtbl.Columns.Count > 0 Then

'                        For _nC = 1 To _nDtbl.Columns.Count - 1
'                            myCtrl.Items.Add(_nDtbl.Columns(_nC).ColumnName)
'                        Next

'                        myCtrl.SelectedIndex = 1
'                        myCtrl.AllowDrop = True
'                    End If

'                End If
'            Next
'        Catch ex As Exception

'        End Try

'    End Sub

'    Public Sub _pPopulateComboBox(ByVal _onComboBox As ComboBox, ByVal _nCbValueMember As String, ByVal _nCbDisplayMember As String, ByVal _nCond As String, ByVal _nTblName As String, ByVal _nWhere As String) ''----------------------Function of populating ComboBox  20190326

'        _mSelectionComboBox = False
'        _onComboBox.DataSource = Nothing
'        _mCondReturn = ""
'        '_onComboBox.Items.Clear()
'        '_onComboBox.Items.Add("")
'        '_onComboBox.Items.Clear()
'        '_onComboBox.Items.Add("")


'        _mDataTable = _pSubSelectQuery(_nCond, _nTblName, _nWhere) ''_pSourceDatatable(_mCondReturn, _mDataTable) '' Modify 20190429
'        _onComboBox.DataSource = _mDataTable
'        _onComboBox.ValueMember = _nCbValueMember
'        _onComboBox.DisplayMember = _nCbDisplayMember
'        _onComboBox.SelectedIndex = -1
'        _onComboBox.AllowDrop = False
'        '_mDtbl.Dispose()

'        ClassGetFunction._mSelectionComboBox = True

'    End Sub

'    Public Function _pSourceDatatable(ByVal _nCond As String, ByVal SourceDatatable As DataTable) As DataTable  '----------------------------- 20190214

'        SourceDatatable = New DataTable

'        Dim _nSqlData = New SqlDataAdapter(_nCond, _mSqlCon)

'        SourceDatatable.Rows.Clear()


'        _nSqlData.Fill(SourceDatatable)



'        _nSqlData.Dispose()

'        Return SourceDatatable


'    End Function


'    Public Sub _pSubSetGridView(ByVal _nDatagridview As DataGridView, ByRef _nDatatable As DataTable)  ''-------------------Moved 20190321

'        _nDatagridview.DataSource = Nothing
'        _nDatagridview.MultiSelect = False
'        _nDatagridview.AutoGenerateColumns = False
'        _nDatagridview.DataSource = _nDatatable
'        _nDatagridview.Refresh()
'        _nDatatable.Dispose()
'    End Sub

'    Private Sub _oGv_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs, ByVal _nDatagridview As DataGridView)
'        If e.KeyCode = Keys.Up Then
'        ElseIf e.KeyCode = Keys.Down Then
'        End If

'    End Sub



'    ''---------------------------------------------------------------------------------------------------20190423
'    Public Function _pDataGrid_GetSelectedVal(ByVal _nGv As DataGridView, Optional _nVal As String = "") ''---------------------------------------20190423

'        Try

'            Return IIf(IsDBNull(_nGv.SelectedRows(0).Cells(_nVal).Value), "", _nGv.SelectedRows(0).Cells(_nVal).Value)

'        Catch ex As Exception
'            Return Nothing
'        End Try
'    End Function

'    ''---------------------------------------------------------------------------------------------Added ------20190430
'    Public Function _pDatatable_GetData(ByVal _nDt As DataTable, Optional _nVal As String = "")

'        Try

'            Return IIf(IsDBNull(_nDt.Rows(0).Item(_nVal).ToString), "", (_nDt.Rows(0).Item(_nVal).ToString).ToString)

'        Catch ex As Exception
'            Return Nothing
'        End Try
'    End Function



'    'Public Function _pPopulate_Datatable(ByVal SourceDatatable As DataTable, Optional _nCond As String = Nothing) As DataTable ''------------------This is function for Return Datatable 20190220

'    '    SourceDatatable = New DataTable

'    '    Dim _nSqlData = New SqlDataAdapter(_nCond, _mDbCon)

'    '    SourceDatatable.Rows.Clear()

'    '    _nSqlData.Fill(SourceDatatable)

'    '    _nSqlData.Dispose()

'    '    Return SourceDatatable

'    'End Function
'End Class
