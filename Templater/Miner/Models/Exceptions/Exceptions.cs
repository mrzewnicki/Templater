using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templater.Miner.Models.Exceptions
{
    public static class Exceptioner
    {
        public static ExpressionNotFoundException ExpressionNotFound() => new ExpressionNotFoundException();

        public static ExpressionFormatException ExpressionFormat() => new ExpressionFormatException();

        public static NextStepRecognizeException NextStepRecognize() => new NextStepRecognizeException();

        public static GetPropertyException GetProperty() => new GetPropertyException();

        public static FillWithValueException FillWithValue() => new FillWithValueException();
    }

    public class ExpressionNotFoundException : Exception
    {
        public ExpressionNotFoundException() : base("Expression didn't found in analized text")
        {
        }
    }

    public class ExpressionFormatException : Exception
    {
        public ExpressionFormatException() : base("Invalid expression format")
        {
        }
    }

    public class NextStepRecognizeException : Exception
    {
        public NextStepRecognizeException() : base("cannot recognize next step")
        {
        }
    }

    public class GetPropertyException : Exception
    {
        public GetPropertyException() : base("Cannot get property from object")
        {
        }
    }

    public class FillWithValueException : Exception
    {
        public FillWithValueException() : base("Cannot fill expression with value")
        {
        }
    }
}