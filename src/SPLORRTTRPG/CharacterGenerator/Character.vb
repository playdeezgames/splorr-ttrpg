Public Class Character
    Public Name As String
    Public AbilityScores As Dictionary(Of AbilityScore, Long)
    Public HP As Long
    Public MaximumHP As Long
    Public MP As Long
    Public MaximumMP As Long
    Public Weapon As Weapon
    Sub New(name As String)
        Me.Name = name
        AbilityScores = New Dictionary(Of AbilityScore, Long)
    End Sub
    ReadOnly Property IsDead As Boolean
        Get
            Return HP <= 0
        End Get
    End Property

    Function RollAttack() As Long
        Dim roll As Long = 0
        Dim attack = AbilityScores(AbilityScore.Strength) + Weapon.AttackBonus
        While attack > 0
            attack -= 1
            roll += RNG.RollDice("1d6/6")
        End While
        Return roll
    End Function

    Friend Sub Attack(enemy As Character)
        Dim attackRoll = RollAttack()
        AnsiConsole.WriteLine($"{Name} rolls an attack of {attackRoll}.")
        Dim defendRoll = enemy.RollDefend()
        AnsiConsole.WriteLine($"{enemy.Name} rolls a defend of {defendRoll}.")
        Dim damage = Math.Max(0, Math.Min(attackRoll - defendRoll, Weapon.MaximumDamage))
        AnsiConsole.WriteLine($"{enemy.Name} takes {damage} damage.")
        enemy.HP -= damage
        AnsiConsole.WriteLine($"{enemy.Name} has {enemy.HP} HP left.")
        AnsiConsole.WriteLine("---")
    End Sub

    Private Function RollDefend() As Long
        Dim roll As Long = 0
        Dim defend = AbilityScores(AbilityScore.Dexterity)
        While defend > 0
            defend -= 1
            roll += RNG.RollDice("1d6/6")
        End While
        Return roll
    End Function
End Class
