Feature: US12-ViewlistofNews
	As a potential customer
	I want to view the viewlistofnews of a properety
	So that I could choose the most suitable property

Background: 
	Given the following property
	| Name                                        | Content                                                                      | Created_at |
	| TẠI SAO TÔI NÊN CHỌN VINHOMES CENTRAL PARK? | Vinhomes Central Park là "thành phố xanh thu nhỏ" với mật độ xây dựng 16%... | 2017-05-12 |

Scenario: Viewlistofnews should be matched
	Given user at the Home Page
	When user click for new by the pharse 'New'
	Then user should see the following information
	| Name                                        | Content                                                                      | Created_at |
	| TẠI SAO TÔI NÊN CHỌN VINHOMES CENTRAL PARK? | Vinhomes Central Park là "thành phố xanh thu nhỏ" với mật độ xây dựng 16%... | 2017-05-12 |

