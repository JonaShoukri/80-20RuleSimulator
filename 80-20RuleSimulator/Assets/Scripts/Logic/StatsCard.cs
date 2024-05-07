using System;

namespace Logic
{
    public class StatsCard
    {
        public float equity;
        public float value;
        public float xFactor;
        
        public StatsCard()
        {
            equity = 5000;
            value = 5000;
            
            // Generate a Gaussian distributed random number for xFactor
            Random random = new Random();

            double u1 = 1.0 - random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)

            double mean = 1.025;
            double stdDev = 0.0125;
            double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

            // Clamp the value between 1.0 and 1.05
            xFactor = (float)Math.Max(1.0, Math.Min(1.05, randNormal));
        }
        public StatsCard(StatsCard other)
        {
            equity = other.equity;
            value = other.value;
            xFactor = other.xFactor;
        }
        
        //GETTERS
        public float GetEquity()
        {
            return equity;
        }
        
        public float GetValue()
        {
            return value;
        }
        
        public float GetXFactor()
        {
            return xFactor;
        }
        
        //SETTERS
        public void Bonus()
        {
            equity *= 1.025f;
        }
        public void SetEquity(float newValue)
        {
            value = newValue;
        }
        public void SetValue(float newValue)
        {
            value = newValue;
        }
    }
}