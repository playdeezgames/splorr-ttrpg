Public Class AbilityScoreDescriptor
    ReadOnly Property Name As String
    ReadOnly Property Minimum As Long
    Sub New(name As String, minimum As Long)
        Me.Name = name
        Me.Minimum = minimum
    End Sub
End Class
Module AbilityScoreDescriptorExtensions
    Friend AbilityScoreDescriptors As New Dictionary(Of AbilityScore, AbilityScoreDescriptor) From
        {
            {AbilityScore.Strength, New AbilityScoreDescriptor("STR", 1)},
            {AbilityScore.Dexterity, New AbilityScoreDescriptor("DEX", 1)},
            {AbilityScore.Willpower, New AbilityScoreDescriptor("WIL", 1)},
            {AbilityScore.Influence, New AbilityScoreDescriptor("INF", 1)},
            {AbilityScore.Power, New AbilityScoreDescriptor("POW", 0)}
        }
End Module