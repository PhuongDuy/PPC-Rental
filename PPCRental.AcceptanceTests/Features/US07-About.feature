Feature: US07-About
	As a potential customer
	I want to view the about of a properety
	So that I could choose the most suitable property

Background: 
	Given the following property
	| Title   | About us                                   | Our Team                                   | CEO                                        | Decription                                 |
	| WELCOME | Perfect Property Company (PPC) is known... | Perfect Property Company (PPC) is known... | Perfect Property Company (PPC) is known... | Perfect Property Company (PPC) is known... |

Scenario: About should be matched
	Given User at a Home Page
	When User click for about by the pharse 'About'
	Then User should see the following information
	| Title   | About us                                   | Our Team                                   | CEO                                        | Decription                                 |
	| WELCOME | Perfect Property Company (PPC) is known... | Perfect Property Company (PPC) is known... | Perfect Property Company (PPC) is known... | Perfect Property Company (PPC) is known... |
