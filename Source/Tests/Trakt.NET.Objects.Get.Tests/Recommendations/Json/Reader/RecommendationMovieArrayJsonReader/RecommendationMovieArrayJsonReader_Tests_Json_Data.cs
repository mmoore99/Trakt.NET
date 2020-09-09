﻿namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    public partial class RecommendationMovieArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
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
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
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
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""ra"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
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
                  ""ra"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
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
                  ""ra"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""ra"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                }
              ]";
    }
}
