
Public Interface IPass

  Property FormatVersion As String
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

  Property Images As List(of Image)

  Property Fields As Dictionary(Of String, Dictionary(Of String, String))

End Interface
