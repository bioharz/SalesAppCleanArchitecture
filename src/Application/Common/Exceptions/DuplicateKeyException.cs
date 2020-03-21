using System;

namespace CleanArchitecture.Application.Common.Exceptions
{
    public class DuplicateKeyException : Exception
    {
        public DuplicateKeyException()
            : base($"Entity already exist in the database.")
        {
        }
    }
}