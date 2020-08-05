﻿namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CrewMemberArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""jobs"": [
                    ""Director""
                  ],
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""jobs"": [
                    ""Director""
                  ],
                  ""person"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""jobs"": [
                    ""Director""
                  ],
                  ""person"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""jobs"": [
                    ""Director""
                  ],
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""jobs"": [
                    ""Director""
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""j"": ""Director"",
                  ""js"": [
                    ""Director""
                  ],
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""jobs"": [
                    ""Director""
                  ],
                  ""person"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""jobs"": [
                    ""Director""
                  ],
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""jobs"": [
                    ""Director""
                  ],
                  ""pers"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""j"": ""Director"",
                  ""js"": [
                    ""Director""
                  ],
                  ""person"": {
                    ""name"": ""Bryan Cranston"",
                    ""ids"": {
                      ""trakt"": 297737,
                      ""slug"": ""bryan-cranston"",
                      ""imdb"": ""nm0186505"",
                      ""tmdb"": 17419,
                      ""tvrage"": 1797
                    }
                  }
                },
                {
                  ""jobs"": [
                    ""Director""
                  ],
                  ""pers"": {
                    ""name"": ""Samuel L.Jackson"",
                    ""ids"": {
                      ""trakt"": 9486,
                      ""slug"": ""samuel-l-jackson"",
                      ""imdb"": ""nm0000168"",
                      ""tmdb"": 2231,
                      ""tvrage"": 55720
                    }
                  }
                }
              ]";
    }
}
