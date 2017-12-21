Feature: US08-Contact
	As a potential customer
	I want to view the contact of a properety
	So that I could choose the most suitable property


Scenario: Contact should be matched
	Given i at the Home Page
	When i click for contact by the pharse 'Contact'
	And i enter information
	| Full name    | Email                    | Title         | Content      |
	| Trần Phú Hòa | tranphuhoa1995@gmail.com | Dự án Winhome | Mở lại dự án |
	Then i click to sent contact