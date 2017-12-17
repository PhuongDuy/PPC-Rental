Feature: US01-Filter
	As a potential customer
	I want to view the filter of a properety
	So that I could choose the most suitable property

Background: 
	Given the following property
		| Property_Name          | Property_Type | Ward_ID     | Price | Bedroom | District_ID | Bathroom |
		| PIS Top Apartment      | Apartment     | TT Tây Đằng | 10000 | 3       | Ba Vì       | 3        |
		| Modern Style Apartment | Villa         | Ba Trại     | 30000 | 2       | Ba Vì       | 4        |
		| PIS Serviced Apartment | Villa         | Ba Vì       | 70000 | 3       | Ba Vì       | 2        |

Scenario: PropertyName should be matched
	Given I at the Home Page
	When I search for property by the pharse 'Property name'
	Then I should see the following information
		| Property_Name          |
		| PIS Top Apartment      | 
		| Modern Style Apartment | 
		| PIS Serviced Apartment | 
