
Public Interface IPass

  Property PassName As String
  Property PassPath As String

  Property FormatVersion As Integer
  Property PassTypeIdentifier As String
  Property SerialNumber As String
  Property TeamIdentifier As String

  Property WebServiceURL As String
  Property AuthenticationToken As String

  Property Barcode As Barcode

  Property Locations As List(Of Location)

  Property OrganizationName As String 'Customer Name
  Property Description As String 'Coupon or Reward Description

  Property LogoText As String 'Coupon or Reward Name

  Property ForegroundColor As String
  Property BackgroundColor As String

  Property Images As Dictionary(Of String, Byte())

  Property Fields As Dictionary(Of String, Dictionary(Of String, String))

  Property PassFile As Byte()

  Property PassFileData As String

  Property ManifestFile As Byte()

  Property SigingingCertificate As Byte()

  Property CertificatePassword As String

  Property WWDRIntermediateCertificate() As Byte()

  Property SignatureFile As Byte()

  Sub Write(writer As Newtonsoft.Json.JsonWriter)

End Interface
