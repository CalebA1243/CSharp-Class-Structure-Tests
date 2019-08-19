using System;
using System.Collections;

namespace LearningProject
{

    public abstract class Test
    {
        public abstract void TestMethod();

        public void TestClassMethod()
        {
            Console.Write("The abstract class method got called.");
        }
    }

    public interface ITest
    {
        void Test();
    }

    public class TestImplementation : Test, ITest
    {
        public void Test()
        {
            throw new NotImplementedException();
        }

        public override void TestMethod()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var testImplemenation = new Test();
        }
    }
}
