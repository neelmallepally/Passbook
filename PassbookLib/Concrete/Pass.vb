Imports Newtonsoft.Json
Imports System.ComponentModel

Public Class Pass

  ''STANDARD KEYS
  Private _description As String
  <JsonProperty("description", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property Description() As String
    Get
      Return _description
    End Get
    Set(ByVal value As String)
      _description = value
    End Set
  End Property

  Private _formatVersion As Integer = 1
  <JsonProperty("formatVersion", Order:=-10, NullValueHandling:=NullValueHandling.Ignore)>
  Public ReadOnly Property FormatVersion() As Integer
    Get
      Return _formatVersion
    End Get
  End Property

  Private _organizationName As String
  <JsonProperty("organizationName", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property OrganizationName() As String
    Get
      Return _organizationName
    End Get
    Set(ByVal value As String)
      _organizationName = value
    End Set
  End Property

  Private _passTypeIdentifier As String
  <JsonProperty("passTypeIdentifier", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property PassTypeIdentifier() As String
    Get
      Return _passTypeIdentifier
    End Get
    Set(ByVal value As String)
      _passTypeIdentifier = value
    End Set
  End Property

  Private _serialNumber As String
  <JsonProperty("serialNumber", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property SerialNumber() As String
    Get
      Return _serialNumber
    End Get
    Set(ByVal value As String)
      _serialNumber = value
    End Set
  End Property

  Private _teamIdentifier As String
  <JsonProperty("teamIdentifier", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property TeamIdentifier() As String
    Get
      Return _teamIdentifier
    End Get
    Set(ByVal value As String)
      _teamIdentifier = value
    End Set
  End Property

  'RELEVANCE KEYS
  Private _locations As System.Collections.Generic.List(Of Location)
  <JsonProperty("locations", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property Locations As System.Collections.Generic.List(Of Location)
    Get
      Return _locations
    End Get
    Set(value As System.Collections.Generic.List(Of Location))
      _locations = value
    End Set
  End Property

  'W3C date
  Private _relevantDate As String
  <JsonProperty("relevantDate", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property RelevantDate() As String
    Get
      Return _relevantDate
    End Get
    Set(ByVal value As String)
      _relevantDate = value
    End Set
  End Property

  'Visual appearance keys
  Private _barcode As Barcode
  <JsonProperty("barcode", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property Barcode() As Barcode
    Get
      Return _barcode
    End Get
    Set(ByVal value As Barcode)
      _barcode = value
    End Set
  End Property

  Private _backgroundColor As String
  <JsonProperty("backgroundColor", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property BackgroundColor() As String
    Get
      Return _backgroundColor
    End Get
    Set(ByVal value As String)
      _backgroundColor = value
    End Set
  End Property

  Private _foregroundColor As String
  <JsonProperty("foregroundColor", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property ForegroundColor As String
    Get
      Return _foregroundColor
    End Get
    Set(value As String)
      _foregroundColor = value
    End Set
  End Property

  Private _labelColor As String
  <JsonProperty("labelColor", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property LabelColor As String
    Get
      Return _labelColor
    End Get
    Set(value As String)
      _labelColor = value
    End Set
  End Property

  Private _logoText As String
  <JsonProperty("logoText", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property LogoText As String
    Get
      Return _logoText
    End Get
    Set(value As String)
      _logoText = value
    End Set
  End Property

  Private _supressStripShine As Boolean
  <JsonProperty("supressStripShine", Order:=-1, NullValueHandling:=NullValueHandling.Ignore)>
  Public Property SupressStripShine() As Boolean
    Get
      Return _supressStripShine
    End Get
    Set(ByVal value As Boolean)
      _supressStripShine = value
    End Set
  End Property

  'Web Service Tokens
  Private _AuthenticationToken As String
  <JsonProperty("authenticationToken", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property AuthenticationToken As String
    Get
      Return _AuthenticationToken
    End Get
    Set(value As String)
      _AuthenticationToken = value
    End Set
  End Property

  Private _webServiceURL As String
  <JsonProperty("webServiceURL", NullValueHandling:=NullValueHandling.Ignore)>
  Public Property WebServiceURL As String
    Get
      Return _webServiceURL
    End Get
    Set(value As String)
      _webServiceURL = value
    End Set
  End Property

  Private _passStyle As IPassStyle
  Public Property PassStyle() As IPassStyle
    Get
      Return _passStyle
    End Get
    Set(ByVal value As IPassStyle)
      _passStyle = value
    End Set
  End Property

End Class
