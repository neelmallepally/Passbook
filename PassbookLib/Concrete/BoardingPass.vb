Imports Newtonsoft.Json

<DisplayName("boardingPass")>
Public Class BoardingPass
    Implements IPassStyle

    Private _transitType As String
    <JsonProperty("transitType", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property TransitType() As String
        Get
            Return _transitType
        End Get
        Set(ByVal value As String)
            _transitType = value
        End Set
    End Property
End Class
