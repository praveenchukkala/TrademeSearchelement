Feature: Trademe element search

Search for an element

@suziki
Scenario: Search for an element in trademe
	Given Open the browser
	When Enter the URL
	Then Search for the <elements>
	Examples: 
	| elements |
	| Suzuki   |
	| Honda    |
	
	