﻿namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class NetworkObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_NetworkObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new NetworkObjectJsonWriter();
            ITraktNetwork traktNetwork = new TraktNetwork();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktNetwork);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktNetwork traktNetwork = new TraktNetwork
            {
                Network = "network"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new NetworkObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktNetwork);
                stringWriter.ToString().Should().Be(@"{""network"":""network""}");
            }
        }
    }
}
