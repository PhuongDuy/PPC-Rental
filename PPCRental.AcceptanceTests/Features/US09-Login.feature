Feature: US09-Login
	In order to login
	As a Agency
	I want to login a Account


@mytag
Scenario: Sucessfull Login
	Given I am at home page
	And Navigate to Login page
	When I input the following information
	| Field    | Value            |
	| Email    | anhthy3103@gmail |
	| Password | 123456           |
	And I click on Login Button
	Then I should see sucessfull message
