Feature: US03_ViewDetails
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
Given the following projects
| Property Name                    | Street Name                        | Price     | Property Type | District  | Ward        | Street       | Packing Place | Bed Room | Bathroom | Content                                                                                                                                                                                                   |
| PIS Serviced Apartment – Style 3 | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 30000 USD | Office        | Chương Mỹ | TT Chúc Sơn | Đường Nội Bộ | 1             | 2        | 4        | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs.. Behind the industrial glass wall you will find the bedroom area with a double bed and a large closet. |


Scenario: Hien thi chi tiet du an thanh cong  
	When User click "ID_Project"
	Then Hien thi thong tin chi tiet du an
| Property Name                    | Street Name                        | Price     | Property Type | District  | Ward        | Street       | Packing Place | Bed Room | Bathroom | Content                                                                                                                                                                                                   |
| PIS Serviced Apartment – Style 3 | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 30000 USD | Office        | Chương Mỹ | TT Chúc Sơn | Đường Nội Bộ | 1             | 2        | 4        | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs.. Behind the industrial glass wall you will find the bedroom area with a double bed and a large closet. |

