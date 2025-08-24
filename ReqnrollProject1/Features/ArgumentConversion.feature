Feature: Argument Conversion

Scenario: Customer can add non-expired offer code to the basket
Given I have offer code 'CODE1' which expires in '3 days time'
When I add offer code 'CODE1' to the basket
Then the offer code is valid

Scenario: Customer can add expired offer code to the basket
Given I have offer code 'CODE1' which expires '7 days ago'
When I add offer code 'CODE1' to the basket
Then the offer code is invalid

Scenario: Customer Visit Challenge - First
Given I am the customer N°1 to view the offer page
Then I am given a special discount

Scenario: Customer Visit Chalenge  - Second
Given I am the customer N°2 to view the offer page
Then I am not given a special discount

Scenario: Customer Visit Chalenge - Forty 
Given I am the customer N°4 to view the offer page
Then I am not given a special discount

Scenario: Customer Visit Chalenge - Zero or Negative 
Given I am the customer N°0 to view the offer page
Then an IndexOutOfRangeException is thrown