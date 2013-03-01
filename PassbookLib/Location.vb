
Public Class Location

  Private _altitude As Double
  Public Property Altitude() As Double
    Get
      Return _altitude
    End Get
    Set(ByVal value As Double)
      _altitude = value
    End Set
  End Property

  Private _latitude As Double
  Public Property Latitude() As Double
    Get
      Return _latitude
    End Get
    Set(ByVal value As Double)
      _latitude = value
    End Set
  End Property

  Private _longitude As Double
  Public Property Longitude() As Double
    Get
      Return _longitude
    End Get
    Set(ByVal value As Double)
      _longitude = value
    End Set
  End Property

  Private _relevantText As String
  Public Property RelevantText() As String
    Get
      Return _relevantText
    End Get
    Set(ByVal value As String)
      _relevantText = value
    End Set
  End Property

End Class
