using System;
namespace JeBalance.Settings
{
    public static class ClaimDefinitions
    {

        public static class ClaimTypes
        {
            /// <summary>
            /// La date de création du token
            /// </summary>
            public const string IssuedDateTime = "IssuedDateTime";

            /// <summary>
            /// Le format de la date de création du token
            /// Format de la date ISO 8601 utilisé pour représenter un DateTime dans les fichiers JSON
            /// </summary>
            public const string IssuedDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffk";

            /// <summary>
            /// La durée de vie du token
            /// </summary>
            public const string LifeTime = "LifeTime";
        }

        public static class GivenName
        {
            public const string AuthenticationService = nameof(AuthenticationService);
        }

        public static class NameIdentifier
        {
            public const string AuthenticationService = nameof(AuthenticationService);
        }
    }
}

