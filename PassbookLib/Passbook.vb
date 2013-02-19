Imports System.IO
Imports Newtonsoft.Json
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Pkcs
Imports System.Text
Imports System.Drawing
Imports Org.BouncyCastle.Cms
Imports Org.BouncyCastle.Security
Imports Org.BouncyCastle.X509.Store
Imports Ionic.Zip

Public Class Passbook

  Private _pkPassFile As Byte()
  Private _IPass As IPass

  Public Sub New(ByVal pPass As IPass)
    _IPass = pPass
  End Sub

  Sub CreatePass(ByVal psPassName As String, ByVal psPassPath As String)

    _IPass.PassName = psPassName
    _IPass.PassPath = psPassPath

    'Create directory
    If (Not String.IsNullOrEmpty(psPassName) And Not String.IsNullOrEmpty(psPassPath)) Then
      If (Directory.Exists(psPassPath)) Then
        Directory.CreateDirectory(Path.Combine(psPassPath, psPassName))
      End If
    End If

    CreatePackage(_IPass)
    ZipPackage(_IPass)

  End Sub

  Private Sub CreatePackage(IPass As IPass)
    CreatePassFile(IPass)
    CreateManifestFile()
    SignManifestFile(IPass)

    'GenerateManifestFile(IPass)
  End Sub

  Private Sub ZipPackage(IPass As IPass)
    Dim passDirectory As String = Path.Combine(IPass.PassPath, IPass.PassName)

    Dim ZipFilePath As String = Path.Combine(IPass.PassPath, IPass.PassName & ".pkpass")
    If File.Exists(ZipFilePath) Then File.Delete(ZipFilePath)

    Using zip As ZipFile = New ZipFile()
      zip.AddDirectory(passDirectory)
      zip.Save(ZipFilePath)
    End Using
  End Sub

  Private Sub CreatePassFile(IPass As IPass)

    'Create a pass.json file in Pass directory
    Dim lsPassDirectory As String = Path.Combine(IPass.PassPath, IPass.PassName)
    Dim lsPassJsonFilePath As String = Path.Combine(lsPassDirectory, "pass.json")
    If (File.Exists(lsPassJsonFilePath)) Then
      File.Delete(lsPassJsonFilePath)
    End If

    Dim sb As StringBuilder = New StringBuilder()
    Dim sw As StringWriter = New StringWriter(sb)

    Using writer As JsonWriter = New JsonTextWriter(sw)
      IPass.Write(writer)
      IPass.PassFileData = sb.ToString()
      IPass.PassFile = Encoding.Unicode.GetBytes(sb.ToString())
    End Using

    File.WriteAllText(lsPassJsonFilePath, sb.ToString())

    'Add images to the Pass directory
    For Each i In IPass.Images
      Dim iconImage As Image = Image.FromStream(New MemoryStream(i.Value))
      iconImage.Save(Path.Combine(lsPassDirectory, i.Key))
    Next


  End Sub

  Private Sub CreateManifestFile()

    Dim lPassDirectory As New DirectoryInfo(Path.Combine(_IPass.PassPath, _IPass.PassName))
    Dim lSignatureFilePath As String = Path.Combine(lPassDirectory.FullName, "signature")
    Dim lManifestFilePath As String = Path.Combine(lPassDirectory.FullName, "manifest.json")

    If File.Exists(lSignatureFilePath) Then
      File.Delete(lSignatureFilePath)
    End If

    If File.Exists(lManifestFilePath) Then
      File.Delete(lManifestFilePath)
    End If

    Dim fileHashDic = New Dictionary(Of String, String)
    For Each lFileX As FileInfo In lPassDirectory.GetFiles()
      fileHashDic.Add(lFileX.Name, GetHashForFile(lFileX))
    Next

    Dim json As String = JsonConvert.SerializeObject(fileHashDic)

    Using sw As StreamWriter = File.CreateText(lManifestFilePath)
      sw.WriteLine(json)
      _IPass.ManifestFile = Encoding.Unicode.GetBytes(json)
    End Using

  End Sub

  Private Sub GenerateManifestFile(IPass As IPass)

    Using ms As MemoryStream = New MemoryStream()
      Using sw As StreamWriter = New StreamWriter(ms)
        Using JsonWriter As JsonWriter = New JsonTextWriter(sw)
          JsonWriter.Formatting = Formatting.Indented
          JsonWriter.WriteStartObject()

          Dim hash As String = Nothing

          If (IPass.Images.ContainsKey(PassbookImage.Icon)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.Icon))
            JsonWriter.WritePropertyName(PassbookImage.Icon)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.IconRetina)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.IconRetina))
            JsonWriter.WritePropertyName(PassbookImage.IconRetina)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.Logo)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.Logo))
            JsonWriter.WritePropertyName(PassbookImage.Logo)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.LogoRetina)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.LogoRetina))
            JsonWriter.WritePropertyName(PassbookImage.LogoRetina)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.Strip)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.Strip))
            JsonWriter.WritePropertyName(PassbookImage.Strip)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.StripRetina)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.StripRetina))
            JsonWriter.WritePropertyName(PassbookImage.StripRetina)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.Thumbnail)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.Thumbnail))
            JsonWriter.WritePropertyName(PassbookImage.Thumbnail)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.ThumbnailRetina)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.ThumbnailRetina))
            JsonWriter.WritePropertyName(PassbookImage.ThumbnailRetina)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.Background)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.Background))
            JsonWriter.WritePropertyName(PassbookImage.Background)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          If (IPass.Images.ContainsKey(PassbookImage.BackgroundRetina)) Then
            hash = GetHasForBytes(IPass.Images(PassbookImage.BackgroundRetina))
            JsonWriter.WritePropertyName(PassbookImage.BackgroundRetina)
            JsonWriter.WriteValue(hash.ToLower())
          End If

          hash = GetHasForBytes(IPass.PassFile)
          JsonWriter.WritePropertyName("pass.json")
          JsonWriter.WriteValue(hash.ToLower())
        End Using

        IPass.ManifestFile = ms.ToArray()

      End Using
    End Using

    'SignManifestFile(IPass)

  End Sub

  Private Function GetHasForBytes(ByVal input As Byte()) As String

    Dim lSHA1Hasher As SHA1CryptoServiceProvider = New SHA1CryptoServiceProvider()
    Dim lHashBytes As Byte() = lSHA1Hasher.ComputeHash(input)
    Return System.BitConverter.ToString(lHashBytes).Replace("-", "")

  End Function

  Private Sub SignManifestFile(IPass As IPass)

    'Get certificates - Developer Certificate & Apple Certificate
    ''Developer Certificate
    Dim lDeveloperCertificate As X509Certificate2 = GetCertificateFromBytes(IPass.SigingingCertificate, IPass.CertificatePassword)
    If lDeveloperCertificate Is Nothing Then
      Throw New FileNotFoundException("Invaid Certificate")
    End If

    ''Apple Certificate
    Dim lAppleCertificate As X509Certificate2 = GetCertificateFromBytes(IPass.WWDRIntermediateCertificate, IPass.CertificatePassword)
    If lAppleCertificate Is Nothing Then
      Throw New FileNotFoundException("Invaid Apple Certificate")
    End If

    'Dim lX509Certificate2Collection As New X509Certificate2Collection
    'lX509Certificate2Collection.Add(lDeveloperCertificate)
    'lX509Certificate2Collection.Add(lAppleCertificate)

    'Dim lContentInfo As New ContentInfo(IPass.ManifestFile)
    'Dim lSignedCms As New SignedCms(lContentInfo)

    'For Each cert In lX509Certificate2Collection
    '  lSignedCms.ComputeSignature(New CmsSigner(cert))
    'Next

    'IPass.SignatureFile = lSignedCms.Encode()

    Dim cert As Org.BouncyCastle.X509.X509Certificate = DotNetUtilities.FromX509Certificate(lDeveloperCertificate)
    Dim privateKey As Org.BouncyCastle.Crypto.AsymmetricKeyParameter = DotNetUtilities.GetKeyPair(lDeveloperCertificate.PrivateKey).Private

    Dim appleCA As Org.BouncyCastle.X509.X509Certificate = DotNetUtilities.FromX509Certificate(lAppleCertificate)

    Dim intermediateCertificates As ArrayList = New ArrayList()

    intermediateCertificates.Add(appleCA)
    intermediateCertificates.Add(cert)

    Dim PP As Org.BouncyCastle.X509.Store.X509CollectionStoreParameters = New Org.BouncyCastle.X509.Store.X509CollectionStoreParameters(intermediateCertificates)
    Dim st1 As Org.BouncyCastle.X509.Store.IX509Store = Org.BouncyCastle.X509.Store.X509StoreFactory.Create("CERTIFICATE/COLLECTION", PP)

    Dim generator As CmsSignedDataGenerator = New CmsSignedDataGenerator()
    generator.AddSigner(privateKey, cert, CmsSignedDataGenerator.DigestSha1)
    generator.AddCertificates(st1)

    Dim content As CmsProcessable = New CmsProcessableByteArray(_IPass.ManifestFile)
    Dim signedData As CmsSignedData = generator.Generate(content, False)

    Dim lPassDirectory As New DirectoryInfo(Path.Combine(_IPass.PassPath, _IPass.PassName))
    Dim lSignatureFilePath As String = Path.Combine(lPassDirectory.FullName, "signature")
    If File.Exists(lSignatureFilePath) Then
      File.Delete(lSignatureFilePath)
    End If

    File.WriteAllBytes(lSignatureFilePath, signedData.GetEncoded())
  End Sub

  Private Function GetCertificateFromBytes(ByVal bytes As Byte(), ByVal password As String)

    If password = Nothing Then
      Return New X509Certificate2(bytes)
    Else
      Return New X509Certificate2(bytes, password, X509KeyStorageFlags.Exportable)
    End If

    Return Nothing
  End Function

  Private Function GetHashForFile(lFileX As FileInfo) As String
    Dim lsHashOfFile As String = Nothing
    Using fs As FileStream = New FileStream(lFileX.FullName, FileMode.Open)
      Using SHA1 As SHA1Managed = New SHA1Managed()
        Dim hash As Byte() = SHA1.ComputeHash(fs)
        Dim sbFormatted As StringBuilder = New StringBuilder(hash.Length)
        For Each b In hash
          sbFormatted.AppendFormat("{0:X2}", b)
        Next
        lsHashOfFile = sbFormatted.ToString()
      End Using
    End Using

    Return lsHashOfFile
  End Function

End Class
