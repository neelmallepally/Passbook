Public Class Passbook

  Private _pkPassFile As Byte()
  Private _IPass As IPass

  Public Sub New(ByVal pPass As IPass)
    _IPass = pPass
  End Sub


  Public Function Generate() As Byte()
    'CreatePackage()
    'ZipPackage()

    Return _pkPassfile
  End Function

End Class
