namespace Spaceship.Mission.API.Domain.ValueObjects
{
    public class MaterialModel
    {
        public MaterialModel(int multiplier)
        {
            Metal = 10*multiplier;
            Crystal = 5*multiplier;
            Currency = 40*multiplier;
        }

        public int Metal { get; set; }
        public int Crystal { get; set; }
        public int Currency { get; set; }
    }
}
