Feature: RegisterNewUser
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Successfully Register a New Account
Given I am at Home Page
And Navigate to register page
When I input the following information
	| Field            | Value                |
	| FullName         | Anh Thy              |
	| Email            | anhthy3103@gmail.com |
	| Password         | 123456               |
	| Re-type Password | 123456               |
	| Phone            | 0125487963           |
	| Address          | Cong Hoa             |
	| Role             | 1                    |
	| Status           | True                 |
And I click on Submit button
Then I should see successful message