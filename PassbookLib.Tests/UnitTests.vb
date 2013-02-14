Imports System.Text
Imports PassbookLib

<TestClass()>
Public Class UnitTests

  <TestMethod()>
  Public Sub Convert_Coupon_Object_To_PassJson()

    ''Arrange
    Dim lCoupon As New Coupon()
    lCoupon.FormatVersion = "1"
    lCoupon.PassTypeIdentifier = "pass.feb132013.coupons"
    lCoupon.SerialNumber = "123456789"
    lCoupon.TeamIdentifier = ""
    lCoupon.WebServiceURL = ""
    lCoupon.Barcode = New Barcode() With {.Message = "", .Format = "", .MessageEncoding = ""}
    lCoupon.Locations = New List(Of Location)() From { _
                  New Location With {.Latitude = "", .Longitude = ""}, _
                  New Location With {.Latitude = "", .Longitude = ""}}

    Dim lsExpected As String = "{""formatVersion"": 1}"
    Dim lsActual As String = JsonHelper.CreatePassJson(lCoupon)

    ''Action

    Assert.AreEqual(lsExpected, lsActual)

    ''Assert



  End Sub

End Class
