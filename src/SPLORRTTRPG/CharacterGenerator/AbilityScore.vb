Imports System.Runtime.CompilerServices

Public Enum AbilityScore
    None
    Strength
    Dexterity
    Willpower
    Influence
    Power
End Enum
Module AbilityScoreExtensions
    <Extension>
    Function Name(abilityScore As AbilityScore) As String
        Return AbilityScoreDescriptors(abilityScore).Name
    End Function
End Module
