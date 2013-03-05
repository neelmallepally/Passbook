Imports System.Collections
Imports Newtonsoft.Json
Imports System.Dynamic

Public Interface IPassStyle

    <JsonProperty("headerFields", Order:=1, DefaultValueHandling:=DefaultValueHandling.Ignore)>
    Property HeaderFields As IList(Of ExpandoObject)

    <JsonProperty("primaryFields", Order:=2, DefaultValueHandling:=DefaultValueHandling.Ignore)>
    Property PrimaryFields As IList(Of ExpandoObject)

    <JsonProperty("secondaryFields", Order:=3, DefaultValueHandling:=DefaultValueHandling.Ignore)>
    Property SecondaryFields As IList(Of ExpandoObject)

    <JsonProperty("auxiliaryFields", Order:=4, DefaultValueHandling:=DefaultValueHandling.Ignore)>
    Property AuxiliaryFields As IList(Of ExpandoObject)

    <JsonProperty("backFields", Order:=5, DefaultValueHandling:=DefaultValueHandling.Ignore)>
    Property BackFields As IList(Of ExpandoObject)

End Interface
