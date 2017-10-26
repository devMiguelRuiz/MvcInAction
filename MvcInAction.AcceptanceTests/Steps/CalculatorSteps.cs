using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcInAction.AcceptanceTests.Helpers;
using TechTalk.SpecFlow;

namespace MvcInAction.AcceptanceTests.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly Calculator _calculator = new Calculator();
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _calculator.FirstNumber = p0;
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int p0)
        {
            _calculator.SecondNumber = p0;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(_result, p0);
        }
    }
}
