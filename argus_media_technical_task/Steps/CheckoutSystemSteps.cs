using System.Globalization;
using argus_media_technical_task.Utilities;
using TechTalk.SpecFlow;
using Xunit;

namespace argus_media_technical_task.Steps;

[Binding]
public class CheckoutSystemSteps()
{
    readonly CheckoutSystem checkoutSystem = new();

    [Given(@"a group of {int} people order {int} starters, {int} mains and {int} drinks before {string}")]
    public void GivenAGroupOfNPeopleOrderNStartersNMainsAndNDrinksTime(int people, int starters, int mains, int drinks, string time)
    {
        checkoutSystem.CalculateDrinks(drinks, DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture));
        checkoutSystem.CalculateMains(mains);
        checkoutSystem.CalculateStarters(starters);
    }

    [Given(@"a group of {int} people order {int} starters, {int} mains and {int} drinks")]
    public void GivenAGroupOfNPeopleOrderNStartersNMainsAndNDrinksTime(int people, int starters, int mains, int drinks)
    {
        // Assumption: The time is after 7pm, as it is not defined in the scenario
        checkoutSystem.CalculateDrinks(drinks, DateTime.ParseExact("20:00", "HH:mm", CultureInfo.InvariantCulture));
        checkoutSystem.CalculateMains(mains);
        checkoutSystem.CalculateStarters(starters);
    }

    [When(@"the group requests their final bill")]
    public void WhenTheGroupRequestsTheirFinalBill()
    {
        checkoutSystem.CalculateFinalBill();
    }

    [When(@"the group requests their bill")]
    public void WhenTheGroupRequestsTheirBill()
    {
        checkoutSystem.CalculateFinalBill();
    }

    [When("{int} more people join at {string} and order {int} mains and {int} drinks")]
    public void WhenMorePeopleJoinAtPmAndOrderMainsAndDrinks(int people, string time, int mains, int drinks)
    {
        checkoutSystem.UpdateMains(mains);
        checkoutSystem.UpdateDrinks(drinks, DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture));
    }

    [When("{int} person in the group cancels their order")]
    public void WhenPersonInTheGroupCancelsTheirOrder(int numberChange)
    {
        // Assumption: The time is after 7pm, as it is not defined in the scenario
        checkoutSystem.UpdateStarters(numberChange);
        checkoutSystem.UpdateMains(numberChange);
        checkoutSystem.UpdateDrinks(numberChange, DateTime.ParseExact("20:00", "HH:mm", CultureInfo.InvariantCulture));
    }

    [Then(@"the First total should be correct")]
    public void ThenTheFirstTotalShouldBeCorrect()
    {
        Assert.Equal(58.40m, checkoutSystem.RequestFinalBill());
    }

    [Then("the first interim total should be correct")]
    public void ThenTheFirstInterimTotalShouldBeCorrect()
    {
        Assert.Equal(24.80m, checkoutSystem.RequestFinalBill());
    }

    [Then("the second interim total should be correct")]
    public void ThenTheSecondInterimTotalShouldBeCorrect()
    {
        Assert.Equal(58.40m, checkoutSystem.RequestFinalBill());
    }

    [Then("the Second total should be correct")]
    public void ThenTheSecondTotalShouldBeCorrect()
    {
        Assert.Equal(45.20m, checkoutSystem.RequestFinalBill());
    }

    [Then("the Third total should be correct")]
    public void ThenTheThirdTotalShouldBeCorrect()
    {
        Assert.Equal(73.00m, checkoutSystem.RequestFinalBill());
    }
}
