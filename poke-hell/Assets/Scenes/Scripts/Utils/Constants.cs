/// <summary>
/// La clase estatica Constants asegura que los valores declarados en ella sean
/// accedibles para los demás scripts, en ella se definen los siguientes valores
/// SCENARIO_SPEED -> float: velocidad a la que se mueve el escenario
/// BULLET_SPEED -> float: velocidad a la que se mueven las balas
/// BULLET_LIFE -> float: tiempo de vida de las balas antes de desaparecer
/// RADIUS -> float: radio de un circulo
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public static class Constants
{
    public const float SCENARIO_SPEED = 3.0f;
    public const float BULLET_SPEED = 5.0f;
    public const float BULLET_LIFE = 2.0f;
    public const float RADIUS = 1.0f;
}
