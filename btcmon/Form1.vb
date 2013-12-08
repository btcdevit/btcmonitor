Imports System.Net.WebClient

Public Class Form1
    
    Dim dragme As Boolean
    Dim dragpos(1) As Integer
    Dim mainwidth As Integer
    Dim panels As Integer = 1
    Dim url_mtgoxeur As String = "http://data.mtgox.com/api/1/BTCEUR/ticker_fast"
    Dim url_mtgoxusd As String = "http://data.mtgox.com/api/1/BTCUSD/ticker_fast"
    Dim url_mtgoxgbp As String = "http://data.mtgox.com/api/1/BTCGBP/ticker_fast"
    Dim url_bitstampusd As String = "https://www.bitstamp.net/api/ticker/"
    Dim url_btcchinacny As String = "https://vip.btcchina.com/bc/ticker"
    Dim url_btceusd As String = "https://btc-e.com/api/2/btc_usd/ticker"
    Dim url_btceur As String = "https://btc-e.com/api/2/btc_eur/ticker"
    Dim url_btcltcusd As String = "https://btc-e.com/api/2/ltc_usd/ticker"
    Dim url_btcltcbtc As String = "https://btc-e.com/api/2/ltc_btc/ticker"
    Dim url_btcltceur As String = "https://btc-e.com/api/2/ltc_eur/ticker"
    Dim url_btcenmcusd As String = "https://btc-e.com/api/2/nmc_usd/ticker"
    Dim url_btcenmcbtc As String = "https://btc-e.com/api/2/nmc_btc/ticker"
    Dim url_btcenvcusd As String = "https://btc-e.com/api/2/nvc_usd/ticker"
    Dim url_btcenvcbtc As String = "https://btc-e.com/api/2/nvc_btc/ticker"
    Dim url_btceppcusd As String = "https://btc-e.com/api/2/ppc_usd/ticker"
    Dim url_btceppcbtc As String = "https://btc-e.com/api/2/ppc_btc/ticker"
    Dim url_krakenbtcusd As String = "https://api.kraken.com/0/public/Ticker?pair=XBTUSD"
    Dim url_krakenbtcEUR As String = "https://api.kraken.com/0/public/Ticker?pair=XBTEUR"
    Dim url_krakenbtcLTC As String = "https://api.kraken.com/0/public/Ticker?pair=XBTLTC"
    Dim url_krakenltcusd As String = "https://api.kraken.com/0/public/Ticker?pair=LTCUSD"
    Dim url_krakenltceur As String = "https://api.kraken.com/0/public/Ticker?pair=LTCEUR"
    Dim url_cryptsybtcqqb As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=10"
    Dim url_cryptsybtcbtb As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=23"
    Dim url_cryptsybtccap As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=53"
    Dim url_cryptsybtccrc As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=58"
    Dim url_cryptsybtcelc As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=12"
    Dim url_cryptsybtcfrc As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=39"
    Dim url_cryptsybtcfrk As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=33"
    Dim url_cryptsybtcltc As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=3"
    Dim url_cryptsybtctrc As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=27"
    Dim url_cryptsybtcpts As String = "http://pubapi.cryptsy.com/api.php?method=singlemarketdata&marketid=119"
    Dim align As Integer = 0 '0=4x1  1=1x4 2=2x2


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        p1.reg_url = "p1_url"
        p1.reg_market = "p1_market"
        p1.reg_currency = "p1_cur"
        p1.reg_enable = "p1_enable"
        p1.reg_coin = "p1_coin"
        p2.reg_url = "p2_url"
        p2.reg_market = "p2_market"
        p2.reg_currency = "p2_cur"
        p2.reg_enable = "p2_enable"
        p2.reg_coin = "p2_coin"
        p3.reg_url = "p3_url"
        p3.reg_market = "p3_market"
        p3.reg_currency = "p3_cur"
        p3.reg_enable = "p3_enable"
        p3.reg_coin = "p3_coin"
        p4.reg_url = "p4_url"
        p4.reg_market = "p4_market"
        p4.reg_currency = "p4_cur"
        p4.reg_enable = "p4_enable"
        p4.reg_coin = "p4_coin"
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
        p1.dec = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_dec", "2")
        p2.dec = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_dec", "2")
        p3.dec = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_dec", "2")
        p4.dec = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_dec", "2")
        p1.coin = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_coin", "BTC")
        p2.coin = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_coin", "BTC")
        p3.coin = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_coin", "BTC")
        p4.coin = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_coin", "BTC")
        p1.enable = True
        If p1.enable Then
            panels = 1
            panel_update(p1, 1)
        End If

        If p2.enable Then
            panels = 2
            panel_update(p2, 2)
        End If

        If p3.enable Then
            panels = 3
            panel_update(p3, 3)
        End If

        If p4.enable Then
            panels = 4
            panel_update(p4, 4)
        End If

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
        p1.alert_1_val = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_val1", 0)
        p1.alert_2_val = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_val2", 0)
        p1.alert_1_ar = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_ar1", 0)
        p1.alert_2_ar = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_ar2", 0)
        p1.alert_or = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_or", 0)
        p1.alert_set = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_set", 0)
        If p1.alert_set Then p1_alert_onoff.BackColor = Color.Red
        p2.alert_1_val = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_val1", 0)
        p2.alert_2_val = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_val2", 0)
        p2.alert_1_ar = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_ar1", 0)
        p2.alert_2_ar = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_ar2", 0)
        p2.alert_or = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_or", 0)
        p2.alert_set = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_set", 0)
        If p2.alert_set Then rb_p2_alertonoff.BackColor = Color.Red
        p3.alert_1_val = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_val1", 0)
        p3.alert_2_val = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_val2", 0)
        p3.alert_1_ar = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_ar1", 0)
        p3.alert_2_ar = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_ar2", 0)
        p3.alert_or = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_or", 0)
        p3.alert_set = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_set", 0)
        If p3.alert_set Then rb_p3_alertonoff.BackColor = Color.Red
        p4.alert_1_val = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_val1", 0)
        p4.alert_2_val = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_val2", 0)
        p4.alert_1_ar = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_ar1", 0)
        p4.alert_2_ar = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_ar2", 0)
        p4.alert_or = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_or", 0)
        p4.alert_set = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_set", 0)
        If p4.alert_set Then rb_p4_alertonoff.BackColor = Color.Red
        NotifyIcon1.Visible = False
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
        Dim z, pos As Integer
        Dim x As String
        panel_update(p1, 1)
        If p2.enable = True Then
            panel_update(p2, 2)
        End If
        If p3.enable = True Then
            panel_update(p3, 3)
        End If
        If p4.enable = True Then
            panel_update(p4, 4)
        End If
    End Sub
   
    
   
 
    
   

    Private Sub EURToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EURToolStripMenuItem.Click

        set_market(p1, "EUR", "mtgox", "BTC", url_mtgoxeur)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub USDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USDToolStripMenuItem.Click
        set_market(p1, "USD", "mtgox", "BTC", url_mtgoxusd)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub GBPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GBPToolStripMenuItem.Click
        set_market(p1, "GBP", "mtgox", "BTC", url_mtgoxgbp)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub USDToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USDToolStripMenuItem1.Click
        set_market(p1, "USD", "bitstamp", "BTC", url_bitstampusd)
        alert_off(1)
        panel_update(p1, 1)
        
    End Sub
    Private Function GetUnixTimestamp(ByVal currDate As DateTime) As Double
        'create Timespan by subtracting the value provided from the Unix Epoch
        Dim span As TimeSpan = (currDate - New DateTime(2012, 1, 1, 0, 0, 0, 0).ToLocalTime())
        'return the total seconds (which is a UNIX timestamp)
        Return span.TotalSeconds
    End Function

  

    Private Sub CNYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNYToolStripMenuItem.Click
        set_market(p1, "CNY", "btcchiona", "BTC", url_btcchinacny)
        alert_off(1)
        panel_update(p1, 1)
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
        set_market(p4, "EUR", "mtgox", "BTC", url_mtgoxeur)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_mtgoxusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_mtgoxusd.Click
        set_market(p4, "USD", "mtgox", "BTC", url_mtgoxusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_mtgoxgbp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_mtgoxgbp.Click
        set_market(p4, "GBP", "mtgox", "BTC", url_mtgoxgbp)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_bitstampusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_bitstampusd.Click
        set_market(p4, "USD", "bitstamp", "BTC", url_bitstampusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_btcchinacny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_btcchinacny.Click
        set_market(p4, "CNY", "btcchina", "BTC", url_btcchinacny)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp3_btcchinacny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_btcchinacny.Click
        set_market(p3, "CNY", "btcchina", "BTC", url_btcchinacny)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_bitstampusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_bitstampusd.Click
        set_market(p3, "USD", "bitstamp", "BTC", url_bitstampusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_mtgoxeur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_mtgoxeur.Click
        set_market(p3, "EUR", "mtgox", "BTC", url_mtgoxeur)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_mtgoxusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_mtgoxusd.Click
        set_market(p3, "USD", "mtgox", "BTC", url_mtgoxusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_mtgoxgbp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_mtgoxgbp.Click
        set_market(p3, "GBP", "mtgox", "BTC", url_mtgoxgbp)
        alert_off(3)

        panel_update(p3, 3)
    End Sub

    Private Sub cmp2_btcchinacny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_btcchinacny.Click
        set_market(p2, "CNY", "btcchina", "BTC", url_btcchinacny)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_bitstampusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_bitstampusd.Click
        set_market(p2, "USD", "bitstamp", "BTC", url_bitstampusd)
        alert_off(2)
        panel_update(p2, 2)

    End Sub

    Private Sub cmp2_mtgoxeur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_mtgoxeur.Click
        set_market(p2, "EUR", "mtgox", "BTC", url_mtgoxeur)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_mtgoxusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_mtgoxusd.Click
        set_market(p2, "USD", "mtgox", "BTC", url_mtgoxusd)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_mtgoxgbp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_mtgoxgbp.Click
        set_market(p2, "GBP", "mtgox", "BTC", url_mtgoxgbp)
        alert_off(2)
        panel_update(p2, 2)
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

    Private Sub AlarmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_alert.Click
        ALERT_PANEL = 1
        Form2.ShowDialog()


    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_alert.Click
        ALERT_PANEL = 2
        Form2.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_alert.Click
        ALERT_PANEL = 3
        Form2.ShowDialog()
    End Sub

    Private Sub cmp4_alarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_alert.Click
        ALERT_PANEL = 4
        Form2.ShowDialog()
    End Sub
    

    Private Sub alert_timer_Tick(sender As System.Object, e As System.EventArgs) Handles alert_timer.Tick
        If p1.alert = 1 Then
            Panel1.BackColor = Color.Red
            p1.alert = 2
            GoTo p2
        End If
        If p1.alert = 2 Then
            Panel1.BackColor = Color.Black
            p1.alert = 1
        End If
        If p1.alert = 0 Then
            Panel1.BackColor = Color.Black
        End If
p2:
        If p2.alert = 1 Then
            Panel2.BackColor = Color.Red
            p2.alert = 2
            GoTo p3
        End If
        If p2.alert = 2 Then
            Panel2.BackColor = Color.Black
            p2.alert = 1
        End If
p3:
        If p3.alert = 1 Then
            Panel3.BackColor = Color.Red
            p3.alert = 2
            GoTo p4
        End If
        If p3.alert = 2 Then
            Panel3.BackColor = Color.Black
            p3.alert = 1
        End If
p4:
        If p4.alert = 1 Then
            Panel4.BackColor = Color.Red
            p4.alert = 2
            GoTo p5
        End If
        If p4.alert = 2 Then
            Panel4.BackColor = Color.Black
            p4.alert = 1
        End If
p5:

    End Sub
    

    Private Sub MinimizeInTaskbarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeInTaskbarToolStripMenuItem.Click
        Me.NotifyIcon1.Visible = True

        'Me.WindowState = FormWindowState.Minimized
        Me.Visible = False

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If (FormWindowState.Minimized) Then
            'Me.WindowState = FormWindowState.Normal
            Me.Visible = True
        End If
        Me.Activate()
    End Sub
    Private Sub InfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub
    Private Sub EURToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EURToolStripMenuItem1.Click
        set_market(p1, "EUR", "BTC-E", "BTC", url_btceur)
        alert_off(1)
        panel_update(p1, 1)
    End Sub
    Private Sub USDToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USDToolStripMenuItem2.Click
        set_market(p1, "USD", "BTC-E", "BTC", url_btceusd)
        alert_off(1)
        panel_update(p1, 1)
    End Sub
    Private Sub USDToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USDToolStripMenuItem3.Click
        set_market(p2, "USD", "BTC-E", "BTC", url_btceusd)
        alert_off(2)
        panel_update(p2, 2)
    End Sub
    Private Sub EURToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EURToolStripMenuItem2.Click
        set_market(p1, "EUR", "BTC-E", "BTC", url_btceur)
        alert_off(1)
        panel_update(p1, 1)
    End Sub
    Private Sub USDToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USDToolStripMenuItem4.Click
        set_market(p3, "USD", "BTC-E", "BTC", url_btceusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub
    Private Sub EURToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EURToolStripMenuItem3.Click
        set_market(p3, "EUR", "BTC-E", "BTC", url_btceur)
        alert_off(3)
        panel_update(p3, 3)
    End Sub
    Private Sub USDToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USDToolStripMenuItem5.Click
        set_market(p4, "USD", "BTC-E", "BTC", url_btceusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub EURToolStripMenuItem4_Click(sender As System.Object, e As System.EventArgs) Handles EURToolStripMenuItem4.Click
        set_market(p4, "EUR", "BTC-E", "BTC", url_btceur)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub LTCUSDToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LTCUSDToolStripMenuItem.Click
        set_market(p1, "USD", "BTC-E", "LTC", url_btcltcusd)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub LTCBTCToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LTCBTCToolStripMenuItem.Click
        set_market(p1, "BTC", "BTC-E", "LTC", url_btcltcbtc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub LTCEURToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LTCEURToolStripMenuItem.Click
        set_market(p1, "EUR", "BTC-E", "LTC", url_btcltceur)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub LTCUSDToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles LTCUSDToolStripMenuItem1.Click
        set_market(p2, "USD", "BTC-E", "LTC", url_btcltcusd)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub LTCBTCToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles LTCBTCToolStripMenuItem1.Click
        set_market(p2, "BTC", "BTC-E", "LTC", url_btcltcbtc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub LTCEURToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles LTCEURToolStripMenuItem1.Click
        set_market(p2, "EUR", "BTC-E", "LTC", url_btcltceur)
        alert_off(2)
        panel_update(p2, 2)
    End Sub


    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        p1.dec = 1
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_dec", "1")
        panel_update(p1, 1)
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        p1.dec = 2
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_dec", "2")
        panel_update(p1, 1)
    End Sub

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        p1.dec = 3
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_dec", "3")
        panel_update(p1, 1)
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        p1.dec = 4
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_dec", "4")
        panel_update(p1, 1)
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        p1.dec = 5
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_dec", "5")
        panel_update(p1, 1)
    End Sub

    Private Sub PPCUSDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPCUSDBToolStripMenuItem.Click
        set_market(p1, "USD", "BTC-E", "PPC", url_btceppcusd)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub NMCUSDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NMCUSDToolStripMenuItem.Click
        set_market(p1, "USD", "BTC-E", "NMC", url_btcenmcusd)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub NMCBTCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NMCBTCToolStripMenuItem.Click
        set_market(p1, "BTC", "BTC-E", "NMC", url_btceppcbtc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub NVCUSDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVCUSDToolStripMenuItem.Click
        set_market(p1, "USD", "BTC-E", "NVC", url_btcenvcusd)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub NVCBTCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVCBTCToolStripMenuItem.Click
        set_market(p1, "BTC", "BTC-E", "NVC", url_btcenvcbtc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub PPCBTCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPCBTCToolStripMenuItem.Click
        set_market(p1, "BTC", "BTC-E", "PPC", url_btceppcbtc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub NMCUSDToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NMCUSDToolStripMenuItem1.Click
        set_market(p2, "USD", "BTC-E", "NMC", url_btcenmcusd)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub NMCBTCToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NMCBTCToolStripMenuItem1.Click
        set_market(p2, "BTC", "BTC-E", "NMC", url_btcenmcbtc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub NVCUSDToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVCUSDToolStripMenuItem1.Click
        set_market(p2, "USD", "BTC-E", "NVC", url_btcenvcusd)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub NVCBTCToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVCBTCToolStripMenuItem1.Click
        set_market(p2, "BTC", "BTC-E", "NVC", url_btcenvcbtc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub PPCUSDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPCUSDToolStripMenuItem.Click
        set_market(p2, "USD", "BTC-E", "PPC", url_btceppcusd)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub PPCBTCToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPCBTCToolStripMenuItem1.Click
        set_market(p2, "BTC", "BTC-E", "PPC", url_btceppcbtc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub


    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        p2.dec = 1
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_dec", "1")
        panel_update(p2, 2)
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        p2.dec = 2
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_dec", "2")
        panel_update(p2, 2)
    End Sub

    Private Sub ToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem27.Click
        p2.dec = 3
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_dec", "3")
        panel_update(p2, 2)
    End Sub

    Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        p2.dec = 4
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_dec", "4")
        panel_update(p2, 2)
    End Sub

    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem28.Click
        p2.dec = 5
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_dec", "5")
        panel_update(p2, 2)
    End Sub

    Private Sub ToolStripMenuItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem33.Click
        p3.dec = 1
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_dec", "1")
        panel_update(p3, 3)
    End Sub

    Private Sub ToolStripMenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem34.Click
        p3.dec = 2
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_dec", "2")
        panel_update(p3, 3)
    End Sub

    Private Sub ToolStripMenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem36.Click
        p3.dec = 3
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_dec", "3")
        panel_update(p3, 3)
    End Sub

    Private Sub ToolStripMenuItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem35.Click
        p3.dec = 4
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_dec", "4")
        panel_update(p3, 3)
    End Sub

    Private Sub ToolStripMenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem37.Click
        p3.dec = 5
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_dec", "5")
        panel_update(p3, 3)
    End Sub

    Private Sub ToolStripMenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem40.Click
        p4.dec = 1
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_dec", "1")
        panel_update(p4, 4)
    End Sub

    Private Sub ToolStripMenuItem41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem41.Click
        p4.dec = 2
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_dec", "2")
        panel_update(p4, 4)
    End Sub

    Private Sub ToolStripMenuItem43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem43.Click
        p4.dec = 3
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_dec", "3")
        panel_update(p4, 4)
    End Sub

    Private Sub ToolStripMenuItem42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem42.Click
        p4.dec = 4
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_dec", "4")
        panel_update(p4, 4)
    End Sub

    Private Sub ToolStripMenuItem44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem44.Click
        p4.dec = 5
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_dec", "5")
        panel_update(p4, 4)
    End Sub

    Private Sub LTCUSDToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTCUSDToolStripMenuItem2.Click
        set_market(p3, "USD", "BTC-E", "LTC", url_btcltcusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub NMCUSDToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NMCUSDToolStripMenuItem2.Click
        set_market(p3, "USD", "BTC-E", "NMC", url_btcenmcusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub NVCUSDToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVCUSDToolStripMenuItem2.Click
        set_market(p3, "USD", "BTC-E", "NVC", url_btcenvcusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub PPCUSDToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPCUSDToolStripMenuItem1.Click
        set_market(p3, "USD", "BTC-E", "PPC", url_btceppcusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub LTCEURToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTCEURToolStripMenuItem2.Click
        set_market(p3, "EUR", "BTC-E", "LTC", url_btcltceur)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub LTCBTCToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTCBTCToolStripMenuItem2.Click
        set_market(p3, "BTC", "BTC-E", "LTC", url_btcltcbtc)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub NMCBTCToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NMCBTCToolStripMenuItem2.Click
        set_market(p3, "BTC", "BTC-E", "NMC", url_btcenmcbtc)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub NVCBTCToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVCBTCToolStripMenuItem2.Click
        set_market(p3, "BTC", "BTC-E", "NVC", url_btcenvcbtc)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub PPCBTCToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPCBTCToolStripMenuItem2.Click
        set_market(p3, "BTC", "BTC-E", "PPC", url_btceppcbtc)
        alert_off(3)

        panel_update(p3, 3)
    End Sub

    Private Sub LTCUSDToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTCUSDToolStripMenuItem3.Click
        set_market(p4, "USD", "BTC-E", "LTC", url_btcltcusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub NMCUSDToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NMCUSDToolStripMenuItem3.Click
        set_market(p4, "USD", "BTC-E", "NMC", url_btcenmcusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub NVCUSDToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVCUSDToolStripMenuItem3.Click
        set_market(p4, "USD", "BTC-E", "NVC", url_btcenvcusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub PPCUSDToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPCUSDToolStripMenuItem2.Click
        set_market(p4, "USD", "BTC-E", "PPC", url_btceppcusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub LTCEURToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTCEURToolStripMenuItem3.Click
        set_market(p4, "EUR", "BTC-E", "LTC", url_btcltceur)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub LTCBTCToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTCBTCToolStripMenuItem3.Click
        set_market(p4, "BTC", "BTC-E", "LTC", url_btcltcbtc)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub NMCBTCToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NMCBTCToolStripMenuItem3.Click
        set_market(p4, "BTC", "BTC-E", "NMC", url_btcenmcbtc)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub NVCBTCToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVCBTCToolStripMenuItem3.Click
        set_market(p4, "BTC", "BTC-E", "NVC", url_btcenvcbtc)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub PPCBTCToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPCBTCToolStripMenuItem3.Click
        set_market(p4, "BTC", "BTC-E", "PPC", url_btceppcbtc)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub BTCUSDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCUSDToolStripMenuItem.Click
        set_market(p1, "USD", "kraken", "BTC", url_krakenbtcusd)
        alert_off(1)

        panel_update(p1, 1)
    End Sub

    Private Sub BTCEURToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCEURToolStripMenuItem.Click
        set_market(p1, "EUR", "kraken", "BTC", url_krakenbtcEUR)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub BTCLTCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCLTCToolStripMenuItem.Click
        set_market(p1, "LTC", "kraken", "BTC", url_krakenbtcLTC)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub LTCUSDToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTCUSDToolStripMenuItem4.Click
        set_market(p1, "USD", "kraken", "LTC", url_krakenltcusd)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub LTCEURToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTCEURToolStripMenuItem4.Click
        set_market(p1, "EUR", "kraken", "LTC", url_krakenltceur)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub BBQBTCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_bbqbtc.Click
        set_market(p1, "BTC", "cryptsy", "BBQ", url_cryptsybtcqqb)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub ToolStripMenuItem46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem46.Click
        p1.dec = 8
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_dec", "8")
        panel_update(p1, 1)
    End Sub

    Private Sub BTBBTCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_btbbtc.Click
        set_market(p1, "BTC", "cryptsy", "BTB", url_cryptsybtcbtb)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub CAPBTCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_capbtc.Click
        set_market(p1, "BTC", "cryptsy", "CAP", url_cryptsybtccap)
        alert_off(1)
        panel_update(p1, 1)
    End Sub


    Private Sub cmp2_cryptsy_bbqbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_bbqbtc.Click
        set_market(p2, "BTC", "cryptsy", "BBQ", url_cryptsybtcqqb)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_cryptsy_BTBbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_BTBbtc.Click
        set_market(p2, "BTC", "cryptsy", "BTB", url_cryptsybtcbtb)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_cryptsy_capbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_capbtc.Click
        set_market(p2, "BTC", "cryptsy", "CAP", url_cryptsybtccap)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp3_cryptsybbqbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsybbqbtc.Click
        set_market(p3, "BTC", "cryptsy", "BBQ", url_cryptsybtcqqb)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_cryptsybtbbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsybtbbtc.Click
        set_market(p3, "BTC", "cryptsy", "BTB", url_cryptsybtcbtb)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_cryptsycapbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsycapbtc.Click
        set_market(p3, "BTC", "cryptsy", "CAP", url_cryptsybtccap)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp4_cryptsy_bbqbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_cryptsy_bbqbtc.Click
        set_market(p4, "BTC", "cryptsy", "BBQ", url_cryptsybtcqqb)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_cryptsy_btcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_cryptsy_btcbtc.Click
        set_market(p4, "BTC", "cryptsy", "BTB", url_cryptsybtcbtb)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_cryptsy_capbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_cryptsy_capbtc.Click
        set_market(p4, "BTC", "cryptsy", "CAP", url_cryptsybtccap)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp2_kraken_btcusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_kraken_btcusd.Click
        set_market(p2, "USD", "kraken", "BTC", url_krakenbtcusd)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_kraken_btceur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_kraken_btceur.Click
        set_market(p2, "EUR", "kraken", "BTC", url_krakenbtcEUR)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_kraken_btcltc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_kraken_btcltc.Click
        set_market(p2, "LTC", "kraken", "BTC", url_krakenbtcLTC)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_kraken_ltcusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_kraken_ltcusd.Click
        set_market(p2, "USD", "kraken", "LTC", url_krakenltcusd)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_kraken_ltceur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_kraken_ltceur.Click
        set_market(p2, "EUR", "kraken", "LTC", url_krakenltceur)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp3_kraken_btcusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_kraken_btcusd.Click
        set_market(p3, "USD", "kraken", "BTC", url_krakenbtcusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_kraken_btceur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_kraken_btceur.Click
        set_market(p3, "EUR", "kraken", "BTC", url_krakenbtcEUR)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_kraken_btcltc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_kraken_btcltc.Click
        set_market(p3, "LTC", "kraken", "BTC", url_krakenbtcLTC)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_kraken_ltcusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_kraken_ltcusd.Click
        set_market(p3, "USD", "kraken", "LTC", url_krakenltcusd)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_kraken_ltceur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_kraken_ltceur.Click
        set_market(p3, "EUR", "kraken", "LTC", url_krakenltceur)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp4_kraken_ltceur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_kraken_ltceur.Click
        set_market(p4, "EUR", "kraken", "LTC", url_krakenltceur)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_kraken_ltcusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_kraken_ltcusd.Click
        set_market(p4, "USD", "kraken", "LTC", url_krakenltcusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_kraken_btcltc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_kraken_btcltc.Click
        set_market(p4, "LTC", "kraken", "BTC", url_krakenbtcLTC)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_kraken_btceur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_kraken_btceur.Click
        set_market(p4, "EUR", "kraken", "BTC", url_krakenbtcEUR)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_kraken_btcusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_kraken_btcusd.Click
        set_market(p4, "USD", "kraken", "BTC", url_krakenbtcusd)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        p2.dec = 8
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_dec", "8")
        panel_update(p2, 2)
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        p3.dec = 8
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_dec", "8")
        panel_update(p3, 3)
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        p4.dec = 8
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_dec", "8")
        panel_update(p4, 4)
    End Sub

    Private Sub cmp1_cryptsy_crcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_crcbtc.Click
        set_market(p1, "BTC", "cryptsy", "CRC", url_cryptsybtccrc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub cmp1_cryptsy_elcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_elcbtc.Click
        set_market(p1, "BTC", "cryptsy", "ELC", url_cryptsybtcelc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub cmp1_cryptsy_frcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_frcbtc.Click
        set_market(p1, "BTC", "cryptsy", "FRC", url_cryptsybtcfrc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub cmp1_cryptsy_frkbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_frkbtc.Click
        set_market(p1, "BTC", "cryptsy", "FRK", url_cryptsybtcfrk)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub cmp1_cryptsy_ltcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_ltcbtc.Click
        set_market(p1, "BTC", "cryptsy", "LTC", url_cryptsybtcltc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub cmp1_cryptsy_trcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_trcbtc.Click
        set_market(p1, "BTC", "cryptsy", "TRC", url_cryptsybtctrc)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub cmp1_cryptsy_ptsbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp1_cryptsy_ptsbtc.Click
        set_market(p1, "BTC", "cryptsy", "PTS", url_cryptsybtcpts)
        alert_off(1)
        panel_update(p1, 1)
    End Sub

    Private Sub cmp2_cryptsy_crcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_crcbtc.Click
        set_market(p2, "BTC", "cryptsy", "CRC", url_cryptsybtccrc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_cryptsy_elcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_elcbtc.Click
        set_market(p2, "BTC", "cryptsy", "ELC", url_cryptsybtcelc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_cryptsy_frcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_frcbtc.Click
        set_market(p2, "BTC", "cryptsy", "FRC", url_cryptsybtcfrc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_cryptsy_frkbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_frkbtc.Click
        set_market(p2, "BTC", "cryptsy", "FRK", url_cryptsybtcfrk)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_cryptsy_ltcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_ltcbtc.Click
        set_market(p2, "BTC", "cryptsy", "LTC", url_cryptsybtcltc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_cryptsy_trcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_trcbtc.Click
        set_market(p2, "BTC", "cryptsy", "TRC", url_cryptsybtctrc)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp2_cryptsy_ptsbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp2_cryptsy_ptsbtc.Click
        set_market(p2, "BTC", "cryptsy", "PTS", url_cryptsybtcpts)
        alert_off(2)
        panel_update(p2, 2)
    End Sub

    Private Sub cmp3_cryptsy_crcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsy_crcbtc.Click
        set_market(p3, "BTC", "cryptsy", "CRC", url_cryptsybtccrc)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_cryptsy_elcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsy_elcbtc.Click
        set_market(p3, "BTC", "cryptsy", "ELC", url_cryptsybtcelc)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_cryptsy_frcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsy_frcbtc.Click
        set_market(p3, "BTC", "cryptsy", "FRC", url_cryptsybtcfrc)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_cryptsy_frkbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsy_frkbtc.Click
        set_market(p3, "BTC", "cryptsy", "FRK", url_cryptsybtcfrk)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_cryptsy_ltcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsy_ltcbtc.Click
        set_market(p3, "BTC", "cryptsy", "LTC", url_cryptsybtcltc)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_cryptsy_trcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsy_trcbtc.Click
        set_market(p3, "BTC", "cryptsy", "TRC", url_cryptsybtctrc)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp3_cryptsy_ptsbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp3_cryptsy_ptsbtc.Click
        set_market(p3, "BTC", "cryptsy", "PTS", url_cryptsybtcpts)
        alert_off(3)
        panel_update(p3, 3)
    End Sub

    Private Sub cmp4_crptsy_crcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_crptsy_crcbtc.Click
        set_market(p4, "BTC", "cryptsy", "CRC", url_cryptsybtccrc)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_crptsy_elcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_crptsy_elcbtc.Click
        set_market(p4, "BTC", "cryptsy", "ELC", url_cryptsybtcelc)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_crptsy_frcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_crptsy_frcbtc.Click
        set_market(p4, "BTC", "cryptsy", "FRC", url_cryptsybtcfrc)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_crptsy_frkbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_crptsy_frkbtc.Click
        set_market(p4, "BTC", "cryptsy", "FRK", url_cryptsybtcfrk)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_crptsy_ltcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_crptsy_ltcbtc.Click
        set_market(p4, "BTC", "cryptsy", "LTC", url_cryptsybtcltc)
        alert_off(4)
        panel_update(p4, 4)

    End Sub

    Private Sub cmp4_crptsy_trcbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_crptsy_trcbtc.Click
        set_market(p4, "BTC", "cryptsy", "TRC", url_cryptsybtctrc)
        alert_off(4)
        panel_update(p4, 4)
    End Sub

    Private Sub cmp4_crptsy_ptsbtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmp4_crptsy_ptsbtc.Click
        set_market(p4, "BTC", "cryptsy", "PTS", url_cryptsybtcpts)
        alert_off(4)
        panel_update(p4, 4)
    End Sub
End Class
