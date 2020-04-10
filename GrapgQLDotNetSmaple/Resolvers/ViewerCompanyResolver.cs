using GrapgQLDotNetSmaple.Model;
using GrapgQLDotNetSmaple.Model.Sample1;
using GraphQL.Resolvers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrapgQLDotNetSmaple.Resolvers
{
    public class ViewerCompanyResolver : IFieldResolver
    {
        public object Resolve(ResolveFieldContext context)
        {
            // Предполагаем, что у нас в контексте будет какой-то наш объект UserInfo
            // который нам передаст родительский обработчик viewer
            return (context.Source as Card).Organization;
        }
    }
}
