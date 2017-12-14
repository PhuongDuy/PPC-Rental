Feature: US09-Login
	In order to login
	As a Agency
	I want to Login a account

@web
Scenario: Successful login 
	Given I am at Home page	
	And Navigate to login page
	When I input the following information
	| Field    | Value                |
	| Email    | anhthy3103@gmail.com |
	| Password | 123456               |
	And I click on Dangnhap Button
	Then I should see successfull message
