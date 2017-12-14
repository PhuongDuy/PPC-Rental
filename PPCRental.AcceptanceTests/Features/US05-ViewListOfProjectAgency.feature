Feature: US05-ViewListOfProjectAgency
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Show project agency list
	Given Saler login system by Sale account
	When Saler enter account information
	| Field    | Value            |
	| Email    | duyho9@gmail.com |
	| Password | 123456789        |
	And Saler click on Login Button
	Then Show project list of agency
	| Ten du an                        | Loai du an | Quan      | Duong        | Trang thai |
	| PIS Serviced Apartment – Style 3 | Office     | Chuong My | Duong Noi Bo | Da duyet   |
