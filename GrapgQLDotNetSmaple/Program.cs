using GrapgQLDotNetSmaple.Model.Sample1;
using GrapgQLDotNetSmaple.Model.Sample2;
using GraphQL;
using GraphQL.Types;
using System;
using System.Threading.Tasks;

namespace GrapgQLDotNetSmaple
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Sample1();
            await Sample2();
        }

        private async static Task Sample1()
        {
            try
            {
                SchemaBuilder builder = new SchemaBuilder();

                Context ctx = new Context()
                {
                    UserInfo = new Card()
                    {
                        UserName = "Steve",
                        Organization = "Apple"
                    }
                };

                Schema schema1 = builder.GetSchema(ctx);


                string res1 = await schema1.ExecuteAsync(_ =>
                {
                    _.Query = @"query { viewer { login, company } }";
                });
                Console.WriteLine($"Res1: {res1}");
            } catch (Exception e)
            {
                Console.WriteLine($"Error: {e.ToString()}");
            }
        }

        private async static Task Sample2()
        {
            try
            {
                string schemaDef = @"
type Droid {
    id: ID
    name: String
}

type Jedi {
    id: ID
    firstname: String
    lastname: String
}

type Query {
    droid: Droid
    jedi: Jedi
}
";

                ISchema schema = Schema.For(schemaDef, _ =>
                {
                    _.Types.Include<Query>();
                });

                string res1 = await schema.ExecuteAsync(_ =>
                {
                    _.Query = "{ droid { id name } }";
                });
                Console.WriteLine($"Res: {res1}");
                string res2 = await schema.ExecuteAsync(_ =>
                {
                    _.Query = "{ jedi { firstname lastname } }";
                });
                Console.WriteLine($"Res: {res2}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.ToString()}");
            }
        }
    }
}
