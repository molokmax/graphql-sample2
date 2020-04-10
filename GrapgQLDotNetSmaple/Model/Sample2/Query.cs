using GraphQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrapgQLDotNetSmaple.Model.Sample2
{
    public class Query
    {
        [GraphQLMetadata("droid")]
        public Droid GetDroid()
        {
            return new Droid { Id = "123", Name = "R2-D2" };
        }
        [GraphQLMetadata("jedi")]
        public Jedi GetJedi()
        {
            return new Jedi { Id = "456", FirstName = "Anakin", LastName = "Skywalker" };
        }
    }
}
