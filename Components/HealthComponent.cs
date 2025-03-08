namespace Components
{
public class HealthComponent
{
    private float health;

    public HealthComponent(float health)
    {
        this.health = health;
    }

    public void HandleDamage(float damage)
    {
        health = health - damage;
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}
}