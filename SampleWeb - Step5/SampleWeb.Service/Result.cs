using SampleWeb.Service.Interface;
using System;
using System.Collections.Generic;

namespace SampleWeb.Service
{
    public class Result : IResult
    {
        public Guid ID
        {
            get;
            private set;
        }

        public bool Success
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public Exception Exception
        {
            get;
            set;
        }

        public List<IResult> InnerResults
        {
            get;
            protected set;
        }


        public Result()
            : this(false)
        {
        }

        public Result(bool success)
        {
            ID = Guid.NewGuid();
            Success = success;
            InnerResults = new List<IResult>();
        }

    }
}
