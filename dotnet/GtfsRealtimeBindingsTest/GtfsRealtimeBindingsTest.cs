using System.IO;
using System.Net;
using Xunit;
using ProtoBuf;
using transit_realtime;

namespace Xunit_Bindings_test
{
    public class GtfsRealtimeBindingsTest
    {
        [Fact]
        public void TestReadVehiclePosition()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "vehicle_position.pb");
            var req = WebRequest.Create(path);
            FeedMessage feed = Serializer.Deserialize<FeedMessage>(req.GetResponse().GetResponseStream());
            int c = feed.entity.Count;
            Assert.True(c== 1);
            var entity = feed.entity[0];
            Assert.True(entity.id == "1");
            Assert.False(entity.vehicle == null);
        }
    }
}
