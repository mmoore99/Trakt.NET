﻿namespace TraktNet.Tests.Objects.Get.People.Credits.Json.Reader
{
    public partial class PersonMovieCreditsCrewItemArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""job"": ""Director"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""job"": ""Producer"",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""job"": ""Producer"",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""job"": ""Director"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""job"": ""Producer""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""j"": ""Director"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""job"": ""Producer"",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""job"": ""Director"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""job"": ""Producer"",
                  ""mov"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""j"": ""Director"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""job"": ""Producer"",
                  ""mov"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 12601,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";
    }
}
