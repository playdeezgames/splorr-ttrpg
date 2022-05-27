Public Class GoblinNPC
    Inherits Character
    Sub New()
        MyBase.New
        MaximumHP = 1
        HP = 1
        MaximumMP = 1
        MP = 1
        AbilityScores(AbilityScore.Strength) = 1
        AbilityScores(AbilityScore.Dexterity) = 3
        AbilityScores(AbilityScore.Willpower) = 1
        AbilityScores(AbilityScore.Influence) = 1
        AbilityScores(AbilityScore.Power) = 0
        Weapon = New Weapon With
            {
                .Name = "club",
                .MaximumDamage = 1,
                .AttackBonus = 1,
                .HP = 3,
                .MaximumHP = 3,
                .SavingThrow = 4
            }
    End Sub
End Class
