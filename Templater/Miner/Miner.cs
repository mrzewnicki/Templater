using System;
using System.Collections.Generic;
using System.Linq;
using Exc = Templater.Miner.Models.Exceptions.Exceptioner;

namespace Templater.Miner
{
    public class Miner : IDisposable
    {
        #region IDisposable

        private bool disposed;

        ~Miner()
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

        public Dictionary<string, object> DataContext { get; set; }

        public Miner(Dictionary<string, object> dataContext)
        {
            DataContext = dataContext;
        }

        public string Fill(string text)
        {
            using (Expression expression = new Expression())
            {
                var found = expression.Find(text);
            }

            return text;
        }

        internal object GetValueFrom(object source, string propName)
        {
            var props = source.GetType().GetProperties();

            if (props is null || props.Length == 0)
                return null;

            if (!props.Any(x => x.Name == propName))
                throw Exc.GetProperty();

            var foundProp = props.Where(x => x.Name == propName).First();

            var propValue = foundProp.GetValue(source, null);

            return propValue;
        }
    }
}