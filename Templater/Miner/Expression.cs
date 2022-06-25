using System.Text.RegularExpressions;
using Templater.Miner.Models;
using Exc = Templater.Miner.Models.Exceptions.Exceptioner;

namespace Templater.Miner
{
    internal class Expression : IDisposable
    {
        #region IDisposable

        private bool disposed;

        ~Expression()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed objects
            }
            // Dispose unmanaged objects
            disposed = true;
        }

        #endregion IDisposable

        internal IEnumerable<ExpressionFM> Find(string text)
        {
            if (!Expression.IsFound(text)) throw Exc.ExpressionNotFound();

            var found = RegexConfig.Expression.Matches(text);

            if (found is null) throw Exc.ExpressionNotFound();

            var groups = found.Select(x => x.Groups);
            var values = found.Select(x => x.Value);
            var indexes = found.Select(x => x.Index);

            if (!found.Any())
                return Enumerable.Empty<ExpressionFM>();

            return found.Select(x => new ExpressionFM()
            {
                FoundText = x.Value,
                IndexStart = x.Index
            });
        }

        internal static bool IsFound(string text) => RegexConfig.Expression.IsMatch(text);

        private static class RegexConfig
        {
            /// /// <summary>
            /// Get expression which will be invoke for passed data and string.
            /// <br /><br />
            /// Pattern is described with {{KEY_IN_DATA_SOURCE:OBJECT_PROPERTY}}
            /// <br />
            /// Example: {{User:Name}}
            /// </summary>
            public static Regex Expression = new Regex(@"(?<=\{{)[^}}]+(?=\}})");

            /// <summary>
            /// Get expression which will be invoke for each record of list.
            ///<br /><br />
            /// Pattern is described with &lt;ANY_EXPRESSION&gt;
            /// <br />
            /// Example: {{FetchedData:Products&lt;Product:Name&gt;}} <br />- where Product inside of brackets is reference to n row in list and Name his property.
            /// </summary>
            // public static Regex List = new Regex(@"\<{1,}(.*?)\>{1,}");

            /// <summary>
            /// Get expression of function which is available for object the program work with.
            /// <br /><br />
            /// Pattern is described with .FUNCTION_NAME().
            /// <br />
            /// Example:
            /// Method arguments will be send to separate group.
            /// </summary>
            public static Regex InternalObjFunction = new Regex(@"\.(.*?)\((.*?)\)");

            /// <summary>
            /// Get group
            /// </summary>
            public static Regex Group = new Regex(@"\((.*)\)");

            /// <summary>
            /// Get expression of function which is available for end data type.
            /// <br /><br />
            /// Pattern is described with .FUNCTION_NAME().
            /// <br />
            /// Example:
            /// Method arguments will be send to separate group.
            /// </summary>
            public static Regex DataTypeFunction = new Regex(@"\:.(.*?)\((.*?)\)");

            /// <summary>
            /// Get expression of function which is available in Digger class.
            /// <br /><br />
            /// Pattern is described with .FUNCTION_NAME().
            /// <br />
            /// Example:
            /// Method arguments will be send to separate group.
            /// </summary>
            // public static Regex DiggerFunction = new Regex(@"\#(.*?)\((.*?)\)");
        }
    }
}