namespace PragueParkingDataAccess
{
    public abstract class Vehicle //Table-Per-Hierarchy. Alla subklasser visas i samma Vehicle-tabell.
    {
        public int Id { get; set; }
        public byte Size { get; set; }
        public string? Registration { get; set; }
    }
    public class Car : Vehicle
    {
        public Car() { }
        public Car(in string reg) // ?
        {
            Size = 4;
            Registration = reg;
        }
    }
    public class MC : Vehicle
    {
        public MC() { }
        public MC(in string reg) // ?
        {
            Size = 2;
            Registration = reg;
        }
    }
}
