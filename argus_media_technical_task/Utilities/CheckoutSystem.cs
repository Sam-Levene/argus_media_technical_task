using System.Diagnostics;
using System.Globalization;

namespace argus_media_technical_task.Utilities;

public class CheckoutSystem {

    readonly decimal mainsCost = 7.00m;
    readonly decimal startersCost = 4.00m;
    readonly decimal drinksCost = 2.50m;
    decimal updatedStartersCost;
    decimal updatedMainsCost;
    decimal updatedDrinksCost;
    decimal finalBill;
    readonly DateTime happyHour = DateTime.ParseExact("19:00", "HH:mm", CultureInfo.InvariantCulture);

    public void CalculateStarters(int numberStarters) {
        updatedStartersCost = startersCost * numberStarters;
    }

    public void CalculateMains(int numberMains) {
        updatedMainsCost = mainsCost * numberMains;
    }

    public void UpdateMains(int numberOfNewMains) {
        updatedMainsCost += numberOfNewMains * mainsCost;
    }

    public void UpdateDrinks(int numberOfNewDrinks, DateTime timeOfDay) {
         if (timeOfDay > happyHour) {
            decimal interimDrinksCost = drinksCost - (drinksCost * 3 / 10);
            updatedDrinksCost += interimDrinksCost * numberOfNewDrinks;
        } else {
            updatedDrinksCost += drinksCost * numberOfNewDrinks;
        }
    }

    public void UpdateStarters(int numberOfNewStarters) {
        updatedStartersCost += numberOfNewStarters * startersCost;
    }

    public void CalculateDrinks(int numberOfDrinks, DateTime timeOfDay) {
        
        if (timeOfDay > happyHour) {
            decimal interimDrinksCost = drinksCost - (drinksCost * 3 / 10);
            updatedDrinksCost = interimDrinksCost * numberOfDrinks;
        } else {
            updatedDrinksCost = drinksCost * numberOfDrinks;
        }
       
    }

    public void CalculateFinalBill() {
        decimal serviceCharge = (updatedMainsCost + updatedStartersCost) * 1 / 10;
        decimal foodCost = updatedMainsCost + updatedStartersCost + serviceCharge;
        Debug.WriteLine("Drinks Cost: £" +  updatedDrinksCost);
        Debug.WriteLine("Starters Cost: £" +  updatedStartersCost);
        Debug.WriteLine("Mains Cost: £" +  updatedMainsCost);
        Debug.WriteLine("Service Charge: £" +  serviceCharge);
        finalBill = Math.Round(updatedDrinksCost + foodCost, 2);
        Debug.WriteLine("Current Final Bill: £" +  finalBill);
    }

    public decimal RequestFinalBill() {
        return finalBill;
    }
}