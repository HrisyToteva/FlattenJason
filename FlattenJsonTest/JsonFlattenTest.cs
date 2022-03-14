using CodingChallenge;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FlattenJsonTest
{
    public class JsonFlattenTest
    {

        [Fact]
        public void TestWithSimpleJson()
        {
            var stringjsonData = "{\"a\":1,\"b\":true,\"c\":{\"d\":3,\"e\":\"test\"}}";

            JObject jObject = JObject.Parse(stringjsonData);


            var propertyAccumulator = new JsonPropertiesAccumulator(jObject);
            var properties = propertyAccumulator.GetAllProperties();

            var flattenedJsonString = JsonConvert.SerializeObject(properties, Formatting.Indented);

            var outputjson = "{\"a\":1,\"b\":true,\"c.d\":3,\"c.e\":\"test\"}";
            JObject jObject2 = JObject.Parse(outputjson);
            var output = JsonConvert.SerializeObject(jObject2, Formatting.Indented);

            Assert.Equal(flattenedJsonString, output);


        }

        [Fact]
        public void TestEmptyJson()
        {
            var stringjsonData = "{}";

            JObject jObject = JObject.Parse(stringjsonData);


            var propertyAccumulator = new JsonPropertiesAccumulator(jObject);
            var properties = propertyAccumulator.GetAllProperties();

            var flattenedJsonString = JsonConvert.SerializeObject(properties, Formatting.Indented);

            var outputjson = "{}";
            JObject jObject2 = JObject.Parse(outputjson);
            var output = JsonConvert.SerializeObject(jObject2, Formatting.Indented);

            Assert.Equal(flattenedJsonString, output);


        }

        [Fact]
        public void TestWithComplexJson()
        {
            var stringjsonData = "{\"a\":1,\"b\":true,\"c\":{\"d\":3,\"e\":\"test\"},\"f\":{\"g\":3,\"h\":\"test\"}}";

            JObject jObject = JObject.Parse(stringjsonData);


            var propertyAccumulator = new JsonPropertiesAccumulator(jObject);
            var properties = propertyAccumulator.GetAllProperties();

            var flattenedJsonString = JsonConvert.SerializeObject(properties, Formatting.Indented);

            var outputjson = "{\"a\":1,\"b\":true,\"c.d\":3,\"c.e\":\"test\",\"f.g\":3,\"f.h\":\"test\"}";
            JObject jObject2 = JObject.Parse(outputjson);
            var output = JsonConvert.SerializeObject(jObject2, Formatting.Indented);

            Assert.Equal(flattenedJsonString, output);


        }

    }
}
