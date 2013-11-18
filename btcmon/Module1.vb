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
End Module
