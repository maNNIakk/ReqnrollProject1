Feature: DataTables


Background: 
	Given I have the following data
		| ProductId | Stock | Basket |
		| 1         | 2     | 0      |
		| 2         | 0     | 0      |
		| 3         | 2     | 1      |
		| 4         | 5     | 1      |

Scenario Outline:  Testing funcionality of basket
	Given I am on the product detail page of product <ProductId>
	When I click the Add to Basket button
	Then the quantities are stock level of <Stock> and basket qty of <Basket>
    And a message <Message> is displayed to the customer
	Examples:
	| Description       | ProductId | Stock | Basket | Message             |
	| In Stock          | 1         | 1     | 1      | 'Added to basket'   |
	| Out of Stock      | 2         | 0     | 0      | 'Out of stock'      |
	| Already in Basket | 3         | 2     | 1      | 'Already in basket' |

Scenario: Testing Remove Item from Basket
	Given I am on the basket page
	When I remove Product Id 3 from basket
	And I remove Product Id 4 from basket
	Then the quantities are
	| Product Id | Stock | Basket |
	| 1          | 2     | 0      |
	| 2          | 0     | 0      |
	| 3          | 3     | 0      |
	| 4          | 6     | 0      |

	Scenario: Customer can add offer code to the basket

	Given I have the following offer codes
	| OfferCode | ExpiryDate | OfferCodeType | IsValid |
	| CODE1     | 06/20/2025 | ByDate        | Yes     |
	| CODE2     | 06/05/2025 | ByDate        | No      |
	And today is '06/04/2025'
	When I add offer code 'CODE1' to the basket
	Then the offer code is valid