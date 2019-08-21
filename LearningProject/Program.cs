using System;
using System.Collections;
using System.Threading;

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

        //public delegate void TestFinishedEventHandler(object source, EventArgs args);

        public event EventHandler TestFinished;


        public void Test()
        {
            Console.WriteLine("Test method in progress.");
            Thread.Sleep(3000);
            OnTestFinished();

        }

        public override void TestMethod()
        {
            throw new NotImplementedException();
        }

        private void OnTestFinished()
        {
            TestFinished ? .Invoke(this, EventArgs.Empty);
        }
    }

    public class TestSubscriber
    {
        public void OnTestFinished(object source, EventArgs e)
        {
            Console.WriteLine("Currently writing a thing");
        }
    }

    public static class ExtensionMethods
    {
        public static void WriteString(this string str)
        {
            Console.WriteLine(str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var testImplemenation = new TestImplementation();
            var testImplementation2 = Activator.CreateInstance(typeof(TestImplementation));
            var testSubsriber = new TestSubscriber();

            testImplemenation.TestFinished += testSubsriber.OnTestFinished;
            "Hi".WriteString();
            testImplemenation.Test();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
