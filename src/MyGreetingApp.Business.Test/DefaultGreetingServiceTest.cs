using System;
using MyGreetingApp.Business;
using NUnit.Framework;

namespace carlosschults.MyGreetingApp.Business.Test
{
    public class DefaultGreetingServiceTest
    {
        [Test]
        public void Construction_WithNullClock_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => new DefaultGreetingService(clock: null));
        }

        [Test]
        public void Greeting_WithInvalidName_Throws()
        {
            IClock clock = new StoppedClock(new DateTimeOffset(
                new DateTime(2018, 1, 1, 14, 15, 0),
                TimeSpan.FromHours(-2)));

            var sut = new DefaultGreetingService(clock);

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => sut.Greet(null));
                Assert.Throws<ArgumentException>(() => sut.Greet(string.Empty));
                Assert.Throws<ArgumentException>(() => sut.Greet("  "));
                Assert.Throws<ArgumentException>(() => sut.Greet("\n\n\t"));
            });
        }

        [TestCase(20, 0, 0, "Carlos", "Good evening, Carlos!")]
        [TestCase(18, 59, 59, "John", "Good afternoon, John!")]
        [TestCase(19, 0, 0, "John", "Good evening, John!")]
        [TestCase(14, 15, 0, "Ana", "Good afternoon, Ana!")]
        [TestCase(12, 0, 0, "Alice", "Good afternoon, Alice!")]
        [TestCase(10, 0, 0, "Bob", "Good morning, Bob!")]
        [TestCase(5, 59, 59, "Lydia", "Good evening, Lydia!")]
        [TestCase(6, 0, 0, "Lydia", "Good morning, Lydia!")]
        public void Greeting(
            int hour,
            int minute,
            int second,
            string userName,
            string expectedGreeting)
        {
            IClock clock = new StoppedClock(new DateTimeOffset(
                new DateTime(2018, 1, 1, hour, minute, second),
                TimeSpan.FromHours(-2)));

            var sut = new DefaultGreetingService(clock);
            Assert.AreEqual(expectedGreeting, sut.Greet(userName));
        }
    }

    internal class StoppedClock : IClock
    {
        private readonly DateTimeOffset dateTimeOffset;

        public StoppedClock(DateTimeOffset dateTimeOffset)
        {
            this.dateTimeOffset = dateTimeOffset;
        }

        public DateTimeOffset Now() => dateTimeOffset;
    }
}
