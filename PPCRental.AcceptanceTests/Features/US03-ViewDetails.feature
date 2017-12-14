Feature: US03-ViewDetails
	As a potential customer
	I want to view the details of a properety
	So that I could choose the most suitable property

Background:
Given the following projects
| PropertyName                     | Price | PropertyType | District  | Ward        | Street       | PackingPlace | Bed Room | Bathroom | Content                                                                                                                                                                                                   | UnitPrice |
| PIS Serviced Apartment – Style 3 | 30000 | Office       | Chương Mỹ | TT Chúc Sơn | Đường Nội Bộ | 1            | 2        | 4        | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs.. Behind the industrial glass wall you will find the bedroom area with a double bed and a large closet. | USD       |

@automated
Scenario: The details of selected property should show
	When I open the details of 'PIS Serviced Apartment – Style 3'
	Then I should see the following information
| PropertyName                     | Price | PropertyType | District  | Ward        | Street       | PackingPlace | Bed Room | Bathroom | Content                                                                                                                                                                                                   | UnitPrice |
| PIS Serviced Apartment – Style 3 | 30000 | Office       | Chương Mỹ | TT Chúc Sơn | Đường Nội Bộ | 1            | 2        | 4        | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs.. Behind the industrial glass wall you will find the bedroom area with a double bed and a large closet. | USD       |