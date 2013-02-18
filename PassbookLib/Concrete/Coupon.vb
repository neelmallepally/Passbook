Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class Coupon
  Implements IPass

  Private _AuthenticationToken As String
  Public Property AuthenticationToken As String Implements IPass.AuthenticationToken
    Get
      Return _AuthenticationToken
    End Get
    Set(value As String)
      _AuthenticationToken = value
    End Set
  End Property

  Private _BackgroundColor As String
  Public Property BackgroundColor As String Implements IPass.BackgroundColor
    Get
      Return _BackgroundColor
    End Get
    Set(value As String)
      _BackgroundColor = value
    End Set
  End Property

  Private _barcode As Barcode
  Public Property Barcode As Barcode Implements IPass.Barcode
    Get
      Return _barcode
    End Get
    Set(value As Barcode)
      _barcode = value
    End Set
  End Property

  Private _certificate As Byte()
  Public Property SigingingCertificate As Byte() Implements IPass.SigingingCertificate
    Get
      Return _certificate
    End Get
    Set(value As Byte())
      _certificate = value
    End Set
  End Property

  Private _certificatePassword As String
  Public Property CertificatePassword As String Implements IPass.CertificatePassword
    Get
      Return _certificatePassword
    End Get
    Set(value As String)
      _certificatePassword = value
    End Set
  End Property

  Private _description As String
  Public Property Description As String Implements IPass.Description
    Get
      Return _description
    End Get
    Set(value As String)
      _description = value
    End Set
  End Property

  Private _fields As System.Collections.Generic.Dictionary(Of String, System.Collections.Generic.Dictionary(Of String, String))
  Public Property Fields As System.Collections.Generic.Dictionary(Of String, System.Collections.Generic.Dictionary(Of String, String)) Implements IPass.Fields
    Get
      Return _fields
    End Get
    Set(value As System.Collections.Generic.Dictionary(Of String, System.Collections.Generic.Dictionary(Of String, String)))
      _fields = value
    End Set
  End Property

  Private _foregroundColor As String
  Public Property ForegroundColor As String Implements IPass.ForegroundColor
    Get
      Return _foregroundColor
    End Get
    Set(value As String)
      _foregroundColor = value
    End Set
  End Property

  Private _formatVersion As Integer
  Public Property FormatVersion As Integer Implements IPass.FormatVersion
    Get
      Return _formatVersion
    End Get
    Set(value As Integer)
      _formatVersion = value
    End Set
  End Property

  Private _images As System.Collections.Generic.Dictionary(Of String, Byte())
  Public Property Images As System.Collections.Generic.Dictionary(Of String, Byte()) Implements IPass.Images
    Get
      Return _images
    End Get
    Set(value As System.Collections.Generic.Dictionary(Of String, Byte()))
      _images = value
    End Set
  End Property

  Private _locations As System.Collections.Generic.List(Of Location)
  Public Property Locations As System.Collections.Generic.List(Of Location) Implements IPass.Locations
    Get
      Return _locations
    End Get
    Set(value As System.Collections.Generic.List(Of Location))
      _locations = value
    End Set
  End Property

  Private _logoText As String
  Public Property LogoText As String Implements IPass.LogoText
    Get
      Return _logoText
    End Get
    Set(value As String)
      _logoText = value
    End Set
  End Property

  Private _manifestFile As Byte()
  Public Property ManifestFile As Byte() Implements IPass.ManifestFile
    Get
      Return _manifestFile
    End Get
    Set(value As Byte())
      _manifestFile = value
    End Set
  End Property

  Private _organizationName As String
  Public Property OrganizationName As String Implements IPass.OrganizationName
    Get
      Return _organizationName
    End Get
    Set(value As String)
      _organizationName = value
    End Set
  End Property

  Private _passFile As Byte()
  Public Property PassFile As Byte() Implements IPass.PassFile
    Get
      Return _passFile
    End Get
    Set(value As Byte())
      _passFile = value
    End Set
  End Property

  Private _passName As String
  Public Property PassName As String Implements IPass.PassName
    Get
      Return _passName
    End Get
    Set(value As String)
      _passName = value
    End Set
  End Property

  Private _passPath As String
  Public Property PassPath As String Implements IPass.PassPath
    Get
      Return _passPath
    End Get
    Set(value As String)
      _passPath = value
    End Set
  End Property

  Private _passTypeIdentifier As String
  Public Property PassTypeIdentifier As String Implements IPass.PassTypeIdentifier
    Get
      Return _passTypeIdentifier
    End Get
    Set(value As String)
      _passTypeIdentifier = value
    End Set
  End Property

  Private _serialNumber As String
  Public Property SerialNumber As String Implements IPass.SerialNumber
    Get
      Return _serialNumber
    End Get
    Set(value As String)
      _serialNumber = value
    End Set
  End Property

  Private _signatureFile As Byte()
  Public Property SignatureFile As Byte() Implements IPass.SignatureFile
    Get
      Return _signatureFile
    End Get
    Set(value As Byte())
      _signatureFile = value
    End Set
  End Property

  Private _teamIdentifier As String
  Public Property TeamIdentifier As String Implements IPass.TeamIdentifier
    Get
      Return _teamIdentifier
    End Get
    Set(value As String)
      _teamIdentifier = value
    End Set
  End Property

  Private _webServiceURL As String
  Public Property WebServiceURL As String Implements IPass.WebServiceURL
    Get
      Return _webServiceURL
    End Get
    Set(value As String)
      _webServiceURL = value
    End Set
  End Property

  Public Sub Write(writer As Newtonsoft.Json.JsonWriter) Implements IPass.Write

    writer.WriteStartObject() 'Start of pass.json file data

    WriteStandardKeys(writer, Me)
    WriteLocationKeys(writer, Me)
    WriteAppearanceKeys(writer, Me)
    WriteBarcode(writer, Me)
    WriteUrls(writer, Me)


    writer.WritePropertyName("coupon") 'Start of Coupon Specific data
    writer.WriteStartObject()
    For Each field In _fields
      writer.WritePropertyName(field.Key)
      writer.WriteStartArray()
      For Each subField In field.Value
        writer.WriteStartObject()
        writer.WritePropertyName(subField.Key)
        writer.WriteValue(subField.Value)
        writer.WriteEndObject()
      Next
      writer.WriteEndArray()
    Next
    writer.WriteEndObject() 'End of Coupon Specific data

    writer.WriteEndObject() 'End of pass.json file data


  End Sub

  Private Sub WriteStandardKeys(writer As JsonWriter, coupon As Coupon)
    writer.WritePropertyName("passTypeIdentifier")
    writer.WriteValue(coupon.PassTypeIdentifier)

    writer.WritePropertyName("formatVersion")
    writer.WriteValue(coupon.FormatVersion)

    writer.WritePropertyName("serialNumber")
    writer.WriteValue(coupon.SerialNumber)

    writer.WritePropertyName("description")
    writer.WriteValue(coupon.Description)

    writer.WritePropertyName("organizationName")
    writer.WriteValue(coupon.OrganizationName)

    writer.WritePropertyName("teamIdentifier")
    writer.WriteValue(coupon.TeamIdentifier)

    If (coupon.LogoText IsNot Nothing) Then
      writer.WritePropertyName("logoText")
      writer.WriteValue(coupon.LogoText)
    End If

  End Sub

  Private Sub WriteLocationKeys(writer As JsonWriter, coupon As Coupon)

    If (_locations IsNot Nothing) Then

      writer.WritePropertyName("locations")
      writer.WriteStartArray()

      For Each Location In _locations
        writer.WriteStartObject()
        writer.WritePropertyName("latitude")
        writer.WriteValue(Location.Latitude)
        writer.WritePropertyName("longitude")
        writer.WriteValue(Location.Longitude)
        writer.WriteEndObject()
      Next

      writer.WriteEndArray()
    End If


  End Sub

  Private Sub WriteAppearanceKeys(writer As JsonWriter, coupon As Coupon)
    If coupon.ForegroundColor <> Nothing Then
      writer.WritePropertyName("foregroundColor")
      writer.WriteValue(coupon.ForegroundColor)
    End If

    If coupon.BackgroundColor <> Nothing Then
      writer.WritePropertyName("backgroundColor")
      writer.WriteValue(coupon.BackgroundColor)
    End If

  End Sub

  Private Sub WriteBarcode(writer As JsonWriter, coupon As Coupon)
    If (_barcode IsNot Nothing) Then
      writer.WritePropertyName("barcode")

      writer.WriteStartObject()

      writer.WritePropertyName("message")
      writer.WriteValue(_barcode.Message)
      writer.WritePropertyName("format")
      writer.WriteValue("PKBarcodeFormatPDF417")
      writer.WritePropertyName("messageEncoding")
      writer.WriteValue("iso-8859-1")

      writer.WriteEndObject()

    End If
  End Sub

  Private Sub WriteUrls(writer As JsonWriter, coupon As Coupon)

    If (Not String.IsNullOrEmpty(_AuthenticationToken)) Then
      writer.WritePropertyName("authenticationToken")
      writer.WriteValue(_AuthenticationToken)

      writer.WritePropertyName("webServiceURL")
      writer.WriteValue(_webServiceURL)
    End If

  End Sub

  Private _passFileData As String
  Public Property PassFileData As String Implements IPass.PassFileData
    Get
      Return _passFileData
    End Get
    Set(value As String)
      _passFileData = value
    End Set
  End Property

  Private _intermediateCertificate As Byte()
  Public Property WWDRIntermediateCertificate As Byte() Implements IPass.WWDRIntermediateCertificate
    Get
      Return _intermediateCertificate
    End Get
    Set(value As Byte())
      _intermediateCertificate = value
    End Set
  End Property
End Class
