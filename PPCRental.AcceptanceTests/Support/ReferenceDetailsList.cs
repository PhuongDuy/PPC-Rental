using System.Collections.Generic;
using PPC_Rental.Models;
using FluentAssertions;

namespace PPCRental.AcceptanceTests.Support
{
    public class ReferenceDetailsList : Dictionary<string, PROPERTY >
    {
        public PROPERTY GetById(string bookId)
        {
            return this[bookId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<PROPERTY>().Which;
        }
    }
}
