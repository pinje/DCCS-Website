using Microsoft.VisualStudio.TestTools.UnitTesting;
using DLL;
using DAL.SeasonBranch;
using Models;

namespace UnitTest
{
    [TestClass]
    public class SeasonUnitTest
    {
        [TestMethod]
        public void AddSeason_Validate()
        {
            // arrange 
            SeasonManager seasonManager = new SeasonManager(new MockSeasonDAL());

            // act
            seasonManager.AddSeason(new Season(1, 1, 1, SeasonStage.PLAYOFFS, SeasonStatus.UPCOMING, "playoffs"));
            Season expected = seasonManager.GetSeason(1);

            // assert
            Assert.AreEqual(expected.SeasonNumber, 1);
            Assert.AreEqual(expected.SplitNumber, 1);
            Assert.AreEqual(expected.Stage, SeasonStage.PLAYOFFS);
            Assert.AreEqual(expected.Status, SeasonStatus.UPCOMING);
            Assert.AreEqual(expected.HubId, "playoffs");
        }
    }
}