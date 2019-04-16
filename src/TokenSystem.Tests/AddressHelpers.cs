using System.Collections.Generic;
using TokenSystem.StrongForceMocks;

namespace TokenSystem.Tests
{
    public static class AddressHelpers
    {
        public static List<Address> GenerateRandomAddresses(int count)
        {
            var addressFactory = new RandomAddressFactory();
            var generatedAddresses = new List<Address>(count);
            for (var i = 0; i < count; i++)
            {
                generatedAddresses.Add(addressFactory.Create());
            }

            return generatedAddresses;
        }
    }
}