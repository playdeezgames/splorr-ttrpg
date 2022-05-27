Public Class PlayerCharacter
    Inherits Character
    Sub New()
        MyBase.New("Bob the N00b")
        Const GenerationDiceCount As Integer = 8
        For Each descriptor In AbilityScoreDescriptors
            AbilityScores(descriptor.Key) = descriptor.Value.Minimum
        Next
        Dim dice = New List(Of Long)
        While dice.Count < GenerationDiceCount
            Dim roll = RNG.RollDice("1d6")
            If roll > 4 Then
                roll = RNG.RollDice("1d6")
            End If
            dice.Add(roll)
        End While
        For Each die In dice
            Dim ability As AbilityScore =
                If(die = 1, AbilityScore.Strength,
                If(die = 2, AbilityScore.Dexterity,
                If(die = 3, AbilityScore.Willpower,
                If(die = 4, AbilityScore.Influence,
                If(die = 5, AbilityScore.Power,
                AbilityScore.Power)))))
            AbilityScores(ability) += 1
        Next
        MaximumHP = 3
        HP = 3
        MaximumMP = 3
        MP = 3
        Weapon = New Weapon With
            {
                .Name = "fist",
                .AttackBonus = 0,
                .HP = Integer.MaxValue,
                .MaximumHP = Integer.MaxValue,
                .SavingThrow = 1,
                .MaximumDamage = 1
            }
    End Sub
End Class
