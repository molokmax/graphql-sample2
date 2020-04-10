using GrapgQLDotNetSmaple.Model;
using GrapgQLDotNetSmaple.Model.Sample1;
using GrapgQLDotNetSmaple.Resolvers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrapgQLDotNetSmaple
{
    public class SchemaBuilder
    {
        public Schema GetSchema(Context ctx)
        {
            Schema result = new Schema();

            FieldType viewerField = GetViewerField(ctx);

            var queryType = new ObjectGraphType();
            queryType.AddField(viewerField);
            result.Query = queryType;

            return result;
        }

        private FieldType GetViewerLoginField()
        {
            var loginField = new GraphQL.Types.FieldType();
            loginField.Name = "login";
            loginField.ResolvedType = new StringGraphType();
            loginField.Type = typeof(string);
            loginField.Resolver = new ViewerLoginResolver();
            return loginField;
        }

        private FieldType GetViewerCompanyField()
        {
            var loginField = new GraphQL.Types.FieldType();
            loginField.Name = "company";
            loginField.ResolvedType = new StringGraphType();
            loginField.Type = typeof(string);
            loginField.Resolver = new ViewerCompanyResolver();
            return loginField;
        }

        private IGraphType GetViewerType()
        {
            ObjectGraphType<Card> viewerType = new ObjectGraphType<Card>();
            viewerType.Name = "Viewer";
            FieldType loginField = GetViewerLoginField();
            viewerType.AddField(loginField);
            FieldType companyField = GetViewerCompanyField();
            viewerType.AddField(companyField);
            return viewerType;
        }

        private FieldType GetViewerField(Context ctx)
        {
            IGraphType viewerType = GetViewerType();
            var viewerField = new FieldType();
            viewerField.Name = "viewer";
            viewerField.ResolvedType = viewerType;
            viewerField.Type = typeof(Card);

            //var idArgument = new QueryArgument(typeof(IdGraphType));
            //idArgument.Name = "id";
            //idArgument.ResolvedType = new IdGraphType();
            //idArgument.DefaultValue = Guid.Empty;
            //viewerField.Arguments = new QueryArguments(idArgument);

            viewerField.Resolver = new ViewerResolver(ctx);
            return viewerField;
        }

    }
}
