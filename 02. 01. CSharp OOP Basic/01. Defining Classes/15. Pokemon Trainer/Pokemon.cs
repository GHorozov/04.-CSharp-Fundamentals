public class Pokemon
{
    public string name;
    public string element;
    public int health = 0;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public void DecreaseHealth()
    {
        this.health -= 10;
    }
}