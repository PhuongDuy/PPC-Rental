@automated
Feature: US05-ViewListOfProjectAgency
As a salesman,
I want to see the list of real estate projects posted by users
So I can choose the real estate projects that need fixing

Background: 
Given the following project list
| PropertyName                     | PropertyType | District  | Street       | Status   |
| PIS Serviced Apartment – Style 3 | Office       | Chương Mỹ | Đường Nội Bộ | Đã duyệt |       

@mytag
Scenario: Show property list of agency
	Given The project has been approved
	When I at the Sale Page
	Then I will see status of project
         | Status   |
         | Đã duyệt |