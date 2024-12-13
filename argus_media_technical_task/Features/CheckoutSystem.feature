Feature: CheckoutSystem

  Scenario: A group of 4 people order 4 starters, 4 mains and 4 drinks. The endpoint returns a correctly calculated bill
    Given a group of 4 people order 4 starters, 4 mains and 4 drinks
    When the group requests their final bill
    Then the First total should be correct

  Scenario: A group of 2 people order 1 starter and 2 mains and 2 drinks before 19:00. The bill is requested and the correct amount is shown on the bill. The group of two people are then joined by 2 more people at 20:00 who order 2 mains and 2 drinks, when the party is ready to leave the final bill is requested and is correct.
    Given a group of 2 people order 1 starters, 2 mains and 2 drinks before "19:00"
    When the group requests their bill
    Then the first interim total should be correct
    When 2 more people join at "20:00" and order 2 mains and 2 drinks
    And the group requests their final bill
    Then the Second total should be correct

  Scenario: A group of 4 people order a starter, 1 mains and a drink each. The bill is requested and correctly calculated. A member of the group cancels their order and the order is now updated to reflect one member of the party leaving. A final bill is requested as the party is ready to leave and final amount is correct and reflects the changes to the group.
    Given a group of 4 people order 4 starters, 4 mains and 4 drinks
    When the group requests their bill
    Then the second interim total should be correct
    When 1 person in the group cancels their order
    And the group requests their final bill
    Then the Third total should be correct