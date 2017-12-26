using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PPC_Rental.Models;
using FluentAssertions;

namespace PPCRental.AcceptanceTests.Common
{
    public class ProjectAssertions
    {
        public static void HomeScreenShouldShow(IEnumerable<PPC_Rental.Models.PROPERTY> shownProject, IEnumerable<string> expectedTitles)
        {
            //shownProject.ShouldAllBeEquivalentTo(expectedTitles, option => option.Excluding(o => o.ID).WithStrictOrdering());
            shownProject.Select(p => p.PropertyName).Should().BeEquivalentTo(expectedTitles);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownProject, IEnumerable<PROPERTY> expectedProject)
        {
            shownProject.ShouldAllBeEquivalentTo(expectedProject, option => option.Excluding(o => o.ID).WithStrictOrdering());
        }
    }
}
