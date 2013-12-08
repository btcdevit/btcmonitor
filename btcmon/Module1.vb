Module Module1
    Public Structure panel
        Public currency As String
        Public market As String
        Public buy As String
        Public sell As String
        Public time As String
        Public value As Double
        Public last_value As Double
        Public trend As String
        Public enable As Boolean
        Public status As String
        Public url As String
        Public col As Integer
        Public row As Integer
        Public alert_1_val As Double
        Public alert_2_val As Double
        Public alert_1_ar As Integer
        Public alert_2_ar As Integer
        Public alert_or As Boolean
        Public alert_set As Boolean
        Public alert As Integer
        Public coin As String
        Public dec As Integer
        Public format As System.IFormatProvider
        Public reg_url As String
        Public reg_market As String
        Public reg_currency As String
        Public reg_enable As String
        Public reg_coin As String

    End Structure
    Public Structure st_mtgox
        Public result As String
        Public now As String
        Public last_local As String
        Public buy As String
        Public sell As String
    End Structure
    Public Structure st_bitstamp
        Public now As String
        Public last As String
        Public buy As String
        Public sell As String
    End Structure
    Public Structure st_btcchina
        Public last As String
        Public buy As String
        Public sell As String
    End Structure
    Public Structure st_btce
        Public last As String
        Public buy As String
        Public sell As String
        Public now As String
    End Structure
    Public Structure st_kraken
        Public last As String
        Public buy As String
        Public sell As String
    End Structure
    Public Structure st_cryptsy
        Public last As String
        Public sell As String
        Public buy As String
        Public now As String

    End Structure
    Public ALERT_PANEL As Integer
    Public p1 As New panel
    Public p2 As New panel
    Public p3 As New panel
    Public p4 As New panel

    Public mtgox As New st_mtgox
    Public bitstamp As New st_bitstamp
    Public btcchina As New st_btcchina
    Public btce As New st_btce
    Public kraken As New st_kraken
    Public cryptsy As New st_cryptsy
    Public Sub set_market(ByRef p As panel, ByVal currency As String, ByVal market As String, ByVal coin As String, ByVal url As String)
        p.currency = currency
        p.market = market
        p.coin = coin
        p.url = url
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", p.reg_market, market)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", p.reg_currency, currency)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", p.reg_url, url)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", p.reg_enable, "1")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", p.reg_coin, coin)
    End Sub
    Public Sub alert_off(ByVal panel As Integer)
        If panel = 1 Then
            p1.alert_set = False
            p1.alert = 0
            Form1.p1_alert_onoff.BackColor = Color.Black
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p1_alert_set", p1.alert_set)
        End If
        If panel = 2 Then
            p2.alert_set = False
            p2.alert = 0
            Form1.rb_p2_alertonoff.BackColor = Color.Black
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p2_alert_set", p2.alert_set)
        End If
        If panel = 3 Then
            p3.alert_set = False
            p3.alert = 0
            Form1.rb_p3_alertonoff.BackColor = Color.Black
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p3_alert_set", p3.alert_set)
        End If
        If panel = 4 Then
            p4.alert_set = False
            p4.alert = 0
            Form1.rb_p4_alertonoff.BackColor = Color.Black
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\btcmon", "p4_alert_set", p4.alert_set)
        End If
    End Sub
    Public Sub mtgox_get(ByVal url As String)
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
    Public Sub btce_get(ByVal url As String)
        Try
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim reply As String = client.DownloadString(url)
            Dim st() As String
            Dim a As Integer
            Dim stringSeparators() As String = {":", ","}
            st = reply.Split(stringSeparators, StringSplitOptions.None)
            For Each s As String In st
                If a = 12 Then btce.last = s
                If a = 14 Then btce.buy = s
                If a = 16 Then btce.sell = s
                a = a + 1
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Sub kraken_get(ByVal url As String)
        Try
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim reply As String = client.DownloadString(url)
            Dim st() As String
            Dim u() As String
            Dim a As Integer
            Dim stringSeparators() As String = {":", ","}
            Dim stringSeparators1() As String = {Chr(34)}
            st = reply.Split(stringSeparators, StringSplitOptions.None)
            For Each s As String In st
                If a = 11 Then
                    u = s.Split(stringSeparators1, StringSplitOptions.None)
                    kraken.last = u(1)
                End If
                If a = 5 Then
                    u = s.Split(stringSeparators1, StringSplitOptions.None)
                    kraken.sell = u(1)
                End If
                If a = 8 Then
                    u = s.Split(stringSeparators1, StringSplitOptions.None)
                    kraken.buy = u(1)
                End If
                a = a + 1
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Sub bitstamp_get(ByVal url As String)
        Try
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim reply As String = client.DownloadString(url)
            Dim st() As String
            Dim a As Integer
            Dim stringSeparators() As String = {":", ","}
            st = reply.Split(stringSeparators, StringSplitOptions.None)
            For Each s As String In st
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
    Public Sub cryptsy_get(ByVal url As String)
        Try
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim reply As String = client.DownloadString(url)
            Dim st() As String
            Dim u(), v() As String
            Dim a As Integer
            Dim stringSeparators() As String = {":", ","}
            Dim stringSeparators1() As String = {Chr(34)}
            Dim sellorder() As String = {"sellorders"}
            Dim buyorder() As String = {"buyorders"}
            u = reply.Split(sellorder, StringSplitOptions.None)
            v = reply.Split(buyorder, StringSplitOptions.None)
            st = u(1).Split(stringSeparators, StringSplitOptions.None)
            cryptsy.sell = Mid(st(2), 2, Len(st(2)) - 1)
            st = v(1).Split(stringSeparators, StringSplitOptions.None)
            cryptsy.buy = Mid(st(2), 2, Len(st(2)) - 1)
            st = reply.Split(stringSeparators, StringSplitOptions.None)
            st = reply.Split(stringSeparators, StringSplitOptions.None)
            cryptsy.last = Mid(st(10), 2, Len(st(10)) - 1)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub btcchina_get(ByVal url As String)
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
    Public Sub p1_update()
        Form1.p1_value.ForeColor = Color.White
        If p1.trend = "up" Then Form1.p1_value.ForeColor = Color.Lime
        If p1.trend = "down" Then Form1.p1_value.ForeColor = Color.Red
        Form1.p1_value.Text = p1.value.ToString("###0.00######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
        Form1.p1_cur.Text = p1.currency
        Form1.p1_market.Text = p1.market
        Form1.p1_sell.Text = "sell:" + p1.sell
        Form1.p1_buy.Text = "buy:" + p1.buy
        Form1.p1_coin.Text = p1.coin

    End Sub
    Private Sub p_draw(ByVal i As Integer)
        If i = 1 Then
            Form1.p1_value.ForeColor = Color.White
            If p1.trend = "up" Then Form1.p1_value.ForeColor = Color.Lime
            If p1.trend = "down" Then Form1.p1_value.ForeColor = Color.Red
            Form1.p1_value.Text = p1.value.ToString("###0.00######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
            Form1.p1_cur.Text = p1.currency
            Form1.p1_market.Text = p1.market
            Form1.p1_sell.Text = "sell:" + p1.sell
            Form1.p1_buy.Text = "buy:" + p1.buy
            Form1.p1_coin.Text = p1.coin
        End If
        If i = 2 Then
            Form1.p2_value.ForeColor = Color.White
            If p2.trend = "up" Then Form1.p2_value.ForeColor = Color.Lime
            If p2.trend = "down" Then Form1.p2_value.ForeColor = Color.Red
            Form1.p2_value.Text = p2.value.ToString("###0.00######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
            Form1.p2_cur.Text = p2.currency
            Form1.p2_market.Text = p2.market
            Form1.p2_sell.Text = "sell:" + p2.sell
            Form1.p2_buy.Text = "buy:" + p2.buy
            Form1.p2_coin.Text = p2.coin
        End If
        If i = 3 Then
            Form1.p3_value.ForeColor = Color.White
            If p3.trend = "up" Then Form1.p3_value.ForeColor = Color.Lime
            If p3.trend = "down" Then Form1.p3_value.ForeColor = Color.Red
            Form1.p3_value.Text = p3.value.ToString("###0.00######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
            Form1.p3_cur.Text = p3.currency
            Form1.p3_market.Text = p3.market
            Form1.p3_sell.Text = "sell:" + p3.sell
            Form1.p3_buy.Text = "buy:" + p3.buy
            Form1.p3_coin.Text = p3.coin
        End If
        If i = 4 Then
            Form1.p4_value.ForeColor = Color.White
            If p4.trend = "up" Then Form1.p4_value.ForeColor = Color.Lime
            If p4.trend = "down" Then Form1.p4_value.ForeColor = Color.Red
            Form1.p4_value.Text = p4.value.ToString("###0.00######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
            Form1.p4_cur.Text = p4.currency
            Form1.p4_market.Text = p4.market
            Form1.p4_sell.Text = "sell:" + p4.sell
            Form1.p4_buy.Text = "buy:" + p4.buy
            Form1.p4_coin.Text = p4.coin
        End If

    End Sub
    Public Sub panel_update(ByRef p As panel, ByVal i As Integer)
        Dim a, b As Double
        Dim c, d As Double
        Dim z, pos As Integer
        Dim x As String
        If p.market = "mtgox" Then
            mtgox_get(p.url)
            If mtgox.result = "success" Then
                p.sell = mtgox.sell
                p.buy = mtgox.buy
                p.time = mtgox.now
                p.status = mtgox.result
                a = Int(Mid(mtgox.last_local, 1, Len(mtgox.last_local) - 6))
                b = Int(Mid(mtgox.last_local, Len(mtgox.last_local) - 4, 2))
                b = b / 100
                p.value = a + b
                If p.value > p.last_value Then p.trend = "up"
                If p.value < p.last_value Then p.trend = "down"
                p.last_value = p.value
                p_draw(i)
            End If
        End If
        If p.market = "bitstamp" Then
            bitstamp_get(p.url)
            p.sell = bitstamp.sell
            p.buy = bitstamp.buy
            p.time = bitstamp.now
            a = Int(Mid(bitstamp.last, 1, Len(bitstamp.last) - 3))
            b = Int(Mid(bitstamp.last, Len(bitstamp.last) - 2, 2))
            b = b / 100
            p.value = a + b
            If p.value > p.last_value Then p.trend = "up"
            If p.value < p.last_value Then p.trend = "down"
            p.last_value = p.value
            p_draw(i)
        End If

        If p.market = "btcchina" Then
            btcchina_get(p.url)
            p.sell = btcchina.sell
            p.buy = btcchina.buy
            p.time = "0"
            a = Int(Mid(btcchina.last, 1, Len(btcchina.last) - 3))
            b = Int(Mid(btcchina.last, Len(btcchina.last) - 1, 2))
            b = b / 100
            p.value = a + b
            If p.value > p.last_value Then p.trend = "up"
            If p.value < p.last_value Then p.trend = "down"
            p.last_value = p.value
            p_draw(i)
        End If
        If p.market = "BTC-E" Then
            btce_get(p.url)
            If Len(btce.sell) > 10 Then p.sell = Mid(btce.sell, 1, 10) Else p.sell = btce.sell
            If Len(btce.buy) > 10 Then p.buy = Mid(btce.buy, 1, 10) Else p.buy = btce.buy
            p.time = btce.now
            z = 1
            For z = 1 To Len(btce.last)
                If Mid(btce.last, z, 1) = "." Then pos = z
            Next
            If pos > 0 Then
                a = Int(Mid(btce.last, 1, pos - 1))
                If Len(btce.last) - pos > 1 Then
                    x = Mid(btce.last, pos + 1, p.dec)
                Else
                    x = Mid(btce.last, pos + 1, 1)
                End If
                If Len(x) >= p.dec Then
                    b = Int(x)
                    b = b / 10 ^ p.dec
                Else
                    b = Int(x)
                    b = b / 10 ^ Len(x)
                End If
                p.value = a + b
            Else
                p.value = Int(btce.last)
            End If
            If p.value > p.last_value Then p.trend = "up"
            If p.value < p.last_value Then p.trend = "down"
            p.last_value = p.value
            p_draw(i)
        End If
        If p.market = "kraken" Then
            kraken_get(p.url)
            If Len(kraken.sell) > 10 Then p.sell = Mid(kraken.sell, 1, 10) Else p.sell = kraken.sell
            If Len(kraken.buy) > 10 Then p.buy = Mid(kraken.buy, 1, 10) Else p.buy = kraken.buy
            z = 1
            For z = 1 To Len(kraken.last)
                If Mid(kraken.last, z, 1) = "." Then pos = z
            Next
            If pos > 0 Then
                a = Int(Mid(kraken.last, 1, pos - 1))
                If Len(kraken.last) - pos > 1 Then
                    x = Mid(kraken.last, pos + 1, p.dec)
                Else
                    x = Mid(kraken.last, pos + 1, 1)
                End If
                If Len(x) >= p.dec Then
                    b = Int(x)
                    b = b / 10 ^ p.dec
                Else
                    b = Int(x)
                    b = b / 10 ^ Len(x)
                End If

                p.value = a + b
            Else
                p.value = Int(kraken.last)
            End If
            If p.value > p.last_value Then p.trend = "up"
            If p.value < p.last_value Then p.trend = "down"
            p.last_value = p.value
            p_draw(i)
        End If
        If p.market = "cryptsy" Then
            cryptsy_get(p.url)
            If Len(cryptsy.sell) > 10 Then p.sell = Mid(cryptsy.sell, 1, 10) Else p.sell = cryptsy.sell
            If Len(cryptsy.buy) > 10 Then p.buy = Mid(cryptsy.buy, 1, 10) Else p.buy = cryptsy.buy
            z = 1
            For z = 1 To Len(cryptsy.last)
                If Mid(cryptsy.last, z, 1) = "." Then pos = z
            Next
            If pos > 0 Then
                a = Int(Mid(cryptsy.last, 1, pos - 1))
                If Len(cryptsy.last) - pos > 1 Then
                    x = Mid(cryptsy.last, pos + 1, p.dec)
                Else
                    x = Mid(cryptsy.last, pos + 1, 1)
                End If
                If Len(x) >= p.dec Then
                    b = Int(x)
                    b = b / 10 ^ p.dec
                Else
                    b = Int(x)
                    b = b / 10 ^ Len(x)
                End If
                p.value = a + b
            Else
                p.value = Int(cryptsy.last)
            End If
            If p.value > p.last_value Then p.trend = "up"
            If p.value < p.last_value Then p.trend = "down"
            p.last_value = p.value
            p_draw(i)
        End If
        alert_chk(i)
    End Sub
    Public Sub alert_chk(ByVal panel As Integer)
        If panel = 1 And p1.alert_set Then
            If p1.alert_1_ar = 0 Then '>=
                If p1.value >= p1.alert_1_val Then p1.alert = 1 Else p1.alert = 0
            Else
                If p1.alert_1_ar = 1 Then '<=
                    If p1.value <= p1.alert_1_val Then p1.alert = 1 Else p1.alert = 0
                End If
            End If
            If p1.alert_or Then
                If p1.alert_2_ar = 0 Then '>=
                    If p1.value >= p1.alert_2_val Then p1.alert = 1
                Else
                    If p1.alert_2_ar = 1 Then '<=
                        If p1.value <= p1.alert_2_val Then p1.alert = 1
                    End If
                End If
            End If
        End If

        If panel = 2 And p2.alert_set Then
            If p2.alert_1_ar = 0 Then '>=
                If p2.value >= p2.alert_1_val Then p2.alert = 1 Else p2.alert = 0
            Else
                If p2.alert_1_ar = 1 Then '<=
                    If p2.value <= p2.alert_1_val Then p2.alert = 1 Else p2.alert = 0
                End If
            End If
            If p2.alert_or Then
                If p2.alert_2_ar = 0 Then '>=
                    If p2.value >= p2.alert_2_val Then p2.alert = 1
                Else
                    If p2.alert_2_ar = 1 Then '<=
                        If p2.value <= p2.alert_2_val Then p2.alert = 1
                    End If
                End If
            End If
        End If

        If panel = 3 And p3.alert_set Then
            If p3.alert_1_ar = 0 Then '>=
                If p3.value >= p3.alert_1_val Then p3.alert = 1 Else p3.alert = 0
            Else
                If p3.alert_1_ar = 1 Then '<=
                    If p3.value <= p3.alert_1_val Then p3.alert = 1 Else p3.alert = 0
                End If
            End If
            If p3.alert_or Then
                If p3.alert_2_ar = 0 Then '>=
                    If p3.value >= p3.alert_2_val Then p3.alert = 1
                Else
                    If p3.alert_2_ar = 1 Then '<=
                        If p3.value <= p3.alert_2_val Then p3.alert = 1
                    End If
                End If
            End If
        End If
        If panel = 4 And p4.alert_set Then
            If p4.alert_1_ar = 0 Then '>=
                If p4.value >= p4.alert_1_val Then p4.alert = 1 Else p4.alert = 0
            Else
                If p4.alert_1_ar = 1 Then '<=
                    If p4.value <= p4.alert_1_val Then p4.alert = 1 Else p4.alert = 0
                End If
            End If
            If p4.alert_or Then
                If p4.alert_2_ar = 0 Then '>=
                    If p4.value >= p4.alert_2_val Then p4.alert = 1
                Else
                    If p4.alert_2_ar = 1 Then '<=
                        If p4.value <= p4.alert_2_val Then p4.alert = 1
                    End If
                End If
            End If
        End If

        If p1.alert <> 0 Or p2.alert <> 0 Or p3.alert <> 0 Or p4.alert <> 0 Then
            Form1.Opacity = 1
            Form1.TopMost = True
            Form1.Visible = True
        End If

    End Sub
End Module
