Imports Newtonsoft.Json

Public Class BoardingPass
  Inherits Pass
  Implements IPassStyle

  Private _transitType As String
  <JsonProperty("transitType")>
  Public Property TransitType() As String
    Get
      Return _transitType
    End Get
    Set(ByVal value As String)
      _transitType = value
    End Set
  End Property

End Class
