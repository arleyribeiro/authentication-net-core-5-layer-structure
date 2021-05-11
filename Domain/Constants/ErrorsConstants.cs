namespace Domain.Constants
{
    public static class ErrorsConstants
    {
        public const int GENERIC_ERROR = 199;
        public const int REQUIRED_PARAMETER = 300;
        public const int INVALID_PARAMETER = 301;
        public const int CREATED_AT_INVALID = 302;
        public const int FUTURE_CREATED_AT_INVALID = 303;
        public const int UPDATED_AT_INVALID = 304;
        public const int FUTURE_UPDATED_AT_INVALID = 305;

        public static class Register
        {
            public const int MIN_LENGTH_PASSWORD = 1000;
            public const int MAX_LENGTH_PASSWORD = 1001;
            public const int MIN_LENGTH_USERNAME = 1002;
            public const int MAX_LENGTH_USERNAME = 1003;
            public const int INVALID_ROLE = 1004;
        }
    }
}