using Domain.Exceptions;

namespace Domain.Entities
{
    public class PowerPlant
    {
        public string Name { get; }
        public double Efficiency { get; }
        public double Pmin { get; }
        public double Pmax { get; }

        private PowerPlant(
        string name,
        double efficiency,
        double pmin,
        double pmax)
        {
            Name = name;
            Efficiency = efficiency;
            Pmin = pmin;
            Pmax = pmax;
        }

        public static PowerPlant Create(
            string name,
            double efficiency,
            double pmin,
            double pmax)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidPowerplantException("Name is required.");

            if (efficiency <= 0 || efficiency > 1)
                throw new InvalidPowerplantException(
                    "Efficiency must be between 0 and 1.");

            if (pmin < 0 || pmax < pmin)
                throw new InvalidPowerplantException(
                    "Invalid power limits.");

            return new PowerPlant(name, efficiency, pmin, pmax);
        }
    }
}
