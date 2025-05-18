namespace nw6m6y
{
    public class Program
    {
        public static void Main(String[] args)
        {
            //Ez még kimaradt
            Atmosphere atmosphere = null;
            try
            {
                using (StreamReader reader = new StreamReader(args[0]))
                {
                    int humidity;
                    int.TryParse(reader.ReadLine(), out humidity);
                    List<(String, int)> lands = new List<(string, int)>();
                    for (String? line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        String[] splitted = line.Split(" ");
                        //splitted[1] felesleges, csak a feladatban van megadva, hogy így legyen
                        //De a vízmennyiségből ki lehet kalkulálni azt is, úgyhogy nekem az irreleváns
                        lands.Add((splitted[0], int.Parse(splitted[2])));
                    }
                    atmosphere = new Atmosphere(humidity, lands);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //Adjuk meg 10 kör után a legvizesebb földterület nevét vízmennyiségével együtt! 
            //Körönként mutassuk meg a földterületek összes tulajdonságát!
            if (atmosphere != null)
            {
                atmosphere.TurnDays(10);
                Land? maxWaterLand = atmosphere.MostWater().Item2;

                Console.WriteLine($"The {maxWaterLand.GetName()} has the most water: {maxWaterLand.GetWater()} km³");
            }
            else
            {
                Console.WriteLine("Your atmosphere is empty. There was something wrong while reading the input file");
            }
        }
    }
}
