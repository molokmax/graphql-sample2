using GrapgQLDotNetSmaple.Model;
using GrapgQLDotNetSmaple.Model.Sample1;
using GraphQL.Resolvers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrapgQLDotNetSmaple.Resolvers
{
    public class ViewerResolver : IFieldResolver
    {
        private Context source;
        public ViewerResolver(Context src)
        {
            source = src;
        }
        public object Resolve(ResolveFieldContext context)
        {
            //var idArgStr = context.Arguments?["id"].ToString() ?? Guid.Empty.ToString();
            //var idArg = Guid.Parse(idArgStr);
            //Console.WriteLine($"ID = {idArg}");
            return source.UserInfo;
        }
    }
}
