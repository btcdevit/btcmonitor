Imports System.Net.WebClient

Public Class Form1
    Dim p1 As New panel
    Dim p2 As New panel
    Dim p3 As New panel
    Dim p4 As New panel
    Dim mtgox As New st_mtgox
    Dim bitstamp As New st_bitstamp
    Dim btcchina As New st_btcchina
    Dim dragme As Boolean
    Dim dragpos(1) As Integer
    Dim mainwidth As Integer
    Dim panels As Integer = 1
    Dim url_mtgoxeur As String = "http://data.mtgox.com/api/1/BTCEUR/ticker_fast"
    Dim url_mtgoxusd As String = "http://data.mtgox.com/api/1/BTCUSD/ticker_fast"
    Dim url_mtgoxgbp As String = "http://data.mtgox.com/api/1/BTCGBP/ticker_fast"
    Dim url_bitstampusd As String = "https://www.bitstamp.net/api/ticker/"
    Dim url_btcchinacny As String = "https://vip.btcchina.com/bc/ticker"
    Dim align As Integer = 0 '0=4x1  1=1x4 2=2x2


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Computer.Registry.CurrentUser.CreateSubKey("Software\btcmon")
        p1.market = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_market", "")
        p2.market = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_market", "")
        p3.market = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_market", "")
        p4.market = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_market", "")
        p1.currency = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_cur", "")
        p2.currency = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_cur", "")
        p3.currency = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_cur", "")
        p4.currency = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_cur", "")
        p1.url = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_url", "")
        p2.url = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_url", "")
        p3.url = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_url", "")
        p4.url = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_url", "")
        p1.enable = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_enable", "1"))
        p2.enable = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_enable", "0"))
        p3.enable = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_enable", "0"))
        p4.enable = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_enable", "0"))
        p1.enable = True
        If p1.enable Then panels = 1
        If p2.enable Then panels = 2
        If p3.enable Then panels = 3
        If p4.enable Then panels = 4
        Panel1.Visible = True
        p1.row = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_row", "1"))
        p2.row = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_row", "1"))
        p3.row = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_row", "1"))
        p4.row = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_row", "1"))
        p1.col = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_col", "1"))
        p2.col = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_col", "2"))
        p3.col = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_col", "3"))
        p4.col = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_col", "4"))
        align = Int(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "align", "0"))

        main_redraw()

    End Sub

    Private Sub p1USDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.currency = "USD"
        If p1.market = "mtgox" Then
            p1.url = "http://data.mtgox.com/api/1/BTCUSD/ticker_fast"
        End If

    End Sub

    Private Sub p1JPYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.currency = "JPY"
        If p1.market = "mtgox" Then
            p1.url = "http://data.mtgox.com/api/1/BTCJPY/ticker_fast"
        End If

    End Sub

    Private Sub p1GBPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.currency = "GBP"
        If p1.market = "mtgox" Then
            p1.url = "http://data.mtgox.com/api/1/BTCGBP/ticker_fast"
        End If

    End Sub

    Private Sub p1PLNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.currency = "PLN"
        If p1.market = "mtgox" Then
            p1.url = "http://data.mtgox.com/api/1/BTCPLN/ticker_fast"
        End If

    End Sub

    Private Sub p1CADToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.currency = "CAD"
        If p1.market = "mtgox" Then
            p1.url = "http://data.mtgox.com/api/1/BTCCAD/ticker_fast"
        End If

    End Sub

    Private Sub p1timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p1timer.Tick

        Dim a, b As Double
        Dim c, d As Double
        If p1.market = "mtgox" Then
            mtgox_get(p1.url)
            If mtgox.result = "success" Then
                p1.sell = mtgox.sell
                p1.buy = mtgox.buy
                p1.time = mtgox.now
                p1.status = mtgox.result
                a = Int(Mid(mtgox.last_local, 1, Len(mtgox.last_local) - 6))
                b = Int(Mid(mtgox.last_local, Len(mtgox.last_local) - 4, 2))
                b = b / 100
                p1.value = a + b
                If p1.value > p1.last_value Then p1.trend = "up"
                If p1.value < p1.last_value Then p1.trend = "down"
                'If p1.value = p1.last_value Then p1.trend = "equ"
                p1.last_value = p1.value
                p1_update()
            End If
        End If
        If p1.market = "bitstamp" Then
            bitstamp_get(p1.url)
            p1.sell = bitstamp.sell
            p1.buy = bitstamp.buy
            p1.time = bitstamp.now
            a = Int(Mid(bitstamp.last, 1, Len(bitstamp.last) - 3))
            b = Int(Mid(bitstamp.last, Len(bitstamp.last) - 2, 2))
            b = b / 100
            p1.value = a + b
            If p1.value > p1.last_value Then p1.trend = "up"
            If p1.value < p1.last_value Then p1.trend = "down"
            'If p1.value = p1.last_value Then p1.trend = "equ"
            p1.last_value = p1.value
            'p1.value = Double (bitstamp.last)
            p1_update()
        End If

        If p1.market = "btcchina" Then
            btcchina_get(p1.url)
            p1.sell = btcchina.sell
            p1.buy = btcchina.buy
            p1.time = "0"
            a = Int(Mid(btcchina.last, 1, Len(btcchina.last) - 3))
            b = Int(Mid(btcchina.last, Len(btcchina.last) - 1, 2))
            b = b / 100
            p1.value = a + b
            If p1.value > p1.last_value Then p1.trend = "up"
            If p1.value < p1.last_value Then p1.trend = "down"
            'If p1.value = p1.last_value Then p1.trend = "equ"
            p1.last_value = p1.value
            p1_update()
        End If

        If p2.enable = True Then

            If p2.market = "mtgox" Then
                mtgox_get(p2.url)
                If mtgox.result = "success" Then
                    p2.sell = mtgox.sell
                    p2.buy = mtgox.buy
                    p2.time = mtgox.now
                    p2.status = mtgox.result
                    c = Int(Mid(mtgox.last_local, 1, Len(mtgox.last_local) - 6))
                    d = Int(Mid(mtgox.last_local, Len(mtgox.last_local) - 4, 2))
                    d = d / 100
                    p2.value = c + d
                    If p2.value > p2.last_value Then p2.trend = "up"
                    If p2.value < p2.last_value Then p2.trend = "down"
                    'If p1.value = p1.last_value Then p1.trend = "equ"
                    p2.last_value = p2.value
                    p2_update()
                End If
            End If
            If p2.market = "bitstamp" Then
                bitstamp_get(p2.url)
                p2.sell = bitstamp.sell
                p2.buy = bitstamp.buy
                p2.time = bitstamp.now
                a = Int(Mid(bitstamp.last, 1, Len(bitstamp.last) - 3))
                b = Int(Mid(bitstamp.last, Len(bitstamp.last) - 2, 2))
                b = b / 100
                p2.value = a + b

                If p2.value > p2.last_value Then p2.trend = "up"
                If p2.value < p2.last_value Then p2.trend = "down"
                p2.last_value = p2.value
                'p1.value = Double (bitstamp.last)
                p2_update()
            End If
            If p2.market = "btcchina" Then
                btcchina_get(p2.url)
                p2.sell = btcchina.sell
                p2.buy = btcchina.buy
                p2.time = "0"
                a = Int(Mid(btcchina.last, 1, Len(btcchina.last) - 3))
                b = Int(Mid(btcchina.last, Len(btcchina.last) - 1, 2))
                b = b / 100
                p2.value = a + b
                If p2.value > p2.last_value Then p2.trend = "up"
                If p2.value < p2.last_value Then p2.trend = "down"
                p2.last_value = p2.value
                p2_update()
            End If

        End If


        If p3.enable = True Then

            If p3.market = "mtgox" Then
                mtgox_get(p3.url)
                If mtgox.result = "success" Then
                    p3.sell = mtgox.sell
                    p3.buy = mtgox.buy
                    p3.time = mtgox.now
                    p3.status = mtgox.result
                    c = Int(Mid(mtgox.last_local, 1, Len(mtgox.last_local) - 6))
                    d = Int(Mid(mtgox.last_local, Len(mtgox.last_local) - 4, 2))
                    d = d / 100
                    p3.value = c + d
                    If p3.value > p3.last_value Then p3.trend = "up"
                    If p3.value < p3.last_value Then p3.trend = "down"
                    'If p1.value = p1.last_value Then p1.trend = "equ"
                    p3.last_value = p3.value
                    p3_update()
                End If
            End If
            If p3.market = "bitstamp" Then
                bitstamp_get(p3.url)
                p3.sell = bitstamp.sell
                p3.buy = bitstamp.buy
                p3.time = bitstamp.now
                a = Int(Mid(bitstamp.last, 1, Len(bitstamp.last) - 3))
                b = Int(Mid(bitstamp.last, Len(bitstamp.last) - 2, 2))
                b = b / 100
                p3.value = a + b
                If p3.value > p3.last_value Then p3.trend = "up"
                If p3.value < p3.last_value Then p3.trend = "down"
                p3.last_value = p3.value
                p3_update()
            End If
            If p3.market = "btcchina" Then
                btcchina_get(p3.url)
                p3.sell = btcchina.sell
                p3.buy = btcchina.buy
                p3.time = "0"
                a = Int(Mid(btcchina.last, 1, Len(btcchina.last) - 3))
                b = Int(Mid(btcchina.last, Len(btcchina.last) - 1, 2))
                b = b / 100
                p3.value = a + b
                If p3.value > p3.last_value Then p3.trend = "up"
                If p3.value < p3.last_value Then p3.trend = "down"
                p3.last_value = p3.value
                p3_update()
            End If
        End If
        If p4.enable = True Then

            If p4.market = "mtgox" Then
                mtgox_get(p4.url)
                If mtgox.result = "success" Then
                    p4.sell = mtgox.sell
                    p4.buy = mtgox.buy
                    p4.time = mtgox.now
                    p4.status = mtgox.result
                    c = Int(Mid(mtgox.last_local, 1, Len(mtgox.last_local) - 6))
                    d = Int(Mid(mtgox.last_local, Len(mtgox.last_local) - 4, 2))
                    d = d / 100
                    p4.value = c + d
                    If p4.value > p4.last_value Then p4.trend = "up"
                    If p4.value < p4.last_value Then p4.trend = "down"
                    p4.last_value = p4.value
                    p4_update()
                End If
            End If
            If p4.market = "bitstamp" Then
                bitstamp_get(p4.url)
                p4.sell = bitstamp.sell
                p4.buy = bitstamp.buy
                p4.time = bitstamp.now
                a = Int(Mid(bitstamp.last, 1, Len(bitstamp.last) - 3))
                b = Int(Mid(bitstamp.last, Len(bitstamp.last) - 2, 2))
                b = b / 100
                p4.value = a + b
                If p4.value > p4.last_value Then p4.trend = "up"
                If p4.value < p4.last_value Then p4.trend = "down"
                p4.last_value = p4.value
                'p1.value = Double (bitstamp.last)
                p4_update()
            End If
            If p4.market = "btcchina" Then
                btcchina_get(p4.url)
                p4.sell = btcchina.sell
                p4.buy = btcchina.buy
                p4.time = "0"
                a = Int(Mid(btcchina.last, 1, Len(btcchina.last) - 3))
                b = Int(Mid(btcchina.last, Len(btcchina.last) - 1, 2))
                b = b / 100
                p4.value = a + b
                If p4.value > p4.last_value Then p4.trend = "up"
                If p4.value < p4.last_value Then p4.trend = "down"
                p4.last_value = p4.value
                p4_update()
            End If
        End If
    End Sub
    Private Sub bitstamp_get(ByVal url As String)
        Try
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim reply As String = client.DownloadString(url)
            Dim st() As String
            Dim a As Integer
            Dim stringSeparators() As String = {":", ","}
            st = reply.Split(stringSeparators, StringSplitOptions.None)
            'ListBox1.Items.Clear()
            For Each s As String In st
                'ListBox1.Items.Add(Str(a) & "--" & s)
                s = Mid(s, 3, Len(s) - 2)
                If a = 3 Then bitstamp.last = s
                If a = 5 Then bitstamp.now = s
                If a = 7 Then bitstamp.buy = Mid(s, 1, Len(s) - 1)
                If a = 13 Then bitstamp.sell = Mid(s, 1, Len(s) - 2)
                a = a + 1
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub mtgox_get(ByVal url As String)
        Try
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim reply As String = client.DownloadString(url)
            Dim st() As String
            Dim a As Integer
            Dim stringSeparators() As String = {":", ","}
            st = reply.Split(stringSeparators, StringSplitOptions.None)
            For Each s As String In st
                s = Mid(s, 2, Len(s) - 2)
                If a = 1 Then mtgox.result = s
                If a = 5 Then mtgox.last_local = s
                If a = 49 Then mtgox.buy = Mid(s, 1, Len(s) - 3)
                If a = 60 Then mtgox.sell = Mid(s, 1, Len(s) - 3)
                a = a + 1
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btcchina_get(ByVal url As String)
        Try
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim reply As String = client.DownloadString(url)
            Dim st() As String
            Dim a As Integer
            Dim stringSeparators() As String = {":", ","}
            st = reply.Split(stringSeparators, StringSplitOptions.None)
            For Each s As String In st
                s = Mid(s, 2, Len(s) - 2)
                If a = 10 Then btcchina.last = s
                If a = 6 Then btcchina.buy = s
                If a = 8 Then btcchina.sell = s
                a = a + 1
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub p1_update()
        p1_value.ForeColor = Color.White
        If p1.trend = "up" Then p1_value.ForeColor = Color.Lime
        If p1.trend = "down" Then p1_value.ForeColor = Color.Red
        p1_value.Text = Str(p1.value)
        p1_cur.Text = p1.currency
        p1_market.Text = p1.market
        p1_sell.Text = "sell:" + p1.sell
        p1_buy.Text = "buy:" + p1.buy
    End Sub
    Private Sub p2_update()
        p2_value.ForeColor = Color.White
        If p2.trend = "up" Then p2_value.ForeColor = Color.Lime
        If p2.trend = "down" Then p2_value.ForeColor = Color.Red
        'If p1.trend = "equ" Then 
        p2_value.Text = Str(p2.value)
        p2_cur.Text = p2.currency
        p2_market.Text = p2.market
        p2_sell.Text = "sell:" + p2.sell
        p2_buy.Text = "buy:" + p2.buy
    End Sub
    Private Sub p3_update()
        p3_value.ForeColor = Color.White
        If p3.trend = "up" Then p3_value.ForeColor = Color.Lime
        If p3.trend = "down" Then p3_value.ForeColor = Color.Red
        'If p1.trend = "equ" Then 
        p3_value.Text = Str(p3.value)
        p3_cur.Text = p3.currency
        p3_market.Text = p3.market
        p3_sell.Text = "sell:" + p3.sell
        p3_buy.Text = "buy:" + p3.buy
    End Sub
    Private Sub p4_update()
        p4_value.ForeColor = Color.White
        If p4.trend = "up" Then p4_value.ForeColor = Color.Lime
        If p4.trend = "down" Then p4_value.ForeColor = Color.Red
        'If p1.trend = "equ" Then 
        p4_value.Text = Str(p4.value)
        p4_cur.Text = p4.currency
        p4_market.Text = p4.market
        p4_sell.Text = "sell:" + p4.sell
        p4_buy.Text = "buy:" + p4.buy

    End Sub

    Private Sub EURToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EURToolStripMenuItem.Click
        p1.currency = "EUR"
        p1.market = "mtgox"
        p1.url = url_mtgoxeur
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_cur", "EUR")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_url", p1.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_enable", "1")
    End Sub

    Private Sub USDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USDToolStripMenuItem.Click
        p1.currency = "USD"
        p1.market = "mtgox"
        p1.url = url_mtgoxusd
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_cur", "USD")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_url", p1.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_enable", "1")
    End Sub

    Private Sub GBPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GBPToolStripMenuItem.Click
        p1.currency = "GBP"
        p1.market = "mtgox"
        p1.url = url_mtgoxgbp
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_cur", "GBP")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_url", p1.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_enable", "1")
    End Sub

    Private Sub USDToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USDToolStripMenuItem1.Click
        p1.currency = "USD"
        p1.market = "bitstamp"
        p1.url = url_bitstampusd
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_market", "bitstamp")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_cur", "USD")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_url", p1.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_enable", "1")
    End Sub
    Private Function GetUnixTimestamp(ByVal currDate As DateTime) As Double
        'create Timespan by subtracting the value provided from the Unix Epoch
        Dim span As TimeSpan = (currDate - New DateTime(2012, 1, 1, 0, 0, 0, 0).ToLocalTime())
        'return the total seconds (which is a UNIX timestamp)
        Return span.TotalSeconds
    End Function

  

    Private Sub CNYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNYToolStripMenuItem.Click
        p1.currency = "CNY"
        p1.market = "btcchina"
        p1.url = url_btcchinacny
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_market", "btcchina")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_cur", "CNY")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_url", p1.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_enable", "1")
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Me.Cursor = Cursors.Hand
        If e.Button = Windows.Forms.MouseButtons.Left Then
            dragme = True
            dragpos(0) = e.Location.X
            dragpos(1) = e.Location.Y
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim item As Control = CType(sender, Control)
        If dragme = True Then
            item.Left = item.Left - (dragpos(0) - e.Location.X)
            item.Top = item.Top - (dragpos(1) - e.Location.Y)
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Me.Cursor = Cursors.Arrow
        dragme = False
    End Sub

    Public Sub main_redraw()
        ' set main window dimension
        'panel = 180 x 100
        If align = 0 Then
            Me.Width = panels * 180 + 55
            Me.Height = 95
        End If
        If align = 1 Then
            Me.Width = 190
            Me.Height = 72 * panels + 55
        End If
        If align = 2 Then
            Me.Width = 360 + 55
            Me.Height = 160
        End If
        p2.enable = False
        p3.enable = False
        p4.enable = False
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_enable", "1")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_enable", "0")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_enable", "0")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_enable", "0")
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel1.Left = (p1.col * 180) - 180 + 5
        Panel1.Top = (p1.row * 74) - 72 + 8

        If panels > 1 Then
            p2.enable = True
            Panel2.Visible = True
            Panel2.Left = (p2.col * 180) - 180 + 5
            Panel2.Top = (p2.row * 74) - 72 + 8
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_enable", "1")
        End If
        If panels > 2 Then
            p3.enable = True
            Panel3.Visible = True
            Panel3.Left = (p3.col * 180) - 180 + 5
            Panel3.Top = (p3.row * 74) - 72 + 8
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_enable", "1")
        End If
        If panels > 3 Then
            p4.enable = True
            Panel4.Visible = True
            Panel4.Left = (p4.col * 180) - 180 + 5
            Panel4.Top = (p4.row * 74) - 72 + 8
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_enable", "1")
        End If


    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        End
    End Sub

    Private Sub AddPanelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPanelToolStripMenuItem.Click
        panels = panels + 1
        main_redraw()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.Opacity = 1

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Me.Opacity = 0.5
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Me.Opacity = 0.75
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Me.Opacity = 0.25
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Me.Opacity = 0.1
    End Sub

    Private Sub DisableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub YesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YesToolStripMenuItem.Click
        Me.TopMost = True
    End Sub

    Private Sub NoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoToolStripMenuItem.Click
        Me.TopMost = False
    End Sub

    Private Sub cm_panel2_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cm_panel2_close.Click
        p2.market = ""
        p2.enable = False
        panels = panels - 1
        If p3.enable = True Then
            'copy panel3 to panel2
            p2 = p3
            p3.enable = False
            p3.market = ""
            'panels = panels - 1
            main_redraw()
            p2.enable = True
        End If
        If p4.enable = True Then
            p3 = p4
            p4.enable = False
            p4.market = ""
            main_redraw()
            p3.enable = True
        End If
        main_redraw()

    End Sub


    Private Sub cmp4_mtgoxeur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_mtgoxeur.Click
        p4.currency = "EUR"
        p4.market = "mtgox"
        p4.url = url_mtgoxeur
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_cur", "EUR")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_url", p4.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_enable", "1")
    End Sub

    Private Sub cmp4_mtgoxusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_mtgoxusd.Click
        p4.currency = "USD"
        p4.market = "mtgox"
        p4.url = url_mtgoxusd
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_cur", "USD")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_url", p4.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_enable", "1")
    End Sub

    Private Sub cmp4_mtgoxgbp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_mtgoxgbp.Click
        p4.currency = "GBP"
        p4.market = "mtgox"
        p4.url = url_mtgoxgbp
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_cur", "GBP")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_url", p4.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_enable", "1")
    End Sub

    Private Sub cmp4_bitstampusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_bitstampusd.Click
        p4.currency = "USD"
        p4.market = "bitstamp"
        p4.url = url_bitstampusd
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_market", "bitstamp")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_cur", "USD")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_url", p4.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_enable", "1")

    End Sub

    Private Sub cmp4_btcchinacny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_btcchinacny.Click
        p4.currency = "CNY"
        p4.market = "btcchina"
        p4.url = url_btcchinacny
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_market", "btcchina")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_cur", "CNY")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_url", p4.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_enable", "1")

    End Sub

   
    Private Sub cmp3_btcchinacny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_btcchinacny.Click
        p3.currency = "CNY"
        p3.market = "btcchina"
        p3.url = url_btcchinacny
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_market", "btcchina")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_cur", "CNY")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_url", p3.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_enable", "1")
    End Sub

    Private Sub cmp3_bitstampusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_bitstampusd.Click
        p3.currency = "USD"
        p3.market = "bitstamp"
        p3.url = url_bitstampusd
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_market", "bitstamp")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_cur", "USD")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_url", p3.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_enable", "1")
    End Sub

    Private Sub cmp3_mtgoxeur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_mtgoxeur.Click
        p3.currency = "EUR"
        p3.market = "mtgox"
        p3.url = url_mtgoxeur
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_cur", "EUR")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_url", p3.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_enable", "1")
    End Sub

    Private Sub cmp3_mtgoxusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_mtgoxusd.Click
        p3.currency = "USD"
        p3.market = "mtgox"
        p3.url = url_mtgoxusd
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_cur", "USD")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_url", p3.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_enable", "1")
    End Sub

    Private Sub cmp3_mtgoxgbp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_mtgoxgbp.Click
        p3.currency = "GBP"
        p3.market = "mtgox"
        p3.url = url_mtgoxgbp
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_cur", "GBP")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_url", p3.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_enable", "1")
    End Sub

    Private Sub cmp2_btcchinacny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_btcchinacny.Click
        p2.currency = "CNY"
        p2.market = "btcchina"
        p2.url = url_btcchinacny
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_market", "btcchina")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_cur", "CNY")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_url", p2.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_enable", "1")
    End Sub

    Private Sub cmp2_bitstampusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_bitstampusd.Click
        p2.currency = "USD"
        p2.market = "bitstamp"
        p2.url = url_bitstampusd
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_market", "bitstamp")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_cur", "USD")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_url", p2.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_enable", "1")
    End Sub

    Private Sub cmp2_mtgoxeur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_mtgoxeur.Click
        p2.currency = "EUR"
        p2.market = "mtgox"
        p2.url = url_mtgoxeur
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_cur", "EUR")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_url", p2.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_enable", "1")
    End Sub

    Private Sub cmp2_mtgoxusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_mtgoxusd.Click
        p2.currency = "USD"
        p2.market = "mtgox"
        p2.url = url_mtgoxusd
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_cur", "USD")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_url", p2.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_enable", "1")
    End Sub

    Private Sub cmp2_mtgoxgbp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_mtgoxgbp.Click
        p3.currency = "GBP"
        p3.market = "mtgox"
        p3.url = url_mtgoxgbp
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_market", "mtgox")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_cur", "GBP")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_url", p2.url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_enable", "1")
    End Sub

    Private Sub cm_panel3_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cm_panel3_close.Click
        p3.market = ""
        p3.enable = False
        panels = panels - 1
        If p4.enable = True Then
            p3 = p4
            p4.enable = False
            p4.market = ""
            main_redraw()
            p3.enable = True
        End If
        main_redraw()


    End Sub

    Private Sub cm_panel4_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cm_panel4_close.Click
        p4.market = ""
        p4.enable = False
        Panel4.Visible = False
        panels = panels - 1
        main_redraw()

    End Sub

  
    Private Sub cm_main_1x4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cm_main_1x4.Click
        p1.row = 1
        p1.col = 1
        p2.row = 2
        p2.col = 1
        p3.row = 3
        p3.col = 1
        p4.row = 4
        p4.col = 1
        align = 1
        align_save()
        main_redraw()

    End Sub

    Private Sub cm_main_2x2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cm_main_2x2.Click
        p1.row = 1
        p1.col = 1
        p2.row = 1
        p2.col = 2
        p3.row = 2
        p3.col = 1
        p4.row = 2
        p4.col = 2
        align = 2
        align_save()
        main_redraw()

    End Sub

    Private Sub cm_main_4x1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cm_main_4x1.Click
        p1.row = 1
        p1.col = 1
        p2.row = 1
        p2.col = 2
        p3.row = 1
        p3.col = 3
        p4.row = 1
        p4.col = 4
        align = 0
        align_save()
        main_redraw()


    End Sub
    Private Sub align_save()
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_row", p1.row)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_row", p2.row)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_row", p3.row)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_row", p4.row)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_col", p1.col)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_col", p2.col)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_col", p3.col)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_col", p4.col)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "align", align)
    End Sub

End Class
