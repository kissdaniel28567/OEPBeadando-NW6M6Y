using NUnit.Framework.Constraints;
using nw6m6y;

namespace BeadandoTest
{
    public class Tests
    {
        public Atmosphere atmosphere;
        [SetUp]
        public void Setup()
        {
            List<(String, int)> lands = new List<(string, int)>();
            lands.Add(("test1", 15));
            lands.Add(("Tihamér", 50));
            lands.Add(("test3", 51));
            atmosphere = new Atmosphere(39, lands);
        }

        [Test]
        public void WeatherTest()
        {
            Assert.That(atmosphere.GetWeather().GetType(), Is.EqualTo(typeof(Sunny)));
            atmosphere.AddHumidity(50);
            atmosphere.ChangeWeather();
            Assert.That(atmosphere.GetWeather().GetType(), Is.EqualTo(typeof(Rainy)));
            Assert.That(atmosphere.GetHumidity(), Is.EqualTo(30));
            atmosphere.AddHumidity(-50);
            atmosphere.ChangeWeather();
            Assert.That(atmosphere.GetWeather().GetType(), Is.EqualTo(typeof(Sunny)));
        }

        [Test]
        public void MostWaterTestEmpty()
        {
            List<(String, int)> lands = new List<(string, int)>();
            Atmosphere emptyAtmosphere = new Atmosphere(39, lands);
            Assert.That(emptyAtmosphere.MostWater().Item1, Is.EqualTo(false));
            Assert.That(emptyAtmosphere.MostWater().Item2, Is.EqualTo(null));
            Assert.That(emptyAtmosphere.MostWater().Item3, Is.EqualTo(0));
        }

        [Test]
        public void MostWaterTestFull()
        {
            Assert.That(atmosphere.MostWater().Item1, Is.EqualTo(true));
            Assert.That(atmosphere.MostWater().Item2, Is.EqualTo(atmosphere.GetLands()[2]));
            Assert.That(atmosphere.MostWater().Item3, Is.EqualTo(51));
        }

        [Test]
        public void AddWaterTest1()
        {
            Assert.That(atmosphere.GetLands()[0].GetWater(), Is.EqualTo(15));
            Assert.That(atmosphere.GetLands()[1].GetWater(), Is.EqualTo(50));
            Assert.That(atmosphere.GetLands()[2].GetWater(), Is.EqualTo(51));
        }

        [Test]
        public void AddWaterTest2()
        {
            atmosphere.GetLands().ForEach(land => land.AddWater(10));
            Assert.That(atmosphere.GetLands()[0].GetWater(), Is.EqualTo(25));
            Assert.That(atmosphere.GetLands()[1].GetWater(), Is.EqualTo(60));
            Assert.That(atmosphere.GetLands()[2].GetWater(), Is.EqualTo(61));
        }

        [Test]
        public void AddWaterTest3()
        {
            atmosphere.GetLands().ForEach(land => land.AddWater(-10));
            Assert.That(atmosphere.GetLands()[0].GetWater(), Is.EqualTo(5));
            Assert.That(atmosphere.GetLands()[1].GetWater(), Is.EqualTo(40));
            Assert.That(atmosphere.GetLands()[2].GetWater(), Is.EqualTo(41));
        }

        [Test]
        public void NextDayTest1()
        {
            atmosphere.AddHumidity(-20);
            atmosphere.GetLands()[0].NextDay();
            Assert.That(atmosphere.GetWeather().GetType(), Is.EqualTo(typeof(Sunny)));
            Assert.That(atmosphere.GetHumidity(), Is.EqualTo(19 + 3));
            Assert.That(atmosphere.GetLands()[0].GetWater(), Is.EqualTo(12));
            Assert.That(atmosphere.GetLands()[0].type.GetType(), Is.EqualTo(typeof(Sheer)));
        }

        [Test]
        public void NextDayTest2()
        {
            atmosphere.AddHumidity(-20);
            atmosphere.GetLands()[1].NextDay();
            Assert.That(atmosphere.GetWeather().GetType(), Is.EqualTo(typeof(Sunny)));
            Assert.That(atmosphere.GetHumidity(), Is.EqualTo(19 + 7));
            Assert.That(atmosphere.GetLands()[1].GetWater(), Is.EqualTo(44));
            Assert.That(atmosphere.GetLands()[1].type.GetType(), Is.EqualTo(typeof(Green)));
        }

        [Test]
        public void NextDayTest3()
        {
            atmosphere.AddHumidity(40);
            atmosphere.GetLands()[2].NextDay();
            Assert.That(atmosphere.GetWeather().GetType(), Is.EqualTo(typeof(Rainy)));
            //Goes back to 30 because of Rainy
            Assert.That(atmosphere.GetHumidity(), Is.EqualTo(30));
            Assert.That(atmosphere.GetLands()[2].GetWater(), Is.EqualTo(41));
            Assert.That(atmosphere.GetLands()[1].type.GetType(), Is.EqualTo(typeof(Green)));
        }

        [Test]
        public void ChangeTest()
        {
            Assert.Throws<ArgumentException>(() => atmosphere.GetLands()[0].type.Change(null));

            atmosphere.GetLands()[0].type.Change(Sunny.Instance);
            Assert.That(atmosphere.GetLands()[0].GetWater(), Is.EqualTo(12));
            Assert.That(atmosphere.GetHumidity(), Is.EqualTo(42));

            atmosphere.GetLands()[1].type.Change(Cloudy.Instance);
            Assert.That(atmosphere.GetLands()[1].GetWater(), Is.EqualTo(48));
            Assert.That(atmosphere.GetHumidity(), Is.EqualTo(49));

            atmosphere.GetLands()[1].type.Change(Cloudy.Instance);
            Assert.That(atmosphere.GetLands()[1].GetWater(), Is.EqualTo(46));
            Assert.That(atmosphere.GetHumidity(), Is.EqualTo(56));
        }
    }
}